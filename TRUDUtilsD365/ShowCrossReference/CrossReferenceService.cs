using System;
using System.Collections.Generic;
using EnvDTE;
using Microsoft.Dynamics.AX.Framework.Xlnt.XReference;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.Core;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.MetaModel;
using Microsoft.Dynamics.Framework.Tools.Configuration;
using Microsoft.Dynamics.AX.Metadata.Storage;
using Microsoft.Dynamics.AX.Metadata.Storage.DiskProvider;
using Microsoft.Dynamics.AX.Metadata.Providers;
using TRUDUtilsD365.Kernel;

namespace TRUDUtilsD365.ShowCrossReference
{
    /// <summary>
    /// Handles all D365 Add-in API interactions: cross-reference queries,
    /// X++ source text extraction, and VS editor navigation.
    /// </summary>
    public class CrossReferenceService
    {
        private readonly Dictionary<string, string> _sourceTextCache = new Dictionary<string, string>();
        private static IMetadataProvider _fallbackMetadataProvider;

        private static IMetadataProvider GetMetadataProvider()
        {
            var designService = DesignMetaModelService.Instance
                                ?? AxServiceProvider.GetService<IDesignMetaModelService>() as DesignMetaModelService;
            if (designService != null)
            {
                return designService.CurrentMetadataProvider;
            }

            if (_fallbackMetadataProvider == null)
            {
                var config = ConfigurationHelper.CurrentConfiguration;
                var diskConfig = new DiskProviderConfiguration
                {
                    XppMetadataPath = config.ModelStoreFolder,
                    MetadataPath = config.ModelStoreFolder
                };
                _fallbackMetadataProvider = new MetadataProviderFactory().CreateDiskProvider(diskConfig);
            }
            return _fallbackMetadataProvider;
        }

        private static ICrossReferenceProvider GetCrossReferenceProvider()
        {
            if (DesignMetaModelService.Instance != null)
            {
                return DesignMetaModelService.Instance.CrossReferenceProvider;
            }

            var config = ConfigurationHelper.CurrentConfiguration;
            return CrossReferenceProviderFactory.CreateSqlCrossReferenceProvider(
                config.CrossReferencesDbServerName, config.CrossReferencesDatabaseName);
        }

        public List<CrossReferenceEntry> LoadCrossReferences(string targetPath)
        {
            var entries = new List<CrossReferenceEntry>();

            ICrossReferenceProvider xrefProvider = GetCrossReferenceProvider();
            IEnumerable<CrossReference> refs = xrefProvider.FindReferences(string.Empty, targetPath, CrossReferenceKind.Any);

            foreach (CrossReference xref in refs)
            {
                var entry = new CrossReferenceEntry
                {
                    SourcePath   = xref.SourcePath,
                    Kind         = xref.Kind.ToString(),
                    LineNumber   = xref.LineNumber,
                    ColumnNumber = xref.ColumnNumber,
                    SourceModule = xref.SourceModule
                };

                ParseSourcePath(xref.SourcePath, entry);
                ResolveActualElementType(entry);
                entry.CodeLine = ExtractCodeLine(entry);

                entries.Add(entry);
            }

            return entries;
        }

        public string ExtractCodeLine(CrossReferenceEntry entry, int totalLines = 1)
        {
            if (entry.LineNumber <= 0 || string.IsNullOrEmpty(entry.ElementName))
                return string.Empty;

            try
            {
                string cacheKey = $"{entry.ElementType}:{entry.ElementName}";
                if (!_sourceTextCache.TryGetValue(cacheKey, out string sourceText))
                {
                    sourceText = GetElementSourceText(entry.ElementType, entry.ElementName);
                    _sourceTextCache[cacheKey] = sourceText ?? string.Empty;
                }

                if (string.IsNullOrEmpty(sourceText))
                    return string.Empty;

                string[] lines = sourceText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                if (entry.LineNumber > lines.Length)
                    return string.Empty;

                if (totalLines <= 1)
                {
                    return lines[entry.LineNumber - 1].Trim();
                }

                int linesAbove = (totalLines - 1) / 2;
                int linesBelow = totalLines - 1 - linesAbove;
                int startIdx = Math.Max(0, entry.LineNumber - 1 - linesAbove);
                int endIdx = Math.Min(lines.Length - 1, entry.LineNumber - 1 + linesBelow);

                var parts = new List<string>();
                for (int i = startIdx; i <= endIdx; i++)
                {
                    parts.Add(lines[i].Trim());
                }
                return string.Join(Environment.NewLine, parts);
            }
            catch
            {
                // Source extraction is best-effort
            }

            return string.Empty;
        }

        public void NavigateToSource(CrossReferenceEntry entry)
        {
            if (entry == null || string.IsNullOrEmpty(entry.ElementName))
                return;

            try
            {
                Type[] metadataTypes = GetMetadataRuntimeTypes(entry.ElementType);
                if (metadataTypes == null || metadataTypes.Length == 0) return;

                string xmlFilePath = null;
                foreach (var metadataType in metadataTypes)
                {
                    xmlFilePath = FindXmlArtifactFile(metadataType, entry.ElementName, entry.SourceModule);
                    if (!string.IsNullOrEmpty(xmlFilePath)) break;
                }

                if (!string.IsNullOrEmpty(xmlFilePath))
                {
                    string xppFilePath = AxServiceProvider.GetService<IMetadataInfoProvider>()?.GetXppSourceFilePath(xmlFilePath);

                    if (!string.IsNullOrEmpty(xppFilePath))
                    {
                        var rootElement = ReadElementAsRoot(GetMetadataProvider(), entry.ElementType, entry.ElementName);
                        if (rootElement != null)
                        {
                            string sourceText = MetaModelUtility.GetXppSourceText(rootElement);
                            if (!string.IsNullOrEmpty(sourceText))
                            {
                                System.IO.File.WriteAllText(xppFilePath, sourceText);
                            }
                        }

                        OpenFileInEditor(xppFilePath, entry.LineNumber, entry.ColumnNumber);
                        return;
                    }
                }

                NavigateViaSourceText(entry);
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }

        private void ParseSourcePath(string sourcePath, CrossReferenceEntry entry)
        {
            if (string.IsNullOrEmpty(sourcePath)) return;

            string[] parts = sourcePath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 2)
            {
                entry.ElementType = parts[0];
                entry.ElementName = parts[1];
            }
            if (parts.Length >= 4)
            {
                entry.MethodName = parts[3];
            }
        }

        private readonly Dictionary<string, string> _resolvedTypeCache = new Dictionary<string, string>();

        private void ResolveActualElementType(CrossReferenceEntry entry)
        {
            if (entry.ElementType != "Tables" || string.IsNullOrEmpty(entry.ElementName))
                return;

            string cacheKey = entry.ElementName;
            if (_resolvedTypeCache.TryGetValue(cacheKey, out string resolvedType))
            {
                entry.ElementType = resolvedType;
                return;
            }

            var metadataProvider = GetMetadataProvider();

            if (metadataProvider.Tables.Read(entry.ElementName) != null)
            {
                _resolvedTypeCache[cacheKey] = "Tables";
                return;
            }

            if (metadataProvider.DataEntityViews.Read(entry.ElementName) != null)
            {
                entry.ElementType = "DataEntityViews";
                _resolvedTypeCache[cacheKey] = "DataEntityViews";
                return;
            }

            if (metadataProvider.Views.Read(entry.ElementName) != null)
            {
                entry.ElementType = "Views";
                _resolvedTypeCache[cacheKey] = "Views";
                return;
            }

            _resolvedTypeCache[cacheKey] = "Tables";
        }

        private string GetElementSourceText(string elementType, string elementName)
        {
            IRootNamedObject rootElement = ReadElementAsRoot(GetMetadataProvider(), elementType, elementName);

            if (rootElement == null)
                return string.Empty;

            return MetaModelUtility.GetXppSourceText(rootElement);
        }

        private IRootNamedObject ReadElementAsRoot(
            Microsoft.Dynamics.AX.Metadata.Providers.IMetadataProvider metadataProvider,
            string elementType, string elementName)
        {
            switch (elementType)
            {
                case "Classes":
                    return metadataProvider.Classes.Read(elementName) as IRootNamedObject;
                case "Tables":
                    var table = metadataProvider.Tables.Read(elementName) as IRootNamedObject;
                    if (table != null) return table;
                    // XRef reports entities/views under /Tables/ path - fall back
                    var entityFallback = metadataProvider.DataEntityViews.Read(elementName) as IRootNamedObject;
                    if (entityFallback != null) return entityFallback;
                    return metadataProvider.Views.Read(elementName) as IRootNamedObject;
                case "TableExtensions":
                    return metadataProvider.TableExtensions.Read(elementName) as IRootNamedObject;
                case "Forms":
                    return metadataProvider.Forms.Read(elementName) as IRootNamedObject;
                case "DataEntities":
                case "DataEntityViews":
                    var entity = metadataProvider.DataEntityViews.Read(elementName) as IRootNamedObject;
                    if (entity == null)
                        entity = metadataProvider.Views.Read(elementName) as IRootNamedObject;
                    return entity;
                case "DataEntityViewExtensions":
                    return metadataProvider.DataEntityViewExtensions.Read(elementName) as IRootNamedObject;
                case "Views":
                    var view = metadataProvider.Views.Read(elementName) as IRootNamedObject;
                    if (view == null)
                        view = metadataProvider.DataEntityViews.Read(elementName) as IRootNamedObject;
                    return view;
                case "Queries":
                    return metadataProvider.Queries.Read(elementName) as IRootNamedObject;
                default:
                    return null;
            }
        }

        private void NavigateViaSourceText(CrossReferenceEntry entry)
        {
            var rootElement = ReadElementAsRoot(GetMetadataProvider(), entry.ElementType, entry.ElementName);
            if (rootElement == null) return;

            string sourceText = MetaModelUtility.GetXppSourceText(rootElement);
            if (string.IsNullOrEmpty(sourceText)) return;

            string tempDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "TRUDUtils_XRef");
            System.IO.Directory.CreateDirectory(tempDir);
            string tempFile = System.IO.Path.Combine(tempDir, entry.ElementName + ".xpp");
            System.IO.File.WriteAllText(tempFile, sourceText);

            OpenFileInEditor(tempFile, entry.LineNumber, entry.ColumnNumber);
        }

        private void OpenFileInEditor(string filePath, int lineNumber, int columnNumber)
        {
            DTE dte = AxServiceProvider.GetService<DTE>();
            if (dte == null) return;

            dte.ItemOperations.OpenFile(filePath);

            if (lineNumber > 0 && dte.ActiveDocument != null)
            {
                TextSelection selection = (TextSelection)dte.ActiveDocument.Selection;
                int col = Math.Max(1, columnNumber);
                selection.MoveToLineAndOffset(lineNumber, col, false);
            }
        }

        private string FindXmlArtifactFile(Type metadataType, string elementName, string module)
        {
            try
            {
                string typeFolderName = GetMetadataFolderName(metadataType);
                if (string.IsNullOrEmpty(typeFolderName))
                    return null;

                var metaModelService = DesignMetaModelService.Instance.CurrentMetaModelService;
                ModelInfo modelInfo = null;

                try
                {
                    modelInfo = metaModelService.GetModel(module);
                }
                catch
                {
                    // module might not be a valid model name
                }

                if (modelInfo != null)
                {
                    string modelStorePath = DesignMetaModelService.Instance.GetModelStorePathForModel(modelInfo);
                    if (!string.IsNullOrEmpty(modelStorePath))
                    {
                        string xmlPath = System.IO.Path.Combine(modelStorePath, typeFolderName, elementName + ".xml");
                        if (System.IO.File.Exists(xmlPath))
                            return xmlPath;
                    }
                }

                var allModels = metaModelService.GetModels();
                if (allModels != null)
                {
                    foreach (var model in allModels)
                    {
                        if (!string.IsNullOrEmpty(module) && model.Module != null &&
                            !model.Module.Equals(module, StringComparison.OrdinalIgnoreCase))
                            continue;

                        string modelStorePath = DesignMetaModelService.Instance.GetModelStorePathForModel(model);
                        if (!string.IsNullOrEmpty(modelStorePath))
                        {
                            string xmlPath = System.IO.Path.Combine(modelStorePath, typeFolderName, elementName + ".xml");
                            if (System.IO.File.Exists(xmlPath))
                                return xmlPath;
                        }
                    }
                }
            }
            catch
            {
                // Navigation is best-effort
            }

            return null;
        }

        private string GetMetadataFolderName(Type metadataType)
        {
            if (metadataType == typeof(AxClass)) return "AxClass";
            if (metadataType == typeof(AxTable)) return "AxTable";
            if (metadataType == typeof(AxForm)) return "AxForm";
            if (metadataType == typeof(AxDataEntityView)) return "AxDataEntityView";
            if (metadataType == typeof(AxDataEntityViewExtension)) return "AxDataEntityViewExtension";
            if (metadataType == typeof(AxView)) return "AxView";
            if (metadataType == typeof(AxQuery)) return "AxQuery";
            if (metadataType == typeof(AxTableExtension)) return "AxTableExtension";
            return null;
        }

        private Type[] GetMetadataRuntimeTypes(string elementType)
        {
            switch (elementType)
            {
                case "Classes": return new[] { typeof(AxClass) };
                case "Tables": return new[] { typeof(AxTable), typeof(AxDataEntityView), typeof(AxView) };
                case "TableExtensions": return new[] { typeof(AxTableExtension) };
                case "Forms": return new[] { typeof(AxForm) };
                case "DataEntities":
                case "DataEntityViews": return new[] { typeof(AxDataEntityView), typeof(AxView) };
                case "DataEntityViewExtensions": return new[] { typeof(AxDataEntityViewExtension) };
                case "Views": return new[] { typeof(AxView), typeof(AxDataEntityView) };
                case "Queries": return new[] { typeof(AxQuery) };
                default: return null;
            }
        }
    }
}

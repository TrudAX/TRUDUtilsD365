using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EnvDTE;
using Microsoft.Dynamics.AX.Framework.Xlnt.XReference;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.Core;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.MetaModel;
using TRUDUtilsD365.Kernel;

namespace TRUDUtilsD365.ShowCrossReference
{
    public enum AccessType
    {
        Read,
        Write,
        NotDefined
    }

    public class CrossReferenceEntry
    {
        public string SourcePath { get; set; }
        public string ElementType { get; set; }
        public string ElementName { get; set; }
        public string MethodName { get; set; }
        public string Kind { get; set; }
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
        public string SourceModule { get; set; }
        public string CodeLine { get; set; }
        public AccessType AccessType { get; set; }
    }

    public class SortableBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private PropertyDescriptor _sortProperty;
        private ListSortDirection _sortDirection;

        public SortableBindingList() { }
        public SortableBindingList(IList<T> list) : base(list) { }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _isSorted;
        protected override PropertyDescriptor SortPropertyCore => _sortProperty;
        protected override ListSortDirection SortDirectionCore => _sortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var items = Items as List<T>;
            if (items != null)
            {
                items.Sort((x, y) =>
                {
                    object xVal = prop.GetValue(x);
                    object yVal = prop.GetValue(y);
                    if (xVal == null && yVal == null) return 0;
                    if (xVal == null) return -1;
                    if (yVal == null) return 1;
                    int result = xVal is IComparable comparable
                        ? comparable.CompareTo(yVal)
                        : string.Compare(xVal.ToString(), yVal.ToString(), StringComparison.OrdinalIgnoreCase);
                    return direction == ListSortDirection.Descending ? -result : result;
                });
            }
            _sortProperty = prop;
            _sortDirection = direction;
            _isSorted = true;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
            _sortProperty = null;
        }
    }

    public class ShowCrossReferenceParms
    {
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public bool IsTableExtension { get; set; }
        public string DisplayName => $"{TableName}.{FieldName}";
        public SortableBindingList<CrossReferenceEntry> References { get; set; }

        private readonly Dictionary<string, string> _sourceTextCache = new Dictionary<string, string>();
        private readonly List<CrossReferenceEntry> _allReferences = new List<CrossReferenceEntry>();

        public void InitFromSelectedElement(AddinDesignerEventArgs e)
        {
            var field = (BaseField)e.SelectedElement;

            if (field.Table != null)
            {
                TableName = field.Table.GetMetadataType().Name;
                IsTableExtension = false;
            }
            else if (field.TableExtension != null)
            {
                TableName = field.TableExtension.GetMetadataType().Name;
                IsTableExtension = true;
            }

            FieldName = field.Name;

            _allReferences.Clear();
            References = new SortableBindingList<CrossReferenceEntry>();
            LoadCrossReferences();
        }

        private void LoadCrossReferences()
        {
            // Table extensions use /TableExtensions/ prefix, regular tables use /Tables/
            string pathPrefix = IsTableExtension ? "TableExtensions" : "Tables";
            string targetPath = $"/{pathPrefix}/{TableName}/Fields/{FieldName}";

            ICrossReferenceProvider xrefProvider = DesignMetaModelService.Instance.CrossReferenceProvider;

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

                entry.CodeLine = ExtractCodeLine(entry);

                entry.AccessType = DetermineAccessType(entry.CodeLine, FieldName);

                _allReferences.Add(entry);
            }

            foreach (var entry in _allReferences)
                References.Add(entry);
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

        private string ExtractCodeLine(CrossReferenceEntry entry, int totalLines = 1)
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

        private string GetElementSourceText(string elementType, string elementName)
        {
            AxHelper axHelper = new AxHelper();
            var metadataProvider = axHelper.MetadataProvider;

            IRootNamedObject rootElement = null;

            switch (elementType)
            {
                case "Classes":
                    rootElement = metadataProvider.Classes.Read(elementName) as IRootNamedObject;
                    break;
                case "Tables":
                    rootElement = metadataProvider.Tables.Read(elementName) as IRootNamedObject;
                    break;
                case "TableExtensions":
                    rootElement = metadataProvider.TableExtensions.Read(elementName) as IRootNamedObject;
                    break;
                case "Forms":
                    rootElement = metadataProvider.Forms.Read(elementName) as IRootNamedObject;
                    break;
                case "DataEntities":
                case "DataEntityViews":
                    rootElement = metadataProvider.DataEntityViews.Read(elementName) as IRootNamedObject;
                    break;
                case "DataEntityViewExtensions":
                    rootElement = metadataProvider.DataEntityViewExtensions.Read(elementName) as IRootNamedObject;
                    break;
                case "Views":
                    rootElement = metadataProvider.Views.Read(elementName) as IRootNamedObject;
                    break;
                case "Queries":
                    rootElement = metadataProvider.Queries.Read(elementName) as IRootNamedObject;
                    break;
            }

            if (rootElement == null)
                return string.Empty;

            return MetaModelUtility.GetXppSourceText(rootElement);
        }

        public static AccessType DetermineAccessType(string codeLine, string fieldName)
        {
            if (string.IsNullOrEmpty(codeLine))
                return AccessType.NotDefined;

            int fieldIdx = codeLine.IndexOf(fieldName, StringComparison.OrdinalIgnoreCase);
            if (fieldIdx < 0)
                return AccessType.NotDefined;

            int equalIdx = codeLine.IndexOf('=');
            if (equalIdx < 0)
                return AccessType.Read;

            // Skip comparison/compound operators: ==, !=, >=, <=, +=, -=
            if (equalIdx + 1 < codeLine.Length && codeLine[equalIdx + 1] == '=')
                return AccessType.Read;
            if (equalIdx > 0 && (codeLine[equalIdx - 1] == '!' ||
                                  codeLine[equalIdx - 1] == '>' ||
                                  codeLine[equalIdx - 1] == '<'))
                return AccessType.Read;

            // += and -= on the field is still a write
            if (equalIdx > 0 && (codeLine[equalIdx - 1] == '+' || codeLine[equalIdx - 1] == '-'))
            {
                // Check if the field is before the +=/-=
                if (fieldIdx < equalIdx - 1)
                    return AccessType.Write;
                return AccessType.Read;
            }

            if (fieldIdx < equalIdx)
                return AccessType.Write;

            return AccessType.Read;
        }

        public void ReloadCodeLines(int totalLines)
        {
            foreach (var entry in _allReferences)
            {
                entry.CodeLine = ExtractCodeLine(entry, totalLines);
            }
            References.ResetBindings();
        }

        public void ApplyDefaultSort()
        {
            var sorted = References.OrderBy(r => r.ElementType)
                                   .ThenBy(r => r.ElementName)
                                   .ThenBy(r => r.MethodName)
                                   .ThenBy(r => r.LineNumber)
                                   .ThenBy(r => r.ColumnNumber)
                                   .ToList();
            References.RaiseListChangedEvents = false;
            References.Clear();
            foreach (var item in sorted)
                References.Add(item);
            References.RaiseListChangedEvents = true;
            References.ResetBindings();
        }

        public List<string> GetDistinctModules()
        {
            return _allReferences.Select(r => r.SourceModule ?? "")
                                 .Where(m => !string.IsNullOrEmpty(m))
                                 .Distinct()
                                 .OrderBy(m => m)
                                 .ToList();
        }

        public void ApplyFilters(string moduleFilter, string accessFilter)
        {
            IEnumerable<CrossReferenceEntry> filtered = _allReferences;

            if (!string.IsNullOrEmpty(moduleFilter) && moduleFilter != "All")
            {
                filtered = filtered.Where(r => string.Equals(r.SourceModule, moduleFilter, StringComparison.OrdinalIgnoreCase));
            }

            if (accessFilter == "Read")
            {
                filtered = filtered.Where(r => r.AccessType == AccessType.Read || r.AccessType == AccessType.NotDefined);
            }
            else if (accessFilter == "Write")
            {
                filtered = filtered.Where(r => r.AccessType == AccessType.Write || r.AccessType == AccessType.NotDefined);
            }

            References.RaiseListChangedEvents = false;
            References.Clear();
            foreach (var entry in filtered)
                References.Add(entry);
            References.RaiseListChangedEvents = true;
            References.ResetBindings();
        }

        public void NavigateToSource(CrossReferenceEntry entry)
        {
            if (entry == null || string.IsNullOrEmpty(entry.ElementName))
                return;

            try
            {
                Type metadataType = GetMetadataRuntimeType(entry.ElementType);
                if (metadataType == null) return;

                // Try to find the XML artifact file for this element
                string xmlFilePath = FindXmlArtifactFile(metadataType, entry.ElementName, entry.SourceModule);

                if (!string.IsNullOrEmpty(xmlFilePath))
                {
                    // Convert XML path to XPP source path
                    string xppFilePath = MetaModelUtility.GetXppSourceFilePath(xmlFilePath);

                    if (!string.IsNullOrEmpty(xppFilePath))
                    {
                        // Read the element to sync source text to the file
                        AxHelper axHelper = new AxHelper();
                        var rootElement = ReadElementAsRoot(axHelper.MetadataProvider, entry.ElementType, entry.ElementName);
                        if (rootElement != null)
                        {
                            string sourceText = MetaModelUtility.GetXppSourceText(rootElement);
                            if (!string.IsNullOrEmpty(sourceText))
                            {
                                System.IO.File.WriteAllText(xppFilePath, sourceText);
                            }
                        }

                        // Open the file using DTE
                        DTE dte = AxServiceProvider.GetService<DTE>();
                        if (dte != null)
                        {
                            dte.ItemOperations.OpenFile(xppFilePath);

                            if (entry.LineNumber > 0 && dte.ActiveDocument != null)
                            {
                                TextSelection selection = (TextSelection)dte.ActiveDocument.Selection;
                                int col = Math.Max(1, entry.ColumnNumber);
                                selection.MoveToLineAndOffset(entry.LineNumber, col, false);
                            }
                        }
                        return;
                    }
                }

                // Fallback: open via source text in a temp file
                NavigateViaSourceText(entry);
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }

        private void NavigateViaSourceText(CrossReferenceEntry entry)
        {
            // Read the element source and write to a temp file, then open in VS
            AxHelper axHelper = new AxHelper();
            var rootElement = ReadElementAsRoot(axHelper.MetadataProvider, entry.ElementType, entry.ElementName);
            if (rootElement == null) return;

            string sourceText = MetaModelUtility.GetXppSourceText(rootElement);
            if (string.IsNullOrEmpty(sourceText)) return;

            string tempDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "TRUDUtils_XRef");
            System.IO.Directory.CreateDirectory(tempDir);
            string tempFile = System.IO.Path.Combine(tempDir, entry.ElementName + ".xpp");
            System.IO.File.WriteAllText(tempFile, sourceText);

            DTE dte = AxServiceProvider.GetService<DTE>();
            if (dte != null)
            {
                dte.ItemOperations.OpenFile(tempFile);

                if (entry.LineNumber > 0 && dte.ActiveDocument != null)
                {
                    TextSelection selection = (TextSelection)dte.ActiveDocument.Selection;
                    int col = Math.Max(1, entry.ColumnNumber);
                    selection.MoveToLineAndOffset(entry.LineNumber, col, false);
                }
            }
        }

        private IRootNamedObject ReadElementAsRoot(Microsoft.Dynamics.AX.Metadata.Providers.IMetadataProvider metadataProvider, string elementType, string elementName)
        {
            switch (elementType)
            {
                case "Classes":
                    return metadataProvider.Classes.Read(elementName) as IRootNamedObject;
                case "Tables":
                    return metadataProvider.Tables.Read(elementName) as IRootNamedObject;
                case "TableExtensions":
                    return metadataProvider.TableExtensions.Read(elementName) as IRootNamedObject;
                case "Forms":
                    return metadataProvider.Forms.Read(elementName) as IRootNamedObject;
                case "DataEntities":
                case "DataEntityViews":
                    return metadataProvider.DataEntityViews.Read(elementName) as IRootNamedObject;
                case "DataEntityViewExtensions":
                    return metadataProvider.DataEntityViewExtensions.Read(elementName) as IRootNamedObject;
                case "Views":
                    return metadataProvider.Views.Read(elementName) as IRootNamedObject;
                case "Queries":
                    return metadataProvider.Queries.Read(elementName) as IRootNamedObject;
                default:
                    return null;
            }
        }

        private string FindXmlArtifactFile(Type metadataType, string elementName, string module)
        {
            try
            {
                string typeFolderName = GetMetadataFolderName(metadataType);
                if (string.IsNullOrEmpty(typeFolderName))
                    return null;

                // Try to get model store path using the module as model name
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

                // Fallback: search across all models
                var allModels = metaModelService.GetModels();
                if (allModels != null)
                {
                    foreach (var model in allModels)
                    {
                        // Filter by module name if possible
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
            if (metadataType == typeof(AxView)) return "AxView";
            if (metadataType == typeof(AxQuery)) return "AxQuery";
            if (metadataType == typeof(AxTableExtension)) return "AxTableExtension";
            return null;
        }

        private Type GetMetadataRuntimeType(string elementType)
        {
            switch (elementType)
            {
                case "Classes": return typeof(AxClass);
                case "Tables": return typeof(AxTable);
                case "TableExtensions": return typeof(AxTableExtension);
                case "Forms": return typeof(AxForm);
                case "DataEntities":
                case "DataEntityViews": return typeof(AxDataEntityView);
                case "DataEntityViewExtensions": return typeof(AxDataEntityViewExtension);
                case "Views": return typeof(AxView);
                case "Queries": return typeof(AxQuery);
                default: return null;
            }
        }
    }
}

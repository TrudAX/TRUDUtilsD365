using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using EnvDTE;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.AX.Metadata.Providers;
using Microsoft.Dynamics.AX.Metadata.Service;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.ProjectSystem;

namespace TRUDUtilsD365.Kernel
{
    [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
    public class AxHelper
    {
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') ||  c == '_')
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
        static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        public static string GetTypeNameFromLabel(string typeName)
        {
            //TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string noCharsStr = RemoveSpecialCharacters(typeName);

            string res = UppercaseWords(noCharsStr).Replace(" ", "");
            //string res = textInfo.ToTitleCase(noCharsStr).Replace(" ", "");
            if (char.IsDigit(res[0]))
            {
                res = "V" + res;
            }
            return res;
        }
        private IMetadataProvider  _metadataProvider;
        private IMetaModelService  _metaModelService;
        private ModelSaveInfo      _modelSaveInfo;

        public IMetadataProvider MetadataProvider
        {
            get
            {
                if (_metadataProvider == null)
                {
                    _metadataProvider = DesignMetaModelService.Instance.CurrentMetadataProvider;
                }

                return _metadataProvider;
            }
        }

        public ModelSaveInfo ModelSaveInfo
        {
            get
            {
                if (_modelSaveInfo == null)
                {
                    VSProjectNode activeProjectNode = GetActiveProjectNode();
                    var modelInfo = activeProjectNode.GetProjectsModelInfo(true);
                    _modelSaveInfo = new ModelSaveInfo(modelInfo);
                }

                return _modelSaveInfo;
            }
        }

        public IMetaModelService MetaModelService
        {
            get
            {
                if (_metaModelService == null)
                {
                    _metaModelService = DesignMetaModelService.Instance.CurrentMetaModelService;
                }

                return _metaModelService;
            }
        }

        private static VSProjectNode GetActiveProjectNode()
        {
            DTE dte = CoreUtility.ServiceProvider.GetService(typeof(DTE)) as DTE;
            if (dte == null)
                throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture,
                    "No service for DTE found. The DTE must be registered as a service for using this API."));

            Array array = dte.ActiveSolutionProjects as Array;
            if (array != null && array.Length > 0)
            {
                Project project = array.GetValue(0) as Project;
                if (project != null) return project.Object as VSProjectNode;
            }

            return null;
        }

        public void AppendToActiveProject(INamedObject edt)
        {
            VSProjectNode activeProjectNode = GetActiveProjectNode();

            activeProjectNode.AddModelElementsToProject(new List<MetadataReference>
            {
                new MetadataReference(edt.Name, edt.GetType())
            });
        }
    }
}
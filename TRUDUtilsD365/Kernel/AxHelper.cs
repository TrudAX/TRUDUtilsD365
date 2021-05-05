using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.AX.Metadata.Providers;
using Microsoft.Dynamics.AX.Metadata.Service;
using Microsoft.Dynamics.Framework.Tools.Core;
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
        public static string UppercaseWords(string value)
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
            if (res.Length > 0 && char.IsDigit(res[0]))
            {
                res = "V" + res;
            }
            return res;
        }

        public static string PrettyName(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            return input.First().ToString().ToLower() + input.Substring(1);
        }
        //AAACustTable  --> custTable
        //AAA_CustTable --> custTable
        //CustTable     --> custTable
        //CustTable_AAA --> custTable
        public static string GetVarNameFromType(string typeName)
        {
            string res;

            if (typeName.Length <= 6)
            {
                return PrettyName(typeName);
            }

            int prefixPos = 0;
            for (int i = 0; i <= 5; i++)
            {
                if (typeName[i] != '_' && Char.IsUpper(typeName[i]) && Char.IsLower(typeName[i + 1]))
                {
                    prefixPos = i;
                    break;
                }
            }

            int typeLen = typeName.Length;
            if (typeName[typeLen - 4] == '_' &&
                Char.IsUpper(typeName[typeLen - 3]) &&
                Char.IsUpper(typeName[typeLen - 2]) &&
                Char.IsUpper(typeName[typeLen - 1]))
            {
                res = PrettyName(typeName.Substring(0, typeLen - 4));
                return res;
            }

            if (prefixPos == 0)
            {
                return PrettyName(typeName);
            }

            res = PrettyName(typeName.Substring(prefixPos));

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
                    var designMetaModelService = AxServiceProvider.GetService<IDesignMetaModelService>() as IDesignMetaModelService;//CoreUtility.GetService<IDesignMetaModelService>() as IDesignMetaModelService;
                    _metadataProvider = designMetaModelService.CurrentMetadataProvider;
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
                    var designMetaModelService = AxServiceProvider.GetService<IDesignMetaModelService>() as IDesignMetaModelService;//CoreUtility.GetService<IDesignMetaModelService>() as IDesignMetaModelService;
                    _metaModelService = designMetaModelService.CurrentMetaModelService;
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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.RunBaseBuilder
{
    public class RunBaseBuilderVars
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Label { get; set; } = "";
        public string LabelHelp { get; set; } = "";
        public Boolean IsMandatory { get; set; } = false;
        public int LineNum { get; set; }//??

    }

    public class RunBaseBuilder
    {        
        public string ClassName { get; set; } = "";
        public string ClassDescription { get; set; } = "";
        public string QueryTable { get; set; } = "";
        public string ExternalTable { get; set; } = "";
        public Boolean IsAddFileUpload { get; set; } = false;

        public List<RunBaseBuilderVars> Fields;

        protected const string ClassNameParm = "Class name";
        protected const string DescriptionParmName = "Description";
        protected const string QueryTableParmName = "Query table";
        protected const string ExternalTableNameParmName = "External table name";
        protected const string AddFileUploadParmName = "Add file upload(y)";
        protected const string CreateMenuItemParmName = "Create menu item(y)";
        protected const string ParametersParmName = "Parameters..";

        private string _logString;

        void AddLog(string logLocal)
        {
            _logString += logLocal;
        }

        public void DisplayLog()
        {
            CoreUtility.DisplayInfo($"The following elements({_logString}) were created and added to the project");
        }

        public string GetPreviewString()
        {
            StringBuilder stringBuilder = new StringBuilder();
           
            return stringBuilder.ToString();
        }

        public void InitDialogParms(SnippetsParms snippetsParms)
        {
            snippetsParms.SnippetName = "Create RunBase class";

            snippetsParms.AddParametersValue(ClassNameParm,     "AATestRunBase");
            snippetsParms.AddParametersValue(DescriptionParmName ,     "Class description");
            snippetsParms.AddParametersValue(QueryTableParmName ,     "CustTable");
            snippetsParms.AddParametersValue(ExternalTableNameParmName,   "");
            snippetsParms.AddParametersValue(AddFileUploadParmName,  "");
            snippetsParms.AddParametersValue(CreateMenuItemParmName, "");

            snippetsParms.AddParametersValue(ParametersParmName,       $"CustAccount" + Environment.NewLine +
                                                                   $"NoYesId {snippetsParms.ValuesSeparator} useCurrentDate {snippetsParms.ValuesSeparator} Use current date");

            snippetsParms.Description = "Util creates a RunBase type class. You can specify multiple parameters - each as a separate line in the following format EDTType | Variable name | " +
                                        "Label | Help text | Mandatory(y for yes). You can specify only EDTType";

            snippetsParms.IsFieldsSeparatorVisible = true;
            snippetsParms.IsCreateButtonVisible = true;
        }

        /*
        private List<AxEnumValue> GetAxEnumValues()
        {
            List<AxEnumValue> resList = new List<AxEnumValue>();

            List<string> listImp = new List<string>(
                EnumValuesStr.Split(new[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries));

            bool isFirstElement = true;
            int currentIndex = EnumValueStartIndex;
            foreach (string lineImp in listImp)
            {
                string enumLabelLocal = "", enumNameLocal = "";

                if (lineImp.Contains(ValuesSeparator))
                {
                    List<string> listLineImp = new List<string>(
                    lineImp.Split(new[] { ValuesSeparator },
                            StringSplitOptions.None));
                    enumLabelLocal = listLineImp[0].Trim();
                    enumNameLocal  = listLineImp[1].Trim();
                    if (enumLabelLocal == "" && enumNameLocal == "" && isFirstElement)
                    {
                        enumNameLocal = "None";
                    }
                }
                else
                {
                    enumLabelLocal = lineImp.Trim();
                    enumNameLocal = AxHelper.GetTypeNameFromLabel(enumLabelLocal);
                    //enumNameLocal = textInfo.ToTitleCase(enumLabelLocal).Replace(" ", "");
                }

                isFirstElement = false;
                if (enumNameLocal != "")
                {
                    AxEnumValue enumValue = new AxEnumValue {Label = enumLabelLocal, Name = enumNameLocal};
                    enumValue.Value = currentIndex;
                    currentIndex++;
                    resList.Add(enumValue);
                }
                else
                {
                    break;
                }
            }
            return resList;
        }
        */

        public void CreateRunBase()
        {
            _logString = "";
            AxHelper axHelper = new AxHelper();

            /*
            AxEnum newEnum = axHelper.MetadataProvider.Enums.Read(EnumName);

            if (newEnum == null)
            {
                
            }
            */
        }
    }
}

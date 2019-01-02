using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        public override string ToString()
        {
            return $"Type:{Type}, varName:{Name}, Mandatory:{IsMandatory}, Label:{Label}, Help:{LabelHelp}";
        }

    }

    public class RunBaseBuilder : SnippedCreateAction
    {        
        public string ClassName { get; set; } = "";
        public string ClassDescription { get; set; } = "";
        public string QueryTable { get; set; } = "";
        public string ExternalTable { get; set; } = "";
        public Boolean IsAddFileUpload { get; set; } = false;
        public Boolean IsCreateMenuItem { get; set; } = false;

        public List<RunBaseBuilderVars> FieldsList;

        protected const char   MandatoryPropertySym      = '*';
        protected const string ClassNameParm             = "Class name";
        protected const string DescriptionParmName       = "Description";
        protected const string QueryTableParmName        = "Query table";
        protected const string ExternalTableNameParmName = "External table name";
        protected const string AddFileUploadParmName     = "Add file upload(y)";
        protected const string CreateMenuItemParmName    = "Create menu item(y)";
        protected const string ParametersParmName        = "Parameters..";


        public string GetPreviewString()
        {
            StringBuilder stringBuilder = new StringBuilder();
           
            return stringBuilder.ToString();
        }

        public void InitDialogParms(SnippetsParms snippetsParms)
        {
            snippetsParms.SnippetName = "Create RunBase class";

            snippetsParms.AddParametersValue(ClassNameParm, "AATestRunBase");
            snippetsParms.AddParametersValue(DescriptionParmName, "Class description");
            snippetsParms.AddParametersValue(QueryTableParmName, "CustTable");
            snippetsParms.AddParametersValue(ExternalTableNameParmName, "");
            snippetsParms.AddParametersValue(AddFileUploadParmName, "");
            snippetsParms.AddParametersValue(CreateMenuItemParmName, "");

            snippetsParms.AddParametersValue(ParametersParmName,       $"CustAccount" + MandatoryPropertySym + Environment.NewLine +
                                                                   $"NoYesId {snippetsParms.ValuesSeparator} useCurrentDate {snippetsParms.ValuesSeparator} Use current date");

            snippetsParms.Description = "Util creates a RunBase type class. You can specify multiple parameters - each as a separate line in the following format EDTType | Variable name | " +
                                        "Label | Help text. You can specify only EDTType. For the Mandatory property add * to the EDTType";

            snippetsParms.IsFieldsSeparatorVisible = true;
            snippetsParms.IsCreateButtonVisible = true;

            snippetsParms.CreateAction = this;
            snippetsParms.PreviewAction = this;
        }
        public override void InitFromSnippetsParms(SnippetsParms snippetsParms)
        {
            ClassName        = snippetsParms.GetParmStr(ClassNameParm);
            ClassDescription = snippetsParms.GetParmStr(DescriptionParmName);
            QueryTable       = snippetsParms.GetParmStr(QueryTableParmName);
            ExternalTable    = snippetsParms.GetParmStr(ExternalTableNameParmName);
            IsAddFileUpload  = snippetsParms.GetParmBool(AddFileUploadParmName);
            IsCreateMenuItem = snippetsParms.GetParmBool(CreateMenuItemParmName);

            List<List<string>> parmList = snippetsParms.GetParmListSeparated(ParametersParmName);
            FieldsList = new List<RunBaseBuilderVars>();

            foreach (List<string> subList in parmList)
            {
                RunBaseBuilderVars runBaseBuilderVars = new RunBaseBuilderVars();

                string item = subList[0];                
                if (item[item.Length - 1] == MandatoryPropertySym)//check mandatory
                {
                    runBaseBuilderVars.IsMandatory = true;
                    runBaseBuilderVars.Type        = item.Remove(item.Length - 1).Trim();
                }
                else
                {
                    runBaseBuilderVars.IsMandatory = false;
                    runBaseBuilderVars.Type        = item;
                }

                if (String.IsNullOrEmpty(runBaseBuilderVars.Type))
                {
                    throw new Exception("Type should be specified");
                }

                if (subList.Count > 1 && ! String.IsNullOrWhiteSpace(subList[1])) //check var name
                {
                    runBaseBuilderVars.Name = subList[1];
                }
                else
                {
                    runBaseBuilderVars.Name = AxHelper.GetVarNameFromType(runBaseBuilderVars.Type);
                }
                if (subList.Count > 2 && !String.IsNullOrWhiteSpace(subList[2])) 
                {
                    runBaseBuilderVars.Label = subList[2];
                }
                if (subList.Count > 3 && !String.IsNullOrWhiteSpace(subList[3]))
                {
                    runBaseBuilderVars.LabelHelp = subList[3];
                }
                FieldsList.Add(runBaseBuilderVars);
            }

        }


        public override void RunCreate()
        {
            AxHelper axHelper = new AxHelper();

            /*
            AxEnum newEnum = axHelper.MetadataProvider.Enums.Read(EnumName);

            if (newEnum == null)
            {
                
            }
            */
        }



        public override string RunPreview()
        {
          
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"class {ClassName}");
            foreach (var field in FieldsList)
            {
                sb.AppendLine(field.ToString());
            }

            return sb.ToString();
        }
    }
}

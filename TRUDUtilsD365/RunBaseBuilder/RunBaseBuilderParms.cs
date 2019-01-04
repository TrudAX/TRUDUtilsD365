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
        public string DlgName { get; set; } = "";
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

        protected CodeGenerateHelper CodeGenerate;

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

                runBaseBuilderVars.DlgName = $"dlg{AxHelper.UppercaseWords(runBaseBuilderVars.Name)}";
                FieldsList.Add(runBaseBuilderVars);
            }

        }

        void InitCodeGenerate()
        {
            int longestNameLength = (from x in FieldsList select x.Name.Length).Max();
            int longestTypeLength = (from x in FieldsList select x.Type.Length).Max();
            longestTypeLength = Math.Max("DialogField".Length, longestTypeLength);
            longestTypeLength++;
            longestNameLength+=2;

            CodeGenerate = new CodeGenerateHelper {IndentGlobalValue = 4};


            CodeGenerate.AddColumnAlignInt("Type", longestTypeLength);
            CodeGenerate.AddColumnAlignInt("FieldName", longestNameLength);
            CodeGenerate.AddColumnAlignInt("DlgName", longestNameLength + 2);
        }

        private string SrcClassDeclaration()
        {
            CodeGenerate.AppendLine($"class {ClassName} extends RunBaseBatch");
            CodeGenerate.BeginBlock();
            foreach (RunBaseBuilderVars df in FieldsList)
            {
                CodeGenerate.Append(df.Type, "Type").AppendLine($" {df.Name};");
            }

            if (FieldsList.Count == 0)
            {
                CodeGenerate.AppendLine("Integer dummy;");
            }
            CodeGenerate.AppendLine("");

            foreach (RunBaseBuilderVars df in FieldsList)
            {
                CodeGenerate.Append("DialogField", "Type").AppendLine($" {df.DlgName};");
            }
            CodeGenerate.AppendLine("");

            // source += strFmt('    %1            %2;', #SysQueryRun, #queryRun)                                      + #newLine;
            CodeGenerate.AppendLine("#define.CurrentVersion(1)");
            CodeGenerate.AppendLine("#localmacro.CurrentList").IndentIncrease();

            for (int i = 0; i < FieldsList.Count; i++)
            {
                CodeGenerate.AppendLine($"{FieldsList[i].Name}{(i < (FieldsList.Count - 1) ? "," : "")}");
            }
            if (FieldsList.Count == 0)
            {
                CodeGenerate.AppendLine("dummy");
            }
            CodeGenerate.IndentDecrease();
            CodeGenerate.AppendLine("#endmacro");
            CodeGenerate.EndBlock();

            return CodeGenerate.GetResult();
        }

        string SrcConstruct()
        {
            CodeGenerate.AppendLine($"public static {ClassName} construct()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"return new {ClassName}();");
            CodeGenerate.EndBlock();

            return CodeGenerate.GetResult();
        }
        string SrcDescription()
        {
            CodeGenerate.AppendLine("static ClassDescription description()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine("return " + "\"" + ClassDescription + "\";");
            CodeGenerate.EndBlock();

            return CodeGenerate.GetResult();
        }

        string SrcDialog()
        {
            CodeGenerate.AppendLine("public Object dialog()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine("DialogRunbase       dialog = super();");
            CodeGenerate.AppendLine(";");

            foreach (RunBaseBuilderVars df in FieldsList)
            {
                CodeGenerate.Append(df.DlgName, "DlgName");

                CodeGenerate.Append($" = dialog.addFieldValue(extendedtypestr({df.Type}), {df.Name}");
                if (df.Label == "" && df.LabelHelp == "")
                {
                    CodeGenerate.AppendLine(");");
                }
                else
                {
                    CodeGenerate.Append($", \"{df.Label}\"");
                    if (df.LabelHelp == "")
                    {
                        CodeGenerate.AppendLine(");");
                    }
                    else
                    {
                        CodeGenerate.AppendLine($", \"{df.LabelHelp}\"");
                    }
                }
            }
            CodeGenerate.AppendLine("");
            CodeGenerate.AppendLine("return dialog;");
            CodeGenerate.EndBlock();

            return CodeGenerate.GetResult();
        }
        string SrcGetFromDialog()
        {
            CodeGenerate.AppendLine("public boolean getFromDialog()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine(";");
            foreach (RunBaseBuilderVars df in FieldsList)
            {
                CodeGenerate.Append(df.Name, "FieldName");
                CodeGenerate.AppendLine($" = {df.DlgName}.value();");
            }
            CodeGenerate.AppendLine("");
            CodeGenerate.AppendLine("return super();");
            CodeGenerate.EndBlock();

            return CodeGenerate.GetResult();
        }
        string SrcInitParmDefault()
        {
            if (!String.IsNullOrEmpty(QueryTable))
            {
                CodeGenerate.AppendLine("public void initParmDefault()");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("this.initQuery();");
                CodeGenerate.EndBlock();
            }

            return CodeGenerate.GetResult();
        }
        string SrcInitQuery()
        {
            if (!String.IsNullOrEmpty(QueryTable))
            {
                CodeGenerate.AppendLine("public void initQuery()");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("Query                   query = new Query();");
                CodeGenerate.AppendLine($"QueryBuildDataSource    qbds = query.addDataSource(tablenum({QueryTable}));");
                CodeGenerate.AppendLine("QueryBuildRange         qBR;");
                CodeGenerate.AppendLine(";");
                CodeGenerate.AppendLine($"qBR = SysQuery::findOrCreateRange(qbds, fieldnum({QueryTable}, RecId));");
                CodeGenerate.AppendLine($"qBR.status(RangeStatus::HIDDEN);");
                CodeGenerate.AppendLine("");
                CodeGenerate.AppendLine("queryRun = new QueryRun(query);");
                CodeGenerate.EndBlock();
            }

            return CodeGenerate.GetResult();
        }
        string SrcMain()
        {
            CodeGenerate.AppendLine("public static void main(Args _args)");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"%1    runObject = {ClassName}::construct();");

            if (ExternalTable != "")//&& showQueryValues)
            {
                CodeGenerate.AppendLine("QueryBuildDataSource  qbds;");
            }
            CodeGenerate.AppendLine(";");
            if (ExternalTable != "")
            {
                CodeGenerate.AppendLine($"if (_args.dataset() != tablenum({ExternalTable}))");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("throw error(Error::missingRecord(funcname()));");
                CodeGenerate.EndBlock();

                CodeGenerate.AppendLine($"runObject.parmCaller{ExternalTable}(_args.record());"); //replace to caller
                if (QueryTable != "")
                {
                    CodeGenerate.AppendLine($"if (_args && _args.record().TableId == tablenum({ExternalTable}))");
                    CodeGenerate.BeginBlock();
                    CodeGenerate.AppendLine($"qbds = runObject.queryRun().query().dataSourceTable(tablenum({QueryTable}));");
                    CodeGenerate.AppendLine("qbds.clearRanges();");
                    CodeGenerate.AppendLine($"qbds.addRange(fieldnum({QueryTable}, RecId)).value(queryValue(runObject.parmCaller{ExternalTable}().RecId));");
                    CodeGenerate.AppendLine("//runObject.parmIsDisableUnpackQuery(true);");
                    CodeGenerate.EndBlock();
                }
            }
            CodeGenerate.AppendLine("if (runObject.prompt())");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine("runObject.run();");
            CodeGenerate.EndBlock();

            CodeGenerate.EndBlock();
            return CodeGenerate.GetResult();
        }
        string SrcPack()
        {
            CodeGenerate.AppendLine("public container pack()");
            CodeGenerate.BeginBlock();
            if (QueryTable != "")
            {
                CodeGenerate.AppendLine("return [#CurrentVersion, #CurrentList, queryRun.pack()];");
            }
            else
            {
                CodeGenerate.AppendLine("return [#CurrentVersion, #CurrentList];");
            }
            CodeGenerate.EndBlock();

            return CodeGenerate.GetResult();            
        }
        string SrcUnpack()
        {
            CodeGenerate.AppendLine("public boolean unpack(container _packedClass)");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine("Version    version = RunBase::getVersion(_packedClass);");
            if (QueryTable != "")
            {
                CodeGenerate.AppendLine("container  queryCon;");
            }
            CodeGenerate.AppendLine("switch (version)");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine("case #CurrentVersion:");
            CodeGenerate.IndentIncrease();
            if (QueryTable != "")
            {
                CodeGenerate.AppendLine("[version, #CurrentList, queryCon] = _packedClass;");
                CodeGenerate.AppendLine("if (SysQuery::isPackedOk(queryCon))");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("queryRun = new QueryRun(queryCon);");
                CodeGenerate.EndBlock();
                CodeGenerate.AppendLine("else");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("this.initQuery();");
                CodeGenerate.EndBlock();
            }
            else
            {
                CodeGenerate.AppendLine("[version,#CurrentList] = _packedClass;");
            }
            CodeGenerate.AppendLine("break;");
            CodeGenerate.IndentDecrease();
            CodeGenerate.AppendLine("default:");
            CodeGenerate.AppendLine("    return false;");
            CodeGenerate.EndBlock();
            CodeGenerate.AppendLine("return true;");

            CodeGenerate.EndBlock();

            return CodeGenerate.GetResult();
        }


        void CreateClass()
        {

            AxHelper axHelper = new AxHelper();

            AxClass newClass = axHelper.MetadataProvider.Classes.Read(ClassName);

            if (newClass != null)
            {
                throw new Exception($"Class {ClassName} already exists");
            }

            newClass = new AxClass { Name = ClassName };

            StringBuilder declarationText = new StringBuilder();
            

            declarationText.AppendLine($"public class {newClass.Name} extends RunBaseBatch");
            declarationText.AppendLine("{");
            declarationText.AppendLine("}");

            newClass.SourceCode.Declaration = declarationText.ToString();
            axHelper.MetaModelService.CreateClass(newClass, axHelper.ModelSaveInfo);
            axHelper.AppendToActiveProject(newClass);

            AddLog($"Class: {newClass.Name}; ");

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
            sb.AppendLine(this.ToString());
            foreach (var field in FieldsList)
            {
                sb.AppendLine(field.ToString());
            }

            return sb.ToString();
        }
    }
}

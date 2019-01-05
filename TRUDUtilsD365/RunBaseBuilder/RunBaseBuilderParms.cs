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

        private AxClass newAxClass;
        protected bool IsPreviewMode;

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

        private void SrcClassDeclaration()
        {
            CodeGenerate.SetMethodName("ClassDeclaration", ClassMethodType.ClassDeclaration);
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
            if (QueryTable != "")
            {
                CodeGenerate.AppendLine("QueryRun       queryRun;");
            }
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
        }

        void SrcConstruct()
        {
            CodeGenerate.SetMethodName("construct", ClassMethodType.Static);

            CodeGenerate.AppendLine($"public static {ClassName} construct()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"return new {ClassName}();");
            CodeGenerate.EndBlock();           
        }
        void SrcDescription()
        {
            CodeGenerate.SetMethodName("description", ClassMethodType.Static);
            CodeGenerate.AppendLine("static ClassDescription description()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine("return " + "\"" + ClassDescription + "\";");
            CodeGenerate.EndBlock();
        }
        void SrcMain()
        {
            CodeGenerate.SetMethodName("main", ClassMethodType.Static);
            CodeGenerate.AppendLine("public static void main(Args _args)");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"{ClassName}    runObject = {ClassName}::construct();");

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
        }

        void SrcDialog()
        {
            CodeGenerate.SetMethodName("dialog");
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
        }
        void SrcGetFromDialog()
        {
            CodeGenerate.SetMethodName("getFromDialog");
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
        }
        void SrcInitParmDefault()
        {
            CodeGenerate.SetMethodName("initParmDefault");
            if (!String.IsNullOrEmpty(QueryTable))
            {
                CodeGenerate.AppendLine("public void initParmDefault()");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("this.initQuery();");
                CodeGenerate.EndBlock();
            }
        }
        void SrcInitQuery()
        {
            CodeGenerate.SetMethodName("initQuery");
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
        }
        void SrcPack()
        {
            CodeGenerate.SetMethodName("pack");
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
        }
        void SrcUnpack()
        {
            CodeGenerate.SetMethodName("unpack");
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
        }
        void SrcQueryRun()
        {
            CodeGenerate.SetMethodName("queryRun");
            if (!String.IsNullOrEmpty(QueryTable))
            {
                CodeGenerate.AppendLine("public QueryRun queryRun()");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("return queryRun;");
                CodeGenerate.EndBlock();
            }
        }
        void SrcRun()
        {
            CodeGenerate.SetMethodName("run");
            CodeGenerate.AppendLine("public void run()");
            CodeGenerate.BeginBlock();

            if (!String.IsNullOrEmpty(QueryTable))
            {
                string queryCursor = AxHelper.GetVarNameFromType(QueryTable);
                CodeGenerate.AppendLine("int                     processedCounter;");
                CodeGenerate.AppendLine("QueryBuildDataSource    qBDS;");
                CodeGenerate.AppendLine($"{QueryTable}    {queryCursor};");
                CodeGenerate.AppendLine(";");
                CodeGenerate.AppendLine($"qBDS = queryRun.query().dataSourceTable(tableNum({QueryTable}));");
                CodeGenerate.AppendLine($"SysQuery::findOrCreateRange(qBDS, fieldnum({QueryTable}, RecId)).value(queryValue(\"\"));");
                CodeGenerate.AppendLine("");
                CodeGenerate.AppendLine("this.progressInit(RunBase::getDescription(classIdGet(this)),");
                CodeGenerate.AppendLine("SysQuery::countTotal(queryRun),");
                CodeGenerate.AppendLine("#AviSearch);");
                CodeGenerate.AppendLine("");
                CodeGenerate.AppendLine("while (queryRun.next())");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine($"{queryCursor} = queryRun.get(tablenum({QueryTable}));");
                CodeGenerate.AppendLine("");
                CodeGenerate.AppendLine("processedCounter++;");
                CodeGenerate.AppendLine("progress.incCount();");             
                CodeGenerate.EndBlock();
                CodeGenerate.AppendLine("info(strfmt(\" %1 record(s) processed\", processedCounter));");
            }
            else
            {
                CodeGenerate.AppendLine("if (! this.validate())");
                CodeGenerate.AppendLine("{");
                CodeGenerate.AppendLine("    throw error(\"Validation error\");");
                CodeGenerate.AppendLine("}");
                CodeGenerate.AppendLine("");
                CodeGenerate.AppendLine("ttsbegin;");
                CodeGenerate.AppendLine("");
                CodeGenerate.AppendLine("ttscommit;");                
            }
            CodeGenerate.EndBlock();
        }
        void SrcShowQueryValues()
        {
            CodeGenerate.SetMethodName("showQueryValues");
            if (!String.IsNullOrEmpty(QueryTable))
            {
                CodeGenerate.AppendLine("public boolean showQueryValues()");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("return true;");
                CodeGenerate.EndBlock();
            }
        }
        void SrcParmMethod(RunBaseBuilderVars  parmVar)
        {
            string mName = $"parm{AxHelper.UppercaseWords(parmVar.Name)}";
            CodeGenerate.SetMethodName(mName);
            CodeGenerate.AppendLine($"public {parmVar.Type} {mName}({parmVar.Type} _{parmVar.Name} = {parmVar.Name})");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"{parmVar.Name} = _{parmVar.Name};");
            CodeGenerate.AppendLine($"return {parmVar.Name};");
            CodeGenerate.EndBlock();
        }

        //void AddMethodCode(String methodName, String methodSourceText, ClassMethodType methodType)
        void AddMethodCode()
        {
            if (String.IsNullOrEmpty(CodeGenerate.GetResult()))
            {
                return;
            }
            if (IsPreviewMode)
            {
                CodeGenerate.AppendLine("");
            }
            else
            {
                if (CodeGenerate.MethodType == ClassMethodType.ClassDeclaration)
                {
                    newAxClass.SourceCode.Declaration = CodeGenerate.GetResult();
                }
                else
                {
                    AxMethod  axMethod = new AxMethod();
                    axMethod.Name = CodeGenerate.MethodName;
                    axMethod.IsStatic = (CodeGenerate.MethodType == ClassMethodType.Static ? true : false);
                    axMethod.Source = CodeGenerate.GetResult();

                    newAxClass.AddMethod(axMethod);

                    CodeGenerate.ClearResult();

                }
            }
        }

        void CreateClassMethods()
        {
            InitCodeGenerate();
            SrcClassDeclaration(); AddMethodCode();
            SrcConstruct(); AddMethodCode();
            SrcDescription(); AddMethodCode();
            SrcMain(); AddMethodCode();
            SrcDialog(); AddMethodCode();
            SrcGetFromDialog(); AddMethodCode();
            SrcInitParmDefault(); AddMethodCode();
            SrcInitQuery(); AddMethodCode();
            SrcPack(); AddMethodCode();
            SrcUnpack(); AddMethodCode();
            SrcQueryRun(); AddMethodCode();
            SrcRun(); AddMethodCode();
            SrcShowQueryValues(); AddMethodCode();
            foreach (RunBaseBuilderVars df in FieldsList)
            {
                SrcParmMethod(df); AddMethodCode();               
            }
        }

        void CreateClass()
        {
            AxHelper axHelper = new AxHelper();

            newAxClass = axHelper.MetadataProvider.Classes.Read(ClassName);

            if (newAxClass != null)
            {
                throw new Exception($"Class {ClassName} already exists");
            }

            newAxClass = new AxClass { Name = ClassName };

            StringBuilder declarationText = new StringBuilder();
            

            declarationText.AppendLine($"public class {newAxClass.Name} extends RunBaseBatch");
            declarationText.AppendLine("{");
            declarationText.AppendLine("}");

            newAxClass.SourceCode.Declaration = declarationText.ToString();

            axHelper.MetaModelService.CreateClass(newAxClass, axHelper.ModelSaveInfo);
            axHelper.AppendToActiveProject(newAxClass);

            AddLog($"Class: {newAxClass.Name}; ");

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
            /*
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"class {ClassName}");
            sb.AppendLine(this.ToString());
            foreach (var field in FieldsList)
            {
                sb.AppendLine(field.ToString());
            }

            return sb.ToString();
            */
            IsPreviewMode = true;
            CreateClassMethods();
            return CodeGenerate.GetResult();
        }
    }
}

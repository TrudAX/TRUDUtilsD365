using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;

namespace TRUDUtilsD365.RunBaseBuilder
{
    public enum FileUploadType
    {
        None,
        Normal,
        Excel,
        CSV
    }
    public class RunBaseBuilderVar
    {
        public string Name { get; set; } = "";
        public string DlgName { get; set; } = "";
        public string Type { get; set; } = "";
        public string Label { get; set; } = "";
        public string LabelHelp { get; set; } = "";
        public Boolean IsMandatory { get; set; } 

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
        public FileUploadType IsAddFileUpload { get; set; } = FileUploadType.None;
        public Boolean IsCreateMenuItem { get; set; } 

        public List<RunBaseBuilderVar> FieldsList;
        protected RunBaseBuilderVar ExternalTableVar;

        protected AxClass NewAxClass;


        protected const char   MandatoryPropertySym      = '*';
        protected const string ClassNameParm             = "Class name";
        protected const string DescriptionParmName       = "Description";
        protected const string QueryTableParmName        = "Query table";
        protected const string ExternalTableNameParmName = "External table name";
        protected const string AddFileUploadParmName     = "Add file upload(y,excel,csv)";
        protected const string CreateMenuItemParmName    = "Create menu item(y)";
        protected const string ParametersParmName        = "Parameters..";

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
                                                                   $"NoYesId {snippetsParms.ValuesSeparator} useCurrentDate {snippetsParms.ValuesSeparator} Use current date {snippetsParms.ValuesSeparator} Help text");

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
            switch (snippetsParms.GetParmStr(AddFileUploadParmName).ToLower())
            {
                case "y":
                    IsAddFileUpload = FileUploadType.Normal;
                    break;
                case "excel":
                    IsAddFileUpload = FileUploadType.Excel;
                    break;
                case "csv":
                    IsAddFileUpload = FileUploadType.CSV;
                    break;
            }
            IsCreateMenuItem = snippetsParms.GetParmBool(CreateMenuItemParmName);
            if (ExternalTable != "")
            {
                ExternalTableVar = new RunBaseBuilderVar();
                ExternalTableVar.Type = ExternalTable;
                ExternalTableVar.Name = $"caller{ExternalTable}";
            }
            List<List<string>> parmList = snippetsParms.GetParmListSeparated(ParametersParmName);
            FieldsList = new List<RunBaseBuilderVar>();

            foreach (List<string> subList in parmList)
            {
                RunBaseBuilderVar runBaseBuilderVars = new RunBaseBuilderVar();

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
            int longestNameLength = FieldsList.Count > 0  ? (from x in FieldsList select x.Name.Length).Max() : 10;
            int longestTypeLength = FieldsList.Count > 0  ? (from x in FieldsList select x.Type.Length).Max() : 10;
            longestTypeLength = Math.Max("DialogField".Length, longestTypeLength);
            longestTypeLength++;
            longestNameLength+=2;

            CodeGenerate = new CodeGenerateHelper {IndentGlobalValue = 0};

            CodeGenerate.AddColumnAlignInt("Type", longestTypeLength);
            CodeGenerate.AddColumnAlignInt("FieldName", longestNameLength);
            CodeGenerate.AddColumnAlignInt("DlgName", longestNameLength + 2);
        }

        private void SrcClassDeclaration()
        {
            CodeGenerate.SetMethodName("ClassDeclaration", ClassMethodType.ClassDeclaration);
            CodeGenerate.AppendLine($"public class {ClassName} extends RunBaseBatch implements BatchRetryable");
            CodeGenerate.BeginBlock();
            foreach (RunBaseBuilderVar df in FieldsList)
            {
                CodeGenerate.Append(df.Type, "Type").AppendLine($" {df.Name};");
            }

            if (FieldsList.Count == 0)
            {
                CodeGenerate.AppendLine("Integer dummy;");
            }
            CodeGenerate.AppendLine("");

            foreach (RunBaseBuilderVar df in FieldsList)
            {
                CodeGenerate.Append("DialogField", "Type").AppendLine($" {df.DlgName};");
            }
            CodeGenerate.AppendLine("");
            if (QueryTable != "")
            {
                CodeGenerate.AppendLine("QueryRun       queryRun;");
            }

            if (ExternalTableVar != null)
            {
                CodeGenerate.AppendLine("");
                CodeGenerate.Append(ExternalTableVar.Type, "Type").AppendLine($" {ExternalTableVar.Name};");
            }

            if (IsAddFileUpload != FileUploadType.None )
            {
                CodeGenerate.AppendLine("");
                CodeGenerate.AppendLine("DialogRunbase     dialog;");
                CodeGenerate.AppendLine("private const str FileUploadName = 'FileUpload';");
                CodeGenerate.AppendLine("private const str OkButtonName   = 'OkButton';");
                CodeGenerate.AppendLine("FileUploadTemporaryStorageResult    fileUploadResult;");

            }
            CodeGenerate.AppendLine("");
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
            CodeGenerate.AppendLine("");
            if (!IsPreviewMode)
            {
                CodeGenerate.EndBlock();
                CodeGenerate.IndentIncrease();
            }
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
            CodeGenerate.AppendLine("runObject.runOperation();");
            CodeGenerate.EndBlock();

            CodeGenerate.EndBlock();
        }

        void SrcDialog()
        {
            CodeGenerate.SetMethodName("dialog");
            CodeGenerate.AppendLine("public Object dialog()");
            CodeGenerate.BeginBlock();
            if (IsAddFileUpload != FileUploadType.None)
            {
                CodeGenerate.AppendLine("dialog = super();");
                CodeGenerate.AppendLine("DialogGroup       dialogGroup;");
                CodeGenerate.AppendLine("FormBuildControl  formBuildControl;");
                CodeGenerate.AppendLine("FileUploadBuild   dialogFileUpload;");
                CodeGenerate.AppendLine(";");
                CodeGenerate.AppendLine("dialogGroup      = dialog.addGroup(\"File\");");
                CodeGenerate.AppendLine("formBuildControl = dialog.formBuildDesign().control(dialogGroup.name());");
                CodeGenerate.AppendLine("dialogFileUpload = formBuildControl.addControlEx(classstr(FileUpload), FileUploadName);");
                CodeGenerate.AppendLine("dialogFileUpload.style(FileUploadStyle::MinimalWithFilename);");
                CodeGenerate.AppendLine("dialogFileUpload.baseFileUploadStrategyClassName(classstr(FileUploadTemporaryStorageStrategy));");
                switch (IsAddFileUpload)
                {                    
                    case FileUploadType.CSV:
                        CodeGenerate.AppendLine("dialogFileUpload.fileTypesAccepted('.csv');");
                        break;
                    case FileUploadType.Excel:
                        CodeGenerate.AppendLine("dialogFileUpload.fileTypesAccepted('.xlsx');");
                        break;
                    default:
                        CodeGenerate.AppendLine("dialogFileUpload.fileTypesAccepted('.txt');");
                        break;
                }
                CodeGenerate.AppendLine("dialogFileUpload.fileNameLabel(\"@SYS308842\");");
                CodeGenerate.AppendLine("");
            }
            else
            {
                CodeGenerate.AppendLine("DialogRunbase       dialog = super();");
                CodeGenerate.AppendLine(";");
            }
            

            foreach (RunBaseBuilderVar df in FieldsList)
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
                        CodeGenerate.AppendLine($", \"{df.LabelHelp}\");");
                    }
                }
                if (df.IsMandatory)
                {
                    CodeGenerate.AppendLine($"{df.DlgName}.mandatory_RU(true);");
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
            if (IsAddFileUpload != FileUploadType.None)
            {
                CodeGenerate.AppendLine("FileUpload  fileUploadControl = this.getFormControl(dialog, FileUploadName);");
                CodeGenerate.AppendLine("fileUploadResult = fileUploadControl.getFileUploadResult();");
                CodeGenerate.AppendLine("");
            }
            else
            {
                CodeGenerate.AppendLine(";");
            }

            foreach (RunBaseBuilderVar df in FieldsList)
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

            foreach (RunBaseBuilderVar df in FieldsList)
            {
                CodeGenerate.AppendLine($"info(strFmt(\"{df.Name}=%1\", {df.Name}));");
            }
            if (IsAddFileUpload != FileUploadType.None)
            {
                CodeGenerate.AppendLine("System.IO.MemoryStream memoryStreamFile;");
                CodeGenerate.AppendLine("try");
                CodeGenerate.AppendLine("{");
                CodeGenerate.AppendLine("    if (!fileUploadResult)");
                CodeGenerate.AppendLine("    {");
                CodeGenerate.AppendLine("        throw error(\"File is empty\");");
                CodeGenerate.AppendLine("    }");
                CodeGenerate.AppendLine("    //get file names");
                CodeGenerate.AppendLine("    container fileNameCon = Docu::splitFilename(fileUploadResult.getFileName());");
                CodeGenerate.AppendLine("    if (!fileNameCon)");
                CodeGenerate.AppendLine("    {");
                CodeGenerate.AppendLine("        throw error(\"File is empty\");");
                CodeGenerate.AppendLine("    }");
                CodeGenerate.AppendLine("    str fileName   = strFmt('%1.%2', conPeek(fileNameCon, 1), conPeek(fileNameCon, 2));");
                CodeGenerate.AppendLine("    str folderName = strFmt('%1', conPeek(fileNameCon, 3));");
                CodeGenerate.AppendLine("    //get file data");
                CodeGenerate.AppendLine("    memoryStreamFile = fileUploadResult.openResult();");
                switch (IsAddFileUpload)
                {
                    case FileUploadType.CSV:
                        CodeGenerate.AppendLine("    //https://github.com/TrudAX/XppTools#devcommon-model");
                        CodeGenerate.AppendLine("    DEVFileReaderCSV   fileReader   = new DEVFileReaderCSV();");
                        CodeGenerate.AppendLine("    fileReader.readCSVFile(memoryStreamFile);");
                        CodeGenerate.AppendLine("    fileReader.readHeaderRow();");
                        CodeGenerate.AppendLine("    while (fileReader.readNextRow())");
                        CodeGenerate.AppendLine("    {");
                        CodeGenerate.AppendLine("        info(strFmt(\"row: % 1\", fileReader.getCurRow()));");
                        CodeGenerate.AppendLine("        info(strFmt(\" % 1, % 2, % 3\",");
                        CodeGenerate.AppendLine("            fileReader.getStringByName('Main account'),");
                        CodeGenerate.AppendLine("            fileReader.getStringByName('BusinessUnit'),");
                        CodeGenerate.AppendLine("            fileReader.getRealByName('Amount')");
                        CodeGenerate.AppendLine("            ));");
                        CodeGenerate.AppendLine("    }");
                        break;
                    case FileUploadType.Excel:
                        CodeGenerate.AppendLine("    //https://github.com/TrudAX/XppTools#devcommon-model");
                        CodeGenerate.AppendLine("    DEVFileReaderExcel   fileReader   = new DEVFileReaderExcel();");
                        CodeGenerate.AppendLine("    fileReader.openFile(memoryStreamFile);");
                        CodeGenerate.AppendLine("    fileReader.readHeaderRow();");
                        CodeGenerate.AppendLine("    while (fileReader.readNextRow())");
                        CodeGenerate.AppendLine("    {");
                        CodeGenerate.AppendLine("        info(strFmt(\"row: % 1\", fileReader.getCurRow()));");
                        CodeGenerate.AppendLine("        info(strFmt(\" % 1, % 2, % 3\",");
                        CodeGenerate.AppendLine("            fileReader.getStringByName(\"Main account\"),");
                        CodeGenerate.AppendLine("            fileReader.getStringByName(\"BusinessUnit\"),");
                        CodeGenerate.AppendLine("            fileReader.getRealByName(\"Amount\")");
                        CodeGenerate.AppendLine("            ));");
                        CodeGenerate.AppendLine("    }");
                        break;
                    default:
                        CodeGenerate.AppendLine("    AsciiStreamIo asciiIo = AsciiStreamIo::constructForRead(memoryStreamFile);");
                        CodeGenerate.AppendLine("    asciiIo.inRecordDelimiter('\\n');");
                        CodeGenerate.AppendLine("    while (asciiIo.status() == IO_Status::Ok)");
                        CodeGenerate.AppendLine("    {");
                        CodeGenerate.AppendLine("        container c = asciiIo.read();");
                        CodeGenerate.AppendLine("        if (conLen(c) > 0)");
                        CodeGenerate.AppendLine("        {");
                        CodeGenerate.AppendLine("            info(strFmt(\"File data:%1\", conPeek(c, 1)));");
                        CodeGenerate.AppendLine("        }");
                        CodeGenerate.AppendLine("    }");
                        break;
                }
                

                CodeGenerate.AppendLine("}");
                CodeGenerate.AppendLine("catch (Exception::Error)");
                CodeGenerate.AppendLine("{");
                CodeGenerate.AppendLine("    exceptionTextFallThrough();");
                CodeGenerate.AppendLine("}");
                CodeGenerate.AppendLine("finally");
                CodeGenerate.AppendLine("{");
                CodeGenerate.AppendLine("    fileUploadResult.deleteResult();");
                CodeGenerate.AppendLine("    memoryStreamFile = null;");
                CodeGenerate.AppendLine("}");
            }

            if (!String.IsNullOrEmpty(QueryTable))
            {
                string queryCursor = AxHelper.GetVarNameFromType(QueryTable);
                CodeGenerate.AppendLine("int                     processedCounter;");
                CodeGenerate.AppendLine("QueryBuildDataSource    qBDS;");
                CodeGenerate.AppendLine($"{QueryTable}    {queryCursor};");
                CodeGenerate.AppendLine("");
                CodeGenerate.AppendLine($"qBDS = queryRun.query().dataSourceTable(tableNum({QueryTable}));");
                CodeGenerate.AppendLine($"SysQuery::findOrCreateRange(qBDS, fieldnum({QueryTable}, RecId)).value(queryValue(\"\"));");
                CodeGenerate.AppendLine("");
                CodeGenerate.AppendLine("this.progressInit(RunBase::getDescription(classIdGet(this)),");
                CodeGenerate.AppendLine("                  SysQuery::countTotal(queryRun),");
                CodeGenerate.AppendLine("                  #AviSearch);");
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
                if (IsAddFileUpload == FileUploadType.None)
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
        void SrcCanRunInNewSession()
        {
            CodeGenerate.SetMethodName("canRunInNewSession");
     
            CodeGenerate.AppendLine("public boolean canRunInNewSession()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine("return false;");
            CodeGenerate.EndBlock();          
        }
        void SrcCanGoBatch()
        {
            CodeGenerate.SetMethodName("canGoBatch");

            CodeGenerate.AppendLine("public boolean canGoBatch()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine("return false;");
            CodeGenerate.EndBlock();
        }
        void SrcIsRetryable()
        {
            CodeGenerate.SetMethodName("isRetryable");

            CodeGenerate.AppendLine("public boolean isRetryable()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine("return true;");
            CodeGenerate.EndBlock();
        }

        void SrcDialogPostRun()
        {
            CodeGenerate.SetMethodName("dialogPostRun");
            if (IsAddFileUpload != FileUploadType.None)
            {
                CodeGenerate.AppendLine("public void dialogPostRun(DialogRunbase _dialog)");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("FileUpload fileUpload = this.getFormControl(_dialog, FileUploadName);");
                CodeGenerate.AppendLine("fileUpload.notifyUploadCompleted += eventhandler(this.uploadCompleted);");
                CodeGenerate.AppendLine("this.setDialogOkButtonEnabled(_dialog, false);");
                CodeGenerate.EndBlock();
            }
        }
        void SrcUploadCompleted()
        {
            CodeGenerate.SetMethodName("uploadCompleted");
            if (IsAddFileUpload != FileUploadType.None)
            {
                CodeGenerate.AppendLine("protected void uploadCompleted()");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("FileUpload fileUpload = this.getFormControl(dialog, FileUploadName);");
                CodeGenerate.AppendLine("fileUpload.notifyUploadCompleted -= eventhandler(this.uploadCompleted);");
                CodeGenerate.AppendLine("this.setDialogOkButtonEnabled(dialog, true);");
                CodeGenerate.EndBlock();
            }
        }
        void SrcSetDialogOkButtonEnabled()
        {
            CodeGenerate.SetMethodName("setDialogOkButtonEnabled");
            if (IsAddFileUpload != FileUploadType.None)
            {
                CodeGenerate.AppendLine("protected void setDialogOkButtonEnabled(DialogRunbase _dialog, boolean _isEnabled)");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("FormControl okButtonControl = this.getFormControl(_dialog, OkButtonName);");
                CodeGenerate.AppendLine("if (okButtonControl)");
                CodeGenerate.AppendLine("{");
                CodeGenerate.AppendLine("    okButtonControl.enabled(_isEnabled);");
                CodeGenerate.AppendLine("}");
                CodeGenerate.EndBlock();
            }
        }
        void SrcGetFormControl()
        {
            CodeGenerate.SetMethodName("getFormControl");
            if (IsAddFileUpload != FileUploadType.None)
            {
                CodeGenerate.AppendLine("protected FormControl getFormControl(DialogRunbase _dialog, str _controlName)");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("return _dialog.formRun().control(_dialog.formRun().controlId( _controlName));");                
                CodeGenerate.EndBlock();
            }
        }
        void SrcParmMethod(RunBaseBuilderVar  parmVar)
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
            AddClassMethodCode(NewAxClass);            
        }

        void CreateClassMethods()
        {
            InitCodeGenerate();
            SrcClassDeclaration(); AddMethodCode();
            SrcDialog(); AddMethodCode();
            SrcGetFromDialog(); AddMethodCode();
            foreach (RunBaseBuilderVar df in FieldsList)
            {
                SrcParmMethod(df); AddMethodCode();
            }
            if (ExternalTableVar != null)
            {
                SrcParmMethod(ExternalTableVar); AddMethodCode();
            }
            SrcInitParmDefault(); AddMethodCode();
            SrcInitQuery(); AddMethodCode();
            SrcPack(); AddMethodCode();
            SrcUnpack(); AddMethodCode();
            SrcQueryRun(); AddMethodCode();
            SrcRun(); AddMethodCode();
            SrcShowQueryValues(); AddMethodCode();
            SrcCanRunInNewSession(); AddMethodCode();
            SrcCanGoBatch(); AddMethodCode();
            SrcIsRetryable(); AddMethodCode();
            SrcDialogPostRun(); AddMethodCode();
            SrcUploadCompleted(); AddMethodCode();
            SrcSetDialogOkButtonEnabled(); AddMethodCode();
            SrcGetFormControl(); AddMethodCode();
            SrcConstruct(); AddMethodCode();
            SrcDescription(); AddMethodCode();
            SrcMain(); AddMethodCode();

            if (IsPreviewMode)
            {
                CodeGenerate.EndBlock();
            }
        }

        void CreateClass()
        {
            AxHelper axHelper = new AxHelper();

            NewAxClass = axHelper.MetadataProvider.Classes.Read(ClassName);
            //newAxClass = axHelper.MetadataProvider.Classes.Read("Tutorial_RunbaseBatch");
            if (NewAxClass != null)
            {
                throw new Exception($"Class {ClassName} already exists");
            }

            if (IsCreateMenuItem)
            {
                if (axHelper.MetadataProvider.MenuItemActions.Read(ClassName) != null)
                {
                    throw new Exception($"Menu item action {ClassName} already exists");
                }
            }

            NewAxClass = new AxClass { Name = ClassName };
            CreateClassMethods();

            axHelper.MetaModelService.CreateClass(NewAxClass, axHelper.ModelSaveInfo);
            axHelper.AppendToActiveProject(NewAxClass);

            AddLog($"Class: {NewAxClass.Name}; ");

            if (IsCreateMenuItem)
            {
                AxMenuItemAction axMenuItem = new AxMenuItemAction
                    {Name = ClassName, Object = ClassName, ObjectType = MenuItemObjectType.Class};
                axMenuItem.Label    = ClassDescription;
                axMenuItem.HelpText = $"{axMenuItem.Label} operation";
                axHelper.MetaModelService.CreateMenuItemAction(axMenuItem, axHelper.ModelSaveInfo);
                axHelper.AppendToActiveProject(axMenuItem);

                AddLog($"MenuItem: {axMenuItem.Name}; ");
            }

        }

        public override void RunCreate()
        {
            CreateClass();            
        }

        public override string RunPreview()
        {           
            CreateClassMethods();
            return CodeGenerate.GetResult();
        }
    }
}

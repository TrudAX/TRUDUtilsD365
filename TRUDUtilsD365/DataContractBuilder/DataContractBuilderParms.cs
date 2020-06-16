using System;
using System.Collections.Generic;
using System.Linq;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.DataContractBuilder
{
    public class DataContractBuilderVar
    {
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public string Label { get; set; } = "";
        public string LabelHelp { get; set; } = "";
        public string GroupName { get; set; } = "";
        public string GroupLabel { get; set; } = "";
        public Boolean IsMandatory { get; set; }

        //calculated 
        public int PositionInGroup;

        public override string ToString()
        {
            return $"Type:{Type}, varName:{Name}, Mandatory:{IsMandatory}, Label:{Label}, Help:{LabelHelp}";
        }
    }


    public class DataContractBuilderParms : SnippedCreateAction
    {        
        public string ClassName { get; set; } = "";

        public Boolean GenerateReportDP { get; set; } = false;
        public string ReportDPTableName { get; set; } = "";
        public string ClassNameDP { get; set; } = "";
        public string ReportDPTableVarName { get; set; } = "";

        public Boolean GenerateReportController { get; set; } = false;
        public string ClassNameController { get; set; } = "";

        public List<DataContractBuilderVar> FieldsList;

        //calculated 
        public List<DataContractBuilderVar> GroupsList;
        protected bool IsAnyMandatory;

        protected AxClass NewAxClass;

        protected const char   MandatoryPropertySym         = '*';
        protected const string ClassNameParm                = "Class name";
        protected const string GenerateReportDPParm         = "Generate report DP(y)";
        protected const string ReportDPTableNameParm        = "Report DP table name";
        protected const string GenerateReportControllerParm = "Generate report controller(y)";
        protected const string ParametersParmName           = "Parameters..";

        public void InitDialogParms(SnippetsParms snippetsParms)
        {
            snippetsParms.SnippetName = "Create DataContract class";

            snippetsParms.AddParametersValue(ClassNameParm, "AATestDataContract");

            snippetsParms.AddParametersValue(GenerateReportDPParm, "y");
            snippetsParms.AddParametersValue(ReportDPTableNameParm, "TmpLedgerConsTrans");
            snippetsParms.AddParametersValue(GenerateReportControllerParm, "y");

            snippetsParms.AddParametersValue(ParametersParmName,   
                $"CustAccount" + MandatoryPropertySym + Environment.NewLine +
                $"NoYesId {snippetsParms.ValuesSeparator} useCurrentDate {snippetsParms.ValuesSeparator} Use current date {snippetsParms.ValuesSeparator} Help text" + Environment.NewLine +
                $"FromDate {snippetsParms.ValuesSeparator} fromDate {snippetsParms.ValuesSeparator} From date label {snippetsParms.ValuesSeparator} Help text { snippetsParms.ValuesSeparator} GroupId { snippetsParms.ValuesSeparator} Group label");

            snippetsParms.Description = "Util creates a DataContract type class. You can specify multiple parameters - each as a separate line in the following format:"+ Environment.NewLine + "EDTType | Variable name | " +
                                        "Label | Help text | GroupId | Group label" + Environment.NewLine + "You can specify only EDTType. For the Mandatory property add * to the EDTType";

            snippetsParms.IsFieldsSeparatorVisible = true;
            snippetsParms.IsCreateButtonVisible = true;

            snippetsParms.CreateAction = this;
            snippetsParms.PreviewAction = this;
        }
        public override void InitFromSnippetsParms(SnippetsParms snippetsParms)
        {
            ClassName                = snippetsParms.GetParmStr(ClassNameParm);
            GenerateReportController = snippetsParms.GetParmBool(GenerateReportControllerParm);
            GenerateReportDP         = snippetsParms.GetParmBool(GenerateReportDPParm);
            ReportDPTableName        = snippetsParms.GetParmStr(ReportDPTableNameParm);
            if (String.IsNullOrWhiteSpace(ReportDPTableName))
            {
                ReportDPTableName = "TableTemDB";
            }
            ReportDPTableVarName = AxHelper.GetVarNameFromType(ReportDPTableName);
            string baseStr = ClassName;
            if (ClassName.ToLower().EndsWith("contract"))
            {
                baseStr = ClassName.Substring(0, ClassName.Length - "contract".Length);
            }
            ClassNameDP = $"{baseStr}DP";
            ClassNameController = $"{baseStr}Controller";

            List<List<string>> parmList = snippetsParms.GetParmListSeparated(ParametersParmName);
            FieldsList = new List<DataContractBuilderVar>();
            GroupsList = new List<DataContractBuilderVar>();
            int groupNum = 0;
            IsAnyMandatory = false;

            Dictionary<string, int> groutPosDict = new Dictionary<string, int>();

            foreach (List<string> subList in parmList)
            {
                DataContractBuilderVar builderVar = new DataContractBuilderVar();

                string item = subList[0];                
                if (item[item.Length - 1] == MandatoryPropertySym)//check mandatory
                {
                    builderVar.IsMandatory = true;
                    builderVar.Type        = item.Remove(item.Length - 1).Trim();
                }
                else
                {
                    builderVar.IsMandatory = false;
                    builderVar.Type        = item;
                }

                if (String.IsNullOrEmpty(builderVar.Type))
                {
                    throw new Exception("Type should be specified");
                }

                if (subList.Count > 1 && ! String.IsNullOrWhiteSpace(subList[1])) //check var name
                {
                    builderVar.Name = subList[1];
                }
                else
                {
                    builderVar.Name = AxHelper.GetVarNameFromType(builderVar.Type);
                }
                if (subList.Count > 2 && !String.IsNullOrWhiteSpace(subList[2])) 
                {
                    builderVar.Label = subList[2];
                }
                if (subList.Count > 3 && !String.IsNullOrWhiteSpace(subList[3]))
                {
                    builderVar.LabelHelp = subList[3];
                }
                if (subList.Count > 4 && !String.IsNullOrWhiteSpace(subList[4]))
                {
                    builderVar.GroupName = subList[4];
                }
                if (subList.Count > 5 && !String.IsNullOrWhiteSpace(subList[5]))
                {
                    builderVar.GroupLabel = subList[5];
                }

                //calculate
                if (! groutPosDict.ContainsKey(builderVar.GroupName))
                {
                    groutPosDict.Add(builderVar.GroupName, 0);
                    if (!String.IsNullOrWhiteSpace(builderVar.GroupName))
                    {
                        groupNum++;
                        var varGr = new DataContractBuilderVar
                        {
                            GroupName       = builderVar.GroupName,
                            GroupLabel      = builderVar.GroupLabel,
                            PositionInGroup = groupNum
                        };
                        GroupsList.Add(varGr);
                    }
                }
                groutPosDict[builderVar.GroupName]++;
                if (builderVar.IsMandatory)
                {
                    IsAnyMandatory = true;
                }

                builderVar.PositionInGroup = groutPosDict[builderVar.GroupName];

                FieldsList.Add(builderVar);
            }
        }

        void InitCodeGenerate()
        {
            int longestNameLength = (from x in FieldsList select x.Name.Length).Max();
            int longestTypeLength = (from x in FieldsList select x.Type.Length).Max();
            longestTypeLength++;
            longestNameLength++;

            CodeGenerate = new CodeGenerateHelper {IndentGlobalValue = 0};

            CodeGenerate.AddColumnAlignInt("Type", longestTypeLength);
            CodeGenerate.AddColumnAlignInt("FieldName", longestNameLength);

            
        }

        private void SrcClassDeclaration()
        {
            CodeGenerate.SetMethodName("ClassDeclaration", ClassMethodType.ClassDeclaration);
            CodeGenerate.AppendLine("[");
            CodeGenerate.IndentIncrease();
            CodeGenerate.ProcessLastSym(",");
            CodeGenerate.Append("DataContractAttribute");
            foreach (DataContractBuilderVar df in GroupsList)
            {
                CodeGenerate.ProcessLastSym(",");
                CodeGenerate.Append($"SysOperationGroupAttribute('{df.GroupName}', \"{df.GroupLabel}\", '{df.PositionInGroup}')");
            }
            CodeGenerate.AppendLine("").IndentDecrease();
            CodeGenerate.AppendLine("]");

            CodeGenerate.Append($"public class {ClassName}");
            if (IsAnyMandatory)
            {
                CodeGenerate.AppendLine(" implements SysOperationValidatable");
            }
            else
            {
                CodeGenerate.AppendLine("");
            }
            CodeGenerate.BeginBlock();
            foreach (DataContractBuilderVar df in FieldsList)
            {
                CodeGenerate.Append(df.Type, "Type").AppendLine($" {df.Name};");
            }
            
            CodeGenerate.AppendLine("");
            if (!IsPreviewMode)
            {
                CodeGenerate.EndBlock();
                CodeGenerate.IndentIncrease();
            }
        }

            
        void SrcParmMethod(DataContractBuilderVar parmVar)
        {
            string mName = $"parm{AxHelper.UppercaseWords(parmVar.Name)}";
            CodeGenerate.SetMethodName(mName);

            CodeGenerate.AppendLine("[");
            CodeGenerate.IndentIncrease();
            CodeGenerate.ProcessLastSym(",");
            CodeGenerate.Append($"DataMemberAttribute(identifierStr({AxHelper.UppercaseWords(parmVar.Name)}))");
            if (!String.IsNullOrEmpty(parmVar.Label))
            {
                CodeGenerate.ProcessLastSym(",");
                CodeGenerate.Append($"SysOperationLabelAttribute(literalstr(\"{parmVar.Label}\"))");
            }
            if (!String.IsNullOrEmpty(parmVar.LabelHelp))
            {
                CodeGenerate.ProcessLastSym(",");
                CodeGenerate.Append($"SysOperationHelpTextAttribute(literalstr(\"{parmVar.LabelHelp}\"))");
            }
            if (!String.IsNullOrEmpty(parmVar.GroupName))
            {
                CodeGenerate.ProcessLastSym(",");
                CodeGenerate.Append($"SysOperationGroupMemberAttribute('{parmVar.GroupName}')");
            }
            if (parmVar.PositionInGroup > 0)
            {
                CodeGenerate.ProcessLastSym(",");
                CodeGenerate.Append($"SysOperationDisplayOrderAttribute('{parmVar.PositionInGroup.ToString()}')");
            }
            
            CodeGenerate.AppendLine("").IndentDecrease();
            CodeGenerate.AppendLine("]");

            CodeGenerate.AppendLine($"public {parmVar.Type} {mName}({parmVar.Type} _{parmVar.Name} = {parmVar.Name})");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"{parmVar.Name} = _{parmVar.Name};");
            CodeGenerate.AppendLine($"return {parmVar.Name};");
            CodeGenerate.EndBlock();
        }


        private void SrcValidate()
        {
            if (IsAnyMandatory)
            {
                CodeGenerate.SetMethodName("validate");
                CodeGenerate.AppendLine("public boolean validate()");
                CodeGenerate.BeginBlock();
                CodeGenerate.AppendLine("boolean ret = true;");
                CodeGenerate.AppendLine("");
                foreach (DataContractBuilderVar df in FieldsList.Where(li => li.IsMandatory))
                {
                    CodeGenerate.AppendLine($"if (!{df.Name})");
                    CodeGenerate.AppendLine("{");
                    CodeGenerate.AppendLine($"    ret = checkFailed(\"{(df.Label == "" ? df.Name : df.Label)} should be specified\");");
                    CodeGenerate.AppendLine("}");
                }

                CodeGenerate.AppendLine("return ret;");
                CodeGenerate.EndBlock();
            }
        }

        void AddMethodCode()
        {
            AddClassMethodCode(NewAxClass);            
        }

        void CreateClassMethodsContract()
        {
            InitCodeGenerate();
            SrcClassDeclaration(); AddMethodCode();
            foreach (DataContractBuilderVar df in FieldsList)
            {
                SrcParmMethod(df); AddMethodCode();
            }
            SrcValidate(); AddMethodCode();

            if (IsPreviewMode)
            {
                CodeGenerate.EndBlock();
            }
        }
        #region DPClass
        private void SrcDPClassDeclaration()
        {
            CodeGenerate.IndentSetValue(0);
            CodeGenerate.SetMethodName("ClassDeclaration", ClassMethodType.ClassDeclaration);

            CodeGenerate.AppendLine($"[SRSReportParameterAttribute(classStr({ClassName})),");
            CodeGenerate.AppendLine("SRSReportQueryAttribute(queryStr(LedgerJournalTrans))]  //Change query");
            CodeGenerate.AppendLine($"public class {ClassNameDP} extends SrsReportDataProviderPreProcessTempDB");
            CodeGenerate.BeginBlock();

            CodeGenerate.AppendLine($"{ReportDPTableName} {ReportDPTableVarName};");

            CodeGenerate.AppendLine("");
            if (!IsPreviewMode)
            {
                CodeGenerate.EndBlock();
                CodeGenerate.IndentIncrease();
            }
        }
        private void SrcDPgetReportDataTmp()
        {
            CodeGenerate.SetMethodName("getReportDataTmp");
            CodeGenerate.AppendLine($"[SRSReportDataSetAttribute(tableStr({ReportDPTableName}))]");
            CodeGenerate.AppendLine($"public {ReportDPTableName} getReportDataTmp()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"select * from {ReportDPTableVarName};");
            CodeGenerate.AppendLine($"return {ReportDPTableVarName};");
            CodeGenerate.EndBlock();
        }
        private void SrcDPprocessReport()
        {
            CodeGenerate.SetMethodName("processReport");
            CodeGenerate.AppendLine("public void processReport()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"{ClassName}   reportContract;");
            CodeGenerate.AppendLine("Query           query;");
            CodeGenerate.AppendLine("");
            CodeGenerate.AppendLine("reportContract  = this.parmDataContract();");
            CodeGenerate.AppendLine("query           = this.parmQuery();");
            CodeGenerate.AppendLine("//populate tempdb table here..");
            CodeGenerate.EndBlock();
        }
        void CreateDataProviderMethods()
        {
            SrcDPClassDeclaration(); AddMethodCode();
            SrcDPgetReportDataTmp(); AddMethodCode();
            SrcDPprocessReport(); AddMethodCode();

            if (IsPreviewMode)
            {
                CodeGenerate.EndBlock();
            }
        }
        #endregion

        #region ControllerClass
        private void SrcControllerClassDeclaration()
        {
            CodeGenerate.IndentSetValue(0);
            CodeGenerate.SetMethodName("ClassDeclaration", ClassMethodType.ClassDeclaration);

            CodeGenerate.AppendLine($"public class {ClassNameController} extends SrsReportRunController");
            CodeGenerate.BeginBlock();

            if (!IsPreviewMode)
            {
                CodeGenerate.EndBlock();
                CodeGenerate.IndentIncrease();
            }
        }
        private void SrcControllerprePromptModifyContract()
        {
            CodeGenerate.SetMethodName("prePromptModifyContract");
            CodeGenerate.AppendLine("protected void prePromptModifyContract()");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"{ClassName}      contract;");
            CodeGenerate.AppendLine("super();");
            CodeGenerate.AppendLine($"contract = this.parmReportContract().parmRdpContract() as {ClassName};");
            CodeGenerate.AppendLine("//handle external record");
            CodeGenerate.AppendLine("if (!args || ! args.record() || args.dataset() != tablenum(CustGroup))");
            CodeGenerate.AppendLine("{");
            CodeGenerate.AppendLine("    throw error(strfmt(\"@GLS110030\",tablestr(CustGroup)));");
            CodeGenerate.AppendLine("}");
            CodeGenerate.AppendLine("CustGroup custGroup = args.record();");
            CodeGenerate.AppendLine("//contract.parmGroupId(custGroup.GroupId);");
            CodeGenerate.AppendLine("//Query query = this.getFirstQuery();");
            CodeGenerate.EndBlock();
        }
        private void SrcControllermain()
        {
            CodeGenerate.SetMethodName("main", ClassMethodType.Static);
            CodeGenerate.AppendLine("public static void main (Args args)");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"{ClassNameController}         reportController;");
            CodeGenerate.AppendLine("");
            CodeGenerate.AppendLine($"reportController  = new {ClassNameController}();");
            CodeGenerate.AppendLine("");
            CodeGenerate.AppendLine("reportController.parmArgs(args);");
            CodeGenerate.AppendLine("reportController.parmReportName(ssrsReportStr(SalesInvoice,Report));");
            CodeGenerate.AppendLine("reportController.parmShowDialog(true);");
            CodeGenerate.AppendLine("reportController.startOperation();");
            CodeGenerate.EndBlock();
        }
        void CreateControllerMethods()
        {
            SrcControllerClassDeclaration(); AddMethodCode();
            SrcControllerprePromptModifyContract(); AddMethodCode();
            SrcControllermain(); AddMethodCode();

            if (IsPreviewMode)
            {
                CodeGenerate.EndBlock();
            }
        }
        #endregion

        void CreateClass()
        {
            AxHelper axHelper = new AxHelper();

            NewAxClass = axHelper.MetadataProvider.Classes.Read(ClassName);

            if (NewAxClass != null)
            {
                throw new Exception($"Class {ClassName} already exists");
            }            

            NewAxClass = new AxClass { Name = ClassName };
            CreateClassMethodsContract();

            axHelper.MetaModelService.CreateClass(NewAxClass, axHelper.ModelSaveInfo);
            axHelper.AppendToActiveProject(NewAxClass);

            AddLog($"Class: {NewAxClass.Name}; ");
        }

        void CreateDPClass()
        {
            AxHelper axHelper = new AxHelper();

            NewAxClass = axHelper.MetadataProvider.Classes.Read(ClassNameDP);

            if (NewAxClass != null)
            {
                CoreUtility.DisplayInfo($"Class {NewAxClass.Name} already exists");
                axHelper.AppendToActiveProject(NewAxClass);
            }
            else
            {
                NewAxClass = new AxClass { Name = ClassNameDP };
                CreateDataProviderMethods();

                axHelper.MetaModelService.CreateClass(NewAxClass, axHelper.ModelSaveInfo);
                axHelper.AppendToActiveProject(NewAxClass);

                AddLog($"Class: {NewAxClass.Name}; ");
            }
        }

        void CreateControllerClass()
        {
            AxHelper axHelper = new AxHelper();

            NewAxClass = axHelper.MetadataProvider.Classes.Read(ClassNameController);

            if (NewAxClass != null)
            {
                CoreUtility.DisplayInfo($"Class {NewAxClass.Name} already exists");
                axHelper.AppendToActiveProject(NewAxClass);
            }
            else
            {
                NewAxClass = new AxClass { Name = ClassNameController };
                CreateControllerMethods();

                axHelper.MetaModelService.CreateClass(NewAxClass, axHelper.ModelSaveInfo);
                axHelper.AppendToActiveProject(NewAxClass);

                AddLog($"Class: {NewAxClass.Name}; ");
            }
        }


        public override void RunCreate()
        {
            CreateClass();
            if (GenerateReportDP)
            {
                CreateDPClass();
            }
            if (GenerateReportController)
            {
                CreateControllerClass();
            }
        }

        public override string RunPreview()
        {           
            CreateClassMethodsContract();
            if (GenerateReportDP)
            {
                CreateDataProviderMethods();
            }
            if (GenerateReportController)
            {
                CreateControllerMethods();
            }

            return CodeGenerate.GetResult();
        }
    }
}

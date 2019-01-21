using System;
using System.Collections.Generic;
using System.Linq;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;

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

        public List<DataContractBuilderVar> FieldsList;

        //calculated 
        public List<DataContractBuilderVar> GroupsList;
        protected bool IsAnyMandatory;

        protected AxClass NewAxClass;

        protected const char   MandatoryPropertySym      = '*';
        protected const string ClassNameParm             = "Class name";
        protected const string ParametersParmName        = "Parameters..";

        public void InitDialogParms(SnippetsParms snippetsParms)
        {
            snippetsParms.SnippetName = "Create DataContract class";

            snippetsParms.AddParametersValue(ClassNameParm, "AATestDataContract");

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
            ClassName        = snippetsParms.GetParmStr(ClassNameParm);
            
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

        void CreateClassMethods()
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

        void CreateClass()
        {
            AxHelper axHelper = new AxHelper();

            NewAxClass = axHelper.MetadataProvider.Classes.Read(ClassName);

            if (NewAxClass != null)
            {
                throw new Exception($"Class {ClassName} already exists");
            }            

            NewAxClass = new AxClass { Name = ClassName };
            CreateClassMethods();

            axHelper.MetaModelService.CreateClass(NewAxClass, axHelper.ModelSaveInfo);
            axHelper.AppendToActiveProject(NewAxClass);

            AddLog($"Class: {NewAxClass.Name}; ");
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

using System;
using System.Collections.Generic;
using System.Linq;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;

namespace TRUDUtilsD365.TableRelationToXpp
{
    public class RelationDef
    {
        public string Field1 { get; set; } = "";
        public string Field2 { get; set; } = "";

        public bool Field1Fixed = false;
        public bool Field2Fixed = false;
    }
    public class TableRelationToXppParms : ISnippetPreviewAction
    {        
        public string Table1 { get; set; } = "";
        public string Table2 { get; set; } = "";

        public string Table1Var { get; set; } = "";
        public string Table2Var { get; set; } = "";

        public bool IsUseQuery { get; set; }

        protected const string Table1VarParm = "Table1 variable";
        protected const string Table2VarParm = "Table2 variable";
        protected const string IsUseQueryParm = "Use query(y)";

        protected List<RelationDef> RelationsList;

        protected CodeGenerateHelper CodeGenerate;

        public void InitDialogParms(SnippetsParms snippetsParms)
        {
            snippetsParms.SnippetName = "Table relation to Xpp code";

            snippetsParms.AddParametersValue(Table1VarParm, Table1Var);
            snippetsParms.AddParametersValue(Table2VarParm, Table2Var);
            snippetsParms.AddParametersValue(IsUseQueryParm, "");

            snippetsParms.Description = "Util converts table relation to X++ code";

            snippetsParms.PreviewAction = this;
        }
        public void InitFromSnippetsParms(SnippetsParms snippetsParms)
        {
            Table1Var = snippetsParms.GetParmStr(Table1VarParm);
            Table2Var = snippetsParms.GetParmStr(Table2VarParm);
            IsUseQuery = snippetsParms.GetParmBool(IsUseQueryParm);
        }        

        public void InitFromRelation(Relation relation)
        {
            Table1 = relation.RelatedTable;
            Table2 = relation.Table.Name;

            Table1Var = AxHelper.GetVarNameFromType(Table1);
            Table2Var = AxHelper.GetVarNameFromType(Table2);
            string relationName;
            relationName = relation.Name;

            RelationsList = new List<RelationDef>();

            AxHelper axHelper = new AxHelper();
            AxTable  axTable = axHelper.MetadataProvider.Tables.Read(Table2);
            AxTableRelation axTableRelation = axTable.Relations[relationName];
            foreach (AxTableRelationConstraint relationPair in axTableRelation.Constraints)
            {
                RelationDef pair = new RelationDef();

                if (relationPair is AxTableRelationConstraintField)
                {
                    pair.Field1 = (relationPair as AxTableRelationConstraintField).RelatedField;
                    pair.Field2 = (relationPair as AxTableRelationConstraintField).Field;
                }
                else
                {
                    if (relationPair is AxTableRelationConstraintFixed)
                    {
                        pair.Field1 = (relationPair as AxTableRelationConstraintFixed).ValueStr;
                        pair.Field2 = (relationPair as AxTableRelationConstraintFixed).Field;
                        pair.Field1Fixed = true;
                    }
                    else
                    {
                        if (relationPair is AxTableRelationConstraintRelatedFixed)
                        {
                            pair.Field1      = (relationPair as AxTableRelationConstraintRelatedFixed).RelatedField;
                            pair.Field2      = (relationPair as AxTableRelationConstraintRelatedFixed).ValueStr;
                            pair.Field2Fixed = true;
                        }
                    }
                }

                if (!String.IsNullOrEmpty(pair.Field1))
                {
                    RelationsList.Add(pair);
                }
            }
        }

        void InitCodeGenerate()
        {
            int longestF1Length = (from x in RelationsList select x.Field1.Length).Max();
            int longestF2Length = (from x in RelationsList select x.Field2.Length).Max();
            longestF1Length++;
            longestF2Length++;

            CodeGenerate = new CodeGenerateHelper { IndentGlobalValue = 0 };

            CodeGenerate.AddColumnAlignInt("Field1", longestF1Length);
            CodeGenerate.AddColumnAlignInt("Field2", longestF2Length);

            CodeGenerate.AddColumnAlignInt("Table", Math.Max(Math.Max(Table1.Length, Table2.Length), "QueryBuildDataSource".Length));
        }
        public  void GenerateMethods()
        {
            InitCodeGenerate();

            CodeGenerate.IndentGlobalValue = 4;
            CodeGenerate.IndentIncrease();

            CodeGenerate.Append($"{Table1}", "Table").AppendLine($"  {Table1Var};");
            CodeGenerate.Append($"{Table2}", "Table").AppendLine($"  {Table2Var};");

            if (IsUseQuery)
            {
                GenerateQueryMethods();
            }
            else
            {
                CodeGenerate.AppendLine("");

                CodeGenerate.AppendLine($"while select {Table2Var}");
                CodeGenerate.Append("    where ");
                CodeGenerate.IndentSetAsCurrentPos();

                Boolean isFirst = true;
                foreach (RelationDef df in RelationsList)
                {
                    if (!isFirst) CodeGenerate.AppendLine(" && ");
                    CodeGenerate.Append(Table2Var + ".");
                    CodeGenerate.Append(df.Field2, "Field2");
                    string valueF1 = df.Field1Fixed ? "" : $"{Table1Var}.";
                    CodeGenerate.Append(" == " + valueF1);
                    CodeGenerate.Append(df.Field1, "Field1");
                    isFirst = false;
                }

                CodeGenerate.IndentRestorePrev();
                CodeGenerate.AppendLine("");
                CodeGenerate.AppendLine("{");
                CodeGenerate.AppendLine("}");
            }

        }

        public void GenerateQueryMethods()
        {
            CodeGenerate.Append("Query", "Table").AppendLine("  query = new Query();");
            CodeGenerate.Append("QueryBuildDataSource", "Table").AppendLine("  qBDS;");
            CodeGenerate.Append("QueryBuildRange", "Table").AppendLine("  qBR;");
            CodeGenerate.Append("QueryRun", "Table").AppendLine("  queryRun;");

            CodeGenerate.AppendLine("");

            CodeGenerate.AppendLine($"qBDS     = query.addDataSource(tablenum({Table2}));");
            foreach (RelationDef df in RelationsList)
            {
                CodeGenerate.AppendLine($"qBR = qBDS.addRange(fieldNum({Table2}, {df.Field2}));");
                string valueF1 = df.Field1Fixed ? "" : $"{Table1Var}."; 
                CodeGenerate.AppendLine($"qBR.value(SysQuery::value({valueF1}{df.Field1}));");

            }

            CodeGenerate.AppendLine($"queryRun = new QueryRun(query);");
            CodeGenerate.AppendLine("");
            CodeGenerate.AppendLine("while (queryRun.next())");
            CodeGenerate.BeginBlock();
            CodeGenerate.AppendLine($"{Table2Var} = queryRun.get(tablenum({Table2}));");
            CodeGenerate.EndBlock();
            CodeGenerate.AppendLine("");
        }

        public string RunPreview()
        {           
            GenerateMethods();
            return CodeGenerate.GetResult();
        }
    }
}

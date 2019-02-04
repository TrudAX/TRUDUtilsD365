using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using TRUDUtilsD365.Kernel;

namespace TRUDUtilsD365.AddTableFindMethod
{
    public class AxTableFieldParm
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsMandatory { get; set; }

        public int Position { get; set; }
    }

    public class AddTableFindMethodParms
    {
        public List<AxTableFieldParm> Fields;
        public string VarName { get; set; } = "";
        public string TableName { get; set; }
        public string FieldsStr { get; set; }
        public string MethodName { get; set; } = "find";

        public bool IsCreateFind { get; set; } = true;
        public bool IsCreateFindRecId { get; set; }
        public bool IsCreateExists { get; set; }

        public bool IsTestMode { get; set; }

       

        public string GenerateResult()
        {
            int longestNameLength = (from x in Fields select x.FieldName.Length).Max();
            int longestTypeLength = (from x in Fields select x.FieldType.Length).Max();
            longestTypeLength = Math.Max("boolean".Length, longestTypeLength);
            longestTypeLength++;
            longestNameLength++;

            CodeGenerateHelper generateHelper = new CodeGenerateHelper {IndentGlobalValue = 4};
            

            generateHelper.AddColumnAlignInt("Type", longestTypeLength);
            generateHelper.AddColumnAlignInt("FieldName", longestNameLength);

            if (VarName == "")
            {            
                VarName = AxHelper.PrettyName(TableName);
            }

            string mandatoryFields;

            if (IsCreateFind)
            {
                generateHelper.IndentSetValue(0);
                generateHelper.Append($"public static {TableName} find(");
                generateHelper.IndentSetAsCurrentPos();

                // build args and mandatory fields list
                mandatoryFields = "";
                bool isFirst = true;
                foreach (AxTableFieldParm df in Fields.OrderBy(x => x.Position))
                {
                    if (df.IsMandatory || df.FieldName == "RecId")
                    {
                        if (mandatoryFields.Length > 0) mandatoryFields += " && ";
                        mandatoryFields += "_" + AxHelper.PrettyName(df.FieldName);
                    }

                    if (!isFirst) generateHelper.AppendLine(",");
                    generateHelper.Append(df.FieldType, "Type");
                    generateHelper.Append($" _{AxHelper.PrettyName(df.FieldName)}");
                    isFirst = false;
                }

                generateHelper.AppendLine(",");
                generateHelper.Append("boolean", "Type");
                generateHelper.AppendLine(" _forUpdate = false)");

                //build method header
                generateHelper.IndentSetValue(0);
                generateHelper.AppendLine("{");
                generateHelper.IndentIncrease();

                generateHelper.AppendLine(TableName + " " + VarName + ";");
                generateHelper.AppendLine(";");

                //check for mandatory fields
                if (mandatoryFields != "")
                {
                    generateHelper.AppendLine("if (" + mandatoryFields + ")");
                    generateHelper.AppendLine("{");
                    generateHelper.IndentIncrease();
                }

                //selectForUpdate
                generateHelper.AppendLine(VarName + ".selectForUpdate(_forUpdate);");
                generateHelper.AppendLine("");

                //build select query
                generateHelper.AppendLine("select firstonly " + VarName);
                generateHelper.Append("    where ");
                generateHelper.IndentSetAsCurrentPos();

                isFirst = true;
                foreach (AxTableFieldParm df in Fields.OrderBy(x => x.Position))
                {
                    if (!isFirst) generateHelper.AppendLine(" && ");
                    generateHelper.Append(VarName + ".");
                    generateHelper.Append(df.FieldName, "FieldName");

                    generateHelper.Append(" == _" + AxHelper.PrettyName(df.FieldName));
                    isFirst = false;
                }

                generateHelper.IndentRestorePrev();
                generateHelper.AppendLine(";");

                //footer
                if (mandatoryFields != "")
                {
                    generateHelper.IndentDecrease();
                    generateHelper.AppendLine("}");
                }

                generateHelper.AppendLine("");
                generateHelper.AppendLine("return " + VarName + ";");
                generateHelper.IndentDecrease();

                generateHelper.AppendLine("}");
            }

            if (IsCreateFindRecId)
            {
                generateHelper.IndentSetValue(0);

                generateHelper.AppendLine("");
                generateHelper.AppendLine($"public static {TableName} findRecId(RefRecId _recId,  _forUpdate = false)");

                //build method header
                generateHelper.AppendLine("{");
                generateHelper.IndentIncrease();
                generateHelper.AppendLine(TableName + " " + VarName + ";");
                generateHelper.AppendLine(";");

                generateHelper.AppendLine("if (_recId)");
                generateHelper.AppendLine("{");
                generateHelper.IndentIncrease();

                //selectForUpdate
                generateHelper.AppendLine(VarName + ".selectForUpdate(_forUpdate);");
                generateHelper.AppendLine("");

                //build select query
                generateHelper.AppendLine("select firstonly " + VarName);
                generateHelper.AppendLine("    where " + VarName + ".RecId == _recId;");
                generateHelper.IndentDecrease();
                generateHelper.AppendLine("}");
                generateHelper.AppendLine("");
                generateHelper.AppendLine("return " + VarName + ";");
                generateHelper.IndentDecrease();

                generateHelper.AppendLine("}");
            }

            if (IsCreateExists)
            {
                generateHelper.IndentSetValue(0);
                generateHelper.AppendLine("");

                generateHelper.Append("public static boolean exists(");
                generateHelper.IndentSetAsCurrentPos();

                // build args and mandatory fields list
                mandatoryFields = "";
                bool isFirst = true;
                foreach (AxTableFieldParm df in Fields.OrderBy(x => x.Position))
                {
                    if (df.IsMandatory || df.FieldName == "RecId")
                    {
                        if (mandatoryFields.Length > 0) mandatoryFields += " && ";
                        mandatoryFields += "_" + AxHelper.PrettyName(df.FieldName);
                    }

                    if (!isFirst) generateHelper.AppendLine(",");
                    generateHelper.Append(df.FieldType, "Type");
                    generateHelper.Append($" _{AxHelper.PrettyName(df.FieldName)}");
                    isFirst = false;
                }

                generateHelper.AppendLine(")");

                //build method header
                generateHelper.IndentSetValue(0);
                generateHelper.AppendLine("{");
                generateHelper.IndentIncrease();

                generateHelper.AppendLine("boolean res;");
                generateHelper.AppendLine(";");

                //check for mandatory fields
                if (mandatoryFields != "")
                {
                    generateHelper.AppendLine("if (" + mandatoryFields + ")");
                    generateHelper.AppendLine("{");
                    generateHelper.IndentIncrease();
                }


                //build select query
                generateHelper.AppendLine("res = (select firstonly RecId from " + TableName);
                generateHelper.Append("        where ");
                generateHelper.IndentSetAsCurrentPos();

                isFirst = true;
                foreach (AxTableFieldParm df in Fields.OrderBy(x => x.Position))
                {
                    if (!isFirst) generateHelper.AppendLine(" && ");
                    generateHelper.Append(TableName + ".");
                    generateHelper.Append(df.FieldName, "FieldName");

                    generateHelper.Append(" == _" + AxHelper.PrettyName(df.FieldName));
                    isFirst = false;
                }

                generateHelper.IndentRestorePrev();
                generateHelper.AppendLine(").RecId != 0;");

                //footer
                if (mandatoryFields != "")
                {
                    generateHelper.IndentDecrease();
                    generateHelper.AppendLine("}");
                }

                generateHelper.AppendLine("");
                generateHelper.AppendLine("return res;");
                generateHelper.IndentDecrease();

                generateHelper.AppendLine("}");
            }

            var methodText = generateHelper.ResultString.ToString();

            return methodText;
        }

        public void InitFromSelectedElement(AddinDesignerEventArgs e)
        {
            Fields = new List<AxTableFieldParm>();
            FieldsStr = "";

            int curPos = 0;
            foreach (BaseField baseField in e.SelectedElements.OfType<BaseField>())
            {
                curPos++;
                AxTableFieldParm fieldParm = new AxTableFieldParm();
                fieldParm.FieldName    = baseField.Name;
                fieldParm.FieldType    = baseField.ExtendedDataType;
                fieldParm.IsMandatory  = baseField.Mandatory == NoYes.Yes ? true : false;
                fieldParm.Position     = curPos;
                if (fieldParm.FieldType == "")
                {
                    if (baseField is FieldEnum)
                    {
                        fieldParm.FieldType = (baseField as FieldEnum).EnumType;
                    }
                }

                Fields.Add(fieldParm);

                FieldsStr += fieldParm.FieldName + Environment.NewLine;
            }
            var field = (BaseField)e.SelectedElement;
            //AxTable axTable = (AxTable)field.Table.GetMetadataType();

            TableName = field.Table != null ? field.Table.GetMetadataType().Name : field.TableExtension?.GetMetadataType().Name;
            VarName = AxHelper.GetVarNameFromType(TableName);
        }

    }
}
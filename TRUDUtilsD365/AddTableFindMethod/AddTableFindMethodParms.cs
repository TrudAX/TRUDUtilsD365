using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRUDUtilsD365.AddTableFindMethod
{
    public class CodeGenerateHelper
    {
        private readonly Dictionary<string, int> _columnAlignMap =
            new Dictionary<string, int>();

        private int    _currentIndent;
        private string _currentIndentStr = "";
        private int    _currentLinePos;
        private bool   _isIndentAppended;
        private int    _savedIndent;

        public StringBuilder ResultString = new StringBuilder();

        public void IndentSetValue(int value)
        {
            _currentIndent = value;
            _currentIndentStr = new string(' ', _currentIndent);
        }

        public void IndentIncrease()
        {
            _currentIndent += 4;
            _currentIndentStr = new string(' ', _currentIndent);
        }

        public void IndentDecrease()
        {
            _currentIndent -= 4;
            _currentIndent = Math.Max(_currentIndent, 0);
            _currentIndentStr = new string(' ', _currentIndent);
        }

        public void IndentRestorePrev()
        {
            IndentSetValue(_savedIndent);
        }

        public void IndentSetAsCurrentPos()
        {
            _savedIndent = _currentIndent;
            _currentIndent = _currentLinePos;
            _currentIndentStr = new string(' ', _currentIndent);
        }

        public void AppendLine(string line)
        {
            ResultString.AppendLine((_isIndentAppended ? "" : _currentIndentStr) + line);
            _currentLinePos = _currentIndent;

            _isIndentAppended = false;
        }

        public void Append(string line, string format = "")
        {
            string textToAppend = (_isIndentAppended ? "" : _currentIndentStr) +
                                  (format == "" ? line : GetFormattedValue(line, format));
            ResultString.Append(textToAppend);
            _currentLinePos = textToAppend.Length;
            _isIndentAppended = true;
        }

        public string GetFormattedValue(string value, string formatStr)
        {
            return value.PadRight(_columnAlignMap[formatStr]);
        }

        public void AddColumnAlignInt(string name, int value)
        {
            if (!_columnAlignMap.ContainsKey(name)) _columnAlignMap.Add(name, value);
            if (_columnAlignMap[name] < value) _columnAlignMap[name] = value;
        }

        public void AddColumnAlign(string name, string value)
        {
            int keyValue = value.Length;
            AddColumnAlignInt(name, keyValue);
        }
    }

    public class AxTableField
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsMandatory { get; set; }

        public int Position { get; set; }
    }

    public class AddTableFindMethodParms
    {
        public List<AxTableField> Fields;
        public string TableName { get; set; }
        public string FieldsStr { get; set; }
        public string MethodName { get; set; } = "find";

        public bool IsCreateFind { get; set; } = true;
        public bool IsCreateFindRecId { get; set; }
        public bool IsCreateExists { get; set; }

        public bool IsTestMode { get; set; }

        public static string PrettyName(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            return input.First().ToString().ToLower() + input.Substring(1);
        }

        public string GenerateResult()
        {
            int longestNameLength = (from x in Fields select x.FieldName.Length).Max();
            int longestTypeLength = (from x in Fields select x.FieldType.Length).Max();
            longestTypeLength = Math.Max("boolean".Length, longestTypeLength);

            CodeGenerateHelper generateHelper = new CodeGenerateHelper();

            generateHelper.AddColumnAlignInt("Type", longestTypeLength);
            generateHelper.AddColumnAlignInt("FieldName", longestNameLength);


            string varName = PrettyName(TableName);
            string mandatoryFields;

            if (IsCreateFind)
            {
                generateHelper.Append($"public static {TableName} find(");
                generateHelper.IndentSetAsCurrentPos();

                // build args and mandatory fields list
                mandatoryFields = "";
                bool isFirst = true;
                foreach (AxTableField df in Fields.OrderBy(x => x.Position))
                {
                    if (df.IsMandatory || df.FieldName == "RecId")
                    {
                        if (mandatoryFields.Length > 0) mandatoryFields += " && ";
                        mandatoryFields += "_" + PrettyName(df.FieldName);
                    }

                    if (!isFirst) generateHelper.AppendLine(",");
                    generateHelper.Append(df.FieldType, "Type");
                    generateHelper.Append($" _{PrettyName(df.FieldName)}");
                    isFirst = false;
                }

                generateHelper.AppendLine(",");
                generateHelper.Append("boolean", "Type");
                generateHelper.AppendLine(" _forUpdate = false)");

                //build method header
                generateHelper.IndentSetValue(0);
                generateHelper.AppendLine("{");
                generateHelper.IndentIncrease();

                generateHelper.AppendLine(TableName + " " + varName + ";");
                generateHelper.AppendLine(";");

                //check for mandatory fields
                if (mandatoryFields != "")
                {
                    generateHelper.AppendLine("if (" + mandatoryFields + ")");
                    generateHelper.AppendLine("{");
                    generateHelper.IndentIncrease();
                }

                //selectForUpdate
                generateHelper.AppendLine(varName + ".selectForUpdate(_forUpdate);");
                generateHelper.AppendLine("");

                //build select query
                generateHelper.AppendLine("select firstonly " + varName);
                generateHelper.Append("    where ");
                generateHelper.IndentSetAsCurrentPos();

                isFirst = true;
                foreach (AxTableField df in Fields.OrderBy(x => x.Position))
                {
                    if (!isFirst) generateHelper.AppendLine(" && ");
                    generateHelper.Append(varName + ".");
                    generateHelper.Append(df.FieldName, "FieldName");

                    generateHelper.Append(" == _" + PrettyName(df.FieldName));
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
                generateHelper.AppendLine("return " + varName + ";");
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
                generateHelper.AppendLine(TableName + " " + varName + ";");
                generateHelper.AppendLine(";");

                generateHelper.AppendLine("if (_recId)");
                generateHelper.AppendLine("{");
                generateHelper.IndentIncrease();

                //selectForUpdate
                generateHelper.AppendLine(varName + ".selectForUpdate(_forUpdate);");
                generateHelper.AppendLine("");

                //build select query
                generateHelper.AppendLine("select firstonly " + varName);
                generateHelper.AppendLine("    where " + varName + ".RecId == _recId;");
                generateHelper.IndentDecrease();
                generateHelper.AppendLine("}");
                generateHelper.AppendLine("");
                generateHelper.AppendLine("return " + varName + ";");
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
                foreach (AxTableField df in Fields.OrderBy(x => x.Position))
                {
                    if (df.IsMandatory || df.FieldName == "RecId")
                    {
                        if (mandatoryFields.Length > 0) mandatoryFields += " && ";
                        mandatoryFields += "_" + PrettyName(df.FieldName);
                    }

                    if (!isFirst) generateHelper.AppendLine(",");
                    generateHelper.Append(df.FieldType, "Type");
                    generateHelper.Append($" _{PrettyName(df.FieldName)}");
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
                foreach (AxTableField df in Fields.OrderBy(x => x.Position))
                {
                    if (!isFirst) generateHelper.AppendLine(" && ");
                    generateHelper.Append(TableName + ".");
                    generateHelper.Append(df.FieldName, "FieldName");

                    generateHelper.Append(" == _" + PrettyName(df.FieldName));
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
    }
}
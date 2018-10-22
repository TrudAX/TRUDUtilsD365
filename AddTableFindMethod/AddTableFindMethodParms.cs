using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTableFindMethod
{
    public class CodeGenerateHelper
    {
        int     currentIndent       = 0;
        String  currentIndentStr    = "";

        int     currentLinePos      = 0;
        bool    isIndentAppended    = false;

        int     savedIndent;

        Dictionary<string, int> columnAllignMap =
            new Dictionary<string, int>();

        public StringBuilder resultString = new StringBuilder();

        public void indentSetValue(int _value)
        {
            currentIndent = _value;
            currentIndentStr = new String(' ', currentIndent);
        }

        public void indentIncrease()
        {
            currentIndent += 4;
            currentIndentStr = new String(' ', currentIndent);
        }
        public void indentDecrease()
        {
            currentIndent -= 4;
            currentIndent = Math.Max(currentIndent, 0);
            currentIndentStr = new String(' ', currentIndent);
        }
        public void indentRestorePrev()
        {
            this.indentSetValue(savedIndent);
        }
        public void indentSetAsCurrentPos()
        {
            savedIndent         = currentIndent;
            currentIndent       = currentLinePos;
            currentIndentStr    = new String(' ', currentIndent);
        }

        public void appendLine(String _line)
        {
            resultString.AppendLine((isIndentAppended ? "" : currentIndentStr) + _line);
            currentLinePos = currentIndent;

            isIndentAppended = false;
        }
        public void append(String _line, string  _format = "")
        {
            String textToAppend = (isIndentAppended ? "" : currentIndentStr) + (_format == "" ? _line : this.getFormatedValue(_line, _format));
            resultString.Append(textToAppend);
            currentLinePos = textToAppend.Length;
            isIndentAppended = true;
        }

        public string getFormatedValue(String _value, string _formatStr)
        {
            return _value.PadRight(columnAllignMap[_formatStr]);
        }

        public void addColumnAllignInt(string _name, int _value)
        {
            if (!columnAllignMap.ContainsKey(_name))
            {
                columnAllignMap.Add(_name, _value);
            }
            if (columnAllignMap[_name] < _value)
            {
                columnAllignMap[_name] = _value;
            }

        }
        public void addColumnAllign(string _name, String _value)
        {
            int keyValue = _value.Length;
            this.addColumnAllignInt(_name, keyValue);           
        }
    }
    public class AxTableField
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool   IsMandatory { get; set; }

        public int Position { get; set; }

    }
    public class AddTableFindMethodParms
    {
        public string TableName { get; set; }
        public string FieldsStr { get; set; }
        public string MethodName { get; set; } = "find";

        public bool IsCreateFind { get; set; } = true;
        public bool IsCreateFindRecId { get; set; }
        public bool IsCreateExists { get; set; }

        public List<AxTableField> fields;

        public bool IsTestMode { get; set; }

        public static string prettyName(string _input)
        {
            if (String.IsNullOrEmpty(_input))
            {
                return "";
            }
            return _input.First().ToString().ToLower() + _input.Substring(1);
            
        }

        public string generateResult()
        {
            string methodText = "";

            

            int longestNameLength = (from x in fields select x.FieldName.Length).Max();
            int longestTypeLength = (from x in fields select x.FieldType.Length).Max();
            longestTypeLength = Math.Max("boolean".Length, longestTypeLength);

            CodeGenerateHelper generateHelper = new CodeGenerateHelper();

            generateHelper.addColumnAllignInt("Type",      longestTypeLength);
            generateHelper.addColumnAllignInt("FieldName", longestNameLength);


            string varName = AddTableFindMethodParms.prettyName(this.TableName);
            string mandatoryFields = "";

            if (this.IsCreateFind)
            {
                generateHelper.append($"public static {this.TableName} find(");
                generateHelper.indentSetAsCurrentPos();

                bool isFirst = true;

                // build args and mandatory fields list
                mandatoryFields = "";
                foreach (AxTableField df in fields.OrderBy(x=>x.Position))
                {
                    if (df.IsMandatory || df.FieldName == "RecId")
                    {
                        if (mandatoryFields.Length > 0)
                        {
                            mandatoryFields += " && ";
                        }
                        mandatoryFields += "_" + prettyName(df.FieldName);
                    }
                    if (!isFirst)
                    {
                        generateHelper.appendLine(",");
                    }
                    generateHelper.append(df.FieldType, "Type");
                    generateHelper.append(String.Format(" _{0}", prettyName(df.FieldName)));

                    //methodText += String.Format("{0} _{1}", df.FieldType.PadRight(longestTypeLength), prettyName(df.FieldName));
                    isFirst = false;
                }
                generateHelper.appendLine(",");
                generateHelper.append("boolean", "Type");
                generateHelper.appendLine(" _forUpdate = false)");

                //build method header
                generateHelper.indentSetValue(0);
                generateHelper.appendLine("{");
                generateHelper.indentIncrease();

                generateHelper.appendLine(this.TableName + " " + varName + ";");
                generateHelper.appendLine(";");

                //check for mandatory fields
                if (mandatoryFields != "")
                {
                    generateHelper.appendLine("if (" + mandatoryFields + ")");
                    generateHelper.appendLine("{");
                    generateHelper.indentIncrease();
                }

                //selectForUpdate
                generateHelper.appendLine(varName + ".selectForUpdate(_forUpdate);");
                generateHelper.appendLine("");

                //build select query
                generateHelper.appendLine("select firstonly " + varName);
                generateHelper.append("    where ");
                generateHelper.indentSetAsCurrentPos();

                isFirst = true;
                foreach (AxTableField df in fields.OrderBy(x => x.Position))
                {
                    if (!isFirst)
                    {
                        generateHelper.appendLine(" && ");
                    }
                    generateHelper.append(varName + ".");
                    generateHelper.append(df.FieldName, "FieldName");

                    generateHelper.append(" == _" + prettyName(df.FieldName));
                    isFirst = false;
                }
                generateHelper.indentRestorePrev();
                generateHelper.appendLine(";");

                //footer
                if (mandatoryFields != "")
                {
                    generateHelper.indentDecrease();
                    generateHelper.appendLine("}");

                }
                generateHelper.appendLine("");
                generateHelper.appendLine("return " + varName + ";");
                generateHelper.indentDecrease();

                generateHelper.appendLine("}");

                methodText += generateHelper.resultString.ToString();

            }
            if (this.IsCreateFindRecId)
            {
                methodText += "findRecId\r\n";
            }
            if (this.IsCreateExists)
            {
                methodText += "exists\r\n";
            }

            return methodText;
        }
    }
}

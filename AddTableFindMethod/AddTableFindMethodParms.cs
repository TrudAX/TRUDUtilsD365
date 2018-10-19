using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTableFindMethod
{
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

            methodText += $"maxTypeLength= {longestTypeLength} maxFieldLength = {longestNameLength} \r\n";

            string varName = AddTableFindMethodParms.prettyName(this.TableName);
            string indent;
            string mandatoryFields = "";

            if (this.IsCreateFind)
            {
                methodText += $"public static {this.TableName} find(";              
                indent = new String(' ', methodText.Length);

                bool isFirst = true;

                // build args and mandatory fields list
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
                        methodText += String.Format(",\n{0}", indent);
                    }
                    methodText += String.Format("{0} _{1}", df.FieldType.PadRight(longestTypeLength), prettyName(df.FieldName));
                    isFirst = false;
                }


                //build method header
                methodText += strfmt(',\n%1boolean%2_forUpdate = false)\n{\n', indent, strrep(' ', 1 + longestTypeLength - strlen('boolean')));
                indent = '    ';
                methodText += indent + dt.name() + ' ' + varName + ';\n';
                methodText += indent + '\n';

                //check for mandatory fields
                if (mandatoryFields)
                {
                    methodText += indent + 'if (' + mandatoryFields + ')\n';
                    methodText += indent + '{\n';
                    indent += '    ';
                }

                //selectForUpdate
                methodText += indent + varName + '.selectForUpdate(_forUpdate);\n\n';

                //build select query
                methodText += indent + 'select firstonly ' + varname + '\n';
                methodText += indent + '    where ';
                for (i = 1; i <= di.numberOfFields(); ++i)
                {
                    df = new DictField(dt.id(), di.field(i));
                    if (i != 1)
                    {
                        methodText += '\n' + indent + '       && ';
                    }
                    methodText += varName + '.' + df.name() + strrep(' ', longestNameLength - strlen(df.name())) + ' == _' + prettyName(df.name());
                }
                methodText += ';\n';

                //footer
                if (mandatoryFields)
                {
                    indent = substr(indent, 1, strlen(indent) - 4);
                    methodText += indent + '}\n';
                }
                methodText += '\n';
                methodText += indent + 'return ' + varName + ';\n';

                methodText += '}';

                res += "find\r\n";
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

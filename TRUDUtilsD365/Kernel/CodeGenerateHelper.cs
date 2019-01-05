using System;
using System.Collections.Generic;
using System.Text;

namespace TRUDUtilsD365.Kernel
{
    public enum ClassMethodType
    {
        Method,
        ClassDeclaration,
        Static
    }
    public class CodeGenerateHelper
    {
        private readonly Dictionary<string, int> _columnAlignMap =
            new Dictionary<string, int>();

        private int _currentIndent;
        private string _currentIndentStr = "";
        private int _currentLinePos;
        private bool _isIndentAppended;
        private int _savedIndent;

        public string MethodName = "";
        public ClassMethodType MethodType = ClassMethodType.Method;

        public void SetMethodName(string methodName, ClassMethodType methodType = ClassMethodType.Method)
        {
            MethodName = methodName;
            MethodType = methodType;
        }

        public int IndentGlobalValue { get; set; } = 0;

        public StringBuilder ResultString = new StringBuilder();

        public void IndentSetValue(int value)
        {
            _currentIndent = value;
            _currentIndentStr = new string(' ', _currentIndent + IndentGlobalValue);
        }

        public void IndentIncrease()
        {
            _currentIndent += 4;
            _currentIndentStr = new string(' ', _currentIndent + IndentGlobalValue);
        }

        public void IndentDecrease()
        {
            _currentIndent -= 4;
            _currentIndent = Math.Max(_currentIndent, 0);
            _currentIndentStr = new string(' ', _currentIndent + IndentGlobalValue);
        }

        public void IndentRestorePrev()
        {
            IndentSetValue(_savedIndent);
        }

        public void IndentSetAsCurrentPos()
        {
            _savedIndent = _currentIndent;
            IndentSetValue(_currentLinePos - IndentGlobalValue);
        }

        public CodeGenerateHelper AppendLine(string line)
        {
            ResultString.AppendLine((_isIndentAppended ? "" : _currentIndentStr) + line);
            _currentLinePos = _currentIndent;

            _isIndentAppended = false;
            return this;
        }

        public CodeGenerateHelper Append(string line, string format = "")
        {
            string textToAppend = (_isIndentAppended ? "" : _currentIndentStr) +
                                  (format == "" ? line : GetFormattedValue(line, format));
            ResultString.Append(textToAppend);
            _currentLinePos = textToAppend.Length;
            _isIndentAppended = true;
            return this;
        }

        public string GetFormattedValue(string value, string formatStr)
        {
            return value.PadRight(_columnAlignMap[formatStr]);
        }
        public string GetResult()
        {
            return ResultString.ToString();
        }

        public void ClearResult()
        {
            ResultString.Clear();
        }

        public void BeginBlock()
        {
            this.AppendLine("{").IndentIncrease();
        }
        public void EndBlock()
        {
            this.IndentDecrease();
            this.AppendLine("}");
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
}

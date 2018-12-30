using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRUDUtilsD365.Kernel
{
    public class SnippetsParms
    {
        public string ResultText { get; set; } = "";
        public string Description { get; set; } = "";
        public string Parameters { get; set; } = "";
        public string Values { get; set; } = "";
        public string SnippetName { get; set; } = "";
        public string ValuesSeparator { get; set; } = "|";
        public Boolean IsFieldsSeparatorVisible { get; set; } = false;

        public Boolean IsCreateButtonVisible { get; set; } = false;


        public void AddParametersValue(string parmName, string parmValue)
        {
            if (String.IsNullOrWhiteSpace(Parameters))
            {
                Parameters += parmName;
                Values     += parmValue;
            }
            else
            {
                Parameters += Environment.NewLine + parmName;
                Values     += Environment.NewLine + parmValue;
            }
        }
    }
}

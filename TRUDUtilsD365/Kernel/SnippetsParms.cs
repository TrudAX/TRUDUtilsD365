using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.Kernel
{
    public interface ISnippetPreviewAction
    {
        string RunPreview();

        void InitFromSnippetsParms(SnippetsParms snippetsParms);

    }
    public interface ISnippetCreateAction : ISnippetPreviewAction
    {
        void RunCreateLog();
        void DisplayLog();
    }

    public abstract  class SnippedCreateAction : ISnippetCreateAction
    {
        private string _logString;

        public abstract string RunPreview();
        public abstract void RunCreate();

        public abstract void InitFromSnippetsParms(SnippetsParms snippetsParms);

        public virtual void RunCreateLog()
        {
            _logString = "";
            RunCreate();
        }

        public void AddLog(string logLocal)
        {
            _logString += logLocal;
        }

        public void DisplayLog()
        {
            if (!String.IsNullOrWhiteSpace(_logString))
            {
                CoreUtility.DisplayInfo($"The following element(s)({_logString}) created and added to the project");
            }
        }
    }
    public class SnippetsParms
    {
        private string NewLineSeparator = Environment.NewLine;

        public string ResultText { get; set; } = "";
        public string Description { get; set; } = "";
        public string Parameters { get; set; } = "";
        public string Values { get; set; } = "";
        public string SnippetName { get; set; } = "";
        public string ValuesSeparator { get; set; } = "|";
        public Boolean IsFieldsSeparatorVisible { get; set; } = false;

        public Boolean IsCreateButtonVisible { get; set; } = false;

        public ISnippetPreviewAction PreviewAction { get; set; }
        public ISnippetCreateAction CreateAction { get; set; }


        protected List<string> ParmsPositionList;
        protected Dictionary<string, string> ParmsValuesMap;

        public void AddParametersValue(string parmName, string parmValue)
        {            
            if (String.IsNullOrWhiteSpace(Parameters))
            {
                Parameters += parmName;
                Values     += parmValue;
            }
            else
            {
                Parameters += NewLineSeparator + parmName;
                Values     += NewLineSeparator + parmValue;
            }
            if (ParmsPositionList == null)
            {
                ParmsPositionList = new List<string>();
            }
            ParmsPositionList.Add(parmName);
        }

        public void ParseValues()
        {
            ParmsValuesMap = new Dictionary<string, string>();

            List<string> listImp = new List<string>(
                Values.Split(new[] { NewLineSeparator },
                    StringSplitOptions.None));

            for (int i = 0; i < ParmsPositionList.Count; i++)
            {
                if (!String.IsNullOrWhiteSpace(listImp[i]))
                {
                    ParmsValuesMap.Add(ParmsPositionList[i], listImp[i].Trim());
                }
                else
                {
                    ParmsValuesMap.Add(ParmsPositionList[i], "");
                }
            }
            //add last rows to the last parm
            string lastParmName = ParmsPositionList.Last();
            if (listImp.Count > ParmsPositionList.Count)
            {
                for (int i = ParmsPositionList.Count; i < listImp.Count; i++)
                {
                    ParmsValuesMap[lastParmName] += NewLineSeparator + listImp[i].Trim();
                }
            }
        }

        public string GetParmStr(string parmName)
        {
            return ParmsValuesMap[parmName];
        }

        public Boolean GetParmBool(string parmName)
        {
            return ParmsValuesMap[parmName].Equals("y", StringComparison.OrdinalIgnoreCase);
        }

        public List<List<string>> GetParmListSeparated(string parmName)
        {
            List<string> listImp = new List<string>(
                GetParmStr(parmName).Split(new[] { NewLineSeparator }, 
                    StringSplitOptions.None));

            List < List < string >> resList = new List<List<string>>();

            foreach (string lineStr in listImp)
            {
                if (String.IsNullOrWhiteSpace(lineStr))
                {
                    break;
                }
                List<string> rowListOrig = new List<string>(
                    lineStr.Split(new[] { ValuesSeparator }, 
                        StringSplitOptions.None));

                List<string> rowListNew = new List<string>();

                foreach (string rowParmStr in rowListOrig)
                {
                    rowListNew.Add(rowParmStr.Trim());
                }
                resList.Add(rowListNew);
            }

            return resList;
        }
    }
}

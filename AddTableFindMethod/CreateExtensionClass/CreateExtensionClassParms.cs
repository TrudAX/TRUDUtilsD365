using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRUDUtilsD365.CreateExtensionClass
{
    public enum ExtensionClassType
    {
        Extension ,
        EventHandler
    }
    public class CreateExtensionClassParms
    {
        public string Prefix { get; set; }
    
        public string ElementName { get; set; }
        public string ElementType { get; set; }

        public ExtensionClassType ClassType { get; set; }

        public string ResultClassName { get; set; }

        public void calcResultName()
        {
            string res = "";
            res += this.ElementName;
            if (this.ElementType == "IForm")
            {
                res += "Form";
            }
            res += this.Prefix;
            switch(this.ClassType)
            {
                case ExtensionClassType.Extension:
                    res += "_Extension";
                    break;
                case ExtensionClassType.EventHandler:
                    res += "_EventHandler";
                    break;
            }
           
            this.ResultClassName = res;
        }

    }
}

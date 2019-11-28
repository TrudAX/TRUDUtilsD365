using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRUDUtilsD365.Kernel
{
    public enum ExtensionClassObject
    {
        Form,
        Table,
        Class,
        FormDataField,
        FormDataSource,
        FormControl,
        DataEntityView,
        View
    }
    public class ExtensionNameTemplate
    {
        public ExtensionClassObject ExtensionObject { get; set; }
        public String ExtensionTemplate { get; set; }
        public string EventHandlerTemplate { get; set; }
    }

    class AxModelSettings
    {
        public String ModelPrefix { get; set; } = "";

        public Dictionary<ExtensionClassObject, ExtensionNameTemplate> ExtensionNameTemplateList;

        //public List<ExtensionNameTemplate> ExtensionNameTemplateList = new List<ExtensionNameTemplate>();
    }
}

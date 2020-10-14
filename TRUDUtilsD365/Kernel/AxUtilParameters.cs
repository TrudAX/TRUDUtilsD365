using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;

namespace TRUDUtilsD365.Kernel
{
    public enum ExtensionClassType
    {        
        Class,
        Table,
        DataEntityView,
        View,
        Map,
        Form,
        FormDataField,
        FormDataSource,
        FormControl
    }
    public enum ExtensionClassModeType
    {
        Extension,
        EventHandler
    }
    public class ExtensionNameTemplate
    {
        public ExtensionClassType ExtensionType { get; set; }
        public String ExtensionTemplate { get; set; }
        public string EventHandlerTemplate { get; set; }
    }

    [DataContract]
    public class AxModelSettings 
    {
        [DataMember]
        public String ModelPrefix { get; set; } = "";

        [DataMember]
        public Dictionary<ExtensionClassType, ExtensionNameTemplate> ExtensionNameTemplateList { get; set; }

        //public List<ExtensionNameTemplate> ExtensionNameTemplateList = new List<ExtensionNameTemplate>();
    }
}

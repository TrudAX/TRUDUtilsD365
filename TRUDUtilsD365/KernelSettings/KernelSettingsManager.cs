using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRUDUtilsD365.Kernel;

namespace TRUDUtilsD365.KernelSettings
{
    class KernelSettingsManager
    {
        const string PrefixTemplateName        = "$Prefix$";
        const string MainElementTemplateName   = "$MainObject$";
        const string SubElementTemplateName    = "$SubObject$";

        private AxModelSettings AxModelSettings;

        private KernelSettingsStorage _kernelSettingsStorage = new KernelSettingsStorage();

        public void LoadSettingsOrDefault()
        {
            AxModelSettings = _kernelSettingsStorage.LoadSettings();

            if (String.IsNullOrEmpty(AxModelSettings.ModelPrefix))
            {
                AxModelSettings.ModelPrefix = "TST";
            }

            if (AxModelSettings.ExtensionNameTemplateList == null)
            {
                AxModelSettings.ExtensionNameTemplateList = new Dictionary<ExtensionClassObject, ExtensionNameTemplate>();
            }

            foreach (ExtensionClassObject currentObject in Enum.GetValues(typeof(ExtensionClassObject)))
            {
                ExtensionNameTemplate nameTemplate;
                if (AxModelSettings.ExtensionNameTemplateList.ContainsKey(currentObject))
                {
                    nameTemplate = AxModelSettings.ExtensionNameTemplateList[currentObject];
                }
                else
                {
                    nameTemplate = new ExtensionNameTemplate();
                }

                nameTemplate.ExtensionObject = currentObject;

                if (string.IsNullOrEmpty(nameTemplate.ExtensionTemplate))
                {
                    switch (currentObject)
                    {
                        case ExtensionClassObject.Form:
                            nameTemplate.ExtensionTemplate = MainElementTemplateName + " + " + "Form " + PrefixTemplateName + " + _Extension";
                            break;
                        case ExtensionClassObject.FormDataField:
                        case ExtensionClassObject.FormDataSource:
                        case ExtensionClassObject.FormControl:
                            nameTemplate.ExtensionTemplate = MainElementTemplateName + " + " + "Form " + PrefixTemplateName + "_"+ SubElementTemplateName + " + _Extension";
                            break;
                        default:
                            nameTemplate.ExtensionTemplate = MainElementTemplateName + " + " +  PrefixTemplateName + " + _Extension";
                            break;
                    }
                }

                if (string.IsNullOrEmpty(nameTemplate.EventHandlerTemplate))
                {
                    switch (currentObject)
                    {
                        case ExtensionClassObject.Form:
                        case ExtensionClassObject.FormDataField:
                        case ExtensionClassObject.FormDataSource:
                        case ExtensionClassObject.FormControl:
                            nameTemplate.EventHandlerTemplate = MainElementTemplateName + " + " + "Form " + PrefixTemplateName + " + _EventHandler";
                            break;
                        default:
                            nameTemplate.EventHandlerTemplate = MainElementTemplateName + " + " + PrefixTemplateName + " + _EventHandler";
                            break;
                    }
                }

                AxModelSettings.ExtensionNameTemplateList[currentObject] = nameTemplate;
            }

        }

        public string GetClassName(string TemplateString, string PrefixValue, string MainElementValue, string SubElementValue)
        {
            string ResultName = TemplateString;

            //String

            return ResultName;


        }
    }
}

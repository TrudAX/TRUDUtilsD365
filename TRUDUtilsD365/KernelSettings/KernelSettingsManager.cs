using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TRUDUtilsD365.Kernel;

namespace TRUDUtilsD365.KernelSettings
{
    public enum ExtensionTemplateDefaultScheme
    {
        Default,
        DefaultWithUnderscore
    }
    class KernelSettingsManager
    {
        const string PrefixTemplateName = "$Prefix$";
        const string MainElementTemplateName = "$MainObject$";
        const string SubElementTemplateName = "$SubObject$";

        private AxModelSettings AxModelSettings;

        private KernelSettingsStorage _kernelSettingsStorage = new KernelSettingsStorage();

        protected void InitMissingSettings()
        {
            if (String.IsNullOrEmpty(AxModelSettings.ModelPrefix))
            {
                AxModelSettings.ModelPrefix = "TST";
            }

            if (AxModelSettings.ExtensionNameTemplateList == null)
            {
                AxModelSettings.ExtensionNameTemplateList =
                    new Dictionary<ExtensionClassType, ExtensionNameTemplate>();
            }

            foreach (ExtensionClassType currentObject in Enum.GetValues(typeof(ExtensionClassType)))
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

                nameTemplate.ExtensionType = currentObject;

                if (string.IsNullOrEmpty(nameTemplate.ExtensionTemplate))
                {
                    switch (currentObject)
                    {
                        case ExtensionClassType.Form:
                            nameTemplate.ExtensionTemplate =
                                MainElementTemplateName + " + " + "Form + " + PrefixTemplateName + " + _Extension";
                            break;
                        case ExtensionClassType.FormDataField:
                        case ExtensionClassType.FormDataSource:
                            nameTemplate.ExtensionTemplate =
                                MainElementTemplateName + " + Form + " + PrefixTemplateName + "+ _ds + " +
                                SubElementTemplateName + " + _Extension";
                            break;
                        case ExtensionClassType.FormControl:
                            nameTemplate.ExtensionTemplate =
                                MainElementTemplateName + " + Form + " + PrefixTemplateName + "+ _c + " +
                                SubElementTemplateName + " + _Extension";
                            break;
                        default:
                            nameTemplate.ExtensionTemplate =
                                MainElementTemplateName + " + " + PrefixTemplateName + " + _Extension";
                            break;
                    }
                }

                if (string.IsNullOrEmpty(nameTemplate.EventHandlerTemplate))
                {
                    switch (currentObject)
                    {
                        case ExtensionClassType.Form:
                        case ExtensionClassType.FormDataField:
                        case ExtensionClassType.FormDataSource:
                        case ExtensionClassType.FormControl:
                            nameTemplate.EventHandlerTemplate =
                                MainElementTemplateName + " + " + "Form + " + PrefixTemplateName + " + _EventHandler";
                            break;
                        default:
                            nameTemplate.EventHandlerTemplate =
                                MainElementTemplateName + " + " + PrefixTemplateName + " + _EventHandler";
                            break;
                    }
                }

                AxModelSettings.ExtensionNameTemplateList[currentObject] = nameTemplate;
            }
        }

        public AxModelSettings GetAxModelSettings()
        {
            return AxModelSettings;
        }

        public void LoadSettings()
        {
            AxModelSettings = _kernelSettingsStorage.LoadSettings();

            InitMissingSettings();
        }
        public void LoadDefaultSettings(ExtensionTemplateDefaultScheme extensionTemplateDefaultScheme)
        {
            AxModelSettings = new AxModelSettings();
            InitMissingSettings();
            switch (extensionTemplateDefaultScheme)
            {
                case ExtensionTemplateDefaultScheme.DefaultWithUnderscore:
                    string templateStringControl;
                    templateStringControl =
                    @"TST
                    $MainObject$ + _ + $Prefix$ + _Extension
                    $MainObject$ + _ + $Prefix$ + _Extension
                    $MainObject$ + _ + $Prefix$ + _Extension
                    $MainObject$ + _ + $Prefix$ + _Extension
                    $MainObject$ + _ + $Prefix$ + _Extension
                    $MainObject$ + Form + _ + $Prefix$ + _Extension
                    $MainObject$ + Form + _ds + $Prefix$+ _ + $SubObject$ + _Extension
                    $MainObject$ + Form + _ds + $Prefix$+ _ + $SubObject$ + _Extension
                    $MainObject$ + Form + _c + $Prefix$+ _ + $SubObject$ + _Extension
                    $MainObject$ + _ + $Prefix$ + _EventHandler
                    $MainObject$ + _ + $Prefix$ + _EventHandler
                    $MainObject$ + _ + $Prefix$ + _EventHandler
                    $MainObject$ + _ + $Prefix$ + _EventHandler
                    $MainObject$ + _ + $Prefix$ + _EventHandler
                    $MainObject$ + Form + _ + $Prefix$ + _EventHandler
                    $MainObject$ + Form + _ + $Prefix$ + _EventHandler
                    $MainObject$ + Form + _ + $Prefix$ + _EventHandler
                    $MainObject$ + Form + _ + $Prefix$ + _EventHandler";

                    LoadSettingsFromFormControlData(templateStringControl);
                    break;
            }            
        }

        public string GetSettingsFilename()
        {
            return _kernelSettingsStorage.GetFilePath();
        }



        public void InitFormControlData(out string typeStringControl, out string templateStringControl)
        {
            StringBuilder typeBuilder = new StringBuilder();
            StringBuilder typeEventBuilder = new StringBuilder();
            StringBuilder templateBuilder = new StringBuilder();
            StringBuilder templateEventBuilder = new StringBuilder();
            typeBuilder.AppendLine("Prefix");
            templateBuilder.AppendLine(AxModelSettings.ModelPrefix);

            foreach (ExtensionClassType currentObject in Enum.GetValues(typeof(ExtensionClassType)))
            {
                ExtensionNameTemplate nameTemplate = AxModelSettings.ExtensionNameTemplateList[currentObject];
                typeBuilder.AppendLine($"{currentObject}");
                templateBuilder.AppendLine(nameTemplate.ExtensionTemplate);

                typeEventBuilder.AppendLine($"{currentObject} EventHandler");
                templateEventBuilder.AppendLine(nameTemplate.EventHandlerTemplate);
            }

            typeBuilder.Append(typeEventBuilder);
            templateBuilder.Append(templateEventBuilder);

            typeStringControl = typeBuilder.ToString();
            templateStringControl = templateBuilder.ToString();
        }

        public void LoadSettingsFromFormControlData(string templateStringControl)
        {
            List<string> listImp = new List<string>(
                templateStringControl.Split(new[] {Environment.NewLine},
                    StringSplitOptions.None));

            int enumLength = Enum.GetNames(typeof(ExtensionClassType)).Length;
            int currentPosition = 1;

            AxModelSettings.ModelPrefix = listImp[0].Trim();
            foreach (ExtensionClassType currentObject in Enum.GetValues(typeof(ExtensionClassType)))
            {
                ExtensionNameTemplate nameTemplate = AxModelSettings.ExtensionNameTemplateList[currentObject];
                if (!String.IsNullOrWhiteSpace(listImp[currentPosition]))
                {
                    nameTemplate.ExtensionTemplate = listImp[currentPosition].Trim();
                }

                if (!String.IsNullOrWhiteSpace(listImp[currentPosition + enumLength]))
                {
                    nameTemplate.EventHandlerTemplate = listImp[currentPosition + enumLength].Trim();
                }

                AxModelSettings.ExtensionNameTemplateList[currentObject] = nameTemplate;
                currentPosition++;
            }
        }

        public bool SaveToFile()
        {
            return _kernelSettingsStorage.SaveSettings(AxModelSettings);

        }

        public string GetDescription()
        {
            string res = "";

            res += "Use the following placeholders to setup a class template name:" + Environment.NewLine;

            res += $"{PrefixTemplateName} - Current prefix; {MainElementTemplateName} - Main AOT element name; {SubElementTemplateName} - Selected element" + Environment.NewLine;
            return res;
        }

        public string GetClassName(Kernel.ExtensionClassType elementType, ExtensionClassModeType classType,
                                            string prefixValue, string mainElementValue,
                                            string subElementValue)
        {
            ExtensionNameTemplate nameTemplate = AxModelSettings.ExtensionNameTemplateList[elementType];

            string templateString = classType == ExtensionClassModeType.EventHandler
                ? nameTemplate.EventHandlerTemplate
                : nameTemplate.ExtensionTemplate;

            string resultName = templateString;

            //String
            resultName = resultName.Replace(PrefixTemplateName, prefixValue);
            resultName = resultName.Replace(MainElementTemplateName, mainElementValue);
            resultName = resultName.Replace(SubElementTemplateName, subElementValue);

            resultName = AxHelper.RemoveSpecialCharacters(resultName).Replace(" ", "");

            return resultName;

        }

    }
}

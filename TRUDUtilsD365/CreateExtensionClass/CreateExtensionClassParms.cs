using System.Text;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Classes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.DataEntityViews;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Views;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Maps;
using TRUDUtilsD365.Kernel;
using Exception = System.Exception;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using TRUDUtilsD365.KernelSettings;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;

namespace TRUDUtilsD365.CreateExtensionClass
{


    public class CreateExtensionClassParms
    {
        public string Prefix { get; set; } = "TST";

        public string ElementName { get; set; }
        public string SubElementName { get; set; } = "";
        public Kernel.ExtensionClassType ElementType { get; set; }

        public ExtensionClassModeType ClassModeType { get; set; } = ExtensionClassModeType.Extension;

        public string ResultClassName { get; set; } = "";

        private string _logString;

        private KernelSettingsManager _kernelSettingsManager;

        public bool ClassTypeModified()
        {
            CalcResultName();
            return true;
        }
        public bool PrefixModified()
        {
            CalcResultName();
            return true;
        }

        void AddLog(string logLocal)
        {
            _logString += logLocal;
        }

        public void DisplayLog()
        {
            CoreUtility.DisplayInfo($"The following element({_logString}) was created and added to the project");
        }

        public void InitFromSettings()
        {
            _kernelSettingsManager = new KernelSettingsManager();
            _kernelSettingsManager.LoadSettings();

            Prefix = _kernelSettingsManager.GetAxModelSettings().ModelPrefix;
        }

        public void InitFromSelectedElement(object selectedElement)
        {
            if (selectedElement is IForm)
            {
                var form = (IForm)selectedElement;
                ElementType = Kernel.ExtensionClassType.Form;
                ElementName = form.Name;
            }
            else
            if (selectedElement is FormExtension)
            {
                var form = (FormExtension)selectedElement;
                ElementType = Kernel.ExtensionClassType.Form;
                ElementName = form.Name.Split('.')[0];
            }
            else
            if (selectedElement is ClassItem)
            {
                var form = (ClassItem)selectedElement;
                ElementType = Kernel.ExtensionClassType.Class;
                ElementName = form.Name;
            }
            else
            if ((selectedElement is Table) || (selectedElement is TableExtension))
            {
                var form = (INamedElement)selectedElement;
                ElementType = Kernel.ExtensionClassType.Table;
                ElementName = form.Name.Split('.')[0];
            }            
            else if (selectedElement is FormDataSourceField)
            {
                var form = (FormDataSourceField)selectedElement;
                ElementType    = Kernel.ExtensionClassType.FormDataField;
                ElementName    = form.FormDataSource.RootElement.Name;
                ElementName = ElementName.Split('.')[0];
                SubElementName = $"{form.FormDataSource.Name},{form.DataField}";
            }
            else if (selectedElement is FormDataSource)
            {
                var form = (FormDataSource)selectedElement;
                ElementType    = Kernel.ExtensionClassType.FormDataSource;
                ElementName    = form.RootElement.Name;
                ElementName = ElementName.Split('.')[0];
                SubElementName = $"{form.Name}";
            }
            else if (selectedElement is FormControl)
            {
                var form = (FormControl)selectedElement;
                ElementType    = Kernel.ExtensionClassType.FormControl;
                ElementName    = form.RootElement.Name;
                ElementName = ElementName.Split('.')[0];
                SubElementName = $"{form.Name}";
            }
            else if ((selectedElement is DataEntityView) || (selectedElement is DataEntityViewExtension))
            {
                var form = (INamedElement)selectedElement;
                ElementType = Kernel.ExtensionClassType.DataEntityView;
                ElementName = form.Name;
                ElementName = ElementName.Split('.')[0];
            }
            else if ((selectedElement is View) || (selectedElement is ViewExtension))
            {
                var form = (INamedElement)selectedElement;
                ElementType = Kernel.ExtensionClassType.View;
                ElementName = form.Name;
                ElementName = ElementName.Split('.')[0];
            }
            else if ((selectedElement is Map) || (selectedElement is MapExtension))
            {
                var form = (INamedElement)selectedElement;
                ElementType = Kernel.ExtensionClassType.Map;
                ElementName = form.Name;
                ElementName = ElementName.Split('.')[0];
            }
            InitFromSettings();
        }

        public void CalcResultName()
        {
            string res = _kernelSettingsManager.GetClassName(ElementType, ClassModeType, Prefix, ElementName, SubElementName);

            ResultClassName = res;
        }

        public bool Run()
        {
            if (ResultClassName.Length > 80)
            {
                throw new Exception($"Class name can't be more than 80 symbols({ResultClassName.Length})");
            }

            AxHelper axHelper = new AxHelper();

            AxClass newClass = axHelper.MetadataProvider.Classes.Read(ResultClassName);
            bool res = false;

            if (newClass == null)
            {
                res = true;
                //throw new Exception($"Class {ResultClassName} already exists");

                newClass = new AxClass {IsFinal = true, Name = ResultClassName};

                if (ClassModeType == ExtensionClassModeType.EventHandler) newClass.IsStatic = true;

                string typeStr = "";
                switch (ElementType)
                {
                    case Kernel.ExtensionClassType.Form:
                        typeStr = "formstr";
                        break;
                    case Kernel.ExtensionClassType.Class:
                        typeStr = "classstr";
                        break;
                    case Kernel.ExtensionClassType.Table:
                        typeStr = "tablestr";
                        break;
                    case Kernel.ExtensionClassType.FormDataField:
                        typeStr = "formdatafieldstr";
                        break;
                    case Kernel.ExtensionClassType.FormDataSource:
                        typeStr = "formdatasourcestr";
                        break;
                    case Kernel.ExtensionClassType.FormControl:
                        typeStr = "formcontrolstr";
                        break;
                    case Kernel.ExtensionClassType.DataEntityView:
                        typeStr = "dataentityviewstr";
                        break;
                    case Kernel.ExtensionClassType.View:
                        typeStr = "viewstr";
                        break;
                    case Kernel.ExtensionClassType.Map:
                        typeStr = "mapstr";
                        break;
                }

                StringBuilder declarationText = new StringBuilder();
                if (ClassModeType == ExtensionClassModeType.Extension)
                {
                    if (string.IsNullOrWhiteSpace(SubElementName))
                    {
                        declarationText.AppendLine($"[ExtensionOf({typeStr}({ElementName}))]");
                    }
                    else
                    {
                        declarationText.AppendLine($"[ExtensionOf({typeStr}({ElementName}, {SubElementName}))]");
                    }
                }

                declarationText.AppendLine($"final{(newClass.IsStatic ? " static " : " ")}class {newClass.Name}");
                declarationText.AppendLine("{");
                declarationText.AppendLine("}");

                newClass.SourceCode.Declaration = declarationText.ToString();
                axHelper.MetaModelService.CreateClass(newClass, axHelper.ModelSaveInfo);

                axHelper.AppendToActiveProject(newClass);
                AddLog($"Class: {newClass.Name}; ");
            }
            else
            {
                CoreUtility.DisplayInfo($"Class {newClass.Name} already exists");
                axHelper.AppendToActiveProject(newClass);
            }

            return res;

        }
    }
}
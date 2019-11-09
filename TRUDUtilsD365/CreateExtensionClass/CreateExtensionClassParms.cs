using System.Text;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Classes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.DataEntityViews;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Views;
using TRUDUtilsD365.Kernel;
using Exception = System.Exception;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.CreateExtensionClass
{
    public enum ExtensionClassType
    {
        Extension,
        EventHandler
    }

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

    public class CreateExtensionClassParms
    {
        public string Prefix { get; set; } = "TST";

        public string ElementName { get; set; }
        public string SubElementName { get; set; } = "";
        public ExtensionClassObject ElementType { get; set; }

        public ExtensionClassType ClassType { get; set; } = ExtensionClassType.Extension;

        public string ResultClassName { get; set; } = "";

        private string _logString;

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

        public void InitFromSelectedElement(object selectedElement)
        {
            if (selectedElement is IForm)
            {
                var form = (IForm)selectedElement;
                ElementType = ExtensionClassObject.Form;
                ElementName = form.Name;
            }
            else
            if (selectedElement is FormExtension)
            {
                var form = (FormExtension)selectedElement;
                ElementType = ExtensionClassObject.Form;
                ElementName = form.Name.Split('.')[0];
            }
            else
            if (selectedElement is ClassItem)
            {
                var form = (ClassItem)selectedElement;
                ElementType = ExtensionClassObject.Class;
                ElementName = form.Name;
            }
            else
            if ((selectedElement is Table) || (selectedElement is TableExtension))
            {
                var form = (Table)selectedElement;
                ElementType = ExtensionClassObject.Table;
                ElementName = form.Name.Split('.')[0];
            }            
            else if (selectedElement is FormDataSourceField)
            {
                var form = (FormDataSourceField)selectedElement;
                ElementType    = ExtensionClassObject.FormDataField;
                ElementName    = form.FormDataSource.RootElement.Name;
                ElementName = ElementName.Split('.')[0];
                SubElementName = $"{form.FormDataSource.Name}, {form.DataField}";
            }
            else if (selectedElement is FormDataSource)
            {
                var form = (FormDataSource)selectedElement;
                ElementType    = ExtensionClassObject.FormDataSource;
                ElementName    = form.RootElement.Name;
                ElementName = ElementName.Split('.')[0];
                SubElementName = $"{form.Name}";
            }
            else if (selectedElement is FormControl)
            {
                var form = (FormControl)selectedElement;
                ElementType    = ExtensionClassObject.FormControl;
                ElementName    = form.RootElement.Name;
                ElementName = ElementName.Split('.')[0];
                SubElementName = $"{form.Name}";
            }
            else if ((selectedElement is DataEntityView) || (selectedElement is DataEntityViewExtension))
            {
                var form = (DataEntityView)selectedElement;
                ElementType = ExtensionClassObject.DataEntityView;
                ElementName = form.Name;
                ElementName = ElementName.Split('.')[0];
            }
            else if ((selectedElement is View) || (selectedElement is ViewExtension))
            {
                var form = (View)selectedElement;
                ElementType = ExtensionClassObject.View;
                ElementName = form.Name;
                ElementName = ElementName.Split('.')[0];
            }
        }

        public void CalcResultName()
        {
            string res = "";
            res += ElementName;
            if (ElementType == ExtensionClassObject.Form ||
                ElementType == ExtensionClassObject.FormDataSource ||
                ElementType == ExtensionClassObject.FormDataField ||
                ElementType == ExtensionClassObject.FormControl)
            {
                res += "Form";
            }

            res += Prefix;

            if (ClassType == ExtensionClassType.Extension)
            {
                if (!string.IsNullOrWhiteSpace(SubElementName))
                {
                    res += "_" + AxHelper.GetTypeNameFromLabel(SubElementName);
                }
            }

            switch (ClassType)
            {
                case ExtensionClassType.Extension:
                    res += "_Extension";
                    break;
                case ExtensionClassType.EventHandler:
                    res += "_EventHandler";
                    break;
            }

            ResultClassName = res;
        }

        public void Run()
        {
            AxHelper axHelper = new AxHelper();

            AxClass newClass = axHelper.MetadataProvider.Classes.Read(ResultClassName);

            if (newClass != null)
            {
                throw new Exception($"Class {ResultClassName} already exists");
            }

            newClass = new AxClass {IsFinal = true, Name = ResultClassName};

            if (ClassType == ExtensionClassType.EventHandler) newClass.IsStatic = true;

            string typeStr = "";
            switch (ElementType)
            {
                case ExtensionClassObject.Form:
                    typeStr = "formstr";
                    break;
                case ExtensionClassObject.Class:
                    typeStr = "classstr";
                    break;
                case ExtensionClassObject.Table:
                    typeStr = "tablestr";
                    break;
                case ExtensionClassObject.FormDataField:
                    typeStr = "formdatafieldstr";
                    break;
                case ExtensionClassObject.FormDataSource:
                    typeStr = "formdatasourcestr";
                    break;
                case ExtensionClassObject.FormControl:
                    typeStr = "formcontrolstr";
                    break;
                case ExtensionClassObject.DataEntityView:
                    typeStr = "dataentityviewstr";
                    break;
                case ExtensionClassObject.View:
                    typeStr = "viewstr";
                    break;
            }

            StringBuilder declarationText = new StringBuilder();
            if (ClassType == ExtensionClassType.Extension)
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
    }
}
using System.Text;
using Dynamics.AX.Application;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using TRUDUtilsD365.Kernel;
using Exception = System.Exception;

namespace TRUDUtilsD365.CreateExtensionClass
{
    public enum ExtensionClassType
    {
        Extension,
        EventHandler
    }

    public class CreateExtensionClassParms
    {
        public string Prefix { get; set; }

        public string ElementName { get; set; }
        public UtilElementType ElementType { get; set; }

        public ExtensionClassType ClassType { get; set; }

        public string ResultClassName { get; set; }

        public void CalcResultName()
        {
            string res = "";
            res += ElementName;
            if (ElementType == UtilElementType.Form) res += "Form";
            res += Prefix;
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

        public void CreateClass()
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
                case UtilElementType.Form:
                    typeStr = "formstr";
                    break;
                case UtilElementType.Class:
                    typeStr = "classstr";
                    break;
                case UtilElementType.Table:
                    typeStr = "tablestr";
                    break;
            }

            StringBuilder declarationText = new StringBuilder();
            declarationText.AppendLine($"[ExtensionOf({typeStr}({ElementName}))]");
            declarationText.AppendLine($"final{(newClass.IsStatic ? " static " : " ")}class {newClass.Name}");
            declarationText.AppendLine("{");
            declarationText.AppendLine("}");

            newClass.SourceCode.Declaration = declarationText.ToString();
            axHelper.MetaModelService.CreateClass(newClass, axHelper.ModelSaveInfo);
            axHelper.AppendToActiveProject(newClass);
        }
    }
}
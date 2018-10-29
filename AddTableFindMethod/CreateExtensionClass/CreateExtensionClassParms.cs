using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Classes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Reports;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.AX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamics.AX.Application;
using Microsoft.Dynamics.AX.Metadata;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using TRUDUtilsD365.Kernel;
using Exception = Dynamics.AX.Application.Exception;

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
        public UtilElementType ElementType { get; set; }

        public ExtensionClassType ClassType { get; set; }

        public string ResultClassName { get; set; }

        public void calcResultName()
        {
            string res = "";
            res += this.ElementName;
            if (this.ElementType == UtilElementType.Form)
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

        public void createClass()
        {
            AxHelper axHelper = new AxHelper();

            Microsoft.Dynamics.AX.Metadata.MetaModel.AxClass newClass;

            newClass = axHelper.MetadataProvider.Classes.Read(this.ResultClassName);

            if (newClass != null)
            {
                throw new System.Exception($"Class {ResultClassName} already exists");
            }
            else
            {
                newClass = new AxClass();
                newClass.IsFinal = true;
                newClass.Name = ResultClassName;
                if (ClassType == ExtensionClassType.EventHandler)
                {
                    newClass.IsStatic = true;
                }

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
                declarationText.AppendLine($"final {(newClass.IsStatic ? "static " : "")}class {newClass.Name}");
                declarationText.AppendLine("{");
                declarationText.AppendLine("}");

                newClass.SourceCode.Declaration = declarationText.ToString();
                axHelper.MetaModelService.CreateClass(newClass, axHelper.ModelSaveInfo);
                axHelper.AppendToActiveProject(newClass);
            }

        }

    }
}

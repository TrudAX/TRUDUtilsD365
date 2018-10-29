using Dynamics.AX.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TRUDUtilsD365.AddTableFindMethod;
using TRUDUtilsD365.CreateExtensionClass;

namespace AddTableFindMethodTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //TestAddTableFindMethod();
            TestCreateExtensionClass();
        }

        private static void TestCreateExtensionClass()
        {
            CreateExtensionClassDialog dialog = new CreateExtensionClassDialog();

            CreateExtensionClassParms parms = new CreateExtensionClassParms();

            parms.ElementName = "CustTable";
            parms.ElementType = UtilElementType.Form;
            parms.Prefix = "MY";
            parms.ClassType = ExtensionClassType.EventHandler;

            dialog.setParameters(parms);

            Application.Run(dialog);
        }


        private static void TestAddTableFindMethod()
        {
            AddTableFindMethodDialog dialog = new AddTableFindMethodDialog();

            AddTableFindMethodParms parms = new AddTableFindMethodParms();
            //parms.MethodName = "find3";
            parms.IsTestMode = true;
            parms.TableName = "MyTable";
            parms.fields = new List<AxTableField> {
                new AxTableField { FieldName = "Field1",    FieldType = "Type1",    IsMandatory = true },
                new AxTableField { FieldName = "Field2Big", FieldType = "Type2Big", IsMandatory = true },
                new AxTableField { FieldName = "F3",        FieldType = "T3",       IsMandatory = false }
            };

            dialog.setParameters(parms);

            Application.Run(dialog);
        }
    }
}

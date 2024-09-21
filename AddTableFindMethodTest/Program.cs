//using Dynamics.AX.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TRUDUtilsD365.AddTableFindMethod;
using TRUDUtilsD365.CreateExtensionClass;
using TRUDUtilsD365.DataContractBuilder;
using TRUDUtilsD365.EnumCreator;
using TRUDUtilsD365.Kernel;
using TRUDUtilsD365.RunBaseBuilder;
using TRUDUtilsD365.TableBuilder;
using TRUDUtilsD365.TableFieldsBuilder;
using TRUDUtilsD365.KernelSettings;
using ExtensionClassType = TRUDUtilsD365.Kernel.ExtensionClassType;

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

            TestAddTableFindMethod();
            //TestCreateExtensionClass();
            //TestEnumCreator();
            //TestTableFieldsBuilder();
            //TestRunBaseBuilder();
            //TestDataContractBuilder();
            //TestTableBuilder();
            //TestSettings();
        }

        private static void TestSettings()
        {
            Application.Run(new KernelSettings());
        }

        private static void TestTableBuilder()
        {
            TableBuilderDialog dialog = new TableBuilderDialog();
            TableBuilderParms parms = new TableBuilderParms();

            dialog.SetParameters(parms);
            Application.Run(dialog);

            
        }
        private static void TestDataContractBuilder()
        {
            SnippetsParms snippetsParms = new SnippetsParms();
            DataContractBuilderParms runBaseBuilder = new DataContractBuilderParms();

            runBaseBuilder.InitDialogParms(snippetsParms);

            SnippetsDialog dialog = new SnippetsDialog();
            dialog.SetParameters(snippetsParms);
            Application.Run(dialog);
        }
        private static void TestRunBaseBuilder()
        {
            SnippetsParms  snippetsParms = new SnippetsParms();
            RunBaseBuilder runBaseBuilder = new RunBaseBuilder();

            runBaseBuilder.InitDialogParms(snippetsParms);

            SnippetsDialog dialog = new SnippetsDialog();
            dialog.SetParameters(snippetsParms);
            Application.Run(dialog);
        }

        private static void TestTableFieldsBuilder()
        {
            TableFieldsBuilderDialog dialog = new TableFieldsBuilderDialog();

            TableFieldsBuilderParms parms = new TableFieldsBuilderParms();
            parms.TableName = "CustTable";            

            dialog.SetParameters(parms);

            Application.Run(dialog);
        }

        private static void TestCreateExtensionClass()
        {
            CreateExtensionClassDialog dialog = new CreateExtensionClassDialog();

            CreateExtensionClassParms parms = new CreateExtensionClassParms();

            parms.ElementName = "CustTable";
            parms.ElementType = ExtensionClassType.Form;
            parms.Prefix = "MY";
            //parms.ClassModeType = ExtensionClassModeType.EventHandler;

            dialog.SetParameters(parms);

            Application.Run(dialog);
        }

        private static void TestEnumCreator()
        {
            EnumCreatorDialog dialog = new EnumCreatorDialog();
            EnumCreatorParms parms = new EnumCreatorParms();

            dialog.SetParameters(parms);

            Application.Run(dialog);
        }


        private static void TestAddTableFindMethod()
        {
            AddTableFindMethodDialog dialog = new AddTableFindMethodDialog();

            AddTableFindMethodParms parms = new AddTableFindMethodParms();
            //parms.MethodName = "find3";
            parms.IsTestMode = true;
            parms.TableName = "MyTable";
            parms.Fields = new List<AxTableFieldParm> {
                new AxTableFieldParm { FieldName = "Field1",    FieldType = "Type1",    IsMandatory = true },
                new AxTableFieldParm { FieldName = "Field2Big", FieldType = "Type2Big", IsMandatory = true },
                new AxTableFieldParm { FieldName = "F3",        FieldType = "T3",       IsMandatory = false }
            };

            dialog.SetParameters(parms);

            Application.Run(dialog);
        }
    }
}

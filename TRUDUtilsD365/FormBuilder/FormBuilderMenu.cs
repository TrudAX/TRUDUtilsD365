using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using System.Windows.Forms;

namespace TRUDUtilsD365.FormBuilder
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITable))]   
    class FormBuilderMenu : DesignerMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "TRUDUtils - Form builder";

        private const string AddinName = "TRUDUtilsD365.FormBuilder";
        /// <summary>
        ///     Unique name of the add-in
        /// </summary>
        public override string Name => AddinName;
        #endregion

        #region Callbacks

        /// <summary>
        ///     Called when user clicks on the add-in menu
        /// </summary>
        /// <param name="e">The context of the VS tools and metadata</param>
        [SuppressMessage("ReSharper", "MergeCastWithTypeCheck")]
        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                NamedElement element = e.SelectedElement as NamedElement;

                if (element != null)
                {
                    FormBuilderDialog dialog = new FormBuilderDialog();
                    FormBuilderParms parms = new FormBuilderParms();
                    parms.TableName = element.Name;
                    parms.InitFromTable();

                    dialog.SetParameters(parms);
                    DialogResult formRes = dialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }

        #endregion

    }
}

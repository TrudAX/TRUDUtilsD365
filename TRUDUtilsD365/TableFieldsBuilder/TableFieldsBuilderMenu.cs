using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using System.Windows.Forms;

namespace TRUDUtilsD365.TableFieldsBuilder
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITable))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITableExtension))]
    class TableFieldsBuilderMenu : DesignerMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "Fields builder";

        private const string AddinName = "TRUDUtilsD365.TableFieldsBuilder";
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
                    TableFieldsBuilderDialog dialog = new TableFieldsBuilderDialog();
                    TableFieldsBuilderParms parms = new TableFieldsBuilderParms();
                    parms.TableName = element.Name;

                    dialog.SetParameters(parms);
                    DialogResult formRes = dialog.ShowDialog();

                    if (formRes == DialogResult.OK) parms.AddFields();

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

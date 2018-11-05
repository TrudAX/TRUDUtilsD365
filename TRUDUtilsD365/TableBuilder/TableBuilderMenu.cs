using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.BaseTypes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.TableBuilder
{
    [Export(typeof(IMainMenu))]
    class TableBuilderMenu : MainMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "TRUDUtils - Table builder";

        private const string AddinName = "TRUDUtilsD365.TableBuilder";
        /// <summary>
        ///     Unique name of the add-in
        /// </summary>
        public override string Name => AddinName;
        #endregion

        public override void OnClick(AddinEventArgs e)
        {
            try
            {
                TableBuilderDialog dialog = new TableBuilderDialog();
                TableBuilderParms parms = new TableBuilderParms();

                dialog.SetParameters(parms);
                DialogResult formRes = dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
    }


    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(EdtString))]
    internal class DesignerTableBuilder : DesignerMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "TRUDUtils - Table builder";

        private const string AddinName = "TRUDUtilsD365.TableBuilderEDT";
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
                
                if (e.SelectedElement is EdtBase)
                {
                    var form = (EdtBase)e.SelectedElement;

                    TableBuilderDialog dialog = new TableBuilderDialog();
                    TableBuilderParms parms = new TableBuilderParms();
                    parms.PrimaryKeyEdtName = form.Name;

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

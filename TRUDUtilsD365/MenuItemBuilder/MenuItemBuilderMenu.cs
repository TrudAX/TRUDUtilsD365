using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Classes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Reports;

namespace TRUDUtilsD365.MenuItemBuilder
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ClassItem))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IForm))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IReport))]
    class MenuItemBuilderMenu : DesignerMenuBase
    {
        #region Properties
        public override string Caption => "TRUDUtils - Create menu item";

        private const string AddinName = "TRUDUtilsD365.MenuItemBuilder";
        public override string Name => AddinName;
        #endregion

        #region Callbacks

        [SuppressMessage("ReSharper", "MergeCastWithTypeCheck")]
        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                if (e.SelectedElement != null)
                {
                    MenuItemBuilderDialog dialog = new MenuItemBuilderDialog();
                    MenuItemBuilderParms parms = new MenuItemBuilderParms();
                    parms.InitFromSelectedElement(e.SelectedElement);

                    dialog.SetParameters(parms);
                    dialog.ShowDialog();
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

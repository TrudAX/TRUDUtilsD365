using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Menus;

namespace TRUDUtilsD365.SecurityPrivilegeBuilder
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IMenuItem))]
    class SecurityPrivilegeBuilderMenu : DesignerMenuBase
    {
        #region Properties
        public override string Caption => "TRUDUtils - Create security privilege";

        private const string AddinName = "TRUDUtilsD365.SecurityPrivilegeBuilder";
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
                    SecurityPrivilegeBuilderDialog dialog = new SecurityPrivilegeBuilderDialog();
                    SecurityPrivilegeBuilderParms parms = new SecurityPrivilegeBuilderParms();
                    parms.InitFromSelectedElement(e.SelectedElement as IMenuItem);

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

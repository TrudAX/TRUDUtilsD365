using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.BaseTypes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.SysOperationBuilder
{
    [Export(typeof(IMainMenu))]
    class SysOperationBuilderMenu : MainMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "TRUDUtils - SysOperation builder";

        private const string AddinName = "TRUDUtilsD365.SysOperationBuilder";
        /// <summary>
        ///     Unique name of the add-in
        /// </summary>
        public override string Name => AddinName;
        #endregion

        public override void OnClick(AddinEventArgs e)
        {
            try
            {
                SysOperationBuilderDialog dialog = new SysOperationBuilderDialog();
                SysOperationBuilderParms parms = new SysOperationBuilderParms();

                dialog.SetParameters(parms);
                dialog.Show();
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
    }
}
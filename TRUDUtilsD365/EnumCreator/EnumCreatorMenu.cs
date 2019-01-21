using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.EnumCreator
{
    [Export(typeof(IMainMenu))]
    class EnumCreatorMenu : MainMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "TRUDUtils - Enum builder";

        private const string AddinName = "TRUDUtilsD365.EnumCreator";
        /// <summary>
        ///     Unique name of the add-in
        /// </summary>
        public override string Name => AddinName;
        #endregion

        public override void OnClick(AddinEventArgs e)
        {
            try
            {
                EnumCreatorDialog dialog = new EnumCreatorDialog();
                EnumCreatorParms parms = new EnumCreatorParms();

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

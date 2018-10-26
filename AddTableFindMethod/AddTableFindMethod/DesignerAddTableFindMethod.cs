namespace TRUDUtilsD365.AddTableFindMethod
{
    using System;
    using System.Linq;
    using System.ComponentModel.Composition;
    using Microsoft.Dynamics.AX.Metadata.Core;
    using Microsoft.Dynamics.Framework.Tools.Extensibility;
    using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
    using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
    using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
    using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

    /// <summary>
    /// Create standard table methods based on selected fields
    /// </summary>
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(BaseField))]
    public class DesignerAddTableFindMethod : DesignerMenuBase
    {
        #region Member variables
        private const string addinName = "DesignerAddTableFindMethod";
        #endregion

        #region Properties
        /// <summary>
        /// Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption
        {
            get
            {
                return "Add table methods";
            }
        }

        /// <summary>
        /// Unique name of the add-in
        /// </summary>
        public override string Name
        {
            get
            {
                return DesignerAddTableFindMethod.addinName;
            }
        }
        #endregion

        #region Callbacks
        /// <summary>
        /// Called when user clicks on the add-in menu
        /// </summary>
        /// <param name="e">The context of the VS tools and metadata</param>
        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                AddTableFindMethodDialog dialog = new AddTableFindMethodDialog();

                AddTableFindMethodParms parms = new AddTableFindMethodParms();
                parms.MethodName = "find";
                dialog.setParameters(parms);
                dialog.ShowDialog();

            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
        #endregion
    }
}

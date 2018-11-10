using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using Exception = System.Exception;

namespace TRUDUtilsD365.CopyExtensionMethod
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IMethodBase), CanSelectMultiple = false)]
    class DesignerCopyExtensionMethod : DesignerMenuBase
    {
        #region Member variables

        private const string addinName = "CopyExtensionMethod";

        #endregion

        #region Callbacks

        /// <summary>
        ///     Called when user clicks on the add-in menu
        /// </summary>
        /// <param name="e">The context of the VS tools and metadata</param>
        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                if (e.SelectedElement is IMethodBase)
                {
                    var methodBase = e.SelectedElement as IMethodBase;
                    string methodTxt = new CopyExtensionMethodParams().createMethod(methodBase);
                    Clipboard.SetText(methodTxt.ToString());
                }
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
        

        #endregion

        #region Properties

        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption
        {
            get { return "Copy extension method"; }
        }

        /// <summary>
        ///     Unique name of the add-in
        /// </summary>
        public override string Name
        {
            get { return addinName; }
        }

        #endregion
    }
}

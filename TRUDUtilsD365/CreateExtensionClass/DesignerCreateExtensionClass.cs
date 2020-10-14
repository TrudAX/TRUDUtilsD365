using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Classes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.DataEntityViews;
using Exception = System.Exception;

namespace TRUDUtilsD365.CreateExtensionClass
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ClassItem))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IForm))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(FormExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Table))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(TableExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(FormDataSourceField))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(FormDataSource))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(FormControl))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(DataEntityView))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(DataEntityViewExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Views.View))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Views.ViewExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Maps.Map))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Maps.MapExtension))]
    internal class DesignerCreateExtensionClass : DesignerMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "TRUDUtils - Create extension class";

        private const string AddinName = "TRUDUtilsD365.CreateExtensionClass";
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
                if (e.SelectedElement != null)
                {
                    CreateExtensionClassDialog dialog = new CreateExtensionClassDialog();
                    CreateExtensionClassParms parms = new CreateExtensionClassParms();

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
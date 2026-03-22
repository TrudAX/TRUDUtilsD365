using System;
using System.ComponentModel.Composition;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.BaseTypes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Classes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.DataEntityViews;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Views;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.ShowCrossReference
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(BaseField))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITable))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(TableExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ClassItem))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IForm))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(FormExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IView))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IDataEntity))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(DataEntityView))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(DataEntityViewExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IBaseEnum))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IMethodBase))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IDataEntityViewField))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IViewField))]
    public class ShowCrossReferenceMenu : DesignerMenuBase
    {
        public override string Caption => "TRUDUtils - Show cross-reference";

        private const string AddinName = "TRUDUtilsD365.ShowCrossReference";
        public override string Name => AddinName;

        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                if (e.SelectedElement != null)
                {
                    ShowCrossReferenceParms parms = new ShowCrossReferenceParms();
                    parms.InitFromSelectedElement(e);

                    ShowCrossReferenceDialog dialog = new ShowCrossReferenceDialog();
                    dialog.SetParameters(parms);
                    dialog.Show();
                }
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
    }
}

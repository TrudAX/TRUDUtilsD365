using System;
using System.ComponentModel.Composition;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.ShowCrossReference
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(BaseField))]
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

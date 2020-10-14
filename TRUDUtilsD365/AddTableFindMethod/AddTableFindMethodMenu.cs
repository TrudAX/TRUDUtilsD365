using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables; 
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.AddTableFindMethod
{
    /// <summary>
    ///     Create standard table methods based on selected fields
    /// </summary>
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(BaseField))]
    public class AddTableFindMethodMenu : DesignerMenuBase
    {
        public override string Caption => "TRUDUtils - Create find method";

        private const string AddinName = "TRUDUtilsD365.AddTableFindMethod";
        public override string Name => AddinName;

        [SuppressMessage("ReSharper", "MergeCastWithTypeCheck")]
        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                if (e.SelectedElement != null)
                {
                    AddTableFindMethodDialog dialog = new AddTableFindMethodDialog();
                    AddTableFindMethodParms parms = new AddTableFindMethodParms();
                    parms.InitFromSelectedElement(e);

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
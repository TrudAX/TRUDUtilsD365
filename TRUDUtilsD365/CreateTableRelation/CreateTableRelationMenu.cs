using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;

namespace TRUDUtilsD365.CreateTableRelation
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(BaseField))]
    class CreateTableRelationMenu : DesignerMenuBase
    {
        #region Properties
        public override string Caption => "TRUDUtils - Create relation";

        private const string AddinName = "TRUDUtilsD365.CreateTableRelation";
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
                    CreateTableRelationDialog dialog = new CreateTableRelationDialog();
                    CreateTableRelationParms parms = new CreateTableRelationParms();
                    parms.InitFromSelectedElement(e);

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

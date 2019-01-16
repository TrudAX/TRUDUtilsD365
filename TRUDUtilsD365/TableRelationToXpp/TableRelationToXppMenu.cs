using System.ComponentModel.Composition;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using TRUDUtilsD365.Kernel;

namespace TRUDUtilsD365.TableRelationToXpp
{
    [Export(typeof(IDesignerMenu))]
    
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IRelation))]
    internal class TableRelationToXppMenu : DesignerMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "TRUDUtils - Relation to Xpp";

        private const string AddinName = "TRUDUtilsD365.TableRelationToXpp";
        /// <summary>
        ///     Unique name of the add-in
        /// </summary>
        public override string Name => AddinName;
        #endregion

        #region Callbacks

        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                SnippetsParms snippetsParms = new SnippetsParms();
                TableRelationToXppParms relationToXppParms = new TableRelationToXppParms();

                Relation relation = null;
                if (e.SelectedElement != null)
                {
                    relation = e.SelectedElement as Relation;
                }

                if (relation == null)
                {
                    throw new System.Exception("Relation should be selected");
                }
                relationToXppParms.InitFromRelation(relation);
                relationToXppParms.InitDialogParms(snippetsParms);

                SnippetsDialog dialog = new SnippetsDialog();
                dialog.SetParameters(snippetsParms);
                dialog.Show();
                dialog.ShowResultButton_Click(null, null);
            }
            catch (System.Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }

        }
        #endregion
    }
}
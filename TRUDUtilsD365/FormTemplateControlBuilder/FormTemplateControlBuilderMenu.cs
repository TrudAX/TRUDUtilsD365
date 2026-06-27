using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.FormTemplateControlBuilder
{
    /// <summary>
    ///     Adds the controls required by a form's assigned design pattern (template) to that form.
    /// </summary>
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IForm))]
    public class FormTemplateControlBuilderMenu : DesignerMenuBase
    {
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "TRUDUtils - Add template controls";

        private const string AddinName = "TRUDUtilsD365.FormTemplateControlBuilder";

        /// <summary>
        ///     Unique name of the add-in
        /// </summary>
        public override string Name => AddinName;

        [SuppressMessage("ReSharper", "MergeCastWithTypeCheck")]
        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                NamedElement element = e.SelectedElement as NamedElement;
                if (element == null)
                {
                    return;
                }

                FormTemplateControlBuilderParms parms = new FormTemplateControlBuilderParms();
                parms.InitFromSelectedElement(element.Name);

                FormTemplateControlBuilderDialog dialog = new FormTemplateControlBuilderDialog();
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

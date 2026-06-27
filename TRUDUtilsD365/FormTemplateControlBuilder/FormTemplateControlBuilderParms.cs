using System;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.AX.Metadata.Patterns;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using TRUDUtilsD365.Kernel;

namespace TRUDUtilsD365.FormTemplateControlBuilder
{
    /// <summary>
    /// UI-facing model for the "Add template controls" add-in: reads the template (design pattern) currently
    /// assigned to a form and, on Run, adds the controls that template requires to the form via
    /// <see cref="FormPatternControlBuilderService"/>.
    /// </summary>
    public class FormTemplateControlBuilderParms
    {
        public string FormName { get; set; } = "";
        public string TemplateName { get; set; } = "";
        public string TemplateVersion { get; set; } = "";
        public string TemplateFriendlyName { get; set; } = "";

        /// <summary>True when the form design has a template (pattern) assigned.</summary>
        public bool HasTemplate { get; set; }

        /// <summary>True when the form design already contains controls (tool requires an empty design).</summary>
        public bool DesignHasControls { get; set; }

        /// <summary>When true, optional template controls are added too; when false only required ones.</summary>
        public bool AddOptionalControls { get; set; } = true;

        private AxHelper _axHelper;
        private string _logString = "";
        private int _controlsCreated;

        public string TemplateDisplay =>
            HasTemplate
                ? $"{TemplateFriendlyName} ({TemplateName} {TemplateVersion})".Replace("  ", " ").Trim()
                : "<no template assigned>";

        /// <summary>OK is only enabled when there is a template and the design is empty.</summary>
        public bool CanRun => HasTemplate && !DesignHasControls;

        /// <summary>Message shown in the dialog describing what will happen (or why it cannot).</summary>
        public string StatusMessage()
        {
            if (!HasTemplate)
            {
                return $"Form '{FormName}' has no template (pattern) assigned to its design.{Environment.NewLine}{Environment.NewLine}" +
                       "Assign one in the form designer (select Design, set the Pattern property / 'Apply pattern') and run this tool again.";
            }
            if (DesignHasControls)
            {
                return $"The design of form '{FormName}' already contains controls.{Environment.NewLine}{Environment.NewLine}" +
                       "This tool only scaffolds an empty form design. Remove the existing controls or use a new form.";
            }
            return $"The controls required by template '{TemplateDisplay}' will be added to form '{FormName}'.";
        }

        public void InitFromSelectedElement(string formName)
        {
            FormName = formName;
            _axHelper = new AxHelper();

            AxForm form = _axHelper.MetadataProvider.Forms.Read(formName);
            if (form == null)
            {
                throw new Exception($"Form '{formName}' could not be read from metadata");
            }

            TemplateName = form.Design.Pattern ?? "";
            TemplateVersion = form.Design.PatternVersion ?? "";
            HasTemplate = !string.IsNullOrEmpty(TemplateName);
            DesignHasControls = ((IFormControlCollection)form.Design).Controls.Count > 0;

            if (HasTemplate)
            {
                Pattern pattern = FormPatternControlBuilderService.ResolvePattern(TemplateName, TemplateVersion);
                TemplateFriendlyName = pattern != null ? pattern.FriendlyName : TemplateName;
                if (pattern != null && string.IsNullOrEmpty(TemplateVersion))
                {
                    TemplateVersion = pattern.Version;
                }
            }
        }

        public void ValidateData()
        {
            if (string.IsNullOrEmpty(FormName))
            {
                throw new Exception("Form name is not specified");
            }
            if (!HasTemplate)
            {
                throw new Exception($"Form '{FormName}' has no template (pattern) assigned to its design");
            }
            if (DesignHasControls)
            {
                throw new Exception($"Form '{FormName}' design already contains controls; this tool only scaffolds an empty design");
            }
        }

        public void Run()
        {
            ValidateData();
            if (_axHelper == null)
            {
                _axHelper = new AxHelper();
            }

            AxForm form = _axHelper.MetadataProvider.Forms.Read(FormName);
            if (form == null)
            {
                throw new Exception($"Form '{FormName}' not found");
            }
            if (((IFormControlCollection)form.Design).Controls.Count > 0)
            {
                throw new Exception($"Form '{FormName}' design already contains controls");
            }

            Pattern pattern = FormPatternControlBuilderService.ResolvePattern(form.Design.Pattern, form.Design.PatternVersion);
            if (pattern == null)
            {
                throw new Exception($"Template '{form.Design.Pattern}' was not found in the pattern catalog");
            }

            FormPatternControlBuilderService service = new FormPatternControlBuilderService(AddOptionalControls);
            service.BuildControls(form.Design, pattern);

            _axHelper.MetaModelService.UpdateForm(form, _axHelper.ModelSaveInfo);
            _axHelper.AppendToActiveProject(form);

            _logString = service.Log;
            _controlsCreated = service.ControlsCreated;
        }

        public void DisplayLog()
        {
            CoreUtility.DisplayInfo(
                $"{_controlsCreated} control(s) were added to form '{FormName}' for template '{TemplateDisplay}'. " +
                $"Restore the form before use.{Environment.NewLine}{Environment.NewLine}{_logString}");
        }
    }
}

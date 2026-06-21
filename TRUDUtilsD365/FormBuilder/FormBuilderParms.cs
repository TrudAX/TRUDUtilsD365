using System;
using System.Collections.Generic;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.FormBuilder
{
    public enum FormTemplateType
    {
        SimpleList,
        SimpleListDetails
    }

    public class FormTabDef
    {
        public string Caption;
        public bool IsList;
    }

    public class FormBuilderParms
    {
        public string TableName { get; set; } = "";

        public FormTemplateType TemplateType { get; set; }

        public Boolean IsCreateMenuItem { get; set; }=true;
        public string FormName { get; set; } = "";
        public string FormLabel { get; set; } = "";
        public string FormHelp { get; set; } = "";

        public string GroupNameGrid { get; set; } = "Overview";
        public string GroupNameHeader { get; set; } = "DetailsHeaderGroup";

        // Values entered in the right-hand "Values" column on the SimpleListDetails-Tabular tab.
        // Each line maps positionally to a static label: line 1 = Grid group, line 2 = Header group,
        // line 3+ = Tabs (one tab per line; "Name, list" creates a toolbar+grid tab page).
        public string SimpleListDetailsValues { get; set; } =
            "Overview"           + Environment.NewLine +
            "DetailsHeaderGroup" + Environment.NewLine +
            "Details"            + Environment.NewLine +
            "Lines,list";

        private List<FormTabDef> _parsedTabs;

        private AxHelper _axHelper;

        private string _logString;

        void AddLog(string logLocal)
        {
            _logString += logLocal;
        }

        public void DisplayLog()
        {
            CoreUtility.DisplayInfo($"The following elements({_logString}) were created and added to the project");
        }

        public void ValidateData()
        {
           if (string.IsNullOrEmpty(TableName) || string.IsNullOrEmpty(FormName))
            {
                throw new Exception($"Table name and Form name should be specified");
            }
            
        }

        public void InitFromTable()
        {
            _axHelper = new AxHelper();
            AxTable newTable = _axHelper.MetadataProvider.Tables.Read(TableName);
            if (newTable != null)
            {
                FormName = TableName;
                FormLabel = newTable.Label;
            }
        }

        public void ParseSimpleListDetailsParams()
        {
            _parsedTabs = new List<FormTabDef>();

            string[] lines = SimpleListDetailsValues.Split(
                new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                string value = lines[i].Trim();

                switch (i)
                {
                    case 0:   // Grid group
                        GroupNameGrid = value;
                        break;
                    case 1:   // Header group
                        GroupNameHeader = value;
                        break;
                    default:  // Tabs (one per line)
                        AddTabDef(value);
                        break;
                }
            }
        }

        void AddTabDef(string tabEntry)
        {
            if (string.IsNullOrWhiteSpace(tabEntry))
            {
                return;
            }

            string[] parts = tabEntry.Split(',');
            bool isList = parts.Length > 1 &&
                          parts[parts.Length - 1].Trim().Equals("list", StringComparison.OrdinalIgnoreCase);

            string caption = isList ? parts[0].Trim() : tabEntry.Trim();
            _parsedTabs.Add(new FormTabDef { Caption = caption, IsList = isList });
        }

        public void Run()
        {
            _logString = "";
            ValidateData();
            if (_axHelper == null)
            {
                _axHelper = new AxHelper();
            }

            if (TemplateType == FormTemplateType.SimpleListDetails)
            {
                ParseSimpleListDetailsParams();
            }

            DoTableUpdate();

            DoFormCreate();

            if (IsCreateMenuItem)
            {                
                DoMenuItemCreate();
            }
        }

        void DoMenuItemCreate()
        {
            AxMenuItemDisplay axMenuItemDisplay =_axHelper.MetadataProvider.MenuItemDisplays.Read(FormName);
            if (axMenuItemDisplay != null)
            {
                return;                
            }

            axMenuItemDisplay = new AxMenuItemDisplay { Name = FormName, Object = FormName, Label = FormLabel, HelpText = FormHelp };
            _axHelper.MetaModelService.CreateMenuItemDisplay(axMenuItemDisplay, _axHelper.ModelSaveInfo);
            _axHelper.AppendToActiveProject(axMenuItemDisplay);

            AddLog($"MenuItem: {axMenuItemDisplay.Name}; ");
        }

        void DoFormCreate()
        {
            AxForm newForm = _axHelper.MetadataProvider.Forms.Read(FormName);
            if (newForm != null)
            {
                throw new Exception($"Form {FormName} already exists");
            }

            newForm = new AxForm {Name = FormName};

            AxMethod axMethod = new AxMethod();
            axMethod.Name = "classDeclaration";
            axMethod.Source = $"[Form]{Environment.NewLine}public class {newForm.Name} extends FormRun " +
                              Environment.NewLine + "{" + Environment.NewLine + "}";
            newForm.AddMethod(axMethod);

            string dsName = TableName;

            AxFormDataSourceRoot axFormDataSource = new AxFormDataSourceRoot();
            axFormDataSource.Name = dsName;
            axFormDataSource.Table = TableName;
            axFormDataSource.InsertIfEmpty = NoYes.No;
            newForm.AddDataSource(axFormDataSource);
            newForm.Design.Caption = FormLabel;
            newForm.Design.TitleDataSource = dsName;
            newForm.Design.DataSource = dsName;

            AxFormGroupControl filterGrp, detailsHeaderGroup;
            AxFormGridControl axFormGridControl;
            AxFormControlExtension quickFilterControl;
            AxFormControlExtensionProperty formControlExtensionProperty;
            AxFormGroupControl overviewGroupControl;
            AxFormTabControl formTabControl;

            switch (TemplateType)
            {
                case FormTemplateType.SimpleList:
                    newForm.Design.AddControl(new AxFormActionPaneControl { Name = "MainActionPane" });

                    filterGrp = new AxFormGroupControl { Name = "FilterGroup", Pattern = "CustomAndQuickFilters", PatternVersion = "1.1" };

                    quickFilterControl = new AxFormControlExtension { Name = "QuickFilterControl" };
                    formControlExtensionProperty = new AxFormControlExtensionProperty();

                    formControlExtensionProperty.Name  = "targetControlName";
                    formControlExtensionProperty.Type  = CompilerBaseType.String;
                    formControlExtensionProperty.Value = "MainGrid";
                    quickFilterControl.ExtensionProperties.Add(formControlExtensionProperty);

                    filterGrp.AddControl(new AxFormControl { Name = "QuickFilter", FormControlExtension = quickFilterControl });
                    newForm.Design.AddControl(filterGrp);
                    axFormGridControl = new AxFormGridControl { Name = "MainGrid", DataSource = dsName };

                    overviewGroupControl = new AxFormGroupControl
                    {
                        Name       = GroupNameGrid,
                        DataGroup  = GroupNameGrid,
                        DataSource = dsName
                    };
                    axFormGridControl.AddControl(overviewGroupControl);
                    newForm.Design.AddControl(axFormGridControl);
                    break;
                case FormTemplateType.SimpleListDetails:
                    // "Simple list and details - Tabular grid". Only the structure and data-binding/functional
                    // properties are set here; all pattern-mandated layout properties (Style, WidthMode, FrameType,
                    // grid Tabular/AllowEdit/..., the design Pattern/PatternVersion, etc.) are applied at the end by
                    // AxHelper.ApplyPattern - the headless equivalent of the designer "Apply Pattern" command.
                    AxFormActionPaneControl mainActionPane = new AxFormActionPaneControl { Name = "MainActionPane" };
                    mainActionPane.AddControl(new AxFormButtonGroupControl { Name = "FormButtonGroupControlMain" });
                    newForm.Design.AddControl(mainActionPane);

                    filterGrp = new AxFormGroupControl { Name = "NavigationListGroup" };

                    quickFilterControl = new AxFormControlExtension { Name = "QuickFilterControl" };
                    formControlExtensionProperty = new AxFormControlExtensionProperty();
                    formControlExtensionProperty.Name  = "targetControlName";
                    formControlExtensionProperty.Type  = CompilerBaseType.String;
                    formControlExtensionProperty.Value = "MainGrid";
                    quickFilterControl.ExtensionProperties.Add(formControlExtensionProperty);
                    // QuickFilterControl declares these two extra properties; the designer materializes them
                    // (empty) too, so emit them to match the designer "Apply Pattern" output exactly.
                    quickFilterControl.ExtensionProperties.Add(new AxFormControlExtensionProperty { Name = "placeholderText",   Type = CompilerBaseType.String });
                    quickFilterControl.ExtensionProperties.Add(new AxFormControlExtensionProperty { Name = "defaultColumnName", Type = CompilerBaseType.String });

                    filterGrp.AddControl(new AxFormControl { Name = "NavListQuickFilter", FormControlExtension = quickFilterControl });
                    axFormGridControl = new AxFormGridControl { Name = "MainGrid", DataSource = dsName };

                    if (!string.IsNullOrWhiteSpace(GroupNameGrid))
                    {
                        overviewGroupControl = new AxFormGroupControl
                        {
                            Name       = GroupNameGrid,
                            DataGroup  = GroupNameGrid,
                            DataSource = dsName
                        };
                        axFormGridControl.AddControl(overviewGroupControl);
                    }

                    filterGrp.AddControl(axFormGridControl);
                    newForm.Design.AddControl(filterGrp);

                    newForm.Design.AddControl(new AxFormGroupControl { Name = "VerticalSplitterGroup" });

                    detailsHeaderGroup = new AxFormGroupControl { Name = "DetailsHeaderGroup", DataSource = dsName };
                    if (!string.IsNullOrWhiteSpace(GroupNameHeader))
                    {
                        detailsHeaderGroup.DataGroup = GroupNameHeader;
                    }

                    newForm.Design.AddControl(detailsHeaderGroup);

                    formTabControl = new AxFormTabControl { Name = "DetailsTab" };

                    foreach (FormTabDef tabDef in _parsedTabs)
                    {
                        formTabControl.AddControl(tabDef.IsList
                            ? CreateListTabPage(tabDef.Caption)
                            : CreateDetailsTabPage(tabDef.Caption, dsName));
                    }

                    newForm.Design.AddControl(formTabControl);

                    // Apply the form pattern and the header sub-pattern (tab-page sub-patterns are applied in the
                    // helpers). This stamps the current pattern versions and all mandated layout properties.
                    AxHelper.ApplyPattern(newForm.Design, "SimpleListDetails-Grid");
                    AxHelper.ApplyPattern(detailsHeaderGroup, "FieldsFieldGroups");

                    break;

            }

            _axHelper.MetaModelService.CreateForm(newForm, _axHelper.ModelSaveInfo);
            _axHelper.AppendToActiveProject(newForm);

            AddLog($"Form: {newForm.Name} - Restore it before use;");
        }

        AxFormTabPageControl CreateDetailsTabPage(string caption, string dsName)
        {
            AxFormTabPageControl tabPage = new AxFormTabPageControl
            {
                Name       = AxHelper.GetTypeNameFromLabel(caption) + "TabPage",
                Caption    = caption,
                DataSource = dsName
            };
            AxHelper.ApplyPattern(tabPage, "FieldsFieldGroups");
            return tabPage;
        }

        AxFormTabPageControl CreateListTabPage(string caption)
        {
            string suffix = AxHelper.GetTypeNameFromLabel(caption);

            AxFormTabPageControl tabPage = new AxFormTabPageControl
            {
                Name    = "TabPage" + suffix,
                Caption = caption
            };

            AxFormActionPaneControl actionPane = new AxFormActionPaneControl { Name = "ActionPaneControl" + suffix };

            AxFormButtonGroupControl newDeleteGroup = new AxFormButtonGroupControl { Name = "NewDeleteGroup" + suffix };
            newDeleteGroup.AddControl(new AxFormCommandButtonControl
            {
                Name          = "AddButton" + suffix,
                Command       = ClientTaskType.New,
                NormalImage   = "New",
                ButtonDisplay = ButtonDisplay_ITxt.TextWithImageLeft,
                Primary       = NoYes.Yes,
                Text          = "@sys60080"
            });
            newDeleteGroup.AddControl(new AxFormCommandButtonControl
            {
                Name          = "RemoveButton" + suffix,
                Command       = ClientTaskType.DeleteRecord,
                NormalImage   = "Delete",
                ButtonDisplay = ButtonDisplay_ITxt.TextWithImageLeft,
                Primary       = NoYes.Yes,
                SaveRecord    = NoYes.No,
                Text          = "@sys26394"
            });
            actionPane.AddControl(newDeleteGroup);
            actionPane.AddControl(new AxFormButtonGroupControl { Name = "FormButtonGroupControl" + suffix });

            tabPage.AddControl(actionPane);
            tabPage.AddControl(new AxFormGridControl { Name = "Grid" + suffix });

            AxHelper.ApplyPattern(tabPage, "ToolbarList");
            return tabPage;
        }


        void DoTableUpdate()
        {
            AxTable newTable = _axHelper.MetadataProvider.Tables.Read(TableName);
            if (newTable != null)
            {
                AxTableFieldGroup axTableFieldGroup;
                bool isTableModified = false;
                switch (TemplateType)
                {
                    case FormTemplateType.SimpleList:
                        if (!string.IsNullOrWhiteSpace(GroupNameGrid) && !newTable.FieldGroups.Contains(GroupNameGrid))
                        {
                            axTableFieldGroup = new AxTableFieldGroup { Name = GroupNameGrid, Label = "Overview" };
                            newTable.AddFieldGroup(axTableFieldGroup);
                            isTableModified = true;
                            AddLog($"Group added: {GroupNameGrid}; ");
                        }
                        break;
                    case FormTemplateType.SimpleListDetails:
                        if (! string.IsNullOrWhiteSpace(GroupNameGrid) && !newTable.FieldGroups.Contains(GroupNameGrid))
                        {
                            axTableFieldGroup = new AxTableFieldGroup { Name = GroupNameGrid, Label = "Overview" };
                            newTable.AddFieldGroup(axTableFieldGroup);
                            isTableModified = true;
                            AddLog($"Group added: {GroupNameGrid}; ");
                        }
                        if (!string.IsNullOrWhiteSpace(GroupNameHeader) && !newTable.FieldGroups.Contains(GroupNameHeader))
                        {
                            axTableFieldGroup = new AxTableFieldGroup { Name = GroupNameHeader, Label = "Details header" };
                            newTable.AddFieldGroup(axTableFieldGroup);
                            isTableModified = true;
                            AddLog($"Group added: {GroupNameHeader}; ");
                        }
                        break;

                }

                if (isTableModified)
                {
                    _axHelper.MetaModelService.UpdateTable(newTable, _axHelper.ModelSaveInfo);
                    _axHelper.AppendToActiveProject(newTable);

                    //AddLog($"Table modified: {newTable.Name}; ");
                }
            }
        }

    }
}

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
    public class FormBuilderParms
    {
        public string TableName { get; set; } = "";

        public FormTemplateType TemplateType { get; set; }

        public Boolean IsCreateMenuItem { get; set; }=true;
        public string FormName { get; set; } = "";
        public string FormLabel { get; set; } = "";
        public string FormHelp { get; set; } = "";

        public string TabLabels { get; set; } = "Details";

        public string GroupNameGrid { get; set; } = "Overview";
        public string GroupNameHeader { get; set; } = "DetailsHeaderGroup";

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

        public void Run()
        {
            _logString = "";
            ValidateData();
            if (_axHelper == null)
            {
                _axHelper = new AxHelper();
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
                    newForm.Design.AddControl(new AxFormActionPaneControl { Name = "MainActionPane" });
                    filterGrp = new AxFormGroupControl { Name = "NavigationListGroup" };

                    quickFilterControl = new AxFormControlExtension { Name = "QuickFilterControl" };
                    formControlExtensionProperty = new AxFormControlExtensionProperty();
                    formControlExtensionProperty.Name  = "targetControlName";
                    formControlExtensionProperty.Type  = CompilerBaseType.String;
                    formControlExtensionProperty.Value = "MainGrid";
                    quickFilterControl.ExtensionProperties.Add(formControlExtensionProperty);

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

                    detailsHeaderGroup = new AxFormGroupControl { Name = "DetailsHeaderGroup" };
                    detailsHeaderGroup.DataSource = dsName;
                    detailsHeaderGroup.DataGroup = GroupNameHeader;

                    newForm.Design.AddControl(detailsHeaderGroup);

                    formTabControl = new AxFormTabControl { Name = "DetailsTab" };

                    List<string> listImp = new List<string>(
                        TabLabels.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
                    foreach (string lineImp in listImp)
                    {
                        string tabName = AxHelper.GetTypeNameFromLabel(lineImp) + "TabPage";
                        formTabControl.AddControl(new AxFormTabPageControl {Name = tabName, Caption = lineImp,DataSource = dsName });
                    }

                    newForm.Design.AddControl(formTabControl);

                    break;

            }

            _axHelper.MetaModelService.CreateForm(newForm, _axHelper.ModelSaveInfo);
            _axHelper.AppendToActiveProject(newForm);

            AddLog($"Form: {newForm.Name} - Restore it before use;");
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

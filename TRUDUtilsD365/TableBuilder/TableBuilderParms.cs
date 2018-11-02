using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using TRUDUtilsD365.AddTableFindMethod;
using AxTableField = Microsoft.Dynamics.AX.Metadata.MetaModel.AxTableField;

namespace TRUDUtilsD365.TableBuilder
{
    public class TableBuilderParms
    {
        public Boolean IsCreateTable { get; set; }
        public string TableName { get; set; } = "";
        public string TableLabel { get; set; } = "";
        public string TableVarName { get; set; } = "";

        public Boolean IsCreateForm { get; set; }
        public string FormName { get; set; } = "";
        public string FormLabel { get; set; } = "";
        public string FormHelp { get; set; } = "";

        public string PrimaryKeyEDTName { get; set; } = "";
        public string KeyFieldName { get; set; } = "Id";

        private AxHelper _axHelper;

        public void CreateTable()
        {
            if (IsCreateTable)
            {
                DoTableCreate();
            }

            if (IsCreateForm)
            {
                DoFormCreate();
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
        }

        void DoFormCreate()
        {
            AxForm newForm = _axHelper.MetadataProvider.Forms.Read(FormName);
            if (newForm != null)
            {
                return;
            }
            newForm = new AxForm();
            newForm.Name = FormName;

            string dsName = TableName;

            AxFormDataSourceRoot axFormDataSource = new AxFormDataSourceRoot();
            axFormDataSource.Name = dsName;
            axFormDataSource.Table = TableName;
            axFormDataSource.InsertIfEmpty = NoYes.No;
            newForm.AddDataSource(axFormDataSource);

            newForm.Design.Pattern = "SimpleList";
            newForm.Design.Caption = FormLabel;

            newForm.Design.AddControl(new AxFormActionPaneControl { Name = "MainActionPane" });
            var filterGrp = new AxFormGroupControl{Name = "FilterGroup",Pattern = "CustomAndQuickFilters"};

            filterGrp.AddControl(new AxFormControl{Name = "QuickFilter",
                FormControlExtension = new AxFormControlExtension { Name = "QuickFilterControl" }
            });
            AxFormGridControl axFormGridControl = new AxFormGridControl {Name = "MainGrid", DataSource = dsName};

            AxFormGroupControl overviewGroupControl = new AxFormGroupControl
            {
                Name = "Overview", DataGroup = "Overview", DataSource = dsName
            };

            axFormGridControl.AddControl(overviewGroupControl);
            newForm.Design.AddControl(axFormGridControl);

            _axHelper.MetaModelService.CreateForm(newForm, _axHelper.ModelSaveInfo);
            _axHelper.AppendToActiveProject(newForm);
        }


        void DoTableCreate()
        {
            if (_axHelper == null)
            {
                _axHelper = new AxHelper();
            }

            AxTable newTable = _axHelper.MetadataProvider.Tables.Read(TableName);
            if (newTable == null)
            {
                newTable                  = new AxTable();
                newTable.Name             = TableName;
                newTable.Label            = TableLabel;
                newTable.TitleField1      = KeyFieldName;
                newTable.CacheLookup      = RecordCacheLevel.Found;
                newTable.ClusteredIndex   = $"{KeyFieldName}Idx";
                newTable.PrimaryIndex     = newTable.ClusteredIndex;
                newTable.ReplacementKey   = newTable.ClusteredIndex;
                newTable.TableGroup       = TableGroup.Group;
                newTable.CreatedBy        = NoYes.Yes;
                newTable.CreatedDateTime  = NoYes.Yes;
                newTable.ModifiedBy       = NoYes.Yes;
                newTable.ModifiedDateTime = NoYes.Yes;

                AxTableField primaryField = new AxTableFieldString();
                primaryField.Name              = KeyFieldName;
                primaryField.ExtendedDataType  = PrimaryKeyEDTName;
                primaryField.IgnoreEDTRelation = NoYes.Yes;
                primaryField.AllowEdit         = NoYes.No;
                primaryField.Mandatory         = NoYes.Yes;
                newTable.AddField(primaryField);

                AxTableIndexField axTableIndexField = new AxTableIndexField();
                axTableIndexField.DataField = KeyFieldName;
                axTableIndexField.Name      = KeyFieldName;
                AxTableIndex axTableIndex = new AxTableIndex();
                axTableIndex.Name         = newTable.ClusteredIndex;
                axTableIndex.AlternateKey = NoYes.Yes;
                axTableIndex.AddField(axTableIndexField);
                newTable.AddIndex(axTableIndex);

                AxTableFieldGroup axTableFieldGroup;
                AxTableFieldGroupField axTableFieldGroupField;

                axTableFieldGroup = new AxTableFieldGroup { Name = "AutoReport", IsSystemGenerated = NoYes.Yes};
                axTableFieldGroupField = new AxTableFieldGroupField
                {
                    Name      = KeyFieldName,
                    DataField = KeyFieldName
                };
                axTableFieldGroup.AddField(axTableFieldGroupField);
                newTable.AddFieldGroup(axTableFieldGroup);

                axTableFieldGroup = new AxTableFieldGroup { Name = "AutoLookup", IsSystemGenerated = NoYes.Yes };
                newTable.AddFieldGroup(axTableFieldGroup);

                axTableFieldGroup = new AxTableFieldGroup { Name = "AutoIdentification", IsSystemGenerated = NoYes.Yes, AutoPopulate = NoYes.Yes};
                newTable.AddFieldGroup(axTableFieldGroup);

                axTableFieldGroup = new AxTableFieldGroup { Name = "AutoSummary", IsSystemGenerated = NoYes.Yes };
                newTable.AddFieldGroup(axTableFieldGroup);

                axTableFieldGroup = new AxTableFieldGroup { Name = "AutoBrowse", IsSystemGenerated = NoYes.Yes };
                newTable.AddFieldGroup(axTableFieldGroup);

                axTableFieldGroup = new AxTableFieldGroup {Name = "Overview", Label = "Overview"};
                axTableFieldGroupField = new AxTableFieldGroupField
                {
                    Name = KeyFieldName, DataField = KeyFieldName
                };
                axTableFieldGroup.AddField(axTableFieldGroupField);
                newTable.AddFieldGroup(axTableFieldGroup);

                AddTableFindMethodParms findMethodParms = new AddTableFindMethodParms();
                findMethodParms.IsCreateFind = true;
                findMethodParms.IsTestMode   = true;
                findMethodParms.TableName    = TableName;
                findMethodParms.VarName      = TableVarName;
                findMethodParms.Fields = new List<AxTableFieldParm>
                {
                    new AxTableFieldParm
                    {
                        FieldName = KeyFieldName, FieldType = PrimaryKeyEDTName, IsMandatory = true
                    }
                };

                AxMethod axMethod = new AxMethod();
                axMethod.Name     = "find";
                axMethod.IsStatic = true;
                axMethod.Source   = findMethodParms.GenerateResult();
                newTable.AddMethod(axMethod);

                _axHelper.MetaModelService.CreateTable(newTable, _axHelper.ModelSaveInfo);
                _axHelper.AppendToActiveProject(newTable);

                AxEdt edtLocal = _axHelper.MetadataProvider.Edts.Read(PrimaryKeyEDTName);
                if (edtLocal != null)
                {
                    edtLocal.ReferenceTable = TableName;
                    edtLocal.AddTableReference(TableName, KeyFieldName);

                    _axHelper.MetaModelService.UpdateExtendedDataType(edtLocal, _axHelper.ModelSaveInfo);
                    _axHelper.AppendToActiveProject(edtLocal);
                }


            }
        }

    }
}

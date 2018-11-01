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
                newTable.CacheLookup      = RecordCacheLevel.NotInTTS;
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

                AxTableFieldGroup axTableFieldGroup = new AxTableFieldGroup();
                axTableFieldGroup.Name = "Overview";
                axTableFieldGroup.Label = "Overview";
                AxTableFieldGroupField axTableFieldGroupField = new AxTableFieldGroupField();
                axTableFieldGroupField.Name = KeyFieldName;
                axTableFieldGroupField.DataField = KeyFieldName;
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

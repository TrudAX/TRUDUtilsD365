using System.Linq;
using TRUDUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using TRUDUtilsD365.TableFieldsBuilder;


namespace TRUDUtilsD365.CreateTableRelation
{
    public class CreateTableRelationParms
    {
        public string RelationName { get; set; } = "";

        public string SelectedField { get; set; } = "";
        public string TableName { get; set; } = "";

        public AxTableRelationForeignKey TableRelationForeignKey { get; set; }
        private AxTable          _axTable;
        private AxTableExtension _axTableExtension;

        private AxHelper _axHelper;

        private string _logString;

        void AddLog(string logLocal)
        {
            _logString += logLocal;
        }

        public void DisplayLog()
        {
            CoreUtility.DisplayInfo($"The following element({_logString}) was created and added to the project");
        }

        public void ValidateData()
        {
           if (string.IsNullOrWhiteSpace(RelationName) || string.IsNullOrWhiteSpace(TableName))
            {
                throw new System.Exception($"Object name should be specified");
            }            
        }

        public void InitFromSelectedElement(AddinDesignerEventArgs e)
        {
            if (_axHelper == null)
            {
                _axHelper = new AxHelper();
            }

            BaseField baseField = e.SelectedElements.OfType<BaseField>().First();
            SelectedField = baseField.Name;

            TableName = baseField.Table != null ? baseField.Table.GetMetadataType().Name : baseField.TableExtension?.GetMetadataType().Name;

            NewFieldEngine newFieldEngine = new NewFieldEngine();
            newFieldEngine.GetSetHelper = _axHelper;

            if (TableName.Contains(".") == false)
            {
                _axTable = _axHelper.MetadataProvider.Tables.Read(TableName);
                AxTableField axTableField = _axTable.Fields[baseField.Name];

                TableRelationForeignKey = newFieldEngine.AddTableRelation(axTableField, _axTable.Relations);
            }
            else
            {
                _axTableExtension = _axHelper.MetadataProvider.TableExtensions.Read(TableName);
                AxTableField axTableField = _axTableExtension.Fields[baseField.Name];

                TableRelationForeignKey = newFieldEngine.AddTableRelation(axTableField, _axTableExtension.Relations);
            }

            if (TableRelationForeignKey == null)
            {
                throw new System.Exception($"Field {baseField.Name} doesn't have an EDT relation");
            }

            RelationName = TableRelationForeignKey.Name;
        }

        public void Run()
        {
            _logString = "";
            ValidateData();
            if (_axHelper == null)
            {
                _axHelper = new AxHelper();
            }
            DoRelationCreate();
        }

      
        void DoRelationCreate()
        {
            TableRelationForeignKey.Name = RelationName;

            if (_axTable != null)
            {
                _axTable.AddRelation(TableRelationForeignKey);
                _axHelper.MetadataProvider.Tables.Update(_axTable, _axHelper.ModelSaveInfo);
                _axHelper.AppendToActiveProject(_axTable);
            } else 
            if (_axTableExtension != null)
            {
                _axTableExtension.Relations.Add(TableRelationForeignKey);
                _axHelper.MetadataProvider.TableExtensions.Update(_axTableExtension, _axHelper.ModelSaveInfo);
                _axHelper.AppendToActiveProject(_axTableExtension);
            }

            AddLog($"Relation: {RelationName}; ");
        }

    }
}

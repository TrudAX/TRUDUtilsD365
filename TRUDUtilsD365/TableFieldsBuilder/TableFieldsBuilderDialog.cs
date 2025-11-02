using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUDUtilsD365.Kernel;

namespace TRUDUtilsD365.TableFieldsBuilder
{
    public partial class TableFieldsBuilderDialog : Form
    {
        private TableFieldsBuilderParms _parms;
        public void SetParameters(TableFieldsBuilderParms parms)
        {
            _parms = parms;
            tableFieldsBuilderParmsBindingSource.Add(parms);

            FieldTypeBox.DataSource = Enum.GetValues(typeof(FieldType));

            FieldGroupBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            FieldGroupBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            FieldGroupBox.DropDownStyle = ComboBoxStyle.DropDown;

            PopulateFieldGroupLookup();

        }
        public TableFieldsBuilderDialog()
        {
            InitializeComponent();
        }
        private void PopulateFieldGroupLookup()
        {
            FieldGroupBox.Items.Clear();

            if (_parms == null || string.IsNullOrWhiteSpace(_parms.TableName))
            {
                return;
            }

            try
            {
                AxHelper axHelper = new AxHelper();
                var groupNames = new List<string>();

                if (_parms.TableName.Contains("."))
                {
                    var tableExtension = axHelper.MetadataProvider.TableExtensions.Read(_parms.TableName);
                    if (tableExtension != null)
                    {
                        foreach (AxTableFieldGroup fieldGroup in tableExtension.FieldGroups)
                        {
                            AddFieldGroupName(groupNames, fieldGroup);
                        }
                    }
                }
                else
                {
                    var table = axHelper.MetadataProvider.Tables.Read(_parms.TableName);
                    if (table != null)
                    {
                        foreach (AxTableFieldGroup fieldGroup in table.FieldGroups)
                        {
                            AddFieldGroupName(groupNames, fieldGroup);
                        }
                    }
                }

                foreach (string groupName in groupNames
                             .Where(name => !string.IsNullOrWhiteSpace(name))
                             .Distinct(StringComparer.OrdinalIgnoreCase)
                             .OrderBy(name => name, StringComparer.OrdinalIgnoreCase))
                {
                    FieldGroupBox.Items.Add(groupName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static readonly string[] DefaultAutoFieldGroups =
        {
            "AutoBrowse",
            "AutoIdentification",
            "AutoLookup",
            "AutoReport",
            "AutoSummary"
        };

        private static void AddFieldGroupName(ICollection<string> groupNames, AxTableFieldGroup fieldGroup)
        {
            if (fieldGroup != null && !string.IsNullOrWhiteSpace(fieldGroup.Name))
            {
                if (!DefaultAutoFieldGroups.Contains(fieldGroup.Name, StringComparer.OrdinalIgnoreCase))
                {
                    groupNames.Add(fieldGroup.Name);
                }
            }
        }

        void UpdateParms()
        {
            _parms.IsOneFieldMode = false;
            _parms.OneFieldData = null;
            if (tabControl1.SelectedTab == tabPage2)
            {
                NewFieldEngine oneFieldForm = new NewFieldEngine();
                oneFieldForm.FieldType     = (FieldType) FieldTypeBox.SelectedItem;
                oneFieldForm.FieldName     = FieldNameBox.Text.Trim();
                oneFieldForm.EdtText       = EDTNameBox.Text.Trim();
                oneFieldForm.ExtendsText   = EDTExtendsBox.Text.Trim();
                oneFieldForm.LabelText     = LabelBox.Text.Trim();
                oneFieldForm.HelpTextText  = HelpTextBox.Text.Trim();
                int strLen;
                int.TryParse(StrLenBox.Text.Trim(), out strLen);
                oneFieldForm.NewStrEdtLen    = strLen;
                oneFieldForm.GroupName       = FieldGroupBox.Text.Trim();
                oneFieldForm.GroupLabel      = FieldGroupLabelBox.Text.Trim();
                oneFieldForm.IsMandatory     = MandatoryCheckBox.Checked;
                oneFieldForm.IsDisplayMethod = IsDisplayMethodCheckBox.Checked;

                _parms.IsOneFieldMode = true;
                _parms.OneFieldData   = oneFieldForm;

            }

            //if(Tabpage)
        }

        private void UpdatePreviewButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateParms();
                PreviewTextBox.Text = _parms.GetPreviewString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateParms();
                _parms.AddFields();

                _parms.DisplayLog();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void GetTemplateButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialogTemplate.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialogTemplate.FileName;
                var byteRes = Properties.Resources.TableFieldsBuilderTemplateV11;

                File.WriteAllBytes(fileName, byteRes);

                System.Diagnostics.Process.Start(fileName);
            }
        }

        private void LabelBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LabelBox_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(FieldNameBox.Text) && !String.IsNullOrWhiteSpace(LabelBox.Text))
            {
                FieldNameBox.Text = AxHelper.GetTypeNameFromLabel(LabelBox.Text.Trim());
            }
        }
    }
}

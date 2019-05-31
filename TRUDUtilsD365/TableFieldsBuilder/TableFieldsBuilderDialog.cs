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
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
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
        }
        public TableFieldsBuilderDialog()
        {
            InitializeComponent();
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

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

namespace TRUDUtilsD365.TableFieldsBuilder
{
    public partial class TableFieldsBuilderDialog : Form
    {
        private TableFieldsBuilderParms _parms;
        public void SetParameters(TableFieldsBuilderParms parms)
        {
            _parms = parms;
            tableFieldsBuilderParmsBindingSource.Add(parms);
        }
        public TableFieldsBuilderDialog()
        {
            InitializeComponent();
        }

        private void UpdatePreviewButton_Click(object sender, EventArgs e)
        {
            try
            {
                PreviewTextBox.Text = _parms.GetPreviewString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void GetTemplateButton_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialogTemplate.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialogTemplate.FileName;
                var byteRes = Properties.Resources.TableFieldsBuilderTemplateV1;

                File.WriteAllBytes(fileName, byteRes);
            }
        }
    }
}

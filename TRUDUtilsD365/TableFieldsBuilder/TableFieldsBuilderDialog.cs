using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            PreviewTextBox.Text = _parms.GetPreviewString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

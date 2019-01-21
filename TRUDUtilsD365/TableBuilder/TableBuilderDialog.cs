using System;
using System.Windows.Forms;
using TRUDUtilsD365.Kernel;

namespace TRUDUtilsD365.TableBuilder
{
    public partial class TableBuilderDialog : Form
    {
        private TableBuilderParms _parms;

        public TableBuilderDialog()
        {
            InitializeComponent();
        }
        public void SetParameters(TableBuilderParms parms)
        {
            _parms = parms;
            tableBuilderParmsBindingSource.Add(parms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {                
                _parms.CreateTable();

                _parms.DisplayLog();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void TableNameTextBox_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TableVarNameTextBox.Text) && !String.IsNullOrWhiteSpace(TableNameTextBox.Text))
            {
                TableVarNameTextBox.Text = AxHelper.GetVarNameFromType(TableNameTextBox.Text.Trim());
                _parms.TableVarName = TableVarNameTextBox.Text;
            }
        }
    }
}

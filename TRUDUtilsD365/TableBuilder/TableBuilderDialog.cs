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

            if (!String.IsNullOrWhiteSpace(TableNameTextBox.Text))
            {
                FormNameTextBox.Text = TableNameTextBox.Text;
                _parms.FormName = FormNameTextBox.Text;

                TableVarNameTextBox.Text = AxHelper.GetVarNameFromType(TableNameTextBox.Text.Trim());
                _parms.TableVarName = TableVarNameTextBox.Text;
                if (!_parms.IsExternalEDT)
                {
                    PrimaryKeyEDTTextBox.Text = $@"{TableNameTextBox.Text}Id";
                    _parms.PrimaryKeyEdtName = PrimaryKeyEDTTextBox.Text;
                }

                FieldNameTextBox.Text = $@"{AxHelper.UppercaseWords(TableVarNameTextBox.Text)}Id";
                _parms.KeyFieldName = FieldNameTextBox.Text;
            }
        }

        private void TableLabelTextBox_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TableLabelTextBox.Text))
            {
                FormLabelTextBox.Text = TableLabelTextBox.Text;
                _parms.FormLabel      = FormLabelTextBox.Text;

                FormHelpTextBox.Text = $"Set up {AxHelper.PrettyName(TableLabelTextBox.Text)}";
                _parms.FormHelp      = FormHelpTextBox.Text;

                PrivilegeLabelViewTextBox.Text = $"{_parms.FormLabel} view";
                _parms.PrivilegeLabelView = PrivilegeLabelViewTextBox.Text;

                PrivilegeLabelMaintainTextBox.Text = $"{_parms.FormLabel} maintain";
                _parms.PrivilegeLabelMaintain = PrivilegeLabelMaintainTextBox.Text;
            }
        }

        private void EDTLabeltextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(EDTLabeltextBox.Text) && (_parms.EdtLabel != EDTLabeltextBox.Text))
            {
                EDTHelpTextBox.Text = $"Identification of the {AxHelper.PrettyName(EDTLabeltextBox.Text)}";
                _parms.EdtHelpText = EDTHelpTextBox.Text;
            }
        }
    }
}

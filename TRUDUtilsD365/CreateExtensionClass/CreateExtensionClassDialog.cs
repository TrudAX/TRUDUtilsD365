using System;
using System.Windows.Forms;

namespace TRUDUtilsD365.CreateExtensionClass
{
    public partial class CreateExtensionClassDialog : Form
    {
        private CreateExtensionClassParms _parms;


        public CreateExtensionClassDialog()
        {
            InitializeComponent();
        }

        public void SetParameters(CreateExtensionClassParms parms)
        {
            _parms = parms;

            comboBox1.DataSource = Enum.GetValues(parms.ClassType.GetType());
            ElementTypeComboBox.DataSource = Enum.GetValues(parms.ElementType.GetType());

            createExtensionClassParmsBindingSource.Add(_parms);

            UpdateResult();
        }

        private void UpdateResult()
        {
            _parms.CalcResultName();
            ResultClassNameTextBox.Text = _parms.ResultClassName;
        }


        private void RestoreNameButton_Click(object sender, EventArgs e)
        {
            UpdateResult();
            //this.createExtensionClassParmsBindingSource.
        }

        private void ElementTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }

        private void PrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }

        private void ElementNameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }

        private void CreateClassButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
using System;
using System.Windows.Forms;

namespace TRUDUtilsD365.FormTemplateControlBuilder
{
    public partial class FormTemplateControlBuilderDialog : Form
    {
        private FormTemplateControlBuilderParms _parms;

        public FormTemplateControlBuilderDialog()
        {
            InitializeComponent();
        }

        public void SetParameters(FormTemplateControlBuilderParms parms)
        {
            _parms = parms;

            FormNameTextBox.Text = parms.FormName;
            TemplateTextBox.Text = parms.TemplateDisplay;
            MessageLabel.Text = parms.StatusMessage();
            AddOptionalCheckBox.Checked = parms.AddOptionalControls;
            AddOptionalCheckBox.Enabled = parms.CanRun;
            buttonOk.Enabled = parms.CanRun;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                _parms.AddOptionalControls = AddOptionalCheckBox.Checked;
                _parms.Run();
                _parms.DisplayLog();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

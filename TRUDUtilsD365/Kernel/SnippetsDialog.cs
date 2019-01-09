using System;
using System.Windows.Forms;

namespace TRUDUtilsD365.Kernel
{
    public partial class SnippetsDialog : Form
    {
        private SnippetsParms _parms;

        public SnippetsDialog()
        {
            InitializeComponent();
        }

        public void SetParameters(SnippetsParms parms)
        {
            _parms = parms;
            snippetsParmsBindingSource.Add(_parms);
            this.Text = _parms.SnippetName;
        }


        private void ShowResultButton_Click(object sender, EventArgs e)
        {
            //UpdateFromForm();
            try
            {
                _parms.ParseValues();
                SnippedCreateAction sa = _parms.PreviewAction as SnippedCreateAction;
                if (sa != null)
                {
                    sa.IsPreviewMode = true;
                }
                _parms.PreviewAction.InitFromSnippetsParms(_parms);
                ResultTextBox.Text = _parms.PreviewAction.RunPreview();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } 
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(ResultTextBox.Text);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (_parms.CreateAction != null)
            {
                try
                {
                    _parms.ParseValues();
                    _parms.CreateAction.InitFromSnippetsParms(_parms);
                    _parms.CreateAction.RunCreateLog();

                    _parms.CreateAction.DisplayLog();
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
}
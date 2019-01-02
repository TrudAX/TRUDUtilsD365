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


            /*
            MethodTypeCheckedListBox.Items.Clear();
            MethodTypeCheckedListBox.Items.Add("find", _parms.IsCreateFind);
            MethodTypeCheckedListBox.Items.Add("exists", _parms.IsCreateExists);
            MethodTypeCheckedListBox.Items.Add("findRecId", _parms.IsCreateFindRecId);

            UpdateFromForm();
            ResultTextBox.Text = _parms.GenerateResult();
            */
        }


        private void ShowResultButton_Click(object sender, EventArgs e)
        {
            //UpdateFromForm();
            try
            {
                _parms.ParseValues();
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
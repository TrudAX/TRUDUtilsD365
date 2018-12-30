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

            //ResultTextBox.Text = _parms.GenerateResult();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(ResultTextBox.Text);
        }

     
    }
}
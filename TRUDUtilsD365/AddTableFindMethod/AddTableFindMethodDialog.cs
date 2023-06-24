using System;
using System.Windows.Forms;

namespace TRUDUtilsD365.AddTableFindMethod
{
    public partial class AddTableFindMethodDialog : Form
    {
        private AddTableFindMethodParms _parms;

        public AddTableFindMethodDialog()
        {
            InitializeComponent();
        }

        public void SetParameters(AddTableFindMethodParms parms)
        {
            _parms = parms;

            addTableFindMethodParmsBindingSource.Add(_parms);

            MethodTypeCheckedListBox.Items.Clear();
            MethodTypeCheckedListBox.Items.Add("find", _parms.IsCreateFind);
            MethodTypeCheckedListBox.Items.Add("exists", _parms.IsCreateExists);
            MethodTypeCheckedListBox.Items.Add("findRecId", _parms.IsCreateFindRecId);
            MethodTypeCheckedListBox.Items.Add("txtNotExists", _parms.IsTxtNotExists);
            MethodTypeCheckedListBox.Items.Add("checkExists", _parms.IsCheckExists);
            UpdateFromForm();
            ResultTextBox.Text = _parms.GenerateResult();

        }

        private void UpdateFromForm()
        {
            for (int i = 0; i <= MethodTypeCheckedListBox.Items.Count - 1; i++)
            {
                var itemLoc = MethodTypeCheckedListBox.Items[i];
                switch (itemLoc.ToString())
                {
                    case "find":
                        _parms.IsCreateFind = MethodTypeCheckedListBox.GetItemChecked(i);
                        break;
                    case "findRecId":
                        _parms.IsCreateFindRecId = MethodTypeCheckedListBox.GetItemChecked(i);
                        break;
                    case "exists":
                        _parms.IsCreateExists = MethodTypeCheckedListBox.GetItemChecked(i);
                        break;
                    case "txtNotExists":
                        _parms.IsTxtNotExists = MethodTypeCheckedListBox.GetItemChecked(i);
                        break;
                    case "checkExists":
                        _parms.IsCheckExists = MethodTypeCheckedListBox.GetItemChecked(i);
                        break;
                }
            }
        }

        private void ShowResultButton_Click(object sender, EventArgs e)
        {
            UpdateFromForm();

            ResultTextBox.Text = _parms.GenerateResult();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(ResultTextBox.Text);
        }
    }
}
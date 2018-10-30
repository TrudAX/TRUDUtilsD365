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


            //BindingList<AddTableFindMethodParms> bookProperty = new BindingList<AddTableFindMethodParms>();
            //bookProperty.Add(parms);
            //MethodNameControl.DataBindings.Add("Text", bookProperty[0], "MethodName");
            //MethodNameControl.DataBindings.Add("Text", parms, "MethodName", false, DataSourceUpdateMode.OnPropertyChanged);
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
                }
            }
        }

        private void ShowResultButton_Click(object sender, EventArgs e)
        {
            UpdateFromForm();

            ResultTextBox.Text = _parms.GenerateResult();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void MethodNameControl_TextChanged(object sender, EventArgs e)
        {
        }

        private void TableNameControl_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRUDUtilsD365.AddTableFindMethod
{
    public partial class AddTableFindMethodDialog : Form
    {
        AddTableFindMethodParms parms;

        public AddTableFindMethodDialog()
        {
            InitializeComponent();
        }

        public void setParameters(AddTableFindMethodParms _parms)
        {
            parms = _parms;

            this.addTableFindMethodParmsBindingSource.Add(parms);

            MethodTypeCheckedListBox.Items.Clear();
            MethodTypeCheckedListBox.Items.Add("find",      parms.IsCreateFind);
            MethodTypeCheckedListBox.Items.Add("exists",    parms.IsCreateExists);
            MethodTypeCheckedListBox.Items.Add("findRecId", parms.IsCreateFindRecId);


            //BindingList<AddTableFindMethodParms> bookProperty = new BindingList<AddTableFindMethodParms>();
            //bookProperty.Add(parms);
            //MethodNameControl.DataBindings.Add("Text", bookProperty[0], "MethodName");
            //MethodNameControl.DataBindings.Add("Text", parms, "MethodName", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        void updateFromForm()
        {
            for (int i = 0; i <= (MethodTypeCheckedListBox.Items.Count - 1); i++)
            {
                var itemLoc = MethodTypeCheckedListBox.Items[i];
                switch(itemLoc.ToString())
                {
                    case "find":
                        parms.IsCreateFind = MethodTypeCheckedListBox.GetItemChecked(i);
                        break;
                    case "findRecId":
                        parms.IsCreateFindRecId = MethodTypeCheckedListBox.GetItemChecked(i);
                        break;
                    case "exists":
                        parms.IsCreateExists = MethodTypeCheckedListBox.GetItemChecked(i);
                        break;
                }
                
            }
        }

        private void ShowResultButton_Click(object sender, EventArgs e)
        {
            this.updateFromForm();

            ResultTextBox.Text = parms.generateResult();
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

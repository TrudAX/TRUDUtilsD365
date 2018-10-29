using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRUDUtilsD365.CreateExtensionClass
{
    public partial class CreateExtensionClassDialog : Form
    {
        CreateExtensionClassParms parms;


        public CreateExtensionClassDialog()
        {
            InitializeComponent();
        }
        public void setParameters(CreateExtensionClassParms _parms)
        {
            
            parms = _parms;

            this.comboBox1.DataSource           = Enum.GetValues(_parms.ClassType.GetType());
            this.ElementTypeComboBox.DataSource = Enum.GetValues(_parms.ElementType.GetType());

            this.createExtensionClassParmsBindingSource.Add(parms);

            this.UpdateResult();
        }

        void UpdateResult()
        {
            parms.calcResultName();
            ResultClassNameTextBox.Text = parms.ResultClassName;
        }


        private void RestoreNameButton_Click(object sender, EventArgs e)
        {
            this.UpdateResult();
            //this.createExtensionClassParmsBindingSource.
        }

        private void ElementTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateResult();
        }

        private void PrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateResult();
        }

        private void ElementNameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateResult();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            this.UpdateResult();
        }

        private void CreateClassButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

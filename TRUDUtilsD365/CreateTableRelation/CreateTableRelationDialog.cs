using System;
using System.Windows.Forms;

namespace TRUDUtilsD365.CreateTableRelation
{
    public partial class CreateTableRelationDialog : Form
    {
        private CreateTableRelationParms _parms;

        public CreateTableRelationDialog()
        {
            InitializeComponent();
        }
        public void SetParameters(CreateTableRelationParms parms)
        {
            _parms = parms;

            createTableRelationParmsBindingSource.Add(parms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
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

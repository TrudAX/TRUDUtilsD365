using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRUDUtilsD365.TableBuilder
{
    public partial class TableBuilderDialog : Form
    {
        private TableBuilderParms _parms;

        public TableBuilderDialog()
        {
            InitializeComponent();
        }
        public void SetParameters(TableBuilderParms parms)
        {
            _parms = parms;
            tableBuilderParmsBindingSource.Add(parms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {                
                _parms.CreateTable();

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

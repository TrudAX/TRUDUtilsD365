using System;
using System.Windows.Forms;

namespace TRUDUtilsD365.MenuItemBuilder
{
    public partial class MenuItemBuilderDialog : Form
    {
        private MenuItemBuilderParms _parms;

        public MenuItemBuilderDialog()
        {
            InitializeComponent();
        }
        public void SetParameters(MenuItemBuilderParms parms)
        {
            _parms = parms;
            comboBox1.DataSource = Enum.GetValues(_parms.MenuItemType.GetType());
            menuItemBuilderParmsBindingSource.Add(parms);
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

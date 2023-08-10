using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRUDUtilsD365.SysOperationBuilder
{
    public partial class SysOperationBuilderDialog : Form
    {
        private SysOperationBuilderParms _parms;
        public SysOperationBuilderDialog()
        {
            InitializeComponent();
        }
        public void SetParameters(SysOperationBuilderParms parms)
        {
            _parms = parms;
            sysOperationBuilderParmsBindingSource.Add(parms);
        }

        private void CreateSysOperationButton_Click(object sender, EventArgs e)
        {
            try
            {
                _parms.CreateSysOperation();

                _parms.DisplayLog();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                //TODO: Da ripristinare al precendete messaggio
                //MessageBox.Show(ex.Message, @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString(), @"An exception occurred:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateControllerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                ControllerClassNameTextBox.Enabled = checkBox.Checked;
                ControllerExtendsClassTextBox.Enabled = checkBox.Checked;
                ControllerImplementsClassTextBox.Enabled = checkBox.Checked;
            }
        }

        private void CreateDataContractCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                ContractClassNameTextBox.Enabled = checkBox.Checked;
                ContractExtendsClassTextBox.Enabled = checkBox.Checked;
                ContractImplementsClassTextBox.Enabled = checkBox.Checked;
                ContractIsValidatableCheckBox.Enabled = checkBox.Checked;
            }
        }

        private void CreateUIBuilderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                UIBuilderClassNameTextBox.Enabled = checkBox.Checked;
                UIBuilderExtendsClassTextBox.Enabled = checkBox.Checked;
                UIBuilderImplementsClassTextBox.Enabled = checkBox.Checked;
            }
        }

        private void CreateMenuItemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                MenuItemNameTextBox.Enabled = checkBox.Checked;
                MenuItemLabelTextBox.Enabled = checkBox.Checked;
            }
        }

        private void CreateMaintainPrivilegeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                MaintainPrivilegeNameTextBox.Enabled = checkBox.Checked;
                MaintainPrivilegeLabelTextBox.Enabled = checkBox.Checked;
            }
        }
    }
}

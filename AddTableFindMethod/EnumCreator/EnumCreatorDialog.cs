using System;
using System.Windows.Forms;

namespace TRUDUtilsD365.EnumCreator
{
    public partial class EnumCreatorDialog : Form
    {
        private EnumCreatorParms _parms;

        public EnumCreatorDialog()
        {
            InitializeComponent();
        }
        public void SetParameters(EnumCreatorParms parms)
        {
            _parms = parms;
            enumCreatorParmsBindingSource.Add(parms);
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            PreviewTextBox.Text = _parms.GetPreviewString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }


        private void IsCreateTypeCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (_parms.IsCreateEnumTypeModified())
            { 
                enumCreatorParmsBindingSource.ResetBindings(false);
            }
        }

        private void EnumLabelTextBox_Validated(object sender, EventArgs e)
        {
            if (_parms.EnumLabelModified())
            { 
                enumCreatorParmsBindingSource.ResetBindings(false);
            }
        }

    }
}

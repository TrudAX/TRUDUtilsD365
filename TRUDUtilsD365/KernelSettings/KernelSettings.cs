using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRUDUtilsD365.KernelSettings
{
    public partial class KernelSettings : Form
    {
        private KernelSettingsManager _kernelSettingsManager;

        public KernelSettings()
        {
            InitializeComponent();

            _kernelSettingsManager = new KernelSettingsManager();
            _kernelSettingsManager.LoadSettingsOrDefault();

            string templateType, templateName;

            _kernelSettingsManager.InitFormControlData(out templateType, out templateName);
            ParametersBox.Text = templateType;
            ValuesControl.Text = templateName;

            DescriptionBox.Text = _kernelSettingsManager.GetDescription();
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            _kernelSettingsManager.SaveFormControlData(ValuesControl.Text);
        }
    }
}

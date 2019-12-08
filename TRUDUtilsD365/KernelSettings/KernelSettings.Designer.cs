namespace TRUDUtilsD365.KernelSettings
{
    partial class KernelSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ClassExtensionNameTab = new System.Windows.Forms.TabPage();
            this.AboutTabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ParametersBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ValuesControl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SetDefaultButton = new System.Windows.Forms.Button();
            this.SettingsTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.ClassExtensionNameTab.SuspendLayout();
            this.AboutTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.ClassExtensionNameTab);
            this.tabControl1.Controls.Add(this.AboutTabPage);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 474);
            this.tabControl1.TabIndex = 21;
            // 
            // ClassExtensionNameTab
            // 
            this.ClassExtensionNameTab.Controls.Add(this.linkLabel2);
            this.ClassExtensionNameTab.Controls.Add(this.FileNameTextBox);
            this.ClassExtensionNameTab.Controls.Add(this.label4);
            this.ClassExtensionNameTab.Controls.Add(this.SettingsTypeComboBox);
            this.ClassExtensionNameTab.Controls.Add(this.SetDefaultButton);
            this.ClassExtensionNameTab.Controls.Add(this.label2);
            this.ClassExtensionNameTab.Controls.Add(this.DescriptionBox);
            this.ClassExtensionNameTab.Controls.Add(this.SaveButton);
            this.ClassExtensionNameTab.Controls.Add(this.ParametersBox);
            this.ClassExtensionNameTab.Controls.Add(this.label3);
            this.ClassExtensionNameTab.Controls.Add(this.ValuesControl);
            this.ClassExtensionNameTab.Controls.Add(this.label1);
            this.ClassExtensionNameTab.Location = new System.Drawing.Point(4, 22);
            this.ClassExtensionNameTab.Name = "ClassExtensionNameTab";
            this.ClassExtensionNameTab.Padding = new System.Windows.Forms.Padding(3);
            this.ClassExtensionNameTab.Size = new System.Drawing.Size(710, 448);
            this.ClassExtensionNameTab.TabIndex = 0;
            this.ClassExtensionNameTab.Text = "Class extension name";
            this.ClassExtensionNameTab.UseVisualStyleBackColor = true;
            // 
            // AboutTabPage
            // 
            this.AboutTabPage.Controls.Add(this.textBox1);
            this.AboutTabPage.Controls.Add(this.linkLabel1);
            this.AboutTabPage.Location = new System.Drawing.Point(4, 22);
            this.AboutTabPage.Name = "AboutTabPage";
            this.AboutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AboutTabPage.Size = new System.Drawing.Size(924, 493);
            this.AboutTabPage.TabIndex = 1;
            this.AboutTabPage.Text = "About";
            this.AboutTabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Name template for class extensions";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DescriptionBox.Location = new System.Drawing.Point(6, 32);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(424, 59);
            this.DescriptionBox.TabIndex = 26;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(438, 68);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 25;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click_1);
            // 
            // ParametersBox
            // 
            this.ParametersBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ParametersBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ParametersBox.Location = new System.Drawing.Point(0, 110);
            this.ParametersBox.Multiline = true;
            this.ParametersBox.Name = "ParametersBox";
            this.ParametersBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ParametersBox.Size = new System.Drawing.Size(157, 332);
            this.ParametersBox.TabIndex = 24;
            this.ParametersBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ParametersBox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Base Type";
            // 
            // ValuesControl
            // 
            this.ValuesControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValuesControl.BackColor = System.Drawing.SystemColors.Window;
            this.ValuesControl.Location = new System.Drawing.Point(159, 110);
            this.ValuesControl.Multiline = true;
            this.ValuesControl.Name = "ValuesControl";
            this.ValuesControl.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ValuesControl.Size = new System.Drawing.Size(543, 332);
            this.ValuesControl.TabIndex = 22;
            this.ValuesControl.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name template";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 84);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(218, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/TrudAX/TRUDUtilsD365";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(339, 53);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "A set of Dynamics 365 Finance and Operations Visual Studio add-ins that can help " +
    "you to accelerate the development speed";
            // 
            // SetDefaultButton
            // 
            this.SetDefaultButton.Location = new System.Drawing.Point(562, 32);
            this.SetDefaultButton.Name = "SetDefaultButton";
            this.SetDefaultButton.Size = new System.Drawing.Size(112, 23);
            this.SetDefaultButton.TabIndex = 28;
            this.SetDefaultButton.Text = "Load default";
            this.SetDefaultButton.UseVisualStyleBackColor = true;
            this.SetDefaultButton.Click += new System.EventHandler(this.SetDefaultButton_Click);
            // 
            // SettingsTypeComboBox
            // 
            this.SettingsTypeComboBox.FormattingEnabled = true;
            this.SettingsTypeComboBox.Location = new System.Drawing.Point(435, 34);
            this.SettingsTypeComboBox.Name = "SettingsTypeComboBox";
            this.SettingsTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.SettingsTypeComboBox.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Default settings";
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameTextBox.Location = new System.Drawing.Point(519, 70);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.ReadOnly = true;
            this.FileNameTextBox.Size = new System.Drawing.Size(183, 20);
            this.FileNameTextBox.TabIndex = 31;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(185, 16);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(235, 13);
            this.linkLabel2.TabIndex = 32;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Naming guidelines for extensions(docs.microsoft)";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // KernelSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 478);
            this.Controls.Add(this.tabControl1);
            this.Name = "KernelSettings";
            this.Text = "TRUDUtilsD365 Settings";
            this.tabControl1.ResumeLayout(false);
            this.ClassExtensionNameTab.ResumeLayout(false);
            this.ClassExtensionNameTab.PerformLayout();
            this.AboutTabPage.ResumeLayout(false);
            this.AboutTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ClassExtensionNameTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox ParametersBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ValuesControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage AboutTabPage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button SetDefaultButton;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SettingsTypeComboBox;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}
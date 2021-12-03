namespace TRUDUtilsD365.SecurityPrivilegeBuilder
{
    partial class SecurityPrivilegeBuilderDialog
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MenuItemNameTextBox = new System.Windows.Forms.TextBox();
            this.securityPrivilegeBuilderParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrivilegeNameTextBox = new System.Windows.Forms.TextBox();
            this.PrivilegeLabelTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MenuItemTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AccessLevelComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.securityPrivilegeBuilderParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Menu item name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Privilege Label:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Privilege Name:";
            // 
            // MenuItemNameTextBox
            // 
            this.MenuItemNameTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MenuItemNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.securityPrivilegeBuilderParmsBindingSource, "MenuItemName", true));
            this.MenuItemNameTextBox.Location = new System.Drawing.Point(104, 9);
            this.MenuItemNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MenuItemNameTextBox.Name = "MenuItemNameTextBox";
            this.MenuItemNameTextBox.Size = new System.Drawing.Size(252, 20);
            this.MenuItemNameTextBox.TabIndex = 100;
            // 
            // securityPrivilegeBuilderParmsBindingSource
            // 
            this.securityPrivilegeBuilderParmsBindingSource.DataSource = typeof(TRUDUtilsD365.SecurityPrivilegeBuilder.SecurityPrivilegeBuilderParms);
            // 
            // PrivilegeNameTextBox
            // 
            this.PrivilegeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.securityPrivilegeBuilderParmsBindingSource, "ObjectName", true));
            this.PrivilegeNameTextBox.Location = new System.Drawing.Point(104, 120);
            this.PrivilegeNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PrivilegeNameTextBox.Name = "PrivilegeNameTextBox";
            this.PrivilegeNameTextBox.Size = new System.Drawing.Size(252, 20);
            this.PrivilegeNameTextBox.TabIndex = 1;
            // 
            // PrivilegeLabelTextBox
            // 
            this.PrivilegeLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.securityPrivilegeBuilderParmsBindingSource, "FormLabel", true));
            this.PrivilegeLabelTextBox.Location = new System.Drawing.Point(104, 96);
            this.PrivilegeLabelTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PrivilegeLabelTextBox.Name = "PrivilegeLabelTextBox";
            this.PrivilegeLabelTextBox.Size = new System.Drawing.Size(252, 20);
            this.PrivilegeLabelTextBox.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 153);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Create Security Privilege";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MenuItemTypeComboBox
            // 
            this.MenuItemTypeComboBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MenuItemTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.securityPrivilegeBuilderParmsBindingSource, "MenuItemType", true));
            this.MenuItemTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.securityPrivilegeBuilderParmsBindingSource, "MenuItemType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MenuItemTypeComboBox.FormattingEnabled = true;
            this.MenuItemTypeComboBox.Location = new System.Drawing.Point(104, 32);
            this.MenuItemTypeComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MenuItemTypeComboBox.Name = "MenuItemTypeComboBox";
            this.MenuItemTypeComboBox.Size = new System.Drawing.Size(252, 21);
            this.MenuItemTypeComboBox.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Menu item type:";
            // 
            // AccessLevelComboBox
            // 
            this.AccessLevelComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.securityPrivilegeBuilderParmsBindingSource, "AccessLevel", true));
            this.AccessLevelComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.securityPrivilegeBuilderParmsBindingSource, "AccessLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AccessLevelComboBox.FormattingEnabled = true;
            this.AccessLevelComboBox.Location = new System.Drawing.Point(104, 71);
            this.AccessLevelComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AccessLevelComboBox.Name = "AccessLevelComboBox";
            this.AccessLevelComboBox.Size = new System.Drawing.Size(252, 21);
            this.AccessLevelComboBox.TabIndex = 103;
            this.AccessLevelComboBox.SelectedIndexChanged += new System.EventHandler(this.AccessLevelComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "Access Level:";
            // 
            // SecurityPrivilegeBuilderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 199);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AccessLevelComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MenuItemTypeComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PrivilegeNameTextBox);
            this.Controls.Add(this.PrivilegeLabelTextBox);
            this.Controls.Add(this.MenuItemNameTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Name = "SecurityPrivilegeBuilderDialog";
            this.Text = "Create Security Privilege";
            ((System.ComponentModel.ISupportInitialize)(this.securityPrivilegeBuilderParmsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MenuItemNameTextBox;
        private System.Windows.Forms.TextBox PrivilegeNameTextBox;
        private System.Windows.Forms.TextBox PrivilegeLabelTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox MenuItemTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AccessLevelComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource securityPrivilegeBuilderParmsBindingSource;
    }
}
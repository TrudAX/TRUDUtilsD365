namespace TRUDUtilsD365.TableBuilder
{
    partial class TableBuilderDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PrimaryKeyEDTTextBox = new System.Windows.Forms.TextBox();
            this.tableBuilderParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IsCreateTableCheckBox = new System.Windows.Forms.CheckBox();
            this.TableNameTextBox = new System.Windows.Forms.TextBox();
            this.TableLabelTextBox = new System.Windows.Forms.TextBox();
            this.TableVarNameTextBox = new System.Windows.Forms.TextBox();
            this.FormHelpTextBox = new System.Windows.Forms.TextBox();
            this.FormLabelTextBox = new System.Windows.Forms.TextBox();
            this.FormNameTextBox = new System.Windows.Forms.TextBox();
            this.IsCreateFormCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.FieldNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.EDTLabeltextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.EDTHelpTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.EDTExtendsTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.EDTStringSizeTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.PrivilegeLabelMaintainTextBox = new System.Windows.Forms.TextBox();
            this.PrivilegeLabelViewTextBox = new System.Windows.Forms.TextBox();
            this.IsCreatePrivilegeCheckBox = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableBuilderParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create a table?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(25, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Table name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(29, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Table label:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Table var name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Create a form?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Form name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(344, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Form label:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(333, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Form help text:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Primary key EDT:";
            // 
            // PrimaryKeyEDTTextBox
            // 
            this.PrimaryKeyEDTTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "PrimaryKeyEDTName", true));
            this.PrimaryKeyEDTTextBox.Location = new System.Drawing.Point(103, 13);
            this.PrimaryKeyEDTTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PrimaryKeyEDTTextBox.Name = "PrimaryKeyEDTTextBox";
            this.PrimaryKeyEDTTextBox.Size = new System.Drawing.Size(184, 20);
            this.PrimaryKeyEDTTextBox.TabIndex = 9;
            // 
            // tableBuilderParmsBindingSource
            // 
            this.tableBuilderParmsBindingSource.DataSource = typeof(TRUDUtilsD365.TableBuilder.TableBuilderParms);
            // 
            // IsCreateTableCheckBox
            // 
            this.IsCreateTableCheckBox.AutoSize = true;
            this.IsCreateTableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tableBuilderParmsBindingSource, "IsCreateTable", true));
            this.IsCreateTableCheckBox.Location = new System.Drawing.Point(103, 90);
            this.IsCreateTableCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IsCreateTableCheckBox.Name = "IsCreateTableCheckBox";
            this.IsCreateTableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.IsCreateTableCheckBox.TabIndex = 10;
            this.IsCreateTableCheckBox.UseVisualStyleBackColor = true;
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "TableName", true));
            this.TableNameTextBox.Location = new System.Drawing.Point(103, 107);
            this.TableNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(184, 20);
            this.TableNameTextBox.TabIndex = 11;
            this.TableNameTextBox.Validated += new System.EventHandler(this.TableNameTextBox_Validated);
            // 
            // TableLabelTextBox
            // 
            this.TableLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "TableLabel", true));
            this.TableLabelTextBox.Location = new System.Drawing.Point(103, 131);
            this.TableLabelTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TableLabelTextBox.Name = "TableLabelTextBox";
            this.TableLabelTextBox.Size = new System.Drawing.Size(184, 20);
            this.TableLabelTextBox.TabIndex = 12;
            this.TableLabelTextBox.Validated += new System.EventHandler(this.TableLabelTextBox_Validated);
            // 
            // TableVarNameTextBox
            // 
            this.TableVarNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "TableVarName", true));
            this.TableVarNameTextBox.Location = new System.Drawing.Point(103, 155);
            this.TableVarNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TableVarNameTextBox.Name = "TableVarNameTextBox";
            this.TableVarNameTextBox.Size = new System.Drawing.Size(184, 20);
            this.TableVarNameTextBox.TabIndex = 13;
            // 
            // FormHelpTextBox
            // 
            this.FormHelpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "FormHelp", true));
            this.FormHelpTextBox.Location = new System.Drawing.Point(408, 155);
            this.FormHelpTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FormHelpTextBox.Name = "FormHelpTextBox";
            this.FormHelpTextBox.Size = new System.Drawing.Size(205, 20);
            this.FormHelpTextBox.TabIndex = 17;
            // 
            // FormLabelTextBox
            // 
            this.FormLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "FormLabel", true));
            this.FormLabelTextBox.Location = new System.Drawing.Point(408, 131);
            this.FormLabelTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FormLabelTextBox.Name = "FormLabelTextBox";
            this.FormLabelTextBox.Size = new System.Drawing.Size(205, 20);
            this.FormLabelTextBox.TabIndex = 16;
            // 
            // FormNameTextBox
            // 
            this.FormNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "FormName", true));
            this.FormNameTextBox.Location = new System.Drawing.Point(408, 106);
            this.FormNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FormNameTextBox.Name = "FormNameTextBox";
            this.FormNameTextBox.Size = new System.Drawing.Size(205, 20);
            this.FormNameTextBox.TabIndex = 15;
            // 
            // IsCreateFormCheckBox
            // 
            this.IsCreateFormCheckBox.AutoSize = true;
            this.IsCreateFormCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tableBuilderParmsBindingSource, "IsCreateForm", true));
            this.IsCreateFormCheckBox.Location = new System.Drawing.Point(418, 89);
            this.IsCreateFormCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IsCreateFormCheckBox.Name = "IsCreateFormCheckBox";
            this.IsCreateFormCheckBox.Size = new System.Drawing.Size(15, 14);
            this.IsCreateFormCheckBox.TabIndex = 14;
            this.IsCreateFormCheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 218);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Create ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FieldNameTextBox
            // 
            this.FieldNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "KeyFieldName", true));
            this.FieldNameTextBox.Location = new System.Drawing.Point(103, 178);
            this.FieldNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FieldNameTextBox.Name = "FieldNameTextBox";
            this.FieldNameTextBox.Size = new System.Drawing.Size(184, 20);
            this.FieldNameTextBox.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Key field name:";
            // 
            // EDTLabeltextBox
            // 
            this.EDTLabeltextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "EdtLabel", true));
            this.EDTLabeltextBox.Location = new System.Drawing.Point(103, 37);
            this.EDTLabeltextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EDTLabeltextBox.Name = "EDTLabeltextBox";
            this.EDTLabeltextBox.Size = new System.Drawing.Size(184, 20);
            this.EDTLabeltextBox.TabIndex = 22;
            this.EDTLabeltextBox.TextChanged += new System.EventHandler(this.EDTLabeltextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "EDT label:";
            // 
            // EDTHelpTextBox
            // 
            this.EDTHelpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "EdtHelpText", true));
            this.EDTHelpTextBox.Location = new System.Drawing.Point(103, 61);
            this.EDTHelpTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EDTHelpTextBox.Name = "EDTHelpTextBox";
            this.EDTHelpTextBox.Size = new System.Drawing.Size(184, 20);
            this.EDTHelpTextBox.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "EDT help:";
            // 
            // EDTExtendsTextBox
            // 
            this.EDTExtendsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "EdtExtends", true));
            this.EDTExtendsTextBox.Location = new System.Drawing.Point(408, 13);
            this.EDTExtendsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EDTExtendsTextBox.Name = "EDTExtendsTextBox";
            this.EDTExtendsTextBox.Size = new System.Drawing.Size(205, 20);
            this.EDTExtendsTextBox.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(339, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "EDT extends:";
            // 
            // EDTStringSizeTextBox
            // 
            this.EDTStringSizeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "EdtStrLen", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.EDTStringSizeTextBox.Location = new System.Drawing.Point(408, 37);
            this.EDTStringSizeTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EDTStringSizeTextBox.Name = "EDTStringSizeTextBox";
            this.EDTStringSizeTextBox.Size = new System.Drawing.Size(49, 20);
            this.EDTStringSizeTextBox.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(339, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "EDT Str Size:";
            // 
            // PrivilegeLabelMaintainTextBox
            // 
            this.PrivilegeLabelMaintainTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "PrivilegeLabelMaintain", true));
            this.PrivilegeLabelMaintainTextBox.Location = new System.Drawing.Point(408, 220);
            this.PrivilegeLabelMaintainTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PrivilegeLabelMaintainTextBox.Name = "PrivilegeLabelMaintainTextBox";
            this.PrivilegeLabelMaintainTextBox.Size = new System.Drawing.Size(205, 20);
            this.PrivilegeLabelMaintainTextBox.TabIndex = 34;
            // 
            // PrivilegeLabelViewTextBox
            // 
            this.PrivilegeLabelViewTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableBuilderParmsBindingSource, "PrivilegeLabelView", true));
            this.PrivilegeLabelViewTextBox.Location = new System.Drawing.Point(408, 196);
            this.PrivilegeLabelViewTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PrivilegeLabelViewTextBox.Name = "PrivilegeLabelViewTextBox";
            this.PrivilegeLabelViewTextBox.Size = new System.Drawing.Size(205, 20);
            this.PrivilegeLabelViewTextBox.TabIndex = 33;
            // 
            // IsCreatePrivilegeCheckBox
            // 
            this.IsCreatePrivilegeCheckBox.AutoSize = true;
            this.IsCreatePrivilegeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tableBuilderParmsBindingSource, "IsCreatePrivilege", true));
            this.IsCreatePrivilegeCheckBox.Location = new System.Drawing.Point(418, 179);
            this.IsCreatePrivilegeCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IsCreatePrivilegeCheckBox.Name = "IsCreatePrivilegeCheckBox";
            this.IsCreatePrivilegeCheckBox.Size = new System.Drawing.Size(15, 14);
            this.IsCreatePrivilegeCheckBox.TabIndex = 32;
            this.IsCreatePrivilegeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(328, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Maintain label:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(345, 199);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "View label:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(318, 179);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "Create a privilege?";
            // 
            // TableBuilderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 274);
            this.Controls.Add(this.PrivilegeLabelMaintainTextBox);
            this.Controls.Add(this.PrivilegeLabelViewTextBox);
            this.Controls.Add(this.IsCreatePrivilegeCheckBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.EDTStringSizeTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.EDTExtendsTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.EDTHelpTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.EDTLabeltextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.FieldNameTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FormHelpTextBox);
            this.Controls.Add(this.FormLabelTextBox);
            this.Controls.Add(this.FormNameTextBox);
            this.Controls.Add(this.IsCreateFormCheckBox);
            this.Controls.Add(this.TableVarNameTextBox);
            this.Controls.Add(this.TableLabelTextBox);
            this.Controls.Add(this.TableNameTextBox);
            this.Controls.Add(this.IsCreateTableCheckBox);
            this.Controls.Add(this.PrimaryKeyEDTTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TableBuilderDialog";
            this.Text = "Table Builder";
            ((System.ComponentModel.ISupportInitialize)(this.tableBuilderParmsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PrimaryKeyEDTTextBox;
        private System.Windows.Forms.CheckBox IsCreateTableCheckBox;
        private System.Windows.Forms.TextBox TableNameTextBox;
        private System.Windows.Forms.TextBox TableLabelTextBox;
        private System.Windows.Forms.TextBox TableVarNameTextBox;
        private System.Windows.Forms.TextBox FormHelpTextBox;
        private System.Windows.Forms.TextBox FormLabelTextBox;
        private System.Windows.Forms.TextBox FormNameTextBox;
        private System.Windows.Forms.CheckBox IsCreateFormCheckBox;
        private System.Windows.Forms.BindingSource tableBuilderParmsBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox FieldNameTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox EDTLabeltextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox EDTHelpTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox EDTExtendsTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox EDTStringSizeTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox PrivilegeLabelMaintainTextBox;
        private System.Windows.Forms.TextBox PrivilegeLabelViewTextBox;
        private System.Windows.Forms.CheckBox IsCreatePrivilegeCheckBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}
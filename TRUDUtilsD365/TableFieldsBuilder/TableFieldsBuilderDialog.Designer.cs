namespace TRUDUtilsD365.TableFieldsBuilder
{
    partial class TableFieldsBuilderDialog
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
            this.TableNameTextBox = new System.Windows.Forms.TextBox();
            this.tableFieldsBuilderParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FieldsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PreviewTextBox = new System.Windows.Forms.TextBox();
            this.UpdatePreviewButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.GetTemplateButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FieldGroupLabelBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.IsDisplayMethodCheckBox = new System.Windows.Forms.CheckBox();
            this.MandatoryCheckBox = new System.Windows.Forms.CheckBox();
            this.FieldGroupBox = new System.Windows.Forms.TextBox();
            this.StrLenBox = new System.Windows.Forms.TextBox();
            this.HelpTextBox = new System.Windows.Forms.TextBox();
            this.LabelBox = new System.Windows.Forms.TextBox();
            this.EDTExtendsBox = new System.Windows.Forms.TextBox();
            this.EDTNameBox = new System.Windows.Forms.TextBox();
            this.FieldNameBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FieldTypeBox = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.saveFileDialogTemplate = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.tableFieldsBuilderParmsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table name:";
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TableNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableFieldsBuilderParmsBindingSource, "TableName", true));
            this.TableNameTextBox.Location = new System.Drawing.Point(98, 16);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.ReadOnly = true;
            this.TableNameTextBox.Size = new System.Drawing.Size(275, 20);
            this.TableNameTextBox.TabIndex = 1;
            // 
            // tableFieldsBuilderParmsBindingSource
            // 
            this.tableFieldsBuilderParmsBindingSource.DataSource = typeof(TRUDUtilsD365.TableFieldsBuilder.TableFieldsBuilderParms);
            // 
            // FieldsTextBox
            // 
            this.FieldsTextBox.AcceptsReturn = true;
            this.FieldsTextBox.AcceptsTab = true;
            this.FieldsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableFieldsBuilderParmsBindingSource, "TableFieldsTxt", true));
            this.FieldsTextBox.Location = new System.Drawing.Point(3, 30);
            this.FieldsTextBox.MaxLength = 100000;
            this.FieldsTextBox.Multiline = true;
            this.FieldsTextBox.Name = "FieldsTextBox";
            this.FieldsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FieldsTextBox.Size = new System.Drawing.Size(412, 277);
            this.FieldsTextBox.TabIndex = 2;
            this.FieldsTextBox.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fields(paste from Excel):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Preview:";
            // 
            // PreviewTextBox
            // 
            this.PreviewTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewTextBox.Location = new System.Drawing.Point(0, 51);
            this.PreviewTextBox.MaxLength = 100000;
            this.PreviewTextBox.Multiline = true;
            this.PreviewTextBox.Name = "PreviewTextBox";
            this.PreviewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PreviewTextBox.Size = new System.Drawing.Size(384, 281);
            this.PreviewTextBox.TabIndex = 4;
            this.PreviewTextBox.WordWrap = false;
            // 
            // UpdatePreviewButton
            // 
            this.UpdatePreviewButton.Location = new System.Drawing.Point(75, 22);
            this.UpdatePreviewButton.Name = "UpdatePreviewButton";
            this.UpdatePreviewButton.Size = new System.Drawing.Size(119, 20);
            this.UpdatePreviewButton.TabIndex = 6;
            this.UpdatePreviewButton.Text = "Update preview";
            this.UpdatePreviewButton.UseVisualStyleBackColor = true;
            this.UpdatePreviewButton.Click += new System.EventHandler(this.UpdatePreviewButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add fields";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PreviewTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.UpdatePreviewButton);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(811, 332);
            this.splitContainer1.SplitterDistance = 426;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(426, 332);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.GetTemplateButton);
            this.tabPage1.Controls.Add(this.FieldsTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(418, 306);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Multiple fields";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tableFieldsBuilderParmsBindingSource, "IsContainsHeader", true));
            this.checkBox1.Location = new System.Drawing.Point(269, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Contains header";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // GetTemplateButton
            // 
            this.GetTemplateButton.Location = new System.Drawing.Point(155, 5);
            this.GetTemplateButton.Name = "GetTemplateButton";
            this.GetTemplateButton.Size = new System.Drawing.Size(99, 20);
            this.GetTemplateButton.TabIndex = 9;
            this.GetTemplateButton.Text = "Get template";
            this.GetTemplateButton.UseVisualStyleBackColor = true;
            this.GetTemplateButton.Click += new System.EventHandler(this.GetTemplateButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FieldGroupLabelBox);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.IsDisplayMethodCheckBox);
            this.tabPage2.Controls.Add(this.MandatoryCheckBox);
            this.tabPage2.Controls.Add(this.FieldGroupBox);
            this.tabPage2.Controls.Add(this.StrLenBox);
            this.tabPage2.Controls.Add(this.HelpTextBox);
            this.tabPage2.Controls.Add(this.LabelBox);
            this.tabPage2.Controls.Add(this.EDTExtendsBox);
            this.tabPage2.Controls.Add(this.EDTNameBox);
            this.tabPage2.Controls.Add(this.FieldNameBox);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.FieldTypeBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(418, 306);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "One field";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FieldGroupLabelBox
            // 
            this.FieldGroupLabelBox.Location = new System.Drawing.Point(94, 222);
            this.FieldGroupLabelBox.Name = "FieldGroupLabelBox";
            this.FieldGroupLabelBox.Size = new System.Drawing.Size(264, 20);
            this.FieldGroupLabelBox.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 225);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Group label";
            // 
            // IsDisplayMethodCheckBox
            // 
            this.IsDisplayMethodCheckBox.AutoSize = true;
            this.IsDisplayMethodCheckBox.Location = new System.Drawing.Point(94, 270);
            this.IsDisplayMethodCheckBox.Name = "IsDisplayMethodCheckBox";
            this.IsDisplayMethodCheckBox.Size = new System.Drawing.Size(107, 17);
            this.IsDisplayMethodCheckBox.TabIndex = 20;
            this.IsDisplayMethodCheckBox.Text = "Is display method";
            this.IsDisplayMethodCheckBox.UseVisualStyleBackColor = true;
            // 
            // MandatoryCheckBox
            // 
            this.MandatoryCheckBox.AutoSize = true;
            this.MandatoryCheckBox.Location = new System.Drawing.Point(94, 247);
            this.MandatoryCheckBox.Name = "MandatoryCheckBox";
            this.MandatoryCheckBox.Size = new System.Drawing.Size(76, 17);
            this.MandatoryCheckBox.TabIndex = 19;
            this.MandatoryCheckBox.Text = "Mandatory";
            this.MandatoryCheckBox.UseVisualStyleBackColor = true;
            // 
            // FieldGroupBox
            // 
            this.FieldGroupBox.Location = new System.Drawing.Point(94, 197);
            this.FieldGroupBox.Name = "FieldGroupBox";
            this.FieldGroupBox.Size = new System.Drawing.Size(264, 20);
            this.FieldGroupBox.TabIndex = 17;
            // 
            // StrLenBox
            // 
            this.StrLenBox.Location = new System.Drawing.Point(94, 172);
            this.StrLenBox.Name = "StrLenBox";
            this.StrLenBox.Size = new System.Drawing.Size(264, 20);
            this.StrLenBox.TabIndex = 16;
            // 
            // HelpTextBox
            // 
            this.HelpTextBox.Location = new System.Drawing.Point(94, 146);
            this.HelpTextBox.Name = "HelpTextBox";
            this.HelpTextBox.Size = new System.Drawing.Size(264, 20);
            this.HelpTextBox.TabIndex = 15;
            // 
            // LabelBox
            // 
            this.LabelBox.Location = new System.Drawing.Point(94, 121);
            this.LabelBox.Name = "LabelBox";
            this.LabelBox.Size = new System.Drawing.Size(264, 20);
            this.LabelBox.TabIndex = 14;
            this.LabelBox.TextChanged += new System.EventHandler(this.LabelBox_TextChanged);
            this.LabelBox.Validated += new System.EventHandler(this.LabelBox_Validated);
            // 
            // EDTExtendsBox
            // 
            this.EDTExtendsBox.Location = new System.Drawing.Point(94, 96);
            this.EDTExtendsBox.Name = "EDTExtendsBox";
            this.EDTExtendsBox.Size = new System.Drawing.Size(264, 20);
            this.EDTExtendsBox.TabIndex = 13;
            // 
            // EDTNameBox
            // 
            this.EDTNameBox.Location = new System.Drawing.Point(94, 71);
            this.EDTNameBox.Name = "EDTNameBox";
            this.EDTNameBox.Size = new System.Drawing.Size(264, 20);
            this.EDTNameBox.TabIndex = 12;
            // 
            // FieldNameBox
            // 
            this.FieldNameBox.Location = new System.Drawing.Point(94, 46);
            this.FieldNameBox.Name = "FieldNameBox";
            this.FieldNameBox.Size = new System.Drawing.Size(264, 20);
            this.FieldNameBox.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Field group";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Str len";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Help text";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Label";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "EDT Extends";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "EDT name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Field name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Field type";
            // 
            // FieldTypeBox
            // 
            this.FieldTypeBox.FormattingEnabled = true;
            this.FieldTypeBox.Location = new System.Drawing.Point(94, 21);
            this.FieldTypeBox.Name = "FieldTypeBox";
            this.FieldTypeBox.Size = new System.Drawing.Size(264, 21);
            this.FieldTypeBox.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.TableNameTextBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(811, 389);
            this.splitContainer2.SplitterDistance = 54;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 9;
            // 
            // saveFileDialogTemplate
            // 
            this.saveFileDialogTemplate.DefaultExt = "xlsm";
            this.saveFileDialogTemplate.FileName = "TableFieldsBuilderTemplate.xlsm";
            this.saveFileDialogTemplate.Title = "Get excel template";
            // 
            // TableFieldsBuilderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 389);
            this.Controls.Add(this.splitContainer2);
            this.Name = "TableFieldsBuilderDialog";
            this.Text = "Add fields to table";
            ((System.ComponentModel.ISupportInitialize)(this.tableFieldsBuilderParmsBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TableNameTextBox;
        private System.Windows.Forms.TextBox FieldsTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PreviewTextBox;
        private System.Windows.Forms.Button UpdatePreviewButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.BindingSource tableFieldsBuilderParmsBindingSource;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button GetTemplateButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialogTemplate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox IsDisplayMethodCheckBox;
        private System.Windows.Forms.CheckBox MandatoryCheckBox;
        private System.Windows.Forms.TextBox FieldGroupBox;
        private System.Windows.Forms.TextBox StrLenBox;
        private System.Windows.Forms.TextBox HelpTextBox;
        private System.Windows.Forms.TextBox LabelBox;
        private System.Windows.Forms.TextBox EDTExtendsBox;
        private System.Windows.Forms.TextBox EDTNameBox;
        private System.Windows.Forms.TextBox FieldNameBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FieldTypeBox;
        private System.Windows.Forms.TextBox FieldGroupLabelBox;
        private System.Windows.Forms.Label label12;
    }
}
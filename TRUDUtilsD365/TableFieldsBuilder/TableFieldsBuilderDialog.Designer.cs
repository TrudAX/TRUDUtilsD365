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
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table name:";
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TableNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableFieldsBuilderParmsBindingSource, "TableName", true));
            this.TableNameTextBox.Location = new System.Drawing.Point(114, 19);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.ReadOnly = true;
            this.TableNameTextBox.Size = new System.Drawing.Size(320, 23);
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
            this.FieldsTextBox.Location = new System.Drawing.Point(3, 35);
            this.FieldsTextBox.MaxLength = 100000;
            this.FieldsTextBox.Multiline = true;
            this.FieldsTextBox.Name = "FieldsTextBox";
            this.FieldsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FieldsTextBox.Size = new System.Drawing.Size(480, 325);
            this.FieldsTextBox.TabIndex = 2;
            this.FieldsTextBox.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fields(paste from Excel):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Preview:";
            // 
            // PreviewTextBox
            // 
            this.PreviewTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewTextBox.Location = new System.Drawing.Point(0, 59);
            this.PreviewTextBox.MaxLength = 100000;
            this.PreviewTextBox.Multiline = true;
            this.PreviewTextBox.Name = "PreviewTextBox";
            this.PreviewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PreviewTextBox.Size = new System.Drawing.Size(445, 332);
            this.PreviewTextBox.TabIndex = 4;
            this.PreviewTextBox.WordWrap = false;
            // 
            // UpdatePreviewButton
            // 
            this.UpdatePreviewButton.Location = new System.Drawing.Point(87, 25);
            this.UpdatePreviewButton.Name = "UpdatePreviewButton";
            this.UpdatePreviewButton.Size = new System.Drawing.Size(139, 23);
            this.UpdatePreviewButton.TabIndex = 6;
            this.UpdatePreviewButton.Text = "Update preview";
            this.UpdatePreviewButton.UseVisualStyleBackColor = true;
            this.UpdatePreviewButton.Click += new System.EventHandler(this.UpdatePreviewButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(459, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 35);
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
            this.splitContainer1.Size = new System.Drawing.Size(946, 391);
            this.splitContainer1.SplitterDistance = 497;
            this.splitContainer1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(497, 391);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.GetTemplateButton);
            this.tabPage1.Controls.Add(this.FieldsTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(489, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Multiple fields";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tableFieldsBuilderParmsBindingSource, "IsContainsHeader", true));
            this.checkBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(314, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(131, 18);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Contains header";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // GetTemplateButton
            // 
            this.GetTemplateButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetTemplateButton.Location = new System.Drawing.Point(181, 6);
            this.GetTemplateButton.Name = "GetTemplateButton";
            this.GetTemplateButton.Size = new System.Drawing.Size(116, 23);
            this.GetTemplateButton.TabIndex = 9;
            this.GetTemplateButton.Text = "Get template";
            this.GetTemplateButton.UseVisualStyleBackColor = true;
            this.GetTemplateButton.Click += new System.EventHandler(this.GetTemplateButton_Click);
            // 
            // tabPage2
            // 
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
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(489, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "One field";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // IsDisplayMethodCheckBox
            // 
            this.IsDisplayMethodCheckBox.AutoSize = true;
            this.IsDisplayMethodCheckBox.Location = new System.Drawing.Point(119, 283);
            this.IsDisplayMethodCheckBox.Name = "IsDisplayMethodCheckBox";
            this.IsDisplayMethodCheckBox.Size = new System.Drawing.Size(163, 21);
            this.IsDisplayMethodCheckBox.TabIndex = 19;
            this.IsDisplayMethodCheckBox.Text = "Is display method";
            this.IsDisplayMethodCheckBox.UseVisualStyleBackColor = true;
            // 
            // MandatoryCheckBox
            // 
            this.MandatoryCheckBox.AutoSize = true;
            this.MandatoryCheckBox.Location = new System.Drawing.Point(119, 256);
            this.MandatoryCheckBox.Name = "MandatoryCheckBox";
            this.MandatoryCheckBox.Size = new System.Drawing.Size(99, 21);
            this.MandatoryCheckBox.TabIndex = 18;
            this.MandatoryCheckBox.Text = "Mandatory";
            this.MandatoryCheckBox.UseVisualStyleBackColor = true;
            // 
            // FieldGroupBox
            // 
            this.FieldGroupBox.Location = new System.Drawing.Point(119, 227);
            this.FieldGroupBox.Name = "FieldGroupBox";
            this.FieldGroupBox.Size = new System.Drawing.Size(298, 23);
            this.FieldGroupBox.TabIndex = 17;
            // 
            // StrLenBox
            // 
            this.StrLenBox.Location = new System.Drawing.Point(119, 198);
            this.StrLenBox.Name = "StrLenBox";
            this.StrLenBox.Size = new System.Drawing.Size(298, 23);
            this.StrLenBox.TabIndex = 16;
            // 
            // HelpTextBox
            // 
            this.HelpTextBox.Location = new System.Drawing.Point(119, 169);
            this.HelpTextBox.Name = "HelpTextBox";
            this.HelpTextBox.Size = new System.Drawing.Size(298, 23);
            this.HelpTextBox.TabIndex = 15;
            // 
            // LabelBox
            // 
            this.LabelBox.Location = new System.Drawing.Point(119, 140);
            this.LabelBox.Name = "LabelBox";
            this.LabelBox.Size = new System.Drawing.Size(298, 23);
            this.LabelBox.TabIndex = 14;
            this.LabelBox.TextChanged += new System.EventHandler(this.LabelBox_TextChanged);
            this.LabelBox.Validated += new System.EventHandler(this.LabelBox_Validated);
            // 
            // EDTExtendsBox
            // 
            this.EDTExtendsBox.Location = new System.Drawing.Point(119, 111);
            this.EDTExtendsBox.Name = "EDTExtendsBox";
            this.EDTExtendsBox.Size = new System.Drawing.Size(298, 23);
            this.EDTExtendsBox.TabIndex = 13;
            // 
            // EDTNameBox
            // 
            this.EDTNameBox.Location = new System.Drawing.Point(119, 82);
            this.EDTNameBox.Name = "EDTNameBox";
            this.EDTNameBox.Size = new System.Drawing.Size(298, 23);
            this.EDTNameBox.TabIndex = 12;
            // 
            // FieldNameBox
            // 
            this.FieldNameBox.Location = new System.Drawing.Point(119, 53);
            this.FieldNameBox.Name = "FieldNameBox";
            this.FieldNameBox.Size = new System.Drawing.Size(298, 23);
            this.FieldNameBox.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "Field group";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Str len";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Help text";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Label";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "EDT Extends";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "EDT name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Field name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Field type";
            // 
            // FieldTypeBox
            // 
            this.FieldTypeBox.FormattingEnabled = true;
            this.FieldTypeBox.Location = new System.Drawing.Point(119, 24);
            this.FieldTypeBox.Name = "FieldTypeBox";
            this.FieldTypeBox.Size = new System.Drawing.Size(298, 23);
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
            this.splitContainer2.Size = new System.Drawing.Size(946, 449);
            this.splitContainer2.SplitterDistance = 54;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 449);
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
    }
}
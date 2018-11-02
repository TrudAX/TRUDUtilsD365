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
            this.FieldsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PreviewTextBox = new System.Windows.Forms.TextBox();
            this.UpdatePreviewButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.GetTemplateButton = new System.Windows.Forms.Button();
            this.saveFileDialogTemplate = new System.Windows.Forms.SaveFileDialog();
            this.tableFieldsBuilderParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableFieldsBuilderParmsBindingSource)).BeginInit();
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
            this.TableNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableFieldsBuilderParmsBindingSource, "TableName", true));
            this.TableNameTextBox.Location = new System.Drawing.Point(114, 19);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(320, 23);
            this.TableNameTextBox.TabIndex = 1;
            // 
            // FieldsTextBox
            // 
            this.FieldsTextBox.AcceptsReturn = true;
            this.FieldsTextBox.AcceptsTab = true;
            this.FieldsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableFieldsBuilderParmsBindingSource, "TableFieldsTxt", true));
            this.FieldsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldsTextBox.Location = new System.Drawing.Point(0, 0);
            this.FieldsTextBox.MaxLength = 100000;
            this.FieldsTextBox.Multiline = true;
            this.FieldsTextBox.Name = "FieldsTextBox";
            this.FieldsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FieldsTextBox.Size = new System.Drawing.Size(497, 323);
            this.FieldsTextBox.TabIndex = 2;
            this.FieldsTextBox.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fields(paste from Excel):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(500, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Preview:";
            // 
            // PreviewTextBox
            // 
            this.PreviewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewTextBox.Location = new System.Drawing.Point(0, 0);
            this.PreviewTextBox.MaxLength = 100000;
            this.PreviewTextBox.Multiline = true;
            this.PreviewTextBox.Name = "PreviewTextBox";
            this.PreviewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PreviewTextBox.Size = new System.Drawing.Size(445, 323);
            this.PreviewTextBox.TabIndex = 4;
            this.PreviewTextBox.WordWrap = false;
            // 
            // UpdatePreviewButton
            // 
            this.UpdatePreviewButton.Location = new System.Drawing.Point(578, 53);
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
            this.splitContainer1.Panel1.Controls.Add(this.FieldsTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PreviewTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(946, 323);
            this.splitContainer1.SplitterDistance = 497;
            this.splitContainer1.TabIndex = 8;
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
            this.splitContainer2.Panel1.Controls.Add(this.GetTemplateButton);
            this.splitContainer2.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.TableNameTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.UpdatePreviewButton);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(946, 412);
            this.splitContainer2.SplitterDistance = 85;
            this.splitContainer2.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.tableFieldsBuilderParmsBindingSource, "IsContainsHeader", true));
            this.checkBox1.Location = new System.Drawing.Point(337, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 21);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Contains header";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // GetTemplateButton
            // 
            this.GetTemplateButton.Location = new System.Drawing.Point(215, 53);
            this.GetTemplateButton.Name = "GetTemplateButton";
            this.GetTemplateButton.Size = new System.Drawing.Size(116, 23);
            this.GetTemplateButton.TabIndex = 9;
            this.GetTemplateButton.Text = "Get template";
            this.GetTemplateButton.UseVisualStyleBackColor = true;
            this.GetTemplateButton.Click += new System.EventHandler(this.GetTemplateButton_Click);
            // 
            // saveFileDialogTemplate
            // 
            this.saveFileDialogTemplate.DefaultExt = "xlsx";
            this.saveFileDialogTemplate.FileName = "TableFieldsBuilderTemplate.xlsx";
            this.saveFileDialogTemplate.Title = "Get excel template";
            // 
            // tableFieldsBuilderParmsBindingSource
            // 
            this.tableFieldsBuilderParmsBindingSource.DataSource = typeof(TRUDUtilsD365.TableFieldsBuilder.TableFieldsBuilderParms);
            // 
            // TableFieldsBuilderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 412);
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TableFieldsBuilderDialog";
            this.Text = "Add fields to table";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableFieldsBuilderParmsBindingSource)).EndInit();
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
    }
}
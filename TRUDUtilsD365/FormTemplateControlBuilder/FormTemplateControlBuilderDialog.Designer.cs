namespace TRUDUtilsD365.FormTemplateControlBuilder
{
    partial class FormTemplateControlBuilderDialog
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
            this.labelForm = new System.Windows.Forms.Label();
            this.FormNameTextBox = new System.Windows.Forms.TextBox();
            this.labelTemplate = new System.Windows.Forms.Label();
            this.TemplateTextBox = new System.Windows.Forms.TextBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.AddOptionalCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // labelForm
            //
            this.labelForm.AutoSize = true;
            this.labelForm.Location = new System.Drawing.Point(16, 18);
            this.labelForm.Name = "labelForm";
            this.labelForm.Size = new System.Drawing.Size(63, 13);
            this.labelForm.TabIndex = 0;
            this.labelForm.Text = "Form name";
            //
            // FormNameTextBox
            //
            this.FormNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FormNameTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.FormNameTextBox.Location = new System.Drawing.Point(110, 15);
            this.FormNameTextBox.Name = "FormNameTextBox";
            this.FormNameTextBox.ReadOnly = true;
            this.FormNameTextBox.Size = new System.Drawing.Size(380, 20);
            this.FormNameTextBox.TabIndex = 1;
            this.FormNameTextBox.TabStop = false;
            //
            // labelTemplate
            //
            this.labelTemplate.AutoSize = true;
            this.labelTemplate.Location = new System.Drawing.Point(16, 50);
            this.labelTemplate.Name = "labelTemplate";
            this.labelTemplate.Size = new System.Drawing.Size(49, 13);
            this.labelTemplate.TabIndex = 2;
            this.labelTemplate.Text = "Template";
            //
            // TemplateTextBox
            //
            this.TemplateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TemplateTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.TemplateTextBox.Location = new System.Drawing.Point(110, 47);
            this.TemplateTextBox.Name = "TemplateTextBox";
            this.TemplateTextBox.ReadOnly = true;
            this.TemplateTextBox.Size = new System.Drawing.Size(380, 20);
            this.TemplateTextBox.TabIndex = 3;
            this.TemplateTextBox.TabStop = false;
            //
            // MessageLabel
            //
            this.MessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageLabel.Location = new System.Drawing.Point(16, 82);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(474, 66);
            this.MessageLabel.TabIndex = 4;
            //
            // AddOptionalCheckBox
            //
            this.AddOptionalCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddOptionalCheckBox.AutoSize = true;
            this.AddOptionalCheckBox.Checked = true;
            this.AddOptionalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AddOptionalCheckBox.Location = new System.Drawing.Point(19, 160);
            this.AddOptionalCheckBox.Name = "AddOptionalCheckBox";
            this.AddOptionalCheckBox.Size = new System.Drawing.Size(244, 17);
            this.AddOptionalCheckBox.TabIndex = 5;
            this.AddOptionalCheckBox.Text = "Add optional controls (not just required ones)";
            this.AddOptionalCheckBox.UseVisualStyleBackColor = true;
            //
            // buttonOk
            //
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(322, 185);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 25);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            //
            // buttonCancel
            //
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(415, 185);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 25);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            //
            // FormTemplateControlBuilderDialog
            //
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(506, 224);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.AddOptionalCheckBox);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.TemplateTextBox);
            this.Controls.Add(this.labelTemplate);
            this.Controls.Add(this.FormNameTextBox);
            this.Controls.Add(this.labelForm);
            this.MinimumSize = new System.Drawing.Size(420, 200);
            this.Name = "FormTemplateControlBuilderDialog";
            this.Text = "Add template controls";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelForm;
        private System.Windows.Forms.TextBox FormNameTextBox;
        private System.Windows.Forms.Label labelTemplate;
        private System.Windows.Forms.TextBox TemplateTextBox;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.CheckBox AddOptionalCheckBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}

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
            this.ParametersBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ValuesControl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ParametersBox
            // 
            this.ParametersBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ParametersBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ParametersBox.Location = new System.Drawing.Point(3, 144);
            this.ParametersBox.Multiline = true;
            this.ParametersBox.Name = "ParametersBox";
            this.ParametersBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ParametersBox.Size = new System.Drawing.Size(157, 249);
            this.ParametersBox.TabIndex = 17;
            this.ParametersBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ParametersBox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Base Type";
            // 
            // ValuesControl
            // 
            this.ValuesControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValuesControl.BackColor = System.Drawing.SystemColors.Window;
            this.ValuesControl.Location = new System.Drawing.Point(166, 144);
            this.ValuesControl.Multiline = true;
            this.ValuesControl.Name = "ValuesControl";
            this.ValuesControl.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ValuesControl.Size = new System.Drawing.Size(346, 249);
            this.ValuesControl.TabIndex = 15;
            this.ValuesControl.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name template";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(441, 46);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 18;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DescriptionBox.Location = new System.Drawing.Point(3, 46);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(424, 59);
            this.DescriptionBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Name template for class extensions";
            // 
            // KernelSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 397);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ParametersBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ValuesControl);
            this.Controls.Add(this.label1);
            this.Name = "KernelSettings";
            this.Text = "KernelSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ParametersBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ValuesControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label2;
    }
}
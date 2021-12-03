namespace TRUDUtilsD365.Kernel
{
    partial class SnippetsDialog
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
            this.ValuesControl = new System.Windows.Forms.TextBox();
            this.snippetsParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ShowResultButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ParametersBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.SnippetNameBox = new System.Windows.Forms.ComboBox();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SeparatorTextBox = new System.Windows.Forms.TextBox();
            this.SepLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.snippetsParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Values";
            // 
            // ValuesControl
            // 
            this.ValuesControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ValuesControl.BackColor = System.Drawing.SystemColors.Window;
            this.ValuesControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "Values", true));
            this.ValuesControl.Location = new System.Drawing.Point(153, 137);
            this.ValuesControl.Multiline = true;
            this.ValuesControl.Name = "ValuesControl";
            this.ValuesControl.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ValuesControl.Size = new System.Drawing.Size(269, 265);
            this.ValuesControl.TabIndex = 2;
            this.ValuesControl.WordWrap = false;
            // 
            // snippetsParmsBindingSource
            // 
            this.snippetsParmsBindingSource.DataSource = typeof(TRUDUtilsD365.Kernel.SnippetsParms);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parameters";
            // 
            // ShowResultButton
            // 
            this.ShowResultButton.Location = new System.Drawing.Point(483, 8);
            this.ShowResultButton.Name = "ShowResultButton";
            this.ShowResultButton.Size = new System.Drawing.Size(75, 23);
            this.ShowResultButton.TabIndex = 6;
            this.ShowResultButton.Text = "Refresh";
            this.ShowResultButton.UseVisualStyleBackColor = true;
            this.ShowResultButton.Click += new System.EventHandler(this.ShowResultButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Preview";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "ResultText", true));
            this.ResultTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultTextBox.Location = new System.Drawing.Point(428, 39);
            this.ResultTextBox.MaxLength = 327670;
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultTextBox.Size = new System.Drawing.Size(428, 363);
            this.ResultTextBox.TabIndex = 9;
            this.ResultTextBox.WordWrap = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(564, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(89, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Copy to clipboard";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ParametersBox
            // 
            this.ParametersBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ParametersBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ParametersBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "Parameters", true));
            this.ParametersBox.Location = new System.Drawing.Point(-2, 137);
            this.ParametersBox.Multiline = true;
            this.ParametersBox.Name = "ParametersBox";
            this.ParametersBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ParametersBox.Size = new System.Drawing.Size(157, 265);
            this.ParametersBox.TabIndex = 13;
            this.ParametersBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ParametersBox.WordWrap = false;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(659, 5);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(89, 28);
            this.CreateButton.TabIndex = 15;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // SnippetNameBox
            // 
            this.SnippetNameBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "SnippetName", true));
            this.SnippetNameBox.FormattingEnabled = true;
            this.SnippetNameBox.Location = new System.Drawing.Point(49, 12);
            this.SnippetNameBox.Name = "SnippetNameBox";
            this.SnippetNameBox.Size = new System.Drawing.Size(172, 21);
            this.SnippetNameBox.TabIndex = 16;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DescriptionBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "Description", true));
            this.DescriptionBox.Location = new System.Drawing.Point(-2, 39);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(424, 73);
            this.DescriptionBox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Description";
            // 
            // SeparatorTextBox
            // 
            this.SeparatorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "ValuesSeparator", true));
            this.SeparatorTextBox.Location = new System.Drawing.Point(390, 114);
            this.SeparatorTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SeparatorTextBox.MaxLength = 1;
            this.SeparatorTextBox.Name = "SeparatorTextBox";
            this.SeparatorTextBox.Size = new System.Drawing.Size(32, 20);
            this.SeparatorTextBox.TabIndex = 21;
            this.SeparatorTextBox.WordWrap = false;
            // 
            // SepLabel
            // 
            this.SepLabel.AutoSize = true;
            this.SepLabel.Location = new System.Drawing.Point(326, 117);
            this.SepLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SepLabel.Name = "SepLabel";
            this.SepLabel.Size = new System.Drawing.Size(56, 13);
            this.SepLabel.TabIndex = 20;
            this.SepLabel.Text = "Separator:";
            this.SepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SnippetsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 414);
            this.Controls.Add(this.SeparatorTextBox);
            this.Controls.Add(this.SepLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.SnippetNameBox);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.ParametersBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ShowResultButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ValuesControl);
            this.Controls.Add(this.label1);
            this.Name = "SnippetsDialog";
            this.Text = "Advanced snippets dialog";
            ((System.ComponentModel.ISupportInitialize)(this.snippetsParmsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ValuesControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ShowResultButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox ParametersBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.ComboBox SnippetNameBox;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SeparatorTextBox;
        private System.Windows.Forms.Label SepLabel;
        private System.Windows.Forms.BindingSource snippetsParmsBindingSource;
    }
}
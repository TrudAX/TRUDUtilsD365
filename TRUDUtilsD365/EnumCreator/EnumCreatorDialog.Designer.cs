namespace TRUDUtilsD365.EnumCreator
{
    partial class EnumCreatorDialog
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
            this.EnumNameTextBox = new System.Windows.Forms.TextBox();
            this.enumCreatorParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SeparatorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ValuesTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PreviewTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PreviewButton = new System.Windows.Forms.Button();
            this.TypeNameTextBox = new System.Windows.Forms.TextBox();
            this.IsCreateTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EnumLabelTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.StartIndexTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.enumCreatorParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enum name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnumNameTextBox
            // 
            this.EnumNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumName", true));
            this.EnumNameTextBox.Location = new System.Drawing.Point(12, 21);
            this.EnumNameTextBox.Name = "EnumNameTextBox";
            this.EnumNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.EnumNameTextBox.TabIndex = 1;
            // 
            // enumCreatorParmsBindingSource
            // 
            this.enumCreatorParmsBindingSource.DataSource = typeof(TRUDUtilsD365.EnumCreator.EnumCreatorParms);
            // 
            // SeparatorTextBox
            // 
            this.SeparatorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "ValuesSeparator", true));
            this.SeparatorTextBox.Location = new System.Drawing.Point(247, 91);
            this.SeparatorTextBox.MaxLength = 1;
            this.SeparatorTextBox.Name = "SeparatorTextBox";
            this.SeparatorTextBox.Size = new System.Drawing.Size(25, 20);
            this.SeparatorTextBox.TabIndex = 3;
            this.SeparatorTextBox.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Separator:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ValuesTextBox
            // 
            this.ValuesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumValuesStr", true));
            this.ValuesTextBox.Font = new System.Drawing.Font("Consolas", 9F);
            this.ValuesTextBox.Location = new System.Drawing.Point(12, 114);
            this.ValuesTextBox.Multiline = true;
            this.ValuesTextBox.Name = "ValuesTextBox";
            this.ValuesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ValuesTextBox.Size = new System.Drawing.Size(263, 176);
            this.ValuesTextBox.TabIndex = 4;
            this.ValuesTextBox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Values per line(Label | Name):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PreviewTextBox
            // 
            this.PreviewTextBox.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.PreviewTextBox.Location = new System.Drawing.Point(281, 114);
            this.PreviewTextBox.Multiline = true;
            this.PreviewTextBox.Name = "PreviewTextBox";
            this.PreviewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PreviewTextBox.Size = new System.Drawing.Size(304, 176);
            this.PreviewTextBox.TabIndex = 6;
            this.PreviewTextBox.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Preview:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PreviewButton
            // 
            this.PreviewButton.Location = new System.Drawing.Point(354, 86);
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.Size = new System.Drawing.Size(54, 23);
            this.PreviewButton.TabIndex = 8;
            this.PreviewButton.Text = "Preview";
            this.PreviewButton.UseVisualStyleBackColor = true;
            this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // TypeNameTextBox
            // 
            this.TypeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumTypeName", true));
            this.TypeNameTextBox.Location = new System.Drawing.Point(503, 60);
            this.TypeNameTextBox.Name = "TypeNameTextBox";
            this.TypeNameTextBox.Size = new System.Drawing.Size(180, 20);
            this.TypeNameTextBox.TabIndex = 9;
            // 
            // IsCreateTypeCheckBox
            // 
            this.IsCreateTypeCheckBox.AutoSize = true;
            this.IsCreateTypeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.enumCreatorParmsBindingSource, "IsCreateEnumType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IsCreateTypeCheckBox.Location = new System.Drawing.Point(503, 21);
            this.IsCreateTypeCheckBox.Name = "IsCreateTypeCheckBox";
            this.IsCreateTypeCheckBox.Size = new System.Drawing.Size(82, 17);
            this.IsCreateTypeCheckBox.TabIndex = 10;
            this.IsCreateTypeCheckBox.Text = "Create EDT";
            this.IsCreateTypeCheckBox.UseVisualStyleBackColor = true;
            this.IsCreateTypeCheckBox.CheckStateChanged += new System.EventHandler(this.IsCreateTypeCheckBox_CheckStateChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "EDT name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnumLabelTextBox
            // 
            this.EnumLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumLabel", true));
            this.EnumLabelTextBox.Location = new System.Drawing.Point(280, 21);
            this.EnumLabelTextBox.Name = "EnumLabelTextBox";
            this.EnumLabelTextBox.Size = new System.Drawing.Size(189, 20);
            this.EnumLabelTextBox.TabIndex = 13;
            this.EnumLabelTextBox.Validated += new System.EventHandler(this.EnumLabelTextBox_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Label:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumHelpText", true));
            this.textBox2.Location = new System.Drawing.Point(281, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(189, 20);
            this.textBox2.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Help text:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 32);
            this.button1.TabIndex = 16;
            this.button1.Text = "Create ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartIndexTextBox
            // 
            this.StartIndexTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumValueStartIndex", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N0"));
            this.StartIndexTextBox.Location = new System.Drawing.Point(12, 60);
            this.StartIndexTextBox.Name = "StartIndexTextBox";
            this.StartIndexTextBox.Size = new System.Drawing.Size(57, 20);
            this.StartIndexTextBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Start index:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnumCreatorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 331);
            this.Controls.Add(this.StartIndexTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EnumLabelTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IsCreateTypeCheckBox);
            this.Controls.Add(this.TypeNameTextBox);
            this.Controls.Add(this.PreviewButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PreviewTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ValuesTextBox);
            this.Controls.Add(this.SeparatorTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EnumNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "EnumCreatorDialog";
            this.Text = "Enum builder";
            ((System.ComponentModel.ISupportInitialize)(this.enumCreatorParmsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EnumNameTextBox;
        private System.Windows.Forms.TextBox SeparatorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ValuesTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PreviewTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.TextBox TypeNameTextBox;
        private System.Windows.Forms.CheckBox IsCreateTypeCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EnumLabelTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource enumCreatorParmsBindingSource;
        private System.Windows.Forms.TextBox StartIndexTextBox;
        private System.Windows.Forms.Label label8;
    }
}
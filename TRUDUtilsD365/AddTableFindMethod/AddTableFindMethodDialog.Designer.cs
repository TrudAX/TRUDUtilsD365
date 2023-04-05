namespace TRUDUtilsD365.AddTableFindMethod
{
    partial class AddTableFindMethodDialog
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
            this.TableNameControl = new System.Windows.Forms.TextBox();
            this.addTableFindMethodParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.FieldsControl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MethodNameControl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ShowResultButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.MethodTypeCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.addTableFindMethodParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TableNameControl
            // 
            this.TableNameControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addTableFindMethodParmsBindingSource, "TableName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TableNameControl.Location = new System.Drawing.Point(42, 79);
            this.TableNameControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TableNameControl.MaxLength = 100;
            this.TableNameControl.Name = "TableNameControl";
            this.TableNameControl.Size = new System.Drawing.Size(352, 31);
            this.TableNameControl.TabIndex = 0;
            // 
            // addTableFindMethodParmsBindingSource
            // 
            this.addTableFindMethodParmsBindingSource.DataSource = typeof(TRUDUtilsD365.AddTableFindMethod.AddTableFindMethodParms);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table name";
            // 
            // FieldsControl
            // 
            this.FieldsControl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FieldsControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addTableFindMethodParmsBindingSource, "FieldsStr", true));
            this.FieldsControl.Location = new System.Drawing.Point(42, 235);
            this.FieldsControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.FieldsControl.Multiline = true;
            this.FieldsControl.Name = "FieldsControl";
            this.FieldsControl.Size = new System.Drawing.Size(352, 183);
            this.FieldsControl.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fields";
            // 
            // MethodNameControl
            // 
            this.MethodNameControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addTableFindMethodParmsBindingSource, "VarName", true));
            this.MethodNameControl.Location = new System.Drawing.Point(42, 154);
            this.MethodNameControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MethodNameControl.Name = "MethodNameControl";
            this.MethodNameControl.Size = new System.Drawing.Size(346, 31);
            this.MethodNameControl.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Var name";
            // 
            // ShowResultButton
            // 
            this.ShowResultButton.Location = new System.Drawing.Point(806, 37);
            this.ShowResultButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ShowResultButton.Name = "ShowResultButton";
            this.ShowResultButton.Size = new System.Drawing.Size(150, 44);
            this.ShowResultButton.TabIndex = 6;
            this.ShowResultButton.Text = "Refresh";
            this.ShowResultButton.UseVisualStyleBackColor = true;
            this.ShowResultButton.Click += new System.EventHandler(this.ShowResultButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(528, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Result";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultTextBox.Location = new System.Drawing.Point(534, 83);
            this.ResultTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ResultTextBox.MaxLength = 327670;
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTextBox.Size = new System.Drawing.Size(888, 717);
            this.ResultTextBox.TabIndex = 9;
            this.ResultTextBox.WordWrap = false;
            // 
            // MethodTypeCheckedListBox
            // 
            this.MethodTypeCheckedListBox.CheckOnClick = true;
            this.MethodTypeCheckedListBox.FormattingEnabled = true;
            this.MethodTypeCheckedListBox.Items.AddRange(new object[] {
            "find",
            "exists",
            "findRecId",
            "txtNotFind",
            "checkExists"});
            this.MethodTypeCheckedListBox.Location = new System.Drawing.Point(42, 458);
            this.MethodTypeCheckedListBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MethodTypeCheckedListBox.Name = "MethodTypeCheckedListBox";
            this.MethodTypeCheckedListBox.Size = new System.Drawing.Size(352, 172);
            this.MethodTypeCheckedListBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 427);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Method type";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(616, 46);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(180, 25);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Copy to clipboard";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // AddTableFindMethodDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 827);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MethodTypeCheckedListBox);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ShowResultButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MethodNameControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FieldsControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TableNameControl);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "AddTableFindMethodDialog";
            this.Text = "Create table Find method";
            ((System.ComponentModel.ISupportInitialize)(this.addTableFindMethodParmsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TableNameControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FieldsControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MethodNameControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ShowResultButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource addTableFindMethodParmsBindingSource;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.CheckedListBox MethodTypeCheckedListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
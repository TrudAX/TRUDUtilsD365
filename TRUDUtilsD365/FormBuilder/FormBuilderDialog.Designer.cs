namespace TRUDUtilsD365.FormBuilder
{
    partial class FormBuilderDialog
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TableNameTextBox = new System.Windows.Forms.TextBox();
            this.formBuilderParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridGroupNameTextBox1 = new System.Windows.Forms.TextBox();
            this.HeaderGroupTextBox = new System.Windows.Forms.TextBox();
            this.FormHelpTextBox = new System.Windows.Forms.TextBox();
            this.FormLabelTextBox = new System.Windows.Forms.TextBox();
            this.FormNameTextBox = new System.Windows.Forms.TextBox();
            this.IsCreateMenuItemCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TabsCaptionsTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GridGroupNameTextBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.formBuilderParmsBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Table name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grid group:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Header group:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Create menu item?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Form name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Form label:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(262, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Form help text:";
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TableNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "TableName", true));
            this.TableNameTextBox.Location = new System.Drawing.Point(75, 9);
            this.TableNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(184, 20);
            this.TableNameTextBox.TabIndex = 100;
            // 
            // formBuilderParmsBindingSource
            // 
            this.formBuilderParmsBindingSource.DataSource = typeof(TRUDUtilsD365.FormBuilder.FormBuilderParms);
            // 
            // GridGroupNameTextBox1
            // 
            this.GridGroupNameTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "GroupNameGrid", true));
            this.GridGroupNameTextBox1.Location = new System.Drawing.Point(293, 19);
            this.GridGroupNameTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GridGroupNameTextBox1.Name = "GridGroupNameTextBox1";
            this.GridGroupNameTextBox1.Size = new System.Drawing.Size(143, 20);
            this.GridGroupNameTextBox1.TabIndex = 23;
            // 
            // HeaderGroupTextBox
            // 
            this.HeaderGroupTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "GroupNameHeader", true));
            this.HeaderGroupTextBox.Location = new System.Drawing.Point(293, 41);
            this.HeaderGroupTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HeaderGroupTextBox.Name = "HeaderGroupTextBox";
            this.HeaderGroupTextBox.Size = new System.Drawing.Size(143, 20);
            this.HeaderGroupTextBox.TabIndex = 24;
            // 
            // FormHelpTextBox
            // 
            this.FormHelpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "FormHelp", true));
            this.FormHelpTextBox.Location = new System.Drawing.Point(337, 31);
            this.FormHelpTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FormHelpTextBox.Name = "FormHelpTextBox";
            this.FormHelpTextBox.Size = new System.Drawing.Size(213, 20);
            this.FormHelpTextBox.TabIndex = 17;
            // 
            // FormLabelTextBox
            // 
            this.FormLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "FormLabel", true));
            this.FormLabelTextBox.Location = new System.Drawing.Point(337, 9);
            this.FormLabelTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FormLabelTextBox.Name = "FormLabelTextBox";
            this.FormLabelTextBox.Size = new System.Drawing.Size(213, 20);
            this.FormLabelTextBox.TabIndex = 16;
            // 
            // FormNameTextBox
            // 
            this.FormNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "FormName", true));
            this.FormNameTextBox.Location = new System.Drawing.Point(75, 31);
            this.FormNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FormNameTextBox.Name = "FormNameTextBox";
            this.FormNameTextBox.Size = new System.Drawing.Size(184, 20);
            this.FormNameTextBox.TabIndex = 15;
            // 
            // IsCreateMenuItemCheckBox
            // 
            this.IsCreateMenuItemCheckBox.AutoSize = true;
            this.IsCreateMenuItemCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.formBuilderParmsBindingSource, "IsCreateMenuItem", true));
            this.IsCreateMenuItemCheckBox.Location = new System.Drawing.Point(111, 56);
            this.IsCreateMenuItemCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IsCreateMenuItemCheckBox.Name = "IsCreateMenuItemCheckBox";
            this.IsCreateMenuItemCheckBox.Size = new System.Drawing.Size(15, 14);
            this.IsCreateMenuItemCheckBox.TabIndex = 14;
            this.IsCreateMenuItemCheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 252);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Create ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TabsCaptionsTextBox
            // 
            this.TabsCaptionsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "TabLabels", true));
            this.TabsCaptionsTextBox.Location = new System.Drawing.Point(12, 19);
            this.TabsCaptionsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TabsCaptionsTextBox.Multiline = true;
            this.TabsCaptionsTextBox.Name = "TabsCaptionsTextBox";
            this.TabsCaptionsTextBox.Size = new System.Drawing.Size(193, 106);
            this.TabsCaptionsTextBox.TabIndex = 20;
            this.TabsCaptionsTextBox.WordWrap = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Tab labels(line per tab page):";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 91);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 151);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GridGroupNameTextBox2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(504, 125);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "SimpleList";
            this.tabPage1.Text = "SimpleList";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GridGroupNameTextBox2
            // 
            this.GridGroupNameTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "GroupNameGrid", true));
            this.GridGroupNameTextBox2.Location = new System.Drawing.Point(65, 12);
            this.GridGroupNameTextBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GridGroupNameTextBox2.Name = "GridGroupNameTextBox2";
            this.GridGroupNameTextBox2.Size = new System.Drawing.Size(184, 20);
            this.GridGroupNameTextBox2.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Grid group:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GridGroupNameTextBox1);
            this.tabPage2.Controls.Add(this.TabsCaptionsTextBox);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.HeaderGroupTextBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(504, 125);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "SimpleListDetails";
            this.tabPage2.Text = "SimpleListDetails";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormBuilderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 284);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FormHelpTextBox);
            this.Controls.Add(this.FormLabelTextBox);
            this.Controls.Add(this.FormNameTextBox);
            this.Controls.Add(this.IsCreateMenuItemCheckBox);
            this.Controls.Add(this.TableNameTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Name = "FormBuilderDialog";
            this.Text = "Form Builder";
            ((System.ComponentModel.ISupportInitialize)(this.formBuilderParmsBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TableNameTextBox;
        private System.Windows.Forms.TextBox GridGroupNameTextBox1;
        private System.Windows.Forms.TextBox HeaderGroupTextBox;
        private System.Windows.Forms.TextBox FormHelpTextBox;
        private System.Windows.Forms.TextBox FormLabelTextBox;
        private System.Windows.Forms.TextBox FormNameTextBox;
        private System.Windows.Forms.CheckBox IsCreateMenuItemCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TabsCaptionsTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource formBuilderParmsBindingSource;
        private System.Windows.Forms.TextBox GridGroupNameTextBox2;
        private System.Windows.Forms.Label label1;
    }
}
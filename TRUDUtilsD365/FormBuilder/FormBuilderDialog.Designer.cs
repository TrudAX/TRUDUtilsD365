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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TableNameTextBox = new System.Windows.Forms.TextBox();
            this.formBuilderParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FormHelpTextBox = new System.Windows.Forms.TextBox();
            this.FormLabelTextBox = new System.Windows.Forms.TextBox();
            this.FormNameTextBox = new System.Windows.Forms.TextBox();
            this.IsCreateMenuItemCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GridGroupNameTextBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ParamsValuesTextBox = new System.Windows.Forms.TextBox();
            this.ParamsLabelsTextBox = new System.Windows.Forms.TextBox();
            this.labelValuesCol = new System.Windows.Forms.Label();
            this.labelParamsCol = new System.Windows.Forms.Label();
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
            this.TableNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(184, 20);
            this.TableNameTextBox.TabIndex = 100;
            // 
            // formBuilderParmsBindingSource
            // 
            this.formBuilderParmsBindingSource.DataSource = typeof(TRUDUtilsD365.FormBuilder.FormBuilderParms);
            // 
            // FormHelpTextBox
            // 
            this.FormHelpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "FormHelp", true));
            this.FormHelpTextBox.Location = new System.Drawing.Point(337, 31);
            this.FormHelpTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FormHelpTextBox.Name = "FormHelpTextBox";
            this.FormHelpTextBox.Size = new System.Drawing.Size(213, 20);
            this.FormHelpTextBox.TabIndex = 17;
            // 
            // FormLabelTextBox
            // 
            this.FormLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "FormLabel", true));
            this.FormLabelTextBox.Location = new System.Drawing.Point(337, 9);
            this.FormLabelTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FormLabelTextBox.Name = "FormLabelTextBox";
            this.FormLabelTextBox.Size = new System.Drawing.Size(213, 20);
            this.FormLabelTextBox.TabIndex = 16;
            // 
            // FormNameTextBox
            // 
            this.FormNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "FormName", true));
            this.FormNameTextBox.Location = new System.Drawing.Point(75, 31);
            this.FormNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FormNameTextBox.Name = "FormNameTextBox";
            this.FormNameTextBox.Size = new System.Drawing.Size(184, 20);
            this.FormNameTextBox.TabIndex = 15;
            // 
            // IsCreateMenuItemCheckBox
            // 
            this.IsCreateMenuItemCheckBox.AutoSize = true;
            this.IsCreateMenuItemCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.formBuilderParmsBindingSource, "IsCreateMenuItem", true));
            this.IsCreateMenuItemCheckBox.Location = new System.Drawing.Point(111, 56);
            this.IsCreateMenuItemCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.IsCreateMenuItemCheckBox.Name = "IsCreateMenuItemCheckBox";
            this.IsCreateMenuItemCheckBox.Size = new System.Drawing.Size(15, 14);
            this.IsCreateMenuItemCheckBox.TabIndex = 14;
            this.IsCreateMenuItemCheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 252);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Create ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 91);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
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
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
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
            this.GridGroupNameTextBox2.Margin = new System.Windows.Forms.Padding(2);
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
            this.tabPage2.Controls.Add(this.ParamsValuesTextBox);
            this.tabPage2.Controls.Add(this.ParamsLabelsTextBox);
            this.tabPage2.Controls.Add(this.labelValuesCol);
            this.tabPage2.Controls.Add(this.labelParamsCol);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(504, 125);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "SimpleListDetails";
            this.tabPage2.Text = "SimpleListDetails-Tabular";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ParamsValuesTextBox
            // 
            this.ParamsValuesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formBuilderParmsBindingSource, "SimpleListDetailsValues", true));
            this.ParamsValuesTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParamsValuesTextBox.Location = new System.Drawing.Point(226, 22);
            this.ParamsValuesTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ParamsValuesTextBox.Multiline = true;
            this.ParamsValuesTextBox.Name = "ParamsValuesTextBox";
            this.ParamsValuesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ParamsValuesTextBox.Size = new System.Drawing.Size(270, 96);
            this.ParamsValuesTextBox.TabIndex = 20;
            this.ParamsValuesTextBox.WordWrap = false;
            // 
            // ParamsLabelsTextBox
            // 
            this.ParamsLabelsTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ParamsLabelsTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParamsLabelsTextBox.Location = new System.Drawing.Point(12, 22);
            this.ParamsLabelsTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ParamsLabelsTextBox.Multiline = true;
            this.ParamsLabelsTextBox.Name = "ParamsLabelsTextBox";
            this.ParamsLabelsTextBox.ReadOnly = true;
            this.ParamsLabelsTextBox.Size = new System.Drawing.Size(210, 96);
            this.ParamsLabelsTextBox.TabIndex = 21;
            this.ParamsLabelsTextBox.TabStop = false;
            this.ParamsLabelsTextBox.Text = "Grid group\r\nHeader group\r\nTabs (add \',list\' for grid)";
            this.ParamsLabelsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ParamsLabelsTextBox.WordWrap = false;
            // 
            // labelValuesCol
            // 
            this.labelValuesCol.AutoSize = true;
            this.labelValuesCol.Location = new System.Drawing.Point(226, 5);
            this.labelValuesCol.Name = "labelValuesCol";
            this.labelValuesCol.Size = new System.Drawing.Size(39, 13);
            this.labelValuesCol.TabIndex = 22;
            this.labelValuesCol.Text = "Values";
            // 
            // labelParamsCol
            // 
            this.labelParamsCol.AutoSize = true;
            this.labelParamsCol.Location = new System.Drawing.Point(10, 5);
            this.labelParamsCol.Name = "labelParamsCol";
            this.labelParamsCol.Size = new System.Drawing.Size(60, 13);
            this.labelParamsCol.TabIndex = 19;
            this.labelParamsCol.Text = "Parameters";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TableNameTextBox;
        private System.Windows.Forms.TextBox FormHelpTextBox;
        private System.Windows.Forms.TextBox FormLabelTextBox;
        private System.Windows.Forms.TextBox FormNameTextBox;
        private System.Windows.Forms.CheckBox IsCreateMenuItemCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource formBuilderParmsBindingSource;
        private System.Windows.Forms.TextBox GridGroupNameTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ParamsLabelsTextBox;
        private System.Windows.Forms.TextBox ParamsValuesTextBox;
        private System.Windows.Forms.Label labelParamsCol;
        private System.Windows.Forms.Label labelValuesCol;
    }
}
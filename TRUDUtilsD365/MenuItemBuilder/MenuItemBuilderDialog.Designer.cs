namespace TRUDUtilsD365.MenuItemBuilder
{
    partial class MenuItemBuilderDialog
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TableNameTextBox = new System.Windows.Forms.TextBox();
            this.menuItemBuilderParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FormHelpTextBox = new System.Windows.Forms.TextBox();
            this.FormLabelTextBox = new System.Windows.Forms.TextBox();
            this.FormNameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemBuilderParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Object name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Menu item name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Label:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Help text:";
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TableNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemBuilderParmsBindingSource, "ObjectName", true));
            this.TableNameTextBox.Location = new System.Drawing.Point(88, 6);
            this.TableNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(223, 20);
            this.TableNameTextBox.TabIndex = 100;
            // 
            // menuItemBuilderParmsBindingSource
            // 
            this.menuItemBuilderParmsBindingSource.DataSource = typeof(TRUDUtilsD365.MenuItemBuilder.MenuItemBuilderParms);
            // 
            // FormHelpTextBox
            // 
            this.FormHelpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemBuilderParmsBindingSource, "FormHelp", true));
            this.FormHelpTextBox.Location = new System.Drawing.Point(88, 103);
            this.FormHelpTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FormHelpTextBox.Name = "FormHelpTextBox";
            this.FormHelpTextBox.Size = new System.Drawing.Size(223, 20);
            this.FormHelpTextBox.TabIndex = 2;
            // 
            // FormLabelTextBox
            // 
            this.FormLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemBuilderParmsBindingSource, "FormLabel", true));
            this.FormLabelTextBox.Location = new System.Drawing.Point(88, 80);
            this.FormLabelTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FormLabelTextBox.Name = "FormLabelTextBox";
            this.FormLabelTextBox.Size = new System.Drawing.Size(223, 20);
            this.FormLabelTextBox.TabIndex = 1;
            // 
            // FormNameTextBox
            // 
            this.FormNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemBuilderParmsBindingSource, "MenuItemName", true));
            this.FormNameTextBox.Location = new System.Drawing.Point(88, 57);
            this.FormNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FormNameTextBox.Name = "FormNameTextBox";
            this.FormNameTextBox.Size = new System.Drawing.Size(223, 20);
            this.FormNameTextBox.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 131);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Create Menu item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.menuItemBuilderParmsBindingSource, "MenuItemType", true));
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.menuItemBuilderParmsBindingSource, "MenuItemType", true));
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemBuilderParmsBindingSource, "MenuItemType", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 28);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 21);
            this.comboBox1.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Type:";
            // 
            // MenuItemBuilderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 165);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FormHelpTextBox);
            this.Controls.Add(this.FormLabelTextBox);
            this.Controls.Add(this.FormNameTextBox);
            this.Controls.Add(this.TableNameTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Name = "MenuItemBuilderDialog";
            this.Text = "Create Menu item";
            ((System.ComponentModel.ISupportInitialize)(this.menuItemBuilderParmsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TableNameTextBox;
        private System.Windows.Forms.TextBox FormHelpTextBox;
        private System.Windows.Forms.TextBox FormLabelTextBox;
        private System.Windows.Forms.TextBox FormNameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource menuItemBuilderParmsBindingSource;
    }
}
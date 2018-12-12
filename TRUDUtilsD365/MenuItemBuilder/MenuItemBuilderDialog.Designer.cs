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
            this.FormHelpTextBox = new System.Windows.Forms.TextBox();
            this.FormLabelTextBox = new System.Windows.Forms.TextBox();
            this.FormNameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuItemBuilderParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.menuItemBuilderParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Object name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 82);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Menu item name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(78, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Label:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(56, 142);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Help text:";
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TableNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemBuilderParmsBindingSource, "ObjectName", true));
            this.TableNameTextBox.Location = new System.Drawing.Point(132, 8);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(274, 24);
            this.TableNameTextBox.TabIndex = 100;
            // 
            // FormHelpTextBox
            // 
            this.FormHelpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemBuilderParmsBindingSource, "FormHelp", true));
            this.FormHelpTextBox.Location = new System.Drawing.Point(132, 139);
            this.FormHelpTextBox.Name = "FormHelpTextBox";
            this.FormHelpTextBox.Size = new System.Drawing.Size(274, 24);
            this.FormHelpTextBox.TabIndex = 2;
            // 
            // FormLabelTextBox
            // 
            this.FormLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemBuilderParmsBindingSource, "FormLabel", true));
            this.FormLabelTextBox.Location = new System.Drawing.Point(132, 109);
            this.FormLabelTextBox.Name = "FormLabelTextBox";
            this.FormLabelTextBox.Size = new System.Drawing.Size(274, 24);
            this.FormLabelTextBox.TabIndex = 1;
            // 
            // FormNameTextBox
            // 
            this.FormNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemBuilderParmsBindingSource, "MenuItemName", true));
            this.FormNameTextBox.Location = new System.Drawing.Point(132, 79);
            this.FormNameTextBox.Name = "FormNameTextBox";
            this.FormNameTextBox.Size = new System.Drawing.Size(274, 24);
            this.FormNameTextBox.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(39, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 32);
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
            this.comboBox1.Location = new System.Drawing.Point(132, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(274, 26);
            this.comboBox1.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 102;
            this.label1.Text = "Type:";
            // 
            // menuItemBuilderParmsBindingSource
            // 
            this.menuItemBuilderParmsBindingSource.DataSource = typeof(TRUDUtilsD365.MenuItemBuilder.MenuItemBuilderParms);
            // 
            // MenuItemBuilderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 225);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
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
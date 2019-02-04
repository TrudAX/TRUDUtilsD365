namespace TRUDUtilsD365.CreateTableRelation
{
    partial class CreateTableRelationDialog
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
            this.TableNameTextBox = new System.Windows.Forms.TextBox();
            this.RelationNameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.FieldNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createTableRelationParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.createTableRelationParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Table name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 93);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Relation name:";
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TableNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createTableRelationParmsBindingSource, "TableName", true));
            this.TableNameTextBox.Location = new System.Drawing.Point(132, 15);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(330, 24);
            this.TableNameTextBox.TabIndex = 100;
            // 
            // RelationNameTextBox
            // 
            this.RelationNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createTableRelationParmsBindingSource, "RelationName", true));
            this.RelationNameTextBox.Location = new System.Drawing.Point(132, 90);
            this.RelationNameTextBox.Name = "RelationNameTextBox";
            this.RelationNameTextBox.Size = new System.Drawing.Size(330, 24);
            this.RelationNameTextBox.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "Create relation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FieldNameTextBox
            // 
            this.FieldNameTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.FieldNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createTableRelationParmsBindingSource, "SelectedField", true));
            this.FieldNameTextBox.Location = new System.Drawing.Point(132, 45);
            this.FieldNameTextBox.Name = "FieldNameTextBox";
            this.FieldNameTextBox.Size = new System.Drawing.Size(330, 24);
            this.FieldNameTextBox.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 101;
            this.label1.Text = "Field name:";
            // 
            // createTableRelationParmsBindingSource
            // 
            this.createTableRelationParmsBindingSource.DataSource = typeof(TRUDUtilsD365.CreateTableRelation.CreateTableRelationParms);
            // 
            // CreateTableRelationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 181);
            this.Controls.Add(this.FieldNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RelationNameTextBox);
            this.Controls.Add(this.TableNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateTableRelationDialog";
            this.Text = "Create Table Relation";
            ((System.ComponentModel.ISupportInitialize)(this.createTableRelationParmsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TableNameTextBox;
        private System.Windows.Forms.TextBox RelationNameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox FieldNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource createTableRelationParmsBindingSource;
    }
}
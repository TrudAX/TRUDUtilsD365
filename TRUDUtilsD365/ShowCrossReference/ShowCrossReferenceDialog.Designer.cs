namespace TRUDUtilsD365.ShowCrossReference
{
    partial class ShowCrossReferenceDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.FieldNameLabel = new System.Windows.Forms.TextBox();
            this.ReferenceCountLabel = new System.Windows.Forms.Label();
            this.ModuleFilterLabel = new System.Windows.Forms.Label();
            this.ModuleComboBox = new System.Windows.Forms.ComboBox();
            this.AccessFilterLabel = new System.Windows.Forms.Label();
            this.AccessComboBox = new System.Windows.Forms.ComboBox();
            this.GoToSourceButton = new System.Windows.Forms.Button();
            this.DefaultSortButton = new System.Windows.Forms.Button();
            this.CopyToClipboardButton = new System.Windows.Forms.Button();
            this.CodeLinesLabel = new System.Windows.Forms.Label();
            this.CodeLinesUpDown = new System.Windows.Forms.NumericUpDown();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.crossReferenceGrid = new System.Windows.Forms.DataGridView();
            this.CodePreviewTextBox = new System.Windows.Forms.TextBox();
            this.colElementType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colElementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMethodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodeLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccessType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceModule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.crossReferenceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeLinesUpDown)).BeginInit();
            this.SuspendLayout();
            //
            // FieldNameLabel
            //
            this.FieldNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FieldNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldNameLabel.Location = new System.Drawing.Point(12, 9);
            this.FieldNameLabel.Name = "FieldNameLabel";
            this.FieldNameLabel.Size = new System.Drawing.Size(500, 17);
            this.FieldNameLabel.TabIndex = 0;
            this.FieldNameLabel.Text = "Table.FieldName";
            this.FieldNameLabel.BackColor = System.Drawing.SystemColors.Control;
            //
            // ReferenceCountLabel
            //
            this.ReferenceCountLabel.AutoSize = true;
            this.ReferenceCountLabel.Location = new System.Drawing.Point(12, 34);
            this.ReferenceCountLabel.Name = "ReferenceCountLabel";
            this.ReferenceCountLabel.Size = new System.Drawing.Size(70, 13);
            this.ReferenceCountLabel.TabIndex = 1;
            this.ReferenceCountLabel.Text = "References: 0";
            //
            // ModuleFilterLabel
            //
            this.ModuleFilterLabel.AutoSize = true;
            this.ModuleFilterLabel.Location = new System.Drawing.Point(160, 34);
            this.ModuleFilterLabel.Name = "ModuleFilterLabel";
            this.ModuleFilterLabel.Size = new System.Drawing.Size(45, 13);
            this.ModuleFilterLabel.TabIndex = 2;
            this.ModuleFilterLabel.Text = "Module:";
            //
            // ModuleComboBox
            //
            this.ModuleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModuleComboBox.FormattingEnabled = true;
            this.ModuleComboBox.Location = new System.Drawing.Point(210, 30);
            this.ModuleComboBox.Name = "ModuleComboBox";
            this.ModuleComboBox.Size = new System.Drawing.Size(150, 21);
            this.ModuleComboBox.TabIndex = 3;
            this.ModuleComboBox.SelectedIndexChanged += new System.EventHandler(this.ModuleComboBox_SelectedIndexChanged);
            //
            // AccessFilterLabel
            //
            this.AccessFilterLabel.AutoSize = true;
            this.AccessFilterLabel.Location = new System.Drawing.Point(375, 34);
            this.AccessFilterLabel.Name = "AccessFilterLabel";
            this.AccessFilterLabel.Size = new System.Drawing.Size(42, 13);
            this.AccessFilterLabel.TabIndex = 4;
            this.AccessFilterLabel.Text = "Access:";
            //
            // AccessComboBox
            //
            this.AccessComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccessComboBox.FormattingEnabled = true;
            this.AccessComboBox.Location = new System.Drawing.Point(420, 30);
            this.AccessComboBox.Name = "AccessComboBox";
            this.AccessComboBox.Size = new System.Drawing.Size(100, 21);
            this.AccessComboBox.TabIndex = 5;
            this.AccessComboBox.SelectedIndexChanged += new System.EventHandler(this.AccessComboBox_SelectedIndexChanged);
            //
            // GoToSourceButton
            //
            this.GoToSourceButton.Location = new System.Drawing.Point(12, 55);
            this.GoToSourceButton.Name = "GoToSourceButton";
            this.GoToSourceButton.Size = new System.Drawing.Size(100, 26);
            this.GoToSourceButton.TabIndex = 6;
            this.GoToSourceButton.Text = "Go to source";
            this.GoToSourceButton.UseVisualStyleBackColor = true;
            this.GoToSourceButton.Click += new System.EventHandler(this.GoToSourceButton_Click);
            //
            // DefaultSortButton
            //
            this.DefaultSortButton.Location = new System.Drawing.Point(117, 55);
            this.DefaultSortButton.Name = "DefaultSortButton";
            this.DefaultSortButton.Size = new System.Drawing.Size(100, 26);
            this.DefaultSortButton.TabIndex = 7;
            this.DefaultSortButton.Text = "Default sort";
            this.DefaultSortButton.UseVisualStyleBackColor = true;
            this.DefaultSortButton.Click += new System.EventHandler(this.DefaultSortButton_Click);
            //
            // CopyToClipboardButton
            //
            this.CopyToClipboardButton.Location = new System.Drawing.Point(222, 55);
            this.CopyToClipboardButton.Name = "CopyToClipboardButton";
            this.CopyToClipboardButton.Size = new System.Drawing.Size(120, 26);
            this.CopyToClipboardButton.TabIndex = 8;
            this.CopyToClipboardButton.Text = "Copy to clipboard";
            this.CopyToClipboardButton.UseVisualStyleBackColor = true;
            this.CopyToClipboardButton.Click += new System.EventHandler(this.CopyToClipboardButton_Click);
            //
            // CodeLinesLabel
            //
            this.CodeLinesLabel.AutoSize = true;
            this.CodeLinesLabel.Location = new System.Drawing.Point(362, 61);
            this.CodeLinesLabel.Name = "CodeLinesLabel";
            this.CodeLinesLabel.Size = new System.Drawing.Size(60, 13);
            this.CodeLinesLabel.TabIndex = 9;
            this.CodeLinesLabel.Text = "Code lines:";
            //
            // CodeLinesUpDown
            //
            this.CodeLinesUpDown.Location = new System.Drawing.Point(432, 57);
            this.CodeLinesUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.CodeLinesUpDown.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            this.CodeLinesUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.CodeLinesUpDown.Name = "CodeLinesUpDown";
            this.CodeLinesUpDown.Size = new System.Drawing.Size(50, 20);
            this.CodeLinesUpDown.TabIndex = 10;
            //
            // RefreshButton
            //
            this.RefreshButton.Location = new System.Drawing.Point(487, 55);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 26);
            this.RefreshButton.TabIndex = 11;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            //
            // crossReferenceGrid
            //
            this.crossReferenceGrid.AllowUserToAddRows = false;
            this.crossReferenceGrid.AllowUserToDeleteRows = false;
            this.crossReferenceGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crossReferenceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crossReferenceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colElementType,
            this.colElementName,
            this.colMethodName,
            this.colLineNumber,
            this.colColumnNumber,
            this.colCodeLine,
            this.colAccessType,
            this.colSourceModule});
            this.crossReferenceGrid.Location = new System.Drawing.Point(12, 85);
            this.crossReferenceGrid.MultiSelect = false;
            this.crossReferenceGrid.Name = "crossReferenceGrid";
            this.crossReferenceGrid.ReadOnly = true;
            this.crossReferenceGrid.RowHeadersVisible = false;
            this.crossReferenceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.crossReferenceGrid.Size = new System.Drawing.Size(1376, 446);
            this.crossReferenceGrid.TabIndex = 12;
            this.crossReferenceGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.crossReferenceGrid_CellDoubleClick);
            this.crossReferenceGrid.SelectionChanged += new System.EventHandler(this.crossReferenceGrid_SelectionChanged);
            this.crossReferenceGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.crossReferenceGrid_CellFormatting);
            //
            // CodePreviewTextBox
            //
            this.CodePreviewTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodePreviewTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodePreviewTextBox.Location = new System.Drawing.Point(12, 535);
            this.CodePreviewTextBox.Multiline = true;
            this.CodePreviewTextBox.Name = "CodePreviewTextBox";
            this.CodePreviewTextBox.ReadOnly = true;
            this.CodePreviewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.CodePreviewTextBox.Size = new System.Drawing.Size(1376, 40);
            this.CodePreviewTextBox.TabIndex = 13;
            this.CodePreviewTextBox.WordWrap = false;
            this.CodePreviewTextBox.BackColor = System.Drawing.SystemColors.Window;
            //
            // colElementType
            //
            this.colElementType.DataPropertyName = "ElementType";
            this.colElementType.HeaderText = "Type";
            this.colElementType.Name = "colElementType";
            this.colElementType.ReadOnly = true;
            this.colElementType.Width = 70;
            //
            // colElementName
            //
            this.colElementName.DataPropertyName = "ElementName";
            this.colElementName.HeaderText = "Element";
            this.colElementName.Name = "colElementName";
            this.colElementName.ReadOnly = true;
            this.colElementName.Width = 150;
            //
            // colMethodName
            //
            this.colMethodName.DataPropertyName = "MethodName";
            this.colMethodName.HeaderText = "Method";
            this.colMethodName.Name = "colMethodName";
            this.colMethodName.ReadOnly = true;
            this.colMethodName.Width = 130;
            //
            // colLineNumber
            //
            this.colLineNumber.DataPropertyName = "LineNumber";
            this.colLineNumber.HeaderText = "Line";
            this.colLineNumber.Name = "colLineNumber";
            this.colLineNumber.ReadOnly = true;
            this.colLineNumber.Width = 50;
            //
            // colColumnNumber
            //
            this.colColumnNumber.DataPropertyName = "ColumnNumber";
            this.colColumnNumber.HeaderText = "Column";
            this.colColumnNumber.Name = "colColumnNumber";
            this.colColumnNumber.ReadOnly = true;
            this.colColumnNumber.Width = 55;
            //
            // colCodeLine
            //
            this.colCodeLine.DataPropertyName = "CodeLine";
            this.colCodeLine.HeaderText = "Code";
            this.colCodeLine.Name = "colCodeLine";
            this.colCodeLine.ReadOnly = true;
            this.colCodeLine.Width = 720;
            //
            // colAccessType
            //
            this.colAccessType.DataPropertyName = "AccessType";
            this.colAccessType.HeaderText = "Access";
            this.colAccessType.Name = "colAccessType";
            this.colAccessType.ReadOnly = true;
            this.colAccessType.Width = 70;
            //
            // colSourceModule
            //
            this.colSourceModule.DataPropertyName = "SourceModule";
            this.colSourceModule.HeaderText = "Module";
            this.colSourceModule.Name = "colSourceModule";
            this.colSourceModule.ReadOnly = true;
            this.colSourceModule.Width = 100;
            //
            // ShowCrossReferenceDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 561);
            this.Controls.Add(this.CodePreviewTextBox);
            this.Controls.Add(this.crossReferenceGrid);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.CodeLinesUpDown);
            this.Controls.Add(this.CodeLinesLabel);
            this.Controls.Add(this.CopyToClipboardButton);
            this.Controls.Add(this.DefaultSortButton);
            this.Controls.Add(this.GoToSourceButton);
            this.Controls.Add(this.AccessComboBox);
            this.Controls.Add(this.AccessFilterLabel);
            this.Controls.Add(this.ModuleComboBox);
            this.Controls.Add(this.ModuleFilterLabel);
            this.Controls.Add(this.ReferenceCountLabel);
            this.Controls.Add(this.FieldNameLabel);
            this.Name = "ShowCrossReferenceDialog";
            this.Text = "TRUDUtils - Cross-references";
            ((System.ComponentModel.ISupportInitialize)(this.crossReferenceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeLinesUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox FieldNameLabel;
        private System.Windows.Forms.Label ReferenceCountLabel;
        private System.Windows.Forms.Label ModuleFilterLabel;
        private System.Windows.Forms.ComboBox ModuleComboBox;
        private System.Windows.Forms.Label AccessFilterLabel;
        private System.Windows.Forms.ComboBox AccessComboBox;
        private System.Windows.Forms.Button GoToSourceButton;
        private System.Windows.Forms.Button DefaultSortButton;
        private System.Windows.Forms.Button CopyToClipboardButton;
        private System.Windows.Forms.Label CodeLinesLabel;
        private System.Windows.Forms.NumericUpDown CodeLinesUpDown;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.DataGridView crossReferenceGrid;
        private System.Windows.Forms.TextBox CodePreviewTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMethodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodeLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccessType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceModule;
    }
}

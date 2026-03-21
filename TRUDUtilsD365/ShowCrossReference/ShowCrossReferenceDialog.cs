using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace TRUDUtilsD365.ShowCrossReference
{
    public partial class ShowCrossReferenceDialog : Form
    {
        private ShowCrossReferenceParms _parms;
        private bool _initializing;

        public ShowCrossReferenceDialog()
        {
            InitializeComponent();
        }

        public void SetParameters(ShowCrossReferenceParms parms)
        {
            _initializing = true;
            _parms = parms;

            FieldNameLabel.Text = parms.DisplayName;
            ReferenceCountLabel.Text = $"References: {parms.References.Count}";

            // Populate module filter
            ModuleComboBox.Items.Clear();
            ModuleComboBox.Items.Add("All");
            foreach (string module in parms.GetDistinctModules())
                ModuleComboBox.Items.Add(module);
            ModuleComboBox.SelectedIndex = 0;

            // Populate access filter
            AccessComboBox.Items.Clear();
            AccessComboBox.Items.Add("All");
            AccessComboBox.Items.Add("Read");
            AccessComboBox.Items.Add("Write");
            AccessComboBox.SelectedIndex = 0;

            _initializing = false;

            crossReferenceGrid.AutoGenerateColumns = false;
            crossReferenceGrid.DataSource = parms.References;

            AdjustLayout();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            if (crossReferenceGrid == null || CodePreviewTextBox == null) return;

            // Position textbox at form bottom
            CodePreviewTextBox.Top = this.ClientSize.Height - CodePreviewTextBox.Height - 6;

            // Grid fills space between its top and the textbox
            crossReferenceGrid.Height = CodePreviewTextBox.Top - crossReferenceGrid.Top - 4;
        }

        private void GoToSourceButton_Click(object sender, EventArgs e)
        {
            NavigateToSelectedRow();
        }

        private void crossReferenceGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                NavigateToSelectedRow();
            }
        }

        private void crossReferenceGrid_SelectionChanged(object sender, EventArgs e)
        {
            UpdateCodePreview();
        }

        private void crossReferenceGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void UpdateCodePreview()
        {
            if (crossReferenceGrid.CurrentRow?.DataBoundItem is CrossReferenceEntry entry)
            {
                CodePreviewTextBox.Text = entry.CodeLine ?? "";
            }
            else
            {
                CodePreviewTextBox.Text = "";
            }
        }

        private void NavigateToSelectedRow()
        {
            if (crossReferenceGrid.CurrentRow?.DataBoundItem is CrossReferenceEntry entry)
            {
                try
                {
                    _parms.NavigateToSource(entry);
                }
                catch (Exception ex)
                {
                    CoreUtility.HandleExceptionWithErrorMessage(ex);
                }
            }
        }

        private void DefaultSortButton_Click(object sender, EventArgs e)
        {
            if (_parms != null)
            {
                _parms.ApplyDefaultSort();
            }
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            if (crossReferenceGrid.Rows.Count == 0)
                return;

            var orderedColumns = crossReferenceGrid.Columns.Cast<DataGridViewColumn>()
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            var sb = new StringBuilder();

            for (int i = 0; i < orderedColumns.Count; i++)
            {
                if (i > 0) sb.Append('\t');
                sb.Append(orderedColumns[i].HeaderText);
            }
            sb.AppendLine();

            foreach (DataGridViewRow row in crossReferenceGrid.Rows)
            {
                for (int i = 0; i < orderedColumns.Count; i++)
                {
                    if (i > 0) sb.Append('\t');
                    string val = row.Cells[orderedColumns[i].Index].Value?.ToString() ?? "";
                    if (val.Contains("\n") || val.Contains("\t") || val.Contains("\""))
                    {
                        val = "\"" + val.Replace("\"", "\"\"") + "\"";
                    }
                    sb.Append(val);
                }
                sb.AppendLine();
            }

            Clipboard.SetText(sb.ToString());
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (_parms == null) return;

            int totalLines = (int)CodeLinesUpDown.Value;
            _parms.ReloadCodeLines(totalLines);

            // Enable wrap so \n renders as line breaks in Code column
            colCodeLine.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // Disable auto-size so we control row height
            crossReferenceGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // Calculate fixed row height for N lines
            using (var g = crossReferenceGrid.CreateGraphics())
            {
                var font = crossReferenceGrid.DefaultCellStyle.Font ?? crossReferenceGrid.Font;
                int singleLineHeight = (int)Math.Ceiling(g.MeasureString("Xg", font).Height);
                int rowHeight = singleLineHeight * totalLines + 4;
                crossReferenceGrid.RowTemplate.Height = rowHeight;
                foreach (DataGridViewRow row in crossReferenceGrid.Rows)
                {
                    row.Height = rowHeight;
                }
            }

            // Resize code preview textbox to match code lines
            CodePreviewTextBox.Height = (int)(CodePreviewTextBox.Font.Height * totalLines * 1.2) + 12;
            AdjustLayout();

            UpdateCodePreview();
        }

        private void ApplyFilters()
        {
            if (_parms == null || _initializing) return;

            string moduleFilter = ModuleComboBox.SelectedItem?.ToString() ?? "All";
            string accessFilter = AccessComboBox.SelectedItem?.ToString() ?? "All";

            _parms.ApplyFilters(moduleFilter, accessFilter);
            ReferenceCountLabel.Text = $"References: {_parms.References.Count}";
        }

        private void ModuleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void AccessComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}

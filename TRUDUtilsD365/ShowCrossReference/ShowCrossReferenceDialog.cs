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

            AdjustGridHeight();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustGridHeight();
        }

        private void AdjustGridHeight()
        {
            if (crossReferenceGrid != null && CodePreviewTextBox != null)
            {
                crossReferenceGrid.Height = CodePreviewTextBox.Top - crossReferenceGrid.Top - 4;
            }
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

            // Get columns in display order
            var orderedColumns = crossReferenceGrid.Columns.Cast<DataGridViewColumn>()
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            var sb = new StringBuilder();

            // Header row
            for (int i = 0; i < orderedColumns.Count; i++)
            {
                if (i > 0) sb.Append('\t');
                sb.Append(orderedColumns[i].HeaderText);
            }
            sb.AppendLine();

            // Data rows
            foreach (DataGridViewRow row in crossReferenceGrid.Rows)
            {
                for (int i = 0; i < orderedColumns.Count; i++)
                {
                    if (i > 0) sb.Append('\t');
                    string val = row.Cells[orderedColumns[i].Index].Value?.ToString() ?? "";
                    val = val.Replace("\r\n", " ").Replace("\n", " ");
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

            // Toggle grid WrapMode based on code lines
            if (totalLines > 1)
            {
                colCodeLine.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                crossReferenceGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            else
            {
                colCodeLine.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                crossReferenceGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            }

            // Resize code preview textbox to match code lines
            int lineHeight = CodePreviewTextBox.Font.Height;
            int newHeight = totalLines * lineHeight + 8;
            CodePreviewTextBox.Height = newHeight;
            AdjustGridHeight();

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

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CollegeLMS
{
    internal static class UiTheme
    {
        internal static readonly Color BrandBlue = Color.FromArgb(31, 84, 147);
        internal static readonly Color GridAltRow = Color.FromArgb(235, 244, 255);
        internal static readonly Color GridHoverRow = Color.FromArgb(210, 230, 255);
        internal static readonly Color GridLine = Color.FromArgb(140, 204, 235);

        internal static void ApplyFormDefaults(Form form)
        {
            if (form == null) return;

            form.AutoScaleMode = AutoScaleMode.Dpi;
            form.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.KeyPreview = true;
        }

        internal static void ApplyHeader(Label title, Label subtitle)
        {
            if (title != null)
            {
                title.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
                title.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (subtitle != null)
            {
                subtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
                subtitle.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        internal static void ApplyStatusLabel(Label statusLabel)
        {
            if (statusLabel == null) return;
            statusLabel.AutoSize = false;
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusLabel.Padding = new Padding(8, 0, 0, 0);
        }

        internal static void ApplyGridDefaults(DataGridView grid)
        {
            if (grid == null) return;

            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.RowHeadersVisible = false;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.BackgroundColor = Color.White;
            grid.GridColor = GridLine;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = BrandBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
            grid.ColumnHeadersHeight = 36;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            grid.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
            grid.RowTemplate.Height = 34;
            grid.AlternatingRowsDefaultCellStyle.BackColor = GridAltRow;
            grid.DefaultCellStyle.SelectionBackColor = BrandBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        internal static void WireGridRowHover(DataGridView grid)
        {
            if (grid == null) return;

            grid.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = GridHoverRow;
                    grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            };

            grid.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = (e.RowIndex % 2 == 0)
                        ? Color.White
                        : GridAltRow;
                    grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            };
        }

        internal static void WireCommonShortcuts(Form form, Func<Control> findSearchBox = null, Action triggerSearch = null)
        {
            if (form == null) return;

            form.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.F)
                {
                    Control box = findSearchBox?.Invoke();
                    if (box != null)
                    {
                        box.Focus();
                        if (box is TextBox tb) tb.SelectAll();
                        e.SuppressKeyPress = true;
                    }
                }

                if (e.KeyCode == Keys.F5)
                {
                    triggerSearch?.Invoke();
                    e.SuppressKeyPress = true;
                }

                if (e.KeyCode == Keys.Escape && form.ActiveControl is TextBox activeTb)
                {
                    activeTb.Clear();
                    e.SuppressKeyPress = true;
                }
            };
        }
    }
}


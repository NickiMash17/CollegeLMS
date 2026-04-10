using System;
using System.Drawing;
using System.Windows.Forms;

namespace CollegeLMS
{
    internal static class UiTheme
    {
        internal static readonly Color BrandBlue = Color.FromArgb(31, 84, 147);
        internal static readonly Color BrandBlueDark = Color.FromArgb(20, 63, 120);
        internal static readonly Color Surface = Color.White;
        internal static readonly Color AppBackground = Color.FromArgb(245, 248, 255);
        internal static readonly Color GridAltRow = Color.FromArgb(235, 244, 255);
        internal static readonly Color GridHoverRow = Color.FromArgb(210, 230, 255);
        internal static readonly Color GridLine = Color.FromArgb(140, 204, 235);

        internal static readonly Font FontBase = new Font("Segoe UI", 9F, FontStyle.Regular);
        internal static readonly Font FontHeaderTitle = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
        internal static readonly Font FontHeaderSubtitle = new Font("Segoe UI", 10F, FontStyle.Italic);
        internal static readonly Font FontNav = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        internal static readonly Font FontButton = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        internal static readonly Font FontCardTitle = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        internal static readonly Font FontCardSubtitle = new Font("Segoe UI", 9F, FontStyle.Regular);
        internal static readonly Font FontEmojiLarge = new Font("Segoe UI Emoji", 18F, FontStyle.Regular);
        internal static readonly Font FontGridHeader = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        internal static readonly Font FontGridCell = new Font("Segoe UI", 9.5F, FontStyle.Regular);

        internal static void ApplyFormDefaults(Form form)
        {
            if (form == null) return;

            form.AutoScaleMode = AutoScaleMode.Dpi;
            form.Font = FontBase;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.KeyPreview = true;
            form.BackColor = AppBackground;
        }

        internal static void ApplyHeader(Label title, Label subtitle)
        {
            if (title != null)
            {
                title.Font = FontHeaderTitle;
                title.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (subtitle != null)
            {
                subtitle.Font = FontHeaderSubtitle;
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
            grid.BackgroundColor = Surface;
            grid.GridColor = GridLine;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = BrandBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = FontGridHeader;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            grid.ColumnHeadersHeight = 32;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.DefaultCellStyle.Font = FontGridCell;
            grid.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            grid.RowTemplate.Height = 28;
            grid.RowTemplate.MinimumHeight = 24;
            grid.AlternatingRowsDefaultCellStyle.BackColor = GridAltRow;
            grid.DefaultCellStyle.SelectionBackColor = BrandBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        internal static void ApplyNavButton(Button button)
        {
            if (button == null) return;
            button.Font = FontNav;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }

        internal static void ApplyActionButton(Button button)
        {
            if (button == null) return;
            button.Font = FontButton;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
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

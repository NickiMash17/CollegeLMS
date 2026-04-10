// ============================================================
// COPYRIGHT NOTICE
// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba
// Student No:  20232990
// ? 2026 Nicolette Mashaba. All rights reserved.
// ============================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CollegeLMS
{
    public partial class ModulesForm : Form
    {
        DataTable currentTable = new DataTable();
        private bool navOffsetApplied = false;
        private readonly Dictionary<Button, Point> buttonPositions = new Dictionary<Button, Point>();
        private readonly List<Button> shadowButtons = new List<Button>();
        private Button activeNavButton;

        public ModulesForm()
        {
            InitializeComponent();
            UiTheme.ApplyFormDefaults(this);
            this.DoubleBuffered = true;
            this.Resize += ModulesForm_Resize;
            this.Paint += ModulesForm_Paint;

            UiTheme.WireCommonShortcuts(
                this,
                triggerSearch: LoadModules);
        }

        private void ModulesForm_Load(object sender, EventArgs e)
        {
            ApplyNavOffset();
            LoadModules();
            SetupGrid();
            EnhanceUI();
        }

        private void ModulesForm_Resize(object sender, EventArgs e)
        {
            CenterHeader();
            CenterNavButtons();
            ApplyRoundedAll();
        }

        private void EnhanceUI()
        {
            ApplyIconText();
            UiTheme.ApplyHeader(lblTitle, lblSubTitle);

            UiTheme.ApplyNavButton(btnNavDashboard);
            UiTheme.ApplyNavButton(btnNavStudents);
            UiTheme.ApplyNavButton(btnNavCourses);
            UiTheme.ApplyNavButton(btnNavDepartments);
            UiTheme.ApplyNavButton(btnNavModules);
            UiTheme.ApplyNavButton(btnNavLecturers);

            UiTheme.ApplyActionButton(btnAdd);
            UiTheme.ApplyActionButton(btnUpdate);
            UiTheme.ApplyActionButton(btnDelete);
            UiTheme.ApplyActionButton(btnClear);
            UiTheme.ApplyActionButton(btnBack);

            ApplyButtonHover(btnAdd);
            ApplyButtonHover(btnUpdate);
            ApplyButtonHover(btnDelete);
            ApplyButtonHover(btnClear);
            ApplyButtonHover(btnBack);

            WireButtonLift(btnAdd);
            WireButtonLift(btnUpdate);
            WireButtonLift(btnDelete);
            WireButtonLift(btnClear);
            WireButtonLift(btnBack);

            ApplyNavHover(btnNavDashboard);
            ApplyNavHover(btnNavStudents);
            ApplyNavHover(btnNavCourses);
            ApplyNavHover(btnNavDepartments);
            ApplyNavHover(btnNavModules);
            ApplyNavHover(btnNavLecturers);
            SetActiveNav(btnNavModules);

            CenterHeader();
            CenterNavButtons();
            ApplyRoundedAll();
            if (pnlNav != null) pnlNav.Paint += NavBar_Paint;
            PolishStatusBar();
        }

        private void CenterHeader()
        {
            if (pnlTitle == null || lblTitle == null || lblSubTitle == null) return;
            UiTheme.ApplyHeader(lblTitle, lblSubTitle);
            lblTitle.Left = (pnlTitle.Width - lblTitle.Width) / 2;
            lblSubTitle.Left = (pnlTitle.Width - lblSubTitle.Width) / 2;
            lblTitle.Top = 10;
            lblSubTitle.Top = lblTitle.Bottom + 4;
        }

        private void CenterNavButtons()
        {
            if (pnlNav == null) return;
            int gap = 10;
            Button[] navButtons = new[]
            {
                btnNavDashboard, btnNavStudents, btnNavCourses,
                btnNavDepartments, btnNavModules, btnNavLecturers
            };
            int totalWidth = -gap;
            foreach (Button b in navButtons)
            {
                if (b == null) continue;
                totalWidth += b.Width + gap;
            }
            int startX = Math.Max(10, (pnlNav.Width - totalWidth) / 2);
            int y = (pnlNav.Height - navButtons[0].Height) / 2;
            int x = startX;
            foreach (Button b in navButtons)
            {
                if (b == null) continue;
                b.Location = new Point(x, y);
                x += b.Width + gap;
            }
        }

        private void ApplyButtonHover(Button btn)
        {
            if (btn == null) return;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(btn.BackColor, 0.15f);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(btn.BackColor, 0.10f);
        }

        private void ApplyNavHover(Button btn)
        {
            if (btn == null) return;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(btn.BackColor, 0.12f);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(btn.BackColor, 0.12f);
        }

        private void SetActiveNav(Button btn)
        {
            if (btn == null) return;
            btn.BackColor = Color.FromArgb(31, 84, 147);
            activeNavButton = btn;
            pnlNav?.Invalidate();
        }

        private void NavBar_Paint(object sender, PaintEventArgs e)
        {
            if (activeNavButton == null) return;
            Rectangle r = activeNavButton.Bounds;
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush, r.Left, r.Bottom - 3, r.Width, 3);
            }
        }

        private void ApplyRoundedAll()
        {
            ApplyRounded(btnAdd, 10);
            ApplyRounded(btnUpdate, 10);
            ApplyRounded(btnDelete, 10);
            ApplyRounded(btnClear, 10);
            ApplyRounded(btnBack, 10);
        }

        private void ApplyRounded(Button btn, int radius)
        {
            if (btn == null) return;
            Rectangle bounds = new Rectangle(0, 0, btn.Width, btn.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                int r = radius * 2;
                path.AddArc(bounds.X, bounds.Y, r, r, 180, 90);
                path.AddArc(bounds.Right - r, bounds.Y, r, r, 270, 90);
                path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - r, r, r, 90, 90);
                path.CloseAllFigures();
                btn.Region = new Region(path);
            }
        }

        private void WireButtonLift(Button btn)
        {
            if (btn == null) return;
            if (!buttonPositions.ContainsKey(btn))
            {
                buttonPositions[btn] = btn.Location;
                shadowButtons.Add(btn);
            }
            btn.MouseEnter += (s, e) =>
            {
                Button b = (Button)s;
                b.Location = new Point(buttonPositions[b].X, buttonPositions[b].Y - 2);
                Invalidate();
            };
            btn.MouseLeave += (s, e) =>
            {
                Button b = (Button)s;
                b.Location = buttonPositions[b];
                Invalidate();
            };
        }

        private void ModulesForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (Button b in shadowButtons)
            {
                DrawShadow(e.Graphics, b);
            }
        }

        private void DrawShadow(Graphics g, Control c)
        {
            if (c == null) return;
            int shadowOffset = 3;
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(25, 0, 0, 0)))
            {
                Rectangle r = new Rectangle(c.Left + shadowOffset, c.Top + shadowOffset, c.Width, c.Height);
                g.FillRectangle(shadowBrush, r);
            }
        }

        private void ApplyNavOffset()
        {
            if (navOffsetApplied) return;
            int navHeight = pnlNav.Height + 10;
            foreach (Control control in Controls)
            {
                if (control == pnlTitle || control == pnlNav || control == pnlStatus) continue;
                control.Top += navHeight;
            }
            navOffsetApplied = true;
        }

        private void SetupGrid()
        {
            UiTheme.ApplyGridDefaults(dataGridView1);
            UiTheme.WireGridRowHover(dataGridView1);
        }

        private void LoadModules()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT ModuleID, ModuleName, CourseID, Credits FROM Module ORDER BY ModuleID", conn);
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                    dataGridView1.DataSource = currentTable;
                    statusLabel.Text = "✅ " + currentTable.Rows.Count + " modules loaded";
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "❌ Error: " + ex.Message;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtModuleID.Text = row.Cells["ModuleID"].Value.ToString();
                txtModuleName.Text = row.Cells["ModuleName"].Value.ToString();
                txtCourseID.Text = row.Cells["CourseID"].Value.ToString();
                txtCredits.Text = row.Cells["Credits"].Value.ToString();
                statusLabel.Text = "📋 Selected: " + txtModuleName.Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string moduleName = txtModuleName.Text.Trim();
            string courseId = txtCourseID.Text.Trim();
            string creditsText = txtCredits.Text.Trim();

            if (moduleName == "")
            {
                MessageBox.Show("Please fill in Module Name!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (courseId == "")
            {
                MessageBox.Show("Please enter Course ID!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(creditsText, out int credits) || credits < 0 || credits > 60)
            {
                MessageBox.Show("Please enter valid Credits (0 - 60).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Module (ModuleName, CourseID, Credits) VALUES (@ModuleName, @CourseID, @Credits)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ModuleName", moduleName);
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@Credits", credits);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Module added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadModules();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string moduleIdText = txtModuleID.Text.Trim();
            string moduleName = txtModuleName.Text.Trim();
            string courseId = txtCourseID.Text.Trim();
            string creditsText = txtCredits.Text.Trim();

            if (moduleIdText == "")
            {
                MessageBox.Show("Select a module first!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(moduleIdText, out int moduleId))
            {
                MessageBox.Show("Invalid Module ID selected.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (moduleName == "")
            {
                MessageBox.Show("Please fill in Module Name!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (courseId == "")
            {
                MessageBox.Show("Please enter Course ID!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(creditsText, out int credits) || credits < 0 || credits > 60)
            {
                MessageBox.Show("Please enter valid Credits (0 - 60).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Module SET ModuleName=@ModuleName, CourseID=@CourseID, Credits=@Credits WHERE ModuleID=@ModuleID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                    cmd.Parameters.AddWithValue("@ModuleName", moduleName);
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@Credits", credits);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Module updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadModules();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string moduleIdText = txtModuleID.Text.Trim();

            if (moduleIdText == "")
            {
                MessageBox.Show("Select a module first!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(moduleIdText, out int moduleId))
            {
                MessageBox.Show("Invalid Module ID selected.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Delete module: " + txtModuleName.Text + "?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Module WHERE ModuleID=@ModuleID", conn);
                        cmd.Parameters.AddWithValue("@ModuleID", moduleId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("🗑️ Module deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadModules();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e) { ClearFields(); }
        private void btnBack_Click(object sender, EventArgs e) { this.Close(); }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Close();
        }

        private void btnNavStudents_Click(object sender, EventArgs e)
        {
            new StudentsForm().Show();
            this.Close();
        }

        private void btnNavCourses_Click(object sender, EventArgs e)
        {
            new CoursesForm().Show();
            this.Close();
        }

        private void btnNavDepartments_Click(object sender, EventArgs e)
        {
            new DepartmentsForm().Show();
            this.Close();
        }

        private void btnNavModules_Click(object sender, EventArgs e)
        {
            // Already on Modules
        }

        private void btnNavLecturers_Click(object sender, EventArgs e)
        {
            new LecturersForm().Show();
            this.Close();
        }

        private void ApplyIconText()
        {
            if (lblTitle != null) lblTitle.Text = "📖  Modules Management";
            if (btnAdd != null) btnAdd.Text = "➕ Add";
            if (btnUpdate != null) btnUpdate.Text = "✏️ Update";
            if (btnDelete != null) btnDelete.Text = "🗑️ Delete";
            if (btnClear != null) btnClear.Text = "🧹 Clear";
            if (btnBack != null) btnBack.Text = "⬅️ Back to Dashboard";
        }

        private void PolishStatusBar()
        {
            UiTheme.ApplyStatusLabel(statusLabel);
        }

        private void ClearFields()
        {
            txtModuleID.Text = "";
            txtModuleName.Text = "";
            txtCourseID.Text = "";
            txtCredits.Text = "";
            statusLabel.Text = "🧹 Fields cleared";
        }

    }
}





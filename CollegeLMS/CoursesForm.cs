// ============================================================
// COPYRIGHT NOTICE
// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba
// Student No:  20232990
// Module:      KM-03: Database Manipulation and C#
// Institution: CTU Training Solutions
// Date:        12 February 2026
//
// ? 2026 Nicolette Mashaba. All rights reserved.
// Unauthorized copying or redistribution is strictly prohibited.
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
    public partial class CoursesForm : Form
    {
        DataTable currentTable = new DataTable();
        private bool navOffsetApplied = false;
        private readonly Dictionary<Button, Point> buttonPositions = new Dictionary<Button, Point>();
        private readonly List<Button> shadowButtons = new List<Button>();
        private Button activeNavButton;

        public CoursesForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Resize += CoursesForm_Resize;
            this.Paint += CoursesForm_Paint;
        }

        private void CoursesForm_Load(object sender, EventArgs e)
        {
            ApplyNavOffset();
            LoadCourses();
            SetupGrid();
            EnhanceUI();
        }

        private void CoursesForm_Resize(object sender, EventArgs e)
        {
            CenterHeader();
            CenterNavButtons();
            ApplyRoundedAll();
        }

        private void EnhanceUI()
        {
            ApplyIconText();
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
            SetActiveNav(btnNavCourses);

            CenterHeader();
            CenterNavButtons();
            ApplyRoundedAll();
            if (pnlNav != null) pnlNav.Paint += NavBar_Paint;
            PolishStatusBar();

            if (lblFooterText != null) 
                lblFooterText.Text = "© 2026 Nicolette Mashaba  •  Created with ❤️ by Nicolette Mashaba";
        }

        private void CenterHeader()
        {
            if (pnlTitle == null || lblTitle == null || lblSubTitle == null) return;
            lblTitle.Font = new Font("Arial", 24, FontStyle.Bold);
            lblSubTitle.Font = new Font("Arial", 10, FontStyle.Italic);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;
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

        private void CoursesForm_Paint(object sender, PaintEventArgs e)
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
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 84, 147);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 38;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.DefaultCellStyle.Padding = new Padding(6, 3, 6, 3);
            dataGridView1.RowTemplate.Height = 34;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 244, 255);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 84, 147);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(210, 230, 255);
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            };
            dataGridView1.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = e.RowIndex % 2 == 0
                        ? Color.White
                        : Color.FromArgb(235, 244, 255);
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            };
        }

        private void LoadCourses()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT CourseID, CourseName, DepartmentID, DurationYears FROM Course ORDER BY CourseID", conn);
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                    dataGridView1.DataSource = currentTable;
                    statusLabel.Text = "✅ " + currentTable.Rows.Count + " courses loaded";
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
                txtCourseID.Text = row.Cells["CourseID"].Value.ToString();
                txtCourseName.Text = row.Cells["CourseName"].Value.ToString();
                txtDepartmentID.Text = row.Cells["DepartmentID"].Value.ToString();
                txtDurationYears.Text = row.Cells["DurationYears"].Value.ToString();
                statusLabel.Text = "📋 Selected: " + txtCourseName.Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string courseId = txtCourseID.Text.Trim();
            string courseName = txtCourseName.Text.Trim();
            string departmentId = txtDepartmentID.Text.Trim();
            string durationText = txtDurationYears.Text.Trim();

            if (courseId == "" || courseName == "")
            {
                MessageBox.Show("Please fill in Course ID and Course Name!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (departmentId == "")
            {
                MessageBox.Show("Please enter Department ID!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(durationText, out int durationYears) || durationYears < 1 || durationYears > 10)
            {
                MessageBox.Show("Please enter a valid Duration Years (1 - 10).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Course (CourseID, CourseName, DepartmentID, DurationYears) VALUES (@CourseID, @CourseName, @DepartmentID, @DurationYears)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                    cmd.Parameters.AddWithValue("@DurationYears", durationYears);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Course added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "❌ Error: " + ex.Message;
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string courseId = txtCourseID.Text.Trim();
            string courseName = txtCourseName.Text.Trim();
            string departmentId = txtDepartmentID.Text.Trim();
            string durationText = txtDurationYears.Text.Trim();

            if (courseId == "")
            {
                MessageBox.Show("Select a course first!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (courseName == "")
            {
                MessageBox.Show("Please enter Course Name!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (departmentId == "")
            {
                MessageBox.Show("Please enter Department ID!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(durationText, out int durationYears) || durationYears < 1 || durationYears > 10)
            {
                MessageBox.Show("Please enter a valid Duration Years (1 - 10).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Course SET CourseName=@CourseName, DepartmentID=@DepartmentID, DurationYears=@DurationYears WHERE CourseID=@CourseID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                    cmd.Parameters.AddWithValue("@DurationYears", durationYears);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Course updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses();
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
            string courseId = txtCourseID.Text.Trim();
            if (courseId == "")
            {
                MessageBox.Show("Select a course first!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Delete course: " + txtCourseName.Text + "?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Course WHERE CourseID=@CourseID", conn);
                        cmd.Parameters.AddWithValue("@CourseID", courseId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("🗑️ Course deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCourses();
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
            // Already on Courses
        }

        private void btnNavDepartments_Click(object sender, EventArgs e)
        {
            new DepartmentsForm().Show();
            this.Close();
        }

        private void btnNavModules_Click(object sender, EventArgs e)
        {
            new ModulesForm().Show();
            this.Close();
        }

        private void btnNavLecturers_Click(object sender, EventArgs e)
        {
            new LecturersForm().Show();
            this.Close();
        }

        private void ApplyIconText()
        {
            if (lblTitle != null) lblTitle.Text = "📚  Courses Management";
            if (btnAdd != null) btnAdd.Text = "➕ Add";
            if (btnUpdate != null) btnUpdate.Text = "✏️ Update";
            if (btnDelete != null) btnDelete.Text = "🗑️ Delete";
            if (btnClear != null) btnClear.Text = "🧹 Clear";
            if (btnBack != null) btnBack.Text = "⬅️ Back to Dashboard";
        }

        private void PolishStatusBar()
        {
            if (statusLabel == null) return;
            statusLabel.AutoSize = false;
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusLabel.Padding = new Padding(8, 0, 0, 0);
        }

        private void ClearFields()
        {
            txtCourseID.Text = "";
            txtCourseName.Text = "";
            txtDepartmentID.Text = "";
            txtDurationYears.Text = "";
            statusLabel.Text = "🧹 Fields cleared";
        }

    }
}

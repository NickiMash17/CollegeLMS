// ============================================================
// COPYRIGHT NOTICE
// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba
// Student No:  20232990
// © 2026 Nicolette Mashaba. All rights reserved.
// ============================================================

using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CollegeLMS
{
    public partial class DepartmentsForm : Form
    {
        string connectionString =
            "Server=HACKER17\\SQLEXPRESS;Database=CTUCollegeDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

        DataTable currentTable = new DataTable();
        private bool navOffsetApplied = false;
        private readonly Dictionary<Button, Point> buttonPositions = new Dictionary<Button, Point>();
        private readonly List<Button> shadowButtons = new List<Button>();
        private Button activeNavButton;

        public DepartmentsForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Resize += DepartmentsForm_Resize;
            this.Paint += DepartmentsForm_Paint;
        }

        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
            ApplyNavOffset();
            LoadDepartments();
            SetupGrid();
            EnhanceUI();
        }

        private void DepartmentsForm_Resize(object sender, EventArgs e)
        {
            CenterHeader();
            CenterNavButtons();
            ApplyRoundedAll();
        }

        private void EnhanceUI()
        {
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
            SetActiveNav(btnNavDepartments);

            CenterHeader();
            CenterNavButtons();
            ApplyRoundedAll();
            if (pnlNav != null) pnlNav.Paint += NavBar_Paint;
        }

        private void CenterHeader()
        {
            if (pnlTitle == null || lblTitle == null || lblSubTitle == null) return;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Left = (pnlTitle.Width - lblTitle.Width) / 2;
            lblSubTitle.Left = (pnlTitle.Width - lblSubTitle.Width) / 2;
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
            btn.BackColor = Color.FromArgb(24, 72, 128);
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
            ApplyRounded(btnAdd, 8);
            ApplyRounded(btnUpdate, 8);
            ApplyRounded(btnDelete, 8);
            ApplyRounded(btnClear, 8);
            ApplyRounded(btnBack, 8);
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

        private void DepartmentsForm_Paint(object sender, PaintEventArgs e)
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
        }

        private void LoadDepartments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT DepartmentID, DepartmentName, Building FROM Department ORDER BY DepartmentID", conn);
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                    dataGridView1.DataSource = currentTable;
                    statusLabel.Text = "✅ " + currentTable.Rows.Count + " departments loaded";
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
                txtDepartmentID.Text = row.Cells["DepartmentID"].Value.ToString();
                txtDepartmentName.Text = row.Cells["DepartmentName"].Value.ToString();
                txtBuilding.Text = row.Cells["Building"].Value.ToString();
                statusLabel.Text = "📋 Selected: " + txtDepartmentName.Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDepartmentName.Text == "")
            {
                MessageBox.Show("Please fill in Department Name!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Department (DepartmentName, Building) VALUES (@DepartmentName, @Building)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Building", txtBuilding.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Department added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDepartments();
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
            if (txtDepartmentID.Text == "")
            {
                MessageBox.Show("Select a department first!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Department SET DepartmentName=@DepartmentName, Building=@Building WHERE DepartmentID=@DepartmentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DepartmentID", txtDepartmentID.Text);
                    cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Building", txtBuilding.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Department updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDepartments();
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
            if (txtDepartmentID.Text == "")
            {
                MessageBox.Show("Select a department first!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Delete department: " + txtDepartmentName.Text + "?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Department WHERE DepartmentID=@DepartmentID", conn);
                        cmd.Parameters.AddWithValue("@DepartmentID", txtDepartmentID.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("🗑️ Department deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDepartments();
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
            // Already on Departments
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

        private void ClearFields()
        {
            txtDepartmentID.Text = "";
            txtDepartmentName.Text = "";
            txtBuilding.Text = "";
            statusLabel.Text = "🧹 Fields cleared";
        }

    }
}

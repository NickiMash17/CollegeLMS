// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba  |  Student No: 20232990
// © 2026 Nicolette Mashaba. All rights reserved.
// ============================================================

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace CollegeLMS
{
    public partial class StudentsForm : Form
    {
        DataTable currentTable = new DataTable();
        private Button activeNavButton;

        public StudentsForm()
        {
            InitializeComponent();
            UiTheme.ApplyFormDefaults(this);
            UiTheme.InitializeLayout(this, pnlTitle, pnlNav, pnlStatus);
            DoubleBuffered = true;
            UiTheme.WireCommonShortcuts(this,
                findSearchBox: () => txtSearch,
                triggerSearch: () => btnView_Click(this, EventArgs.Empty));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents();
            SetupDataGridView();
            UpdateStudentCount();
            EnhanceUI();
        }

        private void EnhanceUI()
        {
            // Panel painters
            if (pnlTitle  != null) pnlTitle.Paint  += (s, e) => UiTheme.PaintHeaderPanel(pnlTitle, e);
            if (pnlNav    != null) pnlNav.Paint    += (s, e) => UiTheme.PaintNavPanel(pnlNav, e, activeNavButton);
            if (pnlLeft   != null) pnlLeft.Paint   += (s, e) => UiTheme.PaintLeftPanel(pnlLeft, e);
            if (pnlStatus != null) pnlStatus.Paint += (s, e) => UiTheme.PaintFooterPanel(pnlStatus, e);
            if (pnlFooter != null) pnlFooter.Paint += (s, e) => UiTheme.PaintFooterPanel(pnlFooter, e);

            // Nav
            UiTheme.ApplyNavStyle(btnNavDashboard, btnNavStudents, btnNavCourses,
                                  btnNavDepartments, btnNavModules, btnNavLecturers);
            SetActiveNav(btnNavStudents);

            // ── Buttons — ORIGINAL vivid colours ──────────────────────────────
            UiTheme.ApplyPrimaryButton(btnView);    // Blue
            UiTheme.ApplyPrimaryButton(btnSearch);  // Blue
            UiTheme.ApplySuccessButton(btnAdd);     // Green
            UiTheme.ApplyCyanButton(btnUpdate);     // Teal
            UiTheme.ApplyDangerButton(btnDelete);   // Red
            UiTheme.ApplyNeutralButton(btnClear);   // Slate
            UiTheme.ApplyAmberButton(btnExport);    // Orange  (was Teal; keeping vivid)
            UiTheme.ApplyPurpleButton(btnPrint);    // Dark slate purple

            // Button labels
            if (lblTitle  != null) lblTitle.Text  = "Student Management";
            if (btnView   != null) btnView.Text   = "View";
            if (btnAdd    != null) btnAdd.Text    = "Add";
            if (btnUpdate != null) btnUpdate.Text = "Update";
            if (btnDelete != null) btnDelete.Text = "Delete";
            if (btnClear  != null) btnClear.Text  = "Clear";
            if (btnExport != null) btnExport.Text = "Export";
            if (btnPrint  != null) btnPrint.Text  = "Print";
            if (btnSearch != null) btnSearch.Text = "Search";
            if (lblSearch != null) lblSearch.Text = "Search:";
            if (lblCount  != null) lblCount.Text  = "Total Students: 0";

            // Inputs
            UiTheme.ApplyModernInput(txtStudentID);
            UiTheme.ApplyModernInput(txtFirstName);
            UiTheme.ApplyModernInput(txtLastName);
            UiTheme.ApplyModernInput(txtAge);
            UiTheme.ApplyModernInput(txtCourseID);
            UiTheme.ApplyModernInput(txtSearch);

            // Badge
            UiTheme.ApplyBadgeStyle(lblCount);

            // Header
            UiTheme.ApplyHeader(pnlTitle, lblTitle, lblSubTitle);
            UiTheme.ApplyStatusLabel(statusLabel);

            // Footer
            if (lblFooterText != null)
                lblFooterText.Text = "\u00A9 2026 Nicolette Mashaba  \u2022  CTU Training Solutions";
        }

        private void SetActiveNav(Button btn)
        {
            activeNavButton = btn;
            if (btn != null)
            {
                btn.ForeColor = Color.White;
                btn.Font      = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            }
            pnlNav?.Invalidate();
        }

        private void SetupDataGridView()
        {
            UiTheme.ApplyGridDefaults(dataGridView1);
            UiTheme.WireGridRowHover(dataGridView1);
        }

        private void SetStatus(string message)
        {
            if (statusLabel != null) statusLabel.Text = message;
        }

        private void LoadStudents()
        {
            try
            {
                using (var conn = new SqlConnection(AppSettings.ConnectionString))
                {
                    conn.Open();
                    var adapter  = new SqlDataAdapter(
                        "SELECT StudentID, FirstName, LastName, Age, CourseID FROM Student ORDER BY StudentID", conn);
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                    dataGridView1.DataSource = currentTable;
                    UpdateStudentCount();
                    SetStatus(currentTable.Rows.Count + " students loaded successfully");
                }
            }
            catch (Exception ex)
            {
                SetStatus("Connection error: " + ex.Message);
                MessageBox.Show("Database connection failed!\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStudentCount()
        {
            if (lblCount != null) lblCount.Text = "Total Students: " + currentTable.Rows.Count;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text  = row.Cells["LastName"].Value.ToString();
                txtAge.Text       = row.Cells["Age"].Value.ToString();
                txtCourseID.Text  = row.Cells["CourseID"].Value.ToString();
                SetStatus("Selected: " + txtFirstName.Text + " " + txtLastName.Text
                          + "  |  Course: " + txtCourseID.Text + "  |  Age: " + txtAge.Text);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string s = txtSearch.Text.Trim();
            if (s == "") { LoadStudents(); return; }
            try
            {
                using (var conn = new SqlConnection(AppSettings.ConnectionString))
                {
                    conn.Open();
                    var adapter = new SqlDataAdapter(
                        @"SELECT StudentID, FirstName, LastName, Age, CourseID FROM Student
                          WHERE FirstName LIKE @s OR LastName LIKE @s
                             OR CourseID LIKE @s OR CAST(StudentID AS VARCHAR) LIKE @s
                          ORDER BY StudentID", conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@s", "%" + s + "%");
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                    dataGridView1.DataSource = currentTable;
                    UpdateStudentCount();
                    SetStatus("Found " + currentTable.Rows.Count + " result(s) for: \"" + s + "\"");
                }
            }
            catch (Exception ex) { SetStatus("Search error: " + ex.Message); }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadStudents();
            txtSearch.Text = "";
            SetStatus("Table refreshed");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim() == "" || txtLastName.Text.Trim() == "")
            { MessageBox.Show("Please fill in First Name and Last Name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (txtCourseID.Text.Trim() == "")
            { MessageBox.Show("Please enter Course ID!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(txtAge.Text.Trim(), out int age) || age < 1 || age > 120)
            { MessageBox.Show("Please enter a valid Age (1-120).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                using (var conn = new SqlConnection(AppSettings.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "INSERT INTO Student (FirstName, LastName, Age, CourseID) VALUES (@F,@L,@A,@C)", conn);
                    cmd.Parameters.AddWithValue("@F", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@L", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@A", age);
                    cmd.Parameters.AddWithValue("@C", txtCourseID.Text.Trim());
                    cmd.ExecuteNonQuery();
                    SetStatus("Added: " + txtFirstName.Text + " " + txtLastName.Text);
                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents(); ClearFields();
                }
            }
            catch (Exception ex) { SetStatus("Error: " + ex.Message); MessageBox.Show("Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStudentID.Text.Trim(), out int id))
            { MessageBox.Show("Please select a student from the table first!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (txtFirstName.Text.Trim() == "" || txtLastName.Text.Trim() == "" || txtCourseID.Text.Trim() == "")
            { MessageBox.Show("Please fill in all fields!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(txtAge.Text.Trim(), out int age) || age < 1 || age > 120)
            { MessageBox.Show("Please enter a valid Age (1-120).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (MessageBox.Show("Update " + txtFirstName.Text + " " + txtLastName.Text + "?",
                "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new SqlConnection(AppSettings.ConnectionString))
                    {
                        conn.Open();
                        var cmd = new SqlCommand(
                            "UPDATE Student SET FirstName=@F,LastName=@L,Age=@A,CourseID=@C WHERE StudentID=@ID", conn);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@F",  txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@L",  txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@A",  age);
                        cmd.Parameters.AddWithValue("@C",  txtCourseID.Text.Trim());
                        cmd.ExecuteNonQuery();
                        SetStatus("Updated: " + txtFirstName.Text + " " + txtLastName.Text);
                        MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents(); ClearFields();
                    }
                }
                catch (Exception ex) { SetStatus("Error: " + ex.Message); MessageBox.Show("Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStudentID.Text.Trim(), out int id))
            { MessageBox.Show("Please select a student from the table first!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (MessageBox.Show("DELETE " + txtFirstName.Text + " " + txtLastName.Text + "?\n\nThis cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new SqlConnection(AppSettings.ConnectionString))
                    {
                        conn.Open();
                        var cmd = new SqlCommand("DELETE FROM Student WHERE StudentID=@ID", conn);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                        SetStatus("Deleted: " + txtFirstName.Text + " " + txtLastName.Text);
                        MessageBox.Show("Student deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents(); ClearFields();
                    }
                }
                catch (Exception ex) { SetStatus("Error: " + ex.Message); MessageBox.Show("Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private static string EscapeCsv(object v)
        {
            string t = v?.ToString() ?? "";
            if (t.Contains("\"")) t = t.Replace("\"", "\"\"");
            if (t.IndexOfAny(new[] { ',', '"', '\r', '\n' }) >= 0) t = "\"" + t + "\"";
            return t;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (currentTable == null || currentTable.Rows.Count == 0)
            { MessageBox.Show("No students to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var dlg = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = "Students_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (var sw = new StreamWriter(dlg.FileName))
                {
                    sw.WriteLine("StudentID,FirstName,LastName,Age,CourseID");
                    foreach (DataRow row in currentTable.Rows)
                        sw.WriteLine(EscapeCsv(row["StudentID"]) + "," + EscapeCsv(row["FirstName"]) + "," +
                                     EscapeCsv(row["LastName"]) + "," + EscapeCsv(row["Age"]) + "," + EscapeCsv(row["CourseID"]));
                }
                SetStatus("Exported to: " + dlg.FileName);
                MessageBox.Show("Exported successfully!\n" + dlg.FileName, "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (currentTable == null || currentTable.Rows.Count == 0)
            { MessageBox.Show("No students to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int printRow = 0;
            var pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                var g = ev.Graphics;
                var titleF  = new Font("Segoe UI Semibold", 16, FontStyle.Bold);
                var hdrF    = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
                var dataF   = new Font("Segoe UI", 9);
                int[] cw    = { 80, 120, 120, 50, 80 };
                string[] hd = { "StudentID", "FirstName", "LastName", "Age", "CourseID" };
                int y = 50;

                g.DrawString("CTU College — Student List", titleF, new SolidBrush(UiTheme.NavyDeep), 50, y); y += 30;
                g.DrawString("Printed: " + DateTime.Now.ToString("dd MMM yyyy HH:mm"), dataF, new SolidBrush(UiTheme.TextMuted), 50, y); y += 30;
                using (var pen = new Pen(UiTheme.SteelBlue)) g.DrawLine(pen, 50, y, 700, y); y += 10;

                int x = 50;
                for (int i = 0; i < hd.Length; i++)
                {
                    g.FillRectangle(new SolidBrush(UiTheme.GridHeaderBg), x, y, cw[i], 28);
                    g.DrawString(hd[i], hdrF, Brushes.White, x + 4, y + 5);
                    x += cw[i];
                }
                y += 34;

                bool alt = (printRow % 2) == 1;
                while (printRow < currentTable.Rows.Count && y <= ev.MarginBounds.Bottom - 40)
                {
                    var row = currentTable.Rows[printRow];
                    x = 50;
                    if (alt) g.FillRectangle(new SolidBrush(UiTheme.GridRowOdd), 50, y, 530, 24);
                    g.DrawString(row["StudentID"].ToString(), dataF, new SolidBrush(UiTheme.TextPrimary), x + 4, y + 4); x += cw[0];
                    g.DrawString(row["FirstName"].ToString(), dataF, new SolidBrush(UiTheme.TextPrimary), x + 4, y + 4); x += cw[1];
                    g.DrawString(row["LastName"].ToString(),  dataF, new SolidBrush(UiTheme.TextPrimary), x + 4, y + 4); x += cw[2];
                    g.DrawString(row["Age"].ToString(),       dataF, new SolidBrush(UiTheme.TextPrimary), x + 4, y + 4); x += cw[3];
                    g.DrawString(row["CourseID"].ToString(),  dataF, new SolidBrush(UiTheme.TextPrimary), x + 4, y + 4);
                    y += 24; alt = !alt; printRow++;
                }
                using (var pen = new Pen(UiTheme.SteelBlue)) g.DrawLine(pen, 50, y + 5, 700, y + 5);
                g.DrawString("Total: " + currentTable.Rows.Count, hdrF, new SolidBrush(UiTheme.NavyMid), 50, y + 10);
                ev.HasMorePages = printRow < currentTable.Rows.Count;
                if (!ev.HasMorePages) printRow = 0;
                titleF.Dispose(); hdrF.Dispose(); dataF.Dispose();
            };

            new PrintPreviewDialog { Document = pd, Width = 900, Height = 700 }.ShowDialog();
            SetStatus("Print preview opened");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtSearch.Text = "";
            SetStatus("Fields cleared");
        }

        private void ClearFields()
        {
            txtStudentID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text  = "";
            txtAge.Text       = "";
            txtCourseID.Text  = "";
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)   { new Dashboard().Show(); Close(); }
        private void btnNavStudents_Click(object sender, EventArgs e)    { /* already here */ }
        private void btnNavCourses_Click(object sender, EventArgs e)     { new CoursesForm().Show();     Close(); }
        private void btnNavDepartments_Click(object sender, EventArgs e) { new DepartmentsForm().Show(); Close(); }
        private void btnNavModules_Click(object sender, EventArgs e)     { new ModulesForm().Show();     Close(); }
        private void btnNavLecturers_Click(object sender, EventArgs e)   { new LecturersForm().Show();   Close(); }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace CollegeLMS
{
    public partial class Form1 : Form
    {
        string connectionString =
            "Server=HACKER17\\SQLEXPRESS;Database=CTUCollegeDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

        DataTable currentTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents();
            SetupDataGridView();
            UpdateStudentCount();
            statusLabel.Text = "✅ Connected to CTUCollegeDB";
        }

        // =====================
        // SETUP DATAGRIDVIEW
        // =====================
        private void SetupDataGridView()
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            // Header style
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 84, 147);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dataGridView1.ColumnHeadersHeight = 35;

            // Row style
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.DefaultCellStyle.Padding = new Padding(3);
            dataGridView1.RowTemplate.Height = 30;

            // Alternating rows
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 244, 255);

            // Selection style
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 84, 147);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid appearance
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.GridColor = Color.LightSteelBlue;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.BackgroundColor = Color.White;

            // Hover effect
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

        // =====================
        // LOAD STUDENTS
        // =====================
        private void LoadStudents()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT StudentID, FirstName, LastName, Age, CourseID FROM Student ORDER BY StudentID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                    dataGridView1.DataSource = currentTable;
                    UpdateStudentCount();
                    statusLabel.Text = "✅ " + currentTable.Rows.Count + " students loaded successfully";
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "❌ Connection Error: " + ex.Message;
                MessageBox.Show("Database connection failed!\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================
        // UPDATE STUDENT COUNT
        // =====================
        private void UpdateStudentCount()
        {
            lblCount.Text = "👥 Total Students: " + currentTable.Rows.Count;
        }

        // =====================
        // CELL CLICK
        // =====================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                txtCourseID.Text = row.Cells["CourseID"].Value.ToString();
                statusLabel.Text = "📋 Selected: " + txtFirstName.Text + " " + txtLastName.Text
                                  + "  |  Course: " + txtCourseID.Text
                                  + "  |  Age: " + txtAge.Text;
            }
        }

        // =====================
        // SEARCH
        // =====================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (searchText == "")
            {
                LoadStudents();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT StudentID, FirstName, LastName, Age, CourseID
                                     FROM Student
                                     WHERE FirstName LIKE @s OR LastName LIKE @s
                                        OR CourseID LIKE @s OR CAST(StudentID AS VARCHAR) LIKE @s
                                     ORDER BY StudentID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@s", "%" + searchText + "%");
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                    dataGridView1.DataSource = currentTable;
                    UpdateStudentCount();
                    statusLabel.Text = "🔍 Found " + currentTable.Rows.Count + " result(s) for: \"" + searchText + "\"";
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "❌ Search Error: " + ex.Message;
            }
        }

        // =====================
        // VIEW
        // =====================
        private void btnView_Click(object sender, EventArgs e)
        {
            LoadStudents();
            txtSearch.Text = "";
            statusLabel.Text = "🔄 Table refreshed";
        }

        // =====================
        // ADD
        // =====================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "")
            {
                MessageBox.Show("Please fill in First Name and Last Name!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Student (FirstName, LastName, Age, CourseID) VALUES (@FirstName, @LastName, @Age, @CourseID)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                    cmd.Parameters.AddWithValue("@CourseID", txtCourseID.Text.Trim());
                    cmd.ExecuteNonQuery();
                    statusLabel.Text = "✅ Added: " + txtFirstName.Text + " " + txtLastName.Text;
                    MessageBox.Show("✅ Student added successfully!\n\n" +
                        "Name: " + txtFirstName.Text + " " + txtLastName.Text + "\n" +
                        "Course: " + txtCourseID.Text,
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "❌ Error: " + ex.Message;
                MessageBox.Show("Error adding student:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================
        // UPDATE
        // =====================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "")
            {
                MessageBox.Show("Please select a student from the table first!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to update:\n\n" +
                "Student: " + txtFirstName.Text + " " + txtLastName.Text + "\n" +
                "ID: " + txtStudentID.Text,
                "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE Student SET FirstName=@FirstName, LastName=@LastName, Age=@Age, CourseID=@CourseID WHERE StudentID=@StudentID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                        cmd.Parameters.AddWithValue("@CourseID", txtCourseID.Text.Trim());
                        cmd.ExecuteNonQuery();
                        statusLabel.Text = "✅ Updated: " + txtFirstName.Text + " " + txtLastName.Text;
                        MessageBox.Show("✅ Student updated successfully!\n\n" +
                            "Name: " + txtFirstName.Text + " " + txtLastName.Text,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    statusLabel.Text = "❌ Error: " + ex.Message;
                    MessageBox.Show("Error updating student:\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =====================
        // DELETE
        // =====================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "")
            {
                MessageBox.Show("Please select a student from the table first!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "⚠️ Are you sure you want to DELETE:\n\n" +
                "Name: " + txtFirstName.Text + " " + txtLastName.Text + "\n" +
                "ID: " + txtStudentID.Text + "\n" +
                "Course: " + txtCourseID.Text + "\n\n" +
                "This action cannot be undone!",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE StudentID=@StudentID", conn);
                        cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                        cmd.ExecuteNonQuery();
                        statusLabel.Text = "🗑️ Deleted: " + txtFirstName.Text + " " + txtLastName.Text;
                        MessageBox.Show("🗑️ Student deleted successfully!", "Deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudents();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    statusLabel.Text = "❌ Error: " + ex.Message;
                    MessageBox.Show("Error deleting student:\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =====================
        // EXPORT TO CSV
        // =====================
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveDialog.FileName = "Students_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                saveDialog.Title = "Export Students to CSV";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveDialog.FileName))
                    {
                        // Write headers
                        sw.WriteLine("StudentID,FirstName,LastName,Age,CourseID");

                        // Write rows
                        foreach (DataRow row in currentTable.Rows)
                        {
                            sw.WriteLine(row["StudentID"] + "," +
                                        row["FirstName"] + "," +
                                        row["LastName"] + "," +
                                        row["Age"] + "," +
                                        row["CourseID"]);
                        }
                    }
                    statusLabel.Text = "📁 Exported to: " + saveDialog.FileName;
                    MessageBox.Show("✅ Students exported successfully!\n\nSaved to:\n" + saveDialog.FileName,
                        "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================
        // PRINT
        // =====================
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (s, ev) =>
                {
                    Graphics g = ev.Graphics;
                    Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                    Font headerFont = new Font("Arial", 10, FontStyle.Bold);
                    Font dataFont = new Font("Arial", 9);

                    int y = 50;
                    int[] colWidths = { 80, 120, 120, 50, 80 };
                    string[] headers = { "StudentID", "FirstName", "LastName", "Age", "CourseID" };

                    // Title
                    g.DrawString("CTU College — Student List", titleFont, Brushes.DarkBlue, 50, y);
                    y += 30;
                    g.DrawString("Printed: " + DateTime.Now.ToString("dd MMM yyyy HH:mm"), dataFont, Brushes.Gray, 50, y);
                    y += 30;
                    g.DrawLine(Pens.SteelBlue, 50, y, 700, y);
                    y += 10;

                    // Headers
                    int x = 50;
                    foreach (string h in headers)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(31, 84, 147)), x, y, colWidths[Array.IndexOf(headers, h)], 25);
                        g.DrawString(h, headerFont, Brushes.White, x + 3, y + 4);
                        x += colWidths[Array.IndexOf(headers, h)];
                    }
                    y += 30;

                    // Rows
                    bool alternate = false;
                    foreach (DataRow row in currentTable.Rows)
                    {
                        x = 50;
                        if (alternate)
                            g.FillRectangle(new SolidBrush(Color.FromArgb(235, 244, 255)), 50, y, 530, 22);

                        g.DrawString(row["StudentID"].ToString(), dataFont, Brushes.Black, x + 3, y + 3); x += colWidths[0];
                        g.DrawString(row["FirstName"].ToString(), dataFont, Brushes.Black, x + 3, y + 3); x += colWidths[1];
                        g.DrawString(row["LastName"].ToString(), dataFont, Brushes.Black, x + 3, y + 3); x += colWidths[2];
                        g.DrawString(row["Age"].ToString(), dataFont, Brushes.Black, x + 3, y + 3); x += colWidths[3];
                        g.DrawString(row["CourseID"].ToString(), dataFont, Brushes.Black, x + 3, y + 3);

                        y += 22;
                        alternate = !alternate;

                        if (y > ev.PageBounds.Height - 100) break;
                    }

                    // Footer
                    g.DrawLine(Pens.SteelBlue, 50, y + 5, 700, y + 5);
                    g.DrawString("Total Students: " + currentTable.Rows.Count, headerFont, Brushes.DarkBlue, 50, y + 10);
                };

                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = pd;
                preview.Width = 900;
                preview.Height = 700;
                preview.ShowDialog();
                statusLabel.Text = "🖨️ Print preview opened";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print failed:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================
        // CLEAR
        // =====================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtSearch.Text = "";
            statusLabel.Text = "🧹 Fields cleared";
        }

        private void ClearFields()
        {
            txtStudentID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAge.Text = "";
            txtCourseID.Text = "";
        }
    }
}
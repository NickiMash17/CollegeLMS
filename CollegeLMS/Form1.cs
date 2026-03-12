using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CollegeLMS
{
    public partial class Form1 : Form
    {
        string connectionString =
            "Server=HACKER17\\SQLEXPRESS;Database=CTUCollegeDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT StudentID, FirstName, LastName, Age, CourseID FROM Student";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

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
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "")
            {
                MessageBox.Show("Please fill in First Name and Last Name!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Student (FirstName, LastName, Age, CourseID) VALUES (@FirstName, @LastName, @Age, @CourseID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@CourseID", txtCourseID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student added successfully!");
                LoadStudents();
                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "")
            {
                MessageBox.Show("Select a student first!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Student SET FirstName=@FirstName, LastName=@LastName, Age=@Age, CourseID=@CourseID WHERE StudentID=@StudentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@CourseID", txtCourseID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student updated successfully!");
                LoadStudents();
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "")
            {
                MessageBox.Show("Select a student first!");
                return;
            }

            if (MessageBox.Show("Delete this student?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE StudentID=@StudentID", conn);
                    cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student deleted!");
                    LoadStudents();
                    ClearFields();
                }
            }
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
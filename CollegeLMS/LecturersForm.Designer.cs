namespace CollegeLMS
{
    partial class LecturersForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtLecturerID = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavStudents = new System.Windows.Forms.Button();
            this.btnNavCourses = new System.Windows.Forms.Button();
            this.btnNavDepartments = new System.Windows.Forms.Button();
            this.btnNavModules = new System.Windows.Forms.Button();
            this.btnNavLecturers = new System.Windows.Forms.Button();
            this.lblLecturerID = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();

            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Size = new System.Drawing.Size(1100, 80);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.lblSubTitle);
            this.pnlTitle.Paint += (s, e) => {
                var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    this.pnlTitle.ClientRectangle,
                    System.Drawing.Color.FromArgb(13, 51, 86),
                    System.Drawing.Color.FromArgb(62, 174, 223),
                    System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(brush, this.pnlTitle.ClientRectangle);
            };

            this.lblTitle.Text = "?????  Lecturers Management";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 22, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(330, 10);
            this.lblTitle.Size = new System.Drawing.Size(440, 38);

            this.lblSubTitle.Text = "CTUCollegeDB : Lecturer Table";
            this.lblSubTitle.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Italic);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(95, 151, 184);
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Location = new System.Drawing.Point(390, 54);
            this.lblSubTitle.Size = new System.Drawing.Size(300, 18);

            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(13, 51, 86);
            this.pnlNav.Location = new System.Drawing.Point(0, 80);
            this.pnlNav.Size = new System.Drawing.Size(1100, 36);
            this.pnlNav.Name = "pnlNav";

            this.btnNavDashboard.Location = new System.Drawing.Point(10, 4);
            this.btnNavDashboard.Size = new System.Drawing.Size(95, 28);
            this.btnNavDashboard.Text = "Dashboard";
            this.btnNavDashboard.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);

            this.btnNavStudents.Location = new System.Drawing.Point(110, 4);
            this.btnNavStudents.Size = new System.Drawing.Size(90, 28);
            this.btnNavStudents.Text = "Students";
            this.btnNavStudents.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavStudents.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.btnNavStudents.ForeColor = System.Drawing.Color.White;
            this.btnNavStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStudents.FlatAppearance.BorderSize = 0;
            this.btnNavStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavStudents.Click += new System.EventHandler(this.btnNavStudents_Click);

            this.btnNavCourses.Location = new System.Drawing.Point(205, 4);
            this.btnNavCourses.Size = new System.Drawing.Size(85, 28);
            this.btnNavCourses.Text = "Courses";
            this.btnNavCourses.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavCourses.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.btnNavCourses.ForeColor = System.Drawing.Color.White;
            this.btnNavCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCourses.FlatAppearance.BorderSize = 0;
            this.btnNavCourses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCourses.Click += new System.EventHandler(this.btnNavCourses_Click);

            this.btnNavDepartments.Location = new System.Drawing.Point(295, 4);
            this.btnNavDepartments.Size = new System.Drawing.Size(105, 28);
            this.btnNavDepartments.Text = "Departments";
            this.btnNavDepartments.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavDepartments.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.btnNavDepartments.ForeColor = System.Drawing.Color.White;
            this.btnNavDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDepartments.FlatAppearance.BorderSize = 0;
            this.btnNavDepartments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDepartments.Click += new System.EventHandler(this.btnNavDepartments_Click);

            this.btnNavModules.Location = new System.Drawing.Point(405, 4);
            this.btnNavModules.Size = new System.Drawing.Size(85, 28);
            this.btnNavModules.Text = "Modules";
            this.btnNavModules.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavModules.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.btnNavModules.ForeColor = System.Drawing.Color.White;
            this.btnNavModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavModules.FlatAppearance.BorderSize = 0;
            this.btnNavModules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavModules.Click += new System.EventHandler(this.btnNavModules_Click);

            this.btnNavLecturers.Location = new System.Drawing.Point(495, 4);
            this.btnNavLecturers.Size = new System.Drawing.Size(90, 28);
            this.btnNavLecturers.Text = "Lecturers";
            this.btnNavLecturers.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavLecturers.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.btnNavLecturers.ForeColor = System.Drawing.Color.White;
            this.btnNavLecturers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLecturers.FlatAppearance.BorderSize = 0;
            this.btnNavLecturers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavLecturers.Click += new System.EventHandler(this.btnNavLecturers_Click);

            this.pnlNav.Controls.Add(this.btnNavDashboard);
            this.pnlNav.Controls.Add(this.btnNavStudents);
            this.pnlNav.Controls.Add(this.btnNavCourses);
            this.pnlNav.Controls.Add(this.btnNavDepartments);
            this.pnlNav.Controls.Add(this.btnNavModules);
            this.pnlNav.Controls.Add(this.btnNavLecturers);

            this.lblLecturerID.Text = "Lecturer ID";
            this.lblLecturerID.Location = new System.Drawing.Point(30, 105);
            this.lblLecturerID.Size = new System.Drawing.Size(120, 22);
            this.lblLecturerID.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblLecturerID.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);

            this.lblFirstName.Text = "First Name";
            this.lblFirstName.Location = new System.Drawing.Point(30, 150);
            this.lblFirstName.Size = new System.Drawing.Size(120, 22);
            this.lblFirstName.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);

            this.lblLastName.Text = "Last Name";
            this.lblLastName.Location = new System.Drawing.Point(30, 195);
            this.lblLastName.Size = new System.Drawing.Size(120, 22);
            this.lblLastName.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);

            this.lblSalary.Text = "Salary";
            this.lblSalary.Location = new System.Drawing.Point(30, 240);
            this.lblSalary.Size = new System.Drawing.Size(120, 22);
            this.lblSalary.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblSalary.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);

            this.lblDepartmentName.Text = "Department";
            this.lblDepartmentName.Location = new System.Drawing.Point(30, 285);
            this.lblDepartmentName.Size = new System.Drawing.Size(120, 22);
            this.lblDepartmentName.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblDepartmentName.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);

            this.txtLecturerID.Location = new System.Drawing.Point(170, 103);
            this.txtLecturerID.Size = new System.Drawing.Size(250, 26);
            this.txtLecturerID.Font = new System.Drawing.Font("Arial", 10);
            this.txtLecturerID.BackColor = System.Drawing.Color.AliceBlue;
            this.txtLecturerID.ReadOnly = true;

            this.txtFirstName.Location = new System.Drawing.Point(170, 148);
            this.txtFirstName.Size = new System.Drawing.Size(250, 26);
            this.txtFirstName.Font = new System.Drawing.Font("Arial", 10);
            this.txtFirstName.BackColor = System.Drawing.Color.AliceBlue;

            this.txtLastName.Location = new System.Drawing.Point(170, 193);
            this.txtLastName.Size = new System.Drawing.Size(250, 26);
            this.txtLastName.Font = new System.Drawing.Font("Arial", 10);
            this.txtLastName.BackColor = System.Drawing.Color.AliceBlue;

            this.txtSalary.Location = new System.Drawing.Point(170, 238);
            this.txtSalary.Size = new System.Drawing.Size(250, 26);
            this.txtSalary.Font = new System.Drawing.Font("Arial", 10);
            this.txtSalary.BackColor = System.Drawing.Color.AliceBlue;

            this.txtDepartmentName.Location = new System.Drawing.Point(170, 283);
            this.txtDepartmentName.Size = new System.Drawing.Size(250, 26);
            this.txtDepartmentName.Font = new System.Drawing.Font("Arial", 10);
            this.txtDepartmentName.BackColor = System.Drawing.Color.AliceBlue;

            this.btnAdd.Location = new System.Drawing.Point(30, 335);
            this.btnAdd.Size = new System.Drawing.Size(90, 38);
            this.btnAdd.Text = "? Add";
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(130, 335);
            this.btnUpdate.Size = new System.Drawing.Size(90, 38);
            this.btnUpdate.Text = "?? Update";
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(230, 335);
            this.btnDelete.Size = new System.Drawing.Size(90, 38);
            this.btnDelete.Text = "??? Delete";
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Location = new System.Drawing.Point(330, 335);
            this.btnClear.Size = new System.Drawing.Size(90, 38);
            this.btnClear.Text = "?? Clear";
            this.btnClear.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnClear.BackColor = System.Drawing.Color.SlateGray;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.btnBack.Location = new System.Drawing.Point(30, 390);
            this.btnBack.Size = new System.Drawing.Size(150, 38);
            this.btnBack.Text = "?? Back to Dashboard";
            this.btnBack.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            this.dataGridView1.Location = new System.Drawing.Point(460, 90);
            this.dataGridView1.Size = new System.Drawing.Size(600, 390);
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.pnlStatus.Location = new System.Drawing.Point(0, 523);
            this.pnlStatus.Size = new System.Drawing.Size(1100, 30);
            this.pnlStatus.Controls.Add(this.statusLabel);

            this.statusLabel.Text = "Ready";
            this.statusLabel.Font = new System.Drawing.Font("Arial", 9);
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(10, 7);
            this.statusLabel.Size = new System.Drawing.Size(800, 18);

            this.ClientSize = new System.Drawing.Size(1100, 553);
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.Text = "Lecturers Management";
            this.Load += new System.EventHandler(this.LecturersForm_Load);

            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.lblLecturerID);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.lblDepartmentName);
            this.Controls.Add(this.txtLecturerID);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.txtDepartmentName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlStatus);

            this.pnlTitle.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtLecturerID;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavStudents;
        private System.Windows.Forms.Button btnNavCourses;
        private System.Windows.Forms.Button btnNavDepartments;
        private System.Windows.Forms.Button btnNavModules;
        private System.Windows.Forms.Button btnNavLecturers;
        private System.Windows.Forms.Label lblLecturerID;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Label statusLabel;
    }
}





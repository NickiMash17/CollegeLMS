namespace CollegeLMS
{
    partial class CoursesForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCourseID = new System.Windows.Forms.TextBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.txtDurationYears = new System.Windows.Forms.TextBox();
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
            this.lblCourseID = new System.Windows.Forms.Label();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.lblDepartmentID = new System.Windows.Forms.Label();
            this.lblDurationYears = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();

            // Title Panel
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Size = new System.Drawing.Size(1100, 80);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.lblSubTitle);
            this.pnlTitle.Paint += (s, e) => {
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    this.pnlTitle.ClientRectangle,
                    System.Drawing.Color.FromArgb(20, 63, 120),
                    System.Drawing.Color.FromArgb(52, 120, 200),
                    System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, this.pnlTitle.ClientRectangle);
                }
            };

            this.lblTitle.Text = "📚  Courses Management";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 22, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(350, 10);
            this.lblTitle.Size = new System.Drawing.Size(400, 38);

            this.lblSubTitle.Text = "CTUCollegeDB : Course Table";
            this.lblSubTitle.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Italic);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(140, 204, 235);
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Location = new System.Drawing.Point(390, 54);
            this.lblSubTitle.Size = new System.Drawing.Size(320, 18);

            // Nav Bar
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(20, 63, 120);
            this.pnlNav.Location = new System.Drawing.Point(0, 80);
            this.pnlNav.Size = new System.Drawing.Size(1100, 36);
            this.pnlNav.Name = "pnlNav";

            this.btnNavDashboard.Location = new System.Drawing.Point(10, 4);
            this.btnNavDashboard.Size = new System.Drawing.Size(95, 28);
            this.btnNavDashboard.Text = "Dashboard";
            this.btnNavDashboard.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);

            this.btnNavStudents.Location = new System.Drawing.Point(110, 4);
            this.btnNavStudents.Size = new System.Drawing.Size(90, 28);
            this.btnNavStudents.Text = "Students";
            this.btnNavStudents.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavStudents.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnNavStudents.ForeColor = System.Drawing.Color.White;
            this.btnNavStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStudents.FlatAppearance.BorderSize = 0;
            this.btnNavStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavStudents.Click += new System.EventHandler(this.btnNavStudents_Click);

            this.btnNavCourses.Location = new System.Drawing.Point(205, 4);
            this.btnNavCourses.Size = new System.Drawing.Size(85, 28);
            this.btnNavCourses.Text = "Courses";
            this.btnNavCourses.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavCourses.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnNavCourses.ForeColor = System.Drawing.Color.White;
            this.btnNavCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCourses.FlatAppearance.BorderSize = 0;
            this.btnNavCourses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCourses.Click += new System.EventHandler(this.btnNavCourses_Click);

            this.btnNavDepartments.Location = new System.Drawing.Point(295, 4);
            this.btnNavDepartments.Size = new System.Drawing.Size(105, 28);
            this.btnNavDepartments.Text = "Departments";
            this.btnNavDepartments.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavDepartments.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnNavDepartments.ForeColor = System.Drawing.Color.White;
            this.btnNavDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDepartments.FlatAppearance.BorderSize = 0;
            this.btnNavDepartments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDepartments.Click += new System.EventHandler(this.btnNavDepartments_Click);

            this.btnNavModules.Location = new System.Drawing.Point(405, 4);
            this.btnNavModules.Size = new System.Drawing.Size(85, 28);
            this.btnNavModules.Text = "Modules";
            this.btnNavModules.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavModules.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnNavModules.ForeColor = System.Drawing.Color.White;
            this.btnNavModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavModules.FlatAppearance.BorderSize = 0;
            this.btnNavModules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavModules.Click += new System.EventHandler(this.btnNavModules_Click);

            this.btnNavLecturers.Location = new System.Drawing.Point(495, 4);
            this.btnNavLecturers.Size = new System.Drawing.Size(90, 28);
            this.btnNavLecturers.Text = "Lecturers";
            this.btnNavLecturers.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavLecturers.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
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

            // Labels
            this.lblCourseID.Text = "Course ID";
            this.lblCourseID.Location = new System.Drawing.Point(30, 105);
            this.lblCourseID.Size = new System.Drawing.Size(110, 22);
            this.lblCourseID.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblCourseID.ForeColor = System.Drawing.Color.FromArgb(31, 84, 147);

            this.lblCourseName.Text = "Course Name";
            this.lblCourseName.Location = new System.Drawing.Point(30, 150);
            this.lblCourseName.Size = new System.Drawing.Size(110, 22);
            this.lblCourseName.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblCourseName.ForeColor = System.Drawing.Color.FromArgb(31, 84, 147);

            this.lblDepartmentID.Text = "Department ID";
            this.lblDepartmentID.Location = new System.Drawing.Point(30, 195);
            this.lblDepartmentID.Size = new System.Drawing.Size(120, 22);
            this.lblDepartmentID.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblDepartmentID.ForeColor = System.Drawing.Color.FromArgb(31, 84, 147);

            this.lblDurationYears.Text = "Duration (Years)";
            this.lblDurationYears.Location = new System.Drawing.Point(30, 240);
            this.lblDurationYears.Size = new System.Drawing.Size(130, 22);
            this.lblDurationYears.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblDurationYears.ForeColor = System.Drawing.Color.FromArgb(31, 84, 147);

            // TextBoxes
            this.txtCourseID.Location = new System.Drawing.Point(170, 103);
            this.txtCourseID.Size = new System.Drawing.Size(250, 26);
            this.txtCourseID.Font = new System.Drawing.Font("Arial", 10);
            this.txtCourseID.BackColor = System.Drawing.Color.AliceBlue;

            this.txtCourseName.Location = new System.Drawing.Point(170, 148);
            this.txtCourseName.Size = new System.Drawing.Size(250, 26);
            this.txtCourseName.Font = new System.Drawing.Font("Arial", 10);
            this.txtCourseName.BackColor = System.Drawing.Color.AliceBlue;

            this.txtDepartmentID.Location = new System.Drawing.Point(170, 193);
            this.txtDepartmentID.Size = new System.Drawing.Size(250, 26);
            this.txtDepartmentID.Font = new System.Drawing.Font("Arial", 10);
            this.txtDepartmentID.BackColor = System.Drawing.Color.AliceBlue;

            this.txtDurationYears.Location = new System.Drawing.Point(170, 238);
            this.txtDurationYears.Size = new System.Drawing.Size(250, 26);
            this.txtDurationYears.Font = new System.Drawing.Font("Arial", 10);
            this.txtDurationYears.BackColor = System.Drawing.Color.AliceBlue;

            // Buttons
            this.btnAdd.Location = new System.Drawing.Point(30, 290);
            this.btnAdd.Size = new System.Drawing.Size(90, 38);
            this.btnAdd.Text = "➕ Add";
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(130, 290);
            this.btnUpdate.Size = new System.Drawing.Size(90, 38);
            this.btnUpdate.Text = "✏️ Update";
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(230, 290);
            this.btnDelete.Size = new System.Drawing.Size(90, 38);
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Location = new System.Drawing.Point(330, 290);
            this.btnClear.Size = new System.Drawing.Size(90, 38);
            this.btnClear.Text = "🧹 Clear";
            this.btnClear.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnClear.BackColor = System.Drawing.Color.SlateGray;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.btnBack.Location = new System.Drawing.Point(30, 345);
            this.btnBack.Size = new System.Drawing.Size(130, 38);
            this.btnBack.Text = "⬅️ Back to Dashboard";
            this.btnBack.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // DataGridView
            this.dataGridView1.Location = new System.Drawing.Point(460, 90);
            this.dataGridView1.Size = new System.Drawing.Size(600, 390);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // Status Bar
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.pnlStatus.Location = new System.Drawing.Point(0, 523);
            this.pnlStatus.Size = new System.Drawing.Size(1100, 30);
            this.pnlStatus.Controls.Add(this.statusLabel);

            // Footer Panel
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 40;
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(20, 63, 120);
            this.pnlFooter.Controls.Add(this.lblFooterText);
            this.pnlFooter.Paint += (s, e) => {
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    this.pnlFooter.ClientRectangle,
                    System.Drawing.Color.FromArgb(31, 84, 147),
                    System.Drawing.Color.FromArgb(15, 52, 112),
                    System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, this.pnlFooter.ClientRectangle);
                }

                using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(140, 204, 235), 1))
                {
                    e.Graphics.DrawLine(pen, 0, 0, this.pnlFooter.Width, 0);
                }
            };

            // Footer Label
            this.lblFooterText.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblFooterText.ForeColor = System.Drawing.Color.White;
            this.lblFooterText.BackColor = System.Drawing.Color.Transparent;
            this.lblFooterText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooterText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.statusLabel.Text = "Ready";
            this.statusLabel.Font = new System.Drawing.Font("Arial", 9);
            this.statusLabel.ForeColor = System.Drawing.Color.White;

            // Form
            this.ClientSize = new System.Drawing.Size(1100, 553);
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.Text = "Courses Management";
            this.Load += new System.EventHandler(this.CoursesForm_Load);

            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.lblCourseID);
            this.Controls.Add(this.lblCourseName);
            this.Controls.Add(this.lblDepartmentID);
            this.Controls.Add(this.lblDurationYears);
            this.Controls.Add(this.txtCourseID);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.txtDepartmentID);
            this.Controls.Add(this.txtDurationYears);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlFooter);

            this.pnlTitle.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtCourseID;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.TextBox txtDepartmentID;
        private System.Windows.Forms.TextBox txtDurationYears;
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
        private System.Windows.Forms.Label lblCourseID;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.Label lblDepartmentID;
        private System.Windows.Forms.Label lblDurationYears;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooterText;
    }
}

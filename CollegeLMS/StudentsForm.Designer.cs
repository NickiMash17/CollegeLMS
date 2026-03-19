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
// © 2026 Nicolette Mashaba. All rights reserved.
// This code is the intellectual property of Nicolette Mashaba.
// Unauthorized copying, sharing, reuse, or redistribution of
// this code, in whole or in part, is strictly prohibited
// without prior written permission from the author.
//
// For academic inquiries contact: github.com/NickiMash17
// ============================================================

namespace CollegeLMS
{
    partial class StudentsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtCourseID = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblCourseID = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavStudents = new System.Windows.Forms.Button();
            this.btnNavCourses = new System.Windows.Forms.Button();
            this.btnNavDepartments = new System.Windows.Forms.Button();
            this.btnNavModules = new System.Windows.Forms.Button();
            this.btnNavLecturers = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();

            // -- Title Panel (gradient painted in code) --
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Size = new System.Drawing.Size(1150, 90);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.lblSubTitle);
            this.pnlTitle.Paint += (s, e) => {
                System.Drawing.Drawing2D.LinearGradientBrush brush =
                    new System.Drawing.Drawing2D.LinearGradientBrush(
                        this.pnlTitle.ClientRectangle,
                        System.Drawing.Color.FromArgb(13, 51, 86),
                        System.Drawing.Color.FromArgb(62, 174, 223),
                        System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(brush, this.pnlTitle.ClientRectangle);
            };

            // -- Title Label --
            this.lblTitle.Text = "??  Student APP";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 26, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(370, 8);
            this.lblTitle.Size = new System.Drawing.Size(420, 45);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            // -- SubTitle Label --
            this.lblSubTitle.Text = "College Learner Management System  —  CTUCollegeDB";
            this.lblSubTitle.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Italic);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(95, 151, 184);
            this.lblSubTitle.Location = new System.Drawing.Point(390, 58);
            this.lblSubTitle.Size = new System.Drawing.Size(420, 20);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;

            // -- Nav Bar --
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(13, 51, 86);
            this.pnlNav.Location = new System.Drawing.Point(0, 90);
            this.pnlNav.Size = new System.Drawing.Size(1150, 36);
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

            // -- Left Panel --
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Location = new System.Drawing.Point(0, 90);
            this.pnlLeft.Size = new System.Drawing.Size(470, 500);
            this.pnlLeft.Name = "pnlLeft";

            // -- Student Count Label --
            this.lblCount.Text = "?? Total Students: 0";
            this.lblCount.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.lblCount.Location = new System.Drawing.Point(20, 15);
            this.lblCount.Size = new System.Drawing.Size(220, 22);
            this.lblCount.Name = "lblCount";

            // -- Labels --
            this.lblStudentID.Text = "Student ID";
            this.lblStudentID.Location = new System.Drawing.Point(20, 55);
            this.lblStudentID.Size = new System.Drawing.Size(110, 22);
            this.lblStudentID.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblStudentID.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.lblStudentID.Name = "lblStudentID";

            this.lblFirstName.Text = "First Name";
            this.lblFirstName.Location = new System.Drawing.Point(20, 100);
            this.lblFirstName.Size = new System.Drawing.Size(110, 22);
            this.lblFirstName.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.lblFirstName.Name = "lblFirstName";

            this.lblLastName.Text = "Last Name";
            this.lblLastName.Location = new System.Drawing.Point(20, 145);
            this.lblLastName.Size = new System.Drawing.Size(110, 22);
            this.lblLastName.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.lblLastName.Name = "lblLastName";

            this.lblAge.Text = "Age";
            this.lblAge.Location = new System.Drawing.Point(20, 190);
            this.lblAge.Size = new System.Drawing.Size(110, 22);
            this.lblAge.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblAge.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.lblAge.Name = "lblAge";

            this.lblCourseID.Text = "Course Name";
            this.lblCourseID.Location = new System.Drawing.Point(20, 235);
            this.lblCourseID.Size = new System.Drawing.Size(110, 22);
            this.lblCourseID.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblCourseID.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.lblCourseID.Name = "lblCourseID";

            // -- TextBoxes --
            this.txtStudentID.Location = new System.Drawing.Point(145, 53);
            this.txtStudentID.Size = new System.Drawing.Size(280, 28);
            this.txtStudentID.Font = new System.Drawing.Font("Arial", 10);
            this.txtStudentID.BackColor = System.Drawing.Color.AliceBlue;
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.ReadOnly = true;

            this.txtFirstName.Location = new System.Drawing.Point(145, 98);
            this.txtFirstName.Size = new System.Drawing.Size(280, 28);
            this.txtFirstName.Font = new System.Drawing.Font("Arial", 10);
            this.txtFirstName.BackColor = System.Drawing.Color.AliceBlue;
            this.txtFirstName.Name = "txtFirstName";

            this.txtLastName.Location = new System.Drawing.Point(145, 143);
            this.txtLastName.Size = new System.Drawing.Size(280, 28);
            this.txtLastName.Font = new System.Drawing.Font("Arial", 10);
            this.txtLastName.BackColor = System.Drawing.Color.AliceBlue;
            this.txtLastName.Name = "txtLastName";

            this.txtAge.Location = new System.Drawing.Point(145, 188);
            this.txtAge.Size = new System.Drawing.Size(280, 28);
            this.txtAge.Font = new System.Drawing.Font("Arial", 10);
            this.txtAge.BackColor = System.Drawing.Color.AliceBlue;
            this.txtAge.Name = "txtAge";

            this.txtCourseID.Location = new System.Drawing.Point(145, 233);
            this.txtCourseID.Size = new System.Drawing.Size(280, 28);
            this.txtCourseID.Font = new System.Drawing.Font("Arial", 10);
            this.txtCourseID.BackColor = System.Drawing.Color.AliceBlue;
            this.txtCourseID.Name = "txtCourseID";

            // -- Buttons Row 1 --
            this.btnView.Location = new System.Drawing.Point(20, 285);
            this.btnView.Size = new System.Drawing.Size(90, 38);
            this.btnView.Text = "?? View";
            this.btnView.Name = "btnView";
            this.btnView.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnView.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);

            this.btnAdd.Location = new System.Drawing.Point(120, 285);
            this.btnAdd.Size = new System.Drawing.Size(90, 38);
            this.btnAdd.Text = "? Add";
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(220, 285);
            this.btnUpdate.Size = new System.Drawing.Size(90, 38);
            this.btnUpdate.Text = "?? Update";
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(320, 285);
            this.btnDelete.Size = new System.Drawing.Size(90, 38);
            this.btnDelete.Text = "??? Delete";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // -- Buttons Row 2 --
            this.btnClear.Location = new System.Drawing.Point(20, 335);
            this.btnClear.Size = new System.Drawing.Size(90, 38);
            this.btnClear.Text = "?? Clear";
            this.btnClear.Name = "btnClear";
            this.btnClear.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnClear.BackColor = System.Drawing.Color.SlateGray;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.btnExport.Location = new System.Drawing.Point(120, 335);
            this.btnExport.Size = new System.Drawing.Size(90, 38);
            this.btnExport.Text = "?? Export";
            this.btnExport.Name = "btnExport";
            this.btnExport.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnExport.BackColor = System.Drawing.Color.Teal;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            this.btnPrint.Location = new System.Drawing.Point(220, 335);
            this.btnPrint.Size = new System.Drawing.Size(90, 38);
            this.btnPrint.Text = "??? Print";
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnPrint.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // -- Search Bar --
            this.lblSearch.Text = "?? Search:";
            this.lblSearch.Location = new System.Drawing.Point(490, 103);
            this.lblSearch.Size = new System.Drawing.Size(80, 22);
            this.lblSearch.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.lblSearch.Name = "lblSearch";

            this.txtSearch.Location = new System.Drawing.Point(580, 100);
            this.txtSearch.Size = new System.Drawing.Size(310, 28);
            this.txtSearch.Font = new System.Drawing.Font("Arial", 10);
            this.txtSearch.BackColor = System.Drawing.Color.AliceBlue;
            this.txtSearch.Name = "txtSearch";

            this.btnSearch.Location = new System.Drawing.Point(900, 98);
            this.btnSearch.Size = new System.Drawing.Size(90, 32);
            this.btnSearch.Text = "?? Search";
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // -- DataGridView --
            this.dataGridView1.Location = new System.Drawing.Point(480, 140);
            this.dataGridView1.Size = new System.Drawing.Size(640, 400);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // -- Status Bar --
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(27, 117, 180);
            this.pnlStatus.Location = new System.Drawing.Point(0, 555);
            this.pnlStatus.Size = new System.Drawing.Size(1150, 32);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Controls.Add(this.statusLabel);

            this.statusLabel.Text = "Ready";
            this.statusLabel.Font = new System.Drawing.Font("Arial", 9);
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(10, 8);
            this.statusLabel.Size = new System.Drawing.Size(900, 18);
            this.statusLabel.Name = "statusLabel";

            // -- Form --
            this.ClientSize = new System.Drawing.Size(1150, 587);
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.Text = "Student Application Form";
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);

            // Add controls to pnlLeft
            this.pnlLeft.Controls.Add(this.lblCount);
            this.pnlLeft.Controls.Add(this.lblStudentID);
            this.pnlLeft.Controls.Add(this.lblFirstName);
            this.pnlLeft.Controls.Add(this.lblLastName);
            this.pnlLeft.Controls.Add(this.lblAge);
            this.pnlLeft.Controls.Add(this.lblCourseID);
            this.pnlLeft.Controls.Add(this.txtStudentID);
            this.pnlLeft.Controls.Add(this.txtFirstName);
            this.pnlLeft.Controls.Add(this.txtLastName);
            this.pnlLeft.Controls.Add(this.txtAge);
            this.pnlLeft.Controls.Add(this.txtCourseID);
            this.pnlLeft.Controls.Add(this.btnView);
            this.pnlLeft.Controls.Add(this.btnAdd);
            this.pnlLeft.Controls.Add(this.btnUpdate);
            this.pnlLeft.Controls.Add(this.btnDelete);
            this.pnlLeft.Controls.Add(this.btnClear);
            this.pnlLeft.Controls.Add(this.btnExport);
            this.pnlLeft.Controls.Add(this.btnPrint);

            // Add to Form
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);

            this.pnlTitle.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtCourseID;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblCourseID;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavStudents;
        private System.Windows.Forms.Button btnNavCourses;
        private System.Windows.Forms.Button btnNavDepartments;
        private System.Windows.Forms.Button btnNavModules;
        private System.Windows.Forms.Button btnNavLecturers;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label statusLabel;
    }
}





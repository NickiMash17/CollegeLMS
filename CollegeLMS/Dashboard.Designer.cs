﻿// ============================================================
// COPYRIGHT NOTICE
// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba
// Student No:  20232990
// © 2026 Nicolette Mashaba. All rights reserved.
// ============================================================

namespace CollegeLMS
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblInstruct = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavStudents = new System.Windows.Forms.Button();
            this.btnNavCourses = new System.Windows.Forms.Button();
            this.btnNavDepartments = new System.Windows.Forms.Button();
            this.btnNavModules = new System.Windows.Forms.Button();
            this.btnNavLecturers = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.btnModules = new System.Windows.Forms.Button();
            this.btnLecturers = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterText = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();

            // ── Title Panel ──
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Size = new System.Drawing.Size(1000, 150);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.lblSubTitle);
            this.pnlTitle.Controls.Add(this.lblDateTime);
            this.pnlTitle.Paint += (s, e) => {
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    this.pnlTitle.ClientRectangle,
                    System.Drawing.Color.FromArgb(15, 52, 112),
                    System.Drawing.Color.FromArgb(52, 120, 200),
                    System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, this.pnlTitle.ClientRectangle);
                }
            };

            // ── Title ──
            this.lblTitle.Text = "🎓  College LMS";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 30, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(260, 20);
            this.lblTitle.Size = new System.Drawing.Size(480, 48);

            // ── SubTitle ──
            this.lblSubTitle.Text = "College Learner Management System : CTUCollegeDB";
            this.lblSubTitle.Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Italic);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(140, 204, 235);
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Location = new System.Drawing.Point(250, 78);
            this.lblSubTitle.Size = new System.Drawing.Size(600, 24);

            // ── Date Time ──
            this.lblDateTime.Text = System.DateTime.Now.ToString("dddd, dd MMMM yyyy");
            this.lblDateTime.Font = new System.Drawing.Font("Arial", 10);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(140, 204, 235);
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Location = new System.Drawing.Point(780, 18);
            this.lblDateTime.Size = new System.Drawing.Size(190, 22);
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ── Nav Bar ──
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(20, 63, 120);
            this.pnlNav.Location = new System.Drawing.Point(0, 150);
            this.pnlNav.Size = new System.Drawing.Size(1000, 48);
            this.pnlNav.Name = "pnlNav";

            this.btnNavDashboard.Location = new System.Drawing.Point(12, 10);
            this.btnNavDashboard.Size = new System.Drawing.Size(100, 28);
            this.btnNavDashboard.Text = "Dashboard";
            this.btnNavDashboard.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);

            this.btnNavStudents.Location = new System.Drawing.Point(120, 10);
            this.btnNavStudents.Size = new System.Drawing.Size(90, 28);
            this.btnNavStudents.Text = "Students";
            this.btnNavStudents.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavStudents.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnNavStudents.ForeColor = System.Drawing.Color.White;
            this.btnNavStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStudents.FlatAppearance.BorderSize = 0;
            this.btnNavStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavStudents.Click += new System.EventHandler(this.btnNavStudents_Click);

            this.btnNavCourses.Location = new System.Drawing.Point(215, 10);
            this.btnNavCourses.Size = new System.Drawing.Size(85, 28);
            this.btnNavCourses.Text = "Courses";
            this.btnNavCourses.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavCourses.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnNavCourses.ForeColor = System.Drawing.Color.White;
            this.btnNavCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCourses.FlatAppearance.BorderSize = 0;
            this.btnNavCourses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCourses.Click += new System.EventHandler(this.btnNavCourses_Click);

            this.btnNavDepartments.Location = new System.Drawing.Point(305, 10);
            this.btnNavDepartments.Size = new System.Drawing.Size(110, 28);
            this.btnNavDepartments.Text = "Departments";
            this.btnNavDepartments.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavDepartments.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnNavDepartments.ForeColor = System.Drawing.Color.White;
            this.btnNavDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDepartments.FlatAppearance.BorderSize = 0;
            this.btnNavDepartments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDepartments.Click += new System.EventHandler(this.btnNavDepartments_Click);

            this.btnNavModules.Location = new System.Drawing.Point(420, 10);
            this.btnNavModules.Size = new System.Drawing.Size(85, 28);
            this.btnNavModules.Text = "Modules";
            this.btnNavModules.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            this.btnNavModules.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnNavModules.ForeColor = System.Drawing.Color.White;
            this.btnNavModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavModules.FlatAppearance.BorderSize = 0;
            this.btnNavModules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavModules.Click += new System.EventHandler(this.btnNavModules_Click);

            this.btnNavLecturers.Location = new System.Drawing.Point(510, 10);
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

            // ── Welcome Text ──
            this.lblWelcome.Text = "Welcome to College LMS";
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 26, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.lblWelcome.Location = new System.Drawing.Point(250, 190);
            this.lblWelcome.Size = new System.Drawing.Size(560, 44);
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Instruction ──
            this.lblInstruct.Text = "Select a module below to get started";
            this.lblInstruct.Font = new System.Drawing.Font("Arial", 12);
            this.lblInstruct.ForeColor = System.Drawing.Color.Gray;
            this.lblInstruct.Location = new System.Drawing.Point(300, 235);
            this.lblInstruct.Size = new System.Drawing.Size(460, 26);
            this.lblInstruct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── ROW 1 CARDS ──

            // Students Card
            this.btnStudents.Location = new System.Drawing.Point(60, 300);
            this.btnStudents.Size = new System.Drawing.Size(240, 140);
            this.btnStudents.Text = "Students\r\nManage Students";
            this.btnStudents.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.btnStudents.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);

            // Courses Card
            this.btnCourses.Location = new System.Drawing.Point(310, 300);
            this.btnCourses.Size = new System.Drawing.Size(240, 140);
            this.btnCourses.Text = "Courses\r\nManage Courses";
            this.btnCourses.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.btnCourses.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCourses.ForeColor = System.Drawing.Color.White;
            this.btnCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourses.FlatAppearance.BorderSize = 0;
            this.btnCourses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);

            // Departments Card
            this.btnDepartments.Location = new System.Drawing.Point(560, 300);
            this.btnDepartments.Size = new System.Drawing.Size(240, 140);
            this.btnDepartments.Text = "Departments\r\nManage Departments";
            this.btnDepartments.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.btnDepartments.BackColor = System.Drawing.Color.DarkOrange;
            this.btnDepartments.ForeColor = System.Drawing.Color.White;
            this.btnDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartments.FlatAppearance.BorderSize = 0;
            this.btnDepartments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDepartments.Click += new System.EventHandler(this.btnDepartments_Click);

            // Modules Card
            this.btnModules.Location = new System.Drawing.Point(810, 300);
            this.btnModules.Size = new System.Drawing.Size(240, 140);
            this.btnModules.Text = "Modules\r\nManage Modules";
            this.btnModules.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.btnModules.BackColor = System.Drawing.Color.Teal;
            this.btnModules.ForeColor = System.Drawing.Color.White;
            this.btnModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModules.FlatAppearance.BorderSize = 0;
            this.btnModules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModules.Click += new System.EventHandler(this.btnModules_Click);

            // ── ROW 2 CARDS ──

            // Lecturers Card
            this.btnLecturers.Location = new System.Drawing.Point(390, 490);
            this.btnLecturers.Size = new System.Drawing.Size(240, 140);
            this.btnLecturers.Text = "Lecturers\r\nManage Lecturers";
            this.btnLecturers.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.btnLecturers.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnLecturers.ForeColor = System.Drawing.Color.White;
            this.btnLecturers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLecturers.FlatAppearance.BorderSize = 0;
            this.btnLecturers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLecturers.Click += new System.EventHandler(this.btnLecturers_Click);

            // ── Status Bar ──
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(31, 84, 147);
            this.pnlStatus.Location = new System.Drawing.Point(0, 535);
            this.pnlStatus.Size = new System.Drawing.Size(1000, 32);
            this.pnlStatus.Controls.Add(this.lblStatus);

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

            this.lblStatus.Text = "✅ Welcome to College LMS : CTUCollegeDB";
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(10, 8);
            this.lblStatus.Size = new System.Drawing.Size(800, 18);

            // ── Form ──
            this.ClientSize = new System.Drawing.Size(1000, 567);
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.Text = "College LMS : Dashboard";
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);

            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblInstruct);
            this.Controls.Add(this.btnStudents);
            this.Controls.Add(this.btnCourses);
            this.Controls.Add(this.btnDepartments);
            this.Controls.Add(this.btnModules);
            this.Controls.Add(this.btnLecturers);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlFooter);

            this.pnlTitle.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblInstruct;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavStudents;
        private System.Windows.Forms.Button btnNavCourses;
        private System.Windows.Forms.Button btnNavDepartments;
        private System.Windows.Forms.Button btnNavModules;
        private System.Windows.Forms.Button btnNavLecturers;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.Button btnModules;
        private System.Windows.Forms.Button btnLecturers;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooterText;
    }
}

﻿// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba  |  Student No: 20232990
// © 2026 Nicolette Mashaba. All rights reserved.
// ============================================================

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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
            this.pnlTitle      = new System.Windows.Forms.Panel();
            this.btnLogout     = new System.Windows.Forms.Button();
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblSubTitle   = new System.Windows.Forms.Label();
            this.lblWelcome    = new System.Windows.Forms.Label();
            this.lblInstruct   = new System.Windows.Forms.Label();
            this.lblDateTime   = new System.Windows.Forms.Label();
            this.pnlNav        = new System.Windows.Forms.Panel();
            this.btnNavDashboard   = new System.Windows.Forms.Button();
            this.btnNavStudents    = new System.Windows.Forms.Button();
            this.btnNavCourses     = new System.Windows.Forms.Button();
            this.btnNavDepartments = new System.Windows.Forms.Button();
            this.btnNavModules     = new System.Windows.Forms.Button();
            this.btnNavLecturers   = new System.Windows.Forms.Button();
            this.btnStudents    = new System.Windows.Forms.Button();
            this.btnCourses     = new System.Windows.Forms.Button();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.btnModules     = new System.Windows.Forms.Button();
            this.btnLecturers   = new System.Windows.Forms.Button();
            this.pnlStatus      = new System.Windows.Forms.Panel();
            this.lblStatus      = new System.Windows.Forms.Label();
            this.pnlFooter      = new System.Windows.Forms.Panel();
            this.lblFooterText  = new System.Windows.Forms.Label();

            this.pnlTitle.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();

            // ── Title Panel ─────────────────────────────────────────────────
            this.pnlTitle.Dock  = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Size  = new System.Drawing.Size(1200, 148);
            this.pnlTitle.Name  = "pnlTitle";
            this.pnlTitle.Paint += (s, e) => UiTheme.PaintHeaderPanel(this.pnlTitle, e);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.lblSubTitle);
            this.pnlTitle.Controls.Add(this.lblDateTime);
            this.pnlTitle.Controls.Add(this.lblWelcome);
            this.pnlTitle.Controls.Add(this.lblInstruct);
            this.pnlTitle.Controls.Add(this.btnLogout);

            // ── Title label ──────────────────────────────────────────────────
            this.lblTitle.Text      = "College LMS";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI Semibold", 28, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location  = new System.Drawing.Point(0, 18);
            this.lblTitle.Size      = new System.Drawing.Size(500, 44);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Name      = "lblTitle";

            // ── Subtitle ─────────────────────────────────────────────────────
            this.lblSubTitle.Text      = "College Learner Management System  \u2022  CTUCollegeDB";
            this.lblSubTitle.Font      = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Italic);
            this.lblSubTitle.ForeColor = UiTheme.TextLightBlue;
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Location  = new System.Drawing.Point(0, 68);
            this.lblSubTitle.Size      = new System.Drawing.Size(600, 22);
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubTitle.Name      = "lblSubTitle";

            // ── DateTime ─────────────────────────────────────────────────────
            this.lblDateTime.Text      = System.DateTime.Now.ToString("dddd, dd MMMM yyyy");
            this.lblDateTime.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDateTime.ForeColor = UiTheme.TextLightBlue;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Size      = new System.Drawing.Size(220, 22);
            this.lblDateTime.Location  = new System.Drawing.Point(760, 16);
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDateTime.Name      = "lblDateTime";

            // ── Welcome ──────────────────────────────────────────────────────
            this.lblWelcome.Text      = "Welcome to CTU College LMS";
            this.lblWelcome.Font      = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Location  = new System.Drawing.Point(0, 96);
            this.lblWelcome.Size      = new System.Drawing.Size(600, 26);
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWelcome.Name      = "lblWelcome";

            // ── Instruct ─────────────────────────────────────────────────────
            this.lblInstruct.Text      = "Select a module below to get started";
            this.lblInstruct.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInstruct.ForeColor = UiTheme.TextLightBlue;
            this.lblInstruct.BackColor = System.Drawing.Color.Transparent;
            this.lblInstruct.Location  = new System.Drawing.Point(0, 122);
            this.lblInstruct.Size      = new System.Drawing.Size(500, 20);
            this.lblInstruct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInstruct.Name      = "lblInstruct";

            // ── Logout button ─────────────────────────────────────────────────
            this.btnLogout.Text      = "Sign Out";
            this.btnLogout.Font      = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.BackColor = UiTheme.BtnRed;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Location  = new System.Drawing.Point(860, 52);
            this.btnLogout.Size      = new System.Drawing.Size(120, 38);
            this.btnLogout.Name      = "btnLogout";
            UiTheme.SetRoundedRegion(this.btnLogout, 8);
            this.btnLogout.MouseEnter += (s, e) => btnLogout.BackColor = UiTheme.BtnRedHov;
            this.btnLogout.MouseLeave += (s, e) => btnLogout.BackColor = UiTheme.BtnRed;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // ── Nav bar ───────────────────────────────────────────────────────
            this.pnlNav.Dock   = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Size   = new System.Drawing.Size(1200, 46);
            this.pnlNav.Name   = "pnlNav";
            this.pnlNav.Paint += (s, e) => UiTheme.PaintNavPanel(this.pnlNav, e, activeNavButton);

            System.Action<System.Windows.Forms.Button, string, int, System.EventHandler> makeNav =
                (btn, text, x, handler) =>
                {
                    btn.Text      = text;
                    btn.Location  = new System.Drawing.Point(x, 9);
                    btn.Size      = new System.Drawing.Size(text.Length > 9 ? 115 : 100, 30);
                    btn.Click    += handler;
                    UiTheme.ApplyNavButton(btn);
                    this.pnlNav.Controls.Add(btn);
                };

            makeNav(this.btnNavDashboard,   "Dashboard",   14,  this.btnNavDashboard_Click);
            makeNav(this.btnNavStudents,    "Students",    122, this.btnNavStudents_Click);
            makeNav(this.btnNavCourses,     "Courses",     230, this.btnNavCourses_Click);
            makeNav(this.btnNavDepartments, "Departments", 338, this.btnNavDepartments_Click);
            makeNav(this.btnNavModules,     "Modules",     462, this.btnNavModules_Click);
            makeNav(this.btnNavLecturers,   "Lecturers",   570, this.btnNavLecturers_Click);

            // ── Dashboard cards ───────────────────────────────────────────────
            System.Action<System.Windows.Forms.Button, System.Drawing.Color, System.EventHandler> makeCard =
                (btn, color, handler) =>
                {
                    btn.Text      = "";
                    btn.BackColor = color;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor    = System.Windows.Forms.Cursors.Hand;
                    btn.Click    += handler;
                    btn.Paint    += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);
                    UiTheme.SetRoundedRegion(btn, 14);
                };

            makeCard(this.btnStudents,    UiTheme.CardStudents,    this.btnStudents_Click);
            makeCard(this.btnCourses,     UiTheme.CardCourses,     this.btnCourses_Click);
            makeCard(this.btnDepartments, UiTheme.CardDepartments, this.btnDepartments_Click);
            makeCard(this.btnModules,     UiTheme.CardModules,     this.btnModules_Click);
            makeCard(this.btnLecturers,   UiTheme.CardLecturers,   this.btnLecturers_Click);

            // ── Status bar ────────────────────────────────────────────────────
            this.pnlStatus.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Size      = new System.Drawing.Size(1200, 30);
            this.pnlStatus.BackColor = UiTheme.NavyDeep;
            this.pnlStatus.Name      = "pnlStatus";
            this.pnlStatus.Controls.Add(this.lblStatus);

            this.lblStatus.Text      = "Welcome to College LMS  \u2022  CTUCollegeDB";
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = UiTheme.TextLightBlue;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Location  = new System.Drawing.Point(12, 6);
            this.lblStatus.Size      = new System.Drawing.Size(900, 20);

            // ── Footer ────────────────────────────────────────────────────────
            this.pnlFooter.Dock    = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height  = 50;
            this.pnlFooter.Name    = "pnlFooter";
            this.pnlFooter.Paint  += (s, e) => UiTheme.PaintFooterPanel(this.pnlFooter, e);
            this.pnlFooter.Controls.Add(this.lblFooterText);

            this.lblFooterText.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblFooterText.ForeColor = UiTheme.TextLightBlue;
            this.lblFooterText.BackColor = System.Drawing.Color.Transparent;
            this.lblFooterText.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblFooterText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Form ──────────────────────────────────────────────────────────
            this.ClientSize    = new System.Drawing.Size(1200, 700);
            this.BackColor     = UiTheme.AppBackground;
            this.Text          = "College LMS : Dashboard";
            this.Name          = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState   = System.Windows.Forms.FormWindowState.Maximized;
            this.Load         += new System.EventHandler(this.Dashboard_Load);

            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlNav);
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

        private System.Windows.Forms.Panel  pnlTitle;
        private System.Windows.Forms.Panel  pnlStatus;
        private System.Windows.Forms.Panel  pnlNav;
        private System.Windows.Forms.Panel  pnlFooter;
        private System.Windows.Forms.Label  lblTitle;
        private System.Windows.Forms.Label  lblSubTitle;
        private System.Windows.Forms.Label  lblDateTime;
        private System.Windows.Forms.Label  lblWelcome;
        private System.Windows.Forms.Label  lblInstruct;
        private System.Windows.Forms.Label  lblStatus;
        private System.Windows.Forms.Label  lblFooterText;
        private System.Windows.Forms.Button btnLogout;
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
    }
}
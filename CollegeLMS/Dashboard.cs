// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba  |  Student No: 20232990
// © 2026 Nicolette Mashaba. All rights reserved.
// ============================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CollegeLMS
{
    public partial class Dashboard : Form
    {
        private readonly Dictionary<Button, Point>    cardHomeLocations = new Dictionary<Button, Point>();
        private readonly Dictionary<Button, CardSpec> cardSpecs         = new Dictionary<Button, CardSpec>();
        private Button     activeNavButton;
        private PictureBox bgPicture;

        public Dashboard()
        {
            InitializeComponent();
            UiTheme.ApplyFormDefaults(this);
            DoubleBuffered = true;
            ResizeRedraw   = true;

            Resize += Dashboard_Resize;
            Paint  += Dashboard_Paint;

            bgPicture = new PictureBox
            {
                Dock      = DockStyle.Fill,
                SizeMode  = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            Controls.Add(bgPicture);
            bgPicture.SendToBack();

            // Card specs — emoji icons for the dashboard cards
            SetupCard(btnStudents,    "\U0001F464", "Students",    "Manage Students");
            SetupCard(btnCourses,     "\U0001F4DA", "Courses",     "Manage Courses");
            SetupCard(btnDepartments, "\U0001F3E2", "Departments", "Manage Departments");
            SetupCard(btnModules,     "\U0001F4D6", "Modules",     "Manage Modules");
            SetupCard(btnLecturers,   "\U0001F468\u200D\U0001F3EB", "Lecturers", "Manage Lecturers");

            WireCardHover(btnStudents);
            WireCardHover(btnCourses);
            WireCardHover(btnDepartments);
            WireCardHover(btnModules);
            WireCardHover(btnLecturers);

            if (pnlNav != null)
                pnlNav.Paint += (s, e) => UiTheme.PaintNavPanel(pnlNav, e, activeNavButton);

            activeNavButton = btnNavDashboard;
            SetActiveNav(btnNavDashboard);

            UiTheme.ApplyNavStyle(btnNavDashboard, btnNavStudents, btnNavCourses,
                                  btnNavDepartments, btnNavModules, btnNavLecturers);

            UiTheme.ApplyDangerButton(btnLogout);
            btnLogout.Text = "Sign Out";

            if (lblFooterText != null)
                lblFooterText.Text =
                    "CTU College LMS   \u2022   \u00A9 2026 Nicolette Mashaba   \u2022   Empowering Education Through Technology";

            TrySetBackgroundImage();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if (lblDateTime != null)
                lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            LayoutDashboard();
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            LayoutDashboard();
            Invalidate();
        }

        private void LayoutDashboard()
        {
            if (pnlTitle == null || pnlNav == null) return;

            UiTheme.ApplyHeader(pnlTitle, lblTitle, lblSubTitle);

            if (lblWelcome  != null) { lblWelcome.Width  = Math.Min(800, ClientSize.Width - 40); lblWelcome.Left  = (ClientSize.Width - lblWelcome.Width)  / 2; }
            if (lblInstruct != null) { lblInstruct.Width = Math.Min(700, ClientSize.Width - 40); lblInstruct.Left = (ClientSize.Width - lblInstruct.Width) / 2; }
            if (lblDateTime != null) lblDateTime.Left = pnlTitle.Width - lblDateTime.Width - 22;
            if (btnLogout   != null) btnLogout.Left   = pnlTitle.Width - btnLogout.Width   - 22;

            int cardW = 260, cardH = 155, gap = 32, rowGap = 36;
            int contentTop    = pnlNav.Bottom + 28;
            int contentBottom = pnlStatus?.Top ?? ClientSize.Height - 90;
            int contentHeight = Math.Max(0, contentBottom - contentTop);

            int row1X = Math.Max(20, (ClientSize.Width - (cardW * 3 + gap * 2)) / 2);
            int row2X = Math.Max(20, (ClientSize.Width - (cardW * 2 + gap))     / 2);
            int blockH = cardH * 2 + rowGap + 50;
            int row1Y  = contentTop + Math.Max(10, (contentHeight - blockH) / 2) + 20;
            int row2Y  = row1Y + cardH + rowGap;

            void Place(Button b, int x, int y)
            {
                if (b == null) return;
                b.Size     = new Size(cardW, cardH);
                b.Location = new Point(x, y);
                UiTheme.SetRoundedRegion(b, 14);
            }

            Place(btnDepartments, row1X,                     row1Y);
            Place(btnCourses,     row1X + cardW + gap,       row1Y);
            Place(btnStudents,    row1X + 2 * (cardW + gap), row1Y);
            Place(btnModules,     row2X,                     row2Y);
            Place(btnLecturers,   row2X + cardW + gap,       row2Y);

            UiTheme.SetRoundedRegion(btnLogout, 8);
            RememberCardHomes();
        }

        private void RememberCardHomes()
        {
            void R(Button b) { if (b != null) cardHomeLocations[b] = b.Location; }
            R(btnStudents); R(btnCourses); R(btnDepartments); R(btnModules); R(btnLecturers);
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

        private void SetupCard(Button btn, string icon, string title, string subtitle)
        {
            if (btn == null) return;
            cardSpecs[btn] = new CardSpec(icon, title, subtitle);
            btn.Text = string.Empty;
        }

        private void WireCardHover(Button btn)
        {
            if (btn == null) return;
            btn.MouseEnter += (s, e) =>
            {
                if (!cardHomeLocations.ContainsKey(btn)) cardHomeLocations[btn] = btn.Location;
                btn.Location = new Point(cardHomeLocations[btn].X - 1, cardHomeLocations[btn].Y - 4);
                Invalidate();
            };
            btn.MouseLeave += (s, e) =>
            {
                if (cardHomeLocations.ContainsKey(btn)) btn.Location = cardHomeLocations[btn];
                Invalidate();
            };
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Button btn && cardSpecs.ContainsKey(btn))
            {
                var s = cardSpecs[btn];
                UiTheme.PaintDashboardCard(btn, s.Icon, s.Title, s.Subtitle, e);
            }
        }

        private void Dashboard_Paint(object sender, PaintEventArgs e)
        {
            var tray = GetCardsTrayBounds();
            if (!tray.IsEmpty)
            {
                UiTheme.DrawSoftShadow(e.Graphics, tray, 28, 18, 12, 38);
                UiTheme.DrawFrostedTray(e.Graphics, tray, 28);
            }
            void Shadow(Control c) { if (c != null && c.Visible) UiTheme.DrawSoftShadow(e.Graphics, c.Bounds, 14, 12, 8, 50); }
            Shadow(btnStudents); Shadow(btnCourses); Shadow(btnDepartments); Shadow(btnModules); Shadow(btnLecturers);
        }

        private Rectangle GetCardsTrayBounds()
        {
            var cards = new[] { btnStudents, btnCourses, btnDepartments, btnModules, btnLecturers };
            var union = Rectangle.Empty;
            foreach (var b in cards)
                if (b != null && b.Visible) union = union.IsEmpty ? b.Bounds : Rectangle.Union(union, b.Bounds);
            if (union.IsEmpty) return Rectangle.Empty;
            union.Inflate(38, 30);
            return union;
        }

        private void TrySetBackgroundImage()
        {
            try
            {
                string b = AppDomain.CurrentDomain.BaseDirectory;
                foreach (var dir in new[] { b, $"{b}..\\..\\", $"{b}..\\..\\..\\", Environment.CurrentDirectory })
                {
                    string p = Path.GetFullPath(Path.Combine(dir, "tp244-bg1-01.jpg"));
                    if (!File.Exists(p)) continue;
                    Image img;
                    using (var fs = File.OpenRead(p)) using (var t = Image.FromStream(fs)) img = new System.Drawing.Bitmap(t);
                    if (bgPicture != null) bgPicture.Image = img;
                    return;
                }
            }
            catch { }
        }

        // ── Click handlers ────────────────────────────────────────────────────
        private void btnStudents_Click(object sender, EventArgs e)    => new StudentsForm().Show();
        private void btnCourses_Click(object sender, EventArgs e)     => new CoursesForm().Show();
        private void btnDepartments_Click(object sender, EventArgs e) => new DepartmentsForm().Show();
        private void btnModules_Click(object sender, EventArgs e)     => new ModulesForm().Show();
        private void btnLecturers_Click(object sender, EventArgs e)   => new LecturersForm().Show();

        private void btnNavDashboard_Click(object sender, EventArgs e)   => SetActiveNav(btnNavDashboard);
        private void btnNavStudents_Click(object sender, EventArgs e)    { SetActiveNav(btnNavStudents);    new StudentsForm().Show(); }
        private void btnNavCourses_Click(object sender, EventArgs e)     { SetActiveNav(btnNavCourses);     new CoursesForm().Show(); }
        private void btnNavDepartments_Click(object sender, EventArgs e) { SetActiveNav(btnNavDepartments); new DepartmentsForm().Show(); }
        private void btnNavModules_Click(object sender, EventArgs e)     { SetActiveNav(btnNavModules);     new ModulesForm().Show(); }
        private void btnNavLecturers_Click(object sender, EventArgs e)   { SetActiveNav(btnNavLecturers);   new LecturersForm().Show(); }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Sign Out",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Hide();
                var login = new LoginForm();
                login.FormClosed += (s, args) => Application.Exit();
                login.Show();
            }
        }

        private class CardSpec
        {
            public string Icon { get; }
            public string Title { get; }
            public string Subtitle { get; }
            public CardSpec(string icon, string title, string subtitle)
            { Icon = icon; Title = title; Subtitle = subtitle; }
        }
    }
}
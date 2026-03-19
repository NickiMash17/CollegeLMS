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
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CollegeLMS
{
    public partial class Dashboard : Form
    {
        private readonly Dictionary<Button, Color> cardColors = new Dictionary<Button, Color>();
        private readonly Dictionary<Button, CardSpec> cardSpecs = new Dictionary<Button, CardSpec>();
        private Button activeNavButton;
        private PictureBox bgPicture;

        public Dashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Resize += Dashboard_Resize;
            this.Paint += Dashboard_Paint;

            // Background image container (ensures image shows behind all controls)
            bgPicture = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Controls.Add(bgPicture);
            bgPicture.SendToBack();

            SetupCard(btnStudents, "👨‍🎓", "Students", "Manage Students");
            SetupCard(btnCourses, "📚", "Courses", "Manage Courses");
            SetupCard(btnDepartments, "🏢", "Departments", "Manage Departments");
            SetupCard(btnModules, "📖", "Modules", "Manage Modules");
            SetupCard(btnLecturers, "👨‍🏫", "Lecturers", "Manage Lecturers");

            WireCardHover(btnStudents);
            WireCardHover(btnCourses);
            WireCardHover(btnDepartments);
            WireCardHover(btnModules);
            WireCardHover(btnLecturers);

            if (pnlNav != null) pnlNav.Paint += NavBar_Paint;
            activeNavButton = btnNavDashboard;

            TrySetBackgroundImage();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();
            LayoutDashboard();
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            LayoutDashboard();
            Invalidate();
        }

        private void UpdateDateTimeLabel()
        {
            if (lblDateTime != null)
            {
                lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            }
        }

        private void LayoutDashboard()
        {
            if (pnlTitle == null || pnlNav == null || pnlStatus == null) return;

            int contentTop = pnlNav.Bottom + 20;
            int contentBottom = pnlStatus.Top - 20;
            int contentHeight = Math.Max(0, contentBottom - contentTop);

            lblWelcome.Width = Math.Min(820, ClientSize.Width - 40);
            lblWelcome.Left = (ClientSize.Width - lblWelcome.Width) / 2;
            lblWelcome.Top = contentTop + 10;

            lblInstruct.Width = Math.Min(680, ClientSize.Width - 40);
            lblInstruct.Left = (ClientSize.Width - lblInstruct.Width) / 2;
            lblInstruct.Top = lblWelcome.Bottom + 10;

            int cardW = 250;
            int cardH = 150;
            int gap = 35;
            int heroGap = 30;
            int rowGap = 40;

            int totalRowW = cardW * 3 + gap * 2;
            int startX = Math.Max(20, (ClientSize.Width - totalRowW) / 2);

            int totalRow2W = cardW * 2 + gap;
            int row2X = Math.Max(20, (ClientSize.Width - totalRow2W) / 2);

            int blockHeight = (lblInstruct.Height + heroGap) + cardH + rowGap + cardH;
            int blockTop = contentTop + Math.Max(10, (contentHeight - blockHeight) / 2);

            lblWelcome.Top = blockTop;
            lblInstruct.Top = lblWelcome.Bottom + 10;
            int row1Y = lblInstruct.Bottom + heroGap;

            btnStudents.Size = new System.Drawing.Size(cardW, cardH);
            btnCourses.Size = new System.Drawing.Size(cardW, cardH);
            btnDepartments.Size = new System.Drawing.Size(cardW, cardH);
            btnModules.Size = new System.Drawing.Size(cardW, cardH);
            btnLecturers.Size = new System.Drawing.Size(cardW, cardH);

            btnDepartments.Location = new System.Drawing.Point(startX, row1Y);
            btnCourses.Location = new System.Drawing.Point(startX + (cardW + gap), row1Y);
            btnStudents.Location = new System.Drawing.Point(startX + 2 * (cardW + gap), row1Y);

            int row2Y = row1Y + cardH + rowGap;
            btnModules.Location = new System.Drawing.Point(row2X, row2Y);
            btnLecturers.Location = new System.Drawing.Point(row2X + cardW + gap, row2Y);

            if (pnlTitle != null)
            {
                lblTitle.Width = Math.Min(900, pnlTitle.Width - 40);
                lblSubTitle.Width = Math.Min(900, pnlTitle.Width - 40);
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
                lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;
                lblTitle.Left = (pnlTitle.Width - lblTitle.Width) / 2;
                lblSubTitle.Left = (pnlTitle.Width - lblSubTitle.Width) / 2;
                lblTitle.Top = 22;
                lblSubTitle.Top = lblTitle.Bottom + 6;
                lblDateTime.Left = pnlTitle.Width - lblDateTime.Width - 20;
            }

            CenterNavButtons();
            ApplyRoundedCards();
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

        private void NavBar_Paint(object sender, PaintEventArgs e)
        {
            if (activeNavButton == null) return;
            Rectangle r = activeNavButton.Bounds;
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush, r.Left, r.Bottom - 3, r.Width, 3);
            }
        }

        private void ApplyRoundedCards()
        {
            ApplyRounded(btnStudents, 10);
            ApplyRounded(btnCourses, 10);
            ApplyRounded(btnDepartments, 10);
            ApplyRounded(btnModules, 10);
            ApplyRounded(btnLecturers, 10);
        }

        private void ApplyRounded(Button btn, int radius)
        {
            if (btn == null) return;
            Rectangle bounds = new Rectangle(0, 0, btn.Width, btn.Height);
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
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

        private void WireCardHover(Button btn)
        {
            if (btn == null) return;
            cardColors[btn] = btn.BackColor;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(btn.BackColor, 0.15f);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(btn.BackColor, 0.10f);
            btn.Text = string.Empty;
            btn.Paint += Card_Paint;
            btn.MouseEnter += (s, e) =>
            {
                Button b = (Button)s;
                b.BackColor = ControlPaint.Light(cardColors[b], 0.15f);
            };
            btn.MouseLeave += (s, e) =>
            {
                Button b = (Button)s;
                b.BackColor = cardColors[b];
            };
        }

        private void SetupCard(Button btn, string icon, string title, string subtitle)
        {
            if (btn == null) return;
            cardSpecs[btn] = new CardSpec(icon, title, subtitle);
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || !cardSpecs.ContainsKey(btn)) return;
            CardSpec spec = cardSpecs[btn];

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Font iconFont = new Font("Arial", 16, FontStyle.Regular))
            using (Font titleFont = new Font("Arial", 13, FontStyle.Bold))
            using (Font subFont = new Font("Arial", 9, FontStyle.Regular))
            {
                Size iconSize = TextRenderer.MeasureText(spec.Icon, iconFont);
                Size titleSize = TextRenderer.MeasureText(spec.Title, titleFont);
                Size subSize = TextRenderer.MeasureText(spec.Subtitle, subFont);

                int totalH = iconSize.Height + titleSize.Height + subSize.Height + 8;
                int startY = (btn.Height - totalH) / 2;

                int iconX = (btn.Width - iconSize.Width) / 2;
                int titleX = (btn.Width - titleSize.Width) / 2;
                int subX = (btn.Width - subSize.Width) / 2;

                TextRenderer.DrawText(e.Graphics, spec.Icon, iconFont,
                    new Point(iconX, startY), Color.White);
                TextRenderer.DrawText(e.Graphics, spec.Title, titleFont,
                    new Point(titleX, startY + iconSize.Height + 2), Color.White);
                TextRenderer.DrawText(e.Graphics, spec.Subtitle, subFont,
                    new Point(subX, startY + iconSize.Height + titleSize.Height + 4), Color.White);
            }
        }

        private void Dashboard_Paint(object sender, PaintEventArgs e)
        {
            DrawShadow(e.Graphics, btnStudents);
            DrawShadow(e.Graphics, btnCourses);
            DrawShadow(e.Graphics, btnDepartments);
            DrawShadow(e.Graphics, btnModules);
            DrawShadow(e.Graphics, btnLecturers);
        }

        private void DrawShadow(Graphics g, Control c)
        {
            if (c == null) return;
            int shadowOffset = 4;
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(28, 0, 0, 0)))
            {
                Rectangle r = new Rectangle(c.Left + shadowOffset, c.Top + shadowOffset, c.Width, c.Height);
                g.FillRectangle(shadowBrush, r);
            }
        }

        private void TrySetBackgroundImage()
        {
            try
            {
                string localFile = ResolveLocalBackgroundPath("waves-bent-paper-cut-style.jpg");
                Image img;

                if (!string.IsNullOrEmpty(localFile) && File.Exists(localFile))
                {
                    img = Image.FromFile(localFile);
                }
                else
                {
                    string url = "https://cdn.pixabay.com/photo/2016/01/16/01/00/blue-1142745_1280.jpg";
                    using (WebClient client = new WebClient())
                    {
                        byte[] data = client.DownloadData(url);
                        using (MemoryStream ms = new MemoryStream(data))
                        {
                            img = Image.FromStream(ms);
                        }
                    }
                }

                if (bgPicture != null)
                {
                    bgPicture.Image = img;
                }
                else
                {
                    BackgroundImage = img;
                    BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            catch
            {
                // If download fails, keep the default background.
            }
        }

        private string ResolveLocalBackgroundPath(string fileName)
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string candidate1 = Path.GetFullPath(Path.Combine(baseDir, "..", "..", fileName));
                if (File.Exists(candidate1)) return candidate1;

                string candidate2 = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", fileName));
                if (File.Exists(candidate2)) return candidate2;

                string candidate3 = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, fileName));
                if (File.Exists(candidate3)) return candidate3;
            }
            catch
            {
                // Ignore path resolution errors
            }

            return null;
        }

        private class CardSpec
        {
            public string Icon { get; }
            public string Title { get; }
            public string Subtitle { get; }

            public CardSpec(string icon, string title, string subtitle)
            {
                Icon = icon;
                Title = title;
                Subtitle = subtitle;
            }
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            new StudentsForm().Show();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            new CoursesForm().Show();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            new DepartmentsForm().Show();
        }

        private void btnModules_Click(object sender, EventArgs e)
        {
            new ModulesForm().Show();
        }

        private void btnLecturers_Click(object sender, EventArgs e)
        {
            new LecturersForm().Show();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            // Already on Dashboard
        }

        private void btnNavStudents_Click(object sender, EventArgs e)
        {
            new StudentsForm().Show();
        }

        private void btnNavCourses_Click(object sender, EventArgs e)
        {
            new CoursesForm().Show();
        }

        private void btnNavDepartments_Click(object sender, EventArgs e)
        {
            new DepartmentsForm().Show();
        }

        private void btnNavModules_Click(object sender, EventArgs e)
        {
            new ModulesForm().Show();
        }

        private void btnNavLecturers_Click(object sender, EventArgs e)
        {
            new LecturersForm().Show();
        }
    }
}

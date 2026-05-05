// ============================================================
// COPYRIGHT NOTICE
// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba  |  Student No: 20232990
// © 2026 Nicolette Mashaba. All rights reserved.
// ============================================================

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CollegeLMS
{
    public partial class LoginForm : Form
    {
        private Panel     pnlMain;
        private Panel     pnlLoginCard;
        private Panel     pnlCardHeader;
        private Label     lblCardTitle;
        private Label     lblCardSubtitle;
        private Label     lblUsernameLabel;
        private Label     lblPasswordLabel;
        private TextBox   txtUsername;
        private TextBox   txtPassword;
        private Button    btnLogin;
        private Button    btnRegister;
        private Label     lblForgotPassword;
        private CheckBox  chkRememberMe;
        private Panel     pnlProgressBar;
        private Label     lblLoading;
        private PictureBox bgPicture;
        private Button    btnClose;
        private Panel     pnlSidebar;

        public LoginForm()
        {
            InitializeComponent();
            UiTheme.ApplyFormDefaults(this);
            DoubleBuffered = true;
            ResizeRedraw   = true;
            Paint         += LoginForm_Paint;
            SetupUI();
            LoadBackgroundImage();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            Text            = "College LMS — Login";
            Size            = new Size(1280, 800);
            StartPosition   = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            WindowState     = FormWindowState.Maximized;
            BackColor       = UiTheme.AppBackground;
            MouseDown      += LoginForm_MouseDown;
            Load           += LoginForm_Load;
            ResumeLayout(false);
        }

        private void SetupUI()
        {
            // ── Background image ─────────────────────────────────────────────
            bgPicture = new PictureBox
            {
                Dock      = DockStyle.Fill,
                SizeMode  = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            Controls.Add(bgPicture);
            bgPicture.SendToBack();

            // ── Main transparent overlay ─────────────────────────────────────
            pnlMain = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent };
            Controls.Add(pnlMain);

            // ── Close button ─────────────────────────────────────────────────
            btnClose = new Button
            {
                Size      = new Size(36, 36),
                Text      = "×",
                Font      = new Font("Segoe UI", 18, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand,
                Anchor    = AnchorStyles.Top | AnchorStyles.Right
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 220, 30, 30);
            btnClose.Click += (s, e) => Application.Exit();
            pnlMain.Controls.Add(btnClose);

            // ── Left sidebar — steel-blue, echoes triangle palette ────────────
            pnlSidebar = new Panel
            {
                Width     = 420,
                Dock      = DockStyle.Left,
                BackColor = Color.Transparent   // painted below
            };
            pnlSidebar.Paint += (s, e) => UiTheme.PaintSidebarPanel(pnlSidebar, e);
            pnlMain.Controls.Add(pnlSidebar);

            BuildSidebarContent();

            // ── Login card — white glass ──────────────────────────────────────
            pnlLoginCard = new Panel
            {
                Size      = new Size(460, 590),
                BackColor = Color.White
            };
            pnlLoginCard.Paint += PaintLoginCard;
            pnlMain.Controls.Add(pnlLoginCard);

            // Card header band
            pnlCardHeader = new Panel
            {
                Size      = new Size(460, 100),
                Dock      = DockStyle.Top,
                BackColor = Color.Transparent
            };
            pnlCardHeader.Paint += (s, e) => UiTheme.PaintCardHeaderPanel(pnlCardHeader, e);
            pnlLoginCard.Controls.Add(pnlCardHeader);

            lblCardTitle = new Label
            {
                Text      = "Welcome back",
                Font      = new Font("Segoe UI Semibold", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize  = false,
                Size      = new Size(380, 38),
                Location  = new Point(40, 22),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlCardHeader.Controls.Add(lblCardTitle);

            lblCardSubtitle = new Label
            {
                Text      = "Sign in to your learning portal",
                Font      = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = UiTheme.TextLightBlue,
                BackColor = Color.Transparent,
                AutoSize  = false,
                Size      = new Size(380, 22),
                Location  = new Point(40, 66),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlCardHeader.Controls.Add(lblCardSubtitle);

            // Field labels
            lblUsernameLabel = MakeFieldLabel("USERNAME", 40, 118);
            lblPasswordLabel = MakeFieldLabel("PASSWORD", 40, 186);
            pnlLoginCard.Controls.Add(lblUsernameLabel);
            pnlLoginCard.Controls.Add(lblPasswordLabel);

            // Username field
            txtUsername = new TextBox
            {
                Size        = new Size(378, 38),
                Font        = new Font("Segoe UI", 11F),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor   = UiTheme.ControlFill,
                ForeColor   = UiTheme.TextPrimary,
                Location    = new Point(40, 136),
                Text        = "Enter username"
            };
            txtUsername.GotFocus  += (s, e) => { if (txtUsername.Text == "Enter username") { txtUsername.Text = ""; txtUsername.ForeColor = UiTheme.TextPrimary; } txtUsername.BackColor = UiTheme.ControlFillFocus; };
            txtUsername.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtUsername.Text)) { txtUsername.Text = "Enter username"; txtUsername.ForeColor = Color.FromArgb(160, 175, 195); } txtUsername.BackColor = UiTheme.ControlFill; };
            txtUsername.ForeColor  = Color.FromArgb(160, 175, 195);
            pnlLoginCard.Controls.Add(txtUsername);

            // Password field
            txtPassword = new TextBox
            {
                Size                  = new Size(378, 38),
                Font                  = new Font("Segoe UI", 11F),
                BorderStyle           = BorderStyle.FixedSingle,
                BackColor             = UiTheme.ControlFill,
                ForeColor             = UiTheme.TextPrimary,
                Location              = new Point(40, 204),
                UseSystemPasswordChar = false,
                Text                  = "Enter password"
            };
            txtPassword.GotFocus  += (s, e) => { if (txtPassword.Text == "Enter password") { txtPassword.Text = ""; txtPassword.ForeColor = UiTheme.TextPrimary; txtPassword.UseSystemPasswordChar = true; } txtPassword.BackColor = UiTheme.ControlFillFocus; };
            txtPassword.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtPassword.Text)) { txtPassword.Text = "Enter password"; txtPassword.ForeColor = Color.FromArgb(160, 175, 195); txtPassword.UseSystemPasswordChar = false; } txtPassword.BackColor = UiTheme.ControlFill; };
            txtPassword.ForeColor  = Color.FromArgb(160, 175, 195);
            pnlLoginCard.Controls.Add(txtPassword);

            // Remember me + forgot password row
            chkRememberMe = new CheckBox
            {
                Text      = "Remember me",
                Font      = new Font("Segoe UI", 9.5F),
                ForeColor = UiTheme.TextSecondary,
                BackColor = Color.Transparent,
                AutoSize  = true,
                Location  = new Point(40, 262)
            };
            pnlLoginCard.Controls.Add(chkRememberMe);

            lblForgotPassword = new Label
            {
                Text      = "Forgot password?",
                Font      = new Font("Segoe UI", 9.5F),
                ForeColor = UiTheme.BtnBlue,
                BackColor = Color.Transparent,
                Cursor    = Cursors.Hand,
                AutoSize  = true,
                Location  = new Point(290, 264)
            };
            lblForgotPassword.Click      += (s, e) => MessageBox.Show("Password reset feature coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblForgotPassword.MouseEnter += (s, e) => lblForgotPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Underline);
            lblForgotPassword.MouseLeave += (s, e) => lblForgotPassword.Font = new Font("Segoe UI", 9.5F);
            pnlLoginCard.Controls.Add(lblForgotPassword);

            // Sign In button
            btnLogin = new Button
            {
                Size      = new Size(378, 50),
                Text      = "Sign In",
                Font      = new Font("Segoe UI Semibold", 13F, FontStyle.Bold),
                BackColor = UiTheme.BtnBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand,
                Location  = new Point(40, 306)
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            UiTheme.SetRoundedRegion(btnLogin, 10);
            UiTheme.WireButtonLift(btnLogin, 2, UiTheme.BtnBlueHov);
            btnLogin.Click += BtnLogin_Click;
            pnlLoginCard.Controls.Add(btnLogin);

            // Loading label
            lblLoading = new Label
            {
                Text      = "Authenticating...",
                Font      = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = UiTheme.TextSecondary,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize  = false,
                Size      = new Size(378, 24),
                Location  = new Point(40, 362),
                Visible   = false
            };
            pnlLoginCard.Controls.Add(lblLoading);

            // Progress bar
            pnlProgressBar = new Panel
            {
                Size      = new Size(0, 3),
                BackColor = UiTheme.SteelBlue,
                Location  = new Point(40, 390),
                Visible   = false
            };
            pnlLoginCard.Controls.Add(pnlProgressBar);

            // Divider line
            var divider = new Panel
            {
                Size      = new Size(378, 1),
                BackColor = UiTheme.BorderSoft,
                Location  = new Point(40, 410)
            };
            pnlLoginCard.Controls.Add(divider);

            // Create Account button
            btnRegister = new Button
            {
                Size      = new Size(378, 46),
                Text      = "Create New Account",
                Font      = new Font("Segoe UI Semibold", 11F),
                BackColor = Color.Transparent,
                ForeColor = UiTheme.BtnBlue,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand,
                Location  = new Point(40, 422)
            };
            btnRegister.FlatAppearance.BorderSize  = 1;
            btnRegister.FlatAppearance.BorderColor = UiTheme.BtnBlue;
            UiTheme.SetRoundedRegion(btnRegister, 10);
            btnRegister.MouseEnter += (s, e) => { btnRegister.BackColor = UiTheme.BtnBlue; btnRegister.ForeColor = Color.White; };
            btnRegister.MouseLeave += (s, e) => { btnRegister.BackColor = Color.Transparent; btnRegister.ForeColor = UiTheme.BtnBlue; };
            btnRegister.Click      += BtnRegister_Click;
            pnlLoginCard.Controls.Add(btnRegister);

            // Footer note inside card
            var lblNote = new Label
            {
                Text      = "Demo credentials: admin / admin",
                Font      = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                ForeColor = UiTheme.TextMuted,
                BackColor = Color.Transparent,
                AutoSize  = false,
                Size      = new Size(378, 20),
                Location  = new Point(40, 480),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlLoginCard.Controls.Add(lblNote);

            WireInputKeys();
        }

        // ── Sidebar content ───────────────────────────────────────────────────

        private void BuildSidebarContent()
        {
            // Logo circle
            var pnlLogo = new Panel
            {
                Size      = new Size(72, 72),
                BackColor = Color.Transparent,
                Location  = new Point(50, 90)
            };
            pnlLogo.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var r = new Rectangle(0, 0, 70, 70);
                using (var bg = new LinearGradientBrush(r, UiTheme.SteelBlueLight, UiTheme.NavyMid, LinearGradientMode.ForwardDiagonal))
                    g.FillEllipse(bg, r);
                using (var pen = new Pen(Color.FromArgb(120, Color.White), 2))
                    g.DrawEllipse(pen, 1, 1, 68, 68);
                // Book icon drawn with lines
                var bookR = new Rectangle(18, 16, 34, 38);
                using (var br = new SolidBrush(Color.White))
                {
                    g.FillRectangle(br, 20, 18, 30, 34);
                    using (var pb = new SolidBrush(UiTheme.NavyMid))
                        g.FillRectangle(pb, 20, 18, 4, 34);
                }
                using (var lp = new Pen(Color.FromArgb(200, UiTheme.NavyMid), 1))
                {
                    g.DrawLine(lp, 26, 25, 46, 25);
                    g.DrawLine(lp, 26, 30, 46, 30);
                    g.DrawLine(lp, 26, 35, 42, 35);
                    g.DrawLine(lp, 26, 40, 44, 40);
                }
                using (var op = new Pen(Color.FromArgb(100, Color.White), 1))
                    g.DrawRectangle(op, 20, 18, 30, 34);
            };
            pnlSidebar.Controls.Add(pnlLogo);

            MakeSidebarLabel("College LMS", new Font("Segoe UI Semibold", 28F, FontStyle.Bold), Color.White, new Point(50, 180), new Size(320, 46));
            MakeSidebarLabel("Learner Management System", new Font("Segoe UI", 12F), UiTheme.TextLightBlue, new Point(50, 232), new Size(320, 26));

            // Separator
            var sep = new Panel { Size = new Size(60, 3), Location = new Point(50, 272), BackColor = UiTheme.SteelBlueLight };
            pnlSidebar.Controls.Add(sep);

            MakeSidebarLabel(
                "Empowering education through\ninnovative technology. Access your\ncourses, track progress, and connect\nwith your learning community.",
                new Font("Segoe UI", 11F), Color.FromArgb(170, 210, 240),
                new Point(50, 292), new Size(310, 100));

            // Feature bullets
            string[] features = { "Student & Course Management", "Department & Module Tracking", "Lecturer Administration", "Export & Print Reports" };
            int fy = 420;
            foreach (var feat in features)
            {
                var bullet = new Panel { Size = new Size(8, 8), Location = new Point(50, fy + 5), BackColor = UiTheme.SteelBlueLight };
                UiTheme.SetRoundedRegion(bullet, 4);
                pnlSidebar.Controls.Add(bullet);
                MakeSidebarLabel(feat, new Font("Segoe UI", 10.5F), Color.FromArgb(200, 225, 245), new Point(70, fy), new Size(290, 24));
                fy += 34;
            }

            // Bottom credit
            MakeSidebarLabel("CTU Training Solutions  ©  2026", new Font("Segoe UI", 8.5F, FontStyle.Italic),
                Color.FromArgb(120, 160, 200), new Point(50, 580), new Size(310, 20));
        }

        private void MakeSidebarLabel(string text, Font font, Color color, Point location, Size size)
        {
            var lbl = new Label
            {
                Text      = text,
                Font      = font,
                ForeColor = color,
                BackColor = Color.Transparent,
                Location  = location,
                Size      = size,
                AutoSize  = false
            };
            pnlSidebar.Controls.Add(lbl);
        }

        private Label MakeFieldLabel(string text, int x, int y)
        {
            return new Label
            {
                Text      = text,
                Font      = new Font("Segoe UI Semibold", 8F, FontStyle.Bold),
                ForeColor = UiTheme.TextSecondary,
                BackColor = Color.Transparent,
                AutoSize  = false,
                Size      = new Size(378, 16),
                Location  = new Point(x, y)
            };
        }

        // ── Painters ─────────────────────────────────────────────────────────

        private void PaintLoginCard(object sender, PaintEventArgs e)
        {
            // White surface with very soft steel-blue left accent and bottom shadow line
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var b = new SolidBrush(Color.White))
                g.FillRectangle(b, pnlLoginCard.ClientRectangle);
            using (var pen = new Pen(UiTheme.BorderSoft, 1))
                g.DrawRectangle(pen, 0, 0, pnlLoginCard.Width - 1, pnlLoginCard.Height - 1);
        }

        // ── Login form shadow (on main form Paint) ────────────────────────────

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            if (pnlLoginCard == null) return;
            UiTheme.DrawSoftShadow(e.Graphics, pnlLoginCard.Bounds, 20, 22, 14, 55);
        }

        // ── Input helpers ─────────────────────────────────────────────────────

        private void WireInputKeys()
        {
            txtUsername.KeyPress += (s, e) => { if (e.KeyChar == (char)Keys.Enter) txtPassword.Focus(); };
            txtPassword.KeyPress += (s, e) => { if (e.KeyChar == (char)Keys.Enter) BtnLogin_Click(s, e); };
        }

        // ── Background image ──────────────────────────────────────────────────

        private void LoadBackgroundImage()
        {
            try
            {
                string path = ResolveImagePath("tp244-bg1-01.jpg");
                if (path != null && System.IO.File.Exists(path))
                {
                    bgPicture.Image    = Image.FromFile(path);
                    bgPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    bgPicture.SendToBack();
                }
                else
                {
                    bgPicture.BackColor = UiTheme.AppBackground;
                }
            }
            catch
            {
                bgPicture.BackColor = UiTheme.AppBackground;
            }
        }

        private string ResolveImagePath(string fileName)
        {
            try
            {
                string b = AppDomain.CurrentDomain.BaseDirectory;
                foreach (var dir in new[] { b, $"{b}..\\..\\", $"{b}..\\..\\..\\", Environment.CurrentDirectory })
                {
                    string p = System.IO.Path.GetFullPath(System.IO.Path.Combine(dir, fileName));
                    if (System.IO.File.Exists(p)) return p;
                }
            }
            catch { }
            return null;
        }

        // ── Layout ────────────────────────────────────────────────────────────

        private void PositionCard()
        {
            if (pnlLoginCard == null || pnlMain == null) return;

            // Centre horizontally in the area right of the sidebar, vertically centred
            int sidebarW  = pnlSidebar?.Width ?? 420;
            int rightArea = pnlMain.Width - sidebarW;
            int cardX     = sidebarW + (rightArea - pnlLoginCard.Width) / 2;
            int cardY     = (pnlMain.Height - pnlLoginCard.Height) / 2;
            pnlLoginCard.Location = new Point(Math.Max(sidebarW + 20, cardX), Math.Max(20, cardY));

            if (btnClose != null)
                btnClose.Location = new Point(pnlMain.Width - 46, 10);

            UiTheme.WireRoundedOnResize(pnlLoginCard, 16);
            UiTheme.SetRoundedRegion(pnlLoginCard, 16);

            // Input sizing
            UiTheme.SetRoundedRegion(txtUsername, 8);
            UiTheme.SetRoundedRegion(txtPassword, 8);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            PositionCard();
        }

        // ── Event handlers ────────────────────────────────────────────────────

        private void LoginForm_Load(object sender, EventArgs e)
        {
            PositionCard();
            txtUsername.Focus();
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || user == "Enter username" ||
                string.IsNullOrEmpty(pass) || pass == "Enter password")
            {
                MessageBox.Show("Please enter your username and password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Visible        = false;
            lblLoading.Visible      = true;
            pnlProgressBar.Visible  = true;
            pnlProgressBar.Width    = 0;

            // Animate progress bar
            var progressTimer = new System.Windows.Forms.Timer { Interval = 25 };
            progressTimer.Tick += (ts, te) =>
            {
                pnlProgressBar.Width += 10;
                if (pnlProgressBar.Width >= 378) progressTimer.Stop();
            };
            progressTimer.Start();

            var loginTimer = new System.Windows.Forms.Timer { Interval = 1500 };
            loginTimer.Tick += (ts, te) =>
            {
                loginTimer.Stop(); progressTimer.Stop();
                if (user.ToLower() == "admin" && pass == "admin")
                {
                    Hide();
                    var dash = new Dashboard();
                    dash.FormClosed += (fs, fa) => Application.Exit();
                    dash.Show();
                }
                else
                {
                    MessageBox.Show("Invalid credentials.\n\nDemo: username = admin, password = admin",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnLogin.Visible       = true;
                    lblLoading.Visible     = false;
                    pnlProgressBar.Visible = false;
                    pnlProgressBar.Width   = 0;
                }
            };
            loginTimer.Start();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            using (var reg = new RegistrationForm())
                reg.ShowDialog(this);
        }
    }

    internal static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}
// ============================================================
// COPYRIGHT NOTICE
// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba
// Student No:  20232990
// © 2026 Nicolette Mashaba. All rights reserved.
// ============================================================

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CollegeLMS
{
    public partial class RegistrationForm : Form
    {
        private Panel     pnlMain;
        private Panel     pnlSidebar;
        private Panel     pnlRegistrationCard;
        private Panel     pnlCardHeader;
        private Label     lblTitle;
        private Label     lblSubtitle;
        private TextBox   txtFirstName;
        private TextBox   txtLastName;
        private TextBox   txtEmail;
        private TextBox   txtUsername;
        private TextBox   txtPassword;
        private TextBox   txtConfirmPassword;
        private ComboBox  cmbRole;
        private Button    btnRegister;
        private Button    btnBackToLogin;
        private CheckBox  chkAcceptTerms;
        private PictureBox bgPicture;
        private Panel     pnlProgressBar;
        private Label     lblLoading;
        private Button    btnClose;

        public RegistrationForm()
        {
            InitializeComponent();
            UiTheme.ApplyFormDefaults(this);
            DoubleBuffered = true;
            ResizeRedraw   = true;
            Paint         += RegistrationForm_Paint;
            SetupUI();
            LoadBackgroundImage();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            Text            = "College LMS — Register";
            Size            = new Size(1280, 800);
            StartPosition   = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            WindowState     = FormWindowState.Maximized;
            BackColor       = UiTheme.AppBackground;
            MouseDown      += RegistrationForm_MouseDown;
            Load           += RegistrationForm_Load;
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

            // ── Close button (top-right, white) ──────────────────────────────
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
            btnClose.Click += (s, e) => Close();
            pnlMain.Controls.Add(btnClose);

            // ── Left sidebar — matches the Login form ────────────────────────
            pnlSidebar = new Panel
            {
                Width     = 420,
                Dock      = DockStyle.Left,
                BackColor = Color.Transparent
            };
            pnlSidebar.Paint += (s, e) => UiTheme.PaintSidebarPanel(pnlSidebar, e);
            pnlMain.Controls.Add(pnlSidebar);
            BuildSidebarContent();

            // ── Registration card — white glass ──────────────────────────────
            pnlRegistrationCard = new Panel
            {
                Size      = new Size(480, 680),
                BackColor = Color.White
            };
            pnlRegistrationCard.Paint += PaintCard;
            pnlMain.Controls.Add(pnlRegistrationCard);

            // Card header band — navy gradient, matches LoginForm
            pnlCardHeader = new Panel
            {
                Size      = new Size(480, 90),
                Dock      = DockStyle.Top,
                BackColor = Color.Transparent
            };
            pnlCardHeader.Paint += (s, e) => UiTheme.PaintCardHeaderPanel(pnlCardHeader, e);
            pnlRegistrationCard.Controls.Add(pnlCardHeader);

            lblTitle = new Label
            {
                Text      = "Create Account",
                Font      = new Font("Segoe UI Semibold", 20F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize  = false,
                Size      = new Size(400, 36),
                Location  = new Point(40, 18),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlCardHeader.Controls.Add(lblTitle);

            lblSubtitle = new Label
            {
                Text      = "Join our learning community",
                Font      = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = UiTheme.TextLightBlue,
                BackColor = Color.Transparent,
                AutoSize  = false,
                Size      = new Size(400, 20),
                Location  = new Point(40, 62),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlCardHeader.Controls.Add(lblSubtitle);

            // ── Fields ───────────────────────────────────────────────────────
            // Layout constants
            const int fl    = 40;   // field left margin
            const int fw    = 400;  // field width
            const int fh    = 34;   // field height
            const int lh    = 14;   // label height
            const int lgap  = 4;    // gap between label and field
            const int fgap  = 10;   // gap after each field group
            int y = 110;            // content starts after 90px header + 20px padding

            // First Name
            pnlRegistrationCard.Controls.Add(MakeFieldLabel("FIRST NAME", fl, y));
            txtFirstName = MakeTextField(fl, y + lh + lgap, fw, fh, "First name");
            pnlRegistrationCard.Controls.Add(txtFirstName);
            y += lh + lgap + fh + fgap;

            // Last Name
            pnlRegistrationCard.Controls.Add(MakeFieldLabel("LAST NAME", fl, y));
            txtLastName = MakeTextField(fl, y + lh + lgap, fw, fh, "Last name");
            pnlRegistrationCard.Controls.Add(txtLastName);
            y += lh + lgap + fh + fgap;

            // Email
            pnlRegistrationCard.Controls.Add(MakeFieldLabel("EMAIL ADDRESS", fl, y));
            txtEmail = MakeTextField(fl, y + lh + lgap, fw, fh, "Email address");
            pnlRegistrationCard.Controls.Add(txtEmail);
            y += lh + lgap + fh + fgap;

            // Username
            pnlRegistrationCard.Controls.Add(MakeFieldLabel("USERNAME", fl, y));
            txtUsername = MakeTextField(fl, y + lh + lgap, fw, fh, "Choose a username");
            pnlRegistrationCard.Controls.Add(txtUsername);
            y += lh + lgap + fh + fgap;

            // Password
            pnlRegistrationCard.Controls.Add(MakeFieldLabel("PASSWORD", fl, y));
            txtPassword = MakeTextField(fl, y + lh + lgap, fw, fh, "Create a password", isPassword: true);
            pnlRegistrationCard.Controls.Add(txtPassword);
            y += lh + lgap + fh + fgap;

            // Confirm Password
            pnlRegistrationCard.Controls.Add(MakeFieldLabel("CONFIRM PASSWORD", fl, y));
            txtConfirmPassword = MakeTextField(fl, y + lh + lgap, fw, fh, "Repeat your password", isPassword: true);
            pnlRegistrationCard.Controls.Add(txtConfirmPassword);
            y += lh + lgap + fh + fgap;

            // Role
            pnlRegistrationCard.Controls.Add(MakeFieldLabel("ROLE", fl, y));
            cmbRole = new ComboBox
            {
                Size          = new Size(fw, fh),
                Location      = new Point(fl, y + lh + lgap),
                Font          = UiTheme.FontBase,
                BackColor     = UiTheme.ControlFill,
                ForeColor     = UiTheme.TextPrimary,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle     = FlatStyle.Flat
            };
            cmbRole.Items.AddRange(new[] { "Student", "Lecturer", "Administrator" });
            cmbRole.SelectedIndex = 0;
            cmbRole.Enter += (s, e) => cmbRole.BackColor = UiTheme.ControlFillFocus;
            cmbRole.Leave += (s, e) => cmbRole.BackColor = UiTheme.ControlFill;
            UiTheme.SetRoundedRegion(cmbRole, 8);
            pnlRegistrationCard.Controls.Add(cmbRole);
            y += lh + lgap + fh + fgap;
            // y = 110 + 7×(14+4+34+10) = 110 + 7×62 = 544

            // Terms checkbox
            chkAcceptTerms = new CheckBox
            {
                Text      = "I accept the Terms of Service and Privacy Policy",
                Font      = UiTheme.FontBase,
                ForeColor = UiTheme.TextSecondary,
                BackColor = Color.Transparent,
                AutoSize  = true,
                Location  = new Point(fl, y)
            };
            pnlRegistrationCard.Controls.Add(chkAcceptTerms);
            y += 30; // y = 574

            // Divider
            pnlRegistrationCard.Controls.Add(new Panel
            {
                Size      = new Size(fw, 1),
                BackColor = UiTheme.BorderSoft,
                Location  = new Point(fl, y)
            });
            y += 10; // y = 584

            // Create Account button
            btnRegister = new Button
            {
                Size      = new Size(fw, 46),
                Text      = "Create Account",
                Font      = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                BackColor = UiTheme.BtnBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand,
                Location  = new Point(fl, y)
            };
            btnRegister.FlatAppearance.BorderSize = 0;
            UiTheme.SetRoundedRegion(btnRegister, 10);
            UiTheme.WireButtonLift(btnRegister, 2, UiTheme.BtnBlueHov);
            btnRegister.Click += BtnRegister_Click;
            pnlRegistrationCard.Controls.Add(btnRegister);

            // Loading label (overlaps button, hidden initially)
            lblLoading = new Label
            {
                Text      = "Creating your account...",
                Font      = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = UiTheme.TextSecondary,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize  = false,
                Size      = new Size(fw, 22),
                Location  = new Point(fl, y + 12),
                Visible   = false
            };
            pnlRegistrationCard.Controls.Add(lblLoading);

            // Progress bar (just below loading label, hidden initially)
            pnlProgressBar = new Panel
            {
                Size      = new Size(0, 3),
                BackColor = UiTheme.SteelBlue,
                Location  = new Point(fl, y + 36),
                Visible   = false
            };
            pnlRegistrationCard.Controls.Add(pnlProgressBar);
            y += 46 + 8; // y = 638

            // Back to Login button
            btnBackToLogin = new Button
            {
                Size      = new Size(fw, 42),
                Text      = "Back to Login",
                Font      = new Font("Segoe UI Semibold", 11F),
                BackColor = Color.Transparent,
                ForeColor = UiTheme.BtnBlue,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand,
                Location  = new Point(fl, y)   // y = 638, bottom = 680
            };
            btnBackToLogin.FlatAppearance.BorderSize  = 1;
            btnBackToLogin.FlatAppearance.BorderColor = UiTheme.BtnBlue;
            UiTheme.SetRoundedRegion(btnBackToLogin, 10);
            btnBackToLogin.MouseEnter += (s, e) => { btnBackToLogin.BackColor = UiTheme.BtnBlue;      btnBackToLogin.ForeColor = Color.White; };
            btnBackToLogin.MouseLeave += (s, e) => { btnBackToLogin.BackColor = Color.Transparent;    btnBackToLogin.ForeColor = UiTheme.BtnBlue; };
            btnBackToLogin.Click      += (s, e) => Close();
            pnlRegistrationCard.Controls.Add(btnBackToLogin);
        }

        // ── Sidebar ───────────────────────────────────────────────────────────

        private void BuildSidebarContent()
        {
            // Logo circle — same drawn-book style as the login form
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

            MakeSidebarLabel("College LMS", new Font("Segoe UI Semibold", 28F, FontStyle.Bold),
                Color.White, new Point(50, 180), new Size(320, 46));
            MakeSidebarLabel("Learner Management System",
                new Font("Segoe UI", 12F), UiTheme.TextLightBlue, new Point(50, 232), new Size(320, 26));

            // Separator
            var sep = new Panel { Size = new Size(60, 3), Location = new Point(50, 272), BackColor = UiTheme.SteelBlueLight };
            pnlSidebar.Controls.Add(sep);

            MakeSidebarLabel(
                "Create your account and join\nthousands of students and lecturers\nbuilding a smarter future through\ninnovative education technology.",
                new Font("Segoe UI", 11F), Color.FromArgb(170, 210, 240),
                new Point(50, 292), new Size(310, 100));

            // Steps
            (string icon, string step)[] steps =
            {
                ("1", "Fill in your personal details"),
                ("2", "Choose a secure password"),
                ("3", "Select your role"),
                ("4", "Accept terms & get started!")
            };
            int sy = 420;
            foreach (var (icon, step) in steps)
            {
                var badge = new Panel { Size = new Size(22, 22), Location = new Point(50, sy + 1), BackColor = UiTheme.SteelBlueLight };
                UiTheme.SetRoundedRegion(badge, 11);
                pnlSidebar.Controls.Add(badge);
                var num = new Label
                {
                    Text      = icon, Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                    ForeColor = UiTheme.NavyDeep, BackColor = Color.Transparent,
                    Size      = new Size(22, 22), Location = new Point(50, sy + 1),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlSidebar.Controls.Add(num);
                MakeSidebarLabel(step, new Font("Segoe UI", 10.5F), Color.FromArgb(200, 225, 245),
                    new Point(80, sy), new Size(290, 24));
                sy += 34;
            }

            MakeSidebarLabel("CTU Training Solutions  ©  2026",
                new Font("Segoe UI", 8.5F, FontStyle.Italic),
                Color.FromArgb(120, 160, 200), new Point(50, 580), new Size(310, 20));
        }

        private void MakeSidebarLabel(string text, Font font, Color color, Point location, Size size)
        {
            pnlSidebar.Controls.Add(new Label
            {
                Text      = text, Font = font, ForeColor = color, BackColor = Color.Transparent,
                Location  = location, Size = size, AutoSize = false
            });
        }

        // ── Field helpers ─────────────────────────────────────────────────────

        private Label MakeFieldLabel(string text, int x, int y)
        {
            return new Label
            {
                Text      = text,
                Font      = new Font("Segoe UI Semibold", 7.5F, FontStyle.Bold),
                ForeColor = UiTheme.TextSecondary,
                BackColor = Color.Transparent,
                AutoSize  = false,
                Size      = new Size(400, 14),
                Location  = new Point(x, y)
            };
        }

        private TextBox MakeTextField(int x, int y, int w, int h, string placeholder, bool isPassword = false)
        {
            var tb = new TextBox
            {
                Size        = new Size(w, h),
                Location    = new Point(x, y),
                Font        = new Font("Segoe UI", 10.5F),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor   = UiTheme.ControlFill,
                ForeColor   = UiTheme.TextMuted,
                Text        = placeholder,
                Tag         = placeholder   // signals placeholder state
            };
            tb.GotFocus += (s, e) =>
            {
                if ((string)tb.Tag == placeholder)
                {
                    tb.Text = ""; tb.ForeColor = UiTheme.TextPrimary; tb.Tag = null;
                    if (isPassword) tb.UseSystemPasswordChar = true;
                }
                tb.BackColor = UiTheme.ControlFillFocus;
            };
            tb.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = placeholder; tb.ForeColor = UiTheme.TextMuted; tb.Tag = placeholder;
                    if (isPassword) tb.UseSystemPasswordChar = false;
                }
                tb.BackColor = UiTheme.ControlFill;
            };
            UiTheme.SetRoundedRegion(tb, 8);
            return tb;
        }

        private string FieldValue(TextBox tb)
            => (tb.Tag != null) ? "" : tb.Text.Trim();

        // ── Painters ─────────────────────────────────────────────────────────

        private void PaintCard(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var b = new SolidBrush(Color.White))
                g.FillRectangle(b, pnlRegistrationCard.ClientRectangle);
            using (var pen = new Pen(UiTheme.BorderSoft, 1))
                g.DrawRectangle(pen, 0, 0, pnlRegistrationCard.Width - 1, pnlRegistrationCard.Height - 1);
        }

        private void RegistrationForm_Paint(object sender, PaintEventArgs e)
        {
            if (pnlRegistrationCard == null) return;
            UiTheme.DrawSoftShadow(e.Graphics, pnlRegistrationCard.Bounds, 20, 22, 14, 55);
        }

        // ── Layout ────────────────────────────────────────────────────────────

        private void PositionCard()
        {
            if (pnlRegistrationCard == null || pnlMain == null) return;
            int sidebarW  = pnlSidebar?.Width ?? 420;
            int rightArea = pnlMain.Width - sidebarW;
            int cardX     = sidebarW + (rightArea - pnlRegistrationCard.Width) / 2;
            int cardY     = (pnlMain.Height - pnlRegistrationCard.Height) / 2;
            pnlRegistrationCard.Location = new Point(Math.Max(sidebarW + 20, cardX), Math.Max(20, cardY));
            if (btnClose != null) btnClose.Location = new Point(pnlMain.Width - 46, 10);
            UiTheme.WireRoundedOnResize(pnlRegistrationCard, 16);
            UiTheme.SetRoundedRegion(pnlRegistrationCard, 16);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            PositionCard();
        }

        // ── Background image ──────────────────────────────────────────────────

        private void LoadBackgroundImage()
        {
            try
            {
                string b = AppDomain.CurrentDomain.BaseDirectory;
                foreach (var dir in new[] { b, $"{b}..\\..\\", $"{b}..\\..\\..\\", Environment.CurrentDirectory })
                {
                    string p = System.IO.Path.GetFullPath(System.IO.Path.Combine(dir, "tp244-bg1-01.jpg"));
                    if (!System.IO.File.Exists(p)) continue;
                    bgPicture.Image    = Image.FromFile(p);
                    bgPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    bgPicture.SendToBack();
                    return;
                }
                bgPicture.BackColor = UiTheme.AppBackground;
            }
            catch { bgPicture.BackColor = UiTheme.AppBackground; }
        }

        // ── Event handlers ────────────────────────────────────────────────────

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            PositionCard();
            txtFirstName.Focus();
        }

        private void RegistrationForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            btnRegister.Visible    = false;
            lblLoading.Visible     = true;
            pnlProgressBar.Visible = true;
            pnlProgressBar.Width   = 0;

            var progressTimer = new System.Windows.Forms.Timer { Interval = 20 };
            progressTimer.Tick += (ts, te) =>
            {
                pnlProgressBar.Width += 12;
                if (pnlProgressBar.Width >= 400) progressTimer.Stop();
            };
            progressTimer.Start();

            var loginTimer = new System.Windows.Forms.Timer { Interval = 1800 };
            loginTimer.Tick += (ts, te) =>
            {
                loginTimer.Stop(); progressTimer.Stop();
                string first = FieldValue(txtFirstName);
                MessageBox.Show($"Account created successfully!\n\nWelcome to College LMS, {first}!",
                    "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            };
            loginTimer.Start();
        }

        // ── Validation ────────────────────────────────────────────────────────

        private bool ValidateForm()
        {
            string firstName       = FieldValue(txtFirstName);
            string lastName        = FieldValue(txtLastName);
            string email           = FieldValue(txtEmail);
            string username        = FieldValue(txtUsername);
            string password        = FieldValue(txtPassword);
            string confirmPassword = FieldValue(txtConfirmPassword);

            if (string.IsNullOrWhiteSpace(firstName))
            { Show("Please enter your first name.", txtFirstName); return false; }
            if (string.IsNullOrWhiteSpace(lastName))
            { Show("Please enter your last name.", txtLastName); return false; }
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            { Show("Please enter a valid email address.", txtEmail); return false; }
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
            { Show("Username must be at least 3 characters.", txtUsername); return false; }
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            { Show("Password must be at least 6 characters.", txtPassword); return false; }
            if (password != confirmPassword)
            { Show("Passwords do not match.", txtConfirmPassword); return false; }
            if (!chkAcceptTerms.Checked)
            {
                MessageBox.Show("Please accept the Terms of Service and Privacy Policy.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkAcceptTerms.Focus(); return false;
            }
            return true;
        }

        private void Show(string message, Control focus)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus?.Focus();
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException) { return false; }
        }
    }
}

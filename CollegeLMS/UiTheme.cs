// ============================================================
// COPYRIGHT NOTICE
// ============================================================
// Project:     College Learner Management System (CollegeLMS)
// Author:      Nicolette Mashaba  |  Student No: 20232990
// © 2026 Nicolette Mashaba. All rights reserved.
// ============================================================
//
// UI THEME v4.0  "Crystal Blue · White & Steel"
// Palette extracted directly from tp244-bg1-01.jpg:
//   Background: near-white #F4F7FC
//   Triangles : steel-blue #7EB3D8 / #5B8DB8
//   Curves    : soft white-grey #E8EDF5
//   Headers   : deep navy #10284A → #1A4272
//   Accent    : steel-blue highlight
// Buttons: ORIGINAL vivid colours — green/teal/orange/red/slate/purple
// Grid  : completely rethought — seamless rows, clean hover

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace CollegeLMS
{
    internal static class UiTheme
    {
        // Brand colours — from the background image
        internal static readonly Color NavyDeep       = Color.FromArgb( 16,  40,  74);
        internal static readonly Color NavyMid        = Color.FromArgb( 26,  66, 114);
        internal static readonly Color NavyLight      = Color.FromArgb( 37,  99, 161);
        internal static readonly Color SteelBlue      = Color.FromArgb( 91, 141, 184);
        internal static readonly Color SteelBlueLight = Color.FromArgb(126, 179, 216);
        internal static readonly Color SteelBluePale  = Color.FromArgb(210, 230, 248);
        internal static readonly Color SteelBlueFaint = Color.FromArgb(235, 243, 252);

        // Surfaces
        internal static readonly Color Surface        = Color.White;
        internal static readonly Color AppBackground  = Color.FromArgb(244, 247, 252);

        // Text
        internal static readonly Color TextPrimary    = Color.FromArgb( 18,  38,  60);
        internal static readonly Color TextSecondary  = Color.FromArgb( 70,  95, 125);
        internal static readonly Color TextMuted      = Color.FromArgb(130, 155, 180);
        internal static readonly Color TextOnDark     = Color.White;
        internal static readonly Color TextLightBlue  = Color.FromArgb(195, 220, 245);

        // Inputs
        internal static readonly Color ControlFill      = Color.FromArgb(247, 251, 255);
        internal static readonly Color ControlFillFocus = Color.FromArgb(232, 244, 255);
        internal static readonly Color BorderSoft       = Color.FromArgb(200, 220, 240);

        // Grid
        internal static readonly Color GridHeaderBg   = NavyMid;
        internal static readonly Color GridHeaderFg   = Color.White;
        internal static readonly Color GridRowEven    = Color.White;
        internal static readonly Color GridRowOdd     = Color.FromArgb(245, 250, 255);
        internal static readonly Color GridHoverRow   = Color.FromArgb(210, 233, 252);
        internal static readonly Color GridSelectRow  = Color.FromArgb(185, 218, 248);
        internal static readonly Color GridLine       = Color.FromArgb(220, 234, 247);

        // ORIGINAL vivid button colours — exactly as before
        internal static readonly Color BtnBlue        = Color.FromArgb( 31,  84, 147);
        internal static readonly Color BtnBlueHov     = Color.FromArgb( 52, 120, 200);
        internal static readonly Color BtnGreen       = Color.FromArgb( 39, 174,  96);
        internal static readonly Color BtnGreenHov    = Color.FromArgb( 30, 140,  78);
        internal static readonly Color BtnTeal        = Color.FromArgb(  0, 128, 128);
        internal static readonly Color BtnTealHov     = Color.FromArgb(  0, 100, 100);
        internal static readonly Color BtnOrange      = Color.FromArgb(255, 140,   0);
        internal static readonly Color BtnOrangeHov   = Color.FromArgb(200, 110,   0);
        internal static readonly Color BtnRed         = Color.FromArgb(220,  53,  69);
        internal static readonly Color BtnRedHov      = Color.FromArgb(185,  28,  48);
        internal static readonly Color BtnSlate       = Color.FromArgb(112, 128, 144);
        internal static readonly Color BtnDarkSlate   = Color.FromArgb( 72,  61, 139);

        // Dashboard card colours
        internal static readonly Color CardStudents    = Color.FromArgb( 52, 152, 219);
        internal static readonly Color CardCourses     = Color.FromArgb( 39, 174,  96);
        internal static readonly Color CardDepartments = Color.FromArgb(230, 126,  34);
        internal static readonly Color CardModules     = Color.FromArgb(142,  68, 173);
        internal static readonly Color CardLecturers   = Color.FromArgb( 44,  62,  80);

        // Warm accent — used for nav indicator, footer lines, card header separator
        internal static readonly Color GoldAccent      = Color.FromArgb(228, 158, 28);
        internal static readonly Color GoldAccentLight = Color.FromArgb(255, 200, 75);
        // Bright royal blue — midtone for gradient drama
        internal static readonly Color RoyalBlue       = Color.FromArgb(26, 88, 180);

        internal static readonly Color NavActiveBar    = GoldAccent;

        // Typography
        internal static readonly Font FontBase            = new Font("Segoe UI", 9.5F);
        internal static readonly Font FontHeaderTitle     = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
        internal static readonly Font FontHeaderSubtitle  = new Font("Segoe UI", 10F, FontStyle.Italic);
        internal static readonly Font FontNav             = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        internal static readonly Font FontButton          = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        internal static readonly Font FontGridHeader      = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        internal static readonly Font FontGridCell        = new Font("Segoe UI", 9.5F);
        internal static readonly Font FontSectionTitle    = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
        internal static readonly Font FontBadge           = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        internal static readonly Font FontInputLabel      = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        internal static readonly Font FontCardTitle       = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
        internal static readonly Font FontCardSub         = new Font("Segoe UI", 9.5F);
        internal static readonly Font FontIconCard        = new Font("Segoe UI Emoji", 28F);

        // ── Form defaults ──────────────────────────────────────────────────────
        internal static void ApplyFormDefaults(Form form)
        {
            if (form == null) return;
            form.AutoScaleMode = AutoScaleMode.Dpi;
            form.Font          = FontBase;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.KeyPreview    = true;
            form.BackColor     = AppBackground;
        }

        internal static void InitializeLayout(Form form, Panel pnlTitle, Panel pnlNav, Panel pnlStatus)
        {
            if (form == null) return;
            form.Resize += (s, e) =>
            {
                if (pnlNav != null)
                    CenterControlsHorizontal(pnlNav,
                        pnlNav.Controls.Cast<Control>().Where(c => c is Button).ToArray(), 8);
                var t  = pnlTitle?.Controls.Find("lblTitle",    true).FirstOrDefault() as Label;
                var st = pnlTitle?.Controls.Find("lblSubTitle", true).FirstOrDefault() as Label;
                if (pnlTitle != null) ApplyHeader(pnlTitle, t, st);
            };
        }

        // ── Panel painters ─────────────────────────────────────────────────────
        internal static void PaintHeaderPanel(Panel panel, PaintEventArgs e)
        {
            if (panel == null) return;
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            // Deep navy → royal blue for visual drama
            using (var bg = new LinearGradientBrush(panel.ClientRectangle, NavyDeep, RoyalBlue, LinearGradientMode.Horizontal))
                g.FillRectangle(bg, panel.ClientRectangle);
            // Top sheen
            using (var shine = new LinearGradientBrush(new Rectangle(0, 0, panel.Width, Math.Max(1, panel.Height / 3)),
                Color.FromArgb(35, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), LinearGradientMode.Vertical))
                g.FillRectangle(shine, 0, 0, panel.Width, panel.Height / 3);
            // Gold accent bottom line
            using (var pen = new Pen(GoldAccent, 2))
                g.DrawLine(pen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
        }

        // Shared card-header painter used by Login and Registration forms
        internal static void PaintCardHeaderPanel(Panel panel, PaintEventArgs e)
        {
            if (panel == null) return;
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = panel.ClientRectangle;
            using (var bg = new LinearGradientBrush(rect, NavyDeep, RoyalBlue, LinearGradientMode.Horizontal))
                g.FillRectangle(bg, rect);
            using (var shine = new LinearGradientBrush(new Rectangle(0, 0, rect.Width, Math.Max(1, rect.Height / 2)),
                Color.FromArgb(28, 255, 255, 255), Color.FromArgb(0, 255, 255, 255), LinearGradientMode.Vertical))
                g.FillRectangle(shine, 0, 0, rect.Width, rect.Height / 2);
            using (var pen = new Pen(GoldAccent, 1.5f))
                g.DrawLine(pen, 0, rect.Height - 1, rect.Width, rect.Height - 1);
        }

        internal static void PaintNavPanel(Panel panel, PaintEventArgs e, Button activeBtn)
        {
            if (panel == null) return;
            var g = e.Graphics;
            using (var bg = new SolidBrush(NavyDeep))
                g.FillRectangle(bg, panel.ClientRectangle);
            // Subtle gold top line to tie into header
            using (var pen = new Pen(Color.FromArgb(55, GoldAccent), 1))
                g.DrawLine(pen, 0, 0, panel.Width, 0);
            using (var shadow = new LinearGradientBrush(new Rectangle(0, panel.Height - 4, panel.Width, 4),
                Color.FromArgb(40, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical))
                g.FillRectangle(shadow, 0, panel.Height - 4, panel.Width, 4);
            // Gold active-tab indicator
            if (activeBtn != null)
                using (var bar = new SolidBrush(GoldAccent))
                    g.FillRectangle(bar, activeBtn.Left, panel.Height - 3, activeBtn.Width, 3);
        }

        internal static void PaintFooterPanel(Panel panel, PaintEventArgs e)
        {
            if (panel == null) return;
            using (var bg = new LinearGradientBrush(panel.ClientRectangle, NavyMid, NavyDeep, LinearGradientMode.Vertical))
                e.Graphics.FillRectangle(bg, panel.ClientRectangle);
            // Gold top line echoes header accent
            using (var pen = new Pen(Color.FromArgb(90, GoldAccent), 1))
                e.Graphics.DrawLine(pen, 0, 0, panel.Width, 0);
        }

        internal static void PaintLeftPanel(Panel panel, PaintEventArgs e)
        {
            if (panel == null) return;
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var b = new SolidBrush(Surface))
                g.FillRectangle(b, panel.ClientRectangle);
            using (var stripe = new SolidBrush(Color.FromArgb(30, SteelBlue)))
                g.FillRectangle(stripe, 0, 0, 3, panel.Height);
            using (var shadow = new LinearGradientBrush(new Rectangle(panel.Width - 10, 0, 10, panel.Height),
                Color.FromArgb(0, 0, 0, 0), Color.FromArgb(14, 0, 0, 0), LinearGradientMode.Horizontal))
                g.FillRectangle(shadow, panel.Width - 10, 0, 10, panel.Height);
        }

        // Shared sidebar painter used by Login and Registration forms
        internal static void PaintSidebarPanel(Panel panel, PaintEventArgs e)
        {
            if (panel == null) return;
            var g    = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = panel.ClientRectangle;
            using (var bg = new LinearGradientBrush(rect, NavyDeep,
                Color.FromArgb(22, 62, 120), LinearGradientMode.ForwardDiagonal))
                g.FillRectangle(bg, rect);
            DrawSidebarTriangleDecor(g, rect);
            // Gold right-edge separator instead of plain steel blue
            using (var sep = new LinearGradientBrush(
                new Rectangle(rect.Width - 3, 0, 3, rect.Height),
                Color.FromArgb(0, GoldAccent), Color.FromArgb(80, GoldAccent),
                LinearGradientMode.Vertical))
                g.FillRectangle(sep, rect.Width - 3, 0, 3, rect.Height);
        }

        internal static void DrawSidebarTriangleDecor(Graphics g, Rectangle rect)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var tris = new[]
            {
                new[] { new Point(0,rect.Height-180), new Point(90,rect.Height-60),  new Point(0,rect.Height) },
                new[] { new Point(60,rect.Height-120), new Point(150,rect.Height),   new Point(0,rect.Height) },
                new[] { new Point(120,rect.Height-80), new Point(220,rect.Height),   new Point(80,rect.Height) },
                new[] { new Point(180,rect.Height-60), new Point(280,rect.Height),   new Point(140,rect.Height) },
            };
            int[] alphas = { 35, 25, 18, 12 };
            for (int i = 0; i < tris.Length; i++)
                using (var br = new SolidBrush(Color.FromArgb(alphas[i], SteelBlueLight)))
                    g.FillPolygon(br, tris[i]);
            var tris2 = new[]
            {
                new[] { new Point(rect.Width-120,0), new Point(rect.Width,0), new Point(rect.Width,100) },
                new[] { new Point(rect.Width-60,0),  new Point(rect.Width,0), new Point(rect.Width,50) },
            };
            foreach (var tri in tris2)
                using (var br = new SolidBrush(Color.FromArgb(20, SteelBlueLight)))
                    g.FillPolygon(br, tri);
        }

        // ── Header labels ──────────────────────────────────────────────────────
        internal static void ApplyHeader(Panel container, Label title, Label subtitle)
        {
            if (container == null) return;
            if (title != null)
            {
                title.Font = FontHeaderTitle; title.ForeColor = TextOnDark;
                title.BackColor = Color.Transparent; title.TextAlign = ContentAlignment.MiddleCenter;
                title.Left = (container.Width - title.Width) / 2;
                title.Top = title.Top > 0 ? title.Top : 14;
            }
            if (subtitle != null)
            {
                subtitle.Font = FontHeaderSubtitle; subtitle.ForeColor = TextLightBlue;
                subtitle.BackColor = Color.Transparent; subtitle.TextAlign = ContentAlignment.MiddleCenter;
                subtitle.Left = (container.Width - subtitle.Width) / 2;
                subtitle.Top = title != null ? title.Bottom + 4 : 44;
            }
        }

        internal static void ApplyStatusLabel(Label lbl)
        {
            if (lbl == null) return;
            lbl.AutoSize = false; lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.ForeColor = TextLightBlue; lbl.BackColor = Color.Transparent;
            lbl.Font = FontBase; lbl.Padding = new Padding(10, 0, 0, 0);
        }

        // ── Nav buttons ────────────────────────────────────────────────────────
        internal static void ApplyNavButton(Button b)
        {
            if (b == null) return;
            b.Font = FontNav; b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.ForeColor = Color.FromArgb(185, 218, 248); b.BackColor = Color.Transparent;
            b.Cursor = Cursors.Hand;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, SteelBlueLight);
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, SteelBlueLight);
        }

        internal static void ApplyNavStyle(params Button[] buttons) { foreach (var b in buttons) ApplyNavButton(b); }

        // ── Action buttons — ORIGINAL colours ─────────────────────────────────
        private static void BaseBtn(Button b)
        {
            if (b == null) return;
            b.Font = FontButton; b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0; b.ForeColor = Color.White;
            b.Cursor = Cursors.Hand; SetRoundedRegion(b, 8);
        }

        internal static void ApplyPrimaryButton(Button b)  { if (b==null) return; BaseBtn(b); b.BackColor=BtnBlue;      WireButtonLift(b,2,BtnBlueHov); }
        internal static void ApplySuccessButton(Button b)  { if (b==null) return; BaseBtn(b); b.BackColor=BtnGreen;     WireButtonLift(b,2,BtnGreenHov); }
        internal static void ApplyCyanButton(Button b)     { if (b==null) return; BaseBtn(b); b.BackColor=BtnTeal;      WireButtonLift(b,2,BtnTealHov); }
        internal static void ApplyAmberButton(Button b)    { if (b==null) return; BaseBtn(b); b.BackColor=BtnOrange;    WireButtonLift(b,2,BtnOrangeHov); }
        internal static void ApplyDangerButton(Button b)   { if (b==null) return; BaseBtn(b); b.BackColor=BtnRed;       WireButtonLift(b,2,BtnRedHov); }
        internal static void ApplyNeutralButton(Button b)  { if (b==null) return; BaseBtn(b); b.BackColor=BtnSlate;     WireButtonLift(b,1,Color.FromArgb(90,105,120)); }
        internal static void ApplyPurpleButton(Button b)   { if (b==null) return; BaseBtn(b); b.BackColor=BtnDarkSlate; WireButtonLift(b,2,Color.FromArgb(95,78,168)); }
        internal static void ApplyOutlineButton(Button b)
        {
            if (b==null) return;
            b.Font=FontButton; b.FlatStyle=FlatStyle.Flat;
            b.FlatAppearance.BorderSize=1; b.FlatAppearance.BorderColor=BtnBlue;
            b.BackColor=Color.Transparent; b.ForeColor=BtnBlue; b.Cursor=Cursors.Hand;
            SetRoundedRegion(b,8);
            b.MouseEnter+=(s,e)=>{b.BackColor=BtnBlue;b.ForeColor=Color.White;};
            b.MouseLeave+=(s,e)=>{b.BackColor=Color.Transparent;b.ForeColor=BtnBlue;};
        }
        internal static void ApplyActionButton(Button b) => ApplyPrimaryButton(b);
        internal static void ApplyActionStyle(params Button[] btns) { foreach(var b in btns) ApplyPrimaryButton(b); }

        // ── Inputs ─────────────────────────────────────────────────────────────
        internal static void ApplyModernInput(TextBox tb)
        {
            if (tb==null) return;
            tb.BorderStyle=BorderStyle.FixedSingle; tb.BackColor=ControlFill;
            tb.ForeColor=TextPrimary; tb.Font=FontBase;
            tb.Enter+=(s,e)=>tb.BackColor=ControlFillFocus;
            tb.Leave+=(s,e)=>tb.BackColor=ControlFill;
        }
        internal static void ApplyModernInput(ComboBox cb)
        {
            if (cb==null) return;
            cb.FlatStyle=FlatStyle.Flat; cb.BackColor=ControlFill;
            cb.ForeColor=TextPrimary; cb.Font=FontBase;
            cb.Enter+=(s,e)=>cb.BackColor=ControlFillFocus;
            cb.Leave+=(s,e)=>cb.BackColor=ControlFill;
        }

        // ── DataGridView — completely rethought ────────────────────────────────
        internal static void ApplyGridDefaults(DataGridView grid)
        {
            if (grid==null) return;
            grid.AllowUserToAddRows=false; grid.AllowUserToDeleteRows=false;
            grid.AllowUserToResizeRows=false; grid.MultiSelect=false;
            grid.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly=true;
            grid.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.None;
            grid.RowHeadersVisible=false;
            grid.BorderStyle=BorderStyle.None;
            grid.CellBorderStyle=DataGridViewCellBorderStyle.None;
            grid.BackgroundColor=Surface;
            grid.GridColor=GridLine;

            // Column headers
            grid.EnableHeadersVisualStyles=false;
            grid.ColumnHeadersDefaultCellStyle.BackColor=GridHeaderBg;
            grid.ColumnHeadersDefaultCellStyle.ForeColor=GridHeaderFg;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor=GridHeaderBg;
            grid.ColumnHeadersDefaultCellStyle.Font=FontGridHeader;
            grid.ColumnHeadersDefaultCellStyle.Padding=new Padding(10,0,10,0);
            grid.ColumnHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersDefaultCellStyle.WrapMode=DataGridViewTriState.False;
            grid.ColumnHeadersHeight=40;
            grid.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Rows
            grid.RowTemplate.Height=40;
            grid.DefaultCellStyle.Font=FontGridCell;
            grid.DefaultCellStyle.ForeColor=TextPrimary;
            grid.DefaultCellStyle.BackColor=GridRowEven;
            grid.DefaultCellStyle.SelectionBackColor=GridSelectRow;
            grid.DefaultCellStyle.SelectionForeColor=TextPrimary;
            grid.DefaultCellStyle.Padding=new Padding(10,0,10,0);
            grid.DefaultCellStyle.WrapMode=DataGridViewTriState.False;
            grid.AlternatingRowsDefaultCellStyle.BackColor=GridRowOdd;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor=GridSelectRow;

            // Custom cell painting for subtle row bottom border
            grid.CellPainting += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                e.PaintBackground(e.ClipBounds, true);
                e.PaintContent(e.ClipBounds);
                using (var pen = new Pen(Color.FromArgb(180, GridLine), 1))
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom-1, e.CellBounds.Right, e.CellBounds.Bottom-1);
                e.Handled = true;
            };
        }

        internal static void WireGridRowHover(DataGridView grid)
        {
            if (grid==null) return;
            grid.CellMouseEnter+=(s,e)=>{ if(e.RowIndex>=0){ grid.Rows[e.RowIndex].DefaultCellStyle.BackColor=GridHoverRow; grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor=TextPrimary; } };
            grid.CellMouseLeave+=(s,e)=>{ if(e.RowIndex>=0){ grid.Rows[e.RowIndex].DefaultCellStyle.BackColor=e.RowIndex%2==0?GridRowEven:GridRowOdd; grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor=TextPrimary; } };
        }

        // ── Badges ─────────────────────────────────────────────────────────────
        internal static Label MakeSectionLabel(string text, int x, int y, int width=360)
        {
            return new Label { Text=text.ToUpper(), Font=FontSectionTitle, ForeColor=TextMuted,
                BackColor=Color.Transparent, Location=new Point(x,y), Size=new Size(width,18), AutoSize=false };
        }

        internal static void ApplyBadgeStyle(Label lbl, Color? bg=null, Color? fg=null)
        {
            if (lbl==null) return;
            lbl.AutoSize=false; lbl.Font=FontBadge;
            lbl.BackColor=bg??SteelBluePale; lbl.ForeColor=fg??NavyMid;
            lbl.TextAlign=ContentAlignment.MiddleCenter;
            lbl.Padding=new Padding(8,0,8,0); SetRoundedRegion(lbl,10);
        }

        // ── Card surface ───────────────────────────────────────────────────────
        internal static void ApplyCardSurface(Control control, int radius=0)
        {
            if (control==null) return;
            control.BackColor=Surface;
            if (radius>0) { SetRoundedRegion(control,radius); WireRoundedOnResize(control,radius); }
        }

        // ── Dashboard card paint ───────────────────────────────────────────────
        internal static void PaintDashboardCard(Button btn, string icon, string title, string subtitle, PaintEventArgs e)
        {
            if (btn==null) return;
            var g=e.Graphics;
            g.TextRenderingHint=TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode=SmoothingMode.AntiAlias;
            g.PixelOffsetMode=PixelOffsetMode.HighQuality;
            var rect=new Rectangle(0,0,btn.Width-1,btn.Height-1);
            if (rect.Width<=4||rect.Height<=4) return;
            int radius=16;
            using (var path=CreateRoundedRectPath(rect,radius))
            {
                using (var bg=new LinearGradientBrush(rect,ControlPaint.Light(btn.BackColor,.18f),ControlPaint.Dark(btn.BackColor,.10f),LinearGradientMode.Vertical)) g.FillPath(bg,path);
                var sr=new Rectangle(0,0,rect.Width,rect.Height/2);
                using (var sheen=new LinearGradientBrush(sr,Color.FromArgb(80,255,255,255),Color.FromArgb(0,255,255,255),LinearGradientMode.Vertical)) g.FillPath(sheen,path);
                using (var border=new Pen(Color.FromArgb(90,255,255,255),1)) g.DrawPath(border,path);
                if(btn.Focused) using(var f=new Pen(Color.FromArgb(180,255,255,255),2)) g.DrawPath(f,path);
            }
            var titleF=new Font("Segoe UI Semibold",14F,FontStyle.Bold);
            var subF=new Font("Segoe UI",9.5F);
            var isz=TextRenderer.MeasureText(icon,FontIconCard);
            var tsz=TextRenderer.MeasureText(title,titleF);
            var ssz=TextRenderer.MeasureText(subtitle,subF);
            int totalH=isz.Height+tsz.Height+ssz.Height+10;
            int sy=(btn.Height-totalH)/2;
            TextRenderer.DrawText(g,icon,FontIconCard,new Point((btn.Width-isz.Width)/2+1,sy+1),Color.FromArgb(30,0,0,0));
            TextRenderer.DrawText(g,icon,FontIconCard,new Point((btn.Width-isz.Width)/2,sy),Color.White);
            TextRenderer.DrawText(g,title,titleF,new Point((btn.Width-tsz.Width)/2+1,sy+isz.Height+3),Color.FromArgb(30,0,0,0));
            TextRenderer.DrawText(g,title,titleF,new Point((btn.Width-tsz.Width)/2,sy+isz.Height+2),Color.White);
            TextRenderer.DrawText(g,subtitle,subF,new Point((btn.Width-ssz.Width)/2,sy+isz.Height+tsz.Height+8),Color.FromArgb(215,235,255));
            titleF.Dispose(); subF.Dispose();
        }

        // ── Layout ─────────────────────────────────────────────────────────────
        internal static void CenterControlsHorizontal(Control container, Control[] controls, int gap)
        {
            if (container==null||controls.Length==0) return;
            int total=controls.Sum(c=>c.Width)+gap*(controls.Length-1);
            int startX=Math.Max(10,(container.Width-total)/2);
            int x=startX;
            foreach(var c in controls.OrderBy(c=>c.TabIndex)) { c.Location=new Point(x,(container.Height-c.Height)/2); x+=c.Width+gap; }
        }

        // ── Drawing utilities ──────────────────────────────────────────────────
        internal static GraphicsPath CreateRoundedRectPath(Rectangle bounds, int radius)
        {
            var path=new GraphicsPath();
            if(radius<=0){path.AddRectangle(bounds);path.CloseFigure();return path;}
            int d=radius*2; var arc=new Rectangle(bounds.Location,new Size(d,d));
            path.AddArc(arc,180,90); arc.X=bounds.Right-d; path.AddArc(arc,270,90);
            arc.Y=bounds.Bottom-d; path.AddArc(arc,0,90); arc.X=bounds.Left; path.AddArc(arc,90,90);
            path.CloseFigure(); return path;
        }

        internal static void SetRoundedRegion(Control control, int radius)
        {
            if(control==null) return;
            var r=new Rectangle(0,0,control.Width,control.Height);
            if(r.Width<=2||r.Height<=2) return;
            using(var path=CreateRoundedRectPath(r,radius)) control.Region=new Region(path);
        }

        internal static void WireRoundedOnResize(Control control, int radius)
        {
            if(control==null) return;
            control.Resize+=(s,e)=>SetRoundedRegion(control,radius);
            SetRoundedRegion(control,radius);
        }

        internal static void DrawSoftShadow(Graphics g, Rectangle cardBounds, int radius,
            int elevation=14, int yOffset=8, int maxAlpha=55)
        {
            if(g==null||cardBounds.Width<=0||cardBounds.Height<=0) return;
            g.SmoothingMode=SmoothingMode.AntiAlias; g.PixelOffsetMode=PixelOffsetMode.HighQuality;
            var b2=cardBounds; b2.Offset(0,yOffset);
            int steps=Math.Max(6,Math.Min(22,elevation));
            for(int i=0;i<steps;i++) {
                float t=i/(float)steps; int alpha=(int)(maxAlpha*(1f-t)*(1f-t));
                var r=b2; r.Inflate(2+i,2+i);
                using(var path=CreateRoundedRectPath(r,radius+2+i))
                using(var brush=new SolidBrush(Color.FromArgb(alpha,0,10,30)))
                    g.FillPath(brush,path);
            }
        }

        internal static void DrawFrostedTray(Graphics g, Rectangle bounds, int radius=22)
        {
            if(g==null||bounds.Width<=0||bounds.Height<=0) return;
            g.SmoothingMode=SmoothingMode.AntiAlias;
            using(var path=CreateRoundedRectPath(bounds,radius))
            using(var fill=new SolidBrush(Color.FromArgb(200,248,252,255)))
            using(var border=new Pen(Color.FromArgb(130,SteelBluePale),1))
            using(var sheen=new LinearGradientBrush(new Rectangle(bounds.X,bounds.Y,bounds.Width,Math.Max(1,bounds.Height/2)),
                Color.FromArgb(75,255,255,255),Color.FromArgb(0,255,255,255),LinearGradientMode.Vertical))
            { g.FillPath(fill,path); g.FillPath(sheen,path); g.DrawPath(border,path); }
        }

        internal static void WireButtonLift(Button b, int upPixels=2, Color? hoverColor=null)
        {
            if(b==null) return;
            Point home=b.Location; bool up=false; Color homeC=b.BackColor;
            b.MouseEnter+=(s,e)=>{ if(!up){home=b.Location;b.Location=new Point(home.X,home.Y-upPixels);up=true;} if(hoverColor.HasValue)b.BackColor=hoverColor.Value; };
            b.MouseLeave+=(s,e)=>{ if(up){b.Location=home;up=false;} b.BackColor=homeC; };
            b.MouseDown+=(s,e)=>{ if(e.Button==MouseButtons.Left&&up)b.Location=new Point(home.X,home.Y-Math.Max(0,upPixels-1)); };
            b.MouseUp+=(s,e)=>{ if(up)b.Location=new Point(home.X,home.Y-upPixels); };
        }

        internal static void WireCommonShortcuts(Form form, Func<Control> findSearchBox=null, Action triggerSearch=null)
        {
            if(form==null) return;
            form.KeyDown+=(s,e)=>{
                if(e.Control&&e.KeyCode==Keys.F){var b=findSearchBox?.Invoke();if(b!=null){b.Focus();if(b is TextBox tb)tb.SelectAll();e.SuppressKeyPress=true;}}
                if(e.KeyCode==Keys.F5){triggerSearch?.Invoke();e.SuppressKeyPress=true;}
                if(e.KeyCode==Keys.Escape&&form.ActiveControl is TextBox at){at.Clear();e.SuppressKeyPress=true;}
            };
        }
    }
}
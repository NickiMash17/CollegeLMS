namespace CollegeLMS
{
    partial class Form1
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
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblCourseID = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();

            // ── Title Panel ──
            this.pnlTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Size = new System.Drawing.Size(1050, 70);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Controls.Add(this.lblTitle);

            // ── Title Label ──
            this.lblTitle.Text = "Student APP";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(380, 15);
            this.lblTitle.Size = new System.Drawing.Size(300, 45);
            this.lblTitle.Name = "lblTitle";

            // ── Labels ──
            this.lblStudentID.Text = "Student ID";
            this.lblStudentID.Location = new System.Drawing.Point(40, 110);
            this.lblStudentID.Size = new System.Drawing.Size(100, 22);
            this.lblStudentID.Font = new System.Drawing.Font("Arial", 10);
            this.lblStudentID.Name = "lblStudentID";

            this.lblFirstName.Text = "First Name";
            this.lblFirstName.Location = new System.Drawing.Point(40, 155);
            this.lblFirstName.Size = new System.Drawing.Size(100, 22);
            this.lblFirstName.Font = new System.Drawing.Font("Arial", 10);
            this.lblFirstName.Name = "lblFirstName";

            this.lblLastName.Text = "Last Name";
            this.lblLastName.Location = new System.Drawing.Point(40, 200);
            this.lblLastName.Size = new System.Drawing.Size(100, 22);
            this.lblLastName.Font = new System.Drawing.Font("Arial", 10);
            this.lblLastName.Name = "lblLastName";

            this.lblAge.Text = "Age";
            this.lblAge.Location = new System.Drawing.Point(40, 245);
            this.lblAge.Size = new System.Drawing.Size(100, 22);
            this.lblAge.Font = new System.Drawing.Font("Arial", 10);
            this.lblAge.Name = "lblAge";

            this.lblCourseID.Text = "Course Name";
            this.lblCourseID.Location = new System.Drawing.Point(40, 290);
            this.lblCourseID.Size = new System.Drawing.Size(110, 22);
            this.lblCourseID.Font = new System.Drawing.Font("Arial", 10);
            this.lblCourseID.Name = "lblCourseID";

            // ── TextBoxes ──
            this.txtStudentID.Location = new System.Drawing.Point(160, 108);
            this.txtStudentID.Size = new System.Drawing.Size(220, 26);
            this.txtStudentID.Font = new System.Drawing.Font("Arial", 10);
            this.txtStudentID.Name = "txtStudentID";

            this.txtFirstName.Location = new System.Drawing.Point(160, 153);
            this.txtFirstName.Size = new System.Drawing.Size(220, 26);
            this.txtFirstName.Font = new System.Drawing.Font("Arial", 10);
            this.txtFirstName.Name = "txtFirstName";

            this.txtLastName.Location = new System.Drawing.Point(160, 198);
            this.txtLastName.Size = new System.Drawing.Size(220, 26);
            this.txtLastName.Font = new System.Drawing.Font("Arial", 10);
            this.txtLastName.Name = "txtLastName";

            this.txtAge.Location = new System.Drawing.Point(160, 243);
            this.txtAge.Size = new System.Drawing.Size(220, 26);
            this.txtAge.Font = new System.Drawing.Font("Arial", 10);
            this.txtAge.Name = "txtAge";

            this.txtCourseID.Location = new System.Drawing.Point(160, 288);
            this.txtCourseID.Size = new System.Drawing.Size(220, 26);
            this.txtCourseID.Font = new System.Drawing.Font("Arial", 10);
            this.txtCourseID.Name = "txtCourseID";

            // ── Buttons ──
            this.btnView.Location = new System.Drawing.Point(40, 340);
            this.btnView.Size = new System.Drawing.Size(90, 40);
            this.btnView.Text = "View";
            this.btnView.Name = "btnView";
            this.btnView.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.btnView.BackColor = System.Drawing.Color.SteelBlue;
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);

            this.btnAdd.Location = new System.Drawing.Point(140, 340);
            this.btnAdd.Size = new System.Drawing.Size(90, 40);
            this.btnAdd.Text = "Add";
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(240, 340);
            this.btnUpdate.Size = new System.Drawing.Size(90, 40);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(340, 340);
            this.btnDelete.Size = new System.Drawing.Size(90, 40);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ── DataGridView ──
            this.dataGridView1.Location = new System.Drawing.Point(500, 90);
            this.dataGridView1.Size = new System.Drawing.Size(520, 300);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // ── Form ──
            this.ClientSize = new System.Drawing.Size(1050, 430);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Text = "Student Application Form";
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblCourseID);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtCourseID);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);

            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtCourseID;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblCourseID;
        private System.Windows.Forms.Panel pnlTitle;
    }
}
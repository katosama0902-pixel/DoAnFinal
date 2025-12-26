namespace DoAnFinal.GUI
{
    partial class FrmStaffAddEdit
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // Header
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Size = new System.Drawing.Size(400, 60);
            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "THÔNG TIN NHÂN VIÊN";
            // Username
            this.label1.Location = new System.Drawing.Point(30, 80); this.label1.Text = "Username:";
            this.label1.AutoSize = true;
            this.txtUsername.Location = new System.Drawing.Point(33, 100); this.txtUsername.Size = new System.Drawing.Size(320, 22);
            // Password
            this.label2.Location = new System.Drawing.Point(30, 140); this.label2.Text = "Password (Để trống nếu không đổi):";
            this.label2.AutoSize = true;
            this.txtPassword.Location = new System.Drawing.Point(33, 160); this.txtPassword.Size = new System.Drawing.Size(320, 22);
            this.txtPassword.PasswordChar = '*';
            // Email
            this.label3.Location = new System.Drawing.Point(30, 200); this.label3.Text = "Email:";
            this.label3.AutoSize = true;
            this.txtEmail.Location = new System.Drawing.Point(33, 220); this.txtEmail.Size = new System.Drawing.Size(320, 22);
            // Role
            this.label4.Location = new System.Drawing.Point(30, 260); this.label4.Text = "Vai trò:";
            this.label4.AutoSize = true;
            this.cboRole.Location = new System.Drawing.Point(33, 280); this.cboRole.Size = new System.Drawing.Size(320, 24);
            this.cboRole.Items.AddRange(new object[] { "Staff", "Admin" });
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // Status
            this.label5.Location = new System.Drawing.Point(30, 320); this.label5.Text = "Trạng thái:";
            this.label5.AutoSize = true;
            this.cboStatus.Location = new System.Drawing.Point(33, 340); this.cboStatus.Size = new System.Drawing.Size(320, 24);
            this.cboStatus.Items.AddRange(new object[] { "Active", "Locked" });
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // Buttons
            this.btnSave.Text = "LƯU";
            this.btnSave.Location = new System.Drawing.Point(140, 400); this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen; this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "HỦY";
            this.btnCancel.Location = new System.Drawing.Point(250, 400); this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick; this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1); this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2); this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3); this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4); this.Controls.Add(this.cboRole);
            this.Controls.Add(this.label5); this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.btnSave); this.Controls.Add(this.btnCancel);

            this.ClientSize = new System.Drawing.Size(400, 470);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false); this.panel1.PerformLayout(); this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1; private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2; private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3; private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4; private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label label5; private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnSave; private System.Windows.Forms.Button btnCancel;
    }
}
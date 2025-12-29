namespace DoAnFinal.GUI
{
    partial class FrmRecovery
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelStep1 = new System.Windows.Forms.Panel();
            this.btnSendOTP = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelStep2 = new System.Windows.Forms.Panel();
            this.btnVerify = new System.Windows.Forms.Button();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelStep3 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelStep1.SuspendLayout();
            this.panelStep2.SuspendLayout();
            this.panelStep3.SuspendLayout();
            this.SuspendLayout();

            // Title
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Size = new System.Drawing.Size(400, 60);
            this.lblTitle.Text = "KHÔI PHỤC MẬT KHẨU";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // STEP 1: Nhập Email
            this.panelStep1.Controls.Add(this.btnSendOTP);
            this.panelStep1.Controls.Add(this.txtEmail);
            this.panelStep1.Controls.Add(this.label1);
            this.panelStep1.Location = new System.Drawing.Point(20, 70);
            this.panelStep1.Size = new System.Drawing.Size(360, 100);

            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(10, 10); this.label1.Text = "Nhập Email đã đăng ký:";
            this.txtEmail.Location = new System.Drawing.Point(10, 30); this.txtEmail.Size = new System.Drawing.Size(230, 22);
            this.btnSendOTP.Text = "Gửi OTP"; this.btnSendOTP.Location = new System.Drawing.Point(250, 28);
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);

            // STEP 2: Nhập OTP (Ẩn lúc đầu)
            this.panelStep2.Controls.Add(this.btnVerify);
            this.panelStep2.Controls.Add(this.txtOTP);
            this.panelStep2.Controls.Add(this.label2);
            this.panelStep2.Location = new System.Drawing.Point(20, 180);
            this.panelStep2.Size = new System.Drawing.Size(360, 100);
            this.panelStep2.Visible = false;

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(10, 10); this.label2.Text = "Nhập mã OTP (6 số):";
            this.txtOTP.Location = new System.Drawing.Point(10, 30); this.txtOTP.Size = new System.Drawing.Size(230, 22);
            this.btnVerify.Text = "Xác thực"; this.btnVerify.Location = new System.Drawing.Point(250, 28);
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);

            // STEP 3: Đổi Pass (Ẩn lúc đầu)
            this.panelStep3.Controls.Add(this.btnSave);
            this.panelStep3.Controls.Add(this.txtNewPass);
            this.panelStep3.Controls.Add(this.label3);
            this.panelStep3.Location = new System.Drawing.Point(20, 290);
            this.panelStep3.Size = new System.Drawing.Size(360, 100);
            this.panelStep3.Visible = false;

            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(10, 10); this.label3.Text = "Nhập mật khẩu mới:";
            this.txtNewPass.Location = new System.Drawing.Point(10, 30); this.txtNewPass.Size = new System.Drawing.Size(230, 22);
            this.txtNewPass.PasswordChar = '*';
            this.btnSave.Text = "ĐỔI PASS"; this.btnSave.Location = new System.Drawing.Point(250, 28);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.panelStep3);
            this.Controls.Add(this.panelStep2);
            this.Controls.Add(this.panelStep1);
            this.Controls.Add(this.lblTitle);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelStep1.ResumeLayout(false); this.panelStep1.PerformLayout();
            this.panelStep2.ResumeLayout(false); this.panelStep2.PerformLayout();
            this.panelStep3.ResumeLayout(false); this.panelStep3.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStep1; private System.Windows.Forms.Button btnSendOTP; private System.Windows.Forms.TextBox txtEmail; private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelStep2; private System.Windows.Forms.Button btnVerify; private System.Windows.Forms.TextBox txtOTP; private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelStep3; private System.Windows.Forms.Button btnSave; private System.Windows.Forms.TextBox txtNewPass; private System.Windows.Forms.Label label3;
    }
}
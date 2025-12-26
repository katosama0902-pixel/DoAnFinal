namespace DoAnFinal.GUI
{
    partial class FrmChangePassword
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // Header
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Size = new System.Drawing.Size(400, 60);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "ĐỔI MẬT KHẨU";

            // Old Pass
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(30, 80); this.label1.Text = "Mật khẩu cũ:";
            this.txtOldPass.Location = new System.Drawing.Point(33, 100); this.txtOldPass.Size = new System.Drawing.Size(320, 22);
            this.txtOldPass.PasswordChar = '*';

            // New Pass
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(30, 140); this.label2.Text = "Mật khẩu mới:";
            this.txtNewPass.Location = new System.Drawing.Point(33, 160); this.txtNewPass.Size = new System.Drawing.Size(320, 22);
            this.txtNewPass.PasswordChar = '*';

            // Confirm Pass
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(30, 200); this.label3.Text = "Nhập lại mật khẩu mới:";
            this.txtConfirmPass.Location = new System.Drawing.Point(33, 220); this.txtConfirmPass.Size = new System.Drawing.Size(320, 22);
            this.txtConfirmPass.PasswordChar = '*';

            // Buttons
            this.btnSave.Text = "LƯU"; this.btnSave.Location = new System.Drawing.Point(140, 280); this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen; this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "HỦY"; this.btnCancel.Location = new System.Drawing.Point(250, 280); this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick; this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1); this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.label2); this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.label3); this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.btnSave); this.Controls.Add(this.btnCancel);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false); this.panel1.PerformLayout();
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.Label label1; private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label label2; private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label3; private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Button btnSave; private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1; private System.Windows.Forms.Label lblTitle;
    }
}
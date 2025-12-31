namespace DoAnFinal.GUI.CustomerArea
{
    partial class FrmCustomerBooking
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblMovieName = new System.Windows.Forms.Label();
            this.flowSeatPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblScreen = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.btnFood = new System.Windows.Forms.Button(); // [MỚI] Khai báo nút Food
            this.lblSeatInfo = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();

            // 1. Tên Phim & Màn hình
            this.lblMovieName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMovieName.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.lblMovieName.ForeColor = System.Drawing.Color.Gold;
            this.lblMovieName.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblMovieName.Height = 60;
            this.lblMovieName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMovieName.Text = "TÊN PHIM...";

            this.lblScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblScreen.BackColor = System.Drawing.Color.Gray;
            this.lblScreen.ForeColor = System.Drawing.Color.White;
            this.lblScreen.Height = 30;
            this.lblScreen.Text = "MÀN HÌNH";
            this.lblScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 2. Sơ đồ ghế
            this.flowSeatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSeatPanel.AutoScroll = true;
            this.flowSeatPanel.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.flowSeatPanel.Padding = new System.Windows.Forms.Padding(50, 20, 0, 0);

            // 3. Panel Thông tin & Thanh toán
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 100;
            this.panelBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBottom.Controls.Add(this.btnConfirm);
            this.panelBottom.Controls.Add(this.panelInfo);

            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInfo.Width = 600; // Tăng độ rộng để chứa thêm nút Food
            this.panelInfo.Controls.Add(this.btnFood); // Add nút Food
            this.panelInfo.Controls.Add(this.lblTotalPrice);
            this.panelInfo.Controls.Add(this.lblSeatInfo);

            this.lblSeatInfo.AutoSize = true;
            this.lblSeatInfo.Location = new System.Drawing.Point(20, 15);
            this.lblSeatInfo.Font = new System.Drawing.Font("Arial", 11F);
            this.lblSeatInfo.Text = "Ghế chọn: ...";

            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(20, 55);
            this.lblTotalPrice.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.lblTotalPrice.Text = "Tổng tiền: 0 đ";

            // [MỚI] btnFood (Nút chọn Combo)
            this.btnFood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0))))); // Màu cam
            this.btnFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFood.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnFood.ForeColor = System.Drawing.Color.White;
            this.btnFood.Location = new System.Drawing.Point(350, 25); // Nằm bên phải giá tiền
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(200, 50);
            this.btnFood.Text = "🍿 CHỌN COMBO";
            this.btnFood.UseVisualStyleBackColor = false;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);

            // btnConfirm
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirm.Width = 200;
            this.btnConfirm.BackColor = System.Drawing.Color.Firebrick;
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Text = "THANH TOÁN";
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            // Form Config
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.flowSeatPanel);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.lblMovieName);
            this.Controls.Add(this.panelBottom);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt vé Online";
            this.panelBottom.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.FlowLayoutPanel flowSeatPanel;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblSeatInfo;
        private System.Windows.Forms.Button btnFood; // Nút mới
    }
}
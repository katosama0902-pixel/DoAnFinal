namespace DoAnFinal.GUI
{
    partial class FrmFood
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblTotalFood = new System.Windows.Forms.Label();
            this.lblGift = new System.Windows.Forms.Label(); // [MỚI] Khai báo nhãn Quà tặng
            this.dgvFood = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFood)).BeginInit();
            this.SuspendLayout();

            // Header
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(600, 60);

            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Text = "CHỌN COMBO BẮP NƯỚC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Bottom
            this.panelBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBottom.Controls.Add(this.lblGift); // [MỚI] Thêm nhãn vào Panel
            this.panelBottom.Controls.Add(this.lblTotalFood);
            this.panelBottom.Controls.Add(this.btnConfirm);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Size = new System.Drawing.Size(600, 100); // Tăng chiều cao lên chút để chứa đủ 2 dòng

            // [MỚI] Cấu hình nhãn Quà tặng
            this.lblGift.AutoSize = true;
            this.lblGift.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold); // In đậm
            this.lblGift.ForeColor = System.Drawing.Color.Green; // Màu xanh lá cây
            this.lblGift.Location = new System.Drawing.Point(20, 15); // Nằm trên dòng Tổng tiền
            this.lblGift.Text = ""; // Mặc định rỗng

            this.lblTotalFood.AutoSize = true;
            this.lblTotalFood.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalFood.ForeColor = System.Drawing.Color.Red;
            this.lblTotalFood.Location = new System.Drawing.Point(20, 50); // Dời xuống dưới chút
            this.lblTotalFood.Text = "Tổng: 0 VND";

            this.btnConfirm.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(400, 25);
            this.btnConfirm.Size = new System.Drawing.Size(180, 50);
            this.btnConfirm.Text = "XÁC NHẬN";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            // Grid
            this.dgvFood.BackgroundColor = System.Drawing.Color.White;
            this.dgvFood.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFood.AllowUserToAddRows = false;
            this.dgvFood.RowTemplate.Height = 40;
            this.dgvFood.Location = new System.Drawing.Point(0, 60);
            this.dgvFood.Size = new System.Drawing.Size(600, 340);
            this.dgvFood.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFood_CellValueChanged);
            this.dgvFood.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvFood_CurrentCellDirtyStateChanged);

            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.dgvFood);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelHeader);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panelHeader.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFood)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader; private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBottom; private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblTotalFood;
        private System.Windows.Forms.Label lblGift; // [MỚI]
        private System.Windows.Forms.DataGridView dgvFood;
    }
}
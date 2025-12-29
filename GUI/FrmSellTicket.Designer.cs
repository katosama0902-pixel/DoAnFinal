namespace DoAnFinal.GUI
{
    partial class FrmSellTicket
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvMovies = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnFood = new System.Windows.Forms.Button(); // [MỚI] Khởi tạo nút Food
            this.btnPay = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSeatCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.flowSeatPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.lblNoteSelecting = new System.Windows.Forms.Label();
            this.btnNoteSelecting = new System.Windows.Forms.Button();
            this.lblNoteVIP = new System.Windows.Forms.Label();
            this.btnNoteVIP = new System.Windows.Forms.Button();
            this.lblNoteNormal = new System.Windows.Forms.Label();
            this.btnNoteNormal = new System.Windows.Forms.Button();
            this.lblNoteSold = new System.Windows.Forms.Label();
            this.btnNoteSold = new System.Windows.Forms.Button();
            this.lblScreen = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelLegend.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.dgvMovies);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(300, 600);
            this.panelLeft.TabIndex = 0;
            // 
            // dgvMovies
            // 
            this.dgvMovies.AllowUserToAddRows = false;
            this.dgvMovies.AllowUserToDeleteRows = false;
            this.dgvMovies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovies.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovies.Location = new System.Drawing.Point(0, 40);
            this.dgvMovies.Name = "dgvMovies";
            this.dgvMovies.ReadOnly = true;
            this.dgvMovies.RowHeadersVisible = false;
            this.dgvMovies.RowTemplate.Height = 30;
            this.dgvMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovies.Size = new System.Drawing.Size(300, 560);
            this.dgvMovies.TabIndex = 1;
            this.dgvMovies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovies_CellClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHỌN PHIM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelRight.Controls.Add(this.btnFood); // [MỚI] Add nút Food vào panel
            this.panelRight.Controls.Add(this.btnPay);
            this.panelRight.Controls.Add(this.lblTotalPrice);
            this.panelRight.Controls.Add(this.label5);
            this.panelRight.Controls.Add(this.lblSeatCount);
            this.panelRight.Controls.Add(this.label3);
            this.panelRight.Controls.Add(this.lblMovieName);
            this.panelRight.Controls.Add(this.label2);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(700, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(250, 600);
            this.panelRight.TabIndex = 1;
            // 
            // btnFood [MỚI] Cấu hình nút Food
            // 
            this.btnFood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFood.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnFood.ForeColor = System.Drawing.Color.White;
            this.btnFood.Location = new System.Drawing.Point(10, 110);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(230, 40);
            this.btnFood.TabIndex = 7;
            this.btnFood.Text = "🍿 CHỌN COMBO";
            this.btnFood.UseVisualStyleBackColor = false;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Firebrick;
            this.btnPay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(0, 540);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(250, 60);
            this.btnPay.TabIndex = 6;
            this.btnPay.Text = "THANH TOÁN";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.lblTotalPrice.Location = new System.Drawing.Point(10, 260);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(230, 30);
            this.lblTotalPrice.TabIndex = 5;
            this.lblTotalPrice.Text = "0 VND";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tổng tiền:";
            // 
            // lblSeatCount
            // 
            this.lblSeatCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblSeatCount.Location = new System.Drawing.Point(10, 180);
            this.lblSeatCount.Name = "lblSeatCount";
            this.lblSeatCount.Size = new System.Drawing.Size(230, 20);
            this.lblSeatCount.TabIndex = 3;
            this.lblSeatCount.Text = "0";
            this.lblSeatCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số ghế đặt:";
            // 
            // lblMovieName
            // 
            this.lblMovieName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblMovieName.ForeColor = System.Drawing.Color.Navy;
            this.lblMovieName.Location = new System.Drawing.Point(10, 60);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(230, 50);
            this.lblMovieName.TabIndex = 1;
            this.lblMovieName.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phim chọn:";
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.flowSeatPanel);
            this.panelCenter.Controls.Add(this.panelLegend);
            this.panelCenter.Controls.Add(this.lblScreen);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(300, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(400, 600);
            this.panelCenter.TabIndex = 2;
            // 
            // flowSeatPanel
            // 
            this.flowSeatPanel.AutoScroll = true;
            this.flowSeatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSeatPanel.Location = new System.Drawing.Point(0, 50);
            this.flowSeatPanel.Name = "flowSeatPanel";
            this.flowSeatPanel.Padding = new System.Windows.Forms.Padding(20);
            this.flowSeatPanel.Size = new System.Drawing.Size(400, 490);
            this.flowSeatPanel.TabIndex = 1;
            // 
            // panelLegend
            // 
            this.panelLegend.BackColor = System.Drawing.Color.White;
            this.panelLegend.Controls.Add(this.lblNoteSelecting);
            this.panelLegend.Controls.Add(this.btnNoteSelecting);
            this.panelLegend.Controls.Add(this.lblNoteVIP);
            this.panelLegend.Controls.Add(this.btnNoteVIP);
            this.panelLegend.Controls.Add(this.lblNoteNormal);
            this.panelLegend.Controls.Add(this.btnNoteNormal);
            this.panelLegend.Controls.Add(this.lblNoteSold);
            this.panelLegend.Controls.Add(this.btnNoteSold);
            this.panelLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLegend.Location = new System.Drawing.Point(0, 540);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(400, 60);
            this.panelLegend.TabIndex = 2;
            // 
            // lblNoteSelecting
            // 
            this.lblNoteSelecting.AutoSize = true;
            this.lblNoteSelecting.Location = new System.Drawing.Point(315, 17);
            this.lblNoteSelecting.Name = "lblNoteSelecting";
            this.lblNoteSelecting.Size = new System.Drawing.Size(76, 17);
            this.lblNoteSelecting.TabIndex = 7;
            this.lblNoteSelecting.Text = "Đang chọn";
            // 
            // btnNoteSelecting
            // 
            this.btnNoteSelecting.BackColor = System.Drawing.Color.Yellow;
            this.btnNoteSelecting.Enabled = false;
            this.btnNoteSelecting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoteSelecting.Location = new System.Drawing.Point(290, 15);
            this.btnNoteSelecting.Name = "btnNoteSelecting";
            this.btnNoteSelecting.Size = new System.Drawing.Size(20, 20);
            this.btnNoteSelecting.TabIndex = 6;
            this.btnNoteSelecting.UseVisualStyleBackColor = false;
            // 
            // lblNoteVIP
            // 
            this.lblNoteVIP.AutoSize = true;
            this.lblNoteVIP.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNoteVIP.Location = new System.Drawing.Point(235, 17);
            this.lblNoteVIP.Name = "lblNoteVIP";
            this.lblNoteVIP.Size = new System.Drawing.Size(32, 18);
            this.lblNoteVIP.TabIndex = 5;
            this.lblNoteVIP.Text = "VIP";
            // 
            // btnNoteVIP
            // 
            this.btnNoteVIP.BackColor = System.Drawing.Color.Gold;
            this.btnNoteVIP.Enabled = false;
            this.btnNoteVIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoteVIP.Location = new System.Drawing.Point(210, 15);
            this.btnNoteVIP.Name = "btnNoteVIP";
            this.btnNoteVIP.Size = new System.Drawing.Size(20, 20);
            this.btnNoteVIP.TabIndex = 4;
            this.btnNoteVIP.UseVisualStyleBackColor = false;
            // 
            // lblNoteNormal
            // 
            this.lblNoteNormal.AutoSize = true;
            this.lblNoteNormal.Location = new System.Drawing.Point(135, 17);
            this.lblNoteNormal.Name = "lblNoteNormal";
            this.lblNoteNormal.Size = new System.Drawing.Size(58, 17);
            this.lblNoteNormal.TabIndex = 3;
            this.lblNoteNormal.Text = "Thường";
            // 
            // btnNoteNormal
            // 
            this.btnNoteNormal.BackColor = System.Drawing.Color.LightGreen;
            this.btnNoteNormal.Enabled = false;
            this.btnNoteNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoteNormal.Location = new System.Drawing.Point(110, 15);
            this.btnNoteNormal.Name = "btnNoteNormal";
            this.btnNoteNormal.Size = new System.Drawing.Size(20, 20);
            this.btnNoteNormal.TabIndex = 2;
            this.btnNoteNormal.UseVisualStyleBackColor = false;
            // 
            // lblNoteSold
            // 
            this.lblNoteSold.AutoSize = true;
            this.lblNoteSold.Location = new System.Drawing.Point(45, 17);
            this.lblNoteSold.Name = "lblNoteSold";
            this.lblNoteSold.Size = new System.Drawing.Size(53, 17);
            this.lblNoteSold.TabIndex = 1;
            this.lblNoteSold.Text = "Đã bán";
            // 
            // btnNoteSold
            // 
            this.btnNoteSold.BackColor = System.Drawing.Color.Red;
            this.btnNoteSold.Enabled = false;
            this.btnNoteSold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoteSold.Location = new System.Drawing.Point(20, 15);
            this.btnNoteSold.Name = "btnNoteSold";
            this.btnNoteSold.Size = new System.Drawing.Size(20, 20);
            this.btnNoteSold.TabIndex = 0;
            this.btnNoteSold.UseVisualStyleBackColor = false;
            // 
            // lblScreen
            // 
            this.lblScreen.BackColor = System.Drawing.Color.Gray;
            this.lblScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblScreen.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblScreen.ForeColor = System.Drawing.Color.White;
            this.lblScreen.Location = new System.Drawing.Point(0, 0);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(400, 50);
            this.lblScreen.TabIndex = 0;
            this.lblScreen.Text = "MÀN HÌNH";
            this.lblScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSellTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "FrmSellTicket";
            this.Text = "BÁN VÉ";
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.panelLegend.ResumeLayout(false);
            this.panelLegend.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView dgvMovies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.FlowLayoutPanel flowSeatPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.Label lblSeatCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPay;

        // --- Nút chọn món ---
        private System.Windows.Forms.Button btnFood;

        // --- Chú thích màu sắc ---
        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.Button btnNoteSold;
        private System.Windows.Forms.Label lblNoteSold;
        private System.Windows.Forms.Button btnNoteNormal;
        private System.Windows.Forms.Label lblNoteNormal;
        private System.Windows.Forms.Button btnNoteVIP;
        private System.Windows.Forms.Label lblNoteVIP;
        private System.Windows.Forms.Button btnNoteSelecting;
        private System.Windows.Forms.Label lblNoteSelecting;
    }
}
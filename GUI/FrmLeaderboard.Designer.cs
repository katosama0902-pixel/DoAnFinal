namespace DoAnFinal.GUI
{
    partial class FrmLeaderboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTop3 = new System.Windows.Forms.Panel();
            this.lblTop3Money = new System.Windows.Forms.Label();
            this.lblTop3Name = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTop1Money = new System.Windows.Forms.Label();
            this.lblTop1Name = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTop2Money = new System.Windows.Forms.Label();
            this.lblTop2Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTicketRev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFoodRev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Yellow;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏆 BẢNG VINH DANH NHÂN VIÊN 🏆";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTop3
            // 
            this.pnlTop3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.pnlTop3.Controls.Add(this.lblTop3Money);
            this.pnlTop3.Controls.Add(this.lblTop3Name);
            this.pnlTop3.Controls.Add(this.label6);
            this.pnlTop3.Controls.Add(this.lblTop1Money);
            this.pnlTop3.Controls.Add(this.lblTop1Name);
            this.pnlTop3.Controls.Add(this.label4);
            this.pnlTop3.Controls.Add(this.lblTop2Money);
            this.pnlTop3.Controls.Add(this.lblTop2Name);
            this.pnlTop3.Controls.Add(this.label1);
            this.pnlTop3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop3.Location = new System.Drawing.Point(0, 60);
            this.pnlTop3.Name = "pnlTop3";
            this.pnlTop3.Size = new System.Drawing.Size(900, 200);
            this.pnlTop3.TabIndex = 1;
            // 
            // lblTop3Money
            // 
            this.lblTop3Money.AutoSize = true;
            this.lblTop3Money.Font = new System.Drawing.Font("Arial", 11F);
            this.lblTop3Money.ForeColor = System.Drawing.Color.LightGreen;
            this.lblTop3Money.Location = new System.Drawing.Point(650, 80);
            this.lblTop3Money.Name = "lblTop3Money";
            this.lblTop3Money.Size = new System.Drawing.Size(65, 22);
            this.lblTop3Money.TabIndex = 8;
            this.lblTop3Money.Text = "0 VND";
            // 
            // lblTop3Name
            // 
            this.lblTop3Name.AutoSize = true;
            this.lblTop3Name.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTop3Name.ForeColor = System.Drawing.Color.White;
            this.lblTop3Name.Location = new System.Drawing.Point(650, 50);
            this.lblTop3Name.Name = "lblTop3Name";
            this.lblTop3Name.Size = new System.Drawing.Size(46, 29);
            this.lblTop3Name.TabIndex = 7;
            this.lblTop3Name.Text = "---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(650, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "🥉 TOP 3";
            // 
            // lblTop1Money
            // 
            this.lblTop1Money.AutoSize = true;
            this.lblTop1Money.Font = new System.Drawing.Font("Arial", 11F);
            this.lblTop1Money.ForeColor = System.Drawing.Color.LightGreen;
            this.lblTop1Money.Location = new System.Drawing.Point(350, 80);
            this.lblTop1Money.Name = "lblTop1Money";
            this.lblTop1Money.Size = new System.Drawing.Size(65, 22);
            this.lblTop1Money.TabIndex = 5;
            this.lblTop1Money.Text = "0 VND";
            // 
            // lblTop1Name
            // 
            this.lblTop1Name.AutoSize = true;
            this.lblTop1Name.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTop1Name.ForeColor = System.Drawing.Color.White;
            this.lblTop1Name.Location = new System.Drawing.Point(350, 50);
            this.lblTop1Name.Name = "lblTop1Name";
            this.lblTop1Name.Size = new System.Drawing.Size(46, 29);
            this.lblTop1Name.TabIndex = 4;
            this.lblTop1Name.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(350, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "🥇 TOP 1 (BEST SELLER)";
            // 
            // lblTop2Money
            // 
            this.lblTop2Money.AutoSize = true;
            this.lblTop2Money.Font = new System.Drawing.Font("Arial", 11F);
            this.lblTop2Money.ForeColor = System.Drawing.Color.LightGreen;
            this.lblTop2Money.Location = new System.Drawing.Point(50, 80);
            this.lblTop2Money.Name = "lblTop2Money";
            this.lblTop2Money.Size = new System.Drawing.Size(65, 22);
            this.lblTop2Money.TabIndex = 2;
            this.lblTop2Money.Text = "0 VND";
            // 
            // lblTop2Name
            // 
            this.lblTop2Name.AutoSize = true;
            this.lblTop2Name.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTop2Name.ForeColor = System.Drawing.Color.White;
            this.lblTop2Name.Location = new System.Drawing.Point(50, 50);
            this.lblTop2Name.Name = "lblTop2Name";
            this.lblTop2Name.Size = new System.Drawing.Size(46, 29);
            this.lblTop2Name.TabIndex = 1;
            this.lblTop2Name.Text = "---";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "🥈 TOP 2";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeight = 40;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRank,
            this.colName,
            this.colTicketRev,
            this.colFoodRev,
            this.colTotal});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(0, 260);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 51;
            this.dgvList.RowTemplate.Height = 35;
            this.dgvList.Size = new System.Drawing.Size(900, 340);
            this.dgvList.TabIndex = 2;
            // 
            // colRank
            // 
            this.colRank.HeaderText = "Hạng";
            this.colRank.MinimumWidth = 6;
            this.colRank.Name = "colRank";
            this.colRank.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "Nhân viên";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colTicketRev
            // 
            this.colTicketRev.HeaderText = "Doanh thu Vé";
            this.colTicketRev.MinimumWidth = 6;
            this.colTicketRev.Name = "colTicketRev";
            this.colTicketRev.ReadOnly = true;
            // 
            // colFoodRev
            // 
            this.colFoodRev.HeaderText = "Doanh thu F&B";
            this.colFoodRev.MinimumWidth = 6;
            this.colFoodRev.Name = "colFoodRev";
            this.colFoodRev.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "TỔNG CỘNG";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // FrmLeaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.pnlTop3);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmLeaderboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng xếp hạng nhân viên";
            this.pnlTop3.ResumeLayout(false);
            this.pnlTop3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTop3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTop3Money;
        private System.Windows.Forms.Label lblTop3Name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTop1Money;
        private System.Windows.Forms.Label lblTop1Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTop2Money;
        private System.Windows.Forms.Label lblTop2Name;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTicketRev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFoodRev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}
namespace DoAnFinal.GUI
{
    partial class FrmCheckTicket
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelFill = new System.Windows.Forms.Panel();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancelTicket = new System.Windows.Forms.Button(); // [MỚI] Nút Hủy
            this.btnPrint = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // Panel Top
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 80;
            this.panelTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.btnSearch);

            this.label1.Text = "Nhập SĐT khách hoặc Tên phim:";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Font = new System.Drawing.Font("Arial", 10F);

            this.txtSearch.Location = new System.Drawing.Point(33, 45);
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.txtSearch.Font = new System.Drawing.Font("Arial", 11F);

            this.btnSearch.Text = "TÌM KIẾM";
            this.btnSearch.Location = new System.Drawing.Point(350, 42);
            this.btnSearch.Size = new System.Drawing.Size(120, 32);
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Panel Bottom
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 60;
            this.panelBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBottom.Controls.Add(this.btnCancelTicket); // Add nút Hủy
            this.panelBottom.Controls.Add(this.btnPrint);

            // [MỚI] btnCancelTicket (HỦY VÉ)
            this.btnCancelTicket.Text = "🗑 HỦY VÉ / HOÀN TIỀN";
            this.btnCancelTicket.Location = new System.Drawing.Point(30, 10);
            this.btnCancelTicket.Size = new System.Drawing.Size(220, 40);
            this.btnCancelTicket.BackColor = System.Drawing.Color.DarkRed; // Màu đỏ đậm
            this.btnCancelTicket.ForeColor = System.Drawing.Color.White;
            this.btnCancelTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelTicket.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelTicket.Click += new System.EventHandler(this.btnCancelTicket_Click);

            // btnPrint
            this.btnPrint.Text = "🖨 IN LẠI VÉ ĐÃ CHỌN";
            this.btnPrint.Location = new System.Drawing.Point(750, 10);
            this.btnPrint.Size = new System.Drawing.Size(200, 40);
            this.btnPrint.BackColor = System.Drawing.Color.SeaGreen;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);

            // Grid
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Controls.Add(this.dgvTickets);

            this.dgvTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTickets.BackgroundColor = System.Drawing.Color.White;
            this.dgvTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTickets.ReadOnly = true;

            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Text = "Tra Cứu Vé";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop; private System.Windows.Forms.Label label1; private System.Windows.Forms.TextBox txtSearch; private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panelFill; private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancelTicket; // Khai báo nút mới
    }
}
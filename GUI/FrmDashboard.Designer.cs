namespace DoAnFinal.GUI
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.panelCards = new System.Windows.Forms.Panel();
            this.panelCard3 = new System.Windows.Forms.Panel();
            this.lblNumStaff = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelCard2 = new System.Windows.Forms.Panel();
            this.lblNumTickets = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCard1 = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelChart = new System.Windows.Forms.Panel();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelChartTitle = new System.Windows.Forms.Label();
            this.panelCards.SuspendLayout();
            this.panelCard3.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.panelCard1.SuspendLayout();
            this.panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.SuspendLayout();

            // 1. Panel chứa 3 thẻ bài
            this.panelCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCards.Height = 150;
            this.panelCards.Padding = new System.Windows.Forms.Padding(10);

            // CARD 1: Doanh thu (Màu Xanh lá)
            this.panelCard1.BackColor = System.Drawing.Color.SeaGreen;
            this.panelCard1.Controls.Add(this.lblTotalRevenue);
            this.panelCard1.Controls.Add(this.label1);
            this.panelCard1.Location = new System.Drawing.Point(20, 20);
            this.panelCard1.Size = new System.Drawing.Size(220, 110);

            this.label1.Text = "TỔNG DOANH THU";
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.AutoSize = true;

            this.lblTotalRevenue.Text = "0 VND";
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.Location = new System.Drawing.Point(10, 50);
            this.lblTotalRevenue.AutoSize = true;

            // CARD 2: Số vé (Màu Cam)
            this.panelCard2.BackColor = System.Drawing.Color.Orange;
            this.panelCard2.Controls.Add(this.lblNumTickets);
            this.panelCard2.Controls.Add(this.label2);
            this.panelCard2.Location = new System.Drawing.Point(260, 20);
            this.panelCard2.Size = new System.Drawing.Size(220, 110);

            this.label2.Text = "VÉ ĐÃ BÁN";
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.AutoSize = true;

            this.lblNumTickets.Text = "0";
            this.lblNumTickets.ForeColor = System.Drawing.Color.White;
            this.lblNumTickets.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblNumTickets.Location = new System.Drawing.Point(10, 50);
            this.lblNumTickets.AutoSize = true;

            // CARD 3: Nhân viên (Màu Xanh dương)
            this.panelCard3.BackColor = System.Drawing.Color.SteelBlue;
            this.panelCard3.Controls.Add(this.lblNumStaff);
            this.panelCard3.Controls.Add(this.label3);
            this.panelCard3.Location = new System.Drawing.Point(500, 20);
            this.panelCard3.Size = new System.Drawing.Size(220, 110);

            this.label3.Text = "TỔNG NHÂN VIÊN";
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(10, 15);
            this.label3.AutoSize = true;

            this.lblNumStaff.Text = "0";
            this.lblNumStaff.ForeColor = System.Drawing.Color.White;
            this.lblNumStaff.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblNumStaff.Location = new System.Drawing.Point(10, 50);
            this.lblNumStaff.AutoSize = true;

            // 2. Chart (Biểu đồ)
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart.Controls.Add(this.chartRevenue);
            this.panelChart.Controls.Add(this.labelChartTitle);
            this.panelChart.Padding = new System.Windows.Forms.Padding(20);

            this.labelChartTitle.Text = "TOP 5 PHIM DOANH THU CAO NHẤT";
            this.labelChartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelChartTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelChartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelChartTitle.Height = 40;

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.chartRevenue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend1);
            this.chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Doanh Thu";
            this.chartRevenue.Series.Add(series1);
            this.chartRevenue.Dock = System.Windows.Forms.DockStyle.Fill;

            // Add controls
            this.panelCards.Controls.Add(this.panelCard1);
            this.panelCards.Controls.Add(this.panelCard2);
            this.panelCards.Controls.Add(this.panelCard3);
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.panelCards);

            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Text = "Dashboard";
            this.panelCards.ResumeLayout(false);
            this.panelCard3.ResumeLayout(false); this.panelCard3.PerformLayout();
            this.panelCard2.ResumeLayout(false); this.panelCard2.PerformLayout();
            this.panelCard1.ResumeLayout(false); this.panelCard1.PerformLayout();
            this.panelChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelCards;
        private System.Windows.Forms.Panel panelCard1; private System.Windows.Forms.Label lblTotalRevenue; private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCard2; private System.Windows.Forms.Label lblNumTickets; private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelCard3; private System.Windows.Forms.Label lblNumStaff; private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Label labelChartTitle;
    }
}
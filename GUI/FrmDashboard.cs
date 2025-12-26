using DAL;
using DoAnFinal.BLL;
using DoAnFinal.DAL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Thư viện biểu đồ

namespace DoAnFinal.GUI
{
    public partial class FrmDashboard : Form
    {
        private DashboardBLL dashBLL = new DashboardBLL();

        public FrmDashboard()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            // 1. Load các con số lên thẻ
            decimal revenue = dashBLL.GetTotalRevenue();
            int tickets = dashBLL.GetTotalTickets();
            int staff = dashBLL.GetTotalStaff();

            lblTotalRevenue.Text = revenue.ToString("N0") + " VND"; // Định dạng tiền
            lblNumTickets.Text = tickets.ToString();
            lblNumStaff.Text = staff.ToString();

            // 2. Vẽ biểu đồ (Chart)
            List<TopMovieDTO> list = dashBLL.GetTopMovies();

            chartRevenue.Series["Doanh Thu"].Points.Clear();

            foreach (var item in list)
            {
                // Thêm cột vào biểu đồ: Trục X là Tên phim, Trục Y là Tiền
                chartRevenue.Series["Doanh Thu"].Points.AddXY(item.MovieName, item.TotalRevenue);
            }
        }
    }
}
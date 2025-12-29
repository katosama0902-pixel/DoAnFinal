using DoAnFinal.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmLeaderboard : Form
    {
        private ReportBLL reportBLL = new ReportBLL();

        public FrmLeaderboard()
        {
            InitializeComponent();
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            // 1. Lấy dữ liệu từ BLL
            List<StaffRevenueDTO> data = reportBLL.GetStaffLeaderboard();

            // 2. Hiển thị Top 1, 2, 3 (Nếu có)
            if (data.Count > 0) SetTopRank(lblTop1Name, lblTop1Money, data[0], Color.Gold);
            else ClearRank(lblTop1Name, lblTop1Money);

            if (data.Count > 1) SetTopRank(lblTop2Name, lblTop2Money, data[1], Color.Silver);
            else ClearRank(lblTop2Name, lblTop2Money);

            if (data.Count > 2) SetTopRank(lblTop3Name, lblTop3Money, data[2], Color.FromArgb(205, 127, 50)); // Màu đồng
            else ClearRank(lblTop3Name, lblTop3Money);

            // 3. Hiển thị danh sách còn lại vào Grid (Từ người thứ 4 trở đi)
            dgvList.Rows.Clear();
            for (int i = 3; i < data.Count; i++)
            {
                var item = data[i];
                dgvList.Rows.Add(
                    i + 1, // Hạng
                    item.Username,
                    item.TicketRevenue.ToString("N0"),
                    item.FoodRevenue.ToString("N0"),
                    item.TotalRevenue.ToString("N0")
                );
            }
        }

        // Hàm hỗ trợ gán dữ liệu cho Label Top
        private void SetTopRank(Label lblName, Label lblMoney, StaffRevenueDTO dto, Color color)
        {
            lblName.Text = dto.Username.ToUpper();
            lblName.ForeColor = color;
            lblMoney.Text = dto.TotalRevenue.ToString("N0") + " VND";
        }

        // Hàm xóa dữ liệu nếu không đủ người
        private void ClearRank(Label lblName, Label lblMoney)
        {
            lblName.Text = "---";
            lblMoney.Text = "0 VND";
        }
    }
}
using DoAnFinal.BLL;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmCheckTicket : Form
    {
        private TicketBLL ticketBLL = new TicketBLL();

        // Biến tạm để lưu thông tin vé cần in
        private string _printMovieName;
        private string _printSeat;
        private string _printPrice;
        private string _printDate;
        private string _printCustomer;

        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

        public FrmCheckTicket()
        {
            InitializeComponent();
            LoadData(""); // Load toàn bộ lúc đầu

            // Cấu hình in ấn
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.Document = printDocument1;
        }

        private void LoadData(string keyword)
        {
            dgvTickets.DataSource = ticketBLL.GetTicketHistory(keyword);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void btnCancelTicket_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đã chọn dòng chưa
            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé cần hủy!", "Thông báo");
                return;
            }

            // 2. Hỏi xác nhận (Rất quan trọng vì xóa là mất luôn)
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn HỦY vé này không?\n\nLƯU Ý: Vé sẽ bị xóa vĩnh viễn và ghế sẽ trống trở lại.",
                "Xác nhận hủy vé",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Lấy Mã Vé (ID) từ cột đầu tiên của Grid
                    int ticketId = Convert.ToInt32(dgvTickets.SelectedRows[0].Cells["Mã Vé"].Value);

                    // Gọi hàm BLL để xóa
                    bool isDeleted = ticketBLL.RefundTicket(ticketId);

                    if (isDeleted)
                    {
                        MessageBox.Show("Đã hủy vé thành công! Đã hoàn tiền cho khách.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Load lại dữ liệu để cập nhật danh sách
                        LoadData(txtSearch.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy vé hoặc vé đã bị xóa trước đó.", "Lỗi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy vé: " + ex.Message);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé cần in!", "Thông báo");
                return;
            }

            // Lấy dữ liệu từ dòng đang chọn
            var row = dgvTickets.SelectedRows[0];
            _printMovieName = row.Cells["Phim"].Value.ToString();
            _printSeat = row.Cells["Ghế"].Value.ToString();
            _printPrice = row.Cells["Giá"].Value.ToString(); // Đã format có dấu phẩy
            _printDate = row.Cells["Ngày Mua"].Value.ToString();
            _printCustomer = row.Cells["Khách Hàng"].Value.ToString();

            // Mở Preview
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
        }

        // HÀM VẼ LẠI VÉ (Copy ý tưởng từ FrmSellTicket nhưng đơn giản hơn)
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 12, FontStyle.Regular);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);

            int y = 20;
            int centerX = e.PageBounds.Width / 2;
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };

            // Header
            e.Graphics.DrawString("RẠP CHIẾU PHIM CINEMA 4.0", titleFont, Brushes.Black, centerX, y, centerFormat);
            y += 40;
            e.Graphics.DrawString("(VÉ IN LẠI / RE-PRINT)", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, centerX, y, centerFormat);
            y += 30;
            e.Graphics.DrawString("------------------------------------------------", bodyFont, Brushes.Black, centerX, y, centerFormat);
            y += 30;

            // Nội dung vé
            e.Graphics.DrawString("Phim: " + _printMovieName, boldFont, Brushes.Black, 50, y);
            y += 30;
            e.Graphics.DrawString("Thời gian: " + _printDate, bodyFont, Brushes.Black, 50, y);
            y += 30;
            e.Graphics.DrawString("Ghế: " + _printSeat, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, y);
            y += 40;
            e.Graphics.DrawString("Giá vé: " + _printPrice + " VND", bodyFont, Brushes.Black, 50, y);
            y += 30;
            e.Graphics.DrawString("Khách hàng: " + _printCustomer, bodyFont, Brushes.Black, 50, y);
            y += 40;

            e.Graphics.DrawString("------------------------------------------------", bodyFont, Brushes.Black, centerX, y, centerFormat);
            y += 30;
            e.Graphics.DrawString("Cảm ơn quý khách!", bodyFont, Brushes.Black, centerX, y, centerFormat);
        }
    }
}
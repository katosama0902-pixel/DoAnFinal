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

            // Cấu hình in ấn
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.Document = printDocument1;

            // Load dữ liệu ngay khi mở form
            LoadData("");
        }

        // Hàm Load dữ liệu AN TOÀN (Fix triệt để lỗi Null)
        private void LoadData(string keyword)
        {
            try
            {
                dgvTickets.DataSource = ticketBLL.GetTicketHistory(keyword);

                // --- 1. TÌM CỘT THỜI GIAN ĐẶT VÉ ---
                DataGridViewColumn colDate = null;
                foreach (DataGridViewColumn col in dgvTickets.Columns)
                {
                    // Tìm cột có kiểu dữ liệu là DateTime hoặc tên chứa chữ "date"/"time"/"ngay"
                    if (col.ValueType == typeof(DateTime) ||
                        col.Name.ToLower().Contains("date") ||
                        col.Name.ToLower().Contains("time") ||
                        col.Name.ToLower().Contains("ngay"))
                    {
                        colDate = col;
                        break;
                    }
                }

                if (colDate != null)
                {
                    colDate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    colDate.HeaderText = "Thời Gian Đặt";
                    colDate.Width = 150;
                }

                // --- 2. TÌM CỘT GIÁ VÉ ---
                DataGridViewColumn colPrice = null;
                foreach (DataGridViewColumn col in dgvTickets.Columns)
                {
                    if (col.Name.ToLower().Contains("price") ||
                        col.Name.ToLower().Contains("gia") ||
                        col.Name.ToLower().Contains("money"))
                    {
                        colPrice = col;
                        break;
                    }
                }

                if (colPrice != null)
                {
                    colPrice.DefaultCellStyle.Format = "N0";
                    colPrice.HeaderText = "Giá Vé (VNĐ)";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load data: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        // [TÍNH NĂNG] Hủy vé theo quy tắc thời gian (70% - 50% - 0%)
        // Đã cập nhật fix lỗi ngày tháng như bạn yêu cầu
        private void btnCancelTicket_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra chọn dòng
            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé cần hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Lấy dữ liệu từ dòng đã chọn
                DataGridViewRow row = dgvTickets.SelectedRows[0];

                // Lấy ID vé an toàn
                int ticketId = 0;
                if (row.Cells["Mã Vé"] != null) int.TryParse(row.Cells["Mã Vé"].Value.ToString(), out ticketId);
                else if (row.Cells["id"] != null) int.TryParse(row.Cells["id"].Value.ToString(), out ticketId);

                // Lấy tên phim
                string movieName = "";
                if (row.Cells["Phim"] != null) movieName = row.Cells["Phim"].Value.ToString();

                // Lấy giá vé
                decimal originalPrice = 0;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn.HeaderText.Contains("Giá") || cell.OwningColumn.Name.Contains("price"))
                    {
                        if (cell.Value != null)
                        {
                            string s = cell.Value.ToString().Replace(",", "").Replace(".", "").Replace(" VND", "");
                            decimal.TryParse(s, out originalPrice);
                        }
                        break;
                    }
                }

                // [FIX LỖI QUAN TRỌNG: LẤY NGÀY ĐẶT VÉ CHUẨN XÁC]
                DateTime bookingDate = DateTime.Now;
                bool dateFound = false;

                // Các tên cột có thể chứa ngày (Ưu tiên 'Ngày Mua' như trong hình của bạn)
                string[] dateColumns = { "Ngày Mua", "created_at", "NgayDat", "Thời Gian Đặt" };

                foreach (string colName in dateColumns)
                {
                    if (dgvTickets.Columns.Contains(colName) && row.Cells[colName].Value != null)
                    {
                        var val = row.Cells[colName].Value;

                        // Trường hợp 1: Dữ liệu gốc là DateTime
                        if (val is DateTime)
                        {
                            bookingDate = (DateTime)val;
                            dateFound = true;
                            break;
                        }
                        // Trường hợp 2: Dữ liệu là Chữ (String) -> Cần ép kiểu lại
                        else if (DateTime.TryParse(val.ToString(), out DateTime parsedDate))
                        {
                            bookingDate = parsedDate;
                            dateFound = true;
                            break;
                        }
                    }
                }

                if (!dateFound)
                {
                    // Nếu không tìm thấy cột ngày, dùng ngày hiện tại (phòng hờ lỗi)
                    bookingDate = DateTime.Now;
                }

                // --- GIẢ LẬP GIỜ CHIẾU (ShowTime) ---
                // Quy tắc giả định: Phim chiếu sau ngày đặt 4 ngày.
                DateTime showTime = bookingDate.AddDays(4);
                // ------------------------------------

                // 3. Tính toán thời gian còn lại
                TimeSpan timeDiff = showTime - DateTime.Now;
                double daysRemaining = timeDiff.TotalDays;

                decimal refundPercent = 0;
                string note = "";

                // Logic hiển thị thông báo
                if (daysRemaining < 0)
                {
                    MessageBox.Show($"Vé này đặt ngày {bookingDate:dd/MM/yyyy}.\nPhim đã chiếu ngày {showTime:dd/MM/yyyy}.\n\n=> KHÔNG THỂ HỦY VÉ CŨ!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (daysRemaining < 1) // Dưới 1 ngày (24h)
                {
                    MessageBox.Show($"Sát giờ chiếu (còn {timeDiff.Hours} giờ)!\nQuy định: Không hoàn vé trước 24h.",
                                    "Không thể hủy", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else if (daysRemaining >= 3) // Trước 3 ngày
                {
                    refundPercent = 0.7m; // 70%
                    note = "(Trước 3 ngày: Hoàn 70%)";
                }
                else // Từ 1 đến 3 ngày
                {
                    refundPercent = 0.5m; // 50%
                    note = "(Sát ngày: Hoàn 50%)";
                }

                decimal refundAmount = originalPrice * refundPercent;

                // 4. Xác nhận
                DialogResult confirm = MessageBox.Show(
                    $"YÊU CẦU HỦY VÉ:\n" +
                    $"🎬 Phim: {movieName}\n" +
                    $"📅 Đặt lúc: {bookingDate:dd/MM/yyyy HH:mm}\n" +
                    $"🕒 Chiếu lúc (Dự kiến): {showTime:dd/MM/yyyy HH:mm}\n" +
                    $"⏳ Còn lại: {daysRemaining:0.0} ngày\n\n" +
                    $"💰 Giá vé: {originalPrice:N0}\n" +
                    $"💸 Hoàn lại: {refundAmount:N0} {note}\n\n" +
                    "Bạn có chắc chắn muốn hủy?",
                    "Xác nhận hoàn tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    if (ticketBLL.RefundTicket(ticketId))
                    {
                        MessageBox.Show($"Đã hủy vé!\nHãy hoàn lại {refundAmount:N0} VNĐ cho khách.", "Thành công");
                        LoadData(txtSearch.Text.Trim()); // Refresh grid
                    }
                    else
                    {
                        MessageBox.Show("Lỗi Database: Không thể hủy vé này.", "Lỗi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvTickets.SelectedRows.Count == 0) return;

            var row = dgvTickets.SelectedRows[0];
            // Lấy thông tin an toàn (tránh null)
            _printMovieName = row.Cells["Phim"]?.Value?.ToString() ?? "N/A";
            _printSeat = row.Cells["Ghế"]?.Value?.ToString() ?? "N/A";

            // Tìm giá và ngày để in
            _printPrice = "0";
            _printDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value is DateTime) _printDate = ((DateTime)cell.Value).ToString("dd/MM/yyyy HH:mm");
                else if (DateTime.TryParse(cell.Value?.ToString(), out DateTime d)) _printDate = d.ToString("dd/MM/yyyy HH:mm"); // Fix thêm cho chắc chắn

                if (cell.OwningColumn.HeaderText.Contains("Giá")) _printPrice = cell.Value?.ToString();
            }

            _printCustomer = row.Cells["Khách Hàng"]?.Value?.ToString() ?? "Khách vãng lai";

            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 12);
            int y = 50; int centerX = e.PageBounds.Width / 2;
            StringFormat center = new StringFormat { Alignment = StringAlignment.Center };

            e.Graphics.DrawString("RẠP CHIẾU PHIM CINEMA 4.0", titleFont, Brushes.Black, centerX, y, center);
            y += 40;
            e.Graphics.DrawString("(VÉ IN LẠI)", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, centerX, y, center);
            y += 40;
            e.Graphics.DrawString($"Phim: {_printMovieName}", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, y);
            y += 30;
            e.Graphics.DrawString($"Thời gian đặt: {_printDate}", bodyFont, Brushes.Black, 50, y);
            y += 30;
            e.Graphics.DrawString($"Ghế: {_printSeat}", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, y);
            y += 50;
            e.Graphics.DrawString($"Giá: {_printPrice} VND", bodyFont, Brushes.Black, 50, y);
            y += 30;
            e.Graphics.DrawString("--------------------------------", bodyFont, Brushes.Black, centerX, y, center);
        }
    }
}
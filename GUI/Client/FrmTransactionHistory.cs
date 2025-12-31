using DAL;
using DoAnFinal.BLL; // Cần dùng BLL để gọi hàm xử lý vé
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DoAnFinal.GUI.CustomerArea
{
    public partial class FrmTransactionHistory : Form
    {
        private customer _currentCustomer;
        private TicketBLL ticketBLL = new TicketBLL(); // Khởi tạo BLL

        public FrmTransactionHistory(customer cus)
        {
            InitializeComponent();
            _currentCustomer = cus;
            LoadData();
        }

        private void LoadData()
        {
            // 1. Hiển thị điểm tích lũy
            lblPoints.Text = $"Ví điểm: {_currentCustomer.points ?? 0:N0} đ";

            using (var db = new CinemaModel())
            {
                // [SỬA LỖI] Dùng cú pháp JOIN để nối bảng Tickets và Movies
                // Cách này đảm bảo lấy được Tên Phim chính xác mà không sợ lỗi "movie is null"
                var myTickets = (from t in db.tickets
                                 join m in db.movies on t.movie_id equals m.movie_id
                                 where t.customer_id == _currentCustomer.id
                                 orderby t.created_at descending
                                 select new
                                 {
                                     MaVe = t.id,          // [FIX 1] Đổi ticket_id -> id
                                     Phim = m.movie_name,  // [FIX 2] Lấy tên phim từ bảng m (Movies)
                                     Ghe = t.seat_number,
                                     GiaVe = t.price,
                                     NgayDat = t.created_at
                                 }).ToList();

                dgvHistory.DataSource = myTickets;

                // Cấu hình hiển thị cột
                if (dgvHistory.Columns["MaVe"] != null)
                    dgvHistory.Columns["MaVe"].Visible = false; // Ẩn cột ID

                dgvHistory.Columns["Phim"].HeaderText = "Tên Phim";
                dgvHistory.Columns["Ghe"].HeaderText = "Số Ghế";
                dgvHistory.Columns["GiaVe"].HeaderText = "Giá Vé (VNĐ)";
                dgvHistory.Columns["GiaVe"].DefaultCellStyle.Format = "N0";
                dgvHistory.Columns["NgayDat"].HeaderText = "Ngày Đặt";
            }
        }

        // --- SỰ KIỆN NÚT PASS VÉ (MỚI) ---
        private void btnResell_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng nào chưa
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé bạn muốn pass lại!", "Chưa chọn vé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ dòng đang chọn
            int ticketId = Convert.ToInt32(dgvHistory.SelectedRows[0].Cells["MaVe"].Value);
            decimal price = Convert.ToDecimal(dgvHistory.SelectedRows[0].Cells["GiaVe"].Value);
            string movieName = dgvHistory.SelectedRows[0].Cells["Phim"].Value.ToString();

            // Tính toán tiền hoàn lại (90%)
            decimal refund = price * 0.9m;

            // Hỏi xác nhận lần cuối
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn PASS lại vé phim:\n\n" +
                $"🎬 {movieName}\n" +
                $"💰 Giá gốc: {price:N0} đ\n" +
                $"🔄 Giá hoàn lại (90%): {refund:N0} đ\n\n" +
                $"Số tiền {refund:N0} đ sẽ được cộng ngay vào Ví Điểm của bạn.",
                "Xác nhận Pass Vé",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Gọi BLL để xử lý (Xóa vé, cộng điểm)
                // Lưu ý: Đảm bảo TicketBLL.cs đã có hàm ResellTicket như bước trước
                bool success = ticketBLL.ResellTicket(ticketId, _currentCustomer.id);

                if (success)
                {
                    MessageBox.Show("Đã pass vé thành công! Tiền đã về ví.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại thông tin khách hàng mới nhất từ DB
                    using (var db = new CinemaModel())
                    {
                        _currentCustomer = db.customers.Find(_currentCustomer.id);
                    }

                    // Load lại bảng
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra hoặc vé không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
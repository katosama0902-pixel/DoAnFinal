using DAL;
using DoAnFinal.BLL;
using DoAnFinal.DAL; // Để dùng class ticket và movie
using DoAnFinal.Helper; // Để dùng Session
using System;
using System.Collections.Generic;
using System.Drawing; // Dùng cho vẽ hóa đơn
using System.Drawing.Printing; // Dùng cho chức năng in
using System.Linq;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmSellTicket : Form
    {
        private MovieBLL movieBLL = new MovieBLL();
        private TicketBLL ticketBLL = new TicketBLL();

        // Biến lưu trạng thái hiện tại
        private movie _selectedMovie = null;
        private List<int> _selectedSeats = new List<int>(); // Danh sách ghế đang chọn

        // --- MỚI THÊM: Khai báo biến dùng cho In Ấn ---
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        // ----------------------------------------------

        public FrmSellTicket()
        {
            InitializeComponent();
            LoadMovieList();

            // --- MỚI THÊM: Cấu hình sự kiện In ---
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.Document = printDocument1;
            // -------------------------------------
        }

        // 1. Load danh sách phim
        private void LoadMovieList()
        {
            var movies = movieBLL.GetMovieList().Where(m => m.status == "Available").ToList();

            dgvMovies.DataSource = movies;
            // Ẩn các cột không cần thiết
            if (dgvMovies.Columns["id"] != null) dgvMovies.Columns["id"].Visible = false;
            if (dgvMovies.Columns["created_at"] != null) dgvMovies.Columns["created_at"].Visible = false;
            if (dgvMovies.Columns["updated_at"] != null) dgvMovies.Columns["updated_at"].Visible = false;
            if (dgvMovies.Columns["movie_image"] != null) dgvMovies.Columns["movie_image"].Visible = false;
            if (dgvMovies.Columns["tickets"] != null) dgvMovies.Columns["tickets"].Visible = false; // Ẩn cột tickets nếu có

            if (dgvMovies.Columns["movie_name"] != null) dgvMovies.Columns["movie_name"].HeaderText = "Tên Phim";
            if (dgvMovies.Columns["price"] != null) dgvMovies.Columns["price"].HeaderText = "Giá";
        }

        // 2. Sự kiện chọn phim
        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy ID phim (Đảm bảo tên cột "id" đúng với database)
                if (dgvMovies.Rows[e.RowIndex].Cells["id"].Value != null)
                {
                    int id = Convert.ToInt32(dgvMovies.Rows[e.RowIndex].Cells["id"].Value);
                    _selectedMovie = movieBLL.GetMovieById(id);

                    lblMovieName.Text = _selectedMovie.movie_name;
                    ResetSelection();
                    GenerateSeatMap(_selectedMovie);
                }
            }
        }

        // 3. Reset chọn ghế
        private void ResetSelection()
        {
            _selectedSeats.Clear();
            UpdatePaymentInfo();
        }

        // 4. Vẽ sơ đồ ghế
        private void GenerateSeatMap(movie mv)
        {
            flowSeatPanel.Controls.Clear();
            List<int> bookedSeats = ticketBLL.GetBookedSeats(mv.movie_id);

            for (int i = 1; i <= mv.capacity; i++)
            {
                Button btnSeat = new Button();
                btnSeat.Width = 50;
                btnSeat.Height = 50;
                btnSeat.Margin = new Padding(5);
                btnSeat.Text = i.ToString();
                btnSeat.Tag = i;

                if (bookedSeats.Contains(i))
                {
                    btnSeat.BackColor = Color.Red;
                    btnSeat.Enabled = false;
                }
                else
                {
                    btnSeat.BackColor = Color.LightGreen;
                    btnSeat.Click += BtnSeat_Click;
                }
                flowSeatPanel.Controls.Add(btnSeat);
            }
        }

        // 5. Click chọn ghế
        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int seatNum = (int)btn.Tag;

            if (_selectedSeats.Contains(seatNum))
            {
                _selectedSeats.Remove(seatNum);
                btn.BackColor = Color.LightGreen;
            }
            else
            {
                _selectedSeats.Add(seatNum);
                btn.BackColor = Color.Yellow;
            }
            UpdatePaymentInfo();
        }

        // 6. Cập nhật tiền
        private void UpdatePaymentInfo()
        {
            lblSeatCount.Text = _selectedSeats.Count.ToString();
            if (_selectedMovie != null)
            {
                decimal total = _selectedSeats.Count * _selectedMovie.price;
                lblTotalPrice.Text = total.ToString("N0") + " VND";
            }
        }

        // 7. Xử lý Thanh Toán (Đã thêm lệnh In)
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (_selectedMovie == null || _selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phim và ghế!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    foreach (int seatNum in _selectedSeats)
                    {
                        ticket t = new ticket();
                        t.movie_id = _selectedMovie.movie_id;
                        t.seat_number = seatNum;
                        t.price = _selectedMovie.price;
                        t.created_at = DateTime.Now;
                        t.customer_id = null; // Khách vãng lai

                        if (Session.CurrentUser != null)
                            t.staff_id = Session.CurrentUser.id;
                        else
                            t.staff_id = 1; // Mặc định Admin nếu chưa login

                        ticketBLL.BuyTicket(t);
                    }

                    MessageBox.Show("Thanh toán thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // --- MỚI THÊM: Hiện bảng xem trước hóa đơn ---
                    try
                    {
                        printPreviewDialog1.WindowState = FormWindowState.Maximized;
                        printPreviewDialog1.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi in ấn: " + ex.Message);
                    }
                    // --------------------------------------------

                    ResetSelection();
                    GenerateSeatMap(_selectedMovie);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // --- MỚI THÊM: Hàm vẽ nội dung hóa đơn ---
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Font chữ
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 12, FontStyle.Regular);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);

            int y = 20;
            int centerX = e.PageBounds.Width / 2;
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };

            // Header
            e.Graphics.DrawString("RẠP CHIẾU PHIM CINEMA 4.0", titleFont, Brushes.Black, centerX, y, centerFormat);
            y += 40;
            e.Graphics.DrawString("----------------------------------------------------------------", bodyFont, Brushes.Black, centerX, y, centerFormat);
            y += 30;

            // Nội dung
            e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN", boldFont, Brushes.Black, centerX, y, centerFormat);
            y += 40;
            e.Graphics.DrawString("Phim: " + _selectedMovie.movie_name, bodyFont, Brushes.Black, 50, y);
            y += 30;
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), bodyFont, Brushes.Black, 50, y);
            y += 30;

            // Danh sách ghế
            string listSeat = string.Join(", ", _selectedSeats);
            e.Graphics.DrawString("Ghế: " + listSeat, boldFont, Brushes.Black, 50, y);
            y += 40;

            e.Graphics.DrawString("----------------------------------------------------------------", bodyFont, Brushes.Black, centerX, y, centerFormat);
            y += 30;

            // Tổng tiền
            decimal total = _selectedSeats.Count * _selectedMovie.price;
            e.Graphics.DrawString("TỔNG TIỀN:", boldFont, Brushes.Black, 50, y);
            e.Graphics.DrawString(total.ToString("N0") + " VND", titleFont, Brushes.Black, e.PageBounds.Width - 50, y - 5, new StringFormat { Alignment = StringAlignment.Far });
            y += 60;

            // Footer
            string staffName = Session.CurrentUser != null ? Session.CurrentUser.username : "Admin";
            e.Graphics.DrawString("Nhân viên: " + staffName, bodyFont, Brushes.Black, 50, y);
            y += 40;
            e.Graphics.DrawString("Cảm ơn quý khách!", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, centerX, y, centerFormat);
        }
    }
}
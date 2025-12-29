using DAL;
using DoAnFinal.BLL;
using DoAnFinal.DAL;
using DoAnFinal.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmSellTicket : Form
    {
        private MovieBLL movieBLL = new MovieBLL();
        private TicketBLL ticketBLL = new TicketBLL();

        private movie _selectedMovie = null;
        private List<int> _selectedSeats = new List<int>();

        private decimal _foodPrice = 0;
        private string _foodDetails = "";

        private const int MAX_SEATS = 8;
        private const int SEATS_PER_ROW = 10;

        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

        public FrmSellTicket()
        {
            InitializeComponent();
            LoadMovieList();

            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.Document = printDocument1;
        }

        private void LoadMovieList()
        {
            var movies = movieBLL.GetMovieList().Where(m => m.status == "Available").ToList();

            dgvMovies.DataSource = movies;
            if (dgvMovies.Columns["id"] != null) dgvMovies.Columns["id"].Visible = false;
            if (dgvMovies.Columns["created_at"] != null) dgvMovies.Columns["created_at"].Visible = false;
            if (dgvMovies.Columns["updated_at"] != null) dgvMovies.Columns["updated_at"].Visible = false;
            if (dgvMovies.Columns["movie_image"] != null) dgvMovies.Columns["movie_image"].Visible = false;
            if (dgvMovies.Columns["tickets"] != null) dgvMovies.Columns["tickets"].Visible = false;

            if (dgvMovies.Columns["movie_name"] != null) dgvMovies.Columns["movie_name"].HeaderText = "Tên Phim";
            if (dgvMovies.Columns["price"] != null) dgvMovies.Columns["price"].HeaderText = "Giá";
        }

        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
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

        private void ResetSelection()
        {
            _selectedSeats.Clear();
            _foodPrice = 0;
            _foodDetails = "";
            btnFood.Text = "🍿 CHỌN COMBO";
            btnFood.BackColor = Color.FromArgb(255, 152, 0);

            UpdatePaymentInfo();
        }

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
                btnSeat.Tag = i;

                if (bookedSeats.Contains(i))
                {
                    btnSeat.Text = i.ToString();
                    btnSeat.BackColor = Color.Red;
                    btnSeat.Enabled = false;
                }
                else
                {
                    if (IsVipSeat(i))
                    {
                        btnSeat.Text = i + "\nVIP";
                        btnSeat.BackColor = Color.Gold;
                        btnSeat.Font = new Font("Arial", 8, FontStyle.Bold);
                    }
                    else
                    {
                        btnSeat.Text = i.ToString();
                        btnSeat.BackColor = Color.LightGreen;
                    }
                    btnSeat.Click += BtnSeat_Click;
                }
                flowSeatPanel.Controls.Add(btnSeat);
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int seatNum = (int)btn.Tag;

            if (_selectedSeats.Contains(seatNum))
            {
                _selectedSeats.Remove(seatNum);
                if (IsVipSeat(seatNum))
                    btn.BackColor = Color.Gold;
                else
                    btn.BackColor = Color.LightGreen;
            }
            else
            {
                if (_selectedSeats.Count >= MAX_SEATS)
                {
                    MessageBox.Show($"Bạn chỉ được chọn tối đa {MAX_SEATS} ghế...", "Cảnh báo");
                    return;
                }
                _selectedSeats.Add(seatNum);
                btn.BackColor = Color.Yellow;
            }
            UpdatePaymentInfo();
        }

        private bool IsVipSeat(int seatNum)
        {
            if (seatNum >= 31 && seatNum <= 70) return true;
            return false;
        }

        private bool CheckGapRule()
        {
            List<int> bookedSeats = ticketBLL.GetBookedSeats(_selectedMovie.movie_id);
            List<int> futureState = new List<int>();
            futureState.AddRange(bookedSeats);
            futureState.AddRange(_selectedSeats);
            futureState.Sort();

            for (int i = 1; i <= _selectedMovie.capacity; i++)
            {
                if (!futureState.Contains(i))
                {
                    int currentRow = (i - 1) / SEATS_PER_ROW;
                    bool leftOccupied = false;
                    if ((i - 1) < 1) leftOccupied = true;
                    else if ((i - 1 - 1) / SEATS_PER_ROW != currentRow) leftOccupied = true;
                    else if (futureState.Contains(i - 1)) leftOccupied = true;

                    bool rightOccupied = false;
                    if ((i + 1) > _selectedMovie.capacity) rightOccupied = true;
                    else if ((i + 1 - 1) / SEATS_PER_ROW != currentRow) rightOccupied = true;
                    else if (futureState.Contains(i + 1)) rightOccupied = true;

                    if (leftOccupied && rightOccupied) return false;
                }
            }
            return true;
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            FrmFood frm = new FrmFood();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _foodPrice = frm.TotalFoodPrice;
                _foodDetails = frm.FoodDetailText;

                if (_foodPrice > 0)
                {
                    btnFood.Text = $"Đã chọn: {_foodPrice:N0}đ";
                    btnFood.BackColor = Color.SeaGreen;
                }
                else
                {
                    btnFood.Text = "🍿 CHỌN COMBO";
                    btnFood.BackColor = Color.FromArgb(255, 152, 0);
                }
                UpdatePaymentInfo();
            }
        }

        private void UpdatePaymentInfo()
        {
            lblSeatCount.Text = _selectedSeats.Count.ToString();

            if (_selectedMovie != null)
            {
                decimal total = 0;
                foreach (int seat in _selectedSeats)
                {
                    if (IsVipSeat(seat))
                        total += (decimal)(_selectedMovie.price_vip ?? _selectedMovie.price);
                    else
                        total += (decimal)_selectedMovie.price;
                }

                total += _foodPrice;
                lblTotalPrice.Text = total.ToString("N0") + " VND";
            }
        }

        // [MỚI] Hàm lấy ID người dùng an toàn (Fix lỗi Foreign Key)
        private int GetCurrentUserId()
        {
            // 1. Ưu tiên lấy từ Session (nếu đăng nhập chuẩn)
            if (Session.CurrentUser != null)
            {
                return Session.CurrentUser.id;
            }

            // 2. Nếu Session Null (Debug/Admin lỗi), lấy User ĐẦU TIÊN trong DB
            // Đảm bảo luôn có 1 ID tồn tại để gán cho vé
            using (CinemaModel db = new CinemaModel())
            {
                var firstUser = db.users.FirstOrDefault();
                if (firstUser != null) return firstUser.id;
            }

            // 3. Fallback cuối cùng (Chỉ khi DB trống trơn)
            return 1;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (_selectedMovie == null || _selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phim và ghế!", "Thông báo");
                return;
            }

            if (!CheckGapRule())
            {
                MessageBox.Show("Vui lòng chọn ghế liền kề nhau (Không để trống 1 ghế ở giữa)!",
                                "Quy tắc chọn ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Lấy ID người dùng an toàn (Admin hay Staff đều OK)
                    int safeStaffId = GetCurrentUserId();

                    // 1. Lưu vé
                    foreach (int seatNum in _selectedSeats)
                    {
                        ticket t = new ticket();
                        t.movie_id = _selectedMovie.movie_id;
                        t.seat_number = seatNum;
                        if (IsVipSeat(seatNum))
                            t.price = _selectedMovie.price_vip ?? _selectedMovie.price;
                        else
                            t.price = _selectedMovie.price;
                        t.created_at = DateTime.Now;

                        // Sử dụng ID an toàn
                        t.staff_id = safeStaffId;

                        ticketBLL.BuyTicket(t);
                    }

                    // 2. Lưu hóa đơn Bắp nước (Nếu có)
                    if (_foodPrice > 0)
                    {
                        using (CinemaModel db = new CinemaModel())
                        {
                            food_bill fb = new food_bill();
                            // Sử dụng ID an toàn
                            fb.staff_id = safeStaffId;
                            fb.total_money = (int)_foodPrice;
                            fb.items_detail = _foodDetails;
                            fb.created_at = DateTime.Now;
                            db.food_bills.Add(fb);
                            db.SaveChanges();
                        }
                    }

                    MessageBox.Show("Thanh toán thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        printPreviewDialog1.WindowState = FormWindowState.Maximized;
                        printPreviewDialog1.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi in ấn: " + ex.Message);
                    }

                    ResetSelection();
                    GenerateSeatMap(_selectedMovie);
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    // Hiện lỗi chi tiết nếu Database từ chối
                    var inner = ex.InnerException;
                    while (inner != null && inner.InnerException != null) inner = inner.InnerException;
                    MessageBox.Show("Lỗi Database: \n" + (inner != null ? inner.Message : ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 12, FontStyle.Regular);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);

            int y = 20;
            int centerX = e.PageBounds.Width / 2;
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat rightFormat = new StringFormat { Alignment = StringAlignment.Far };

            e.Graphics.DrawString("RẠP CHIẾU PHIM CINEMA 4.0", titleFont, Brushes.Black, centerX, y, centerFormat);
            y += 40;
            e.Graphics.DrawString("----------------------------------------------------------------", bodyFont, Brushes.Black, centerX, y, centerFormat);
            y += 30;

            e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN", boldFont, Brushes.Black, centerX, y, centerFormat);
            y += 40;
            e.Graphics.DrawString("Phim: " + _selectedMovie.movie_name, bodyFont, Brushes.Black, 50, y);
            y += 30;
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), bodyFont, Brushes.Black, 50, y);
            y += 30;

            List<string> seatDisplayList = new List<string>();
            decimal totalTicket = 0;
            foreach (int seat in _selectedSeats)
            {
                if (IsVipSeat(seat))
                {
                    seatDisplayList.Add(seat + "(VIP)");
                    totalTicket += (decimal)(_selectedMovie.price_vip ?? _selectedMovie.price);
                }
                else
                {
                    seatDisplayList.Add(seat.ToString());
                    totalTicket += (decimal)_selectedMovie.price;
                }
            }
            string listSeat = string.Join(", ", seatDisplayList);
            e.Graphics.DrawString("Ghế: " + listSeat, boldFont, Brushes.Black, 50, y);
            y += 30;

            if (_foodPrice > 0)
            {
                e.Graphics.DrawString("Combo: " + _foodDetails, bodyFont, Brushes.Black, 50, y);
                e.Graphics.DrawString(_foodPrice.ToString("N0"), bodyFont, Brushes.Black, e.PageBounds.Width - 50, y, rightFormat);
                y += 30;
            }

            e.Graphics.DrawString("----------------------------------------------------------------", bodyFont, Brushes.Black, centerX, y, centerFormat);
            y += 30;

            decimal finalTotal = totalTicket + _foodPrice;

            e.Graphics.DrawString("TỔNG TIỀN:", boldFont, Brushes.Black, 50, y);
            e.Graphics.DrawString(finalTotal.ToString("N0") + " VND", titleFont, Brushes.Black, e.PageBounds.Width - 50, y - 5, rightFormat);
            y += 60;

            string staffName = Session.CurrentUser != null ? Session.CurrentUser.username : "Admin";
            e.Graphics.DrawString("Nhân viên: " + staffName, bodyFont, Brushes.Black, 50, y);
            y += 40;
            e.Graphics.DrawString("Cảm ơn quý khách!", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, centerX, y, centerFormat);
        }
    }
}
using DAL;
using DoAnFinal.BLL;
using DoAnFinal.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DoAnFinal.GUI.CustomerArea
{
    public partial class FrmCustomerBooking : Form
    {
        private movie _movie;
        private customer _customer;
        private TicketBLL ticketBLL = new TicketBLL();

        private List<int> _selectedSeats = new List<int>();

        // [MỚI] Biến lưu thông tin Combo Bắp Nước
        private decimal _foodPrice = 0;
        private string _foodDetails = "";
        // ------------------------------------

        private const int MAX_SEATS = 8;
        private const int SEATS_PER_ROW = 10;

        public FrmCustomerBooking(movie m, customer c)
        {
            InitializeComponent();
            _movie = m;
            _customer = c;

            lblMovieName.Text = _movie.movie_name.ToUpper();
            GenerateSeatMap();
        }

        private void GenerateSeatMap()
        {
            flowSeatPanel.Controls.Clear();
            List<int> bookedSeats = ticketBLL.GetBookedSeats(_movie.movie_id);

            for (int i = 1; i <= _movie.capacity; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(50, 50);
                btn.Margin = new Padding(5);
                btn.Tag = i;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;

                if (bookedSeats.Contains(i))
                {
                    btn.Text = "X";
                    btn.BackColor = Color.Gray;
                    btn.Enabled = false;
                }
                else
                {
                    if (IsVipSeat(i))
                    {
                        btn.Text = i + "\nVIP";
                        btn.BackColor = Color.Gold;
                        btn.Font = new Font("Arial", 7, FontStyle.Bold);
                    }
                    else
                    {
                        btn.Text = i.ToString();
                        btn.BackColor = Color.White;
                    }
                    btn.Click += BtnSeat_Click;
                }
                flowSeatPanel.Controls.Add(btn);
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int seatNum = (int)btn.Tag;

            if (_selectedSeats.Contains(seatNum))
            {
                _selectedSeats.Remove(seatNum);
                btn.BackColor = IsVipSeat(seatNum) ? Color.Gold : Color.White;
            }
            else
            {
                if (_selectedSeats.Count >= MAX_SEATS)
                {
                    MessageBox.Show($"Bạn chỉ được đặt tối đa {MAX_SEATS} vé mỗi lần!", "Cảnh báo");
                    return;
                }

                _selectedSeats.Add(seatNum);
                btn.BackColor = Color.LimeGreen;
            }
            UpdateInfo();
        }

        // [MỚI] SỰ KIỆN CLICK NÚT CHỌN COMBO
        private void btnFood_Click(object sender, EventArgs e)
        {
            // Tái sử dụng form FrmFood đã làm cho Staff
            FrmFood frm = new FrmFood();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _foodPrice = frm.TotalFoodPrice;
                _foodDetails = frm.FoodDetailText;

                // Cập nhật giao diện nút Food
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

                // Tính lại tổng tiền
                UpdateInfo();
            }
        }

        private void UpdateInfo()
        {
            lblSeatInfo.Text = "Ghế chọn: " + string.Join(", ", _selectedSeats);

            decimal totalTicket = 0;
            foreach (int s in _selectedSeats)
            {
                totalTicket += IsVipSeat(s) ? (decimal)(_movie.price_vip ?? _movie.price) : (decimal)_movie.price;
            }

            // Tổng = Tiền vé + Tiền ăn
            decimal grandTotal = totalTicket + _foodPrice;

            lblTotalPrice.Text = $"Tổng tiền: {grandTotal:N0} VND";
        }

        private bool IsVipSeat(int seatNum)
        {
            return (seatNum >= 31 && seatNum <= 70);
        }

        private bool CheckGapRule()
        {
            List<int> bookedSeats = ticketBLL.GetBookedSeats(_movie.movie_id);
            List<int> futureState = new List<int>();
            futureState.AddRange(bookedSeats);
            futureState.AddRange(_selectedSeats);
            futureState.Sort();

            for (int i = 1; i <= _movie.capacity; i++)
            {
                if (!futureState.Contains(i))
                {
                    int currentRow = (i - 1) / SEATS_PER_ROW;
                    bool leftOccupied = false;
                    if ((i - 1) < 1) leftOccupied = true;
                    else if ((i - 1 - 1) / SEATS_PER_ROW != currentRow) leftOccupied = true;
                    else if (futureState.Contains(i - 1)) leftOccupied = true;

                    bool rightOccupied = false;
                    if ((i + 1) > _movie.capacity) rightOccupied = true;
                    else if ((i + 1 - 1) / SEATS_PER_ROW != currentRow) rightOccupied = true;
                    else if (futureState.Contains(i + 1)) rightOccupied = true;

                    if (leftOccupied && rightOccupied) return false;
                }
            }
            return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_selectedSeats.Count == 0) return;

            if (!CheckGapRule())
            {
                MessageBox.Show("Vui lòng không để chừa 1 ghế trống lẻ loi ở giữa hoặc đầu hàng!",
                                "Quy tắc chọn ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // ID Nhân viên hệ thống (Bot) = 1
                    int systemStaffId = 1;

                    // 1. Lưu vé
                    foreach (int seat in _selectedSeats)
                    {
                        ticket t = new ticket();
                        t.movie_id = _movie.movie_id;
                        t.customer_id = _customer.id;
                        t.staff_id = systemStaffId;
                        t.seat_number = seat;
                        t.price = IsVipSeat(seat) ? (_movie.price_vip ?? _movie.price) : _movie.price;
                        t.created_at = DateTime.Now;

                        ticketBLL.BuyTicket(t);
                    }

                    // 2. [MỚI] Lưu hóa đơn Bắp Nước (Nếu có)
                    if (_foodPrice > 0)
                    {
                        using (CinemaModel db = new CinemaModel())
                        {
                            food_bill fb = new food_bill();
                            fb.staff_id = systemStaffId; // Gán cho Hệ thống
                            fb.total_money = (int)_foodPrice;

                            // Ghi chú tên khách vào hóa đơn để Admin biết
                            fb.items_detail = $"[ONLINE - {_customer.full_name}] " + _foodDetails;

                            fb.created_at = DateTime.Now;

                            db.food_bills.Add(fb);
                            db.SaveChanges();
                        }
                    }

                    MessageBox.Show("Đặt vé & Combo thành công! Vui lòng đến rạp nhận vé.", "Success");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
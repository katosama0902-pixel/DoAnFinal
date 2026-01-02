using DAL;
using DoAnFinal.BLL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DoAnFinal.GUI.CustomerArea
{
    public partial class FrmCustomerHome : Form
    {
        private customer _currentCustomer;
        private MovieBLL movieBLL = new MovieBLL();

        public FrmCustomerHome(customer cus)
        {
            InitializeComponent();
            _currentCustomer = cus;

            // Tải giao diện và Phim
            SetupUI();
            LoadMovies();
        }

        private void SetupUI()
        {
            // [CẬP NHẬT] Kiểm tra bằng SĐT "GUEST" thay vì ID -1
            if (_currentCustomer.phone_number == "GUEST")
            {
                // --- CHẾ ĐỘ KHÁCH ---
                lblWelcome.Text = "Xin chào, Khách Vãng Lai (Chế độ Khách)";
                lblWelcome.ForeColor = Color.Silver;

                // KHÓA TÍNH NĂNG LỊCH SỬ
                btnHistory.Enabled = false;
                btnHistory.Text = "🔒 Lịch sử";
                btnHistory.BackColor = Color.Gray;
            }
            else
            {
                // --- CHẾ ĐỘ THÀNH VIÊN ---
                lblWelcome.Text = $"Xin chào, {_currentCustomer.full_name} ({_currentCustomer.points ?? 0} điểm)";

                // Mở tính năng
                btnHistory.Enabled = true;
                btnHistory.Text = "Lịch sử";
                btnHistory.BackColor = Color.SteelBlue;
            }
        }

        private void LoadMovies()
        {
            flowMoviePanel.Controls.Clear();
            var movies = movieBLL.GetMovieList().Where(m => m.status == "Available").ToList();
            string imageFolderPath = Path.Combine(Application.StartupPath, "Images");

            foreach (var m in movies)
            {
                Panel card = new Panel();
                card.Size = new Size(220, 360);
                card.BackColor = Color.FromArgb(45, 45, 45);
                card.Margin = new Padding(15);

                Control imageControl;
                string fullPath = Path.Combine(imageFolderPath, m.movie_image ?? "");

                if (!string.IsNullOrEmpty(m.movie_image) && File.Exists(fullPath))
                {
                    PictureBox pic = new PictureBox();
                    pic.Size = new Size(200, 250);
                    pic.Location = new Point(10, 10);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Image = Image.FromFile(fullPath);
                    imageControl = pic;
                }
                else
                {
                    Panel pnlPlaceholder = new Panel();
                    pnlPlaceholder.Size = new Size(200, 250);
                    pnlPlaceholder.Location = new Point(10, 10);
                    pnlPlaceholder.BackColor = GetRandomColor();

                    Label lblIcon = new Label();
                    lblIcon.Text = string.IsNullOrEmpty(m.movie_name) ? "?" : m.movie_name.Substring(0, 1).ToUpper();
                    lblIcon.Font = new Font("Arial", 50, FontStyle.Bold);
                    lblIcon.ForeColor = Color.White;
                    lblIcon.AutoSize = false;
                    lblIcon.Dock = DockStyle.Fill;
                    lblIcon.TextAlign = ContentAlignment.MiddleCenter;

                    pnlPlaceholder.Controls.Add(lblIcon);
                    imageControl = pnlPlaceholder;
                }

                Label lblName = new Label();
                lblName.Text = m.movie_name;
                lblName.ForeColor = Color.White;
                lblName.Font = new Font("Arial", 11, FontStyle.Bold);
                lblName.AutoSize = false;
                lblName.Size = new Size(200, 40);
                lblName.Location = new Point(10, 270);
                lblName.TextAlign = ContentAlignment.TopCenter;

                Label lblPrice = new Label();
                lblPrice.Text = string.Format("{0:N0} đ", m.price);
                lblPrice.ForeColor = Color.Gold;
                lblPrice.Font = new Font("Arial", 10, FontStyle.Regular);
                lblPrice.AutoSize = false;
                lblPrice.Size = new Size(200, 20);
                lblPrice.Location = new Point(10, 310);
                lblPrice.TextAlign = ContentAlignment.MiddleCenter;

                Button btnBook = new Button();
                btnBook.Text = "ĐẶT VÉ";
                btnBook.Size = new Size(100, 30);
                btnBook.Location = new Point(60, 330);
                btnBook.BackColor = Color.FromArgb(229, 9, 20);
                btnBook.ForeColor = Color.White;
                btnBook.FlatStyle = FlatStyle.Flat;
                btnBook.FlatAppearance.BorderSize = 0;
                btnBook.Tag = m;
                btnBook.Click += BtnBook_Click;

                card.Controls.Add(imageControl);
                card.Controls.Add(lblName);
                card.Controls.Add(lblPrice);
                card.Controls.Add(btnBook);

                flowMoviePanel.Controls.Add(card);
            }
        }

        private Random rand = new Random();
        private Color GetRandomColor()
        {
            return Color.FromArgb(rand.Next(50, 150), rand.Next(50, 150), rand.Next(50, 150));
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            movie selectedMovie = (movie)btn.Tag;

            FrmCustomerBooking frm = new FrmCustomerBooking(selectedMovie, _currentCustomer);
            frm.ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            // [CẬP NHẬT] Chặn nếu là GUEST (dựa trên SĐT)
            if (_currentCustomer.phone_number == "GUEST") return;

            using (var db = new CinemaModel())
            {
                var refreshedCustomer = db.customers.Find(_currentCustomer.id);
                if (refreshedCustomer != null)
                {
                    _currentCustomer = refreshedCustomer;
                }
            }

            FrmTransactionHistory frm = new FrmTransactionHistory(_currentCustomer);
            frm.ShowDialog();

            SetupUI();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
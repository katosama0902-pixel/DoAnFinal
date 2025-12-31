using DAL;
using DoAnFinal.BLL;
using System;
using System.Drawing;
using System.IO; // [QUAN TRỌNG] Thêm thư viện này để xử lý file ảnh
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
            SetupUI();
            LoadMovies();
        }

        private void SetupUI()
        {
            lblWelcome.Text = $"Xin chào, {_currentCustomer.full_name} ({_currentCustomer.points} điểm)";
        }

        private void LoadMovies()
        {
            flowMoviePanel.Controls.Clear();
            var movies = movieBLL.GetMovieList().Where(m => m.status == "Available").ToList();

            // Đường dẫn đến thư mục ảnh (Nằm trong bin/Debug/Images)
            string imageFolderPath = Path.Combine(Application.StartupPath, "Images");

            foreach (var m in movies)
            {
                // Tạo Card Phim
                Panel card = new Panel();
                card.Size = new Size(220, 360); // Tăng chiều cao xíu để chứa ảnh đẹp hơn
                card.BackColor = Color.FromArgb(45, 45, 45);
                card.Margin = new Padding(15);

                // --- 1. XỬ LÝ ẢNH POSTER ---
                Control imageControl;
                string fullPath = Path.Combine(imageFolderPath, m.movie_image ?? "");

                // Kiểm tra: Nếu có tên file VÀ file đó tồn tại trong thư mục Images
                if (!string.IsNullOrEmpty(m.movie_image) && File.Exists(fullPath))
                {
                    PictureBox pic = new PictureBox();
                    pic.Size = new Size(200, 250); // Ảnh lớn chiếm phần lớn card
                    pic.Location = new Point(10, 10);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage; // Co giãn ảnh cho vừa khung
                    pic.Image = Image.FromFile(fullPath);
                    imageControl = pic;
                }
                else
                {
                    // [FALLBACK] Nếu không có ảnh -> Dùng lại cách cũ (Panel màu + Chữ cái đầu)
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
                // ---------------------------

                // 2. Tên Phim
                Label lblName = new Label();
                lblName.Text = m.movie_name;
                lblName.ForeColor = Color.White;
                lblName.Font = new Font("Arial", 11, FontStyle.Bold);
                lblName.AutoSize = false;
                lblName.Size = new Size(200, 40); // Giới hạn chiều cao tên
                lblName.Location = new Point(10, 270); // Nằm dưới ảnh
                lblName.TextAlign = ContentAlignment.TopCenter;

                // 3. Giá vé
                Label lblPrice = new Label();
                lblPrice.Text = string.Format("{0:N0} đ", m.price);
                lblPrice.ForeColor = Color.Gold;
                lblPrice.Font = new Font("Arial", 10, FontStyle.Regular);
                lblPrice.AutoSize = false;
                lblPrice.Size = new Size(200, 20);
                lblPrice.Location = new Point(10, 310);
                lblPrice.TextAlign = ContentAlignment.MiddleCenter;

                // 4. Nút Đặt Vé (Làm trong suốt phủ lên trên hoặc nút nhỏ bên dưới)
                // Ở đây mình làm nút nhỏ gọn đè lên góc ảnh hoặc dưới cùng
                Button btnBook = new Button();
                btnBook.Text = "ĐẶT VÉ";
                btnBook.Size = new Size(100, 30);
                btnBook.Location = new Point(60, 330); // Căn giữa dưới cùng
                btnBook.BackColor = Color.FromArgb(229, 9, 20);
                btnBook.ForeColor = Color.White;
                btnBook.FlatStyle = FlatStyle.Flat;
                btnBook.FlatAppearance.BorderSize = 0;
                btnBook.Tag = m;
                btnBook.Click += BtnBook_Click;

                // Add controls vào Card
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
            return Color.FromArgb(rand.Next(50, 150), rand.Next(50, 150), rand.Next(50, 150)); // Màu tối hơn chút cho hợp nền
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            movie selectedMovie = (movie)btn.Tag;

            // Gọi form đặt vé
            FrmCustomerBooking frm = new FrmCustomerBooking(selectedMovie, _currentCustomer);
            frm.ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            // Cần tải lại dữ liệu khách hàng từ Database để cập nhật điểm mới nhất (nếu khách vừa đặt vé xong)
            using (var db = new CinemaModel())
            {
                // Tìm lại khách hàng theo ID hiện tại
                var refreshedCustomer = db.customers.Find(_currentCustomer.id);

                if (refreshedCustomer != null)
                {
                    _currentCustomer = refreshedCustomer; // Cập nhật lại biến toàn cục
                }
            }

            // Mở Form Lịch sử
            FrmTransactionHistory frm = new FrmTransactionHistory(_currentCustomer);
            frm.ShowDialog();

            // Sau khi tắt form lịch sử, cập nhật lại dòng "Xin chào... (xx điểm)" trên góc phải
            SetupUI();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
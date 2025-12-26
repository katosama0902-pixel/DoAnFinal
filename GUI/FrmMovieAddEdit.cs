using DAL;
using DoAnFinal.BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmMovieAddEdit : Form
    {
        private MovieBLL movieBLL = new MovieBLL();
        private int _movieId = 0; // Nếu = 0 là Thêm mới, > 0 là Sửa
        private string _selectedImagePath = ""; // Đường dẫn ảnh vừa chọn

        // Constructor nhận ID (nếu không truyền gì thì mặc định là 0)
        public FrmMovieAddEdit(int id = 0)
        {
            InitializeComponent();
            _movieId = id;

            // Nếu là chế độ Sửa
            if (_movieId > 0)
            {
                lblTitle.Text = "CẬP NHẬT PHIM";
                LoadMovieData();
            }
            else
            {
                lblTitle.Text = "THÊM PHIM MỚI";
                cboStatus.SelectedIndex = 0; // Mặc định Available
                cboGenre.SelectedIndex = 0;
            }
        }

        private void LoadMovieData()
        {
            var movie = movieBLL.GetMovieById(_movieId);
            if (movie != null)
            {
                txtMovieID.Text = movie.movie_id;
                txtMovieName.Text = movie.movie_name;
                cboGenre.Text = movie.genre;
                txtPrice.Text = movie.price.ToString("0.##"); // Bỏ số 0 thừa
                txtCapacity.Text = movie.capacity.ToString();
                cboStatus.Text = movie.status;

                // Load ảnh
                if (!string.IsNullOrEmpty(movie.movie_image))
                {
                    string folderPath = Path.Combine(Application.StartupPath, "MovieImages");
                    string fullPath = Path.Combine(folderPath, movie.movie_image);

                    if (File.Exists(fullPath))
                    {
                        picMovie.Image = Image.FromFile(fullPath);
                    }
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = open.FileName;
                picMovie.Image = Image.FromFile(_selectedImagePath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate cơ bản
            if (string.IsNullOrEmpty(txtMovieID.Text) || string.IsNullOrEmpty(txtMovieName.Text)
                || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtCapacity.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // 2. Xử lý lưu ảnh vào thư mục dự án
            string imageName = null;
            if (!string.IsNullOrEmpty(_selectedImagePath))
            {
                string folderPath = Path.Combine(Application.StartupPath, "MovieImages");
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                // Tạo tên file ngẫu nhiên để tránh trùng (dùng GUID)
                string extension = Path.GetExtension(_selectedImagePath);
                imageName = Guid.NewGuid().ToString() + extension;

                // Copy file
                string destPath = Path.Combine(folderPath, imageName);
                File.Copy(_selectedImagePath, destPath, true);
            }

            // 3. Tạo đối tượng Movie
            movie mv = new movie();
            mv.movie_id = txtMovieID.Text;
            mv.movie_name = txtMovieName.Text;
            mv.genre = cboGenre.Text;
            mv.price = decimal.Parse(txtPrice.Text);
            mv.capacity = int.Parse(txtCapacity.Text);
            mv.status = cboStatus.Text;
            mv.updated_at = DateTime.Now;

            // Nếu người dùng chọn ảnh mới thì mới cập nhật tên ảnh
            if (imageName != null) mv.movie_image = imageName;

            try
            {
                if (_movieId == 0) // THÊM MỚI
                {
                    mv.created_at = DateTime.Now;
                    movieBLL.AddMovie(mv);
                    MessageBox.Show("Thêm phim thành công!");
                }
                else // CẬP NHẬT
                {
                    mv.id = _movieId;
                    movieBLL.UpdateMovie(mv);
                    MessageBox.Show("Cập nhật phim thành công!");
                }

                this.Close(); // Đóng form dialog
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
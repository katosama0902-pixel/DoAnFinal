using DoAnFinal.BLL;
using System;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmMovieManager : Form
    {
        private MovieBLL movieBLL = new MovieBLL();

        public FrmMovieManager()
        {
            InitializeComponent();
            LoadMovieList();

            // --- Thêm đoạn này để làm Placeholder giả ---
            txtSearch.Text = "Tìm tên phim...";
            txtSearch.ForeColor = System.Drawing.Color.Gray;

            txtSearch.Enter += (s, e) => {
                if (txtSearch.Text == "Tìm tên phim...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = System.Drawing.Color.Black;
                }
            };

            txtSearch.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Tìm tên phim...";
                    txtSearch.ForeColor = System.Drawing.Color.Gray;
                }
            };
            // -------------------------------------------
        }

        // Hàm load dữ liệu lên Grid
        private void LoadMovieList()
        {
            var list = movieBLL.GetMovieList();

            // Dùng BindingSource để tránh lỗi data
            BindingSource source = new BindingSource();
            source.DataSource = list;
            dgvMovies.DataSource = source;

            // Ẩn bớt các cột không cần thiết (Nếu muốn)
            if (dgvMovies.Columns["tickets"] != null) dgvMovies.Columns["tickets"].Visible = false;
        }

        // Sự kiện tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            dgvMovies.DataSource = movieBLL.SearchMovie(keyword);
        }

        // Sự kiện Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count > 0)
            {
                // Lấy ID của dòng đang chọn
                int id = Convert.ToInt32(dgvMovies.SelectedRows[0].Cells["id"].Value);
                string name = dgvMovies.SelectedRows[0].Cells["movie_name"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc muốn ngừng chiếu phim '{name}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (movieBLL.DeleteMovie(id))
                    {
                        MessageBox.Show("Đã cập nhật trạng thái phim thành công!");
                        LoadMovieList(); // Load lại bảng
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bộ phim để xóa!");
            }
        }

        // 1. Nút THÊM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Mở Dialog với ID = 0
            FrmMovieAddEdit frm = new FrmMovieAddEdit(0);
            frm.ShowDialog();

            // Sau khi đóng dialog thì load lại danh sách để thấy phim mới
            LoadMovieList();
        }

        // 2. Nút SỬA
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count > 0)
            {
                // Lấy ID dòng đang chọn
                int id = Convert.ToInt32(dgvMovies.SelectedRows[0].Cells["id"].Value);

                // Mở Dialog với ID lấy được
                FrmMovieAddEdit frm = new FrmMovieAddEdit(id);
                frm.ShowDialog();

                LoadMovieList(); // Load lại danh sách sau khi sửa
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phim cần sửa!");
            }
        }
    }
}
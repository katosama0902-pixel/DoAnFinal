using DAL; // Để dùng CinemaModel
using DoAnFinal.DAL; // Để dùng class customer
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoAnFinal.GUI.CustomerArea
{
    public partial class FrmRegisterCustomer : Form
    {
        public FrmRegisterCustomer()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Lấy thông tin
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string pass = txtPass.Text.Trim();
            string confirm = txtConfirmPass.Text.Trim();

            // 2. Validate cơ bản
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo");
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi");
                return;
            }

            // 3. Xử lý Database
            using (var db = new CinemaModel())
            {
                // Kiểm tra SĐT đã tồn tại chưa
                var exist = db.customers.FirstOrDefault(c => c.phone_number == phone);
                if (exist != null)
                {
                    MessageBox.Show("Số điện thoại này đã được đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo khách hàng mới
                customer newCus = new customer();
                newCus.full_name = name;
                newCus.phone_number = phone;
                newCus.password = pass; // Nếu cần bảo mật cao hơn thì dùng MD5 hash ở đây
                newCus.points = 0;      // Điểm khởi tạo = 0
                newCus.created_at = DateTime.Now;

                db.customers.Add(newCus);
                db.SaveChanges();

                MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form đăng ký để quay về login
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
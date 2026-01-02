using DAL;
using DoAnFinal.Helper;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DoAnFinal.GUI.CustomerArea
{
    public partial class FrmLoginCustomer : Form
    {
        public FrmLoginCustomer()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            using (var db = new CinemaModel())
            {
                var cus = db.customers.FirstOrDefault(c => c.phone_number == phone && c.password == pass);

                if (cus != null)
                {
                    MessageBox.Show($"Xin chào, {cus.full_name}!", "Đăng nhập thành công");
                    this.Hide();
                    FrmCustomerHome home = new FrmCustomerHome(cus);
                    home.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai số điện thoại hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // [CẬP NHẬT] SỰ KIỆN NÚT KHÁCH VÃNG LAI (Fix lỗi thanh toán)
        private void btnGuest_Click(object sender, EventArgs e)
        {
            customer guestCus = null;

            using (var db = new CinemaModel())
            {
                // 1. Tìm xem trong Database đã có tài khoản "GUEST" chưa
                // (Chúng ta dùng số điện thoại "GUEST" để nhận diện)
                guestCus = db.customers.FirstOrDefault(c => c.phone_number == "GUEST");

                // 2. Nếu chưa có thì TẠO MỚI ngay lập tức
                if (guestCus == null)
                {
                    guestCus = new customer();
                    guestCus.full_name = "Khách Vãng Lai";
                    guestCus.phone_number = "GUEST"; // Đánh dấu đặc biệt
                    guestCus.password = "guest123";  // Mật khẩu ngẫu nhiên
                    guestCus.points = 0;

                    db.customers.Add(guestCus);
                    db.SaveChanges(); // Lưu vào DB để sinh ra ID thật
                }
            }

            MessageBox.Show("Đang truy cập với tư cách Khách...\n(Một số tính năng sẽ bị hạn chế)", "Chế độ Khách", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            // Lúc này guestCus đã có ID thật trong DB nên thanh toán sẽ thành công
            FrmCustomerHome home = new FrmCustomerHome(guestCus);
            home.ShowDialog();
            this.Show();
        }

        private void lnkForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRecovery frm = new FrmRecovery();
            frm.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegisterCustomer frm = new FrmRegisterCustomer();
            frm.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
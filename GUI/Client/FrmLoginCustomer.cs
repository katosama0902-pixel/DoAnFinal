using DAL; // Để dùng CinemaModel
using DoAnFinal.Helper; // (Nếu bạn có dùng HashHelper, không thì so sánh chuỗi thường)
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
                // Kiểm tra trong bảng CUSTOMERS (Không phải bảng USERS)
                var cus = db.customers.FirstOrDefault(c => c.phone_number == phone && c.password == pass);

                if (cus != null)
                {
                    MessageBox.Show($"Xin chào, {cus.full_name}!", "Đăng nhập thành công");

                    // Lưu Session khách hàng (Cần tạo thêm biến lưu session này nếu muốn dùng toàn cục)
                    // VD: ClientSession.CurrentCustomer = cus;

                    this.Hide();
                    // Mở trang chủ khách hàng (Sẽ làm ở bước sau)
                    // new FrmCustomerHome(cus).Show(); 

                    // Mở trang chủ và truyền thông tin khách hàng vào
                    FrmCustomerHome home = new FrmCustomerHome(cus);
                    home.ShowDialog();

                    // Khi trang chủ đóng lại thì hiện lại form login (hoặc đóng luôn tuỳ logic)
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai số điện thoại hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Mở form đăng ký dưới dạng Dialog (Cửa sổ con)
            FrmRegisterCustomer frm = new FrmRegisterCustomer();
            frm.ShowDialog();
            // Khi form đăng ký đóng lại, người dùng sẽ quay lại màn hình Login này
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form để quay lại FrmStartup
        }
    }
}
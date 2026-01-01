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
            // (Giữ nguyên code cũ của bạn...)
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

        // [MỚI] Sự kiện bấm nút Quên mật khẩu
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
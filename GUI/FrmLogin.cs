using DoAnFinal.BLL;
using DoAnFinal.DAL; // Để dùng class user
using DoAnFinal.Helper; // Để dùng Session
using System;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmLogin : Form
    {
        private UserBLL userBLL = new UserBLL();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            var user = userBLL.Login(username, password);

            if (user != null)
            {
                // Lưu user vào Session
                Session.CurrentUser = user;

                MessageBox.Show("Đăng nhập thành công! Vai trò: " + user.role, "Thông báo");

                if (user.role == "Admin")
                {
                    new FrmMainAdmin().Show();
                }
                else if (user.role == "Staff")
                {
                    new FrmMainStaff().Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- SỰ KIỆN QUÊN MẬT KHẨU ---
        private void lnkForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRecovery frm = new FrmRecovery();
            frm.ShowDialog();
        }
        // ------------------------------------

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
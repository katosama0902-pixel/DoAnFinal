using DoAnFinal.BLL;
using DoAnFinal.DAL;
using DoAnFinal.Helper;
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

                // [FIX QUAN TRỌNG] Thay vì mở form Main ở đây, ta chỉ báo kết quả OK
                this.DialogResult = DialogResult.OK;
                this.Close(); // Đóng form Login lại để FrmStartup xử lý tiếp
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRecovery frm = new FrmRecovery();
            frm.ShowDialog();
        }

        // Nút Quay lại / Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            // [FIX] Báo Cancel để FrmStartup biết là người dùng không muốn đăng nhập nữa
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
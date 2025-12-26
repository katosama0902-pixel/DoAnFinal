using DoAnFinal.BLL; // Gọi lớp BLL với namespace mới
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

            // Gọi hàm Login từ lớp BLL
            var user = userBLL.Login(username, password);

            if (user != null)
            {
                // Lưu user vào Session
                DoAnFinal.Helper.Session.CurrentUser = user;

                MessageBox.Show("Đăng nhập thành công! Xin chào " + user.role, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau này khi có FrmMainAdmin/FrmMainStaff thì mở comment này ra

                // Trong FrmLogin.cs -> btnLogin_Click
                if (user.role == "Admin")
                {
                    MessageBox.Show("Chào Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new FrmMainAdmin().Show(); // Mở form Main Admin
                    this.Hide();               // Ẩn form Login
                }
                else if (user.role == "Staff")
                {
                    MessageBox.Show("Hello Staff!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new FrmMainStaff().Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            // Hiện/Ẩn mật khẩu
            txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '*';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
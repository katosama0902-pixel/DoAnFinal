using DoAnFinal.BLL;
using DoAnFinal.DAL; // Để dùng class users
using DoAnFinal.Helper;
using System;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmChangePassword : Form
    {
        private UserBLL userBLL = new UserBLL();

        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(txtOldPass.Text) || string.IsNullOrEmpty(txtNewPass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!"); return;
            }

            // 2. Kiểm tra mật khẩu cũ có đúng không
            // Lấy user hiện tại từ Session
            var currentUser = Session.CurrentUser;
            string oldPassHash = HashHelper.HashPassword(txtOldPass.Text);

            if (currentUser.password != oldPassHash)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Kiểm tra mật khẩu mới và nhập lại
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Thực hiện đổi mật khẩu
            try
            {
                // Gọi hàm UpdateUser của BLL (Hàm này chúng ta đã viết lúc làm module Staff)
                // Lưu ý: Hàm UpdateUser của BLL nhận vào (User object, RawNewPassword)
                userBLL.UpdateUser(currentUser, txtNewPass.Text);

                // Cập nhật lại Session để phiên làm việc hiện tại có pass mới luôn
                Session.CurrentUser.password = HashHelper.HashPassword(txtNewPass.Text);

                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                this.Close();
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
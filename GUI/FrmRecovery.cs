using DoAnFinal.BLL;
using DoAnFinal.DAL;
using DoAnFinal.Helper; // Gọi MailHelper ở đây
using System;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmRecovery : Form
    {
        private UserBLL userBLL = new UserBLL();
        private string _otpCode = ""; // Lưu mã OTP hệ thống tạo ra để so sánh
        private int _userId = 0; // Lưu ID người dùng tìm được

        public FrmRecovery()
        {
            InitializeComponent();
        }

        // BƯỚC 1: Tìm Email & Gửi OTP
        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email)) { MessageBox.Show("Vui lòng nhập Email!"); return; }

            // Tìm user có email này
            var u = userBLL.GetUserByEmail(email);
            if (u == null)
            {
                MessageBox.Show("Email này không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _userId = u.id; // Lưu lại ID

            // Tạo mã OTP ngẫu nhiên 6 số
            Random rand = new Random();
            _otpCode = rand.Next(100000, 999999).ToString();

            // Gửi Email
            string subject = "[CINEMA APP] MÃ XÁC THỰC KHÔI PHỤC MẬT KHẨU";
            string body = $"Xin chào {u.username},<br/>Mã OTP của bạn là: <b style='color:red; font-size:20px'>{_otpCode}</b>.<br/>Vui lòng không chia sẻ mã này cho ai.";

            bool isSent = MailHelper.SendMail(email, subject, body);

            if (isSent)
            {
                MessageBox.Show("Đã gửi mã OTP. Vui lòng kiểm tra Email!", "Thông báo");
                panelStep2.Visible = true; // Hiện bước nhập OTP
                panelStep1.Enabled = false; // Khóa bước nhập Email
            }
            else
            {
                MessageBox.Show("Gửi mail thất bại! Vui lòng kiểm tra kết nối mạng.", "Lỗi");
            }
        }

        // BƯỚC 2: Kiểm tra OTP
        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text.Trim() == _otpCode)
            {
                MessageBox.Show("Xác thực thành công! Mời nhập mật khẩu mới.", "Thông báo");
                panelStep3.Visible = true; // Hiện bước nhập Pass mới
                panelStep2.Enabled = false;
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BƯỚC 3: Lưu mật khẩu mới
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPass.Text)) return;

            try
            {
                userBLL.ResetPassword(_userId, txtNewPass.Text.Trim());
                MessageBox.Show("Đổi mật khẩu thành công! Hãy đăng nhập lại.", "Success");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
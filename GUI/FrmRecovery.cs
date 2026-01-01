using DAL;
using DoAnFinal.BLL;
using DoAnFinal.DAL;
using DoAnFinal.Helper; // Gọi MailHelper
using System;
using System.Linq; // Cần thêm thư viện này để query Database
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmRecovery : Form
    {
        private UserBLL userBLL = new UserBLL();
        private string _otpCode = "";
        private int _targetId = 0; // ID người cần đổi pass
        private bool _isCustomer = false; // Biến cờ: Đánh dấu là Khách hay Nhân viên

        public FrmRecovery()
        {
            InitializeComponent();
        }

        // BƯỚC 1: Tìm Email & Gửi OTP (Tìm cả 2 bảng)
        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email)) { MessageBox.Show("Vui lòng nhập Email!"); return; }

            string recipientName = "";

            // 1. Kiểm tra trong bảng USERS (Nhân viên/Admin) trước
            var u = userBLL.GetUserByEmail(email);

            if (u != null)
            {
                _targetId = u.id;
                _isCustomer = false; // Đây là nhân viên
                recipientName = u.username;
            }
            else
            {
                // 2. Nếu không thấy -> Kiểm tra trong bảng CUSTOMERS (Khách hàng)
                using (var db = new CinemaModel())
                {
                    var cus = db.customers.FirstOrDefault(c => c.email == email);
                    if (cus != null)
                    {
                        _targetId = cus.id;
                        _isCustomer = true; // Đây là khách hàng
                        recipientName = cus.full_name;
                    }
                    else
                    {
                        MessageBox.Show("Email này không tồn tại trong hệ thống (cả Nhân viên và Khách hàng)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // 3. Gửi Email OTP
            Random rand = new Random();
            _otpCode = rand.Next(100000, 999999).ToString();

            string subject = "[CINEMA APP] MÃ XÁC THỰC KHÔI PHỤC MẬT KHẨU";
            string body = $"Xin chào <b>{recipientName}</b>,<br/>" +
                          $"Bạn đang yêu cầu cấp lại mật khẩu cho tài khoản {(_isCustomer ? "Khách hàng" : "Nhân viên")}.<br/>" +
                          $"Mã OTP của bạn là: <b style='color:red; font-size:24px'>{_otpCode}</b>.<br/>" +
                          $"Vui lòng không chia sẻ mã này cho ai.";

            bool isSent = MailHelper.SendMail(email, subject, body);

            if (isSent)
            {
                MessageBox.Show("Đã gửi mã OTP. Vui lòng kiểm tra Email!", "Thông báo");
                panelStep2.Visible = true;
                panelStep1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Gửi mail thất bại! Vui lòng kiểm tra kết nối mạng.", "Lỗi");
            }
        }

        // BƯỚC 2: Kiểm tra OTP (Giữ nguyên)
        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text.Trim() == _otpCode)
            {
                MessageBox.Show("Xác thực thành công! Mời nhập mật khẩu mới.", "Thông báo");
                panelStep3.Visible = true;
                panelStep2.Enabled = false;
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BƯỚC 3: Lưu mật khẩu mới (Xử lý riêng cho từng loại)
        private void btnSave_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPass.Text.Trim();
            if (string.IsNullOrEmpty(newPass)) return;

            try
            {
                if (_isCustomer)
                {
                    // --- LƯU CHO KHÁCH HÀNG ---
                    using (var db = new CinemaModel())
                    {
                        var cus = db.customers.Find(_targetId);
                        if (cus != null)
                        {
                            cus.password = newPass; // Lưu mật khẩu mới
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    // --- LƯU CHO NHÂN VIÊN ---
                    userBLL.ResetPassword(_targetId, newPass);
                }

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
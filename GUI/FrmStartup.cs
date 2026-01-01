using DoAnFinal.Helper; // Để dùng Session
using System;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmStartup : Form
    {
        public FrmStartup()
        {
            InitializeComponent();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmLogin frm = new FrmLogin();
            // [FIX QUAN TRỌNG] Chờ FrmLogin đóng lại và lấy kết quả
            DialogResult result = frm.ShowDialog();

            // Nếu đăng nhập thành công (OK)
            if (result == DialogResult.OK)
            {
                Form mainForm = null;

                // Kiểm tra quyền để mở form tương ứng
                if (Session.CurrentUser.role == "Admin")
                {
                    mainForm = new FrmMainAdmin();
                }
                else if (Session.CurrentUser.role == "Staff")
                {
                    mainForm = new FrmMainStaff();
                }

                // Mở Form Main và CHỜ (ShowDialog) cho đến khi nó đóng (Logout)
                if (mainForm != null)
                {
                    this.Hide(); // Đảm bảo Startup vẫn ẩn
                    mainForm.ShowDialog();
                }
            }

            // [FIX] Dòng này chỉ chạy khi:
            // 1. Người dùng bấm "Quay lại" ở FrmLogin (Cancel)
            // 2. HOẶC Người dùng bấm "Đăng xuất" ở FrmMain (Form Main đóng lại)
            this.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerArea.FrmLoginCustomer frm = new CustomerArea.FrmLoginCustomer();
            frm.ShowDialog();
            this.Show();
        }
    }
}
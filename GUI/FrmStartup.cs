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
            // Mở form đăng nhập cũ (Dành cho Admin/Staff)
            this.Hide();
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
            this.Show(); // Hiện lại form chào khi tắt form kia
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Gọi form trong namespace con
            CustomerArea.FrmLoginCustomer frm = new CustomerArea.FrmLoginCustomer();
            frm.ShowDialog();
            this.Show();
        }
    }
}
using DoAnFinal.BLL;
using System;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmCustomerManager : Form
    {
        private CustomerBLL cusBLL = new CustomerBLL();

        public FrmCustomerManager()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvCustomer.DataSource = cusBLL.GetListCustomer();

            // Ẩn cột vé nếu EF tự sinh ra (Relationship)
            if (dgvCustomer.Columns["tickets"] != null) dgvCustomer.Columns["tickets"].Visible = false;

            // Đặt tên cột tiếng Việt cho đẹp
            if (dgvCustomer.Columns["full_name"] != null) dgvCustomer.Columns["full_name"].HeaderText = "Họ và tên";
            if (dgvCustomer.Columns["phone_number"] != null) dgvCustomer.Columns["phone_number"].HeaderText = "SĐT";
            if (dgvCustomer.Columns["points"] != null) dgvCustomer.Columns["points"].HeaderText = "Điểm";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCustomerAddEdit frm = new FrmCustomerAddEdit(0);
            frm.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["id"].Value);
                FrmCustomerAddEdit frm = new FrmCustomerAddEdit(id);
                frm.ShowDialog();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["id"].Value);
                string name = dgvCustomer.SelectedRows[0].Cells["full_name"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc muốn xóa khách hàng '{name}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cusBLL.DeleteCustomer(id);
                    LoadData();
                }
            }
        }
    }
}
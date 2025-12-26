using DoAnFinal.BLL;
using System;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmStaffManager : Form
    {
        private UserBLL userBLL = new UserBLL();

        public FrmStaffManager()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvStaff.DataSource = userBLL.GetListStaff();
            // Ẩn cột mật khẩu đi cho bảo mật
            if (dgvStaff.Columns["password"] != null) dgvStaff.Columns["password"].Visible = false;
            if (dgvStaff.Columns["tickets"] != null) dgvStaff.Columns["tickets"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmStaffAddEdit frm = new FrmStaffAddEdit(0); // ID = 0 là thêm mới
            frm.ShowDialog();
            LoadData(); // Load lại sau khi thêm
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["id"].Value);
                FrmStaffAddEdit frm = new FrmStaffAddEdit(id); // Truyền ID vào để sửa
                frm.ShowDialog();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["id"].Value);
                string username = dgvStaff.SelectedRows[0].Cells["username"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc muốn xóa nhân viên '{username}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    userBLL.DeleteUser(id);
                    LoadData();
                }
            }
        }
    }
}
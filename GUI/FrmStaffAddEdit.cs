using DAL;
using DoAnFinal.BLL;
using DoAnFinal.DAL;
using System;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmStaffAddEdit : Form
    {
        private UserBLL userBLL = new UserBLL();
        private int _userId = 0;

        public FrmStaffAddEdit(int id = 0)
        {
            InitializeComponent();
            _userId = id;
            if (_userId > 0)
            {
                lblTitle.Text = "CẬP NHẬT NHÂN VIÊN";
                txtUsername.ReadOnly = true; // Không cho sửa username
                LoadData();
            }
            else
            {
                lblTitle.Text = "THÊM NHÂN VIÊN MỚI";
                cboRole.SelectedIndex = 0; // Default Staff
                cboStatus.SelectedIndex = 0; // Default Active
            }
        }

        private void LoadData()
        {
            var u = userBLL.GetUserById(_userId);
            if (u != null)
            {
                txtUsername.Text = u.username;
                txtEmail.Text = u.email;
                cboRole.Text = u.role;
                cboStatus.Text = u.status;
                // Password để trống, user nhập mới đổi
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text)) { MessageBox.Show("Vui lòng nhập Username"); return; }

            // Nếu thêm mới thì bắt buộc nhập pass
            if (_userId == 0 && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cho nhân viên mới!"); return;
            }

            user u = new user();
            u.username = txtUsername.Text.Trim();
            u.email = txtEmail.Text.Trim();
            u.role = cboRole.Text;
            u.status = cboStatus.Text;

            string msg = "";
            if (_userId == 0) // ADD
            {
                msg = userBLL.AddUser(u, txtPassword.Text.Trim());
            }
            else // EDIT
            {
                u.id = _userId;
                msg = userBLL.UpdateUser(u, txtPassword.Text.Trim());
            }

            if (msg == "Success")
            {
                MessageBox.Show("Thành công!", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi: " + msg, "Lỗi");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
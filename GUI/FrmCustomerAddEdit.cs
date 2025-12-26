using DAL;
using DoAnFinal.BLL;
using DoAnFinal.DAL;
using System;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmCustomerAddEdit : Form
    {
        private CustomerBLL cusBLL = new CustomerBLL();
        private int _id = 0;

        public FrmCustomerAddEdit(int id = 0)
        {
            InitializeComponent();
            _id = id;
            if (_id > 0)
            {
                lblTitle.Text = "CẬP NHẬT THÀNH VIÊN";
                LoadData();
            }
            else
            {
                lblTitle.Text = "THÊM THÀNH VIÊN MỚI";
            }
        }

        private void LoadData()
        {
            var c = cusBLL.GetCustomerById(_id);
            if (c != null)
            {
                txtFullName.Text = c.full_name;
                txtPhone.Text = c.phone_number;
                numPoints.Value = (decimal)c.points;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập tên và số điện thoại!"); return;
            }

            customer c = new customer();
            c.full_name = txtFullName.Text.Trim();
            c.phone_number = txtPhone.Text.Trim();
            c.points = (int)numPoints.Value;
            c.created_at = DateTime.Now;

            string msg = "";
            if (_id == 0) // Add
            {
                msg = cusBLL.AddCustomer(c);
            }
            else // Edit
            {
                c.id = _id;
                msg = cusBLL.UpdateCustomer(c);
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
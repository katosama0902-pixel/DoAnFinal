using DAL;
using DoAnFinal.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmFood : Form
    {
        private CinemaModel db = new CinemaModel();

        // Hai biến này để trả kết quả về cho Form cha (FrmSellTicket)
        public decimal TotalFoodPrice = 0;
        public string FoodDetailText = "";

        public FrmFood()
        {
            InitializeComponent();
            LoadFood();
        }

        private void LoadFood()
        {
            var list = db.products.ToList();

            // Tạo DataTable để dễ bind và thêm cột Số lượng
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("price", typeof(int));
            dt.Columns.Add("quantity", typeof(int)); // Cột số lượng để nhập

            foreach (var item in list)
            {
                dt.Rows.Add(item.id, item.name, item.price, 0); // Mặc định số lượng 0
            }

            dgvFood.DataSource = dt;

            // Format Grid
            dgvFood.Columns["id"].Visible = false;
            dgvFood.Columns["name"].HeaderText = "Tên Combo / Món";
            dgvFood.Columns["name"].ReadOnly = true;
            dgvFood.Columns["price"].HeaderText = "Đơn Giá";
            dgvFood.Columns["price"].ReadOnly = true;
            dgvFood.Columns["quantity"].HeaderText = "Số Lượng";

            // Tô màu cột Số lượng để người dùng biết là nhập được
            dgvFood.Columns["quantity"].DefaultCellStyle.BackColor = Color.LightYellow;
            dgvFood.Columns["quantity"].DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
        }

        // Tính tổng tiền realtime khi sửa số lượng
        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvFood.Rows)
            {
                int price = Convert.ToInt32(row.Cells["price"].Value);
                int qty = Convert.ToInt32(row.Cells["quantity"].Value);
                total += price * qty;
            }
            lblTotalFood.Text = "Tổng: " + total.ToString("N0") + " VND";
        }

        // Sự kiện khi nhập xong và Enter/Click ra ngoài
        private void dgvFood_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotal();
        }

        // Mẹo: Giúp sự kiện CellValueChanged kích hoạt ngay lập tức khi bấm nút (nếu dùng Checkbox/Button)
        // Với TextBox thì giúp trải nghiệm mượt hơn
        private void dgvFood_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFood.IsCurrentCellDirty)
            {
                dgvFood.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 1. Tính toán lại lần cuối
            TotalFoodPrice = 0;
            List<string> details = new List<string>();

            foreach (DataGridViewRow row in dgvFood.Rows)
            {
                int qty = Convert.ToInt32(row.Cells["quantity"].Value);
                if (qty > 0)
                {
                    string name = row.Cells["name"].Value.ToString();
                    int price = Convert.ToInt32(row.Cells["price"].Value);

                    TotalFoodPrice += (price * qty);
                    details.Add($"{qty}x {name}");
                }
            }

            FoodDetailText = string.Join(", ", details);

            // 2. Đóng form, trả về kết quả OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
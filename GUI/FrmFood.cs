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

        public decimal TotalFoodPrice = 0;
        public string FoodDetailText = "";

        // Biến lưu số lượng quà tặng hiện tại
        private int _freeDrinks = 0;

        public FrmFood()
        {
            InitializeComponent();
            LoadFood();
        }

        private void LoadFood()
        {
            var list = db.products.ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("price", typeof(int));
            dt.Columns.Add("quantity", typeof(int));

            foreach (var item in list)
            {
                dt.Rows.Add(item.id, item.name, item.price, 0);
            }

            dgvFood.DataSource = dt;
            dgvFood.Columns["id"].Visible = false;
            dgvFood.Columns["name"].HeaderText = "Tên Combo / Món";
            dgvFood.Columns["name"].ReadOnly = true;
            dgvFood.Columns["price"].HeaderText = "Đơn Giá";
            dgvFood.Columns["price"].ReadOnly = true;
            dgvFood.Columns["quantity"].HeaderText = "Số Lượng";
            dgvFood.Columns["quantity"].DefaultCellStyle.BackColor = Color.LightYellow;
            dgvFood.Columns["quantity"].DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
        }

        // [LOGIC MỚI] Tính tiền VÀ Cập nhật quà tặng Realtime
        private void CalculateTotal()
        {
            decimal total = 0;
            int totalCombos = 0;

            foreach (DataGridViewRow row in dgvFood.Rows)
            {
                int price = Convert.ToInt32(row.Cells["price"].Value);
                int qty = Convert.ToInt32(row.Cells["quantity"].Value);
                string name = row.Cells["name"].Value.ToString();

                total += price * qty;

                // Đếm số lượng combo đã chọn
                if (qty > 0 && name.ToLower().Contains("combo"))
                {
                    totalCombos += qty;
                }
            }

            lblTotalFood.Text = "Tổng: " + total.ToString("N0") + " VND";

            // --- CẬP NHẬT NHÃN QUÀ TẶNG ---
            _freeDrinks = totalCombos / 2; // Mua 2 tặng 1

            if (_freeDrinks > 0)
            {
                lblGift.Text = $"🎁 BẠN ĐƯỢC TẶNG: {_freeDrinks} ly nước ngọt miễn phí!";
                lblGift.Visible = true;
            }
            else
            {
                lblGift.Text = "";
                lblGift.Visible = false;
            }
        }

        private void dgvFood_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotal();
        }

        private void dgvFood_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFood.IsCurrentCellDirty)
            {
                dgvFood.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
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

            // [LƯU QUÀ TẶNG VÀO HÓA ĐƠN]
            // Tính toán lại lần cuối để chắc chắn (dù CalculateTotal đã tính)
            if (_freeDrinks > 0)
            {
                details.Add($"🎁 TẶNG KÈM: {_freeDrinks}x Pepsi (Miễn phí)");
            }

            FoodDetailText = string.Join(", ", details);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
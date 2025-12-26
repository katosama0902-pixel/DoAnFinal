using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmMainAdmin : Form
    {
        // Các biến để lưu trạng thái giao diện
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public FrmMainAdmin()
        {
            InitializeComponent();
            random = new Random();
        }

        // 1. HÀM CHỌN MÀU NGẪU NHIÊN (Để giao diện rực rỡ hơn)
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            // Nếu màu trùng với màu vừa chọn thì chọn lại cái khác
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        // 2. HÀM KÍCH HOẠT NÚT (Làm nổi bật nút đang bấm)
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton(); // Trả nút cũ về bình thường

                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;

                    // --- Hiệu ứng nổi bật ---
                    currentButton.BackColor = color; // Đổi màu nền
                    currentButton.ForeColor = Color.White; // Đổi màu chữ
                    currentButton.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Bold); // Phóng to chữ

                    // Đổi màu các thanh tiêu đề cho đồng bộ
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3); // Logo đậm hơn chút

                    // Nút đóng form con (nếu có nút X trên thanh tiêu đề - tuỳ chọn)
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        // 3. HÀM TRẢ NÚT VỀ TRẠNG THÁI CŨ
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76); // Màu gốc (Xanh đậm)
                    previousBtn.ForeColor = Color.Gainsboro; // Màu chữ gốc
                    previousBtn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
                }
            }
        }

        // 4. HÀM MỞ FORM CON (Đã tích hợp hiệu ứng)
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(btnSender); // <--- Gọi hàm làm đẹp nút ở đây

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lblTitle.Text = childForm.Text.ToUpper();
        }

        // --- CÁC SỰ KIỆN CLICK (Giữ nguyên logic, chỉ đổi giao diện) ---

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmDashboard(), sender);
            lblTitle.Text = "THỐNG KÊ DOANH THU";
        }

        private void btnMovie_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmMovieManager(), sender);
            lblTitle.Text = "QUẢN LÝ PHIM";
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmStaffManager(), sender);
            lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCustomerManager(), sender);
            lblTitle.Text = "QUẢN LÝ KHÁCH HÀNG";
        }

        private void btnSellTicket_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSellTicket(), sender);
            lblTitle.Text = "BÁN VÉ (POS)";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Reset lại màu khi đăng xuất
            DisableButton();
            new FrmLogin().Show();
            this.Hide();
        }
    }

    // --- CLASS HỖ TRỢ MÀU SẮC (Thêm cái này xuống dưới cùng file) ---
    public static class ThemeColor
    {
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }

        // Danh sách màu sắc rực rỡ (Palette Modern)
        public static System.Collections.Generic.List<string> ColorList = new System.Collections.Generic.List<string>()
        {
            "#3F51B5", // Xanh dương
            "#009688", // Xanh Teal
            "#FF5722", // Cam đậm
            "#607D8B", // Xám xanh
            "#FF9800", // Cam
            "#9C27B0", // Tím
            "#2196F3", // Xanh biển
            "#EA676C", // Hồng cam
            "#E41A4A", // Hồng đậm
            "#5978BB", // Xanh nhạt
            "#018790", // Xanh ngọc
            "#0E3441", // Xanh đen
            "#00B0AD", // Xanh lơ
            "#721D47", // Đỏ rượu
            "#EA4833", // Đỏ cam
            "#EF937E", // Hồng phấn
            "#F37521", // Cam cháy
            "#A12059", // Tím hồng
            "#126881", // Xanh cổ vịt
            "#8BC240", // Xanh lá mạ
            "#364D5B", // Xám đậm
            "#C7DC5B", // Vàng chanh
            "#0094BC", // Xanh da trời
            "#E4126B", // Hồng neon
            "#43B76E", // Xanh lá
            "#7BCFE9", // Xanh baby
            "#B71C46"  // Đỏ mận
        };

        // Hàm làm đậm màu (Dùng cho Logo panel)
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = (double)color.R;
            double green = (double)color.G;
            double blue = (double)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
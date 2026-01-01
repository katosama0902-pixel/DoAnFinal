using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnFinal.GUI
{
    public partial class FrmMainStaff : Form
    {
        private Button currentButton;
        private Form activeForm;

        public FrmMainStaff()
        {
            InitializeComponent();
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    Color color = Color.FromArgb(255, 87, 34); // Màu cam chủ đạo của Staff
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Bold);
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(40, 40, 80);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(btnSender);
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

        private Color ChangeColorBrightness(Color color, double correctionFactor)
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

        // --- CÁC SỰ KIỆN CLICK ---

        private void btnSellTicket_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSellTicket(), sender);
            lblTitle.Text = "QUẦY BÁN VÉ";
        }

        // --- [MỚI] SỰ KIỆN NÚT TRA CỨU VÉ ---
        private void btnCheckTicket_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCheckTicket(), sender);
            lblTitle.Text = "TRA CỨU & IN VÉ";
        }
        // -------------------------------------

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            // Mở form dưới dạng Dialog (popup)
            FrmChangePassword frm = new FrmChangePassword();
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
namespace DoAnFinal.GUI
{
    partial class FrmStaffManager
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();
            // Panel Top
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnEdit);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(800, 60);
            // Btn Add
            this.btnAdd.Text = "+ Thêm NV";
            this.btnAdd.Location = new System.Drawing.Point(20, 10); this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.BackColor = System.Drawing.Color.SeaGreen; this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // Btn Edit
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Location = new System.Drawing.Point(130, 10); this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.BackColor = System.Drawing.Color.Orange; this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // Btn Delete
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new System.Drawing.Point(240, 10); this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick; this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // Grid
            this.dgvStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.AllowUserToAddRows = false;

            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.panelTop);
            this.Text = "Quản lý nhân viên";
            this.panelTop.ResumeLayout(false); ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit(); this.ResumeLayout(false);
        }
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvStaff;
    }
}
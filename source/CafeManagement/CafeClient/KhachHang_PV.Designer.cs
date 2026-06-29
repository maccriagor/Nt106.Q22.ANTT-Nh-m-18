namespace CafeClient
{
    partial class KhachHang_PV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvKhachHang = new DataGridView();
            panel1 = new Panel();
            txtMaKH = new TextBox();
            label1 = new Label();
            panel4 = new Panel();
            txtTenKH = new TextBox();
            txtSDT = new TextBox();
            label5 = new Label();
            panel8 = new Panel();
            txtDiemTichLuy = new TextBox();
            label3 = new Label();
            panel6 = new Panel();
            dtpNgayDangKi = new DateTimePicker();
            label4 = new Label();
            panel7 = new Panel();
            panel3 = new Panel();
            panel5 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            txtTimKiem = new TextBox();
            btn_TimKiem = new Button();
            lblTitle = new Label();
            btnXem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Location = new Point(12, 157);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(528, 437);
            dgvKhachHang.TabIndex = 0;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvKhachHang);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(861, 606);
            panel1.TabIndex = 9;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(3, 31);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(296, 28);
            txtMaKH.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(144, 24);
            label1.TabIndex = 0;
            label1.Text = "Mã khách hàng:";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtMaKH);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(8, 26);
            panel4.Name = "panel4";
            panel4.Size = new Size(328, 62);
            panel4.TabIndex = 0;
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(3, 31);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(296, 28);
            txtTenKH.TabIndex = 0;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(3, 31);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(296, 28);
            txtSDT.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(128, 64, 64);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(127, 24);
            label5.TabIndex = 0;
            label5.Text = "Số điện thoại:";
            // 
            // panel8
            // 
            panel8.Controls.Add(txtSDT);
            panel8.Controls.Add(label5);
            panel8.Location = new Point(8, 162);
            panel8.Name = "panel8";
            panel8.Size = new Size(307, 62);
            panel8.TabIndex = 0;
            // 
            // txtDiemTichLuy
            // 
            txtDiemTichLuy.Location = new Point(3, 31);
            txtDiemTichLuy.Name = "txtDiemTichLuy";
            txtDiemTichLuy.Size = new Size(296, 28);
            txtDiemTichLuy.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(126, 24);
            label3.TabIndex = 0;
            label3.Text = "Điểm tích lũy:";
            // 
            // panel6
            // 
            panel6.Controls.Add(txtDiemTichLuy);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(6, 230);
            panel6.Name = "panel6";
            panel6.Size = new Size(309, 62);
            panel6.TabIndex = 0;
            // 
            // dtpNgayDangKi
            // 
            dtpNgayDangKi.Location = new Point(3, 31);
            dtpNgayDangKi.Name = "dtpNgayDangKi";
            dtpNgayDangKi.Size = new Size(296, 28);
            dtpNgayDangKi.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(128, 64, 64);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(127, 24);
            label4.TabIndex = 0;
            label4.Text = "Ngày đăng ký:";
            // 
            // panel7
            // 
            panel7.Controls.Add(dtpNgayDangKi);
            panel7.Controls.Add(label4);
            panel7.Location = new Point(6, 298);
            panel7.Name = "panel7";
            panel7.Size = new Size(309, 62);
            panel7.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(546, 151);
            panel3.Name = "panel3";
            panel3.Size = new Size(315, 455);
            panel3.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtTenKH);
            panel5.Controls.Add(label2);
            panel5.Location = new Point(8, 94);
            panel5.Name = "panel5";
            panel5.Size = new Size(328, 62);
            panel5.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(146, 24);
            label2.TabIndex = 0;
            label2.Text = "Tên khách hàng:";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtTimKiem);
            panel2.Controls.Add(btn_TimKiem);
            panel2.Controls.Add(lblTitle);
            panel2.Controls.Add(btnXem);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnThem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(861, 151);
            panel2.TabIndex = 11;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTimKiem.Location = new Point(548, 98);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(201, 28);
            txtTimKiem.TabIndex = 16;
            // 
            // btn_TimKiem
            // 
            btn_TimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_TimKiem.BackColor = Color.FromArgb(128, 64, 0);
            btn_TimKiem.FlatAppearance.BorderSize = 0;
            btn_TimKiem.FlatStyle = FlatStyle.Flat;
            btn_TimKiem.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_TimKiem.ForeColor = Color.White;
            btn_TimKiem.Location = new Point(757, 83);
            btn_TimKiem.Name = "btn_TimKiem";
            btn_TimKiem.Size = new Size(92, 57);
            btn_TimKiem.TabIndex = 17;
            btn_TimKiem.Text = "🔍 Tìm";
            btn_TimKiem.UseVisualStyleBackColor = false;
            btn_TimKiem.Click += btnTimKiem_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(213, 49);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Khách hàng";
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(128, 64, 0);
            btnXem.FlatAppearance.BorderSize = 0;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(385, 74);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(116, 74);
            btnXem.TabIndex = 1;
            btnXem.Text = "👁️ Xem";
            btnXem.UseVisualStyleBackColor = false;
            btnXem.Click += btnXem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(128, 64, 0);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(260, 74);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(116, 74);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(128, 64, 0);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(136, 74);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(116, 74);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(128, 64, 0);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(12, 74);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(116, 74);
            btnThem.TabIndex = 1;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // KhachHang_PV
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(128, 64, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "KhachHang_PV";
            Text = "KhachHang_PV";
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvKhachHang;
        private Panel panel1;
        private TextBox txtMaKH;
        private Label label1;
        private Panel panel4;
        private TextBox txtTenKH;
        private TextBox txtSDT;
        private Label label5;
        private Panel panel8;
        private TextBox txtDiemTichLuy;
        private Label label3;
        private Panel panel6;
        private DateTimePicker dtpNgayDangKi;
        private Label label4;
        private Panel panel7;
        private Panel panel3;
        private Panel panel5;
        private Label label2;
        private Panel panel2;
        private Label lblTitle;
        private Button btnXem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private TextBox txtTimKiem;
        private Button btn_TimKiem;
    }
}
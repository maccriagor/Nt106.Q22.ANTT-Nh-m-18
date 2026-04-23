namespace CafeClient
{
    partial class NhanVien_AD
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            tbEmail = new TextBox();
            panel3 = new Panel();
            panel7 = new Panel();
            dtpNgayVaoLam = new DateTimePicker();
            label4 = new Label();
            panel6 = new Panel();
            cbVaiTro = new ComboBox();
            label3 = new Label();
            panel8 = new Panel();
            tbPass = new TextBox();
            label5 = new Label();
            panel5 = new Panel();
            label2 = new Label();
            panel9 = new Panel();
            txtUserName = new TextBox();
            label6 = new Label();
            panel4 = new Panel();
            tbTenNhanVien = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            lblTitle = new Label();
            btnXem = new Button();
            tbTimKiem = new TextBox();
            btnSua = new Button();
            btnTimKiem = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            panel1 = new Panel();
            dgvNhanVien = new DataGridView();
            MaNguoiDung = new DataGridViewTextBoxColumn();
            TenDangNhap = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            VaiTro = new DataGridViewTextBoxColumn();
            NgayTao = new DataGridViewTextBoxColumn();
            userAccountBindingSource = new BindingSource(components);
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            panel5.SuspendLayout();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userAccountBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(3, 31);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(296, 28);
            tbEmail.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel9);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(546, 151);
            panel3.Name = "panel3";
            panel3.Size = new Size(315, 455);
            panel3.TabIndex = 4;
            // 
            // panel7
            // 
            panel7.Controls.Add(dtpNgayVaoLam);
            panel7.Controls.Add(label4);
            panel7.Location = new Point(6, 362);
            panel7.Name = "panel7";
            panel7.Size = new Size(309, 62);
            panel7.TabIndex = 0;
            // 
            // dtpNgayVaoLam
            // 
            dtpNgayVaoLam.Location = new Point(3, 31);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(296, 28);
            dtpNgayVaoLam.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(128, 64, 64);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(128, 24);
            label4.TabIndex = 0;
            label4.Text = "Ngày vào làm:";
            // 
            // panel6
            // 
            panel6.Controls.Add(cbVaiTro);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(8, 294);
            panel6.Name = "panel6";
            panel6.Size = new Size(307, 62);
            panel6.TabIndex = 0;
            // 
            // cbVaiTro
            // 
            cbVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVaiTro.FormattingEnabled = true;
            cbVaiTro.Items.AddRange(new object[] { "Admin", "Waiter", "Kitchen" });
            cbVaiTro.Location = new Point(-2, 27);
            cbVaiTro.Name = "cbVaiTro";
            cbVaiTro.Size = new Size(307, 29);
            cbVaiTro.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(72, 24);
            label3.TabIndex = 0;
            label3.Text = "Vai trò:";
            // 
            // panel8
            // 
            panel8.Controls.Add(tbPass);
            panel8.Controls.Add(label5);
            panel8.Location = new Point(8, 226);
            panel8.Name = "panel8";
            panel8.Size = new Size(307, 62);
            panel8.TabIndex = 0;
            // 
            // tbPass
            // 
            tbPass.Location = new Point(3, 31);
            tbPass.Name = "tbPass";
            tbPass.Size = new Size(296, 28);
            tbPass.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(128, 64, 64);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(97, 24);
            label5.TabIndex = 0;
            label5.Text = "Mật khẩu:";
            // 
            // panel5
            // 
            panel5.Controls.Add(tbEmail);
            panel5.Controls.Add(label2);
            panel5.Location = new Point(8, 158);
            panel5.Name = "panel5";
            panel5.Size = new Size(307, 62);
            panel5.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 24);
            label2.TabIndex = 0;
            label2.Text = "Email:";
            // 
            // panel9
            // 
            panel9.Controls.Add(txtUserName);
            panel9.Controls.Add(label6);
            panel9.Location = new Point(6, 22);
            panel9.Name = "panel9";
            panel9.Size = new Size(309, 62);
            panel9.TabIndex = 0;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(3, 31);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(296, 28);
            txtUserName.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(128, 64, 64);
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(139, 24);
            label6.TabIndex = 0;
            label6.Text = "Tên đăng nhập:";
            // 
            // panel4
            // 
            panel4.Controls.Add(tbTenNhanVien);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(8, 90);
            panel4.Name = "panel4";
            panel4.Size = new Size(307, 62);
            panel4.TabIndex = 0;
            // 
            // tbTenNhanVien
            // 
            tbTenNhanVien.Location = new Point(3, 31);
            tbTenNhanVien.Name = "tbTenNhanVien";
            tbTenNhanVien.Size = new Size(296, 28);
            tbTenNhanVien.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(133, 24);
            label1.TabIndex = 0;
            label1.Text = "Tên nhân viên:";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTitle);
            panel2.Controls.Add(btnXem);
            panel2.Controls.Add(tbTimKiem);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(btnTimKiem);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnThem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(861, 151);
            panel2.TabIndex = 5;
            panel2.Paint += panel2_Paint;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(189, 49);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Nhân viên";
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
            // tbTimKiem
            // 
            tbTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tbTimKiem.Location = new Point(547, 98);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(201, 28);
            tbTimKiem.TabIndex = 0;
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
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(128, 64, 0);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(756, 83);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(92, 57);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "🔍 Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
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
            // panel1
            // 
            panel1.Controls.Add(dgvNhanVien);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 151);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 455);
            panel1.TabIndex = 6;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNhanVien.ColumnHeadersHeight = 35;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNhanVien.Columns.AddRange(new DataGridViewColumn[] { MaNguoiDung, TenDangNhap, HoTen, Email, VaiTro, NgayTao });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle8;
            dgvNhanVien.Location = new Point(13, 3);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dgvNhanVien.RowsDefaultCellStyle = dataGridViewCellStyle9;
            dgvNhanVien.Size = new Size(527, 437);
            dgvNhanVien.TabIndex = 0;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            // 
            // MaNguoiDung
            // 
            MaNguoiDung.DataPropertyName = "MaNguoiDung";
            dataGridViewCellStyle2.ForeColor = Color.Black;
            MaNguoiDung.DefaultCellStyle = dataGridViewCellStyle2;
            MaNguoiDung.HeaderText = "MaNguoiDung";
            MaNguoiDung.MinimumWidth = 6;
            MaNguoiDung.Name = "MaNguoiDung";
            // 
            // TenDangNhap
            // 
            TenDangNhap.DataPropertyName = "TenDangNhap";
            dataGridViewCellStyle3.ForeColor = Color.Black;
            TenDangNhap.DefaultCellStyle = dataGridViewCellStyle3;
            TenDangNhap.HeaderText = "TenDangNhap";
            TenDangNhap.MinimumWidth = 6;
            TenDangNhap.Name = "TenDangNhap";
            // 
            // HoTen
            // 
            HoTen.DataPropertyName = "HoTen";
            dataGridViewCellStyle4.ForeColor = Color.Black;
            HoTen.DefaultCellStyle = dataGridViewCellStyle4;
            HoTen.HeaderText = "TenNhanVien";
            HoTen.MinimumWidth = 6;
            HoTen.Name = "HoTen";
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            dataGridViewCellStyle5.ForeColor = Color.Black;
            Email.DefaultCellStyle = dataGridViewCellStyle5;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            // 
            // VaiTro
            // 
            VaiTro.DataPropertyName = "VaiTro";
            dataGridViewCellStyle6.ForeColor = Color.Black;
            VaiTro.DefaultCellStyle = dataGridViewCellStyle6;
            VaiTro.HeaderText = "VaiTro";
            VaiTro.MinimumWidth = 6;
            VaiTro.Name = "VaiTro";
            // 
            // NgayTao
            // 
            NgayTao.DataPropertyName = "NgayTao";
            dataGridViewCellStyle7.ForeColor = Color.Black;
            NgayTao.DefaultCellStyle = dataGridViewCellStyle7;
            NgayTao.HeaderText = "NgayTao";
            NgayTao.MinimumWidth = 6;
            NgayTao.Name = "NgayTao";
            // 
            // userAccountBindingSource
            // 
            userAccountBindingSource.DataSource = typeof(CafeCommon.UserAccount);
            // 
            // NhanVien_AD
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NhanVien_AD";
            Text = "NhanVien";
            panel3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)userAccountBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private NumericUpDown numericUpDown1;
        private Panel panel3;
        private Panel panel7;
        private TextBox tbTrangThai;
        private Label label4;
        private Panel panel6;
        private Label label3;
        private Panel panel5;
        private Label label2;
        private Panel panel4;
        private TextBox tbTenNhanVien;
        private Label label1;
        private Panel panel2;
        private TextBox tbTimKiem;
        private Button btnTimKiem;
        private Panel panel1;
        private Button btnXem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private DataGridView dgvNhanVien;
        private DateTimePicker dtpNgayVaoLam;
        private Panel panel8;
        private TextBox tbPass;
        private Label label5;
        private TextBox tbEmail;
        private Label lblTitle;
        private Panel panel9;
        private TextBox txtUserName;
        private Label label6;
        private BindingSource userAccountBindingSource;
        private ComboBox cbVaiTro;
        private DataGridViewTextBoxColumn MaNguoiDung;
        private DataGridViewTextBoxColumn TenDangNhap;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn VaiTro;
        private DataGridViewTextBoxColumn NgayTao;
    }
}
namespace CafeClient
{
    partial class Order_Ban
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            txtGhiChu = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label6 = new Label();
            nmSoLuong = new NumericUpDown();
            cbLoaiMonAn = new ComboBox();
            panel3 = new Panel();
            flpTables = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            label3 = new Label();
            lbTrangThaiBan = new Label();
            label2 = new Label();
            btnHuyBan = new Button();
            btnDatBan = new Button();
            cbSoBan = new ComboBox();
            label1 = new Label();
            btnXoa = new Button();
            btnThem = new Button();
            btnGuiOrder = new Button();
            btnChuyenBan = new Button();
            cbBanMuonChuyenDen = new ComboBox();
            panel11 = new Panel();
            lblTitle = new Label();
            panel4 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            dgvGioHang = new DataGridView();
            groupBox3 = new GroupBox();
            dgvMenu = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).BeginInit();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            panel11.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtGhiChu);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(nmSoLuong);
            panel1.Controls.Add(cbLoaiMonAn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(399, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(462, 71);
            panel1.TabIndex = 0;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(131, 40);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(325, 28);
            txtGhiChu.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 10.8F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(128, 64, 0);
            label7.Location = new Point(274, 9);
            label7.Name = "label7";
            label7.Size = new Size(84, 22);
            label7.TabIndex = 3;
            label7.Text = "Số lượng:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 10.8F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(128, 64, 0);
            label5.Location = new Point(14, 43);
            label5.Name = "label5";
            label5.Size = new Size(126, 22);
            label5.TabIndex = 3;
            label5.Text = "Ghi chú khách: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 10.8F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(128, 64, 0);
            label6.Location = new Point(14, 9);
            label6.Name = "label6";
            label6.Size = new Size(85, 22);
            label6.TabIndex = 3;
            label6.Text = "Loại món:";
            // 
            // nmSoLuong
            // 
            nmSoLuong.Location = new Point(359, 7);
            nmSoLuong.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nmSoLuong.Name = "nmSoLuong";
            nmSoLuong.Size = new Size(57, 28);
            nmSoLuong.TabIndex = 2;
            // 
            // cbLoaiMonAn
            // 
            cbLoaiMonAn.FormattingEnabled = true;
            cbLoaiMonAn.Location = new Point(99, 5);
            cbLoaiMonAn.Name = "cbLoaiMonAn";
            cbLoaiMonAn.Size = new Size(151, 29);
            cbLoaiMonAn.TabIndex = 1;
            cbLoaiMonAn.SelectedIndexChanged += cbLoaiMonAn_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(flpTables);
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 68);
            panel3.Name = "panel3";
            panel3.Size = new Size(399, 460);
            panel3.TabIndex = 0;
            // 
            // flpTables
            // 
            flpTables.AutoScroll = true;
            flpTables.Dock = DockStyle.Left;
            flpTables.Location = new Point(0, 121);
            flpTables.Name = "flpTables";
            flpTables.Size = new Size(399, 339);
            flpTables.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lbTrangThaiBan);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnHuyBan);
            groupBox1.Controls.Add(btnDatBan);
            groupBox1.Controls.Add(cbSoBan);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 121);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin bàn ăn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 10.8F, FontStyle.Bold);
            label3.Location = new Point(6, 76);
            label3.Name = "label3";
            label3.Size = new Size(123, 22);
            label3.TabIndex = 2;
            label3.Text = "Trạng thái bàn:";
            // 
            // lbTrangThaiBan
            // 
            lbTrangThaiBan.AutoSize = true;
            lbTrangThaiBan.Font = new Font("Calibri", 10.8F, FontStyle.Bold);
            lbTrangThaiBan.Location = new Point(126, 76);
            lbTrangThaiBan.Name = "lbTrangThaiBan";
            lbTrangThaiBan.Size = new Size(83, 22);
            lbTrangThaiBan.TabIndex = 3;
            lbTrangThaiBan.Text = "trạng thái";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 10.8F, FontStyle.Bold);
            label2.Location = new Point(6, 37);
            label2.Name = "label2";
            label2.Size = new Size(88, 22);
            label2.TabIndex = 1;
            label2.Text = "Chọn bàn:";
            label2.Click += label2_Click;
            // 
            // btnHuyBan
            // 
            btnHuyBan.BackColor = Color.White;
            btnHuyBan.FlatStyle = FlatStyle.Flat;
            btnHuyBan.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuyBan.ForeColor = Color.FromArgb(128, 64, 0);
            btnHuyBan.Location = new Point(262, 66);
            btnHuyBan.Name = "btnHuyBan";
            btnHuyBan.Size = new Size(99, 29);
            btnHuyBan.TabIndex = 3;
            btnHuyBan.Text = "Hủy bàn";
            btnHuyBan.UseVisualStyleBackColor = false;
            btnHuyBan.Click += btnHuyBan_Click;
            // 
            // btnDatBan
            // 
            btnDatBan.BackColor = Color.FromArgb(128, 64, 0);
            btnDatBan.FlatAppearance.BorderSize = 0;
            btnDatBan.FlatStyle = FlatStyle.Flat;
            btnDatBan.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatBan.ForeColor = Color.White;
            btnDatBan.Location = new Point(262, 33);
            btnDatBan.Name = "btnDatBan";
            btnDatBan.Size = new Size(99, 29);
            btnDatBan.TabIndex = 3;
            btnDatBan.Text = "Đặt bàn";
            btnDatBan.UseVisualStyleBackColor = false;
            btnDatBan.Click += btnDatBan_Click;
            // 
            // cbSoBan
            // 
            cbSoBan.FormattingEnabled = true;
            cbSoBan.Location = new Point(102, 33);
            cbSoBan.Name = "cbSoBan";
            cbSoBan.Size = new Size(151, 32);
            cbSoBan.TabIndex = 0;
            cbSoBan.SelectedIndexChanged += cbSoBan_SelectedIndexChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 61);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 0;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnXoa.BackColor = Color.FromArgb(128, 64, 0);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(551, 10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(144, 54);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThem.BackColor = Color.FromArgb(128, 64, 0);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(397, 10);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(144, 54);
            btnThem.TabIndex = 3;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnGuiOrder
            // 
            btnGuiOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuiOrder.BackColor = Color.FromArgb(128, 64, 0);
            btnGuiOrder.FlatAppearance.BorderSize = 0;
            btnGuiOrder.FlatStyle = FlatStyle.Flat;
            btnGuiOrder.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnGuiOrder.ForeColor = Color.White;
            btnGuiOrder.Location = new Point(705, 10);
            btnGuiOrder.Name = "btnGuiOrder";
            btnGuiOrder.Size = new Size(144, 54);
            btnGuiOrder.TabIndex = 2;
            btnGuiOrder.Text = "Gửi Order";
            btnGuiOrder.UseVisualStyleBackColor = false;
            btnGuiOrder.Click += btnGuiOrder_Click;
            // 
            // btnChuyenBan
            // 
            btnChuyenBan.BackColor = Color.FromArgb(128, 64, 0);
            btnChuyenBan.FlatAppearance.BorderSize = 0;
            btnChuyenBan.FlatStyle = FlatStyle.Flat;
            btnChuyenBan.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChuyenBan.ForeColor = Color.White;
            btnChuyenBan.Location = new Point(9, 9);
            btnChuyenBan.Name = "btnChuyenBan";
            btnChuyenBan.Size = new Size(142, 29);
            btnChuyenBan.TabIndex = 3;
            btnChuyenBan.Text = "Chuyển bàn";
            btnChuyenBan.UseVisualStyleBackColor = false;
            btnChuyenBan.Click += btnChuyenBan_Click;
            // 
            // cbBanMuonChuyenDen
            // 
            cbBanMuonChuyenDen.FormattingEnabled = true;
            cbBanMuonChuyenDen.Location = new Point(9, 42);
            cbBanMuonChuyenDen.Name = "cbBanMuonChuyenDen";
            cbBanMuonChuyenDen.Size = new Size(142, 29);
            cbBanMuonChuyenDen.TabIndex = 0;
            cbBanMuonChuyenDen.SelectedIndexChanged += cbBanMuonChuyenDen_SelectedIndexChanged;
            // 
            // panel11
            // 
            panel11.Controls.Add(lblTitle);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(861, 68);
            panel11.TabIndex = 11;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(335, 49);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Đặt món và bàn ăn";
            // 
            // panel4
            // 
            panel4.Controls.Add(btnChuyenBan);
            panel4.Controls.Add(cbBanMuonChuyenDen);
            panel4.Controls.Add(btnGuiOrder);
            panel4.Controls.Add(btnThem);
            panel4.Controls.Add(btnXoa);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 528);
            panel4.Name = "panel4";
            panel4.Size = new Size(861, 78);
            panel4.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(399, 139);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(462, 389);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvGioHang);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox2.Location = new Point(3, 197);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(456, 189);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Giỏ hàng";
            // 
            // dgvGioHang
            // 
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvGioHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Dock = DockStyle.Fill;
            dgvGioHang.Location = new Point(3, 28);
            dgvGioHang.Name = "dgvGioHang";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvGioHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvGioHang.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dgvGioHang.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvGioHang.Size = new Size(450, 158);
            dgvGioHang.TabIndex = 0;
            dgvGioHang.CellFormatting += dgvGioHang_CellFormatting;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvMenu);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(456, 188);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Menu";
            // 
            // dgvMenu
            // 
            dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle4.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvMenu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Dock = DockStyle.Fill;
            dgvMenu.Location = new Point(3, 28);
            dgvMenu.Name = "dgvMenu";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle5.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvMenu.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvMenu.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dgvMenu.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvMenu.Size = new Size(450, 157);
            dgvMenu.TabIndex = 0;
            dgvMenu.CellFormatting += DgvMenu_CellFormatting;
            // 
            // Order_Ban
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel11);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Order_Ban";
            Text = "Order_Ban";
            Load += Order_Ban_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private GroupBox groupBox1;
        private Label lbTrangThaiBan;
        private Label label3;
        private Label label2;
        private ComboBox cbSoBan;
        private Label label6;
        private NumericUpDown nmSoLuong;
        private ComboBox cbLoaiMonAn;
        private ListView listView1;
        private Label label7;
        private Button btnXoa;
        private Button btnThem;
        private FlowLayoutPanel flpTables;
        private Button btnDatBan;
        private Button btnGuiOrder;
        private Button btnHuyBan;
        private Button btnChuyenBan;
        private ComboBox cbBanMuonChuyenDen;
        private Panel panel11;
        private Label lblTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox2;
        private DataGridView dgvGioHang;
        private GroupBox groupBox3;
        private DataGridView dgvMenu;
        private TextBox txtGhiChu;
        private Label label5;
    }
}
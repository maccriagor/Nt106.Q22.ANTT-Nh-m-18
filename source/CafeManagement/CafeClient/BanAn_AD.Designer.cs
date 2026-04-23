namespace CafeClient
{
    partial class BanAn_AD
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
            label4 = new Label();
            panel7 = new Panel();
            cbTrangThai = new ComboBox();
            label3 = new Label();
            panel6 = new Panel();
            numSoChoNgoi = new NumericUpDown();
            label2 = new Label();
            panel5 = new Panel();
            tbTenBan = new TextBox();
            tbMaBan = new TextBox();
            panel4 = new Panel();
            label1 = new Label();
            tbTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvBanAn = new DataGridView();
            panel3 = new Panel();
            panel8 = new Panel();
            dtpNgayTao = new DateTimePicker();
            label5 = new Label();
            panel2 = new Panel();
            btnXem = new Button();
            lblTitle = new Label();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            panel1 = new Panel();
            cbTrangThai = new ComboBox();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoChoNgoi).BeginInit();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBanAn).BeginInit();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(128, 64, 64);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(100, 24);
            label4.TabIndex = 0;
            label4.Text = "Trạng thái:";
            // 
            // panel7
            // 
            panel7.Controls.Add(cbTrangThai);
            panel7.Controls.Add(label4);
            panel7.Location = new Point(8, 230);
            panel7.Name = "panel7";
            panel7.Size = new Size(328, 62);
            panel7.TabIndex = 0;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Items.AddRange(new object[] { "Trống", "Đã đặt", "Có người" });
            cbTrangThai.Location = new Point(3, 27);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(297, 29);
            cbTrangThai.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(112, 24);
            label3.TabIndex = 0;
            label3.Text = "Số chỗ ngồi:";
            // 
            // panel6
            // 
            panel6.Controls.Add(numSoChoNgoi);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(8, 162);
            panel6.Name = "panel6";
            panel6.Size = new Size(328, 62);
            panel6.TabIndex = 0;
            // 
            // numSoChoNgoi
            // 
            numSoChoNgoi.Location = new Point(3, 31);
            numSoChoNgoi.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numSoChoNgoi.Name = "numSoChoNgoi";
            numSoChoNgoi.Size = new Size(296, 28);
            numSoChoNgoi.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 0;
            label2.Text = "Tên bàn:";
            // 
            // panel5
            // 
            panel5.Controls.Add(tbTenBan);
            panel5.Controls.Add(label2);
            panel5.Location = new Point(8, 94);
            panel5.Name = "panel5";
            panel5.Size = new Size(328, 62);
            panel5.TabIndex = 0;
            // 
            // tbTenBan
            // 
            tbTenBan.Location = new Point(3, 31);
            tbTenBan.Name = "tbTenBan";
            tbTenBan.Size = new Size(296, 28);
            tbTenBan.TabIndex = 0;
            // 
            // tbMaBan
            // 
            tbMaBan.Location = new Point(3, 31);
            tbMaBan.Name = "tbMaBan";
            tbMaBan.ReadOnly = true;
            tbMaBan.Size = new Size(296, 28);
            tbMaBan.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(tbMaBan);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(8, 26);
            panel4.Name = "panel4";
            panel4.Size = new Size(328, 62);
            panel4.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 24);
            label1.TabIndex = 0;
            label1.Text = "Mã bàn:";
            // 
            // tbTimKiem
            // 
            tbTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tbTimKiem.Location = new Point(551, 98);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(201, 28);
            tbTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(128, 64, 0);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(760, 83);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(92, 57);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "🔍 Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvBanAn
            // 
            dgvBanAn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBanAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBanAn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBanAn.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBanAn.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBanAn.Location = new Point(12, 6);
            dgvBanAn.Name = "dgvBanAn";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvBanAn.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvBanAn.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dgvBanAn.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvBanAn.Size = new Size(528, 433);
            dgvBanAn.TabIndex = 0;
            dgvBanAn.CellClick += dgvBanAn_CellClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(546, 155);
            panel3.Name = "panel3";
            panel3.Size = new Size(315, 451);
            panel3.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(dtpNgayTao);
            panel8.Controls.Add(label5);
            panel8.Location = new Point(8, 298);
            panel8.Name = "panel8";
            panel8.Size = new Size(307, 62);
            panel8.TabIndex = 0;
            // 
            // dtpNgayTao
            // 
            dtpNgayTao.Location = new Point(3, 28);
            dtpNgayTao.Name = "dtpNgayTao";
            dtpNgayTao.Size = new Size(296, 28);
            dtpNgayTao.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(128, 64, 64);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(106, 24);
            label5.TabIndex = 0;
            label5.Text = "Ngày thêm:";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnXem);
            panel2.Controls.Add(lblTitle);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(tbTimKiem);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnTimKiem);
            panel2.Controls.Add(btnThem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(861, 155);
            panel2.TabIndex = 2;
            // 
            // dgvBanAn
            // 
            dgvBanAn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBanAn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBanAn.Location = new Point(12, 6);
            dgvBanAn.Name = "dgvBanAn";
            dgvBanAn.RowHeadersWidth = 51;
            dgvBanAn.Size = new Size(528, 433);
            dgvBanAn.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(546, 155);
            panel3.Name = "panel3";
            panel3.Size = new Size(315, 451);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnXem);
            panel2.Controls.Add(lblTitle);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(tbTimKiem);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnTimKiem);
            panel2.Controls.Add(btnThem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(861, 155);
            panel2.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(135, 49);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "Bàn ăn";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvBanAn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 155);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 451);
            panel1.TabIndex = 3;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(128, 64, 0);
            btnXem.FlatAppearance.BorderSize = 0;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(385, 75);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(116, 74);
            btnXem.TabIndex = 4;
            btnXem.Text = "👁️ Xem";
            btnXem.UseVisualStyleBackColor = false;
            btnXem.Click += btnXem_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(135, 49);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "Bàn ăn";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(135, 49);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "Bàn ăn";
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(128, 64, 0);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(260, 75);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(116, 74);
            btnSua.TabIndex = 5;
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
            btnXoa.Location = new Point(136, 75);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(116, 74);
            btnXoa.TabIndex = 6;
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
            btnThem.Location = new Point(12, 75);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(116, 74);
            btnThem.TabIndex = 7;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvBanAn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 155);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 451);
            panel1.TabIndex = 3;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Location = new Point(3, 27);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(297, 29);
            cbTrangThai.TabIndex = 1;
            // 
            // BanAn_AD
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
            Name = "BanAn_AD";
            Text = "BanAn";
            Load += BanAn_AD_Load;
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoChoNgoi).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBanAn).EndInit();
            panel3.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label4;
        private Panel panel7;
        private Label label3;
        private Panel panel6;
        private NumericUpDown numSoChoNgoi;
        private Label label2;
        private Panel panel5;
        private TextBox tbMaBan;
        private Panel panel4;
        private Label label1;
        private TextBox tbTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvBanAn;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private TextBox tbTenBan;
        private Label lblTitle;
        private Button btnXem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private Panel panel8;
        private Label label5;
        private DateTimePicker dtpNgayTao;
        private ComboBox cbTrangThai;
    }
}
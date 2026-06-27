namespace CafeClient
{
    partial class TheoDoiOrder_PV
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
            panel3 = new Panel();
            btnLamMoi = new Button();
            btnXoa = new Button();
            cbSoBan = new ComboBox();
            cbTrangThai = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            panel9 = new Panel();
            lblTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            dgvDonHang = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            lvDonHang = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            panel3.SuspendLayout();
            panel9.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(btnLamMoi);
            panel3.Controls.Add(btnXoa);
            panel3.Controls.Add(cbSoBan);
            panel3.Controls.Add(cbTrangThai);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(526, 68);
            panel3.Name = "panel3";
            panel3.Size = new Size(335, 538);
            panel3.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(128, 64, 0);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(11, 120);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(148, 46);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "🔁 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            btnXoa.ForeColor = Color.FromArgb(128, 64, 64);
            btnXoa.Location = new Point(167, 120);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(148, 46);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // cbSoBan
            // 
            cbSoBan.FormattingEnabled = true;
            cbSoBan.Location = new Point(105, 37);
            cbSoBan.Name = "cbSoBan";
            cbSoBan.Size = new Size(216, 29);
            cbSoBan.TabIndex = 1;
            cbSoBan.SelectedIndexChanged += cbSoBan_SelectedIndexChanged;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Items.AddRange(new object[] { "Tất cả trạng thái", "1", "2" });
            cbTrangThai.Location = new Point(105, 70);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(216, 29);
            cbTrangThai.TabIndex = 1;
            cbTrangThai.SelectedIndexChanged += cbTrangThai_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(15, 73);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 0;
            label2.Text = "Trạng thái:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(15, 40);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 0;
            label1.Text = "Bàn ăn:";
            // 
            // panel9
            // 
            panel9.Controls.Add(lblTitle);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(861, 68);
            panel9.TabIndex = 8;
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
            lblTitle.Text = "Theo dõi đơn hàng";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 68);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(526, 538);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvDonHang);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(520, 263);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đơn hàng";
            // 
            // dgvDonHang
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDonHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDonHang.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dgvDonHang.Dock = DockStyle.Fill;
            dgvDonHang.Location = new Point(3, 24);
            dgvDonHang.Name = "dgvDonHang";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDonHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDonHang.RowHeadersWidth = 51;
            dgvDonHang.Size = new Size(514, 236);
            dgvDonHang.TabIndex = 0;
            dgvDonHang.CellClick += dgvDonHang_CellClick;
            dgvDonHang.CellFormatting += dgvDonHang_CellFormatting;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "MaHD";
            Column1.HeaderText = "MaHD";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "TenBan";
            Column2.HeaderText = "Tên Bàn";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "SoLuong";
            Column3.HeaderText = "Số lượng";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "TrangThai";
            Column4.HeaderText = "Trạng Thái";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "NgayOrder";
            Column5.HeaderText = "Ngày Order";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.DataPropertyName = "MaDonHang";
            Column6.HeaderText = "Ma Don Hang";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Visible = false;
            Column6.Width = 125;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lvDonHang);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox2.Location = new Point(3, 272);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(520, 263);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết đơn hàng";
            // 
            // lvDonHang
            // 
            lvDonHang.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            lvDonHang.Dock = DockStyle.Fill;
            lvDonHang.Location = new Point(3, 24);
            lvDonHang.Name = "lvDonHang";
            lvDonHang.Size = new Size(514, 236);
            lvDonHang.TabIndex = 0;
            lvDonHang.UseCompatibleStateImageBehavior = false;
            lvDonHang.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Tên Món";
            columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Số Lượng";
            columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Ghi Chú Khách";
            columnHeader3.Width = 107;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Ghi Chú Bếp";
            columnHeader4.Width = 93;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Trạng Thái";
            columnHeader5.Width = 165;
            // 
            // TheoDoiOrder_PV
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel3);
            Controls.Add(panel9);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TheoDoiOrder_PV";
            Text = "TheoDoiOrder";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private Label label2;
        private Label label1;
        private ComboBox cbSoBan;
        private ComboBox cbTrangThai;
        private Button btnLamMoi;
        private Button btnXoa;
        private Panel panel9;
        private Label lblTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dgvDonHang;
        private ListView lvDonHang;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
    }
}
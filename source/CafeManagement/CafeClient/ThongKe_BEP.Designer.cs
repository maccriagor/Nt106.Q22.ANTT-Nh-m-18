namespace CafeClient
{
    partial class ThongKe_BEP
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
            panel1 = new Panel();
            tbtrungbinh = new TextBox();
            tbtile = new TextBox();
            tbmon = new TextBox();
            tbdon = new TextBox();
            btnXuatBaoCao = new Button();
            btnLamMoi = new Button();
            cbdaubep = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            groupBox1 = new GroupBox();
            lvdaubep = new ListView();
            colSTTChef = new ColumnHeader();
            colTenDauBep = new ColumnHeader();
            colTongSoDon = new ColumnHeader();
            colDonHoanThanh = new ColumnHeader();
            colTiLeHoanThanh = new ColumnHeader();
            colTongSoMon = new ColumnHeader();
            colMonHoanThanh = new ColumnHeader();
            groupBox2 = new GroupBox();
            lvseller = new ListView();
            colSTTFood = new ColumnHeader();
            colTenMon = new ColumnHeader();
            colLoaiMon = new ColumnHeader();
            colSoLuong = new ColumnHeader();
            colSoDon = new ColumnHeader();
            colTiLe = new ColumnHeader();
            panel9 = new Panel();
            lblTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel9.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tbtrungbinh);
            panel1.Controls.Add(tbtile);
            panel1.Controls.Add(tbmon);
            panel1.Controls.Add(tbdon);
            panel1.Controls.Add(btnXuatBaoCao);
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(cbdaubep);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtpDenNgay);
            panel1.Controls.Add(dtpTuNgay);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 533);
            panel1.TabIndex = 0;
            // 
            // tbtrungbinh
            // 
            tbtrungbinh.Location = new Point(182, 249);
            tbtrungbinh.Name = "tbtrungbinh";
            tbtrungbinh.Size = new Size(146, 28);
            tbtrungbinh.TabIndex = 9;
            // 
            // tbtile
            // 
            tbtile.Location = new Point(167, 215);
            tbtile.Name = "tbtile";
            tbtile.Size = new Size(161, 28);
            tbtile.TabIndex = 9;
            // 
            // tbmon
            // 
            tbmon.Location = new Point(135, 181);
            tbmon.Name = "tbmon";
            tbmon.Size = new Size(193, 28);
            tbmon.TabIndex = 9;
            // 
            // tbdon
            // 
            tbdon.Location = new Point(132, 146);
            tbdon.Name = "tbdon";
            tbdon.Size = new Size(196, 28);
            tbdon.TabIndex = 9;
            // 
            // btnXuatBaoCao
            // 
            btnXuatBaoCao.BackColor = Color.FromArgb(128, 64, 0);
            btnXuatBaoCao.FlatAppearance.BorderSize = 0;
            btnXuatBaoCao.FlatStyle = FlatStyle.Flat;
            btnXuatBaoCao.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXuatBaoCao.ForeColor = Color.White;
            btnXuatBaoCao.Location = new Point(10, 305);
            btnXuatBaoCao.Name = "btnXuatBaoCao";
            btnXuatBaoCao.Size = new Size(156, 60);
            btnXuatBaoCao.TabIndex = 7;
            btnXuatBaoCao.Text = "📄 Xuất báo cáo";
            btnXuatBaoCao.UseVisualStyleBackColor = false;
            btnXuatBaoCao.Click += btnXuatBaoCao_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.White;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.FromArgb(128, 64, 0);
            btnLamMoi.Location = new Point(172, 305);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(156, 60);
            btnLamMoi.TabIndex = 8;
            btnLamMoi.Text = "🔁 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // cbdaubep
            // 
            cbdaubep.FormattingEnabled = true;
            cbdaubep.Location = new Point(100, 89);
            cbdaubep.Name = "cbdaubep";
            cbdaubep.Size = new Size(226, 29);
            cbdaubep.TabIndex = 6;
            cbdaubep.SelectedIndexChanged += cbdaubep_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(128, 64, 64);
            label6.Location = new Point(7, 215);
            label6.Name = "label6";
            label6.Size = new Size(154, 24);
            label6.TabIndex = 4;
            label6.Text = "Tỉ lệ hoàn thành:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(128, 64, 64);
            label7.Location = new Point(7, 251);
            label7.Name = "label7";
            label7.Size = new Size(169, 24);
            label7.TabIndex = 4;
            label7.Text = "Số đơn trung bình:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(128, 64, 64);
            label5.Location = new Point(7, 181);
            label5.Name = "label5";
            label5.Size = new Size(122, 24);
            label5.TabIndex = 4;
            label5.Text = "Tổng số món:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(128, 64, 64);
            label4.Location = new Point(7, 146);
            label4.Name = "label4";
            label4.Size = new Size(119, 24);
            label4.TabIndex = 4;
            label4.Text = "Tổng số đơn:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(7, 89);
            label2.Name = "label2";
            label2.Size = new Size(87, 24);
            label2.TabIndex = 4;
            label2.Text = "Đầu bếp:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(7, 49);
            label3.Name = "label3";
            label3.Size = new Size(44, 24);
            label3.TabIndex = 4;
            label3.Text = "Đến";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(5, 14);
            label1.Name = "label1";
            label1.Size = new Size(32, 24);
            label1.TabIndex = 5;
            label1.Text = "Từ";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(51, 49);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(275, 28);
            dtpDenNgay.TabIndex = 2;
            dtpDenNgay.ValueChanged += dtpDenNgay_ValueChanged;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(51, 11);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(275, 28);
            dtpTuNgay.TabIndex = 3;
            dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lvdaubep);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(519, 260);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "TOP ĐẦU BẾP:";
            // 
            // lvdaubep
            // 
            lvdaubep.Columns.AddRange(new ColumnHeader[] { colSTTChef, colTenDauBep, colTongSoDon, colDonHoanThanh, colTiLeHoanThanh, colTongSoMon, colMonHoanThanh });
            lvdaubep.Dock = DockStyle.Fill;
            lvdaubep.FullRowSelect = true;
            lvdaubep.GridLines = true;
            lvdaubep.Location = new Point(3, 24);
            lvdaubep.Name = "lvdaubep";
            lvdaubep.Size = new Size(513, 233);
            lvdaubep.TabIndex = 0;
            lvdaubep.UseCompatibleStateImageBehavior = false;
            lvdaubep.View = View.Details;
            // 
            // colSTTChef
            // 
            colSTTChef.Text = "STT";
            colSTTChef.Width = 45;
            // 
            // colTenDauBep
            // 
            colTenDauBep.Text = "Tên đầu bếp";
            colTenDauBep.Width = 140;
            // 
            // colTongSoDon
            // 
            colTongSoDon.Text = "Tổng số đơn";
            colTongSoDon.Width = 130;
            // 
            // colDonHoanThanh
            // 
            colDonHoanThanh.Text = "Đơn hoàn thành";
            colDonHoanThanh.Width = 140;
            // 
            // colTiLeHoanThanh
            // 
            colTiLeHoanThanh.Text = "Tỉ lệ hoàn thành";
            colTiLeHoanThanh.Width = 140;
            // 
            // colTongSoMon
            // 
            colTongSoMon.Text = "Tổng số món";
            colTongSoMon.Width = 120;
            // 
            // colMonHoanThanh
            // 
            colMonHoanThanh.Text = "Số món hoàn thành";
            colMonHoanThanh.Width = 150;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lvseller);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox2.Location = new Point(3, 269);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(519, 261);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "BEST SELLER";
            // 
            // lvseller
            // 
            lvseller.Columns.AddRange(new ColumnHeader[] { colSTTFood, colTenMon, colLoaiMon, colSoLuong, colSoDon, colTiLe });
            lvseller.Dock = DockStyle.Fill;
            lvseller.FullRowSelect = true;
            lvseller.GridLines = true;
            lvseller.Location = new Point(3, 24);
            lvseller.Name = "lvseller";
            lvseller.Size = new Size(513, 234);
            lvseller.TabIndex = 0;
            lvseller.UseCompatibleStateImageBehavior = false;
            lvseller.View = View.Details;
            // 
            // colSTTFood
            // 
            colSTTFood.Text = "STT";
            colSTTFood.Width = 45;
            // 
            // colTenMon
            // 
            colTenMon.Text = "Tên món";
            colTenMon.Width = 150;
            // 
            // colLoaiMon
            // 
            colLoaiMon.Text = "Loại món";
            colLoaiMon.Width = 90;
            // 
            // colSoLuong
            // 
            colSoLuong.Text = "Số lượng";
            colSoLuong.Width = 80;
            // 
            // colSoDon
            // 
            colSoDon.Text = "Số đơn";
            colSoDon.Width = 80;
            // 
            // colTiLe
            // 
            colTiLe.Text = "Tỉ lệ";
            colTiLe.Width = 80;
            // 
            // panel9
            // 
            panel9.Controls.Add(lblTitle);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(861, 73);
            panel9.TabIndex = 8;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(243, 49);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Thống kê bếp";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(336, 73);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(525, 533);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // ThongKe_BEP
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(panel9);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ThongKe_BEP";
            Text = "ThongKe_BEP";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListView lvdaubep;
        private ListView lvseller;
        private Label label3;
        private Label label1;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private ComboBox cbdaubep;
        private Label label2;
        private Button btnXuatBaoCao;
        private Button btnLamMoi;
        private TextBox tbtrungbinh;
        private TextBox tbtile;
        private TextBox tbmon;
        private TextBox tbdon;
        private Label label6;
        private Label label7;
        private Label label5;
        private Label label4;
        private Panel panel9;
        private Label lblTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private ColumnHeader colSTTChef;
        private ColumnHeader colTenDauBep;
        private ColumnHeader colTongSoDon;
        private ColumnHeader colDonHoanThanh;
        private ColumnHeader colTiLeHoanThanh;
        private ColumnHeader colTongSoMon;
        private ColumnHeader colMonHoanThanh;
        private ColumnHeader colSTTFood;
        private ColumnHeader colTenMon;
        private ColumnHeader colLoaiMon;
        private ColumnHeader colSoLuong;
        private ColumnHeader colSoDon;
        private ColumnHeader colTiLe;
    }
}
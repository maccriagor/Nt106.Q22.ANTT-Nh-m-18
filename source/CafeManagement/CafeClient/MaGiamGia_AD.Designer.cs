namespace CafeClient
{
    partial class MaGiamGia_AD
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
            dgvNhanVien = new DataGridView();
            tbCode = new TextBox();
            panel1 = new Panel();
            tbMaKhuyenMai = new TextBox();
            label1 = new Label();
            panel4 = new Panel();
            label2 = new Label();
            panel5 = new Panel();
            label5 = new Label();
            panel8 = new Panel();
            tbGiaTriGiam = new TextBox();
            label3 = new Label();
            panel6 = new Panel();
            dtpNgayBatDau = new DateTimePicker();
            label4 = new Label();
            panel7 = new Panel();
            panel3 = new Panel();
            panel9 = new Panel();
            dtpNgayKetThuc = new DateTimePicker();
            label6 = new Label();
            panel2 = new Panel();
            txtTim = new TextBox();
            btnTim = new Button();
            tbTimKiem = new TextBox();
            btnTimKiem = new Button();
            lblTitle = new Label();
            btnXem = new Button();
            textBox1 = new TextBox();
            btnSua = new Button();
            button3 = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            cbLoaiKhuynMai = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel9.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(12, 6);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(528, 437);
            dgvNhanVien.TabIndex = 0;
            // 
            // tbCode
            // 
            tbCode.Location = new Point(3, 31);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(296, 28);
            tbCode.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvNhanVien);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 151);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 455);
            panel1.TabIndex = 9;
            // 
            // tbMaKhuyenMai
            // 
            tbMaKhuyenMai.Location = new Point(3, 31);
            tbMaKhuyenMai.Name = "tbMaKhuyenMai";
            tbMaKhuyenMai.Size = new Size(296, 28);
            tbMaKhuyenMai.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(146, 24);
            label1.TabIndex = 0;
            label1.Text = "Mã khuyến mãi:";
            // 
            // panel4
            // 
            panel4.Controls.Add(tbMaKhuyenMai);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(8, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(328, 62);
            panel4.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 24);
            label2.TabIndex = 0;
            label2.Text = "Code:";
            // 
            // panel5
            // 
            panel5.Controls.Add(tbCode);
            panel5.Controls.Add(label2);
            panel5.Location = new Point(8, 69);
            panel5.Name = "panel5";
            panel5.Size = new Size(328, 62);
            panel5.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(128, 64, 64);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(153, 24);
            label5.TabIndex = 0;
            label5.Text = "Loại khuyến mãi:";
            // 
            // panel8
            // 
            panel8.Controls.Add(cbLoaiKhuynMai);
            panel8.Controls.Add(label5);
            panel8.Location = new Point(8, 134);
            panel8.Name = "panel8";
            panel8.Size = new Size(307, 62);
            panel8.TabIndex = 0;
            // 
            // tbGiaTriGiam
            // 
            tbGiaTriGiam.Location = new Point(3, 31);
            tbGiaTriGiam.Name = "tbGiaTriGiam";
            tbGiaTriGiam.Size = new Size(296, 28);
            tbGiaTriGiam.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(113, 24);
            label3.TabIndex = 0;
            label3.Text = "Giá trị giảm:";
            // 
            // panel6
            // 
            panel6.Controls.Add(tbGiaTriGiam);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(6, 202);
            panel6.Name = "panel6";
            panel6.Size = new Size(309, 62);
            panel6.TabIndex = 0;
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.Location = new Point(3, 31);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(296, 28);
            dtpNgayBatDau.TabIndex = 1;
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
            label4.Text = "Ngày bắt đầu:";
            // 
            // panel7
            // 
            panel7.Controls.Add(dtpNgayBatDau);
            panel7.Controls.Add(label4);
            panel7.Location = new Point(6, 268);
            panel7.Name = "panel7";
            panel7.Size = new Size(309, 62);
            panel7.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel9);
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
            // panel9
            // 
            panel9.Controls.Add(dtpNgayKetThuc);
            panel9.Controls.Add(label6);
            panel9.Location = new Point(6, 336);
            panel9.Name = "panel9";
            panel9.Size = new Size(309, 62);
            panel9.TabIndex = 0;
            // 
            // dtpNgayKetThuc
            // 
            dtpNgayKetThuc.Location = new Point(3, 31);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(296, 28);
            dtpNgayKetThuc.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(128, 64, 64);
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(130, 24);
            label6.TabIndex = 0;
            label6.Text = "Ngày kết thúc:";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtTim);
            panel2.Controls.Add(btnTim);
            panel2.Controls.Add(tbTimKiem);
            panel2.Controls.Add(btnTimKiem);
            panel2.Controls.Add(lblTitle);
            panel2.Controls.Add(btnXem);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnThem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(861, 151);
            panel2.TabIndex = 10;
            // 
            // txtTim
            // 
            txtTim.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTim.Location = new Point(548, 98);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(201, 28);
            txtTim.TabIndex = 14;
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTim.BackColor = Color.FromArgb(128, 64, 0);
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTim.ForeColor = Color.White;
            btnTim.Location = new Point(757, 83);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(92, 57);
            btnTim.TabIndex = 15;
            btnTim.Text = "🔍 Tìm";
            btnTim.UseVisualStyleBackColor = false;
            // 
            // tbTimKiem
            // 
            tbTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tbTimKiem.Location = new Point(1209, 149);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(201, 28);
            tbTimKiem.TabIndex = 12;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(128, 64, 0);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(1418, 134);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(92, 57);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "🔍 Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(226, 49);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Mã giảm giá";
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
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox1.Location = new Point(1869, 200);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 28);
            textBox1.TabIndex = 0;
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
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(128, 64, 0);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(2078, 185);
            button3.Name = "button3";
            button3.Size = new Size(92, 57);
            button3.TabIndex = 1;
            button3.Text = "🔍 Tìm";
            button3.UseVisualStyleBackColor = false;
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
            // 
            // cbLoaiKhuynMai
            // 
            cbLoaiKhuynMai.FormattingEnabled = true;
            cbLoaiKhuynMai.Location = new Point(3, 27);
            cbLoaiKhuynMai.Name = "cbLoaiKhuynMai";
            cbLoaiKhuynMai.Size = new Size(296, 29);
            cbLoaiKhuynMai.TabIndex = 1;
            // 
            // MaGiamGia_AD
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
            Name = "MaGiamGia_AD";
            Text = "MaGiamGia";
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel3.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvNhanVien;
        private TextBox tbCode;
        private Panel panel1;
        private TextBox tbMaKhuyenMai;
        private Label label1;
        private Panel panel4;
        private Label label2;
        private Panel panel5;
        private Label label5;
        private Panel panel8;
        private TextBox tbGiaTriGiam;
        private Label label3;
        private Panel panel6;
        private DateTimePicker dtpNgayBatDau;
        private Label label4;
        private Panel panel7;
        private Panel panel3;
        private Panel panel9;
        private DateTimePicker dtpNgayKetThuc;
        private Label label6;
        private Panel panel2;
        private TextBox tbTimKiem;
        private Button btnTimKiem;
        private Label lblTitle;
        private Button btnXem;
        private TextBox textBox1;
        private Button btnSua;
        private Button button3;
        private Button btnXoa;
        private Button btnThem;
        private TextBox txtTim;
        private Button btnTim;
        private ComboBox cbLoaiKhuynMai;
    }
}
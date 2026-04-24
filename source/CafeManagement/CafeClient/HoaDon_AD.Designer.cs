namespace CafeClient
{
    partial class HoaDon_AD
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
            panel2 = new Panel();
            btnXoa = new Button();
            lblTitle = new Label();
            btnXem = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            panel1 = new Panel();
            flpHoaDon = new FlowLayoutPanel();
            txtMaHD = new TextBox();
            label1 = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            cbMaNV = new ComboBox();
            label2 = new Label();
            panel6 = new Panel();
            cbMaBanAn = new ComboBox();
            label3 = new Label();
            panel7 = new Panel();
            dtpNgayXuat = new DateTimePicker();
            label4 = new Label();
            panel3 = new Panel();
            btnSua = new Button();
            btnThem = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(lblTitle);
            panel2.Controls.Add(btnXem);
            panel2.Controls.Add(btnLamMoi);
            panel2.Controls.Add(txtTimKiem);
            panel2.Controls.Add(btnTimKiem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(861, 147);
            panel2.TabIndex = 5;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(128, 64, 0);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(319, 73);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(139, 74);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 49);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "Hóa đơn";
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(128, 64, 0);
            btnXem.FlatAppearance.BorderSize = 0;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(12, 73);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(139, 74);
            btnXem.TabIndex = 1;
            btnXem.Text = "👁️ Xem";
            btnXem.UseVisualStyleBackColor = false;
            btnXem.Click += btnXem_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(128, 64, 0);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(164, 73);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(139, 74);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "🔁 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTimKiem.Location = new Point(546, 87);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(200, 28);
            txtTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(128, 64, 0);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(761, 71);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(92, 57);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "🔍 Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(flpHoaDon);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 147);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 459);
            panel1.TabIndex = 6;
            // 
            // flpHoaDon
            // 
            flpHoaDon.AutoScroll = true;
            flpHoaDon.BackColor = Color.LightGray;
            flpHoaDon.FlowDirection = FlowDirection.TopDown;
            flpHoaDon.Location = new Point(12, 6);
            flpHoaDon.Name = "flpHoaDon";
            flpHoaDon.Padding = new Padding(5);
            flpHoaDon.Size = new Size(518, 441);
            flpHoaDon.TabIndex = 0;
            flpHoaDon.WrapContents = false;
            // 
            // txtMaHD
            // 
            txtMaHD.Location = new Point(3, 31);
            txtMaHD.Name = "txtMaHD";
            txtMaHD.Size = new Size(296, 28);
            txtMaHD.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 24);
            label1.TabIndex = 0;
            label1.Text = "Mã hóa đơn:";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtMaHD);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(8, 26);
            panel4.Name = "panel4";
            panel4.Size = new Size(328, 62);
            panel4.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(cbMaNV);
            panel5.Controls.Add(label2);
            panel5.Location = new Point(8, 94);
            panel5.Name = "panel5";
            panel5.Size = new Size(328, 62);
            panel5.TabIndex = 0;
            // 
            // cbMaNV
            // 
            cbMaNV.FormattingEnabled = true;
            cbMaNV.Location = new Point(3, 27);
            cbMaNV.Name = "cbMaNV";
            cbMaNV.Size = new Size(296, 29);
            cbMaNV.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 24);
            label2.TabIndex = 0;
            label2.Text = "Mã nhân viên";
            // 
            // panel6
            // 
            panel6.Controls.Add(cbMaBanAn);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(8, 162);
            panel6.Name = "panel6";
            panel6.Size = new Size(328, 62);
            panel6.TabIndex = 0;
            // 
            // cbMaBanAn
            // 
            cbMaBanAn.FormattingEnabled = true;
            cbMaBanAn.Location = new Point(3, 27);
            cbMaBanAn.Name = "cbMaBanAn";
            cbMaBanAn.Size = new Size(296, 29);
            cbMaBanAn.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(106, 24);
            label3.TabIndex = 0;
            label3.Text = "Mã bàn ăn:";
            // 
            // panel7
            // 
            panel7.Controls.Add(dtpNgayXuat);
            panel7.Controls.Add(label4);
            panel7.Location = new Point(8, 230);
            panel7.Name = "panel7";
            panel7.Size = new Size(328, 62);
            panel7.TabIndex = 0;
            // 
            // dtpNgayXuat
            // 
            dtpNgayXuat.Location = new Point(3, 27);
            dtpNgayXuat.Name = "dtpNgayXuat";
            dtpNgayXuat.Size = new Size(292, 28);
            dtpNgayXuat.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(128, 64, 64);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(170, 24);
            label4.TabIndex = 0;
            label4.Text = "Ngày xuất hóa đơn";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnSua);
            panel3.Controls.Add(btnThem);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(546, 147);
            panel3.Name = "panel3";
            panel3.Size = new Size(315, 459);
            panel3.TabIndex = 4;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(128, 64, 0);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(172, 332);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(116, 74);
            btnSua.TabIndex = 3;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(128, 64, 0);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(11, 332);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(116, 74);
            btnThem.TabIndex = 2;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // HoaDon_AD
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
            Name = "HoaDon_AD";
            Text = "HoaDon";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Panel panel1;
        private Button btnXem;
        private Button btnLamMoi;
        private TextBox txtMaHD;
        private Label label1;
        private Panel panel4;
        private Panel panel5;
        private Label label2;
        private Panel panel6;
        private Label label3;
        private Panel panel7;
        private Label label4;
        private Panel panel3;
        private Label lblTitle;
        private Button btnThem;
        private Button btnXoa;
        private ComboBox cbMaNV;
        private ComboBox cbMaBanAn;
        private DateTimePicker dtpNgayXuat;
        private Button btnSua;
        private FlowLayoutPanel flpHoaDon;
    }
}
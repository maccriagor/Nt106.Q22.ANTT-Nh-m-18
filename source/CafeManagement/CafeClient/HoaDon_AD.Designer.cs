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
            txtNgayXuatHD = new TextBox();
            panel2 = new Panel();
            lblTitle = new Label();
            btnXem = new Button();
            btnLamMoi = new Button();
            tbTimKiem = new TextBox();
            btnTimKiem = new Button();
            panel1 = new Panel();
            dgvHoaDon = new DataGridView();
            tbMaHoaDon = new TextBox();
            label1 = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            label2 = new Label();
            panel6 = new Panel();
            label3 = new Label();
            panel7 = new Panel();
            label4 = new Label();
            panel3 = new Panel();
            txtMaBanAn = new TextBox();
            txtMaNhanVien = new TextBox();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txtNgayXuatHD
            // 
            txtNgayXuatHD.Location = new Point(3, 31);
            txtNgayXuatHD.Name = "txtNgayXuatHD";
            txtNgayXuatHD.Size = new Size(296, 28);
            txtNgayXuatHD.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTitle);
            panel2.Controls.Add(btnXem);
            panel2.Controls.Add(btnLamMoi);
            panel2.Controls.Add(tbTimKiem);
            panel2.Controls.Add(btnTimKiem);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(861, 147);
            panel2.TabIndex = 5;
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
            // 
            // tbTimKiem
            // 
            tbTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tbTimKiem.Location = new Point(546, 87);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(200, 28);
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
            btnTimKiem.Location = new Point(757, 71);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(92, 57);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "🔍 Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvHoaDon);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 147);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 459);
            panel1.TabIndex = 6;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(12, 11);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(531, 436);
            dgvHoaDon.TabIndex = 0;
            // 
            // tbMaHoaDon
            // 
            tbMaHoaDon.Location = new Point(3, 31);
            tbMaHoaDon.Name = "tbMaHoaDon";
            tbMaHoaDon.Size = new Size(296, 28);
            tbMaHoaDon.TabIndex = 0;
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
            panel4.Controls.Add(tbMaHoaDon);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(8, 26);
            panel4.Name = "panel4";
            panel4.Size = new Size(328, 62);
            panel4.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtMaNhanVien);
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
            label2.Size = new Size(125, 24);
            label2.TabIndex = 0;
            label2.Text = "Mã nhân viên";
            // 
            // panel6
            // 
            panel6.Controls.Add(txtMaBanAn);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(8, 162);
            panel6.Name = "panel6";
            panel6.Size = new Size(328, 62);
            panel6.TabIndex = 0;
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
            panel7.Controls.Add(txtNgayXuatHD);
            panel7.Controls.Add(label4);
            panel7.Location = new Point(8, 230);
            panel7.Name = "panel7";
            panel7.Size = new Size(328, 62);
            panel7.TabIndex = 0;
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
            // txtMaBanAn
            // 
            txtMaBanAn.Location = new Point(3, 27);
            txtMaBanAn.Name = "txtMaBanAn";
            txtMaBanAn.Size = new Size(296, 28);
            txtMaBanAn.TabIndex = 0;
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Location = new Point(3, 27);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(296, 28);
            txtMaNhanVien.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
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

        private TextBox txtNgayXuatHD;
        private Panel panel2;
        private TextBox tbTimKiem;
        private Button btnTimKiem;
        private Panel panel1;
        private Button btnXem;
        private Button btnLamMoi;
        private DataGridView dgvHoaDon;
        private TextBox tbMaHoaDon;
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
        private TextBox txtMaNhanVien;
        private TextBox txtMaBanAn;
    }
}
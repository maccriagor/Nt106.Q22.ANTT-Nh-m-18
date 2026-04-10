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
            label4 = new Label();
            panel7 = new Panel();
            tbTrangThai = new TextBox();
            label3 = new Label();
            panel6 = new Panel();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            panel5 = new Panel();
            tbTenBan = new TextBox();
            tbMaBan = new TextBox();
            panel4 = new Panel();
            label1 = new Label();
            tbTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnXem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            dgvBanAn = new DataGridView();
            panel3 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBanAn).BeginInit();
            panel3.SuspendLayout();
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
            panel7.Controls.Add(tbTrangThai);
            panel7.Controls.Add(label4);
            panel7.Location = new Point(8, 230);
            panel7.Name = "panel7";
            panel7.Size = new Size(328, 62);
            panel7.TabIndex = 0;
            // 
            // tbTrangThai
            // 
            tbTrangThai.Location = new Point(3, 31);
            tbTrangThai.Name = "tbTrangThai";
            tbTrangThai.Size = new Size(296, 28);
            tbTrangThai.TabIndex = 0;
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
            panel6.Controls.Add(numericUpDown1);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(8, 162);
            panel6.Name = "panel6";
            panel6.Size = new Size(328, 62);
            panel6.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(3, 31);
            numericUpDown1.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(296, 28);
            numericUpDown1.TabIndex = 1;
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
            tbTimKiem.Location = new Point(6, 28);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(201, 28);
            tbTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(128, 64, 0);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(215, 13);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(92, 57);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "🔍 Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(128, 64, 0);
            btnXem.FlatAppearance.BorderSize = 0;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(384, 9);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(116, 74);
            btnXem.TabIndex = 1;
            btnXem.Text = "👁️ Xem";
            btnXem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(128, 64, 0);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(259, 9);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(116, 74);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(128, 64, 0);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(134, 9);
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
            btnThem.Location = new Point(11, 9);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(116, 74);
            btnThem.TabIndex = 1;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // dgvBanAn
            // 
            dgvBanAn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBanAn.Location = new Point(12, 96);
            dgvBanAn.Name = "dgvBanAn";
            dgvBanAn.RowHeadersWidth = 51;
            dgvBanAn.Size = new Size(488, 395);
            dgvBanAn.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(534, 107);
            panel3.Name = "panel3";
            panel3.Size = new Size(315, 407);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(tbTimKiem);
            panel2.Controls.Add(btnTimKiem);
            panel2.Location = new Point(534, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(315, 83);
            panel2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.Controls.Add(btnXem);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(dgvBanAn);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(513, 502);
            panel1.TabIndex = 3;
            // 
            // BanAn_AD
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 526);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BanAn_AD";
            Text = "BanAn";
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBanAn).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label4;
        private Panel panel7;
        private TextBox tbTrangThai;
        private Label label3;
        private Panel panel6;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private Panel panel5;
        private TextBox tbMaBan;
        private Panel panel4;
        private Label label1;
        private TextBox tbTimKiem;
        private Button btnTimKiem;
        private Button btnXem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private DataGridView dgvBanAn;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private TextBox tbTenBan;
    }
}
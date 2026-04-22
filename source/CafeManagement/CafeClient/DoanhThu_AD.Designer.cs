namespace CafeClient
{
    partial class DoanhThu_AD
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
            dgvDoanhThu = new DataGridView();
            panel2 = new Panel();
            btnXuatBaoCao = new Button();
            btnXem = new Button();
            label3 = new Label();
            lblTitle = new Label();
            label1 = new Label();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            lbTongDoanhThu = new Label();
            label2 = new Label();
            panel4 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvDoanhThu);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 140);
            panel1.Name = "panel1";
            panel1.Size = new Size(861, 426);
            panel1.TabIndex = 1;
            // 
            // dgvDoanhThu
            // 
            dgvDoanhThu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDoanhThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoanhThu.Location = new Point(8, 6);
            dgvDoanhThu.Name = "dgvDoanhThu";
            dgvDoanhThu.RowHeadersWidth = 51;
            dgvDoanhThu.Size = new Size(844, 414);
            dgvDoanhThu.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnXuatBaoCao);
            panel2.Controls.Add(btnXem);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblTitle);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dtpDenNgay);
            panel2.Controls.Add(dtpTuNgay);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(861, 140);
            panel2.TabIndex = 2;
            // 
            // btnXuatBaoCao
            // 
            btnXuatBaoCao.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnXuatBaoCao.BackColor = Color.FromArgb(128, 64, 0);
            btnXuatBaoCao.FlatAppearance.BorderSize = 0;
            btnXuatBaoCao.FlatStyle = FlatStyle.Flat;
            btnXuatBaoCao.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXuatBaoCao.ForeColor = Color.White;
            btnXuatBaoCao.Location = new Point(668, 68);
            btnXuatBaoCao.Name = "btnXuatBaoCao";
            btnXuatBaoCao.Size = new Size(181, 63);
            btnXuatBaoCao.TabIndex = 2;
            btnXuatBaoCao.Text = "📄 Xuất báo cáo";
            btnXuatBaoCao.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            btnXem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnXem.BackColor = Color.FromArgb(128, 64, 0);
            btnXem.FlatAppearance.BorderSize = 0;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(477, 68);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(181, 63);
            btnXem.TabIndex = 2;
            btnXem.Text = "👁️ Xem";
            btnXem.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(5, 105);
            label3.Name = "label3";
            label3.Size = new Size(44, 24);
            label3.TabIndex = 1;
            label3.Text = "Đến";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(196, 49);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "Doanh thu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(5, 73);
            label1.Name = "label1";
            label1.Size = new Size(32, 24);
            label1.TabIndex = 1;
            label1.Text = "Từ";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(49, 105);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(275, 28);
            dtpDenNgay.TabIndex = 0;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(49, 67);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(275, 28);
            dtpTuNgay.TabIndex = 0;
            // 
            // lbTongDoanhThu
            // 
            lbTongDoanhThu.AutoSize = true;
            lbTongDoanhThu.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTongDoanhThu.ForeColor = Color.Red;
            lbTongDoanhThu.Location = new Point(177, 7);
            lbTongDoanhThu.Name = "lbTongDoanhThu";
            lbTongDoanhThu.Size = new Size(132, 28);
            lbTongDoanhThu.TabIndex = 2;
            lbTongDoanhThu.Text = "36.000 VND ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(3, 7);
            label2.Name = "label2";
            label2.Size = new Size(168, 28);
            label2.TabIndex = 3;
            label2.Text = "Tổng doanh thu: ";
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Controls.Add(lbTongDoanhThu);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 566);
            panel4.Name = "panel4";
            panel4.Size = new Size(861, 40);
            panel4.TabIndex = 4;
            // 
            // DoanhThu_AD
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DoanhThu_AD";
            Text = "DoanhThu";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvDoanhThu;
        private Panel panel2;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private Button btnXuatBaoCao;
        private Button btnXem;
        private Label label1;
        private Label label3;
        private Label lblTitle;
        private Label lbTongDoanhThu;
        private Label label2;
        private Panel panel4;
    }
}
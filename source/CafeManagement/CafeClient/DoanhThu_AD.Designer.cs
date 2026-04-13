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
            lbTongDoanhThu = new Label();
            label2 = new Label();
            panel2 = new Panel();
            btnXuatBaoCao = new Button();
            btnXem = new Button();
            label3 = new Label();
            label1 = new Label();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(dgvDoanhThu);
            panel1.Controls.Add(lbTongDoanhThu);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 109);
            panel1.Name = "panel1";
            panel1.Size = new Size(837, 417);
            panel1.TabIndex = 1;
            // 
            // dgvDoanhThu
            // 
            dgvDoanhThu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDoanhThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoanhThu.Location = new Point(3, 3);
            dgvDoanhThu.Name = "dgvDoanhThu";
            dgvDoanhThu.RowHeadersWidth = 51;
            dgvDoanhThu.Size = new Size(831, 369);
            dgvDoanhThu.TabIndex = 1;
            // 
            // lbTongDoanhThu
            // 
            lbTongDoanhThu.AutoSize = true;
            lbTongDoanhThu.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTongDoanhThu.ForeColor = Color.Red;
            lbTongDoanhThu.Location = new Point(177, 380);
            lbTongDoanhThu.Name = "lbTongDoanhThu";
            lbTongDoanhThu.Size = new Size(132, 28);
            lbTongDoanhThu.TabIndex = 1;
            lbTongDoanhThu.Text = "36.000 VND ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(3, 380);
            label2.Name = "label2";
            label2.Size = new Size(168, 28);
            label2.TabIndex = 1;
            label2.Text = "Tổng doanh thu: ";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnXuatBaoCao);
            panel2.Controls.Add(btnXem);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dtpDenNgay);
            panel2.Controls.Add(dtpTuNgay);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(837, 79);
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
            btnXuatBaoCao.Location = new Point(644, 7);
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
            btnXem.Location = new Point(453, 7);
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
            label3.Location = new Point(5, 42);
            label3.Name = "label3";
            label3.Size = new Size(44, 24);
            label3.TabIndex = 1;
            label3.Text = "Đến";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(5, 10);
            label1.Name = "label1";
            label1.Size = new Size(32, 24);
            label1.TabIndex = 1;
            label1.Text = "Từ";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(49, 42);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(275, 28);
            dtpDenNgay.TabIndex = 0;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(49, 4);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(275, 28);
            dtpTuNgay.TabIndex = 0;
            // 
            // DoanhThu_AD
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 526);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DoanhThu_AD";
            Text = "DoanhThu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Label label2;
        private Label label1;
        private Label label3;
        private Label lbTongDoanhThu;
    }
}
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
            textBox1 = new TextBox();
            panel2 = new Panel();
            tbTimKiem = new TextBox();
            btnTimKiem = new Button();
            panel1 = new Panel();
            btnXem = new Button();
            btnSua = new Button();
            dgvHoaDon = new DataGridView();
            tbMaMon = new TextBox();
            label1 = new Label();
            panel4 = new Panel();
            cbMaLoaiMon = new ComboBox();
            panel5 = new Panel();
            label2 = new Label();
            panel6 = new Panel();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            panel7 = new Panel();
            label4 = new Label();
            panel3 = new Panel();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(296, 28);
            textBox1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(tbTimKiem);
            panel2.Controls.Add(btnTimKiem);
            panel2.Location = new Point(421, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(428, 83);
            panel2.TabIndex = 5;
            // 
            // tbTimKiem
            // 
            tbTimKiem.Location = new Point(1, 28);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(315, 28);
            tbTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(128, 64, 0);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(327, 12);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(92, 57);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "🔍 Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnXem);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(dgvHoaDon);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(513, 502);
            panel1.TabIndex = 6;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(128, 64, 0);
            btnXem.FlatAppearance.BorderSize = 0;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(12, 9);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(139, 74);
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
            btnSua.Location = new Point(161, 9);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(139, 74);
            btnSua.TabIndex = 1;
            btnSua.Text = "🔁 Làm mới";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(12, 96);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(488, 395);
            dgvHoaDon.TabIndex = 0;
            // 
            // tbMaMon
            // 
            tbMaMon.Location = new Point(3, 31);
            tbMaMon.Name = "tbMaMon";
            tbMaMon.Size = new Size(296, 28);
            tbMaMon.TabIndex = 0;
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
            // panel4
            // 
            panel4.Controls.Add(tbMaMon);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(8, 26);
            panel4.Name = "panel4";
            panel4.Size = new Size(328, 62);
            panel4.TabIndex = 0;
            // 
            // cbMaLoaiMon
            // 
            cbMaLoaiMon.FormattingEnabled = true;
            cbMaLoaiMon.Location = new Point(3, 30);
            cbMaLoaiMon.Name = "cbMaLoaiMon";
            cbMaLoaiMon.Size = new Size(296, 29);
            cbMaLoaiMon.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(cbMaLoaiMon);
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
            label2.Size = new Size(82, 24);
            label2.TabIndex = 0;
            label2.Text = "Tên bàn:";
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
            // panel7
            // 
            panel7.Controls.Add(textBox1);
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
            label4.Size = new Size(100, 24);
            label4.TabIndex = 0;
            label4.Text = "Trạng thái:";
            // 
            // panel3
            // 
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(534, 107);
            panel3.Name = "panel3";
            panel3.Size = new Size(315, 407);
            panel3.TabIndex = 4;
            // 
            // HoaDon_AD
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 526);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
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
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Panel panel2;
        private TextBox tbTimKiem;
        private Button btnTimKiem;
        private Panel panel1;
        private Button btnXem;
        private Button btnSua;
        private DataGridView dgvHoaDon;
        private TextBox tbMaMon;
        private Label label1;
        private Panel panel4;
        private ComboBox cbMaLoaiMon;
        private Panel panel5;
        private Label label2;
        private Panel panel6;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Panel panel7;
        private Label label4;
        private Panel panel3;
    }
}
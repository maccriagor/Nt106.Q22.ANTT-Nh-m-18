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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            listView2 = new ListView();
            label1 = new Label();
            label2 = new Label();
            cbTrangThai = new ComboBox();
            cbSoBan = new ComboBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            label3 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(510, 236);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(listView2);
            panel2.Location = new Point(12, 254);
            panel2.Name = "panel2";
            panel2.Size = new Size(510, 260);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnLamMoi);
            panel3.Controls.Add(btnXoa);
            panel3.Controls.Add(cbSoBan);
            panel3.Controls.Add(cbTrangThai);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(528, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(321, 236);
            panel3.TabIndex = 0;
            // 
            // listView2
            // 
            listView2.Location = new Point(0, 0);
            listView2.Name = "listView2";
            listView2.Size = new Size(510, 257);
            listView2.TabIndex = 0;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(12, 40);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 0;
            label1.Text = "Bàn ăn:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 0;
            label2.Text = "Trạng thái:";
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Location = new Point(102, 70);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(216, 29);
            cbTrangThai.TabIndex = 1;
            // 
            // cbSoBan
            // 
            cbSoBan.FormattingEnabled = true;
            cbSoBan.Location = new Point(102, 37);
            cbSoBan.Name = "cbSoBan";
            cbSoBan.Size = new Size(216, 29);
            cbSoBan.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(128, 64, 0);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(8, 120);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(148, 46);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "🔁 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            btnXoa.ForeColor = Color.FromArgb(128, 64, 64);
            btnXoa.Location = new Point(164, 120);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(148, 46);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(12, 182);
            label3.Name = "label3";
            label3.Size = new Size(167, 21);
            label3.TabIndex = 0;
            label3.Text = "Chọn đơn ở bảng trên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(128, 64, 64);
            label4.Location = new Point(528, 414);
            label4.Name = "label4";
            label4.Size = new Size(337, 21);
            label4.TabIndex = 0;
            label4.Text = "ở dưới sẽ hiện Tên món, SL, ghi chú, trạng thái";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(504, 230);
            dataGridView1.TabIndex = 0;
            // 
            // TheoDoiOrder_PV
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 526);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TheoDoiOrder_PV";
            Text = "TheoDoiOrder";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private ListView listView2;
        private Panel panel3;
        private Label label2;
        private Label label1;
        private ComboBox cbSoBan;
        private ComboBox cbTrangThai;
        private Button btnLamMoi;
        private Button btnXoa;
        private Label label3;
        private Label label4;
        private DataGridView dataGridView1;
    }
}
namespace CafeClient
{
    partial class Order_Ban
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            cbSoBan = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            lbTrangThaiBan = new Label();
            label5 = new Label();
            cbLoaiMonAn = new ComboBox();
            nmSoLuong = new NumericUpDown();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            label7 = new Label();
            btnXoa = new Button();
            btnThem = new Button();
            flowLayoutPanel_Table = new FlowLayoutPanel();
            label4 = new Label();
            dataGridView2 = new DataGridView();
            btnGuiOrder = new Button();
            label8 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            cbBanMuonChuyenDen = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel_Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(nmSoLuong);
            panel1.Controls.Add(cbLoaiMonAn);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(391, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(458, 247);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView2);
            panel2.Location = new Point(391, 265);
            panel2.Name = "panel2";
            panel2.Size = new Size(458, 189);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(9, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(376, 130);
            panel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 61);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lbTrangThaiBan);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(cbSoBan);
            groupBox1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox1.Location = new Point(3, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(372, 121);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin bàn ăn";
            // 
            // cbSoBan
            // 
            cbSoBan.FormattingEnabled = true;
            cbSoBan.Location = new Point(102, 33);
            cbSoBan.Name = "cbSoBan";
            cbSoBan.Size = new Size(151, 32);
            cbSoBan.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            label2.Location = new Point(6, 37);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 1;
            label2.Text = "Chọn bàn:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            label3.Location = new Point(6, 70);
            label3.Name = "label3";
            label3.Size = new Size(114, 21);
            label3.TabIndex = 2;
            label3.Text = "Trạng thái bàn:";
            // 
            // lbTrangThaiBan
            // 
            lbTrangThaiBan.AutoSize = true;
            lbTrangThaiBan.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            lbTrangThaiBan.Location = new Point(126, 76);
            lbTrangThaiBan.Name = "lbTrangThaiBan";
            lbTrangThaiBan.Size = new Size(135, 42);
            lbTrangThaiBan.TabIndex = 3;
            lbTrangThaiBan.Text = "thay đổi lb này \r\nvd: Đã đặt (4 chỗ)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(128, 64, 0);
            label5.Location = new Point(3, 3);
            label5.Name = "label5";
            label5.Size = new Size(109, 21);
            label5.TabIndex = 0;
            label5.Text = "Menu món ăn";
            // 
            // cbLoaiMonAn
            // 
            cbLoaiMonAn.FormattingEnabled = true;
            cbLoaiMonAn.Location = new Point(99, 27);
            cbLoaiMonAn.Name = "cbLoaiMonAn";
            cbLoaiMonAn.Size = new Size(151, 29);
            cbLoaiMonAn.TabIndex = 1;
            // 
            // nmSoLuong
            // 
            nmSoLuong.Location = new Point(359, 29);
            nmSoLuong.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nmSoLuong.Name = "nmSoLuong";
            nmSoLuong.Size = new Size(57, 28);
            nmSoLuong.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.FromArgb(128, 64, 0);
            label6.Location = new Point(14, 31);
            label6.Name = "label6";
            label6.Size = new Size(79, 21);
            label6.TabIndex = 3;
            label6.Text = "Loại món:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(452, 178);
            dataGridView1.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.FromArgb(128, 64, 0);
            label7.Location = new Point(274, 31);
            label7.Name = "label7";
            label7.Size = new Size(79, 21);
            label7.TabIndex = 3;
            label7.Text = "Số lượng:";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(128, 64, 0);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(548, 460);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(144, 54);
            btnXoa.TabIndex = 2;
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
            btnThem.Location = new Point(394, 460);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(144, 54);
            btnThem.TabIndex = 3;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel_Table
            // 
            flowLayoutPanel_Table.Controls.Add(label4);
            flowLayoutPanel_Table.Controls.Add(label8);
            flowLayoutPanel_Table.Location = new Point(12, 148);
            flowLayoutPanel_Table.Name = "flowLayoutPanel_Table";
            flowLayoutPanel_Table.Size = new Size(376, 306);
            flowLayoutPanel_Table.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(125, 21);
            label4.TabIndex = 1;
            label4.Text = "Xem vid Kteam?";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(452, 183);
            dataGridView2.TabIndex = 4;
            // 
            // btnGuiOrder
            // 
            btnGuiOrder.BackColor = Color.FromArgb(128, 64, 0);
            btnGuiOrder.FlatAppearance.BorderSize = 0;
            btnGuiOrder.FlatStyle = FlatStyle.Flat;
            btnGuiOrder.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnGuiOrder.ForeColor = Color.White;
            btnGuiOrder.Location = new Point(702, 460);
            btnGuiOrder.Name = "btnGuiOrder";
            btnGuiOrder.Size = new Size(144, 54);
            btnGuiOrder.TabIndex = 2;
            btnGuiOrder.Text = "Gửi Order";
            btnGuiOrder.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(134, 0);
            label8.Name = "label8";
            label8.Size = new Size(82, 21);
            label8.TabIndex = 1;
            label8.Text = "Sơ đồ bàn";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 64, 0);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(262, 33);
            button1.Name = "button1";
            button1.Size = new Size(99, 29);
            button1.TabIndex = 3;
            button1.Text = "Đặt bàn";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(128, 64, 0);
            button2.Location = new Point(262, 66);
            button2.Name = "button2";
            button2.Size = new Size(99, 29);
            button2.TabIndex = 3;
            button2.Text = "Hủy bàn";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(128, 64, 0);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(15, 459);
            button3.Name = "button3";
            button3.Size = new Size(142, 29);
            button3.TabIndex = 3;
            button3.Text = "Chuyển bàn";
            button3.UseVisualStyleBackColor = false;
            // 
            // cbBanMuonChuyenDen
            // 
            cbBanMuonChuyenDen.FormattingEnabled = true;
            cbBanMuonChuyenDen.Location = new Point(15, 492);
            cbBanMuonChuyenDen.Name = "cbBanMuonChuyenDen";
            cbBanMuonChuyenDen.Size = new Size(142, 29);
            cbBanMuonChuyenDen.TabIndex = 0;
            // 
            // Order_Ban
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 526);
            Controls.Add(flowLayoutPanel_Table);
            Controls.Add(btnGuiOrder);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(button3);
            Controls.Add(cbBanMuonChuyenDen);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Order_Ban";
            Text = "Order_Ban";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel_Table.ResumeLayout(false);
            flowLayoutPanel_Table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private GroupBox groupBox1;
        private Label lbTrangThaiBan;
        private Label label3;
        private Label label2;
        private ComboBox cbSoBan;
        private Label label6;
        private NumericUpDown nmSoLuong;
        private ComboBox cbLoaiMonAn;
        private Label label5;
        private DataGridView dataGridView1;
        private ListView listView1;
        private Label label7;
        private Button btnXoa;
        private Button btnThem;
        private FlowLayoutPanel flowLayoutPanel_Table;
        private Label label4;
        private DataGridView dataGridView2;
        private Button button1;
        private Label label8;
        private Button btnGuiOrder;
        private Button button2;
        private Button button3;
        private ComboBox cbBanMuonChuyenDen;
    }
}
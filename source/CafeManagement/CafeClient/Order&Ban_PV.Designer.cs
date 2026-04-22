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
            label7 = new Label();
            label6 = new Label();
            nmSoLuong = new NumericUpDown();
            cbLoaiMonAn = new ComboBox();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            label3 = new Label();
            lbTrangThaiBan = new Label();
            label2 = new Label();
            button2 = new Button();
            button1 = new Button();
            cbSoBan = new ComboBox();
            label1 = new Label();
            flowLayoutPanel_Table = new FlowLayoutPanel();
            label8 = new Label();
            btnXoa = new Button();
            btnThem = new Button();
            btnGuiOrder = new Button();
            button3 = new Button();
            cbBanMuonChuyenDen = new ComboBox();
            panel11 = new Panel();
            lblTitle = new Label();
            panel4 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            dataGridView2 = new DataGridView();
            label4 = new Label();
            label9 = new Label();
            label10 = new Label();
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).BeginInit();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            flowLayoutPanel_Table.SuspendLayout();
            panel11.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(nmSoLuong);
            panel1.Controls.Add(cbLoaiMonAn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(399, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(462, 71);
            panel1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.FromArgb(128, 64, 0);
            label7.Location = new Point(274, 9);
            label7.Name = "label7";
            label7.Size = new Size(79, 21);
            label7.TabIndex = 3;
            label7.Text = "Số lượng:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.FromArgb(128, 64, 0);
            label6.Location = new Point(14, 9);
            label6.Name = "label6";
            label6.Size = new Size(79, 21);
            label6.TabIndex = 3;
            label6.Text = "Loại món:";
            // 
            // nmSoLuong
            // 
            nmSoLuong.Location = new Point(359, 7);
            nmSoLuong.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nmSoLuong.Name = "nmSoLuong";
            nmSoLuong.Size = new Size(57, 28);
            nmSoLuong.TabIndex = 2;
            // 
            // cbLoaiMonAn
            // 
            cbLoaiMonAn.FormattingEnabled = true;
            cbLoaiMonAn.Location = new Point(99, 5);
            cbLoaiMonAn.Name = "cbLoaiMonAn";
            cbLoaiMonAn.Size = new Size(151, 29);
            cbLoaiMonAn.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(flowLayoutPanel_Table);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 68);
            panel3.Name = "panel3";
            panel3.Size = new Size(399, 460);
            panel3.TabIndex = 0;
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
            groupBox1.Size = new Size(393, 121);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin bàn ăn";
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
            lbTrangThaiBan.Size = new Size(118, 42);
            lbTrangThaiBan.TabIndex = 3;
            lbTrangThaiBan.Text = "thay đổi lb này \r\nvd: Đã đặt\r\n";
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
            // cbSoBan
            // 
            cbSoBan.FormattingEnabled = true;
            cbSoBan.Location = new Point(102, 33);
            cbSoBan.Name = "cbSoBan";
            cbSoBan.Size = new Size(151, 32);
            cbSoBan.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 61);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 0;
            // 
            // flowLayoutPanel_Table
            // 
            flowLayoutPanel_Table.Controls.Add(label8);
            flowLayoutPanel_Table.Location = new Point(9, 133);
            flowLayoutPanel_Table.Name = "flowLayoutPanel_Table";
            flowLayoutPanel_Table.Size = new Size(387, 327);
            flowLayoutPanel_Table.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.ForeColor = Color.FromArgb(128, 64, 0);
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(165, 21);
            label8.TabIndex = 1;
            label8.Text = "(Sơ đồ bàn trực quan)";
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnXoa.BackColor = Color.FromArgb(128, 64, 0);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(551, 10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(144, 54);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThem.BackColor = Color.FromArgb(128, 64, 0);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(397, 10);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(144, 54);
            btnThem.TabIndex = 3;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnGuiOrder
            // 
            btnGuiOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuiOrder.BackColor = Color.FromArgb(128, 64, 0);
            btnGuiOrder.FlatAppearance.BorderSize = 0;
            btnGuiOrder.FlatStyle = FlatStyle.Flat;
            btnGuiOrder.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnGuiOrder.ForeColor = Color.White;
            btnGuiOrder.Location = new Point(705, 10);
            btnGuiOrder.Name = "btnGuiOrder";
            btnGuiOrder.Size = new Size(144, 54);
            btnGuiOrder.TabIndex = 2;
            btnGuiOrder.Text = "Gửi Order";
            btnGuiOrder.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(128, 64, 0);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(9, 9);
            button3.Name = "button3";
            button3.Size = new Size(142, 29);
            button3.TabIndex = 3;
            button3.Text = "Chuyển bàn";
            button3.UseVisualStyleBackColor = false;
            // 
            // cbBanMuonChuyenDen
            // 
            cbBanMuonChuyenDen.FormattingEnabled = true;
            cbBanMuonChuyenDen.Location = new Point(9, 42);
            cbBanMuonChuyenDen.Name = "cbBanMuonChuyenDen";
            cbBanMuonChuyenDen.Size = new Size(142, 29);
            cbBanMuonChuyenDen.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Controls.Add(lblTitle);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(861, 68);
            panel11.TabIndex = 11;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(335, 49);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Đặt món và bàn ăn";
            // 
            // panel4
            // 
            panel4.Controls.Add(button3);
            panel4.Controls.Add(cbBanMuonChuyenDen);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(btnGuiOrder);
            panel4.Controls.Add(btnThem);
            panel4.Controls.Add(btnXoa);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 528);
            panel4.Name = "panel4";
            panel4.Size = new Size(861, 78);
            panel4.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(399, 139);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(462, 389);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox2.Location = new Point(3, 197);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(456, 189);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Giỏ hàng";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 28);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(450, 158);
            dataGridView2.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            label4.Location = new Point(183, 13);
            label4.Name = "label4";
            label4.Size = new Size(95, 21);
            label4.TabIndex = 1;
            label4.Text = "xanh - trống";
            label4.Click += label2_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            label9.Location = new Point(183, 36);
            label9.Name = "label9";
            label9.Size = new Size(103, 21);
            label9.TabIndex = 1;
            label9.Text = "đỏ - có khách";
            label9.Click += label2_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            label10.Location = new Point(183, 57);
            label10.Name = "label10";
            label10.Size = new Size(99, 21);
            label10.TabIndex = 1;
            label10.Text = "xám - đã đặt";
            label10.Click += label2_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(456, 188);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Menu";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(450, 157);
            dataGridView1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(128, 64, 0);
            label5.Location = new Point(14, 43);
            label5.Name = "label5";
            label5.Size = new Size(117, 21);
            label5.TabIndex = 3;
            label5.Text = "Ghi chú khách: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(131, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(325, 28);
            textBox1.TabIndex = 4;
            // 
            // Order_Ban
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel11);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Order_Ban";
            Text = "Order_Ban";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel_Table.ResumeLayout(false);
            flowLayoutPanel_Table.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
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
        private ListView listView1;
        private Label label7;
        private Button btnXoa;
        private Button btnThem;
        private FlowLayoutPanel flowLayoutPanel_Table;
        private Button button1;
        private Label label8;
        private Button btnGuiOrder;
        private Button button2;
        private Button button3;
        private ComboBox cbBanMuonChuyenDen;
        private Panel panel11;
        private Label lblTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox2;
        private DataGridView dataGridView2;
        private Label label9;
        private Label label4;
        private Label label10;
        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Label label5;
    }
}
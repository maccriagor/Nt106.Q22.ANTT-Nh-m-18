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
            panel3 = new Panel();
            btnLamMoi = new Button();
            btnXoa = new Button();
            cbSoBan = new ComboBox();
            label4 = new Label();
            cbTrangThai = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            panel9 = new Panel();
            lblTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            listView1 = new ListView();
            panel3.SuspendLayout();
            panel9.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(btnLamMoi);
            panel3.Controls.Add(btnXoa);
            panel3.Controls.Add(cbSoBan);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(cbTrangThai);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(526, 68);
            panel3.Name = "panel3";
            panel3.Size = new Size(335, 538);
            panel3.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(128, 64, 0);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Calibri", 10.2F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(11, 120);
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
            btnXoa.Location = new Point(167, 120);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(148, 46);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // cbSoBan
            // 
            cbSoBan.FormattingEnabled = true;
            cbSoBan.Location = new Point(105, 37);
            cbSoBan.Name = "cbSoBan";
            cbSoBan.Size = new Size(216, 29);
            cbSoBan.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(128, 64, 64);
            label4.Location = new Point(3, 384);
            label4.Name = "label4";
            label4.Size = new Size(337, 21);
            label4.TabIndex = 0;
            label4.Text = "ở dưới sẽ hiện Tên món, SL, ghi chú, trạng thái";
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Location = new Point(105, 70);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(216, 29);
            cbTrangThai.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(15, 73);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 0;
            label2.Text = "Trạng thái:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(15, 206);
            label3.Name = "label3";
            label3.Size = new Size(617, 42);
            label3.TabIndex = 0;
            label3.Text = "Chọn đơn hàng ở bảng trên\r\n(có Mã hóa đơn, Tên bàn, giờ gửi đơn hàng, trạng thái, số lượng món trong đơn hàng)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(15, 40);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 0;
            label1.Text = "Bàn ăn:";
            // 
            // panel9
            // 
            panel9.Controls.Add(lblTitle);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(861, 68);
            panel9.TabIndex = 8;
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
            lblTitle.Text = "Theo dõi đơn hàng";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 68);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(526, 538);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(520, 263);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đơn hàng";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listView1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.ForeColor = Color.FromArgb(128, 64, 0);
            groupBox2.Location = new Point(3, 272);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(520, 263);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết đơn hàng";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(514, 236);
            dataGridView1.TabIndex = 0;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(3, 24);
            listView1.Name = "listView1";
            listView1.Size = new Size(514, 236);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // TheoDoiOrder_PV
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel3);
            Controls.Add(panel9);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TheoDoiOrder_PV";
            Text = "TheoDoiOrder";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private Label label2;
        private Label label1;
        private ComboBox cbSoBan;
        private ComboBox cbTrangThai;
        private Button btnLamMoi;
        private Button btnXoa;
        private Label label3;
        private Label label4;
        private Panel panel9;
        private Label lblTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private ListView listView1;
    }
}
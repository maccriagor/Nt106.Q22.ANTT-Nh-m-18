namespace CafeClient
{
    partial class Menu
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            dgvFood = new DataGridView();
            colMaMon = new DataGridViewTextBoxColumn();
            colLoaiMon = new DataGridViewComboBoxColumn();
            colTenMon = new DataGridViewTextBoxColumn();
            colMoTa = new DataGridViewTextBoxColumn();
            colGia = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            menuBindingSource = new BindingSource(components);
            panel3 = new Panel();
            panel8 = new Panel();
            cbTrangThai = new ComboBox();
            label5 = new Label();
            panel7 = new Panel();
            nmGiaBan = new NumericUpDown();
            label4 = new Label();
            panel2 = new Panel();
            txtMoTa = new TextBox();
            label6 = new Label();
            panel6 = new Panel();
            tbTenMon = new TextBox();
            label3 = new Label();
            panel5 = new Panel();
            tbTenLoaiMon = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            tbMaMon = new TextBox();
            label1 = new Label();
            panel9 = new Panel();
            tbTimKiem = new TextBox();
            btnTimKiem = new Button();
            lblTitle = new Label();
            btnXem = new Button();
            textBox1 = new TextBox();
            btnSua = new Button();
            button3 = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFood).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuBindingSource).BeginInit();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmGiaBan).BeginInit();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvFood);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 151);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 455);
            panel1.TabIndex = 0;
            // 
            // dgvFood
            // 
            dgvFood.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvFood.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvFood.ColumnHeadersHeight = 35;
            dgvFood.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvFood.Columns.AddRange(new DataGridViewColumn[] { colMaMon, colLoaiMon, colTenMon, colMoTa, colGia, colTrangThai });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvFood.DefaultCellStyle = dataGridViewCellStyle2;
            dgvFood.Location = new Point(12, 6);
            dgvFood.Name = "dgvFood";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(128, 64, 0);
            dataGridViewCellStyle3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvFood.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvFood.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dgvFood.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvFood.Size = new Size(528, 437);
            dgvFood.TabIndex = 0;
            dgvFood.CellClick += dgvFood_CellClick;
            // 
            // colMaMon
            // 
            colMaMon.DataPropertyName = "MaMon";
            colMaMon.HeaderText = "Mã món";
            colMaMon.MinimumWidth = 6;
            colMaMon.Name = "colMaMon";
            // 
            // colLoaiMon
            // 
            colLoaiMon.DataPropertyName = "MaLoaiMon";
            colLoaiMon.HeaderText = "Loại món";
            colLoaiMon.MinimumWidth = 6;
            colLoaiMon.Name = "colLoaiMon";
            // 
            // colTenMon
            // 
            colTenMon.DataPropertyName = "TenMon";
            colTenMon.HeaderText = "Tên món";
            colTenMon.MinimumWidth = 6;
            colTenMon.Name = "colTenMon";
            // 
            // colMoTa
            // 
            colMoTa.DataPropertyName = "MoTa";
            colMoTa.HeaderText = "Mô tả";
            colMoTa.MinimumWidth = 6;
            colMoTa.Name = "colMoTa";
            // 
            // colGia
            // 
            colGia.DataPropertyName = "Gia";
            colGia.HeaderText = "Giá bán";
            colGia.MinimumWidth = 6;
            colGia.Name = "colGia";
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            // 
            // menuBindingSource
            // 
            menuBindingSource.DataSource = typeof(CafeCommon.Menu);
            // 
            // panel3
            // 
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(546, 151);
            panel3.Name = "panel3";
            panel3.Size = new Size(315, 455);
            panel3.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(cbTrangThai);
            panel8.Controls.Add(label5);
            panel8.Location = new Point(8, 372);
            panel8.Name = "panel8";
            panel8.Size = new Size(307, 62);
            panel8.TabIndex = 0;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Location = new Point(3, 27);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(296, 29);
            cbTrangThai.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(128, 64, 64);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(100, 24);
            label5.TabIndex = 0;
            label5.Text = "Trạng thái:";
            // 
            // panel7
            // 
            panel7.Controls.Add(nmGiaBan);
            panel7.Controls.Add(label4);
            panel7.Location = new Point(8, 304);
            panel7.Name = "panel7";
            panel7.Size = new Size(307, 62);
            panel7.TabIndex = 0;
            // 
            // nmGiaBan
            // 
            nmGiaBan.Location = new Point(3, 31);
            nmGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmGiaBan.Name = "nmGiaBan";
            nmGiaBan.Size = new Size(296, 28);
            nmGiaBan.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(128, 64, 64);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(81, 24);
            label4.TabIndex = 0;
            label4.Text = "Giá bán:";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtMoTa);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(8, 236);
            panel2.Name = "panel2";
            panel2.Size = new Size(307, 62);
            panel2.TabIndex = 0;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(0, 27);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(296, 28);
            txtMoTa.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(128, 64, 64);
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(66, 24);
            label6.TabIndex = 0;
            label6.Text = "Mô tả:";
            // 
            // panel6
            // 
            panel6.Controls.Add(tbTenMon);
            panel6.Controls.Add(label3);
            panel6.Location = new Point(8, 162);
            panel6.Name = "panel6";
            panel6.Size = new Size(328, 62);
            panel6.TabIndex = 0;
            // 
            // tbTenMon
            // 
            tbTenMon.Location = new Point(3, 27);
            tbTenMon.Name = "tbTenMon";
            tbTenMon.Size = new Size(296, 28);
            tbTenMon.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(88, 24);
            label3.TabIndex = 0;
            label3.Text = "Tên món:";
            // 
            // panel5
            // 
            panel5.Controls.Add(tbTenLoaiMon);
            panel5.Controls.Add(label2);
            panel5.Location = new Point(8, 94);
            panel5.Name = "panel5";
            panel5.Size = new Size(328, 62);
            panel5.TabIndex = 0;
            // 
            // tbTenLoaiMon
            // 
            tbTenLoaiMon.Location = new Point(3, 27);
            tbTenLoaiMon.Name = "tbTenLoaiMon";
            tbTenLoaiMon.Size = new Size(296, 28);
            tbTenLoaiMon.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(124, 24);
            label2.TabIndex = 0;
            label2.Text = "Tên loại món:";
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
            label1.Size = new Size(86, 24);
            label1.TabIndex = 0;
            label1.Text = "Mã món:";
            // 
            // panel9
            // 
            panel9.Controls.Add(tbTimKiem);
            panel9.Controls.Add(btnTimKiem);
            panel9.Controls.Add(lblTitle);
            panel9.Controls.Add(btnXem);
            panel9.Controls.Add(textBox1);
            panel9.Controls.Add(btnSua);
            panel9.Controls.Add(button3);
            panel9.Controls.Add(btnXoa);
            panel9.Controls.Add(btnThem);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(861, 151);
            panel9.TabIndex = 6;
            // 
            // tbTimKiem
            // 
            tbTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tbTimKiem.Location = new Point(550, 99);
            tbTimKiem.Name = "tbTimKiem";
            tbTimKiem.Size = new Size(201, 28);
            tbTimKiem.TabIndex = 12;
            tbTimKiem.TextChanged += tbTimKiem_TextChanged;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(128, 64, 0);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(757, 83);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(92, 57);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "🔍 Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(119, 49);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Menu";
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(128, 64, 0);
            btnXem.FlatAppearance.BorderSize = 0;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(385, 74);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(116, 74);
            btnXem.TabIndex = 1;
            btnXem.Text = "👁️ Xem";
            btnXem.UseVisualStyleBackColor = false;
            btnXem.Click += btnXem_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox1.Location = new Point(1208, 149);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 28);
            textBox1.TabIndex = 0;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(128, 64, 0);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(260, 74);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(116, 74);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(128, 64, 0);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(1417, 134);
            button3.Name = "button3";
            button3.Size = new Size(92, 57);
            button3.TabIndex = 1;
            button3.Text = "🔍 Tìm";
            button3.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(128, 64, 0);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(136, 74);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(116, 74);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(128, 64, 0);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(12, 74);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(116, 74);
            btnThem.TabIndex = 1;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel9);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(128, 64, 64);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFood).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuBindingSource).EndInit();
            panel3.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmGiaBan).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvFood;
        private Panel panel3;
        private Panel panel6;
        private TextBox tbTenMon;
        private Label label3;
        private Panel panel5;
        private Label label2;
        private Panel panel4;
        private TextBox tbMaMon;
        private Label label1;
        private Panel panel8;
        private Label label5;
        private Panel panel7;
        private Label label4;
        private NumericUpDown nmGiaBan;
        private Panel panel9;
        private Label lblTitle;
        private Button btnXem;
        private TextBox textBox1;
        private Button btnSua;
        private Button button3;
        private Button btnXoa;
        private Button btnThem;
        private TextBox tbTimKiem;
        private Button btnTimKiem;
        private Panel panel2;
        private TextBox txtMoTa;
        private Label label6;
        private ComboBox cbTrangThai;
        private BindingSource menuBindingSource;
        private TextBox tbTenLoaiMon;
        private DataGridViewTextBoxColumn colMaMon;
        private DataGridViewComboBoxColumn colLoaiMon;
        private DataGridViewTextBoxColumn colTenMon;
        private DataGridViewTextBoxColumn colMoTa;
        private DataGridViewTextBoxColumn colGia;
        private DataGridViewTextBoxColumn colTrangThai;
    }
}
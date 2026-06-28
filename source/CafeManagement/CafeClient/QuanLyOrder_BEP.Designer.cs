namespace CafeClient
{
    partial class QuanLyOrder_BEP
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            dgvOrders = new DataGridView();
            panel2 = new Panel();
            btnLamMoi = new Button();
            cboTrangThai = new ComboBox();
            cboSapXep = new ComboBox();
            cboTimBan = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel9 = new Panel();
            lblTitle = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            panel2.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvOrders);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 186);
            panel1.Name = "panel1";
            panel1.Size = new Size(861, 420);
            panel1.TabIndex = 0;
            // 
            // dgvOrders
            // 
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(11, 0);
            dgvOrders.Name = "dgvOrders";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(838, 408);
            dgvOrders.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnLamMoi);
            panel2.Controls.Add(cboTrangThai);
            panel2.Controls.Add(cboSapXep);
            panel2.Controls.Add(cboTimBan);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(861, 113);
            panel2.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(128, 64, 0);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(698, 21);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(148, 59);
            btnLamMoi.TabIndex = 8;
            btnLamMoi.Text = "🔁 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(119, 5);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(216, 29);
            cboTrangThai.TabIndex = 6;
            // 
            // cboSapXep
            // 
            cboSapXep.FormattingEnabled = true;
            cboSapXep.Items.AddRange(new object[] { "Thời gian", "Ưu tiên", "..." });
            cboSapXep.Location = new Point(119, 71);
            cboSapXep.Name = "cboSapXep";
            cboSapXep.Size = new Size(216, 29);
            cboSapXep.TabIndex = 7;
            // 
            // cboTimBan
            // 
            cboTimBan.FormattingEnabled = true;
            cboTimBan.Location = new Point(119, 38);
            cboTimBan.Name = "cboTimBan";
            cboTimBan.Size = new Size(216, 29);
            cboTimBan.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(11, 74);
            label3.Name = "label3";
            label3.Size = new Size(81, 24);
            label3.TabIndex = 4;
            label3.Text = "Sắp xếp:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(11, 41);
            label2.Name = "label2";
            label2.Size = new Size(74, 24);
            label2.TabIndex = 4;
            label2.Text = "Bàn ăn:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(11, 8);
            label1.Name = "label1";
            label1.Size = new Size(100, 24);
            label1.TabIndex = 5;
            label1.Text = "Trạng thái:";
            // 
            // panel9
            // 
            panel9.Controls.Add(lblTitle);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(861, 73);
            panel9.TabIndex = 7;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(317, 49);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Quản lý đơn hàng";
            // 
            // QuanLyOrder_BEP
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel9);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "QuanLyOrder_BEP";
            Text = "QuanLyOrder";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvOrders;
        private Button btnLamMoi;
        private ComboBox cboTrangThai;
        private ComboBox cboSapXep;
        private ComboBox cboTimBan;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel9;
        private Label lblTitle;
    }
}
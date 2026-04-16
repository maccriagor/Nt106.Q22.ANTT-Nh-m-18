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
            panel1 = new Panel();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            btnSua = new Button();
            cbTrangThai = new ComboBox();
            cbSoBan = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            cbSapXepTheo = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(12, 131);
            panel1.Name = "panel1";
            panel1.Size = new Size(837, 383);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(cbTrangThai);
            panel2.Controls.Add(cbSapXepTheo);
            panel2.Controls.Add(cbSoBan);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(837, 113);
            panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(831, 380);
            dataGridView1.TabIndex = 0;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(128, 64, 0);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(672, 21);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(148, 59);
            btnSua.TabIndex = 8;
            btnSua.Text = "🔁 Làm mới";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Location = new Point(111, 5);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(216, 29);
            cbTrangThai.TabIndex = 6;
            // 
            // cbSoBan
            // 
            cbSoBan.FormattingEnabled = true;
            cbSoBan.Location = new Point(111, 38);
            cbSoBan.Name = "cbSoBan";
            cbSoBan.Size = new Size(216, 29);
            cbSoBan.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(128, 64, 64);
            label2.Location = new Point(3, 41);
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
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(100, 24);
            label1.TabIndex = 5;
            label1.Text = "Trạng thái:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(128, 64, 64);
            label3.Location = new Point(3, 74);
            label3.Name = "label3";
            label3.Size = new Size(81, 24);
            label3.TabIndex = 4;
            label3.Text = "Sắp xếp:";
            // 
            // cbSapXepTheo
            // 
            cbSapXepTheo.FormattingEnabled = true;
            cbSapXepTheo.Items.AddRange(new object[] { "Thời gian", "Ưu tiên", "..." });
            cbSapXepTheo.Location = new Point(111, 71);
            cbSapXepTheo.Name = "cbSapXepTheo";
            cbSapXepTheo.Size = new Size(216, 29);
            cbSapXepTheo.TabIndex = 7;
            // 
            // QuanLyOrder_BEP
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 526);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "QuanLyOrder_BEP";
            Text = "QuanLyOrder";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button btnSua;
        private ComboBox cbTrangThai;
        private ComboBox cbSapXepTheo;
        private ComboBox cbSoBan;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
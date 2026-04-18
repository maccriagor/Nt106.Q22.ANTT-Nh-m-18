namespace CafeClient
{
    partial class Chat
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
            btnTimKiem = new Button();
            button1 = new Button();
            btnSua = new Button();
            label1 = new Label();
            txtTimKiem = new TextBox();
            lvNhanVIen = new ListView();
            panel2 = new Panel();
            btnSend = new Button();
            textBox1 = new TextBox();
            checkBox1 = new CheckBox();
            lbRole = new Label();
            lbUserName = new Label();
            richTextBox1 = new RichTextBox();
            lblTitle = new Label();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnTimKiem);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(lvNhanVIen);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(265, 539);
            panel1.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(128, 64, 0);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(12, 6);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(109, 28);
            btnTimKiem.TabIndex = 10;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(128, 64, 0);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(136, 461);
            button1.Name = "button1";
            button1.Size = new Size(121, 44);
            button1.TabIndex = 9;
            button1.Text = "🔔 Thông báo";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSua.BackColor = Color.FromArgb(128, 64, 0);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(8, 461);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(121, 44);
            btnSua.TabIndex = 10;
            btnSua.Text = "🔁 Làm mới";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.OldLace;
            label1.Font = new Font("Calibri", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 64, 0);
            label1.Location = new Point(11, 74);
            label1.Name = "label1";
            label1.Size = new Size(54, 18);
            label1.TabIndex = 1;
            label1.Text = "Online: ";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(11, 42);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(246, 28);
            txtTimKiem.TabIndex = 2;
            txtTimKiem.Text = "Tìm kiếm";
            // 
            // lvNhanVIen
            // 
            lvNhanVIen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvNhanVIen.Location = new Point(8, 93);
            lvNhanVIen.Name = "lvNhanVIen";
            lvNhanVIen.Size = new Size(249, 360);
            lvNhanVIen.TabIndex = 0;
            lvNhanVIen.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSend);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(checkBox1);
            panel2.Controls.Add(lbRole);
            panel2.Controls.Add(lbUserName);
            panel2.Controls.Add(richTextBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(265, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(596, 539);
            panel2.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSend.BackColor = Color.FromArgb(128, 64, 0);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(479, 461);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(109, 28);
            btnSend.TabIndex = 10;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox1.Location = new Point(4, 461);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(469, 28);
            textBox1.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.OldLace;
            checkBox1.ForeColor = Color.FromArgb(128, 64, 0);
            checkBox1.Location = new Point(4, 495);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(165, 25);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Gửi cho mọi người";
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // lbRole
            // 
            lbRole.AutoSize = true;
            lbRole.BackColor = Color.OldLace;
            lbRole.ForeColor = Color.FromArgb(128, 64, 0);
            lbRole.Location = new Point(14, 41);
            lbRole.Name = "lbRole";
            lbRole.Size = new Size(53, 21);
            lbRole.TabIndex = 1;
            lbRole.Text = "Vị trí: ";
            // 
            // lbUserName
            // 
            lbUserName.AutoSize = true;
            lbUserName.BackColor = Color.OldLace;
            lbUserName.ForeColor = Color.FromArgb(128, 64, 0);
            lbUserName.Location = new Point(14, 11);
            lbUserName.Name = "lbUserName";
            lbUserName.Size = new Size(157, 21);
            lbUserName.TabIndex = 1;
            lbUserName.Text = "TÊN người đang chat";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(2, 93);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(586, 360);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(98, 49);
            lblTitle.TabIndex = 12;
            lblTitle.Text = "Chat";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTitle);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(861, 67);
            panel3.TabIndex = 13;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 606);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Chat";
            Text = "Chat";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListView lvNhanVIen;
        private Panel panel2;
        private TextBox txtTimKiem;
        private RichTextBox richTextBox1;
        private Label lbRole;
        private Label lbUserName;
        private Label label1;
        private Label lblTitle;
        private Button button1;
        private Button btnSua;
        private Button btnSend;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private Panel panel3;
        private Button btnTimKiem;
    }
}
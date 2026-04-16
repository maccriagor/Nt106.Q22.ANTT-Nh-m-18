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
            label1 = new Label();
            txtTimKiem = new TextBox();
            lvNhanVIen = new ListView();
            panel2 = new Panel();
            lbRole = new Label();
            lbUserName = new Label();
            richTextBox1 = new RichTextBox();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            btnSend = new Button();
            btnSua = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(lvNhanVIen);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(241, 441);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.OldLace;
            label1.Font = new Font("Calibri", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 64, 0);
            label1.Location = new Point(3, 66);
            label1.Name = "label1";
            label1.Size = new Size(54, 18);
            label1.TabIndex = 1;
            label1.Text = "Online: ";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(3, 34);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(235, 28);
            txtTimKiem.TabIndex = 2;
            txtTimKiem.Text = "Tìm kiếm";
            // 
            // lvNhanVIen
            // 
            lvNhanVIen.Location = new Point(0, 85);
            lvNhanVIen.Name = "lvNhanVIen";
            lvNhanVIen.Size = new Size(241, 356);
            lvNhanVIen.TabIndex = 0;
            lvNhanVIen.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(lbRole);
            panel2.Controls.Add(lbUserName);
            panel2.Controls.Add(richTextBox1);
            panel2.Location = new Point(259, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(590, 441);
            panel2.TabIndex = 0;
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
            richTextBox1.Location = new Point(0, 85);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(590, 354);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.OldLace;
            checkBox1.ForeColor = Color.FromArgb(128, 64, 0);
            checkBox1.Location = new Point(265, 493);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(165, 25);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Gửi cho mọi người";
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(261, 459);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(473, 28);
            textBox1.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(128, 64, 0);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(740, 459);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(109, 28);
            btnSend.TabIndex = 7;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(128, 64, 0);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(10, 459);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(121, 44);
            btnSua.TabIndex = 8;
            btnSua.Text = "🔁 Làm mới";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 64, 0);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(134, 459);
            button1.Name = "button1";
            button1.Size = new Size(121, 44);
            button1.TabIndex = 8;
            button1.Text = "🔔 Thông báo";
            button1.UseVisualStyleBackColor = false;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 526);
            Controls.Add(button1);
            Controls.Add(btnSua);
            Controls.Add(btnSend);
            Controls.Add(textBox1);
            Controls.Add(panel2);
            Controls.Add(checkBox1);
            Controls.Add(panel1);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Chat";
            Text = "Chat";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ListView lvNhanVIen;
        private Panel panel2;
        private TextBox txtTimKiem;
        private CheckBox checkBox1;
        private RichTextBox richTextBox1;
        private Label lbRole;
        private Label lbUserName;
        private TextBox textBox1;
        private Button btnSend;
        private Button btnSua;
        private Label label1;
        private Button button1;
    }
}
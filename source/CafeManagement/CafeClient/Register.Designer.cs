namespace CafeClient
{
    partial class Register
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
            label6 = new Label();
            label5 = new Label();
            button1 = new Button();
            btnReg = new Button();
            checkBxShowPass = new CheckBox();
            txtconPass = new TextBox();
            txtpassword = new TextBox();
            txtusername = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtfullname = new TextBox();
            label9 = new Label();
            txtEmail = new TextBox();
            btnClose = new Button();
            label10 = new Label();
            txtSDT = new TextBox();
            cbRole = new ComboBox();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.ForeColor = Color.FromArgb(128, 64, 0);
            label6.Location = new Point(114, 654);
            label6.Name = "label6";
            label6.Size = new Size(141, 21);
            label6.TabIndex = 18;
            label6.Text = "ĐĂNG NHẬP ngay!";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(123, 633);
            label5.Name = "label5";
            label5.Size = new Size(126, 21);
            label5.TabIndex = 17;
            label5.Text = "Đã có tài khoản?";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(128, 64, 0);
            button1.Location = new Point(37, 579);
            button1.Name = "button1";
            button1.Size = new Size(289, 35);
            button1.TabIndex = 15;
            button1.Text = "Xóa";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnReg
            // 
            btnReg.BackColor = Color.FromArgb(128, 64, 0);
            btnReg.Cursor = Cursors.Hand;
            btnReg.FlatAppearance.BorderSize = 0;
            btnReg.FlatStyle = FlatStyle.Flat;
            btnReg.ForeColor = Color.White;
            btnReg.Location = new Point(37, 538);
            btnReg.Name = "btnReg";
            btnReg.Size = new Size(289, 35);
            btnReg.TabIndex = 16;
            btnReg.Text = "Đăng ký";
            btnReg.UseVisualStyleBackColor = false;
            btnReg.Click += btnReg_Click;
            // 
            // checkBxShowPass
            // 
            checkBxShowPass.AutoSize = true;
            checkBxShowPass.Cursor = Cursors.Hand;
            checkBxShowPass.FlatStyle = FlatStyle.Flat;
            checkBxShowPass.Font = new Font("Calibri", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            checkBxShowPass.Location = new Point(211, 503);
            checkBxShowPass.Name = "checkBxShowPass";
            checkBxShowPass.Size = new Size(115, 22);
            checkBxShowPass.TabIndex = 14;
            checkBxShowPass.Text = "Hiện mật khẩu";
            checkBxShowPass.UseVisualStyleBackColor = true;
            checkBxShowPass.CheckedChanged += checkBxShowPass_CheckedChanged;
            // 
            // txtconPass
            // 
            txtconPass.BackColor = Color.FromArgb(230, 231, 233);
            txtconPass.BorderStyle = BorderStyle.None;
            txtconPass.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtconPass.Location = new Point(35, 471);
            txtconPass.Multiline = true;
            txtconPass.Name = "txtconPass";
            txtconPass.PasswordChar = '*';
            txtconPass.Size = new Size(291, 26);
            txtconPass.TabIndex = 11;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.FromArgb(230, 231, 233);
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtpassword.Location = new Point(35, 404);
            txtpassword.Multiline = true;
            txtpassword.Name = "txtpassword";
            txtpassword.PasswordChar = '*';
            txtpassword.Size = new Size(291, 26);
            txtpassword.TabIndex = 12;
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.FromArgb(230, 231, 233);
            txtusername.BorderStyle = BorderStyle.None;
            txtusername.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtusername.Location = new Point(36, 171);
            txtusername.Multiline = true;
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(290, 26);
            txtusername.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(35, 442);
            label4.Name = "label4";
            label4.Size = new Size(137, 21);
            label4.TabIndex = 8;
            label4.Text = "Nhập lại mật khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(35, 375);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 9;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(36, 142);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 10;
            label2.Text = "Tên đăng nhập";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 64, 0);
            label1.Location = new Point(31, 25);
            label1.Name = "label1";
            label1.Size = new Size(131, 41);
            label1.TabIndex = 7;
            label1.Text = "Đăng ký";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(35, 343);
            label7.Name = "label7";
            label7.Size = new Size(111, 21);
            label7.TabIndex = 8;
            label7.Text = "Loại nhân viên";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(36, 82);
            label8.Name = "label8";
            label8.Size = new Size(78, 21);
            label8.TabIndex = 10;
            label8.Text = "Họ và tên";
            // 
            // txtfullname
            // 
            txtfullname.BackColor = Color.FromArgb(230, 231, 233);
            txtfullname.BorderStyle = BorderStyle.None;
            txtfullname.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtfullname.Location = new Point(36, 111);
            txtfullname.Multiline = true;
            txtfullname.Name = "txtfullname";
            txtfullname.Size = new Size(290, 26);
            txtfullname.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.Gray;
            label9.Location = new Point(35, 203);
            label9.Name = "label9";
            label9.Size = new Size(48, 21);
            label9.TabIndex = 10;
            label9.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(230, 231, 233);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(35, 232);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(291, 26);
            txtEmail.TabIndex = 13;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Cascadia Mono", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(128, 64, 0);
            btnClose.Location = new Point(326, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 34);
            btnClose.TabIndex = 50;
            btnClose.Text = "x";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(35, 267);
            label10.Name = "label10";
            label10.Size = new Size(103, 21);
            label10.TabIndex = 10;
            label10.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            txtSDT.BackColor = Color.FromArgb(230, 231, 233);
            txtSDT.BorderStyle = BorderStyle.None;
            txtSDT.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSDT.Location = new Point(35, 296);
            txtSDT.Multiline = true;
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(291, 26);
            txtSDT.TabIndex = 13;
            // 
            // cbRole
            // 
            cbRole.BackColor = Color.FromArgb(230, 231, 233);
            cbRole.FlatStyle = FlatStyle.Flat;
            cbRole.FormattingEnabled = true;
            cbRole.Items.AddRange(new object[] { "Phục vụ", "Bếp" });
            cbRole.Location = new Point(152, 340);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(174, 29);
            cbRole.TabIndex = 51;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(366, 719);
            Controls.Add(cbRole);
            Controls.Add(btnClose);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(btnReg);
            Controls.Add(checkBxShowPass);
            Controls.Add(txtconPass);
            Controls.Add(txtpassword);
            Controls.Add(txtfullname);
            Controls.Add(txtSDT);
            Controls.Add(txtEmail);
            Controls.Add(txtusername);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private Button button1;
        private Button btnReg;
        private CheckBox checkBxShowPass;
        private TextBox txtconPass;
        private TextBox txtpassword;
        private TextBox txtusername;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label8;
        private TextBox txtfullname;
        private Label label9;
        private TextBox txtEmail;
        private Button btnClose;
        private Label label10;
        private TextBox txtSDT;
        private ComboBox cbRole;
    }
}
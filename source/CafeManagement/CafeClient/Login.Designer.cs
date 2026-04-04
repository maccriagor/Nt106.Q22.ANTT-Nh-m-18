namespace CafeClient
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label6 = new Label();
            label5 = new Label();
            label1 = new Label();
            button1 = new Button();
            btnLogin = new Button();
            checkBxShowPass = new CheckBox();
            txtpassword = new TextBox();
            txtusername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            lbForgotPass = new Label();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.ForeColor = Color.FromArgb(128, 64, 0);
            label6.Location = new Point(122, 464);
            label6.Name = "label6";
            label6.Size = new Size(118, 21);
            label6.TabIndex = 34;
            label6.Text = "ĐĂNG KÝ ngay!";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(110, 441);
            label5.Name = "label5";
            label5.Size = new Size(144, 21);
            label5.TabIndex = 33;
            label5.Text = "Chưa có tài khoản?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 64, 0);
            label1.Location = new Point(39, 102);
            label1.Name = "label1";
            label1.Size = new Size(174, 41);
            label1.TabIndex = 20;
            label1.Text = "Đăng Nhập";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(128, 64, 0);
            button1.Location = new Point(39, 369);
            button1.Name = "button1";
            button1.Size = new Size(289, 35);
            button1.TabIndex = 47;
            button1.Text = "Xóa";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(128, 64, 0);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(39, 328);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(289, 35);
            btnLogin.TabIndex = 48;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // checkBxShowPass
            // 
            checkBxShowPass.AutoSize = true;
            checkBxShowPass.Cursor = Cursors.Hand;
            checkBxShowPass.FlatStyle = FlatStyle.Flat;
            checkBxShowPass.Font = new Font("Calibri", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            checkBxShowPass.Location = new Point(213, 296);
            checkBxShowPass.Name = "checkBxShowPass";
            checkBxShowPass.Size = new Size(115, 22);
            checkBxShowPass.TabIndex = 46;
            checkBxShowPass.Text = "Hiện mật khẩu";
            checkBxShowPass.UseVisualStyleBackColor = true;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.FromArgb(230, 231, 233);
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtpassword.Location = new Point(39, 261);
            txtpassword.Multiline = true;
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(291, 26);
            txtpassword.TabIndex = 42;
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.FromArgb(230, 231, 233);
            txtusername.BorderStyle = BorderStyle.None;
            txtusername.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtusername.Location = new Point(39, 199);
            txtusername.Multiline = true;
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(290, 26);
            txtusername.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(39, 233);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 37;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(39, 170);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 40;
            label2.Text = "Tên đăng nhập";
            // 
            // lbForgotPass
            // 
            lbForgotPass.AutoSize = true;
            lbForgotPass.Location = new Point(115, 487);
            lbForgotPass.Name = "lbForgotPass";
            lbForgotPass.Size = new Size(127, 21);
            lbForgotPass.TabIndex = 33;
            lbForgotPass.Text = "Quên mật khẩu?";
            lbForgotPass.Click += lbForgotPass_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(366, 639);
            Controls.Add(button1);
            Controls.Add(btnLogin);
            Controls.Add(checkBxShowPass);
            Controls.Add(txtpassword);
            Controls.Add(txtusername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(lbForgotPass);
            Controls.Add(label5);
            Controls.Add(label1);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private Label label1;
        private Button button1;
        private Button btnLogin;
        private CheckBox checkBxShowPass;
        private TextBox txtpassword;
        private TextBox txtusername;
        private Label label3;
        private Label label2;
        private Label lbForgotPass;
    }
}

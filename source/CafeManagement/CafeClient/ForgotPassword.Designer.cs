namespace CafeClient
{
    partial class ForgotPassword
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
            btnReg = new Button();
            txtpassword = new TextBox();
            txtusername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            checkBxShowPass = new CheckBox();
            txtConfirmPass = new TextBox();
            txtNewPass = new TextBox();
            label5 = new Label();
            label6 = new Label();
            btnUpdate = new Button();
            label7 = new Label();
            btnVerify = new Button();
            SuspendLayout();
            // 
            // btnReg
            // 
            btnReg.BackColor = Color.FromArgb(128, 64, 0);
            btnReg.Cursor = Cursors.Hand;
            btnReg.FlatAppearance.BorderSize = 0;
            btnReg.FlatStyle = FlatStyle.Flat;
            btnReg.ForeColor = Color.White;
            btnReg.Location = new Point(50, 265);
            btnReg.Name = "btnReg";
            btnReg.Size = new Size(289, 35);
            btnReg.TabIndex = 58;
            btnReg.Text = "Gửi mã OTP";
            btnReg.UseVisualStyleBackColor = false;
            btnReg.Click += btnReg_Click;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.FromArgb(230, 231, 233);
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtpassword.Location = new Point(52, 219);
            txtpassword.Multiline = true;
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(291, 26);
            txtpassword.TabIndex = 54;
            txtpassword.TextChanged += txtpassword_TextChanged;
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.FromArgb(230, 231, 233);
            txtusername.BorderStyle = BorderStyle.None;
            txtusername.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtusername.Location = new Point(52, 150);
            txtusername.Multiline = true;
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(290, 26);
            txtusername.TabIndex = 55;
            txtusername.TextChanged += txtusername_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(51, 195);
            label3.Name = "label3";
            label3.Size = new Size(216, 21);
            label3.TabIndex = 52;
            label3.Text = "Nhập mã gửi qua email (6 số)";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(51, 126);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 53;
            label2.Text = "Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 64, 0);
            label1.Location = new Point(50, 72);
            label1.Name = "label1";
            label1.Size = new Size(236, 41);
            label1.TabIndex = 49;
            label1.Text = "Quên mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(128, 64, 0);
            label4.Location = new Point(50, 31);
            label4.Name = "label4";
            label4.Size = new Size(217, 41);
            label4.TabIndex = 49;
            label4.Text = "Đổi mật khẩu,";
            label4.Click += label4_Click;
            // 
            // checkBxShowPass
            // 
            checkBxShowPass.AutoSize = true;
            checkBxShowPass.Cursor = Cursors.Hand;
            checkBxShowPass.FlatStyle = FlatStyle.Flat;
            checkBxShowPass.Font = new Font("Calibri", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            checkBxShowPass.Location = new Point(227, 467);
            checkBxShowPass.Name = "checkBxShowPass";
            checkBxShowPass.Size = new Size(115, 22);
            checkBxShowPass.TabIndex = 63;
            checkBxShowPass.Text = "Hiện mật khẩu";
            checkBxShowPass.UseVisualStyleBackColor = true;
            checkBxShowPass.Visible = false;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BackColor = Color.FromArgb(230, 231, 233);
            txtConfirmPass.BorderStyle = BorderStyle.None;
            txtConfirmPass.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtConfirmPass.Location = new Point(51, 435);
            txtConfirmPass.Multiline = true;
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(291, 26);
            txtConfirmPass.TabIndex = 61;
            txtConfirmPass.Visible = false;
            // 
            // txtNewPass
            // 
            txtNewPass.BackColor = Color.FromArgb(230, 231, 233);
            txtNewPass.BorderStyle = BorderStyle.None;
            txtNewPass.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNewPass.Location = new Point(51, 368);
            txtNewPass.Multiline = true;
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(291, 26);
            txtNewPass.TabIndex = 62;
            txtNewPass.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(51, 406);
            label5.Name = "label5";
            label5.Size = new Size(137, 21);
            label5.TabIndex = 59;
            label5.Text = "Nhập lại mật khẩu";
            label5.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(51, 339);
            label6.Name = "label6";
            label6.Size = new Size(77, 21);
            label6.TabIndex = 60;
            label6.Text = "Mật khẩu";
            label6.Visible = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(128, 64, 0);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(51, 495);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(289, 35);
            btnUpdate.TabIndex = 58;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Cursor = Cursors.Hand;
            label7.ForeColor = Color.FromArgb(128, 64, 0);
            label7.Location = new Point(127, 545);
            label7.Name = "label7";
            label7.Size = new Size(141, 21);
            label7.TabIndex = 64;
            label7.Text = "ĐĂNG NHẬP ngay!";
            label7.Click += label7_Click;
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.FromArgb(128, 64, 0);
            btnVerify.ForeColor = SystemColors.ControlLightLight;
            btnVerify.Location = new Point(50, 307);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(289, 29);
            btnVerify.TabIndex = 65;
            btnVerify.Text = "Xác nhận";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(392, 622);
            Controls.Add(btnVerify);
            Controls.Add(label7);
            Controls.Add(checkBxShowPass);
            Controls.Add(txtConfirmPass);
            Controls.Add(txtNewPass);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(btnUpdate);
            Controls.Add(btnReg);
            Controls.Add(txtpassword);
            Controls.Add(txtusername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgotPassword";
            Text = "ForgotPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnReg;
        private TextBox txtpassword;
        private TextBox txtusername;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private CheckBox checkBxShowPass;
        private TextBox txtConfirmPass;
        private TextBox txtNewPass;
        private Label label5;
        private Label label6;
        private Button btnUpdate;
        private Label label7;
        private Button btnVerify;
    }
}
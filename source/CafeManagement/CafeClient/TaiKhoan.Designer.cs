namespace CafeClient
{
    partial class TaiKhoan
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnUpdateProf = new Button();
            txtfullname = new TextBox();
            txtusername = new TextBox();
            txtEmail = new TextBox();
            txtRole = new TextBox();
            btnDoiMK = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 64, 64);
            label1.Location = new Point(252, 72);
            label1.Name = "label1";
            label1.Size = new Size(343, 49);
            label1.TabIndex = 0;
            label1.Text = "Thông tin tài khoản";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 0, 0);
            label2.Location = new Point(161, 236);
            label2.Name = "label2";
            label2.Size = new Size(133, 24);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 0, 0);
            label3.Location = new Point(161, 192);
            label3.Name = "label3";
            label3.Size = new Size(91, 24);
            label3.TabIndex = 2;
            label3.Text = "Họ và tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(64, 0, 0);
            label4.Location = new Point(159, 281);
            label4.Name = "label4";
            label4.Size = new Size(56, 24);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(64, 0, 0);
            label5.Location = new Point(161, 326);
            label5.Name = "label5";
            label5.Size = new Size(78, 24);
            label5.TabIndex = 4;
            label5.Text = "Chức vụ";
            // 
            // btnUpdateProf
            // 
            btnUpdateProf.BackColor = Color.FromArgb(128, 64, 0);
            btnUpdateProf.Cursor = Cursors.Hand;
            btnUpdateProf.FlatAppearance.BorderSize = 0;
            btnUpdateProf.FlatStyle = FlatStyle.Flat;
            btnUpdateProf.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnUpdateProf.ForeColor = Color.White;
            btnUpdateProf.Location = new Point(323, 370);
            btnUpdateProf.Name = "btnUpdateProf";
            btnUpdateProf.Size = new Size(167, 56);
            btnUpdateProf.TabIndex = 6;
            btnUpdateProf.Text = "Cập nhật";
            btnUpdateProf.UseVisualStyleBackColor = false;
            btnUpdateProf.Click += btnUpdateProf_Click;
            // 
            // txtfullname
            // 
            txtfullname.BackColor = Color.White;
            txtfullname.BorderStyle = BorderStyle.None;
            txtfullname.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtfullname.Location = new Point(323, 188);
            txtfullname.Multiline = true;
            txtfullname.Name = "txtfullname";
            txtfullname.Size = new Size(356, 32);
            txtfullname.TabIndex = 7;
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.White;
            txtusername.BorderStyle = BorderStyle.None;
            txtusername.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtusername.Location = new Point(323, 233);
            txtusername.Multiline = true;
            txtusername.Name = "txtusername";
            txtusername.ReadOnly = true;
            txtusername.Size = new Size(356, 32);
            txtusername.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(323, 278);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(356, 32);
            txtEmail.TabIndex = 7;
            // 
            // txtRole
            // 
            txtRole.BackColor = Color.White;
            txtRole.BorderStyle = BorderStyle.None;
            txtRole.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtRole.Location = new Point(323, 322);
            txtRole.Multiline = true;
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(356, 32);
            txtRole.TabIndex = 7;
            // 
            // btnDoiMK
            // 
            btnDoiMK.BackColor = Color.White;
            btnDoiMK.Cursor = Cursors.Hand;
            btnDoiMK.FlatStyle = FlatStyle.Flat;
            btnDoiMK.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnDoiMK.ForeColor = Color.FromArgb(128, 64, 0);
            btnDoiMK.Location = new Point(512, 370);
            btnDoiMK.Name = "btnDoiMK";
            btnDoiMK.Size = new Size(167, 56);
            btnDoiMK.TabIndex = 6;
            btnDoiMK.Text = "Đổi mật khẩu";
            btnDoiMK.UseVisualStyleBackColor = false;
            btnDoiMK.Click += button1_Click;
            // 
            // TaiKhoan
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(861, 526);
            Controls.Add(txtRole);
            Controls.Add(txtEmail);
            Controls.Add(txtusername);
            Controls.Add(txtfullname);
            Controls.Add(btnDoiMK);
            Controls.Add(btnUpdateProf);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Calibri", 12F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TaiKhoan";
            Text = "TaiKhoan";
            Load += TaiKhoan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnUpdateProf;
        private TextBox txtfullname;
        private TextBox txtusername;
        private TextBox txtEmail;
        private TextBox txtRole;
        private Button btnDoiMK;
    }
}
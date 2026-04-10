namespace CafeClient
{
    partial class AdminMain
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
            pnlNav = new Panel();
            btnLogout = new Button();
            btnTaiKhoan = new Button();
            btnChat = new Button();
            btnNhanVien = new Button();
            btnHoaDon = new Button();
            btnBanAn = new Button();
            btnMenu = new Button();
            btnDoanhThu = new Button();
            panel2 = new Panel();
            AdminName = new Label();
            pictureBox2 = new PictureBox();
            PnlFormLoader = new Panel();
            lblTitle = new Label();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 64, 0);
            panel1.Controls.Add(pnlNav);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnTaiKhoan);
            panel1.Controls.Add(btnChat);
            panel1.Controls.Add(btnNhanVien);
            panel1.Controls.Add(btnHoaDon);
            panel1.Controls.Add(btnBanAn);
            panel1.Controls.Add(btnMenu);
            panel1.Controls.Add(btnDoanhThu);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(209, 606);
            panel1.TabIndex = 0;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.YellowGreen;
            pnlNav.ForeColor = Color.MistyRose;
            pnlNav.Location = new Point(0, 196);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(4, 200);
            pnlNav.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(0, 564);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(209, 42);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            btnLogout.Leave += btnLogout_Leave;
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.Dock = DockStyle.Top;
            btnTaiKhoan.FlatAppearance.BorderSize = 0;
            btnTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnTaiKhoan.Location = new Point(0, 403);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Size = new Size(209, 42);
            btnTaiKhoan.TabIndex = 3;
            btnTaiKhoan.Text = "Tài khoản      ⚙️";
            btnTaiKhoan.UseVisualStyleBackColor = true;
            btnTaiKhoan.Click += btnTaiKhoan_Click;
            btnTaiKhoan.Leave += btnTaiKhoan_Leave;
            // 
            // btnChat
            // 
            btnChat.Dock = DockStyle.Top;
            btnChat.FlatAppearance.BorderSize = 0;
            btnChat.FlatStyle = FlatStyle.Flat;
            btnChat.Location = new Point(0, 361);
            btnChat.Name = "btnChat";
            btnChat.Size = new Size(209, 42);
            btnChat.TabIndex = 3;
            btnChat.Text = "Chat              💭";
            btnChat.UseVisualStyleBackColor = true;
            btnChat.Click += btnChat_Click;
            btnChat.Leave += btnChat_Leave;
            // 
            // btnNhanVien
            // 
            btnNhanVien.Dock = DockStyle.Top;
            btnNhanVien.FlatAppearance.BorderSize = 0;
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.Location = new Point(0, 319);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(209, 42);
            btnNhanVien.TabIndex = 3;
            btnNhanVien.Text = "Nhân viên    👨‍🍳";
            btnNhanVien.UseVisualStyleBackColor = true;
            btnNhanVien.Click += btnNhanVien_Click;
            btnNhanVien.Leave += btnNhanVien_Leave;
            // 
            // btnHoaDon
            // 
            btnHoaDon.Dock = DockStyle.Top;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatStyle = FlatStyle.Flat;
            btnHoaDon.Location = new Point(0, 277);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(209, 42);
            btnHoaDon.TabIndex = 3;
            btnHoaDon.Text = "Hóa đơn      \U0001f9fe";
            btnHoaDon.UseVisualStyleBackColor = true;
            btnHoaDon.Click += btnHoaDon_Click;
            btnHoaDon.Leave += btnHoaDon_Leave;
            // 
            // btnBanAn
            // 
            btnBanAn.Dock = DockStyle.Top;
            btnBanAn.FlatAppearance.BorderSize = 0;
            btnBanAn.FlatStyle = FlatStyle.Flat;
            btnBanAn.Location = new Point(0, 235);
            btnBanAn.Name = "btnBanAn";
            btnBanAn.Size = new Size(209, 42);
            btnBanAn.TabIndex = 3;
            btnBanAn.Text = "Bàn ăn         ┬─┬";
            btnBanAn.UseVisualStyleBackColor = true;
            btnBanAn.Click += btnBanAn_Click;
            btnBanAn.Leave += btnBanAn_Leave;
            // 
            // btnMenu
            // 
            btnMenu.Dock = DockStyle.Top;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Location = new Point(0, 193);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(209, 42);
            btnMenu.TabIndex = 3;
            btnMenu.Text = "Menu           \U0001f950";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            btnMenu.Leave += btnMenu_Leave;
            // 
            // btnDoanhThu
            // 
            btnDoanhThu.Dock = DockStyle.Top;
            btnDoanhThu.FlatAppearance.BorderSize = 0;
            btnDoanhThu.FlatStyle = FlatStyle.Flat;
            btnDoanhThu.Location = new Point(0, 151);
            btnDoanhThu.Name = "btnDoanhThu";
            btnDoanhThu.Size = new Size(209, 42);
            btnDoanhThu.TabIndex = 3;
            btnDoanhThu.Text = "Doanh thu   📊";
            btnDoanhThu.UseVisualStyleBackColor = true;
            btnDoanhThu.Click += btnDoanhThu_Click;
            btnDoanhThu.Leave += btnDoanhThu_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(AdminName);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(209, 151);
            panel2.TabIndex = 2;
            // 
            // AdminName
            // 
            AdminName.AutoSize = true;
            AdminName.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AdminName.ForeColor = Color.PeachPuff;
            AdminName.Location = new Point(12, 90);
            AdminName.Name = "AdminName";
            AdminName.Size = new Size(95, 24);
            AdminName.TabIndex = 2;
            AdminName.Text = "hiện tên...";
            AdminName.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = Properties.Resources.profile;
            pictureBox2.Location = new Point(64, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(78, 71);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // PnlFormLoader
            // 
            PnlFormLoader.BackColor = Color.White;
            PnlFormLoader.Location = new Point(209, 80);
            PnlFormLoader.Name = "PnlFormLoader";
            PnlFormLoader.Size = new Size(861, 526);
            PnlFormLoader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(228, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(196, 49);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Doanh thu";
            // 
            // panel3
            // 
            panel3.Location = new Point(808, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 53);
            panel3.TabIndex = 8;
            panel3.Paint += panel3_Paint;
            // 
            // AdminMain
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(1070, 606);
            Controls.Add(panel3);
            Controls.Add(PnlFormLoader);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AdminMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminMain";
            Load += AdminMain_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox2;
        private Panel panel2;
        private Label AdminName;
        private Button btnDoanhThu;
        private Button btnTaiKhoan;
        private Button btnChat;
        private Button btnNhanVien;
        private Button btnHoaDon;
        private Button btnBanAn;
        private Button btnMenu;
        private Button btnLogout;
        private Panel pnlNav;
        private Panel PnlFormLoader;
        private Label lblTitle;
        private Panel panel3;
    }
}
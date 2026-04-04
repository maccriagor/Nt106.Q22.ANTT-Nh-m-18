namespace CafeClient
{
    partial class WaiterMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaiterMain));
            panel1 = new Panel();
            pnlNav = new Panel();
            btnLogout = new Button();
            btnTaiKhoan = new Button();
            btnChat = new Button();
            btnTheoDoiDH = new Button();
            btnThanhToan = new Button();
            btnOrderVaBan = new Button();
            panel2 = new Panel();
            AdminName = new Label();
            pictureBox2 = new PictureBox();
            PnlFormLoader = new Panel();
            lblTitle = new Label();
            btnClose = new Button();
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
            panel1.Controls.Add(btnTheoDoiDH);
            panel1.Controls.Add(btnThanhToan);
            panel1.Controls.Add(btnOrderVaBan);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(209, 606);
            panel1.TabIndex = 3;
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
            btnTaiKhoan.Location = new Point(0, 319);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Size = new Size(209, 42);
            btnTaiKhoan.TabIndex = 3;
            btnTaiKhoan.Text = "Tài khoản          ⚙️";
            btnTaiKhoan.UseVisualStyleBackColor = true;
            btnTaiKhoan.Click += btnTaiKhoan_Click;
            btnTaiKhoan.Leave += btnTaiKhoan_Leave;
            // 
            // btnChat
            // 
            btnChat.Dock = DockStyle.Top;
            btnChat.FlatAppearance.BorderSize = 0;
            btnChat.FlatStyle = FlatStyle.Flat;
            btnChat.Location = new Point(0, 277);
            btnChat.Name = "btnChat";
            btnChat.Size = new Size(209, 42);
            btnChat.TabIndex = 3;
            btnChat.Text = "Chat                   💭";
            btnChat.UseVisualStyleBackColor = true;
            btnChat.Click += btnChat_Click;
            btnChat.Leave += btnChat_Leave;
            // 
            // btnTheoDoiDH
            // 
            btnTheoDoiDH.Dock = DockStyle.Top;
            btnTheoDoiDH.FlatAppearance.BorderSize = 0;
            btnTheoDoiDH.FlatStyle = FlatStyle.Flat;
            btnTheoDoiDH.Location = new Point(0, 235);
            btnTheoDoiDH.Name = "btnTheoDoiDH";
            btnTheoDoiDH.Size = new Size(209, 42);
            btnTheoDoiDH.TabIndex = 3;
            btnTheoDoiDH.Text = "Theo dõi đơn   🍶";
            btnTheoDoiDH.UseVisualStyleBackColor = true;
            btnTheoDoiDH.Click += btnTheoDoiDH_Click;
            btnTheoDoiDH.Leave += btnTheoDoiDH_Leave;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Dock = DockStyle.Top;
            btnThanhToan.FlatAppearance.BorderSize = 0;
            btnThanhToan.FlatStyle = FlatStyle.Flat;
            btnThanhToan.Location = new Point(0, 193);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(209, 42);
            btnThanhToan.TabIndex = 3;
            btnThanhToan.Text = "Thanh toán       💸";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            btnThanhToan.Leave += btnThanhToan_Leave;
            // 
            // btnOrderVaBan
            // 
            btnOrderVaBan.Dock = DockStyle.Top;
            btnOrderVaBan.FlatAppearance.BorderSize = 0;
            btnOrderVaBan.FlatStyle = FlatStyle.Flat;
            btnOrderVaBan.Location = new Point(0, 151);
            btnOrderVaBan.Name = "btnOrderVaBan";
            btnOrderVaBan.Size = new Size(209, 42);
            btnOrderVaBan.TabIndex = 3;
            btnOrderVaBan.Text = "Order và bàn    🍗";
            btnOrderVaBan.UseVisualStyleBackColor = true;
            btnOrderVaBan.Click += btnOrderVaBan_Click;
            btnOrderVaBan.Leave += btnOrderVaBan_Leave;
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
            AdminName.Location = new Point(54, 94);
            AdminName.Name = "AdminName";
            AdminName.Size = new Size(95, 24);
            AdminName.TabIndex = 2;
            AdminName.Text = "hiện tên...";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(65, 20);
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
            PnlFormLoader.TabIndex = 4;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Brown;
            lblTitle.Location = new Point(228, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(287, 49);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Order và Bàn ăn";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Cascadia Mono", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(128, 64, 0);
            btnClose.Location = new Point(1025, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 34);
            btnClose.TabIndex = 6;
            btnClose.Text = "x";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panel3
            // 
            panel3.Location = new Point(760, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 53);
            panel3.TabIndex = 10;
            // 
            // WaiterMain
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(1070, 606);
            Controls.Add(panel3);
            Controls.Add(btnClose);
            Controls.Add(panel1);
            Controls.Add(PnlFormLoader);
            Controls.Add(lblTitle);
            Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "WaiterMain";
            Text = "WaiterMain";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel pnlNav;
        private Button btnLogout;
        private Button btnTaiKhoan;
        private Button btnChat;
        private Button btnTheoDoiDH;
        private Button btnThanhToan;
        private Button btnOrderVaBan;
        private Panel panel2;
        private Label AdminName;
        private PictureBox pictureBox2;
        private Panel PnlFormLoader;
        private Label lblTitle;
        private Button btnClose;
        private Panel panel3;
    }
}
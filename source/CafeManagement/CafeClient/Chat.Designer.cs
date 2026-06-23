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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            panel1 = new Panel();
            btnTimKiem = new Button();
            btnThongBao = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            lvNhanVien = new ListView();
            NhanVien = new ColumnHeader();
            VaiTro = new ColumnHeader();
            imgListStatus = new ImageList(components);
            panel2 = new Panel();
            btnSend = new Button();
            txtMessage = new TextBox();
            cbEveryone = new CheckBox();
            lbRole = new Label();
            lbUserName = new Label();
            rtbChat = new RichTextBox();
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
            panel1.Controls.Add(btnThongBao);
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(lvNhanVien);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(265, 539);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
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
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnThongBao
            // 
            btnThongBao.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThongBao.BackColor = Color.FromArgb(128, 64, 0);
            btnThongBao.FlatAppearance.BorderSize = 0;
            btnThongBao.FlatStyle = FlatStyle.Flat;
            btnThongBao.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThongBao.ForeColor = Color.White;
            btnThongBao.Location = new Point(136, 461);
            btnThongBao.Name = "btnThongBao";
            btnThongBao.Size = new Size(121, 44);
            btnThongBao.TabIndex = 9;
            btnThongBao.Text = "🔔 Thông báo";
            btnThongBao.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(128, 64, 0);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Calibri", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(8, 461);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(121, 44);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "🔁 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(11, 42);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(246, 28);
            txtTimKiem.TabIndex = 2;
            txtTimKiem.Text = "Tìm kiếm";
            txtTimKiem.Enter += txtTimKiem_Enter;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            // 
            // lvNhanVien
            // 
            lvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvNhanVien.Columns.AddRange(new ColumnHeader[] { NhanVien, VaiTro });
            lvNhanVien.Location = new Point(8, 93);
            lvNhanVien.Name = "lvNhanVien";
            lvNhanVien.Size = new Size(249, 360);
            lvNhanVien.SmallImageList = imgListStatus;
            lvNhanVien.TabIndex = 0;
            lvNhanVien.UseCompatibleStateImageBehavior = false;
            lvNhanVien.View = View.Details;
            lvNhanVien.Click += lvNhanVien_Click;
            // 
            // NhanVien
            // 
            NhanVien.Text = "Nhân Viên";
            NhanVien.Width = 180;
            // 
            // VaiTro
            // 
            VaiTro.Text = "Vai trò";
            VaiTro.Width = 100;
            // 
            // imgListStatus
            // 
            imgListStatus.ColorDepth = ColorDepth.Depth32Bit;
            imgListStatus.ImageStream = (ImageListStreamer)resources.GetObject("imgListStatus.ImageStream");
            imgListStatus.TransparentColor = Color.Transparent;
            imgListStatus.Images.SetKeyName(0, "Online");
            imgListStatus.Images.SetKeyName(1, "Offline");
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSend);
            panel2.Controls.Add(txtMessage);
            panel2.Controls.Add(cbEveryone);
            panel2.Controls.Add(lbRole);
            panel2.Controls.Add(lbUserName);
            panel2.Controls.Add(rtbChat);
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
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtMessage.Location = new Point(4, 461);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(469, 28);
            txtMessage.TabIndex = 9;
            // 
            // cbEveryone
            // 
            cbEveryone.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cbEveryone.AutoSize = true;
            cbEveryone.BackColor = Color.OldLace;
            cbEveryone.ForeColor = Color.FromArgb(128, 64, 0);
            cbEveryone.Location = new Point(4, 495);
            cbEveryone.Name = "cbEveryone";
            cbEveryone.Size = new Size(165, 25);
            cbEveryone.TabIndex = 8;
            cbEveryone.Text = "Gửi cho mọi người";
            cbEveryone.UseVisualStyleBackColor = false;
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
            lbUserName.Size = new Size(166, 21);
            lbUserName.TabIndex = 1;
            lbUserName.Text = "TÊN người đang chat :";
            // 
            // rtbChat
            // 
            rtbChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbChat.Location = new Point(2, 93);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.Size = new Size(586, 360);
            rtbChat.TabIndex = 0;
            rtbChat.Text = "";
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
        private ListView lvNhanVien;
        private Panel panel2;
        private TextBox txtTimKiem;
        private RichTextBox rtbChat;
        private Label lbRole;
        private Label lbUserName;
        private Label lblTitle;
        private Button btnThongBao;
        private Button btnLamMoi;
        private Button btnSend;
        private TextBox txtMessage;
        private CheckBox cbEveryone;
        private Panel panel3;
        private Button btnTimKiem;
        private ColumnHeader NhanVien;
        private ImageList imgListStatus;
        private ColumnHeader VaiTro;
    }
}
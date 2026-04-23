namespace CafeClient
{
    partial class ThongTinHoaDon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStatus = new Label();
            lblID = new Label();
            lblDate = new Label();
            lblPrice = new Label();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(145, 53);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(175, 27);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "trang thai";
            lblStatus.Click += lblStatus_Click;
            // 
            // lblID
            // 
            lblID.Location = new Point(14, 13);
            lblID.Name = "lblID";
            lblID.Size = new Size(125, 25);
            lblID.TabIndex = 5;
            lblID.Text = "MaHD";
            lblID.Click += label1_Click;
            // 
            // lblDate
            // 
            lblDate.Location = new Point(14, 55);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(125, 25);
            lblDate.TabIndex = 6;
            lblDate.Text = "NgayTao";
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(316, 16);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(130, 25);
            lblPrice.TabIndex = 7;
            lblPrice.Text = "GiaTien";
            // 
            // ThongTinHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(lblPrice);
            Controls.Add(lblDate);
            Controls.Add(lblID);
            Controls.Add(lblStatus);
            ForeColor = SystemColors.ControlText;
            Name = "ThongTinHoaDon";
            Size = new Size(465, 90);
            DoubleClick += ThongTinHoaDon_DoubleClick;
            ResumeLayout(false);
        }

        #endregion
        private Label lblStatus;
        private Label lblID;
        private Label lblDate;
        private Label lblPrice;
    }
}

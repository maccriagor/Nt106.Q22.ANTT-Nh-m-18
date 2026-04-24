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
            txtMaHD = new TextBox();
            txtMaBanAn = new TextBox();
            txtMaNV = new TextBox();
            txtNgayXuat = new TextBox();
            SuspendLayout();
            // 
            // txtMaHD
            // 
            txtMaHD.Location = new Point(8, 16);
            txtMaHD.Name = "txtMaHD";
            txtMaHD.Size = new Size(125, 27);
            txtMaHD.TabIndex = 0;
            // 
            // txtMaBanAn
            // 
            txtMaBanAn.Location = new Point(154, 62);
            txtMaBanAn.Name = "txtMaBanAn";
            txtMaBanAn.Size = new Size(125, 27);
            txtMaBanAn.TabIndex = 1;
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(8, 62);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(125, 27);
            txtMaNV.TabIndex = 2;
            // 
            // txtNgayXuat
            // 
            txtNgayXuat.Location = new Point(282, 16);
            txtNgayXuat.Name = "txtNgayXuat";
            txtNgayXuat.Size = new Size(200, 27);
            txtNgayXuat.TabIndex = 3;
            // 
            // ThongTinHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtNgayXuat);
            Controls.Add(txtMaNV);
            Controls.Add(txtMaBanAn);
            Controls.Add(txtMaHD);
            Name = "ThongTinHoaDon";
            Size = new Size(485, 105);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaHD;
        private TextBox txtMaBanAn;
        private TextBox txtMaNV;
        private TextBox txtNgayXuat;
    }
}

namespace CafeClient
{
    partial class ThoiGian
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
            Time = new Label();
            Date = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // Time
            // 
            Time.AutoSize = true;
            Time.Location = new Point(100, 5);
            Time.Name = "Time";
            Time.Size = new Size(44, 21);
            Time.TabIndex = 0;
            Time.Text = "Time";
            // 
            // Date
            // 
            Date.AutoSize = true;
            Date.Location = new Point(102, 26);
            Date.Name = "Date";
            Date.Size = new Size(42, 21);
            Date.TabIndex = 0;
            Date.Text = "Date";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // ThoiGian
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(250, 53);
            Controls.Add(Date);
            Controls.Add(Time);
            Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(128, 64, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ThoiGian";
            Text = "ThoiGian";
            Load += ThoiGian_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Time;
        private Label Date;
        private System.Windows.Forms.Timer timer1;
    }
}
namespace WiFiTrayPlus2
{
    partial class WifiInfoForm
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
            lblWifiName = new Label();
            lblSignal = new Label();
            lblDownload = new Label();
            lblUpload = new Label();
            picWifi = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picWifi).BeginInit();
            SuspendLayout();
            // 
            // lblWifiName
            // 
            lblWifiName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblWifiName.Location = new Point(41, 9);
            lblWifiName.Name = "lblWifiName";
            lblWifiName.Size = new Size(166, 30);
            lblWifiName.TabIndex = 0;
            lblWifiName.Text = "Nazwa sieci WiFi";
            lblWifiName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSignal
            // 
            lblSignal.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSignal.Location = new Point(15, 50);
            lblSignal.Name = "lblSignal";
            lblSignal.Size = new Size(166, 25);
            lblSignal.TabIndex = 1;
            lblSignal.Text = "Sygnał: 0%";
            // 
            // lblDownload
            // 
            lblDownload.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblDownload.Location = new Point(15, 80);
            lblDownload.Name = "lblDownload";
            lblDownload.Size = new Size(166, 25);
            lblDownload.TabIndex = 2;
            lblDownload.Text = "↓ Pobieranie: 0 Mb/s";
            lblDownload.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUpload
            // 
            lblUpload.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblUpload.Location = new Point(15, 105);
            lblUpload.Name = "lblUpload";
            lblUpload.Size = new Size(166, 25);
            lblUpload.TabIndex = 3;
            lblUpload.Text = "↑ Wysyłanie: 0 Mb/s";
            lblUpload.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // picWifi
            // 
            picWifi.Location = new Point(-3, 9);
            picWifi.Name = "picWifi";
            picWifi.Size = new Size(38, 29);
            picWifi.TabIndex = 4;
            picWifi.TabStop = false;
            // 
            // WifiInfoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(183, 150);
            Controls.Add(picWifi);
            Controls.Add(lblUpload);
            Controls.Add(lblDownload);
            Controls.Add(lblSignal);
            Controls.Add(lblWifiName);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WifiInfoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Wi-Fi";
            TopMost = true;
            Deactivate += WifiInfoForm_Deactivate;
            Load += WifiInfoForm_Load;
            ((System.ComponentModel.ISupportInitialize)picWifi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblWifiName;
        private Label lblSignal;
        private Label lblDownload;
        private Label lblUpload;
        private PictureBox picWifi;
    }
}
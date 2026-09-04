using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WiFiTrayPlus2
{
    public partial class WifiInfoForm : Form
    {
        public WifiInfoForm()
        {
            InitializeComponent();
        }
        public void SetWifiInfo(
    string wifiName,
    int signal,
    string download,
    string upload)
        {
            lblWifiName.Text = wifiName;
            lblSignal.Text = $"Sygnał: {signal}%";
            lblDownload.Text = $"↓ Pobieranie: {download}";
            lblUpload.Text = $"↑ Wysyłanie: {upload}";
        }
        public void SetWifiIcon(int signal)
        {
            int level;

            if (signal <= 0)
                level = 0;
            else if (signal <= 25)
                level = 1;
            else if (signal <= 50)
                level = 2;
            else if (signal <= 75)
                level = 3;
            else
                level = 4;

            string iconPath = Path.Combine(
                AppContext.BaseDirectory,
                "Resources",
                $"wifi_{level}.ico"
            );

            if (File.Exists(iconPath))
            {
                picWifi.Image?.Dispose();

                using (Icon icon = new Icon(iconPath))
                {
                    picWifi.Image = icon.ToBitmap();
                }
            }
        }
        private void WifiInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void WifiInfoForm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
    }
}

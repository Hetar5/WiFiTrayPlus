using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
namespace WiFiTrayPlus2
{

    public partial class Form1 : Form
    {

      
        
        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void informacjeOWiFiToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            ShowWifiInfo();
        }
        private WifiInfoForm? wifiInfoForm;
        
        private System.Windows.Forms.Timer wifiTimer;
   
 
        public Form1()
        {
            InitializeComponent();

 

         

            wifiTimer = new System.Windows.Forms.Timer();
            wifiTimer.Interval = 1000;
            wifiTimer.Tick += WifiTimer_Tick;
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);


        private Icon CreateSignalIcon(int level)
        {
            using (Bitmap bmp = new Bitmap(16, 16))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.None;

                using (Brush active = new SolidBrush(Color.LimeGreen))
                using (Brush inactive = new SolidBrush(Color.FromArgb(70, 70, 70)))
                using (Pen border = new Pen(Color.FromArgb(25, 25, 25), 1))
                {
                    int[] x = { 0, 4, 8, 12 };
                    int[] height = { 5, 8, 11, 14 };

                    for (int i = 0; i < 4; i++)
                    {
                        int top = 15 - height[i];

                        Brush fill = (i < level) ? active : inactive;

                        using (GraphicsPath path = new GraphicsPath())
                        {
                            int width = 4;
                            int radius = 1;

                            path.AddArc(
                                x[i],
                                top,
                                width,
                                radius * 2,
                                180,
                                90
                            );

                            path.AddArc(
                                x[i] + width - radius * 2,
                                top,
                                radius * 2,
                                radius * 2,
                                270,
                                90
                            );

                            path.AddLine(
                                x[i] + width,
                                top + radius,
                                x[i] + width,
                                top + height[i]
                            );

                            path.AddLine(
                                x[i] + width,
                                top + height[i],
                                x[i],
                                top + height[i]
                            );

                            path.AddLine(
                                x[i],
                                top + height[i],
                                x[i],
                                top + radius
                            );

                            path.CloseFigure();

                            g.FillPath(fill, path);
                            g.DrawPath(border, path);
                        }
                    }

                    if (level == 0)
                    {
                        using (Pen redX = new Pen(Color.Red, 2))
                        {
                            g.DrawLine(redX, 9, 9, 15, 15);
                            g.DrawLine(redX, 15, 9, 9, 15);
                        }
                    }
                }

                IntPtr hIcon = bmp.GetHicon();

                try
                {
                    using (Icon tempIcon = Icon.FromHandle(hIcon))
                    {
                        return (Icon)tempIcon.Clone();
                    }
                }
                finally
                {
                    DestroyIcon(hIcon);
                }
            }
        }

        private void SetSignalIcon(int level)
        {
            string iconPath = $@"Resources\wifi_{level}.ico";
            notifyIcon1.Icon = new Icon(iconPath);
        }

        private int GetWifiSignal()
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = "wlan show interfaces",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (var process = System.Diagnostics.Process.Start(psi))
            {
                if (process == null)
                    return -1;
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                var match = System.Text.RegularExpressions.Regex.Match(
    output,
    @"^\s*Signal\s*:\s*(\d+)\s*%",
    System.Text.RegularExpressions.RegexOptions.Multiline

                );

                if (match.Success)
                {
                    return int.Parse(match.Groups[1].Value);
                }
            }

            return -1;
        }
        private string GetWifiName()
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = "wlan show interfaces",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (var process = System.Diagnostics.Process.Start(psi))
            {
                if (process == null)
                    return "Brak połączenia z Wi-Fi";

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                var match = System.Text.RegularExpressions.Regex.Match(
                    output,
                    @"^\s*SSID\s*:\s*(.+)$",
                    System.Text.RegularExpressions.RegexOptions.Multiline
                );

                if (match.Success)
                {
                    return match.Groups[1].Value.Trim();
                }
            }

            return "Brak połączenia z Wi-Fi";
        }
        private (string wifiName, int signal) GetWifiInfo()
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = "wlan show interfaces",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (var process = System.Diagnostics.Process.Start(psi))
            {
                if (process == null)
                    return ("Brak połączenia z Wi-Fi", -1);

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                string wifiName = "Brak połączenia z Wi-Fi";
                int signal = -1;

                var nameMatch = System.Text.RegularExpressions.Regex.Match(
                    output,
                    @"^\s*SSID\s*:\s*(.+)$",
                    System.Text.RegularExpressions.RegexOptions.Multiline
                );

                if (nameMatch.Success)
                {
                    wifiName = nameMatch.Groups[1].Value.Trim();
                }

                var signalMatch = System.Text.RegularExpressions.Regex.Match(
                    output,
                    @"^\s*Signal\s*:\s*(\d+)\s*%",
                    System.Text.RegularExpressions.RegexOptions.Multiline
                );

                if (signalMatch.Success)
                {
                    signal = int.Parse(signalMatch.Groups[1].Value);
                }

                return (wifiName, signal);
            }
        }
        private (string download, string upload) GetWifiSpeed()
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = "wlan show interfaces",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (var process = System.Diagnostics.Process.Start(psi))
            {
                if (process == null)
                    return ("Nieznana", "Nieznana");

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                var receiveMatch = System.Text.RegularExpressions.Regex.Match(
                    output,
                    @"Receive rate \(Mbps\)\s*:\s*(\d+)"
                );

                var transmitMatch = System.Text.RegularExpressions.Regex.Match(
                    output,
                    @"Transmit rate \(Mbps\)\s*:\s*(\d+)"
                );

                string download = receiveMatch.Success
                    ? receiveMatch.Groups[1].Value + " Mb/s"
                    : "Nieznana";

                string upload = transmitMatch.Success
                    ? transmitMatch.Groups[1].Value + " Mb/s"
                    : "Nieznana";

                return (download, upload);
            }
        }
        private void ShowWifiInfo()
        {
            if (wifiInfoForm != null && !wifiInfoForm.IsDisposed)
            {
                wifiInfoForm.Close();
                wifiInfoForm = null;
                return;
            }

            string wifiName = GetWifiName();
            int signal = GetWifiSignal();

            var speed = GetWifiSpeed();

            wifiInfoForm = new WifiInfoForm();

            wifiInfoForm.SetWifiInfo(
                wifiName,
                signal,
                speed.download,
                speed.upload
              );
            wifiInfoForm.SetWifiIcon(signal);

            Rectangle workingArea = Screen.PrimaryScreen?.WorkingArea
    ?? Screen.FromPoint(Cursor.Position).WorkingArea;

            wifiInfoForm.Location = new Point(
                workingArea.Right - wifiInfoForm.Width - 10,
                workingArea.Bottom - wifiInfoForm.Height - 10
            );

            wifiInfoForm.Show();
        }

        private void WifiTimer_Tick(object? sender, EventArgs e)
        {
            var wifi = GetWifiInfo();

            string wifiName = wifi.wifiName;
            int signal = wifi.signal;

            notifyIcon1.Text = wifiName;

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

            SetSignalIcon(level);
        }



        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            int signal = GetWifiSignal();



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

            SetSignalIcon(level);
            notifyIcon1.Visible = true;
            wifiTimer.Start();
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Hide();
        }
        private void contextMenuStrip1_Opening(
    object? sender,
    System.ComponentModel.CancelEventArgs e)
        {
        }





        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void notifyIcon1_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Diagnostics.Process.Start(
                    "explorer.exe",
                    "ms-availablenetworks:"
                );
            }
        }


    }
            }
        

    

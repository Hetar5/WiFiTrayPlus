namespace WiFiTrayPlus2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            zakończToolStripMenuItem = new ToolStripMenuItem();
            informacjeOWiFiToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { informacjeOWiFiToolStripMenuItem, zakończToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(183, 70);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // zakończToolStripMenuItem
            // 
            zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            zakończToolStripMenuItem.Size = new Size(180, 22);
            zakończToolStripMenuItem.Text = "Zakończ";
            zakończToolStripMenuItem.Click += zakończToolStripMenuItem_Click;
            // 
            // informacjeOWiFiToolStripMenuItem
            // 
            informacjeOWiFiToolStripMenuItem.Name = "informacjeOWiFiToolStripMenuItem";
            informacjeOWiFiToolStripMenuItem.Size = new Size(182, 22);
            informacjeOWiFiToolStripMenuItem.Text = "Informacje oWiFi";
            informacjeOWiFiToolStripMenuItem.Click += informacjeOWiFiToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "Form1";
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem zakończToolStripMenuItem;
        private ToolStripMenuItem informacjeOWiFiToolStripMenuItem;
    }
}

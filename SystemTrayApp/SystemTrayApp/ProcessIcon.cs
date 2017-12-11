using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SystemTrayApp.Properties;

namespace SystemTrayApp
{
    class ProcessIcon : IDisposable
    {
        /// <summary>
        /// The NotifyIcon object.
        /// </summary>
        NotifyIcon ni;
        System.Windows.Forms.Timer t;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessIcon"/> class.
        /// </summary>
        public ProcessIcon()
        {
            // Instantiate the NotifyIcon object.
            ni = new NotifyIcon();
            t = new System.Windows.Forms.Timer();
        }

        /// <summary>
        /// Displays the icon in the system tray.
        /// </summary>
        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            ni.MouseClick += new MouseEventHandler(ni_MouseClick);
            ni.Icon = Resources.SystemTrayApp;
            ni.Text = "System Tray Utility Application Demonstration Program";
            ni.Visible = true;

            // Attach a context menu.


            ni.ContextMenuStrip = new ContextMenus().Create();

            t.Enabled = true;
            t.Interval = 1000;
            t.Tick += t_Tick;
        }
        List<string> copyList = new List<string>();

        void t_Tick(object sender, EventArgs e)
        {
            try
            {
                int count = 0;

                if (Clipboard.GetText().Trim().Length > 0)
                {
                    SharedItems.CopyItems it = new SharedItems.CopyItems() { Text = Clipboard.GetText().Trim(), Date = DateTime.Now };

                    DBOperations operation = new DBOperations();

                    if (operation.GetRecordByText(it.Text) == null)
                    {
                        operation.insertRecord(it);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void Getfiles()
        {
            try
            {
                var obj = Clipboard.GetFileDropList();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            ni.Dispose();
        }
        /// <summary>
        /// Handles the MouseClick event of the ni control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        void ni_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                // Start Windows Explorer.
                //Process.Start("explorer", null);
                frmHome hist = new frmHome();
                hist.ShowDialog();
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppUtility;
using BusinessLogic.DisplayBoards;
using DevComponents.DotNetBar;
using System.Threading;
using BusinessLogic.SortingProcess;

namespace MonitorMain
{

    public partial class PutPortForm : Form
    {

        public PutPortForm(string outportno)
        {
            InitializeComponent();
            cOutPort1.OutPortNo = outportno.ToUpper();

            showOnMonitor(Int16.Parse(AppUtil._ScreenPosition) - 1);
        }



        private void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }


            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

        private void OutPortForm_Load(object sender, EventArgs e)
        {
            cOutPort1.Start();            
        }

        private void OutPortForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}

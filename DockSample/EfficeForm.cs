using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AppUtility;
using BusinessLogic.Common;
using BusinessLogic.DisplayBoards;
using BusinessLogic.INTASKS;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar;

namespace MonitorMain
{

    public partial class EfficeForm : Form
    {


        private string taskdate;
        private string taskno;
        private Dictionary<string, string> soDictionary;


        public EfficeForm()
        {
            InitializeComponent();
            

            showOnMonitor(Int16.Parse(AppUtil._ScreenPosition) - 1);
        }

        private void OutPortForm_Load(object sender, EventArgs e)
        {
            taskdate = SortingLineTask.GetSortingLineTaskDate();
            taskno = SortingLineTask.GetSortingLineTaskNo();
            GetProcess();
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

        void GetProcess()
        {
            
            soDictionary = SortingProgress.GetSortingProcessInfo(taskdate,taskno,SortingLine.GetNonSortingLineCode());
            foreach (Control control in panelEx3.Controls)
            {
                if (control is PanelEx)
                {
                    var panelex = (PanelEx)control as PanelEx;
                    if (panelex.Tag != null)
                    {
                        try
                        {
                            panelex.Text = soDictionary[panelex.Tag.ToString()];
                        }
                        catch (Exception)
                        {
                        }

                    }
                }
            }

            panelEx4.Text = "目标分拣效率15000条/小时，今日平均分拣效率" + soDictionary["EFFICIENCY"];

            panelEx10.Text = "分拣效率  " + soDictionary["EFFICIENCY"];

            progressBarX1.Text = soDictionary["QTY_PRODUCT"] + "/" + soDictionary["QTY_PRODCUT_TOT"] + "条 - " + soDictionary["Progress"] + "%";
            progressBarX1.Maximum = Convert.ToInt32(soDictionary["QTY_PRODCUT_TOT"]);
            progressBarX1.Value = Convert.ToInt32(soDictionary["QTY_PRODUCT"]);
        }


        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
        }
    }
}

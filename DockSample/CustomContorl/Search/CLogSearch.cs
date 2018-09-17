using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Download;
using BusinessLogic.Log;
using BusinessLogic.Search;
using BusinessLogic.SortingTask;
using BusinessLogic.PrintBarcode;
using System.IO;

namespace MonitorMain.CustomContorl.Search
{
    public partial class CLogSearch : UserControl
    {

        public CLogSearch()
        {
            InitializeComponent();
            dateTimeInput1.Value = DateTime.Now;

            DataGridViewTranslation.LoadMainColHeader(dgvLog);
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MonitorLogCriteria monitorLogCriteria = new MonitorLogCriteria();
            monitorLogCriteria.CreateDate = dateTimeInput1.Value.Date.ToString("yyyy-MM-dd HH:mm:dd");
            monitorLogCriteria.AddDate = dateTimeInput1.Value.AddDays(1).AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:dd");
            monitorLogCriteria.LogType = cobtype.SelectedValue is int ? (int) cobtype.SelectedValue : -1;
            monitorLogCriteria.LogLocagtion = cobtype.SelectedText;
            monitorLogCriteria.LogInfo = txtLoginfo.Text.Trim();
            dgvLog.DataSource = MonitorLogList.GetMonitorLogList(monitorLogCriteria);
        }

        

       

        

        private void CSortingTaskSearch_Load(object sender, EventArgs e)
        {
            customButton1.Pulse(10);

            coblocaltion.Items.Add("");
            foreach (string locationname in MonitorLogList.GetLocationName())
            {
                coblocaltion.Items.Add(locationname);
            }

            cobtype.DataSource = MonitorLogList.GetTypes();
            cobtype.ValueMember = "LogType";
            cobtype.DisplayMember = "LogName";
        }


        public static void WriteStopLog()
        {
            try
            {
                DateTime? starttime = null;
                double second = 0;
                double passt = 0;

                double pnum = 0;
                double totolnum = 0;
                int ordernum = 0;
                double waittime = 0;

                string currPath = System.AppDomain.CurrentDomain.BaseDirectory + "Log\\";
                if (!Directory.Exists(currPath))
                {
                    Directory.CreateDirectory(currPath);
                }
                string logfilename = currPath + DateTime.Today.ToString("yyyyMMdd") + "_log.log";

                List<PrintInfo> printinfos = PrintBarCodes.GetAVGPrintEffice();


                if (File.Exists(logfilename) && printinfos.Count > 0)
                    File.Delete(logfilename);
                
                //Dictionary<string, double> effice = new Dictionary<string, double>();
                foreach (PrintInfo printinfo in printinfos)
                {
                    if (starttime == null)
                    {
                        pnum = printinfo.allnum;
                        starttime = printinfo.starttime;
                    }
                    else
                    {
                        second = Convert.ToDouble(ExecDateDiff(Convert.ToDateTime(starttime), printinfo.starttime));
                        if (second > 120)
                        {
                            waittime += second;
                            AppUtility.AppUtil.WriteTxtLog( logfilename,starttime.GetValueOrDefault() + "至" + printinfo.starttime, "停止时间 " + second + "秒");
                        }

                        pnum = printinfo.allnum;
                        starttime = printinfo.starttime;

                    }
                }


                //MessageBox.Show("停机日志生成成功！");
            }
            catch(Exception ex)
            {
                //MessageBox.Show("停机日志生成失败！");
            }
        }

        /// <summary>
        /// 程序执行时间测试
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>返回(秒)单位，比如: 0.00239秒</returns>
        public static string ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //你想转的格式
            return ts3.TotalSeconds.ToString();
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            WriteStopLog();
        }
    }
}

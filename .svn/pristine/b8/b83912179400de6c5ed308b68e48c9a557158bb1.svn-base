using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Search;
using BusinessLogic;
using PlcContract;

namespace MonitorMain.CustomContorl.Search
{
    public partial class CLineBoxSearch : UserControl
    {
        static private CLineBoxSearch _clineboxsearch;
        public CLineBoxSearch()
        {
            InitializeComponent();

            footSumLabel1.Init(dgvLineboxprocess, new Dictionary<string, int>() { { "tOTQTYDataGridViewTextBoxColumn", 0 }, { "nONQTYDataGridViewTextBoxColumn", 0 }, { "fINQTYDataGridViewTextBoxColumn", 0 }, { "OUTQTY", 0 } });
        }


        public static CLineBoxSearch Instance
        {
            get
            {
                return _clineboxsearch;
            }
        }


        private void CLineBoxSearch_Load(object sender, EventArgs e)
        {
            _clineboxsearch = this;
            DataGridViewTranslation.LoadMainColHeader(dgvLineboxprocess);
            LoadLineBoxProcess();
            if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "分拣")
            {
                panel1.Visible = false;
            }
        }

        public void LoadLineBoxProcess()
        {
            LineBoxProcessList lineboxprocesslist =
                LineBoxProcessList.GetList(ConfigurationSettings.AppSettings["Mode"].ToLower());
            try
            {
                OperateOpcAndSoft operateOpcAndSoft = new OperateOpcAndSoft();
                Dictionary<int, int> putoutnums = operateOpcAndSoft.GetPutOutNum();

                for (int i = 0; i < lineboxprocesslist.Count; i++)
                {
                    if (putoutnums.ContainsKey(Convert.ToInt32(lineboxprocesslist[i].LINEBOXCODE)))
                    {
                        lineboxprocesslist[i].OUTQTY = putoutnums[Convert.ToInt32(lineboxprocesslist[i].LINEBOXCODE)];
                        lineboxprocesslist[i].REMAINQTY = lineboxprocesslist[i].NONQTY - lineboxprocesslist[i].OUTQTY;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            dgvLineboxprocess.DataSource = lineboxprocesslist;
            footSumLabel1.Sumdata();

        }

        private void dgvLineboxprocess_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel1.vscrollvalue = e.NewValue;
            }
            footSumLabel1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                LoadLineBoxProcess();
            }
            catch (Exception ex)
            {

                MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "读取进度查询错误";
                monitorLog.LOGINFO = ex.Message;
                monitorLog.LOGLOCATION = "数据库";
                monitorLog.LOGTYPE = 1;
                monitorLog.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvLineboxprocess.DataSource = LineBoxProcessList.GetList(ConfigurationSettings.AppSettings["Mode"].ToLower());
            footSumLabel1.Sumdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvLineboxprocess.DataSource = LineBoxProcessList.GetList();
            footSumLabel1.Sumdata();
        }
    }
}

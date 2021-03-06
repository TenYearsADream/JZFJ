﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.INTASKS;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

using PlcContract;
using Timer = System.Windows.Forms.Timer;
using HDWLogic.Issued;
using BusinessLogic.arrive;


namespace MonitorMain.CustomContorl
{
    public partial class CInTask : UserControl
    {
        private InTaskList m_nonInTaskList;
        private InTaskList m_finInTaskList;
        private string maxtaskno;
        private InTaskIssuedList m_InTaskIssuedList;
        
        private SortingTaskArrives m_SortingTaskArrives;
        private MonitorLog monitorLog;
        public event EventHandler<EventArgs> OnTaskStatusChanged;
        public event EventHandler<EventArgs> OnTaskStopFinished;

        protected virtual void OnOnTaskStopFinished()
        {
            EventHandler<EventArgs> handler = OnTaskStopFinished;
            if (handler != null) handler(this, EventArgs.Empty);
        }


        Thread thread;
        private Timer timer;
        private bool threadstop = true;
        private delegate void d_LoadGridData(DataGridViewX da);
        public TaskStatus taskStatus = new TaskStatus();
        OperateOpcAndSoft operateOpcAndSoft = new OperateOpcAndSoft();

        private InTask _comfirmintask;
        private Dictionary<string, DataGridViewX> dataGridViewXs;


        public CInTask()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            taskStatus = TaskStatus.Stop;
            panelEx1.Text = "暂无补货品规 ";
            dataGridViewXs = new Dictionary<string, DataGridViewX>();
            dataGridViewXs.Add("superTabItem1", dgviewnone);
            dataGridViewXs.Add("superTabItem3", dgvconfirm);
            dataGridViewXs.Add("superTabItem2", dgviewfin);

            footSumLabel1.Init(dgviewnone, new Dictionary<string, int>() { { "dataGridViewTextBoxColumn11", 0 } });
            footSumLabel2.Init(dgvconfirm, new Dictionary<string, int>() { { "dataGridViewTextBoxColumn36", 0 } });
            footSumLabel3.Init(dgviewfin, new Dictionary<string, int>() { { "dataGridViewTextBoxColumn22", 0 } });
        }


        public void LoadInTask()
        {

            dgviewnone.DataSource = m_nonInTaskList = InTaskList.GetFinInTaskList("0");
            dgvconfirm.DataSource = m_finInTaskList = InTaskList.GetFinInTaskList("1");
            dgviewfin.DataSource = m_finInTaskList = InTaskList.GetAllInTaskList();
            
            footSumLabel1.Sumdata();
            footSumLabel2.Sumdata();
            footSumLabel3.Sumdata();
        }

        void LoadGridData(DataGridViewX dataGrid)
        {
            if (!dataGrid.InvokeRequired)
            {
                dataGrid.DataSource = null;
                dataGrid.DataSource = m_InTaskIssuedList;
            }
            else
            {
                CInTask.d_LoadGridData de = LoadGridData;
                this.Invoke(de, dataGrid);
            }
        }


        public void LoadPLCTask()
        {
            //this.SuspendLayout();
            m_InTaskIssuedList = InTaskIssuedList.GetInTaskIssuedList();
            //LoadGridData(dataGridViewX2);
            //this.ResumeLayout(false);
        }


        public void StartScanTask()
        {
            //设置任务开始状态
            taskStatus = TaskStatus.Run;             

            if (thread == null)
            {
                thread = new Thread(ScanTask);
                thread.IsBackground = true;
                thread.Name = "PLCBHTask";
                thread.Start();
                
                if (OnTaskStatusChanged != null)
                {
                    OnTaskStatusChanged.Invoke(null, new EventArgs());
                }
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "线程操作";
                monitorLog.LOGINFO = "补货线程开始!";
                monitorLog.LOGLOCATION = "线程";
                monitorLog.LOGTYPE = 0;
                monitorLog.Save();
            }
            //else if (taskStatus == TaskStatus.Stop)
            //{
            //    thread.Start();
            //    taskStatus = TaskStatus.Run;
            //    if (OnTaskStatusChanged != null)
            //    {
            //        OnTaskStatusChanged.Invoke(null, new EventArgs());
            //    }
            //    monitorLog = MonitorLog.NewMonitorLog();
            //    monitorLog.LOGNAME = "线程操作";
            //    monitorLog.LOGINFO = "补货线程开始!";
            //    monitorLog.LOGLOCATION = "线程";
            //    monitorLog.LOGTYPE = 0;
            //    monitorLog.Save();
            //}
            //else if (taskStatus == TaskStatus.Suspend)
            //{
            //    thread.Resume();
            //    taskStatus = TaskStatus.Run;
            //    if (OnTaskStatusChanged != null)
            //    {
            //        OnTaskStatusChanged.Invoke(null, new EventArgs());
            //    }
            //    monitorLog = MonitorLog.NewMonitorLog();
            //    monitorLog.LOGNAME = "线程操作";
            //    monitorLog.LOGINFO = "补货线程恢复!";
            //    monitorLog.LOGLOCATION = "线程";
            //    monitorLog.LOGTYPE = 0;
            //    monitorLog.Save();
            //}
        }

        public void StopScanTask()
        {
            taskStatus = TaskStatus.Stop;
            if (thread != null)
            {
                while (thread.IsAlive)
                {
                    Thread.Sleep(300);
                }
                thread = null;
                
                
                if (OnTaskStatusChanged != null)
                {
                    OnTaskStatusChanged.Invoke(null, new EventArgs());
                }
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "线程操作";
                monitorLog.LOGINFO = "补货线程停止!";
                monitorLog.LOGLOCATION = "线程";
                monitorLog.LOGTYPE = 0;
                monitorLog.Save();

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["IsStart"].Value = false.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            OnOnTaskStopFinished();
        }

        public void SuspendScanTask()
        {
            if (thread != null)
            {
                thread.Suspend();
                taskStatus = TaskStatus.Suspend;
                if (OnTaskStatusChanged != null)
                {
                    OnTaskStatusChanged.Invoke(null, new EventArgs());
                }
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "线程操作";
                monitorLog.LOGINFO = "补货线程暂停!";
                monitorLog.LOGLOCATION = "线程";
                monitorLog.LOGTYPE = 0;
                monitorLog.Save();
            }

        }

        private void ScanTask()
        {
            PlCResult plCResult = new PlCResult();
            try
            {
                plCResult = operateOpcAndSoft.InDataToTaskAddress();
            }
            catch
            {
            }
            if (plCResult.Succeed)
            {
                while (taskStatus == TaskStatus.Run)
                {
                    if (!InTaskList.IsInTaskFinish())
                    {
                        //获取需要下达的任务
                        InTask inTask = InTaskList.GetComfirmRequestInTask();
                        if (inTask != null)
                        {
                            if (!string.IsNullOrEmpty(inTask.ID))
                            {
                                //下达补货任务
                                plCResult = operateOpcAndSoft.ReplenishmentTask(inTask);
                                if (plCResult.Succeed)
                                {
                                    //写日志
                                    MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                                    monitorLog.LOGNAME = "PLC任务下达";
                                    monitorLog.LOGINFO = "PLCTASKNO:" + inTask.INDEXNO.ToString().PadRight(10);
                                    monitorLog.LOGINFO += "CIG:" + inTask.CIGCODE + "-" + inTask.CIGNAME + "-" +
                                                         inTask.PICKLINENAME +
                                                         "-" + inTask.INQTY;
                                    monitorLog.LOGLOCATION = "PLC";
                                    monitorLog.LOGTYPE = 0;
                                    monitorLog.Save();
                                    //加载数据
                                    this.BeginInvoke(new MethodInvoker(LoadInTask));

                                    //while (!operateOpcAndSoft.IsIntaskScanFinish(inTask))
                                    //{
                                    //    Thread.Sleep(300);
                                    //}
                                }
                                else if (!string.IsNullOrEmpty(plCResult.Exception))
                                {
                                    //写日志
                                    MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                                    monitorLog.LOGNAME = "PLC补货任务下达异常";
                                    monitorLog.LOGINFO = plCResult.Exception;
                                    monitorLog.LOGLOCATION = "PLC";
                                    monitorLog.LOGTYPE = 0;
                                    monitorLog.Save();
                                }
                            }
                        }
                    }
                    else
                    {
                        //写日志
                        Thread.Sleep(2000);
                        MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                        monitorLog.LOGNAME = "PLC任务下达";
                        monitorLog.LOGINFO = "补货任务下达全部完成";
                        monitorLog.LOGLOCATION = "PLC";
                        monitorLog.LOGTYPE = 0;
                        monitorLog.Save();

                        //设置完成后的界面及参数
                        BHMainForm.Instance.InTaskFinish();
                        break;
                    }
                    Thread.Sleep(1000);
                }
            }
            else
            {
                //写日志
                MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "PLC补货绑定品牌下达异常";
                monitorLog.LOGINFO = plCResult.Exception;
                monitorLog.LOGLOCATION = "PLC";
                monitorLog.LOGTYPE = 0;
                monitorLog.Save();
            }
        }

        //private void TaskFinish()
        //{
        //    PlCResult plCResult = new PlCResult();
            
            
        //        while (taskStatus == TaskStatus.Run)
        //        {

        //                    plCResult = operateOpcAndSoft.IsIntaskScanFinish();
        //                    if (plCResult.Succeed)
        //                    {
        //                        //写日志
        //                        MonitorLog monitorLog = MonitorLog.NewMonitorLog();
        //                        monitorLog.LOGNAME = "PLC任务下达";
        //                        monitorLog.LOGINFO = "PLCTASKNO:" + inTask.INDEXNO.ToString().PadRight(10);
        //                        monitorLog.LOGINFO = "CIG:" + inTask.CIGCODE + "-" + inTask.CIGNAME + "-" +
        //                                             inTask.PICKLINENAME +
        //                                             "-" + inTask.INQTY;
        //                        monitorLog.LOGLOCATION = "PLC";
        //                        monitorLog.LOGTYPE = 0;
        //                        monitorLog.Save();
        //                        //加载数据
        //                        this.BeginInvoke(new MethodInvoker(LoadInTask));

        //                        //while (!operateOpcAndSoft.IsIntaskScanFinish(inTask))
        //                        //{
        //                        //    Thread.Sleep(300);
        //                        //}
        //                    }
        //                    else
        //                    {
        //                        //写日志
        //                        MonitorLog monitorLog = MonitorLog.NewMonitorLog();
        //                        monitorLog.LOGNAME = "PLC补货任务下达异常";
        //                        monitorLog.LOGINFO = plCResult.Exception;
        //                        monitorLog.LOGLOCATION = "PLC";
        //                        monitorLog.LOGTYPE = 0;
        //                        monitorLog.Save();
        //                    }
        //                }
        //            Thread.Sleep(1000);
        //        }
           
        



        private void CSortingTask_Load(object sender, EventArgs e)
        {
            DataGridViewTranslation.LoadMainColHeader(dgviewnone);
            DataGridViewTranslation.LoadMainColHeader(dgvconfirm);
            DataGridViewTranslation.LoadMainColHeader(dgviewfin);
            

            if (IsVerifyPass())
            {
                LoadInTask();
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "数据库读取";
                monitorLog.LOGINFO = "补货数据读取成功!";
                monitorLog.LOGLOCATION = "数据库";
                monitorLog.LOGTYPE = 1;
                monitorLog.Save();
                LoadPLCTask();                
            }
            maxtaskno = InTask.GetMaxIndex();
        }

        private bool IsVerifyPass()
        {
            InTask.IsCurrentInTask();
            
            if (InTask.IsIndexRepetition())
            {
                MessageBox.Show("任务中出现相同的顺序号,请检查补货数据后重新下载！");
                return false;
            }
            return true;
        }


        public void ReLoad()
        {
            if (IsVerifyPass())
            {
                LoadPLCTask();
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "数据库读取";
                monitorLog.LOGINFO = "补货数据读取成功!";
                monitorLog.LOGLOCATION = "数据库";
                monitorLog.LOGTYPE = 1;
                monitorLog.Save();
                LoadPLCTask();
                
            }
        }

        
        
        private void labpicklinename_Click(object sender, EventArgs e)
        {

        }

        private void tim_confirmrequest_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            LoadConfirmrequest();
        }

        private void LoadConfirmrequest()
        {
            if (!InTaskList.IsInTaskFinish())
            {
                _comfirmintask = InTask.GetConfirmInTask();
                if (_comfirmintask != null && _comfirmintask.INDEXNO > 0)
                {
                    panelEx2.Visible = true;
                    panelEx2.Dock = DockStyle.Fill;
                    //labintaskno.Text = _comfirmintask.INTASKNO.ToString();
                    laborderdate.Text = _comfirmintask.ORDERDATE;
                    //labintaskport.Text = _comfirmintask.INPORTCODE;
                    labindexno.Text = _comfirmintask.INDEXNO.ToString() + "/" + maxtaskno;
                    labcigcode.Text = _comfirmintask.BARCODE;
                    labcigname.Text = _comfirmintask.CIGNAME;
                    //labcigqty.Text = (_comfirmintask.INQTY/50).ToString();
                }
                else
                {
                    panelEx2.Visible = false;
                    panelEx2.Dock = DockStyle.None;
                }
            }
            else
            {
                panelEx2.Visible = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //if (_comfirmintask != null)
            //{
            //    _comfirmintask.Status = 1;
            //    _comfirmintask.SaveInTaskProcess(_comfirmintask.ID);
            //    panelEx2.Visible = false;
            //    panelEx2.Dock = DockStyle.None;
            //}
            //LoadInTask();
        }

        private void 设置分拣未完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否设置状态为未完成", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SetInTaskStatus(0);
                LoadInTask();
            }
        }

        private void SetInTaskStatus(int status)
        {
            string indexcolname = "";
            string custcolname = "";
            foreach (DataGridViewColumn column in dataGridViewXs[superTabControl1.SelectedTab.Name].Columns)
            {
                if (column.DataPropertyName.ToUpper() == "INDEXNO")
                {
                    indexcolname = column.Name;
                }
            }


            foreach (DataGridViewRow selectedRow in dataGridViewXs[superTabControl1.SelectedTab.Name].SelectedRows)
            {
                //改变任务状态
                string indexcolvalue = selectedRow.Cells[indexcolname].Value.ToString();
                
                InTask inTask = InTask.GetInTaskByIndex(indexcolvalue);
                inTask.Status = status;
                inTask.SaveInTaskProcess(inTask.ID);
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            LoadInTask();
        }

        private void dgviewnone_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel1.vscrollvalue = e.NewValue;
            }
            footSumLabel1.Invalidate();
        }

        private void dgvconfirm_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel2.vscrollvalue = e.NewValue;
            }
            footSumLabel2.Invalidate();
        }

        

        private void dgviewfin_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel3.vscrollvalue = e.NewValue;
            }
            footSumLabel3.Invalidate();
        }

        private void 设置分拣已下达ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否设置状态为已下达", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SetInTaskStatus(1);
                LoadInTask();
            }
        }

        private void 设置补货已完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否设置状态为已完成", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SetInTaskStatus(2);
                LoadInTask();
            }
        }
    }
    
}

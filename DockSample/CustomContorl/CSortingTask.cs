﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AppUtility;
using BusinessLogic;
using BusinessLogic.Box;
using BusinessLogic.Common;
using BusinessLogic.SortingProcess;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar.Controls;
using HDWLogic.Issued;

using PlcContract;
using Timer = System.Windows.Forms.Timer;
using DevComponents.DotNetBar;
using MonitorMain.CustomContorl.Search;
using BusinessLogic.PrintBarcode;
using BusinessLogic.arrive;
using BusinessLogic.DisplayBoards;
using PosPrint;
using BusinessLogic.Log;
using HDWLogic;
using PrintInfo = BusinessLogic.Print.PrintInfo;

namespace MonitorMain.CustomContorl
{
    public sealed partial class CSortingTask : UserControl
    {
        private SortingLineTaskList m_nonSortingLineTaskList;
        private SortingLineTaskList m_finSortingLineTaskList;
        private SortingLineTaskList m_issuedSortingLineTaskList;
        private SortingLineTaskDetails m_nonSortingLineTaskDetails;
        private SortingLineTaskDetails m_finSortingLineTaskDetails;
        private SortingLineTaskDetails m_issuedSortingLineTaskDetails;
        private SortingTaskIssuedList m_SortingTaskIssuedList;
        private SortingTaskIssuedDetails m_SortingTaskIssuedDetails;
        private SortingTaskArrives m_SortingTaskArrives;
        private MonitorLog monitorLog;
        public TaskStatus taskStatus = new TaskStatus();
        private OperateOpcAndSoft operateOpcAndSoft = new OperateOpcAndSoft();

        private Thread Issuedthread;
        private Thread Arrivedthread;
        private Timer timer;
        private bool threadstop = true;

        private delegate void d_LoadGridData(DataGridViewX da);

        public event EventHandler<EventArgs> OnTaskStatusChanged;
        public event EventHandler<EventArgs> OnTaskStopFinished;
        public static event EventHandler<UpdateCSortingMainNumEventArgs> OnUpdateCSortingMainNumEvent;
        public static event EventHandler<EventArgs> OnTaskMoved;
        


        private void OnOnTaskStopFinished()
        {
            EventHandler<EventArgs> handler = OnTaskStopFinished;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private LPTPrintSetup printset = new LPTPrintSetup(); //打印类
        private Dictionary<string, DataGridViewX> dataGridViewXs;
        private bool sort;

        public CSortingTask()
        {
            InitializeComponent();
            
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Dock = DockStyle.Fill;
            taskStatus = TaskStatus.Stop;
            dataGridViewXs = new Dictionary<string, DataGridViewX>();
            dataGridViewXs.Add("superTabItem1", dgviewnone);
            dataGridViewXs.Add("superTabItem3", dgvIssued);
            dataGridViewXs.Add("superTabItem2", dgviewfin);

            //合计使用
            //1.构造中绑定需要合计的列
            //2.绑定数据后调用合计方法
            //3.滚动条事件中重绘合计
            footSumLabel3.Init(dgviewnonedetail, new Dictionary<string, int>() {{"qTYDataGridViewTextBoxColumn", 0}});
            footSumLabel1.Init(dgvIssueddetail, new Dictionary<string, int>() {{"qTYDataGridViewTextBoxColumn2", 0}});
            footSumLabel2.Init(dgviewfindetail, new Dictionary<string, int>() {{"qTYDataGridViewTextBoxColumn4", 0}});


                        

            //SocketCommunication.SocketManager.Instance.EV_SendBoxSuccessed += new EventHandler<SocketCommunication.SortingTaskEventArgs>(Instance_EV_SendBoxSuccessed);

            Thread thread = new Thread(new ParameterizedThreadStart(SortingProcessList.GetSortingProcessList));
            thread.Start(SortingLine.GetNonSortingLineCode());
        }

        ~CSortingTask()
        {
            Issuedthread.Abort();
        }
        //void Instance_EV_SendBoxSuccessed(object sender, SocketCommunication.SortingTaskEventArgs e)
        //{
        //    SendBoxInfo sendBoxInfo = null;
        //    if (e.OutPort == "1")
        //    {
        //        foreach (var firstSendBoxInfo in SendBoxList.FirstSendBoxInfos)
        //        {
        //            if (firstSendBoxInfo.SortingLineTask.SORTINGTASKNO.ToString() == e.TaskNo)
        //            {
        //                sendBoxInfo = firstSendBoxInfo;
        //            }
        //        }
        //    }
        //    if (e.OutPort == "2")
        //    {
        //        foreach (var secondSendBoxInfo in SendBoxList.SecondSendBoxInfos)
        //        {
        //            if (secondSendBoxInfo.SortingLineTask.SORTINGTASKNO.ToString() == e.TaskNo)
        //            {
        //                sendBoxInfo = secondSendBoxInfo;
        //            }
        //        }
        //    }
        //    if (sendBoxInfo != null)
        //    {
        //        sendBoxInfo.ReceiveTime = DateTime.Now;
        //    }
        //}

        private void LoadGridData(DataGridView dataGrid)
        {
            if (!dataGrid.InvokeRequired)
            {
                dataGrid.DataSource = m_SortingTaskIssuedList;
            }
            else
            {
                d_LoadGridData de = LoadGridData;
                this.Invoke(de, dataGrid);
            }
        }


        private void CSortingTask_Load(object sender, EventArgs e)
        {
            DataGridViewTranslation.LoadMainColHeader(dgviewnone);
            DataGridViewTranslation.LoadMainColHeader(dgvIssued);
            DataGridViewTranslation.LoadMainColHeader(dgviewfin);

            DataGridViewTranslation.LoadDetailColHeader(dgviewnonedetail);
            DataGridViewTranslation.LoadDetailColHeader(dgvIssueddetail);
            DataGridViewTranslation.LoadDetailColHeader(dgviewfindetail);

            LoadOrder();
            superTabControl1.SelectedTabIndex = 0;

            //程序开始就启动到达线程
            //if (Arrivedthread == null)
            //{
            //    Arrivedthread = new Thread(FinishTask);
            //    Arrivedthread.IsBackground = true;
            //    Arrivedthread.Name = "ArrivedthreadTask";
            //    Arrivedthread.Start();


            //    monitorLog = MonitorLog.NewMonitorLog();
            //    monitorLog.LOGNAME = "线程操作";
            //    monitorLog.LOGINFO = "分拣任务到达线程开始!";
            //    monitorLog.LOGLOCATION = "线程";
            //    monitorLog.LOGTYPE = 0;
            //    monitorLog.Save();
            //}
        }

        private void dgviewnone_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                m_nonSortingLineTaskDetails =
                    SortingLineTaskDetails.GetSortingLineTaskDetailsByTaskId(
                        dgviewnone.SelectedRows[0].Cells[0].Value.ToString());
                dgviewnonedetail.DataSource = m_nonSortingLineTaskDetails;
                footSumLabel3.Sumdata();
            }
            catch (Exception)
            {


            }

        }

        private void dataGridViewX2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                m_SortingTaskIssuedDetails =
                    m_SortingTaskIssuedList.GetSortingTaskIssuedById(
                        dgviewnone.SelectedRows[0].Cells[0].Value.ToString()).SortingTaskIssuedDetails;
                dataGridViewX2.DataSource = m_nonSortingLineTaskDetails;

            }
            catch (Exception)
            {


            }
        }



        private void dgviewfin_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                m_finSortingLineTaskDetails =
                    SortingLineTaskDetails.GetSortingLineTaskDetailsByTaskId(
                        dgviewfin.SelectedRows[0].Cells[0].Value.ToString());
                dgviewfindetail.DataSource = m_finSortingLineTaskDetails;
                footSumLabel2.Sumdata();
            }
            catch (Exception)
            {


            }
        }

        private void dgvIssued_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                m_issuedSortingLineTaskDetails =
                    SortingLineTaskDetails.GetSortingLineTaskDetailsByTaskId(
                        dgvIssued.SelectedRows[0].Cells[0].Value.ToString());
                dgvIssueddetail.DataSource = m_issuedSortingLineTaskDetails;
                footSumLabel1.Sumdata();
            }
            catch (Exception)
            {


            }
        }

        private void chkisall_CheckedChanged(object sender, DevComponents.DotNetBar.CheckBoxChangeEventArgs e)
        {
            LoadOrder();
        }

        private void dgviewnone_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //try
            //{
            //    Color color = dgviewnone.RowHeadersDefaultCellStyle.ForeColor;
            //    if (dgviewnone.Rows[e.RowIndex].Selected)
            //        color = dgviewnone.RowHeadersDefaultCellStyle.SelectionForeColor;
            //    else
            //        color = dgviewnone.RowHeadersDefaultCellStyle.ForeColor;

            //    using (SolidBrush b = new SolidBrush(color))
            //    {
            //        e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
            //            e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 6);
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }

        private void 设置分拣已下达ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taskStatus == TaskStatus.Run)
            {
                MessageBox.Show("请先暂停任务下达！");
            }
            else
            {
                if (MessageBox.Show("是否设置状态为已下达", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SetSortingStatus(1);
                    LoadOrder();
                    FJMainForm.Instance.CBox.LoadCigBox();
                }
            }
        }

        private void 设置分拣已完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("是否设置状态为已完成", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SetSortingStatus(2);
                LoadOrder();
                FJMainForm.Instance.CBox.LoadCigBox();
            }

        }

        private void 设置分拣未完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taskStatus == TaskStatus.Run)
            {
                MessageBox.Show("请先暂停任务下达！");
            }
            else
            {
                if (MessageBox.Show("是否设置状态为未完成", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SetSortingStatus(0);
                    LoadOrder();
                    FJMainForm.Instance.CBox.LoadCigBox();
                    SortingTaskIssued sortingTaskIssued = SortingTaskIssued.GetSortingTaskIssued("0");
                    sortingTaskIssued.PLCFLAG = 0;
                    sortingTaskIssued.Save();

                    FJMainForm.Instance.CSortingMain.ResetCmain();
                }
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void dgviewnonedetail_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel3.vscrollvalue = e.NewValue;
            }
            footSumLabel3.Invalidate();
        }

        private void dgvIssueddetail_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel1.vscrollvalue = e.NewValue;
            }
            footSumLabel1.Invalidate();
        }

        private void dgviewfindetail_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel2.vscrollvalue = e.NewValue;
            }
            footSumLabel2.Invalidate();
        }

        bool ispd = false; 
        private void timer1_Tick(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow dataGridViewRow in dgviewnone.Rows)
            //{
            //    if (dataGridViewRow.DefaultCellStyle.BackColor == Color.Gray)
            //    {
            //        dataGridViewRow.DefaultCellStyle.BackColor = Color.White;
            //        dataGridViewRow.DefaultCellStyle.ForeColor = Color.Black;
            //    }
            //    if ((Convert.ToInt32(dataGridViewRow.Cells["ISLOCK"].Value) == 1))
            //    {
            //        dataGridViewRow.DefaultCellStyle.BackColor = Color.Gray;
            //        dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
            //    }
            //}
            //Thread thread = new Thread(CheckPD);
            //thread.Start();
        }

        object o = new object();
        /// <summary>
        /// 检测盘点按钮并发送盘点信息
        /// </summary>
        private void CheckPD()
        {
            lock(o)
            {
                bool pd = operateOpcAndSoft.GetPDInfo();
                if (pd == true && ispd == false)
                {
                    ispd = pd;
                    Nixielight ni = new Nixielight();
                    ni.SendPD();
                }
                else
                {
                    ispd = pd;
                }
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }




        #region 业务处理

        public void StartScanTask()
        {
            taskStatus = TaskStatus.Run;

            if (Issuedthread == null)
            {
                Issuedthread = new Thread(ScanTask);
                Issuedthread.IsBackground = true;
                Issuedthread.Name = "IssuedthreadTask";
                Issuedthread.Start();

                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "线程操作";
                monitorLog.LOGINFO = "分拣任务下达线程开始!";
                monitorLog.LOGLOCATION = "线程";
                monitorLog.LOGTYPE = 0;
                monitorLog.Save();
            }

            if (Arrivedthread == null)
            {
                Arrivedthread = new Thread(FinishTask);
                Arrivedthread.IsBackground = true;
                Arrivedthread.Name = "ArrivedthreadTask";
                Arrivedthread.Start();


                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "线程操作";
                monitorLog.LOGINFO = "分拣任务到达线程开始!";
                monitorLog.LOGLOCATION = "线程";
                monitorLog.LOGTYPE = 0;
                monitorLog.Save();
            }
            else
            {
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "线程操作";
                monitorLog.LOGINFO = "分拣任务到达线程正在运行!";
                monitorLog.LOGLOCATION = "线程";
                monitorLog.LOGTYPE = 0;
                monitorLog.Save();
            }

            if (OnTaskStatusChanged != null)
            {
                OnTaskStatusChanged.Invoke(null, new EventArgs());
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["IsStart"].Value = true.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


        public void StopScanTask()
        {
            //只暂停下达任务，不暂停到达任务
            //分拣线需要到达任务将皮带上的烟分拣完
            taskStatus = TaskStatus.Stop;
            if (Issuedthread != null)
            {
                while (Issuedthread.IsAlive)
                {
                    Thread.Sleep(300);
                }
                Issuedthread = null;
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "线程操作";
                monitorLog.LOGINFO = "分拣任务下达线程停止!";
                monitorLog.LOGLOCATION = "线程";
                monitorLog.LOGTYPE = 0;
                monitorLog.Save();



                //while (Arrivedthread.IsAlive)
                //{
                //    Thread.Sleep(300);
                //}
                //Arrivedthread = null;

                //monitorLog = MonitorLog.NewMonitorLog();
                //monitorLog.LOGNAME = "线程操作";
                //monitorLog.LOGINFO = "分拣任务到达线程停止!";
                //monitorLog.LOGLOCATION = "线程";
                //monitorLog.LOGTYPE = 0;
                //monitorLog.Save();


                if (OnTaskStatusChanged != null)
                {
                    OnTaskStatusChanged.Invoke(null, new EventArgs());
                }


                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["IsStart"].Value = false.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            OnOnTaskStopFinished();
        }

        /// <summary>
        /// 分拣任务下达流程
        /// </summary>
        private void ScanTask()
        {
            SortingLineTask sortingLineTask = null;
            while (taskStatus == TaskStatus.Run)
            {
                try
                {
                    //是否有未完成的订单
                    if (!SortingLineTaskList.IsSortingFinish())
                    {
                            //判断标识是否可以下达任务，表示上一次任务是否已经完成
                            SortingTaskIssued sortingTaskIssued = SortingTaskIssued.GetSortingTaskIssued("0");
                            if (sortingTaskIssued.PLCFLAG == 0)
                            {
                                //PLC信息小车是否走到位,或者已扫描到分户盒
                                //分拣工可能先放分户盒，但程序必须判断上次任务是否完成
                                //if (operateOpcAndSoft.GetCubeReady())
                                //{
                                // if(operateOpcAndSoft.GetCubeIndexno > FJMainForm.Instance.CSortingMain.c_Cubes.Last().labindexno)
                                //    int a = operateOpcAndSoft.GetCubeReady() -
                                //            FJMainForm.Instance.CSortingMain.c_Cubes.Last().labindexno;
                                //}
                                if (operateOpcAndSoft.GetCubeReady())
                                {
                                    SortingLineTaskQueue.GetInstance().Move();

                                    //重新加载一次任务队列
                                    SortingLineTaskQueue.GetInstance().LoadSortingLineTasks();

                                    //获取最小排序号的订单
                                    sortingLineTask = SortingLineTask.GetMinSortingLineTask();

                                    //将最小订单放入队列中进行分拣
                                    SortingLineTaskQueue.GetInstance().Enqueue(sortingLineTask);
                                    SortingLineTaskQueue.GetInstance().CreateCubesModel();


                                    //发送卷烟数量到数码管
                                    ATOPTagSdk.instance.SetOrderNixielight(SortingLineTaskQueue.GetInstance().SortingLineTasks);

                                    //通知前台界面显示数码管数量
                                    if (OnUpdateCSortingMainNumEvent != null)
                                    {
                                        OnUpdateCSortingMainNumEvent.Invoke(null,
                                            new UpdateCSortingMainNumEventArgs(ATOPTagSdk.Tags));
                                    }


                                    //如果不是用用来补足的空任务
                                    if (sortingLineTask.INDEXNO > 0)
                                    {
                                        //保存任务状态为已下达
                                        sortingLineTask.Status = 1;
                                        sortingLineTask.SaveSortingTaskProcess(sortingLineTask.ID);
                                    }

                                    //将下达任务标志位设置成已下达
                                    sortingTaskIssued.PLCFLAG = 1;
                                    sortingTaskIssued.PLCTASKNO = sortingLineTask.INDEXNO.ToString();
                                    sortingTaskIssued.ORDERNUMBER = sortingLineTask.SumOrderNumber();
                                    sortingTaskIssued.Save();

                                    //写日志
                                    monitorLog = MonitorLog.NewMonitorLog();
                                    monitorLog.LOGNAME = "任务下达";
                                    monitorLog.LOGINFO = "  任务号:" + sortingLineTask.INDEXNO.ToString().PadRight(10);
                                    monitorLog.LOGLOCATION = "数据库";
                                    monitorLog.LOGTYPE = 0;
                                    monitorLog.Save();
                                    this.BeginInvoke(new MethodInvoker(LoadOrder));
                                    //FJMainForm.Instance.CSortingMain.UpdateLineboxCapacity();

                                }


                            }
                    
                    }
                    else
                    {
                        //写日志
                        MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                        monitorLog.LOGNAME = "任务下达";
                        monitorLog.LOGINFO = "分拣任务全部完成";
                        monitorLog.LOGLOCATION = "数据库";
                        monitorLog.LOGTYPE = 0;
                        monitorLog.Save();

                        //发送分拣完成到上位机
                        //FJMainForm.Instance.SortingFinish();
                        SortingLineTaskQueue.GetInstance().CubesModel.Clear();
                        Array.Clear(SortingLineTaskQueue.GetInstance().SortingLineTasks,0, SortingLineTaskQueue.GetInstance().QueueMaxCount);
                        SortingLineTaskQueue.GetInstance().InvokeOnUpdateCubeEvent();

                        SoundPlayer player = new SoundPlayer();
                        player.SoundLocation = Application.StartupPath + "\\Sound\\分拣结束.wav";
                        player.Load();
                        player.Play();

                        break;//跳出下达循环
                    }
                    Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    //写日志
                    monitorLog = MonitorLog.NewMonitorLog();
                    if (sortingLineTask != null) 
                        monitorLog.LOGNAME = "任务号" + sortingLineTask.INDEXNO + " 分拣任务下达异常";
                    else
                    {
                        monitorLog.LOGNAME = "任务号未知" + " 分拣任务下达异常";
                    }
                    monitorLog.LOGINFO = e.Message;
                    monitorLog.LOGLOCATION = "数据库";
                    monitorLog.LOGTYPE = 0;
                    monitorLog.Save();
                }
            }
        }

        /// <summary>
        /// 分拣任务到达出口流程
        /// </summary>
        public void FinishTask()
        {
              
            //到达任务只要开始后就不会停止
            while (true)
            {
                SortingTaskIssued sortingTaskIssued = SortingTaskIssued.GetSortingTaskIssued("0");

                if (ATOPTagSdk.Tags != null)
                {
                    //提示前台界面已按下的数量
                    if (OnUpdateCSortingMainNumEvent != null)
                    {
                        OnUpdateCSortingMainNumEvent.Invoke(null, new UpdateCSortingMainNumEventArgs(ATOPTagSdk.Tags));
                    }
                }

                 
                //按钮按完进行后续操作
                if (ATOPTagSdk.instance.GetPlcPressTagReady())
                {
                    if (sortingTaskIssued.PLCFLAG != 0)
                    {
                        if (ATOPTagSdk.Tags != null)
                        {
                            foreach (KeyValuePair<int, Tag> tag in ATOPTagSdk.Tags)
                            {
                                SortingLineTaskDetail.SaveStatus(tag.Value.TaskNo, tag.Value.LineboxCode.ToString(), 2);
                            }
                            SortingLineTaskQueue.GetInstance().SaveTaskFinish();

                            //更改下达任务标识为可下达
                            sortingTaskIssued = SortingTaskIssued.GetSortingTaskIssued("0");
                            if (sortingTaskIssued.PLCFLAG != 0)
                            {
                                sortingTaskIssued.PLCFLAG = 0;
                                sortingTaskIssued.Save();

                                //播放语音提示
                                SoundPlayer player = new SoundPlayer();
                                player.SoundLocation = Application.StartupPath + "\\Sound\\订单完成.wav";
                                player.Load();
                                player.Play();
                            }
                            
                        }
                    }

                    //发送当前分拣完成信号给PLC,让小车移动
                    //判断是否可以更改PLC的当前分拣完成信号
                    //判断PLC中订单序号等于系统中队尾的序号
                    //if (operateOpcAndSoft.GetCubeRun() == FJMainForm.Instance.CSortingMain.c_Cubes.Last().labindexno)
                    //{
                    //operateOpcAndSoft.SetCubeRun();
                    //}

                    if (OnTaskMoved != null)
                    {
                        OnTaskMoved.Invoke(null, new EventArgs());
                    }

                    //清除所有电子标签内容
                    ATOPTagSdk.Tags = null;
                }

                Thread.Sleep(500);
            }
        }



        public void LoadOrder()
        {
            if (chkisall.Checked)
            {
                dgviewnonedetail.DataSource = null;
                dgvIssueddetail.DataSource = null;
                dgviewfindetail.DataSource = null;

                dgviewnone.DataSource = m_nonSortingLineTaskList = SortingLineTaskList.GetNonSortingLineTaskList(true);

                dgviewfin.DataSource =
                    m_finSortingLineTaskList =
                        SortingLineTaskList.GetFinSortingLineTaskList(new QueryCondition("2", true, AppUtil._SortingLineId,"desc"));

                dgvIssued.DataSource =
                    m_issuedSortingLineTaskList =
                        SortingLineTaskList.GetFinSortingLineTaskList(new QueryCondition("1", true,AppUtil._SortingLineId,"desc"));
            }
            else
            {
                dgviewnonedetail.DataSource = null;
                dgvIssueddetail.DataSource = null;
                dgviewfindetail.DataSource = null;

                dgviewnone.DataSource = m_nonSortingLineTaskList = SortingLineTaskList.GetNonSortingLineTaskList(false);

                dgviewfin.DataSource =
                    m_finSortingLineTaskList =
                        SortingLineTaskList.GetFinSortingLineTaskList(new QueryCondition("2", false, AppUtil._SortingLineId,"desc"));

                dgvIssued.DataSource =
                    m_issuedSortingLineTaskList =
                        SortingLineTaskList.GetFinSortingLineTaskList(new QueryCondition("1", false, AppUtil._SortingLineId,"desc"));

            }
            footSumLabel1.Sumdata();
            footSumLabel2.Sumdata();
            footSumLabel3.Sumdata();
            
        }

        private void SetSortingStatus(int status)
        {
            string indexcolname = "";
            string custcolname = "";
            foreach (DataGridViewColumn column in dataGridViewXs[superTabControl1.SelectedTab.Name].Columns)
            {
                if (column.DataPropertyName.ToUpper() == "INDEXNO")
                {
                    indexcolname = column.Name;
                }
                if (column.DataPropertyName.ToUpper() == "CUSTCODE")
                {
                    custcolname = column.Name;
                }
            }


            foreach (DataGridViewRow selectedRow in dataGridViewXs[superTabControl1.SelectedTab.Name].SelectedRows)
            {
                //改变任务状态
                string indexcolvalue = selectedRow.Cells[indexcolname].Value.ToString();
                string custvalue = selectedRow.Cells[custcolname].Value.ToString();
                SortingLineTask sortingLineTask = SortingLineTask.GetSortingLineByIndex(indexcolvalue);
                sortingLineTask.Status = status;
                if (status == 2)
                {
                    sortingLineTask.PLCADDRESS = 9;    
                }
                if (status == 0)
                {
                    sortingLineTask.PLCADDRESS = 0; 
                    SortingLineTaskDetail.SaveStatus(sortingLineTask.ID,"",0);
                }
                
                sortingLineTask.SaveSortingTaskProcess(sortingLineTask.ID);



                //改变烟包状态
                //List<CigBoxInfo> cigBoxInfoList = CigBoxInfoList.GetBoxInfoByCustiomNo(custvalue, indexcolvalue,
                //    SortingLine.GetNonSortingLineCode());
                //foreach (CigBoxInfo cigBoxInfo in cigBoxInfoList)
                //{
                //    if (status != 2)
                //    {
                //        CigBoxInfo.SaveProcess(cigBoxInfo.ID, 0);
                //    }
                //    else
                //    {
                //        CigBoxInfo.SaveProcess(cigBoxInfo.ID, status);
                //    }
                //}
            }
        }


        private void SetSortingLock(int islock)
        {
            string indexcolname = "";
            string custcolname = "";
            foreach (DataGridViewColumn column in dataGridViewXs[superTabControl1.SelectedTab.Name].Columns)
            {
                if (column.DataPropertyName.ToUpper() == "INDEXNO")
                {
                    indexcolname = column.Name;
                }
                if (column.DataPropertyName.ToUpper() == "CUSTCODE")
                {
                    custcolname = column.Name;
                }
            }


            foreach (DataGridViewRow selectedRow in dataGridViewXs[superTabControl1.SelectedTab.Name].SelectedRows)
            {
                //改变任务状态
                string indexcolvalue = selectedRow.Cells[indexcolname].Value.ToString();
                string custvalue = selectedRow.Cells[custcolname].Value.ToString();
                SortingLineTask sortingLineTask = SortingLineTask.GetSortingLineByIndex(indexcolvalue);
                sortingLineTask.ISLOCK = islock;
                sortingLineTask.SaveSortingTaskProcess(sortingLineTask.ID);
            }
            LoadOrder();
        }

        private bool IsVerifyPass()
        {
            SortingLineTask.IsCurrentOrder();

            SortingLineTask.IsIndexRepetition();

            return true;
        }


        public void ReLoad()
        {
            if (IsVerifyPass())
            {
                LoadOrder();
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "数据库读取";
                monitorLog.LOGINFO = "订单数据读取成功!";
                monitorLog.LOGLOCATION = "数据库";
                monitorLog.LOGTYPE = 1;
                monitorLog.Save();
            }
        }


        /// <summary>
        /// 保存混仓卷烟在皮带上的数量
        /// </summary>
        private static void SaveDynamicBoxPutNum()
        {
            try
            {
                OperateOpcAndSoft operateOpcAndSoft = new OperateOpcAndSoft();
                Dictionary<int, int> putoutnums = operateOpcAndSoft.GetDynamicBoxPutNum();

                SortingTaskArrive sortingtaskarrive = SortingTaskArrive.GetSortingTaskArrive("0");

                if (Convert.ToInt32(sortingtaskarrive.Value) != putoutnums[73])
                {
                    sortingtaskarrive.ADDRESSCODE = "73";
                    sortingtaskarrive.Value = putoutnums[73].ToString();
                    sortingtaskarrive.Save();
                }
            }
            catch
            {
            }
        }


        private static void SaveUPDownPutIndexno()
        {
            try
            {
                try
                {
                    OperateOpcAndSoft operateOpcAndSoft = new OperateOpcAndSoft();
                    int upindexno = operateOpcAndSoft.GetUpPutIndexno();

                    PutInfo.SaveUpPutIndex(upindexno);

                    int downindexno = operateOpcAndSoft.GetDownPutIndexno();
                    PutInfo.SaveDownPutIndex(downindexno);
                }
                catch
                {
                }
            }
            catch
            {
            }
        }




        int puttaskindexno = 0;
        /// <summary>
        /// 获取分拣机正在出烟的任务
        /// </summary>
        private void GetPutTask()
        {
            int taskno = 0;
            try
            {
                OperateOpcAndSoft operateOpcAndSoft = new OperateOpcAndSoft();
                taskno = operateOpcAndSoft.GetSortingTaskNo();

                foreach (DataGridViewRow dataGridViewRow in dgvIssued.Rows)
                {
                    if (dataGridViewRow.DefaultCellStyle.BackColor == Color.GreenYellow)
                    {
                        dataGridViewRow.DefaultCellStyle.BackColor = Color.White;
                        dataGridViewRow.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    if ((Convert.ToInt32(dataGridViewRow.Cells["dataGridViewTextBoxColumn47"].Value) == taskno))
                    {
                        dataGridViewRow.DefaultCellStyle.BackColor = Color.GreenYellow;
                        dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }               
                
            }
            catch
            {
            }

            //if (puttaskindexno != taskno  && taskno != 0)
            //{
            //    puttaskindexno = taskno;

            //    Thread thread = new Thread(SetOrderNixielight);
            //    thread.Start();
            //}
        
        }

        

        #endregion


        #region 打印操作

        private void 打印标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否打印选择的标签？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Thread thread1 = new Thread(new ParameterizedThreadStart(PirintSet));
                thread1.Start(0);
            }
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(PirintSet));
            thread1.Start(1);
        }

        private void PirintSet(object type)
        {
            try
            {
                string indexcolname = "";
                string custcolname = "";
                foreach (DataGridViewColumn column in dataGridViewXs[superTabControl1.SelectedTab.Name].Columns)
                {
                    if (column.DataPropertyName.ToUpper() == "INDEXNO")
                    {
                        indexcolname = column.Name;
                    }
                    if (column.DataPropertyName.ToUpper() == "CUSTCODE")
                    {
                        custcolname = column.Name;
                    }
                }

                IEnumerable<DataGridViewRow> rows =
                    dataGridViewXs[superTabControl1.SelectedTab.Name].SelectedRows.Cast<DataGridViewRow>();
                DataGridViewRow[] Rows = rows.ToArray();

                if (superTabControl1.SelectedTab.Name == "superTabItem1")
                {
                    Array.Reverse(Rows); //对颠倒的行再次颠倒
                }

                List<string> indexnos = new List<string>();

                foreach (DataGridViewRow selectedRow in Rows)
                {

                    indexnos.Add(selectedRow.Cells[indexcolname].Value.ToString());
                    
                }

                List<PrintInfo> psPrintInfos = new List<PrintInfo>();
                SendBoxList.GetSendBoxList(indexnos, ref psPrintInfos);

                foreach (PrintInfo PSInfo in psPrintInfos)
                {
                    printset.SetupThePrinting(MyPrintDocument, new SYSPrintsettings(), PSInfo);

                    if (Convert.ToInt32(type) == 1)
                    {
                        printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
                        this.printPreviewDialog1.ShowDialog();
                    }
                    else
                    {
                        MyPrintDocument.Print();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                bool hasNextPage = printset.getLPTPrinter().DrawDocument(e.Graphics);
                if (hasNextPage)
                {
                    e.HasMorePages = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            chkisall.Checked = true;
            dataGridViewXs[superTabControl1.SelectedTab.Name].SelectAll();
        }

        private void comboBoxItem1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxItem1.SelectedIndex == 0)
            //{
            //    if (m_nonSortingLineTaskList != null)
            //    {
            //        dgviewnone.DataSource = m_nonSortingLineTaskList;
            //    }
            //}
            //if (comboBoxItem1.SelectedIndex == 1)
            //{
            //    SortingLineTaskList sortingLinetasklist;
            //    for (int i = 0; i < m_nonSortingLineTaskList.Count; i++)
            //    {

            //    }
                
            //}
            //if (comboBoxItem1.SelectedIndex == 2)
            //{                
            //    dgviewnone.DataSource = m_nonSortingLineTaskList.Where(o => o.OUTPORT == "2");
            //}
        }

        private void chkisall_Click(object sender, EventArgs e)
        {

        }

        private void dgviewnone_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dataGridViewRow in dgviewnone.Rows)
            {
                if (dataGridViewRow.DefaultCellStyle.BackColor == Color.Gray)
                {
                    dataGridViewRow.DefaultCellStyle.BackColor = Color.White;
                    dataGridViewRow.DefaultCellStyle.ForeColor = Color.Black;
                }
                if ((Convert.ToInt32(dataGridViewRow.Cells["ISLOCK"].Value) == 1))
                {
                    dataGridViewRow.DefaultCellStyle.BackColor = Color.Gray;
                    dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void 锁定任务不下达ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taskStatus == TaskStatus.Run)
            {
                MessageBox.Show("请先暂停任务下达！");
            }
            else
            {
                if (MessageBox.Show("是否锁定任务不下达", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SetSortingLock(1);
                }
            }
        }

        private void 解锁任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (taskStatus == TaskStatus.Run)
            {
                MessageBox.Show("请先暂停任务下达！");
            }
            else
            {
                if (MessageBox.Show("是否解锁任务", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SetSortingLock(0);
                }
            }
        }

    }

    #endregion

    public enum TaskStatus
    {
        Stop = 0,
        Run = 1,
        Suspend = 2
    }

    public class UpdateCSortingMainNumEventArgs : EventArgs
    {
        public Dictionary<int, Tag> Tags;

        public UpdateCSortingMainNumEventArgs(Dictionary<int, Tag> tags)
        {
            Tags = tags;
        }
    }

}

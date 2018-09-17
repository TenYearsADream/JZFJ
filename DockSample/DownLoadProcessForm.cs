﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AppUtility;
using BusinessLogic;
using BusinessLogic.Configuration;
using BusinessLogic.Download;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using MonitorMain.CustomContorl;
using BusinessLogic.SortingTask;

namespace MonitorMain
{
    public partial class DownLoadProcessForm :  Office2007Form

    {
        
        private DownloadPrecess _downloadPrecess;
        private bool IsDownload = true;
        private Thread thread;

        

        public DownLoadProcessForm()
        {
            
            InitializeComponent();

            

            //laborderdate.Text = _orderdate;
            //labLineCode.Text = SortingLine.GetSortingLineCode();
        }


        void MonitorLog_OnLogCreate(object sender, DataEvenArgs e)
       {
            try
            {
                this.Invoke(new Action<string>(SetText), e.Createtime.ToString().PadRight(20) + e.Type.PadRight(10) + e.Logname.PadRight(10) + e.Loginfo + Environment.NewLine);
            }
            catch (Exception)
            {

                SetText(e.Createtime.ToString().PadRight(20) + e.Type.PadRight(10) + e.Logname.PadRight(10) + e.Loginfo + Environment.NewLine);
            }
               
           
       }

        private void DownLoadProcessForm_Load(object sender, EventArgs e)
        {
            MonitorLog.OnLogCreate += new EventHandler<DataEvenArgs>(MonitorLog_OnLogCreate);
            DownloadData.OnProcessFinish += new EventHandler<DownloadArgs>(DownloadData_OnProcessFinish);
            DownloadData.OnPrecessUpdate += new EventHandler<DownloadPrecess>(DownloadData_OnPrecessUpdate);
            DownloadData.OnProcessStart += new EventHandler<StepNameEvenArgs>(DownloadData_OnProcessStart);
            DownloadData.OnProcessError += new EventHandler<DownloadErrorArgs>(DownloadData_OnProcessError);
            DownloadData.OnDownLoadFinish += new EventHandler<EventArgs>(DownloadData_OnDownLoadFinish);

            DownloadData.OnTransferFinish +=new EventHandler<DownloadArgs>(DownloadData_OnTransferFinish);

            OutPutList outputList = new OutPutList();
            OutPut output = new OutPut();

            output.Name = "原出口";
            output.Value = "-1";
            outputList.Add(output);

            output = new OutPut();
            output.Name = "A出口";
            output.Value = "1";
            outputList.Add(output);

            output = new OutPut();
            output.Name = "B出口";
            output.Value = "2";
            outputList.Add(output);

            output = new OutPut();
            output.Name = "AB双出口";
            output.Value = "0";
            outputList.Add(output);


            



            coboutport.DataSource = outputList;
            coboutport.DisplayMember = "Name";
            coboutport.ValueMember = "Value";

            
        }

        void DownloadData_OnDownLoadFinish(object sender, EventArgs e)
        {
            btnDownload.Enabled = true;
            btnExport.Enabled = true;
            
            btnOK.Invoke(new Action(BtnEnabled));

            MessageBox.Show("分拣任务下载完成！");
           
        }

        private void LoadSortingLine(TaskInfoList taskInfoList)
        {
            itemPanel1.Items.Clear();
            itemPanel1.BeginUpdate();
            foreach (TaskInfo taskInfo in taskInfoList)
            {
                if (!taskInfo.LineName.Contains("罚没") && taskInfo.LineCode == AppUtil._SortingLineId)
                {
                    CheckBoxItem checkBoxX = new CheckBoxItem();
                    checkBoxX.Text = taskInfo.LineName + "-任务号" + taskInfo.TaskNo;
                    checkBoxX.Name = taskInfo.LineCode + taskInfo.TaskNo;
                    checkBoxX.Tag = taskInfo;
                    checkBoxX.Checked = true;
                    itemPanel1.Items.Add(checkBoxX);
                }
            }
            itemPanel1.EndUpdate(true);
        }

        void DownloadData_OnProcessError(object sender, DownloadErrorArgs e)
        {
            btnDownload.Enabled = true;
            btnExport.Enabled = true;
            MessageBox.Show(e.exception.Message,"下载出错");
        }

        void DownloadData_OnProcessStart(object sender, StepNameEvenArgs e)
        {
            IsDownload = true;
            this.Invoke(new Action(delegate { labstepname.Text = e.Stepname; }));
            this.Invoke(new Action(delegate { labLineName.Text = e.Sortinglinename; }));
        }

        void DownloadData_OnProcessFinish(object sender, DownloadArgs e)
        {
            if (this.InvokeRequired)
            {
                if (e.OrderType == 1)
                {
                    this.Invoke(new Action(FJMainForm.Instance.cSortingTask.ReLoad));
                    this.Invoke(new Action(FJMainForm.Instance.CBox.LoadCigBox));
                    this.Invoke(new Action(FJMainForm.Instance.SetVision));
                    this.Invoke(new Action(FJMainForm.Instance.SetOutPort));
                    this.Invoke(new Action(FJMainForm.Instance.CSortingMain.ReLoad));
                }
                else if (e.OrderType == 2)
                {
                    this.Invoke(new Action(FJMainForm.Instance.cAbnSortingTask.ReLoad));
                    this.Invoke(new Action(FJMainForm.Instance.CAbnBox.LoadCigBox));
                    this.Invoke(new Action(FJMainForm.Instance.SetVision));
                }
            }

            IsDownload = false;

            MonitorLog monitorLog = MonitorLog.NewMonitorLog();
            monitorLog.LOGNAME = "线程完成";
            monitorLog.LOGINFO = e.LineName + "分拣任务下载完成";
            monitorLog.LOGLOCATION = "线程操作";
            monitorLog.LOGTYPE = 1;
            monitorLog.Save();

            
        }

        void DownloadData_OnTransferFinish(object sender, DownloadArgs e)
        {
            IsDownload = false;
            btnDownload.Enabled = true;
            btnExport.Enabled = true;
            MessageBox.Show("打标机数据传送完成！");
        }
        
        void DownloadData_OnPrecessUpdate(object sender, DownloadPrecess e)
        {
            _downloadPrecess = e;
            if (prbMain.InvokeRequired)
            {
                this.Invoke(new Action(UpdateProcess));
            }
        }

        private void UpdateProcess()
        {
            prbMain.Text = (_downloadPrecess.MainIndex + "/" + _downloadPrecess.MainCount).ToString();
            prbDetail.Text = (_downloadPrecess.DetailIndex + "/" + _downloadPrecess.DetailCount).ToString();
            prbMain.Maximum = _downloadPrecess.MainCount;
            prbMain.Value = _downloadPrecess.MainIndex;
            prbDetail.Maximum = _downloadPrecess.DetailCount;
            prbDetail.Value = _downloadPrecess.DetailIndex;
        }

        private void DownLoadProcessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDownload)
            {
                if (MessageBox.Show("是否中断分拣任务下载？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (thread != null)
                    {
                        if (thread.IsAlive)
                        {
                            thread.Abort();
                            thread = null;
                            MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                            monitorLog.LOGNAME = "线程中止";
                            monitorLog.LOGINFO = "分拣任务下载线程中止";
                            monitorLog.LOGLOCATION = "线程操作";
                            monitorLog.LOGTYPE = 2;
                            monitorLog.Save();
                        }
                    }
                }
            }
            DownloadData.OnProcessFinish -= new EventHandler<DownloadArgs>(DownloadData_OnProcessFinish);
            DownloadData.OnPrecessUpdate -= new EventHandler<DownloadPrecess>(DownloadData_OnPrecessUpdate);
            DownloadData.OnProcessStart -= new EventHandler<StepNameEvenArgs>(DownloadData_OnProcessStart);
            DownloadData.OnProcessError -= new EventHandler<DownloadErrorArgs>(DownloadData_OnProcessError);
            MonitorLog.OnLogCreate -= new EventHandler<DataEvenArgs>(MonitorLog_OnLogCreate);
            DownloadData.OnDownLoadFinish -= new EventHandler<EventArgs>(DownloadData_OnDownLoadFinish);
            DownloadData.OnTransferFinish -= new EventHandler<DownloadArgs>(DownloadData_OnTransferFinish);
        }


        private void SetText(string text)
        {
            txtInfo.AppendText(text + Environment.NewLine);  
        }

        private void BtnEnabled()
        {
            btnOK.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (FJMainForm.Instance.cSortingTask.taskStatus != TaskStatus.Stop)
            {
                MessageBox.Show("下达任务未停止无法下载新的任务！");
                return;
            }
            btnDownload.Enabled = false;
            btnExport.Enabled = false;
            thread = new Thread(new ParameterizedThreadStart(DownloadData.Start));
            if (thread != null && IsSelectSortingLine())
            {
                if (SortingLineTaskList.IsSortingFinish())
                {
                    StartDownloads();
                }
                else
                {
                    if (SortingLineTaskList.IsSortingStart())
                    {
                        if (MessageBox.Show("分拣已开始,重新下载新清除数据是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            StartDownloads();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("当前订单还未开始分拣,重新下载新清除数据是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            StartDownloads();
                        }
                    }
                }


            }
            else
            {
                MessageBox.Show("任务条件未选择");
                btnDownload.Enabled = true;
                btnExport.Enabled = true;
            }
        }


        private void StartDownloads()
        {
            
            List<DownloadArgs> downloadArgslist = new List<DownloadArgs>();
            foreach (CheckBoxItem checkBoxX in itemPanel1.Items)
            {
                if (checkBoxX.Checked)
                {
                    TaskInfo taskInfo  = checkBoxX.Tag as TaskInfo;
                    DownloadArgs downloadArgs = new DownloadArgs();
                    downloadArgs.OrderDate = dateTimeInput1.Value.Date.ToString("yyyy-MM-dd");
                    downloadArgs.LineCode = taskInfo.LineCode;
                    downloadArgs.LineName = taskInfo.LineName;
                    downloadArgs.Batch = taskInfo.TaskNo;
                    downloadArgs.OrderType = Convert.ToInt16(taskInfo.LineType);
                    downloadArgs.OutPut = coboutport.SelectedValue.ToString();
                    downloadArgslist.Add(downloadArgs);
                }
            }
            thread.Start(downloadArgslist);
        }



        private bool IsSelectSortingLine()
        {
            foreach (CheckBoxItem checkBoxX in itemPanel1.Items)
            {
                if (checkBoxX.Checked)
                {
                    return true;
                }   
            }
            return false;
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
           
            TaskInfoList taskInfoList = TaskInfoList.GetServerTaskBatchs(dateTimeInput1.Value.Date.ToString("yyyy-MM-dd"),false);

            try
            {
                LoadSortingLine(taskInfoList);
            }



            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                    MessageBox.Show("无法连接到分拣信息服务器数据库");
                else
                    throw;
            }
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnDownload.Enabled = false;
            btnExport.Enabled = false;
            thread = new Thread(new ParameterizedThreadStart(DownloadData.TransferOrderBox));

            if (IsSelectSortingLine())
            {
                DownloadArgs downloadArgs = new DownloadArgs();
                downloadArgs.OrderDate = dateTimeInput1.Value.Date.ToString("yyyy-MM-dd");
                //downloadArgs.Batch = cobbatch.SelectedValue.ToString();

                //DownloadData.TransferOrderBox(downloadArgs);
                thread.Start(downloadArgs);
            }
            else
            {
                MessageBox.Show("任务条件未选择");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            coboutport.Enabled = chkoutport.Checked;
        }

    }

    public class OutPutList:List<OutPut>
    {

    }

    public class OutPut
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    
}

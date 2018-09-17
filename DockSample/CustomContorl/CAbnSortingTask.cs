using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Box;
using BusinessLogic.Common;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar.Controls;

using Timer = System.Windows.Forms.Timer;

namespace MonitorMain.CustomContorl
{
    public sealed partial class CAbnSortingTask : UserControl
    {
        private AbnSortingLineTaskList m_nonSortingLineTaskList;
        private AbnSortingLineTaskList m_finSortingLineTaskList;
        private AbnSortingLineTaskDetails m_nonSortingLineTaskDetails;
        private AbnSortingLineTaskDetails m_finSortingLineTaskDetails;
        //private SortingTaskIssuedList m_SortingTaskIssuedList;
        //private SortingTaskIssuedDetails m_SortingTaskIssuedDetails;
        //private SortingTaskArrives m_SortingTaskArrives;
        private MonitorLog monitorLog;
        //public TaskStatus taskStatus = new TaskStatus();
        

        Thread thread;
        private Timer timer;
        private bool threadstop = true;
        private delegate void d_LoadGridData(DataGridViewX da);
        public event EventHandler<EventArgs> OnTaskStatusChanged;
        private Dictionary<string, DataGridViewX> dataGridViewXs;


        public CAbnSortingTask()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Dock = DockStyle.Fill;
            dataGridViewXs = new Dictionary<string, DataGridViewX>();
            dataGridViewXs.Add("superTabItem1", dgviewnone);
            dataGridViewXs.Add("superTabItem2", dgviewfin);
        }


        public void LoadOrder()
        {
            dgviewnone.DataSource = m_nonSortingLineTaskList = AbnSortingLineTaskList.GetNonAbnSortingLineTaskList();
            dgviewfin.DataSource = m_finSortingLineTaskList = AbnSortingLineTaskList.GetFinAbnSortingLineTaskList("2");
        }

        //void LoadGridData(DataGridViewX dataGrid)
        //{
        //    if (!dataGrid.InvokeRequired)
        //    {
        //        dataGrid.DataSource = null;
        //        dataGrid.DataSource = m_SortingTaskIssuedList;
        //    }
        //    else
        //    {
        //        d_LoadGridData de = LoadGridData;
        //        this.Invoke(de, dataGrid);
        //    }
        //}

        //public void LoadTask()
        //{
        //    //this.SuspendLayout();
        //    m_SortingTaskIssuedList = SortingTaskIssuedList.GetSortingTaskIssuedList();
        //    LoadGridData(dataGridViewX2);
        //    //this.ResumeLayout(false);
        //}

        


       

        private void CSortingTask_Load(object sender, EventArgs e)
        {
            DataGridViewTranslation.LoadMainColHeader(dgviewnone);
            
            DataGridViewTranslation.LoadMainColHeader(dgviewfin);

            DataGridViewTranslation.LoadDetailColHeader(dgviewnonedetail);
            
            DataGridViewTranslation.LoadDetailColHeader(dgviewfindetail);

            if (IsVerifyPass())
            {
                LoadOrder();
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "数据库读取";
                monitorLog.LOGINFO = "异型烟订单数据读取成功!";
                monitorLog.LOGLOCATION = "数据库";
                monitorLog.LOGTYPE = 1;
                monitorLog.Save();
                superTabControl1.SelectedTabIndex = 0;
            }
        }

        private bool IsVerifyPass()
        {
            AbnSortingLineTask.IsCurrentOrder();

            if (AbnSortingLineTask.IsIndexRepetition())
            {
                return false;
            }
            return true;
        }


        public void ReLoad()
        {
            if (IsVerifyPass())
            {
                LoadOrder();
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "数据库读取";
                monitorLog.LOGINFO = "异型烟订单数据读取成功!";
                monitorLog.LOGLOCATION = "数据库";
                monitorLog.LOGTYPE = 1;
                monitorLog.Save();
            }
        }

        


        private void dgviewnone_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgviewnonedetail.DataSource = null;
                m_nonSortingLineTaskDetails =
                    AbnSortingLineTaskDetails.GetGetSortingLineTaskDetailsByTaskId(
                        dgviewnone.SelectedRows[0].Cells[0].Value.ToString());
                dgviewnonedetail.DataSource = m_nonSortingLineTaskDetails;

                labSortingtaskno.Tag = dgviewnone.SelectedRows[0].Cells["iDDataGridViewTextBoxColumn"].Value.ToString(); 
                labSortingtaskno.Text = dgviewnone.SelectedRows[0].Cells["sORTINGTASKNODataGridViewTextBoxColumn"].Value.ToString();
                laborderdate.Text = dgviewnone.SelectedRows[0].Cells["oRDERDATEDataGridViewTextBoxColumn"].Value.ToString();
                labpicklinename.Text = dgviewnone.SelectedRows[0].Cells["pICKLINENAMEDataGridViewTextBoxColumn"].Value.ToString();
                labcustcode.Text = dgviewnone.SelectedRows[0].Cells["cUSTCODEDataGridViewTextBoxColumn"].Value.ToString();
                labcustname.Text = dgviewnone.SelectedRows[0].Cells["cUSTNAMEDataGridViewTextBoxColumn"].Value.ToString();
                labindexno.Text = dgviewnone.SelectedRows[0].Cells["iNDEXNODataGridViewTextBoxColumn"].Value.ToString();
                
            }
            catch (Exception)
            {
                
                
            }
           
        }




        //private void dataGridViewX2_SelectionChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        m_SortingTaskIssuedDetails = m_SortingTaskIssuedList.GetSortingTaskIssuedById(dgviewnone.SelectedRows[0].Cells[0].Value.ToString()).SortingTaskIssuedDetails;
        //        dataGridViewX2.DataSource = m_nonSortingLineTaskDetails;
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}

        //private void dgvArraiv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 4)
        //    {
        //        m_SortingTaskArrives[e.RowIndex].Value = "1";
        //        m_SortingTaskArrives.Save();
        //        monitorLog = MonitorLog.NewMonitorLog();
        //        monitorLog.LOGNAME = "PLC任务到达";
        //        monitorLog.LOGINFO = m_SortingTaskArrives[e.RowIndex].ADDRESSCODE + "号出口任务到达!";
        //        monitorLog.LOGLOCATION = "PLC";
        //        monitorLog.LOGTYPE = 0;
        //        monitorLog.Save();
        //    }
        //    if (e.ColumnIndex == 5)
        //    {
        //        if (m_SortingTaskArrives[e.RowIndex].Value == "1")
        //        {
        //            string address =
        //                dgvArraiv.Rows[e.RowIndex].Cells["aDDRESSCODEDataGridViewTextBoxColumn2"].Value.ToString();
        //            string taskno = "";

        //            m_SortingTaskArrives[e.RowIndex].Value = "0";
        //            m_SortingTaskArrives.Save();

        //            m_SortingTaskIssuedList = SortingTaskIssuedList.GetSortingTaskIssuedList();
        //            foreach (SortingTaskIssued sortingTaskIssued in m_SortingTaskIssuedList)
        //            {
        //                if (sortingTaskIssued.SLOCATION == address)
        //                {
        //                    taskno = sortingTaskIssued.PLCTASKNO;
        //                    sortingTaskIssued.Reset();
        //                    sortingTaskIssued.SortingTaskIssuedDetails.RemoveAll();
        //                    sortingTaskIssued.Save();
        //                }
        //            }

        //            foreach (SortingLineTask sortingLineTask in m_nonSortingLineTaskList)
        //            {
        //                if (sortingLineTask.INDEXNO == Convert.ToInt32(taskno))
        //                {
        //                    sortingLineTask.Status = 1;
        //                    sortingLineTask.SaveSortingTaskProcess(taskno);
        //                }
        //            }
        //            monitorLog = MonitorLog.NewMonitorLog();
        //            monitorLog.LOGNAME = "PLC任务完成";
        //            monitorLog.LOGINFO = m_SortingTaskArrives[e.RowIndex].ADDRESSCODE + "号出口任务完成!";
        //            monitorLog.LOGLOCATION = "PLC";
        //            monitorLog.LOGTYPE = 0;
        //            monitorLog.Save();

        //            LoadOrder();
        //            LoadTask();
        //        }
        //        else
        //        {
        //            MessageBox.Show("任务未到达出口，无法结束");
        //        }
        //    }


        //}

        private void dgviewfin_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgviewfindetail.DataSource = null;
                m_finSortingLineTaskDetails = AbnSortingLineTaskDetails.GetGetSortingLineTaskDetailsByTaskId(
                        dgviewfin.SelectedRows[0].Cells[0].Value.ToString());
                dgviewfindetail.DataSource = m_finSortingLineTaskDetails;
            }
            catch (Exception)
            {


            }
        }

        private void dgviewnone_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgviewnone.Columns[e.ColumnIndex].Name == "btnSorting")
            {
                foreach (AbnSortingLineTask abnsortingLineTask in m_nonSortingLineTaskList)
                {
                    if (abnsortingLineTask.ID == dgviewnone.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value)
                    {
                        abnsortingLineTask.SaveAbnSortingTaskProcess(2);
                    }
                }
                LoadOrder();
            }
        }

        private void dgviewnone_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Color color = dgviewnone.RowHeadersDefaultCellStyle.ForeColor;
            if (dgviewnone.Rows[e.RowIndex].Selected)
                color = dgviewnone.RowHeadersDefaultCellStyle.SelectionForeColor;
            else
                color = dgviewnone.RowHeadersDefaultCellStyle.ForeColor;

            using (SolidBrush b = new SolidBrush(color))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 6);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            
            foreach (AbnSortingLineTask abnsortingLineTask in m_nonSortingLineTaskList)
            {
                if (abnsortingLineTask.ID == labSortingtaskno.Tag.ToString())
                {
                    abnsortingLineTask.SaveAbnSortingTaskProcess(2);

                    //成功后保存发送的烟包信息
                    List<CigBoxInfo> cigBoxInfoList = CigBoxInfoList.GetBoxInfoByCustiomNo(abnsortingLineTask.CUSTCODE, abnsortingLineTask.INDEXNO.ToString(), SortingLine.GetAbNonSortingLineCode());
                    foreach (CigBoxInfo cigBoxInfo in cigBoxInfoList)
                    {
                        CigBoxInfo.SaveProcess(cigBoxInfo.ID, 2);
                    }
                }
            }
            LoadOrder();
            FJMainForm.Instance.CAbnBox.LoadCigBox();
        }

        private void 设置分拣未完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSortingStatus(0);
            LoadOrder();
            FJMainForm.Instance.CAbnBox.LoadCigBox();
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
                AbnSortingLineTask sortingLineTask = AbnSortingLineTask.GetAbnSortingLineByIndex(indexcolvalue);
                sortingLineTask.Status = status;
                sortingLineTask.SaveAbnSortingTaskProcess(status);



                //改变烟包状态
                List<CigBoxInfo> cigBoxInfoList = CigBoxInfoList.GetBoxInfoByCustiomNo(custvalue, indexcolvalue, SortingLine.GetAbNonSortingLineCode());
                foreach (CigBoxInfo cigBoxInfo in cigBoxInfoList)
                {
                    if (status != 2)
                    {
                        CigBoxInfo.SaveProcess(cigBoxInfo.ID, 0);
                    }
                    else
                    {
                        CigBoxInfo.SaveProcess(cigBoxInfo.ID, status);
                    }
                }
            }
        }
    }

    

}

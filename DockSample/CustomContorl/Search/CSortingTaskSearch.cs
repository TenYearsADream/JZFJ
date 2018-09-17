using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Download;
using BusinessLogic.Search;
using BusinessLogic.SortingTask;
using System.Threading;
using BusinessLogic.Box;
using AppUtility;
using BusinessLogic.DisplayBoards;
using PosPrint;

namespace MonitorMain.CustomContorl.Search
{
    public partial class CSortingTaskSearch : UserControl
    {

        private SortingLineTaskList m_nonSortingLineTaskList;
        private SortingLineTaskDetailsHistory m_nonSortingLineTaskDetails;


        public CSortingTaskSearch()
        {
            InitializeComponent();
            dateTimeInput1.Value = DateTime.Now;

            DataGridViewTranslation.LoadMainColHeader(dgviewnone);

            

            DataGridViewTranslation.LoadDetailColHeader(dgviewnonedetail);

            footSumLabel1.Init(dgviewnonedetail, new Dictionary<string, int>() { { "qTYDataGridViewTextBoxColumn", 0 } });

            OutPutList outputList = new OutPutList();
            OutPut output = new OutPut();

            output = new OutPut();
            output.Name = "所有出口";
            output.Value = "0";
            outputList.Add(output);

            output = new OutPut();
            output.Name = "A出口";
            output.Value = "1";
            outputList.Add(output);

            output = new OutPut();
            output.Name = "B出口";
            output.Value = "2";
            outputList.Add(output);

            comboBoxEx1.DataSource = outputList;
            comboBoxEx1.DisplayMember = "Name";
            comboBoxEx1.ValueMember = "Value";
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            cobbatch.SelectedText = "";
            cobbatch.SelectedValue = "";
            cobbatch.Text = "";
            cobbatch.DataSource = TaskBatchList.GetTaskBatchs(dateTimeInput1.Value.Date.ToString("yyyy-MM-dd"),true);
            cobSortingLine.DataSource = SortingLineList.GetSortingLines(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchArgs searchArgs = new SearchArgs();
            searchArgs.OrderDate = dateTimeInput1.Value.ToString("yyyy-MM-dd");
            searchArgs.Batch = cobbatch.SelectedValue as string;
            searchArgs.LineCode = cobSortingLine.SelectedValue as string;
            searchArgs.Customer = txtCustomer.Text.Trim();
            searchArgs.OutPort = comboBoxEx1.SelectedValue.ToString();
            m_nonSortingLineTaskList = SortingLineTaskList.GetSortingLineTaskHistoryList(searchArgs);
            dgviewnone.DataSource = m_nonSortingLineTaskList;
            footSumLabel1.Sumdata();
        }

        private void dgviewnone_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgviewnonedetail.DataSource = null;
                m_nonSortingLineTaskDetails =
                    SortingLineTaskDetailsHistory.GetSortingLineTaskDetailsHistoryByTaskId(
                        dgviewnone.SelectedRows[0].Cells[0].Value.ToString());
                dgviewnonedetail.DataSource = m_nonSortingLineTaskDetails;
                footSumLabel1.Sumdata();
            }
            catch (Exception)
            {


            }
        }

       

        private void dgviewnonedetail_Scroll(object sender, ScrollEventArgs e)
        {

            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel1.vscrollvalue = e.NewValue;
            }
            footSumLabel1.Invalidate();
        }

        private void dgviewnone_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void CSortingTaskSearch_Load(object sender, EventArgs e)
        {
            customButton1.Pulse(10);
        }

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


        private LPTPrintSetup printset = new LPTPrintSetup(); //打印类
        private void PirintSet(object type)
        {
            try
            {
                string indexcolname = "";
                string custcolname = "";
                foreach (DataGridViewColumn column in dgviewnone.Columns)
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
                        dgviewnone.SelectedRows.Cast<DataGridViewRow>();
                DataGridViewRow[] Rows = rows.ToArray();
                Array.Reverse(Rows); //对颠倒的行再次颠倒
                

                foreach (DataGridViewRow selectedRow in Rows)
                {

                    string indexcolvalue = selectedRow.Cells[indexcolname].Value.ToString();
                    string custvalue = selectedRow.Cells[custcolname].Value.ToString();
                    SortingLineTask sortingLineTask = SortingLineTask.GetSortingLineByIndex(indexcolvalue);

                    //获取常规烟包
                    List<CigBoxInfo> cigBoxInfoList = CigBoxInfoList.GetBoxInfoByCustiomNo(sortingLineTask.CUSTCODE,
                        sortingLineTask.INDEXNO.ToString(), AppUtil._SortingLineId);

                    //获取异型烟包
                    int abnoboxcount = CigBoxInfoList.GetAbnoCigBoxNum(sortingLineTask.ORDERDATE,
                        sortingLineTask.SORTINGTASKNO.ToString(), AppUtil._AbnoSortingLineId, sortingLineTask.CUSTCODE);


                    OutPort outPort = new OutPort(Convert.ToInt32(indexcolvalue));
                    outPort.GetCustSeq();

                    foreach (CigBoxInfo cigBoxInfo in cigBoxInfoList)
                    {
                        BusinessLogic.Print.PrintInfo PSInfo = new BusinessLogic.Print.PrintInfo();
                        PSInfo.CustomerName = sortingLineTask.ShortName;
                        PSInfo.CustomerCode = sortingLineTask.CUSTCODE;
                        PSInfo.IndexNo = sortingLineTask.INDEXNO.ToString();
                        PSInfo.SortingDate = "(" + sortingLineTask.ORDERDATE + ")";
                        PSInfo.BoxNo = cigBoxInfo.BOXSEQ.ToString() + "/";
                        PSInfo.BoxCount = cigBoxInfo.BOXCOUNT.ToString();
                        PSInfo.CurrentNum = cigBoxInfo.BOXQTY.ToString() + "/" +
                                            sortingLineTask.SortingLineTaskDetails.GetTotQty().ToString();
                        //PSInfo.TaskNumber = sortingLineTask.SortingLineTaskDetails.GetTotQty().ToString();
                        PSInfo.DelivyLine = sortingLineTask.LINENAME;
                        PSInfo.CustomerSqe = "(" + outPort["COUNTLINE"] + "/" + outPort["MAXCOUNTLINE"] + ")户";
                        //PSInfo.CustomerTotSeq = outPort["MAXCOUNTLINE"];
                        PSInfo.AbnoBoxCount = "异" + abnoboxcount;
                        PSInfo.Address = cigBoxInfo.Address;
                        PSInfo.BoxIndex = CigBoxInfoList.GetBoxIndex(PSInfo.IndexNo, cigBoxInfo.BOXSEQ.ToString(), AppUtil._SortingLineId);
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

        
    }
}

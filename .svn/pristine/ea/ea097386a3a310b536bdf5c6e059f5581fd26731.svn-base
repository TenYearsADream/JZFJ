using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Box;
using BusinessLogic.Download;
using BusinessLogic.Search;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.ScrollBar;
//using PosPrint;

namespace MonitorMain.CustomContorl.Search
{
    /// <summary>
    /// 卷烟烟包查询
    /// </summary>
    public partial class CBoxSearch : UserControl
    {

        private string orderdate;
        private string taskno = null;
        private string picklinecode = null;
        private string customername = null;
        //private LPTPrintSetup printset = new LPTPrintSetup();  //打印类

        public CBoxSearch()
        {
            InitializeComponent();
            dateTimeInput1.Value = DateTime.Now;
            DataGridViewTranslation.LoadMainColHeader(dgvCigBox);
            footSumLabel1.Init(dgvCigBox, new Dictionary<string, int>() { { "bOXQTYDataGridViewTextBoxColumn", 0 } });
        }

        

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            cobbatch.SelectedText = "";
            cobbatch.SelectedValue = "";
            cobbatch.Text = "";
            cobbatch.DataSource = TaskBatchList.GetTaskBatchs(dateTimeInput1.Value.Date.ToString("yyyy-MM-dd"), true);
            cobSortingLine.DataSource =  SortingLineList.GetSortingLines(true);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            orderdate = dateTimeInput1.Value.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(cobbatch.SelectedText))
            {
                taskno = cobbatch.SelectedText;
            }
            else
            {
                taskno = null;
            }
            if (!string.IsNullOrEmpty(cobSortingLine.SelectedValue as string))
            {
                picklinecode = cobSortingLine.SelectedValue as string;
            }
            else
            {
                picklinecode = null;
            }
            if (!string.IsNullOrEmpty(txtCustomer.Text.Trim()))
            {
                customername = txtCustomer.Text.Trim();
            }
            else
            {
                customername = null;
            }
            dgvCigBox.DataSource = new SortableBindingList<CigBoxInfo>(CigBoxInfoList.GetCigBoxList(orderdate,taskno,picklinecode,customername));
            footSumLabel1.Sumdata();
        }

        private void dgvCigBox_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel1.vscrollvalue = e.NewValue;
            }
            footSumLabel1.Invalidate();
        }

        private void CBoxSearch_Load(object sender, EventArgs e)
        {
            customButton1.Pulse(10);
        }

        private void 重打标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    PrintInfo printinfo = new PrintInfo();
            //    printinfo.CustomerName = "";
            //    printinfo.TaskNo = "74";
            //    printinfo.TaskNumber = "22";
            //    printinfo.BoxNo = "1-1";
            //    printinfo.DelivyLine = "";
            //    printinfo.SortingDate = "2015-01-12";

            //    if (printset.SetupThePrinting(MyPrintDocument, new SYSPrintsettings(), printinfo, ""))
            //            MyPrintDocument.Print();
               
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //try
            //{
            //    bool hasNextPage = printset.getLPTPrinter().DrawDocument(e.Graphics);
            //    if (hasNextPage)
            //    {
            //        e.HasMorePages = true;
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        
        
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Download;
using BusinessLogic.INTASKS;
using BusinessLogic.Search;

namespace MonitorMain.CustomContorl.Search
{

    public partial class CInSearch : UserControl

    {
        private string orderdate;
        private string taskno = null;
        private string cigcode = null;
        private string cigname = null;
        private string linecode = null;
        private string sublinecode = null;

        public CInSearch()
        {
            InitializeComponent();
            dateTimeInput1.Value = DateTime.Now;
            DataGridViewTranslation.LoadMainColHeader(dgviewnone);
            footSumLabel1.Init(dgviewnone, new Dictionary<string, int>() { { "iNQTYDataGridViewTextBoxColumn", 0 } });
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            orderdate = dateTimeInput1.Value.ToString("yyyy-MM-dd");
            if (cobbatch.SelectedValue != null)
            {
                taskno = cobbatch.SelectedValue.ToString();
            }
            else
            {
                taskno = null;
            }
            if (!string.IsNullOrEmpty(txtCigInfo.Text))
            {
                cigcode = txtCigInfo.Text;
            }
            else
            {
                cigcode = null;
            }
            if (!string.IsNullOrEmpty(txtCigInfo.Text))
            {
                cigname = txtCigInfo.Text;
            }
            else
            {
                cigname = null;
            }

            if (cobSortingLine.SelectedValue != null)
            {
                linecode = cobSortingLine.SelectedValue.ToString();
            }
            else
            {
                linecode = null;
            }

            if (cobSubSortingLine.SelectedValue != null)
            {
                sublinecode = cobSubSortingLine.SelectedValue.ToString();
            }
            else
            {
                sublinecode = null;
            }
            dgviewnone.DataSource = InTaskList.GetSearchInTaskList(orderdate, taskno, cigcode, cigname,linecode,sublinecode);
            footSumLabel1.Sumdata();
        }

        private void CInSearch_Load(object sender, EventArgs e)
        {
            customButton1.Pulse(10);
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            cobbatch.SelectedText = "";
            cobbatch.SelectedValue = "";
            cobbatch.Text = "";
            cobbatch.DataSource = TaskBatchList.GetTaskBatchs(dateTimeInput1.Value.Date.ToString("yyyy-MM-dd"), true);
            cobSortingLine.DataSource = SortingLineList.GetSortingLines(true);
            cobSubSortingLine.DataSource = SubSortingLineList.GetSubSortingLines(true);
        }

        private void dgviewnone_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel1.vscrollvalue = e.NewValue;
            }
            footSumLabel1.Invalidate();
        }
    }
}

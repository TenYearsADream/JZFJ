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

namespace MonitorMain.CustomContorl.Search
{
    public partial class CSortingCigSearch : UserControl
    {
        private string orderdate;
        private string taskno = null;
        private string cigcode = null;
        private string cigname = null;
        public CSortingCigSearch()
        {
            InitializeComponent();
            dateTimeInput1.Value = DateTime.Now;
            DataGridViewTranslation.LoadMainColHeader(dgvSortingCig);
            footSumLabel1.Init(dgvSortingCig, new Dictionary<string, int>() { { "dataGridViewTextBoxColumn5", 0 } });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            orderdate = dateTimeInput1.Value.ToString("yyyy-MM-dd");
            if (cobbatch.SelectedValue !=null )
            {
                taskno = cobbatch.SelectedValue.ToString();
            }
            else
            {
                taskno = null;
            }
            if (!string.IsNullOrEmpty(txtCigCode.Text))
            {
                cigcode = txtCigCode.Text;
            }
            else
            {
                cigcode = null;
            }
            if (!string.IsNullOrEmpty(txtCigName.Text))
            {
                cigname = txtCigName.Text;
            }
            else
            {
                cigname = null;
            }
            dgvSortingCig.DataSource = SortingCigInfoList.GetList(orderdate,taskno,cigcode,cigname);
            footSumLabel1.Sumdata();
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            cobbatch.SelectedText = "";
            cobbatch.SelectedValue = "";
            cobbatch.Text = "";
            cobbatch.DataSource = TaskBatchList.GetTaskBatchs(dateTimeInput1.Value.Date.ToString("yyyy-MM-dd"), true);
        }

        private void dgvSortingCig_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel1.vscrollvalue = e.NewValue;
            }
            footSumLabel1.Invalidate();
        }

        private void CSortingCigSearch_Load(object sender, EventArgs e)
        {
            
        }
    }
}

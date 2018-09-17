using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Download;
using BusinessLogic.SortingProcess;

namespace MonitorMain.CustomContorl
{
    public partial class CSortingEfficiency : UserControl
    {
        public CSortingEfficiency()
        {
            InitializeComponent();
            dateTimeInput1.Value = DateTime.Now;
            DataGridViewTranslation.LoadMainColHeader(dgvSortingEfficiency);
            footSumLabel1.Init(dgvSortingEfficiency,
                               new Dictionary<string, int>()
                                   {
                                       {"qTYPRODCUTTOTDataGridViewTextBoxColumn", 0},
                                       {"qTYPRODUCTDataGridViewTextBoxColumn", 0},
                                   });
        }

        private void CSortingEfficiency_Load(object sender, EventArgs e)
        {
            customButton1.Pulse(10);
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
            string batch = null;
            string linecode = null;
            if (!string.IsNullOrEmpty(cobbatch.SelectedValue as string))
            {
                batch = cobbatch.SelectedValue as string;
            }
            if (!string.IsNullOrEmpty(cobSortingLine.SelectedValue as string))
            {
                linecode = cobSortingLine.SelectedValue as string;
            }
            
            dgvSortingEfficiency.DataSource = SortingProcessList.GetSortingProcessList(dateTimeInput1.Value.ToString("yyyy-MM-dd"),batch,linecode);
            footSumLabel1.Sumdata();
        }

        private void dgvSortingEfficiency_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel1.vscrollvalue = e.NewValue;
            }
            footSumLabel1.Invalidate();
        }

    }
}

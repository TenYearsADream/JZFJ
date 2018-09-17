using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Box;
using BusinessLogic.SortingTask;
using BusinessLogic.Common;

namespace MonitorMain.CustomContorl
{
    public partial class CBox : UserControl
    {
        public CBox()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            footSumLabel1.Init(dgviewnone, new Dictionary<string, int>() { { "bOXQTYDataGridViewTextBoxColumn", 0 } });
            footSumLabel2.Init(dgviewfin, new Dictionary<string, int>() { { "bOXQTYDataGridViewTextBoxColumn1", 0 } });
        }

        private void CBox_Load(object sender, EventArgs e)
        {
            DataGridViewTranslation.LoadMainColHeader(dgviewnone);
            DataGridViewTranslation.LoadMainColHeader(dgviewfin);
            LoadCigBox();
        }

        public void LoadCigBox()
        {
            if (chkisall.Checked)
            {
                CigBoxInfoList cigBoxInfoList = CigBoxInfoList.GetNonCigBoxList(new QueryCondition("0", true, SortingLine.GetNonSortingLineCode(),"desc"));
                dgviewnone.DataSource = cigBoxInfoList;
                dgviewfin.DataSource = CigBoxInfoList.GetFinCigBoxList(new QueryCondition("2", true, SortingLine.GetNonSortingLineCode(),"desc"));
                   
            }
            else
            {
                dgviewnone.DataSource = CigBoxInfoList.GetNonCigBoxList(new QueryCondition("0", false, SortingLine.GetNonSortingLineCode(),"desc"));
                dgviewfin.DataSource = CigBoxInfoList.GetFinCigBoxList(new QueryCondition("2", false, SortingLine.GetNonSortingLineCode(),"desc"));
            }
            footSumLabel1.Sumdata();
            footSumLabel2.Sumdata();
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

        private void chkisall_CheckedChanged(object sender, DevComponents.DotNetBar.CheckBoxChangeEventArgs e)
        {
            LoadCigBox();
        }

        private void dgviewnone_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel1.vscrollvalue = e.NewValue;
            }
            footSumLabel1.Invalidate();
        }

        private void dgviewfin_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                footSumLabel2.vscrollvalue = e.NewValue;
            }
            footSumLabel2.Invalidate();
        }


    }
}

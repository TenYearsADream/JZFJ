﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Box;
using BusinessLogic.Common;
using BusinessLogic.SortingTask;

namespace MonitorMain.CustomContorl
{
    public partial class CAbnBox : UserControl
    {
        public CAbnBox()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
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
                CigBoxInfoList cigBoxInfoList =
                    CigBoxInfoList.GetNonCigBoxList(new QueryCondition("0", true, SortingLine.GetAbNonSortingLineCode(),""));
                dgviewnone.DataSource = cigBoxInfoList;
                dgviewfin.DataSource = CigBoxInfoList.GetFinCigBoxList(new QueryCondition("2", true, SortingLine.GetAbNonSortingLineCode(),""));
                   
            }
            else
            {
                dgviewnone.DataSource = CigBoxInfoList.GetNonCigBoxList(new QueryCondition("0", false, SortingLine.GetAbNonSortingLineCode(),""));
                dgviewfin.DataSource = CigBoxInfoList.GetFinCigBoxList(new QueryCondition("2", false, SortingLine.GetAbNonSortingLineCode(),""));
                
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

        private void chkisall_CheckedChanged(object sender, DevComponents.DotNetBar.CheckBoxChangeEventArgs e)
        {
            LoadCigBox();
        }


    }
}

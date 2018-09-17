using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace MonitorMain.CustomContorl
{
    public partial class DoubleBufferDataGridViewX : DataGridViewX
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        public DoubleBufferDataGridViewX()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            InitializeComponent();
        }

        private void DoubleBufferDataGridViewX_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.RowsDefaultCellStyle = dataGridViewCellStyle2;
            Color color = this.RowHeadersDefaultCellStyle.ForeColor;
            if (this.Rows[e.RowIndex].Selected)
                color = this.RowHeadersDefaultCellStyle.SelectionForeColor;
            else
                color = this.RowHeadersDefaultCellStyle.ForeColor;

            using (SolidBrush b = new SolidBrush(color))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                                      e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 6);
            }
        }
    }
}

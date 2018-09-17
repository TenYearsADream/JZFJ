using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace MonitorMain.CustomContorl
{
    public class FootSumLabel:PanelEx
    {
        public int vscrollvalue;


        private DataGridViewX _GridViewX;
        private Dictionary<string,int>_columnames ;
        private List<string> _collist;

        public FootSumLabel()
        {
            InitializeComponent();
        }


        public void Init(DataGridViewX dgv,Dictionary<string,int> columnames)
        {
            _GridViewX = dgv;
            _columnames = columnames;
            _collist = new List<string>();
            foreach (KeyValuePair<string, int> keyValuePair in columnames)
            {
                _collist.Add(keyValuePair.Key);
            }
            Invalidate();
        }

       
        //合计数值函数
        public void Sumdata()
        {
            foreach (string colname in _collist)
            {
                _columnames[colname] = 0;
            }
            DataGridViewRowCollection rows = _GridViewX.Rows;

            foreach (DataGridViewRow row in rows)
            {
                foreach (string colname in _collist)
                {
                    _columnames[colname] += Convert.ToInt32(row.Cells[colname].Value);
                }
            }
            //重画
            this.Invalidate();
        }

        private void FootSumLabel_Paint(object sender, PaintEventArgs e)
        {
            if (_GridViewX != null)
            {
                int count = _GridViewX.Columns.Count;
                DataGridViewColumnCollection Columns = this._GridViewX.Columns;

                Graphics grf = e.Graphics;
                int x = this._GridViewX.RowHeadersWidth - 2;
                StringFormat strfmt = new StringFormat();
                strfmt.Alignment = StringAlignment.Near;
                for (int i = 0; i < count; i++)
                {

                    foreach (KeyValuePair<string, int> keyValuePair in _columnames)
                    {
                        if (Columns[i].Name == keyValuePair.Key)
                        {
                            grf.DrawString(string.Format("{0}", "|" + keyValuePair.Value), this.Font, Brushes.Black,
                                           x - vscrollvalue, 3, strfmt);
                        }
                    }

                    if (Columns[i].Visible)
                    {
                        x += Columns[i].Width;
                    }

                    if (i == 1)
                    {
                        grf.DrawString(string.Format("{0}", "合计:" + _GridViewX.Rows.Count), this.Font, Brushes.Black, 0 - vscrollvalue, 3,
                                       strfmt);
                    }
                    



                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FootSumLabel
            // 
            this.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FootSumLabel_Paint);
            Text = "";
            this.ResumeLayout(false);
        }
    }
}

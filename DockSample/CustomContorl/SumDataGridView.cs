using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;

namespace SQX.Grid.Demo
{
    public partial class SumDataGridView : UserControl
    {
        #region parameter
        private DataGridViewColumnCollection columns = null;
        #endregion
        #region constructor
        public SumDataGridView()
        {
            InitializeComponent();
            Init();
        }
        #endregion
        #region init
        private void Init()
        {
            //columns = new DataGridViewColumnCollection(dgSource);
        }

        #endregion
        #region Property
        [Category("AGrid"), Description("数据源")]
        public DataGridView SourceGrid
        {
            get
            {
                return null;  //return dgSource;
            }
        }
        /// <summary>
        /// 需要添加合计的行数
        /// </summary>
        [Category("合计"), Description("需要合计的列")]
        public string[] SumColumns
        {
            get;
            set;
        }
        [Editor("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public DataGridViewColumnCollection Columns
        {
            get
            {

                return null;//dgSource.Columns;
            }
            set
            {
                columns = value;
                foreach (DataGridViewColumn col in columns)
                {
                    //if (!dgSource.Columns.Contains(col))
                    //{
                    //    dgSource.Columns.Add(col);
                    ////}
                }

            }
        }
        #endregion
    }
}

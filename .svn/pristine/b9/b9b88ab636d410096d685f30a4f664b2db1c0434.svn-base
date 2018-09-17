using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessLogic.PrintBarcode;
using BusinessLogic.Search;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar;

namespace MonitorMain
{
    public partial class DisLineBox : Form
    {
        public DisLineBox()
        {
            InitializeComponent();


        }

        private void DisLineBox_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;
        }

        private void GetPrintCust(int indexno)
        {
            flowLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(flowLayoutPanel1, true, null);
            flowLayoutPanel4.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(flowLayoutPanel4, true, null);
            flowLayoutPanel4.Controls.Clear();
            flowLayoutPanel1.Controls.Clear();
            SortingLineTask sortingLineTask = SortingLineTask.GetSortingLineByIndex(indexno.ToString());

            Label button = new Label();
            button.Width = 120;
            button.Height = 20;
            button.Text = "当前客户";
            
            flowLayoutPanel4.Controls.Add(button);

            button = new Label();
            button.Width = 120;
            button.Height = 20;
            button.Text = "序号:" + sortingLineTask.INDEXNO;
            flowLayoutPanel4.Controls.Add(button);

            button = new Label();
            button.Width = 120;
            button.Height = 20;
            button.Text = "客户名:" + sortingLineTask.ShortName;
            flowLayoutPanel4.Controls.Add(button);

            button = new Label();
            button.Width = 300;
            button.Height = 20;
            button.Text = sortingLineTask.CUSTCODE;
            flowLayoutPanel4.Controls.Add(button);


            SortingLineTaskDetails sortingLineTaskDetails = SortingLineTaskDetails.GetSortingLineTaskDetailsByIndex(indexno);
            foreach (SortingLineTaskDetail sortingLineTaskDetail in sortingLineTaskDetails)
            {
                button = new Label();
                button.Width = 20;
                button.Height = 120;
                if (sortingLineTaskDetail.CIGNAME.Count() > 7)
                {
                    sortingLineTaskDetail.CIGNAME = sortingLineTaskDetail.CIGNAME.Substring(0, 7);
                }

                button.Text = sortingLineTaskDetail.LINEBOXCODE + Environment.NewLine + sortingLineTaskDetail.CIGNAME.Replace("(", " ").Replace(")", " ") + Environment.NewLine + sortingLineTaskDetail.QTY;
                flowLayoutPanel1.Controls.Add(button);
            }
            ButtonX buttonx = new ButtonX();
            buttonx.Width = 50;
            buttonx.Height = 50;
            buttonx.Text = "显示更多客户列表";
            buttonx.Click += new EventHandler(buttonx_Click);
            flowLayoutPanel4.Controls.Add(buttonx);
        }

        void buttonx_Click(object sender, EventArgs e)
        {
            TaskList taskList = new TaskList();
            taskList.ShowDialog();
        }

        private void GetPrePrintCust(int indexno)
        {
            flowLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(flowLayoutPanel2, true, null);
            flowLayoutPanel6.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(flowLayoutPanel6, true, null);
            flowLayoutPanel6.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            SortingLineTask sortingLineTask = SortingLineTask.GetSortingLineByIndex(indexno.ToString());

            Label button = new Label();
            button.Width = 120;
            button.Height = 20;
            button.Text = "上一客户";
            flowLayoutPanel6.Controls.Add(button);

            button = new Label();
            button.Width = 120;
            button.Height = 20;
            button.Text = "序号:" + sortingLineTask.INDEXNO;
            flowLayoutPanel6.Controls.Add(button);

            button = new Label();
            button.Width = 120;
            button.Height = 20;
            button.Text = "客户名:" + sortingLineTask.ShortName;
            flowLayoutPanel6.Controls.Add(button);

            button = new Label();
            button.Width = 300;
            button.Height = 20;
            button.Text = sortingLineTask.CUSTCODE;
            flowLayoutPanel6.Controls.Add(button);
          

            SortingLineTaskDetails sortingLineTaskDetails = SortingLineTaskDetails.GetSortingLineTaskDetailsByIndex(indexno);

            

            foreach (SortingLineTaskDetail sortingLineTaskDetail in sortingLineTaskDetails)
            {

                if (sortingLineTaskDetail.CIGNAME.Count() > 7)
                {
                    sortingLineTaskDetail.CIGNAME = sortingLineTaskDetail.CIGNAME.Substring(0, 7);
                }
                button = new Label();
                button.Width = 20;
                button.Height = 120;

                button.Text = sortingLineTaskDetail.LINEBOXCODE + Environment.NewLine + sortingLineTaskDetail.CIGNAME.Replace("(", " ").Replace(")", " ") + Environment.NewLine + sortingLineTaskDetail.QTY;
                flowLayoutPanel2.Controls.Add(button);
            }
        }

        private void GetNextPrintCust(int indexno)
        {
            flowLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(flowLayoutPanel3, true, null);
            flowLayoutPanel5.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(flowLayoutPanel5, true, null);
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            SortingLineTask sortingLineTask = SortingLineTask.GetSortingLineByIndex(indexno.ToString());

            Label button = new Label();
            button.Width = 120;
            button.Height = 20;
            button.Text = "下一客户";
            flowLayoutPanel5.Controls.Add(button);

            button = new Label();
            button.Width = 120;
            button.Height = 20;
            button.Text = "序号:" + sortingLineTask.INDEXNO;
            flowLayoutPanel5.Controls.Add(button);

            button = new Label();
            button.Width = 120;
            button.Height = 20;
            button.Text = "客户名:" + sortingLineTask.ShortName;
            flowLayoutPanel5.Controls.Add(button);

            button = new Label();
            button.Width = 300;
            button.Height = 20;
            button.Text = sortingLineTask.CUSTCODE;
            flowLayoutPanel5.Controls.Add(button);




            SortingLineTaskDetails sortingLineTaskDetails = SortingLineTaskDetails.GetSortingLineTaskDetailsByIndex(indexno);

           
            foreach (SortingLineTaskDetail sortingLineTaskDetail in sortingLineTaskDetails)
            {
                if (sortingLineTaskDetail.CIGNAME.Count() > 7)
                {
                    sortingLineTaskDetail.CIGNAME = sortingLineTaskDetail.CIGNAME.Substring(0, 7);
                }
                button = new Label();
                button.Width = 20;
                button.Height = 120;


                button.Text = sortingLineTaskDetail.LINEBOXCODE + Environment.NewLine + sortingLineTaskDetail.CIGNAME.Replace("(", " ").Replace(")", " ") + Environment.NewLine + sortingLineTaskDetail.QTY;
                flowLayoutPanel3.Controls.Add(button);
            }
        }


        void buttonX_Click(object sender, EventArgs e)
        {
            
        }


        private void GetCustCigInfo()
        {
            int indexno = PrintBarCodes.GetPrintIndex();

            if (indexno > 0)
            {
                GetPrintCust(indexno);
                GetPrePrintCust(indexno - 1);
                GetNextPrintCust(indexno + 1);
            }
        }


        public delegate void dt();

        public void run()
        {
            dt d = new dt(new ThreadStart(GetCustCigInfo));
            this.Invoke(d, new Object[] { });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(run));
            
            thread.Start();
        }
    }
}

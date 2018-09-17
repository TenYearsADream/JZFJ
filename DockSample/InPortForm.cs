using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AppUtility;
using BusinessLogic.DisplayBoards;
using BusinessLogic.INTASKS;
using DevComponents.DotNetBar;

namespace MonitorMain
{

    public partial class InPortForm : Form
    {

        Dictionary<int,Color> colors = new Dictionary<int, Color>();
        private int currentindex = 0;
        private int currentcolor = 1;
        private string maxtaskno = "0";
        public InPortForm()
        {
            InitializeComponent();
            colors.Add(1, Color.LimeGreen);
            colors.Add(2, Color.SkyBlue);
            colors.Add(3, Color.Yellow);

            showOnMonitor(Int16.Parse(AppUtil._ScreenPosition) - 1);
        }

        private void OutPortForm_Load(object sender, EventArgs e)
        {
            
            //if (!InTaskList.IsInTaskFinish())
            //{
                timer1.Start();
                GetInPortInfo();
            //}
            //else
            //{
            //    labindexno.Text = "补货完成";
            //    labcigname.Text = "补货完成";
            //    labbarcode.Text = "补货完成";
            //    labnbarcode.Text = "补货完成";
            //    labncigname.Text = "补货完成";
            //}
        }


        public void GetInPortInfo()
        {
            try
            {
                maxtaskno = InTask.GetMaxIndex();
                int indexno = 0;
                indexno = GetCurrentInfo();
                GetNextInfo(indexno);                
                pic_nonetwork.Visible = false;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"));
                {
                    pic_nonetwork.Visible = true;
                }                
            }
                       
            
        }

        private void GetPreInfo(int index)
        {
            
        }

        private void GetNextInfo(int index)
        {
            
            itemPanel1.BeginUpdate();
            itemPanel1.Items.Clear();
            //itemPanel2.Items.Clear();
            List<string> nextIntaskList = InTaskList.GetInTaskCigNamesByIndex(index);

            if (nextIntaskList.Count > 0)
            {
                labncigname.Text = "(" + nextIntaskList[0].Split('-')[2] + ")" + nextIntaskList[0].Split('-')[0];
                labnbarcode.Text = nextIntaskList[0].Split('-')[1];
                nextIntaskList.RemoveAt(0);
            }
            else
            {
                labnbarcode.Text = "无";
                labncigname.Text = "无";
            }

            foreach (string inTask in nextIntaskList)
            {
                LabelItem labelItem = new LabelItem();
                labelItem.Text = "(" + inTask.Split('-')[2] + ")" + inTask.Split('-')[0];
                labelItem.TextAlignment = StringAlignment.Center;
                labelItem.ForeColor = Color.Red;
                itemPanel1.Items.Add(labelItem);

                //LabelItem labelItem1 = new LabelItem();
                //labelItem1.Text = inTask.Split('-')[2];
                //labelItem1.TextAlignment = StringAlignment.Center;
                //labelItem1.ForeColor = Color.Red;
                //itemPanel1.Items.Add(labelItem1);
            }

            
            itemPanel1.EndUpdate();
            //itemPanel1.Update();
            
            //if (_comfirmintask != null && !string.IsNullOrEmpty(_comfirmintask.ID))
            //{
            //    panelEx4.Visible = true;

               
            //    labnextport.Text = _comfirmintask.INPORTCODE;
            //    labnextindexno.Text = _comfirmintask.INDEXNO.ToString();
            //    labnextbarcode.Text = _comfirmintask.BARCODE;
            //    labnextcigname.Text = _comfirmintask.CIGNAME;
            //    labnextqty.Text = (_comfirmintask.INQTY / 50).ToString();
                
            //}
            //else
            //{
            //    panelEx4.Visible = false;
            //}
        }

        private int GetCurrentInfo()
        {          

                InTask _comfirmintask = InTask.GetConfirmInTask();
                string orderdate  = InTask.GetInTaskDate();
                labtitle.Text = "当前补货卷烟 (" + orderdate + ")";
                if (_comfirmintask != null && _comfirmintask.INDEXNO > 0)
                {
                    panelEx2.Visible = true;

                    if (currentindex != _comfirmintask.INDEXNO)
                    {
                        if (currentcolor >= 3)
                        {
                            currentcolor = 1;
                        }

                        foreach (var control in panelEx4.Controls)
                        {
                            if (control is LabelX)
                            {
                                ((LabelX)control).ForeColor = colors[currentcolor];                                
                            }
                        }
                        currentcolor++;
                    }

                    labindexno.Text = _comfirmintask.INDEXNO + "/" + maxtaskno;
                    labbarcode.Text = _comfirmintask.BARCODE;
                    labcigname.Text = _comfirmintask.CIGNAME;


                    currentindex = _comfirmintask.INDEXNO;
                    return _comfirmintask.INDEXNO;
                }
                else
                {
                    labindexno.Text = "无";
                    labbarcode.Text = "无";
                    labcigname.Text = "无";
                }
                return 0;
            //}
            //else
            //{
            //    labindexno.Text = "补货完成";
            //    labcigname.Text = "补货完成";
            //    labbarcode.Text = "补货完成";
            //    labnbarcode.Text = "补货完成";
            //    labncigname.Text = "补货完成";
            //    return 0;
            //}
            
        }


        private void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }


            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// 1.5秒刷新一次补货大屏的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Thread thread = new Thread(GetInPortInfo);
            //thread.IsBackground = true;
            //thread.Start();
            GetInPortInfo();

            try
            {
                //如果补货任务已全部下达
                if (InTaskList.IsInTaskFinish())
                {

                    timer1.Enabled = false;


                    Thread t = new Thread(ShowFinish);
                    t.Start();

                }
            }
            catch (Exception)
            {
                
                
            }
            
        }

        /// <summary>
        /// 显示最后两件需要补货的卷烟
        /// </summary>
        private void ShowFinish()
        {
            Thread.Sleep(20000);
            int indexno = GetCurrentInfo();
            InTask intask = InTask.GetInTaskByIndex((indexno + 1).ToString());
            labindexno.Text = intask.INDEXNO + "/" + maxtaskno;
            labbarcode.Text = intask.BARCODE;
            labcigname.Text = intask.CIGNAME;            
            labnbarcode.Text = "无";
            labncigname.Text = "无";


            Thread.Sleep(20000);
            labindexno.Text = "补货完成";
            labcigname.Text = "补货完成";
            labbarcode.Text = "补货完成";
            labnbarcode.Text = "补货完成";
            labncigname.Text = "补货完成";
            itemPanel1.BeginUpdate();
            itemPanel1.Items.Clear();
            itemPanel1.EndUpdate();
        }

        private void labindexno_Click(object sender, EventArgs e)
        {

        }

        private void InPortForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        
    }
}

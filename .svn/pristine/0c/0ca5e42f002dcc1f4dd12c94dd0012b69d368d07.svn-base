using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessLogic.arrive;
using BusinessLogic.DisplayBoards;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar.Controls;

using MonitorMain.CustomContorl.Search;
using PlcContract;

namespace MonitorMain
{
    public partial class DynamicBoxForm : Form
    {
        public DynamicBoxForm()
        {
            InitializeComponent();
        }

        private DynamicBoxTaskList vwDynamicBoxTaskList;
        private DynamicBoxTaskList ybDynamicBoxTaskList;
        private SortingTaskArrive sortingtaskarrive;

        private void DynamicBoxForm_Load(object sender, EventArgs e)
        {

            

            labnum1.Text = DynamicBoxTaskList.GetDynamicBoxTaskList(new DynamicBoxTaskList.QueryCondition("73", 0 , "desc")).GetSumQty().ToString();
            labnum2.Text = DynamicBoxTaskList.GetDynamicBoxTaskList(new DynamicBoxTaskList.QueryCondition("73", 1 , "desc")).GetSumQty().ToString();
            //labnum3.Text = DynamicBoxTaskList.GetDynamicBoxTaskList("3").GetSumQty().ToString();




            dgvwbDynamicBox.DataSource = vwDynamicBoxTaskList = DynamicBoxTaskList.GetDynamicBoxTaskList(new DynamicBoxTaskList.QueryCondition("73", 0, "desc"));
            dgvybDynamicBox.DataSource = ybDynamicBoxTaskList = DynamicBoxTaskList.GetDynamicBoxTaskList(new DynamicBoxTaskList.QueryCondition("73", 1, "desc"));
            

            SetNonDynamicBox();

            SetFinDynamicBox();           
        }

        private void SetNonDynamicBox()
        {
            int totqty = 0;
            foreach (DataGridViewRow row in dgvwbDynamicBox.Rows)
            {
                totqty += Convert.ToInt16(row.Cells["inQtyDataGridViewTextBoxColumn"].Value);
                row.DefaultCellStyle.BackColor = Color.GreenYellow;
                //每次只加10条烟到仓道
                if (totqty >= 10)
                {
                    break;
                }
            }
        }


        private void SetFinDynamicBox()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(SetFinDynamicBox));
                }

               


                int indexno = 0;
                int rowindexno = 0;

                //获取混合仓中已分拣完成的卷烟列表
                SortingLineTaskList sortingLineTaskList = SortingLineTaskList.GetFinSortingLineTaskList(new QueryCondition("2", true, AppUtility.AppUtil._SortingLineId,"desc"));


                //得到最新完成的流水号
                if (sortingLineTaskList.Count > 0)
                {
                    indexno = sortingLineTaskList[0].INDEXNO;
                }

                //重置列表
                foreach (DataGridViewRow row in dgvybDynamicBox.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.Cells["outputnum"].Value = "";
                }

                //将混仓显示列表中的已完成卷烟背景色显示为灰色
                for (int i = dgvybDynamicBox.Rows.Count-1 ; i >= 0; i--)
                {
                    if (Convert.ToInt16(dgvybDynamicBox.Rows[i].Cells[0].Value) <= indexno)
                    {
                        dgvybDynamicBox.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        //row.Cells["outputnum"].Value = "";
                    }
                    else
                    {
                        //控制滚动条的显示位置
                        if (dgvybDynamicBox.Rows[i].Index - 10 >= 0)
                        {
                            dgvybDynamicBox.FirstDisplayedScrollingRowIndex = dgvybDynamicBox.Rows[i].Index - 10;
                        }
                        else
                        {
                            dgvybDynamicBox.FirstDisplayedScrollingRowIndex = 0;
                        }
                        //获取表格中已分拣完成混仓烟位置
                        rowindexno = dgvybDynamicBox.Rows[i].Index;
                        break;
                    }
                    
                }


                //将混仓显示列表中的已完成卷烟背景色显示为灰色
                //foreach (DataGridViewRow row in dgvybDynamicBox.Rows)
                //{
                //    if (Convert.ToInt16(row.Cells[0].Value) <= indexno)
                //    {
                //        row.DefaultCellStyle.BackColor = Color.DarkGray;
                //        //row.Cells["outputnum"].Value = "";
                //    }
                //    else
                //    {
                //        //控制滚动条的显示位置
                //        if (row.Index >= 6)
                //        {
                //            dgvybDynamicBox.FirstDisplayedScrollingRowIndex = row.Index - 6 ;
                //        }
                //        else
                //        {
                //            dgvybDynamicBox.FirstDisplayedScrollingRowIndex = row.Index - row.Index;
                //        }
                //        //获取表格中已分拣完成混仓烟位置
                //        rowindexno = row.Index;
                //        break;
                //    }
                //}

                //在皮带上的混仓卷烟数量
                sortingtaskarrive = SortingTaskArrive.GetSortingTaskArrive("0");
                int outputnum = Convert.ToInt32(sortingtaskarrive.Value);

                //数量大于0表示皮带上有混仓烟
                if (outputnum > 0)
                {
                    if (rowindexno - 1 > 0)
                    {
                        //对列表上的卷烟进行已分拣出的标记
                        for (int i = rowindexno; i > 0; i--)
                        {

                            if (outputnum > 0)
                            {
                                
                                //当前行的数量小于皮带上的数量，在已打出显示当前数量
                                if (Convert.ToInt32(dgvybDynamicBox.Rows[i].Cells["InQty"].Value) <= outputnum)
                                {
                                    //将已打出的混仓烟标记为蓝色背景
                                    dgvybDynamicBox.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                                    dgvybDynamicBox.Rows[i].Cells["outputnum"].Value = dgvybDynamicBox.Rows[i].Cells["InQty"].Value;
                                }
                                else
                                {
                                    //将已打出的混仓烟标记为蓝色背景
                                    dgvybDynamicBox.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                                    //当前行的数量大于皮带上的剩余数量，显示剩余数量
                                    dgvybDynamicBox.Rows[i].Cells["outputnum"].Value = outputnum;
                                    break;
                                }
                                //减去当前行的数量，得到剩余数量进行下一次循环
                                outputnum = outputnum - Convert.ToInt32(dgvybDynamicBox.Rows[i].Cells["InQty"].Value);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }

        //private delegate void SetDynamicBoxdelegate();
        //private void 
       


        private void timer1_Tick(object sender, EventArgs e)
        {
            //SetDynamicBoxdelegate mydelegate = new SetDynamicBoxdelegate(SetFinDynamicBox);
            //this.Invoke(mydelegate);
            Thread thread = new Thread(SetFinDynamicBox);
            thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认补仓？","提示",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int totqty = 0;
                for (int i = 0; i < vwDynamicBoxTaskList.Count; i++)
                {
                    DynamicBoxTask dynamicBox = vwDynamicBoxTaskList[i];
                    dynamicBox.SaveIn();
                    totqty += vwDynamicBoxTaskList[i].InQty;
                    //if (totqty >= 10)
                    //{
                    //    break;
                    //}
                }

                
                labnum1.Text = DynamicBoxTaskList.GetDynamicBoxTaskList(new DynamicBoxTaskList.QueryCondition("1", 0, "desc")).GetSumQty().ToString();
                labnum2.Text = DynamicBoxTaskList.GetDynamicBoxTaskList(new DynamicBoxTaskList.QueryCondition("1", 1, "desc")).GetSumQty().ToString();
                //labnum3.Text = DynamicBoxTaskList.GetDynamicBoxTaskList("3").GetSumQty().ToString();
                dgvwbDynamicBox.DataSource = vwDynamicBoxTaskList = DynamicBoxTaskList.GetDynamicBoxTaskList(new DynamicBoxTaskList.QueryCondition("1", 0 , "desc"));
                dgvybDynamicBox.DataSource = ybDynamicBoxTaskList = DynamicBoxTaskList.GetDynamicBoxTaskList(new DynamicBoxTaskList.QueryCondition("1", 1, "desc"));
                SetNonDynamicBox();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmLineBoxSearch frmlineboxsearch = new frmLineBoxSearch();
            frmlineboxsearch.ShowDialog();
            
        }


        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.SortingTask;

namespace MonitorMain.CustomContorl
{
    /// <summary>
    /// 界面上的小车控件
    /// </summary>
    public partial class C_Cube : UserControl
    {
        public C_Cube()
        {
            InitializeComponent();
        }

        public string Sublinecode { get; set; }


        /// <summary>
        /// 设置小车的鼠标提示
        /// </summary>
        /// <param name="sublinecode"></param>
        /// <param name="sortingLineTaskDetails"></param>
        public void SetTooltip(string custname,string sublinecode,IEnumerable<SortingLineTaskDetail> sortingLineTaskDetails)
        {
            
            if (sortingLineTaskDetails != null)
            {
                bool iscustnamered = false;
                //设置小车的子线编号
                Sublinecode = sublinecode;
                string headstring =  "<b>已分拣卷烟</b><br></br>";
                string toolstring = "<b>正在分拣卷烟</b><br></br>";
                string foottoolstring = "<b>未分拣卷烟</b><br></br>";
                sortingLineTaskDetails = sortingLineTaskDetails.OrderByDescending(item => item.SUBLINECODE == sublinecode).ThenBy(x => Convert.ToInt32(x.LINEBOXCODE));
                foreach (SortingLineTaskDetail sortingLineTaskDetail in sortingLineTaskDetails)
                {
                    //如果明细任务中子线与小车位置对应以红色显示
                    if (sublinecode == sortingLineTaskDetail.SUBLINECODE)
                    {
                        iscustnamered = true;
                        toolstring += "<font color='red'>子线号:" + sortingLineTaskDetail.SUBLINECODE + " 仓道:" + sortingLineTaskDetail.LINEBOXCODE +
                                  " 卷烟:" + sortingLineTaskDetail.CIGNAME + " 数量：" + sortingLineTaskDetail.QTY + "</font> <br></br>";
                    }
                    else if(sortingLineTaskDetail.Status == 0)
                    {
                        foottoolstring += "子线号:" + sortingLineTaskDetail.SUBLINECODE + " 仓道:" + sortingLineTaskDetail.LINEBOXCODE +
                                  " 卷烟:" + sortingLineTaskDetail.CIGNAME + " 数量：" + sortingLineTaskDetail.QTY + "<br></br>";
                    }
                    else if (sortingLineTaskDetail.Status == 2)
                    {
                        headstring += "子线号:" + sortingLineTaskDetail.SUBLINECODE + " 仓道:" + sortingLineTaskDetail.LINEBOXCODE +
                                  " 卷烟:" + sortingLineTaskDetail.CIGNAME + " 数量：" + sortingLineTaskDetail.QTY + "<br></br>";
                    }
                }
                this.superTooltip1.SetSuperTooltip(this.panelno,
                    new DevComponents.DotNetBar.SuperTooltipInfo("客户订单分拣明细清单-" + custname, headstring + Environment.NewLine +  foottoolstring,
                        toolstring, MonitorMain.Properties.Resources.Arrow_up_48px_1184719_easyicon_net, MonitorMain.Properties.Resources.Arrow_down_48px_1184716_easyicon_net,
                        DevComponents.DotNetBar.eTooltipColor.Yellow));
                this.superTooltip1.SetSuperTooltip(this.labindexno,
                    new DevComponents.DotNetBar.SuperTooltipInfo("客户订单分拣明细清单-" + custname, headstring + Environment.NewLine +  foottoolstring,
                        toolstring, MonitorMain.Properties.Resources.Arrow_up_48px_1184719_easyicon_net, MonitorMain.Properties.Resources.Arrow_down_48px_1184716_easyicon_net,
                        DevComponents.DotNetBar.eTooltipColor.Yellow));
                this.superTooltip1.SetSuperTooltip(this.labcustname,
                    new DevComponents.DotNetBar.SuperTooltipInfo("客户订单分拣明细清单-" + custname, headstring + Environment.NewLine +  foottoolstring,
                        toolstring, MonitorMain.Properties.Resources.Arrow_up_48px_1184719_easyicon_net, MonitorMain.Properties.Resources.Arrow_down_48px_1184716_easyicon_net,
                        DevComponents.DotNetBar.eTooltipColor.Yellow));
                this.superTooltip1.SetSuperTooltip(this.labfinnum,
                    new DevComponents.DotNetBar.SuperTooltipInfo("客户订单分拣明细清单-" + custname, headstring + Environment.NewLine +  foottoolstring,
                        toolstring, MonitorMain.Properties.Resources.Arrow_up_48px_1184719_easyicon_net, MonitorMain.Properties.Resources.Arrow_down_48px_1184716_easyicon_net,
                        DevComponents.DotNetBar.eTooltipColor.Yellow));
                if (iscustnamered)
                {
                    this.labcustname.ForeColor = Color.Red;
                }
                else
                {
                    this.labcustname.ForeColor = Color.Black;
                }
            }
            else
            {
                this.superTooltip1.SetSuperTooltip(this.panelno,
               new DevComponents.DotNetBar.SuperTooltipInfo("", "",
                   "", null, null,
                   DevComponents.DotNetBar.eTooltipColor.Yellow, false, false, new Size(0, 0)));
                this.superTooltip1.SetSuperTooltip(this.labindexno,
                    new DevComponents.DotNetBar.SuperTooltipInfo("", "",
                        "", null, null,
                        DevComponents.DotNetBar.eTooltipColor.Yellow, false, false, new Size(0, 0)));
                this.superTooltip1.SetSuperTooltip(this.labcustname,
                    new DevComponents.DotNetBar.SuperTooltipInfo("", "",
                        "", null, null,
                        DevComponents.DotNetBar.eTooltipColor.Yellow, false, false, new Size(0, 0)));
                this.superTooltip1.SetSuperTooltip(this.labfinnum,
                    new DevComponents.DotNetBar.SuperTooltipInfo("", "",
                        "", null, null,
                        DevComponents.DotNetBar.eTooltipColor.Yellow, false, false, new Size(0, 0)));
                this.labcustname.ForeColor = Color.Black;
            }
            
        }

        public void SetTooltip()
        {
            this.superTooltip1.SetSuperTooltip(this.panelno,
                new DevComponents.DotNetBar.SuperTooltipInfo("", "",
                    "", null, null,
                    DevComponents.DotNetBar.eTooltipColor.Yellow, false, false, new Size(0, 0)));
            this.superTooltip1.SetSuperTooltip(this.labindexno,
                new DevComponents.DotNetBar.SuperTooltipInfo("", "",
                    "", null, null,
                    DevComponents.DotNetBar.eTooltipColor.Yellow, false, false, new Size(0, 0)));
            this.superTooltip1.SetSuperTooltip(this.labcustname,
                new DevComponents.DotNetBar.SuperTooltipInfo("", "",
                    "", null, null,
                    DevComponents.DotNetBar.eTooltipColor.Yellow, false, false, new Size(0, 0)));
            this.superTooltip1.SetSuperTooltip(this.labfinnum,
                new DevComponents.DotNetBar.SuperTooltipInfo("", "",
                    "", null, null,
                    DevComponents.DotNetBar.eTooltipColor.Yellow, false, false, new Size(0, 0)));
            this.labcustname.ForeColor = Color.Black;
        }

        private void 编辑小车位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}

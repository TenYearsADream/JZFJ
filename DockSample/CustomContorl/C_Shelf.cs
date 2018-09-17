using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Common;
using BusinessLogic.Search;
using DevComponents.DotNetBar;
using HDWLogic;

namespace MonitorMain.CustomContorl
{
    public partial class C_Shelf : UserControl
    {
        private CigInfo _cigInfo;
        private SortingLineBox _sortingLineBox;
        private int _nonqty;
        private int _totqty;

        
        public C_Shelf(SortingLineBox sortingLineBox)
        {
            InitializeComponent();
            this.Width = sortingLineBox.PutNum*30;
            _sortingLineBox = sortingLineBox;
            labshelfcode.Text = _sortingLineBox.LineBoxCode;
            progressBarX1.Maximum = _sortingLineBox.TOTQTY;
            progressBarX1.Value = 0;
            progressBarX1.Text = _sortingLineBox.CigName.Replace("(", "").Replace(")", ""); ;
            progressBarX1.TextVisible = false;
            if (sortingLineBox.IsDynamicbox == 1)
            {
                progressBarX1.ColorTable = eProgressBarItemColor.Paused;    
            }
            

            labcqty.Text = "";
            //在父控件中透明
            labcqty.Parent = progressBarX1;
            
            labcqty.BackColor = Color.Transparent;
        }

	    public void SetTooltip(int nonqty,int totqty)
	    {
	        _nonqty = nonqty;
	        _totqty = totqty;
	        try
	        {
                this.superTooltip1.SetSuperTooltip(this.progressBarX1,
                new DevComponents.DotNetBar.SuperTooltipInfo("烟仓分拣进度", "",
                    "烟仓" + _sortingLineBox.LineBoxCode + Environment.NewLine+ _sortingLineBox.CigName + Environment.NewLine + "未分/总量:" +
                    (nonqty + "/" + totqty).ToString(), null, null,
                    DevComponents.DotNetBar.eTooltipColor.Yellow));

                this.superTooltip1.SetSuperTooltip(this.labcqty,
                new DevComponents.DotNetBar.SuperTooltipInfo("烟仓分拣进度", "",
                    "烟仓" + _sortingLineBox.LineBoxCode + Environment.NewLine + _sortingLineBox.CigName + Environment.NewLine + "未分/总量:" +
                    (nonqty + "/" + totqty).ToString(), null, null,
                    DevComponents.DotNetBar.eTooltipColor.Yellow));

              
	        }
	        catch (Exception)
	        {
	            
	            
	        }
		    
	    }


	    private void C_Shelf_Load(object sender, EventArgs e)
        {
            //货格大小初始化
            Size = new System.Drawing.Size(_sortingLineBox.PutNum * 30 , 100);
            
            labcqty.Width = progressBarX1.Width;
            labcqty.TextAlignment = StringAlignment.Center;
            labcqty.TextLineAlignment = StringAlignment.Center;
            labcqty.Left = 0;
            labcqty.Top = progressBarX1.Height/2;
	        labcqty.Height = 20;
        }

        public string Lineboxcode
        {
            get { return labshelfcode.Text; }
            set { labshelfcode.Text = value; }
        }

        public string PickNum
        {
            get { return labcqty.Text; }
            set { labcqty.Text = value; }
        }

        public string CigName
        {
            get { return progressBarX1.Text; }
            set
            {
                progressBarX1.Text = value;
            }
        }

        public void ShowCigName(bool isshow)
        {
            progressBarX1.TextVisible = isshow;
        }

        public void ShowCigQty(int qty)
        {
            progressBarX1.Value = qty;
        }

        private void labcqty_Click(object sender, EventArgs e)
        {
            //this.progressBarX1.Value = this.progressBarX1.Value - TagSdk.instance.CigNums[Convert.ToInt32(Lineboxcode)];
            //this.SetTooltip(_nonqty - TagSdk.instance.CigNums[Convert.ToInt32(Lineboxcode)],_totqty);
            if (ATOPTagSdk.Tags.ContainsKey(Convert.ToInt32(Lineboxcode)))
            {
                ATOPTagSdk.Tags[Convert.ToInt32(Lineboxcode)].Qty = 0;    
            }
        }
    }
}

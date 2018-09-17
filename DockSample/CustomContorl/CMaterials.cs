using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.materials;
using BusinessLogic.Search;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Schedule;

namespace MonitorMain.CustomContorl
{
    public partial class CMaterials : UserControl
    {
	    private int colorint  = 1;
	    private MaterialsList materialsList;
        private List<MaterialsDetial> materialsDetialtots;

        public CMaterials()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); //双缓冲
            this.UpdateStyles();
            InitializeComponent();
            
            materialsList = MaterialsList.GetMaterialsList();
            materialsDetialtots = new List<MaterialsDetial>();
            if (materialsList.Count > 0)
            {
                labmaterialsdate.Text = "订单日期：" + materialsList[0].orderDate + "  分拣批次：" + materialsList[0].sortingTaskNo;

	             
                foreach (Materials materials in materialsList)
                {
                    CreateMaterialControl(materials);
                }
            }
        }

        private void CMaterials_Load(object sender, EventArgs e)
        {
            SetSortingNum();
        }

        private void CreateMaterialControl(Materials materials)
	    {
            DevComponents.DotNetBar.SuperTabItem superTabItem1;
            superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(200, 100);
            this.superTabControlPanel1.TabIndex = 0;
            // 
            // superTabItem1
            // 
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates1 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            superTabItem1.AttachedControl = this.superTabControlPanel1;
            superTabItem1.GlobalItem = false;
            superTabItem1.Name = "superTabItem" + materials.sequenceNo;
            superTabItem1.TabFont = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            superTabItem1.SelectedTabFont = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            superTabItemStateColorTable1.OuterBorder = System.Drawing.Color.Gray;
            superTabColorStates1.Normal = superTabItemStateColorTable1;
            superTabItemColorTable1.Default = superTabColorStates1;
            superTabItem1.TabColor = superTabItemColorTable1;
            superTabItem1.Text = "领用批次" + materials.sequenceNo;
	        superTabItem1.Tag = materials;
            if (materials.status == 0)
	        {
                superTabItem1.Image = global::MonitorMain.Properties.Resources.ball_yellow;
	        }
            else
            {
                superTabItem1.Image = global::MonitorMain.Properties.Resources.ball_green;
            }
            superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            superTabItem1});

            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;


            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel" + materials.sequenceNo;
            flowLayoutPanel1.Size = new System.Drawing.Size(742, 500);
            flowLayoutPanel1.TabIndex = 0;
	        flowLayoutPanel1.AutoScroll = true;

            MaterialsDetial materialsDetialtot = MaterialsDetial.GetMaterialsDetialGroupBy(materials.ID);
            CMaterialsDetal cmaterialsDetal = new CMaterialsDetal(materialsDetialtot);
            cmaterialsDetal.Size = new Size(150, 150);
            if (colorint % 2 == 0)
            {
                cmaterialsDetal.BackColor = Color.AliceBlue;
            }
            else
            {
                cmaterialsDetal.BackColor = Color.Beige;
            }
            colorint++;
            flowLayoutPanel1.Controls.Add(cmaterialsDetal);
            materialsDetialtots.Add(materialsDetialtot);

            Bar bar1 = new Bar();
            bar1.AntiAlias = true;
            bar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            
            bar1.Name = "bar1";
            bar1.Size = new System.Drawing.Size(flowLayoutPanel1.Width + 100, 25);
            bar1.Stretch = true;
            bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            bar1.TabIndex = 5;
            bar1.TabStop = false;
            bar1.Text = "bar1";
            flowLayoutPanel1.Controls.Add(bar1);

	        


            materials.materialsDetailList = MaterialsDetailList.GetMaterialsDetailList(materials.ID);
            foreach (MaterialsDetial materialsDetial in materials.materialsDetailList)
            {
                CMaterialsDetal materialsDetal = new CMaterialsDetal(materialsDetial);
                materialsDetal.Size = new Size(150, 150);
                if (colorint % 2 == 0)
                {
                    materialsDetal.BackColor = Color.SpringGreen;
                }
                else
                {
                    materialsDetal.BackColor = Color.Yellow;
                }
                colorint++;
                flowLayoutPanel1.Controls.Add(materialsDetal);
            }

            PanelEx panelEx1 = new PanelEx();
            // 
            // panelEx1
            // 
            panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            panelEx1.Location = new System.Drawing.Point(369, 103);
            panelEx1.Name = "panelEx1";
            panelEx1.Size = new System.Drawing.Size(200, 100);
            panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            panelEx1.Style.GradientAngle = 90;
            panelEx1.TabIndex = 1;
            panelEx1.Dock = DockStyle.Fill;
            
            panelEx1.Controls.Add(flowLayoutPanel1);

            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(panelEx1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(127, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel" + materials.sequenceNo;
            this.superTabControlPanel1.Size = new System.Drawing.Size(742, 500);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = superTabItem1;
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
	    }

	    private void CreateMaterialDetailControl()
	    {
		    
	    }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (superTabControl1.SelectedPanel != null)
            {
                FlowLayoutPanel flowLayoutPanel =
                    superTabControl1.SelectedPanel.Controls[0].Controls[0] as FlowLayoutPanel;
                flowLayoutPanel.AutoScrollPosition = new Point(0, flowLayoutPanel.VerticalScroll.Value + 200);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (superTabControl1.SelectedPanel != null)
            {
                FlowLayoutPanel flowLayoutPanel = superTabControl1.SelectedPanel.Controls[0].Controls[0] as FlowLayoutPanel;
                flowLayoutPanel.AutoScrollPosition = new Point(0, flowLayoutPanel.VerticalScroll.Value - 200);
            }
            
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (superTabControl1.SelectedPanel != null)
            {
                Materials materials = superTabControl1.SelectedTab.Tag as Materials;
                if (materials != null)
                {
                    if (materials.status == 0)
                    {
                        if (MessageBox.Show("是否已完成当前批次备货？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            materials.SaveMaterialsStatus();
                            superTabControl1.SelectedTab.Image = global::MonitorMain.Properties.Resources.ball_green;
                        }
                    }
                }

            }
        }


	    private void SetSortingNum()
	    {
		    if (materialsList != null && materialsList.Count > 0)
		    {
			    SortingCigInfoList sortingCigInfoList = SortingCigInfoList.GetList();

			    for (int i = 0; i < materialsList.Count; i++)
			    {
				    for (int j = 0; j < materialsList[i].materialsDetailList.Count; j++)
				    {
					    for (int k = 0; k < sortingCigInfoList.Count; k++)
					    {
                            if (materialsList[i].materialsDetailList[j].cigInfoId == sortingCigInfoList[k].CigCode && sortingCigInfoList[k].Qty > 0)
						    {
							    if (materialsList[i].materialsDetailList[j].tQty >= sortingCigInfoList[k].Qty)
							    {
                                    materialsList[i].materialsDetailList[j].sortingNum = sortingCigInfoList[k].Qty;
							    }
							    else
							    {
                                    materialsList[i].materialsDetailList[j].sortingNum = materialsList[i].materialsDetailList[j].tQty;
							        sortingCigInfoList[k].Qty = sortingCigInfoList[k].Qty - materialsList[i].materialsDetailList[j].tQty;
							    }
                                //设置当前备货批次的总分拣量
						        materialsDetialtots[i].sortingNum += materialsList[i].materialsDetailList[j].sortingNum;
                                break;
						    }
					    }
				    }
			    }
		    }

	       
        
	    }
        
    }
}

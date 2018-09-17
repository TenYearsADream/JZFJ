using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.arrive;
using BusinessLogic.Common;
using BusinessLogic.Search;
using BusinessLogic.SortingTask;
using HDWLogic;
using HDWLogic.Issued;

namespace MonitorMain.CustomContorl
{
    public partial class C_SortingMain : UserControl
    {
        private Dictionary<string, C_Shelf> cShelves;
        //private List<C_Shelf> cafterUpShelves;
        //private List<C_Shelf> cafterDownShelves;
        //private List<C_Shelf> cbefortUpShelves;
        //private List<C_Shelf> cbefortDownShelves;
        public List<C_Cube> c_Cubes;
        private Dictionary<string, FlowLayoutPanel> flowLayoutPanels; 
        //private SortingSubLineList sortingSubLineList;

        public C_SortingMain()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); //双缓冲
            this.UpdateStyles();
            InitializeComponent();
            Dock = DockStyle.Fill;
            
        }

        


        private C_Shelf CreateShelf(SortingLineBox sortingLineBox)
        {
            C_Shelf c_Shelf = new C_Shelf(sortingLineBox);
            //c_Shelf.SetTooltip();
            c_Shelf.Name = sortingLineBox.LineBoxCode;
            return c_Shelf;
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

        private void C_SortingMain_Load(object sender, EventArgs e)
        {
            SortingLineTaskQueue.OnUpdateCSortingMainCubeEvent +=
                new EventHandler<EventArgs>(cSortingTask_OnUpdateCSortingMainCubeEvent);
            CSortingTask.OnUpdateCSortingMainNumEvent +=
                new EventHandler<UpdateCSortingMainNumEventArgs>(cSortingTask_OnUpdateCSortingMainNumEvent);
            CSortingTask.OnTaskMoved += new EventHandler<EventArgs>(CSortingTask_OnTaskMoved);
            if (IsVerifyPass())
            {
                MonitorLog monitorLog;
                monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "数据库读取";
                monitorLog.LOGINFO = "订单数据读取成功!";
                monitorLog.LOGLOCATION = "数据库";
                monitorLog.LOGTYPE = 1;
                monitorLog.Save();
            }
            //获取任务列表
            SortingLineTaskQueue.GetInstance().LoadSortingLineTasks();
            LoadLinBox();
            LoadCube();
            chkshowqty.Checked = true;


            //电子标签初始化
            ATOPTagSdk.InitTags();
        }

        

        private bool IsVerifyPass()
        {
            SortingLineTask.IsCurrentOrder();

            SortingLineTask.IsIndexRepetition();

            return true;
        }


        /// <summary>
        /// 加载小车控件
        /// </summary>
        private void LoadCube()
        {
            //获取小车的数据模型
            
            SortingLineTaskQueue.GetInstance().LoadSortingLineTasks();
            SortingLineTaskQueue.GetInstance().CreateCubesModel();
            //sortingSubLineList = SortingSubLineList.GetSubSortingLineList();

            //建立全空的小车控件
            this.cubeLayoutPanel.ColumnCount = SortingLineTaskQueue.GetInstance().CubesModel.Count;
            this.cubeLayoutPanel.ColumnStyles.Clear();
            this.cubeLayoutPanel.Controls.Clear();

            for (int i = 0; i < SortingLineTaskQueue.GetInstance().CubesModel.Count; i++)
            {
                cubeLayoutPanel.ColumnStyles.Add(
                    new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 670));


                C_Cube cCube = new C_Cube();
                cCube.Dock = DockStyle.Fill;
                cCube.Name = "ccube" + i;
                cCube.Margin = new Padding(0, 0, 0, 0);
                cCube.labcustname.Text = "无任务";
                cCube.labfinnum.Text = "0条";
                cCube.labindexno.Text = "0号";

                cCube.Tag = SortingLineTaskQueue.GetInstance().CubesModel[i].SubLineCode;
                cCube.Margin = new Padding(0, 0, 1, 0);

                c_Cubes.Add(cCube);
                cubeLayoutPanel.Controls.Add(cCube, i, 0);
            }
            

            //更新小车上订单的信息
            UpdateCubes();

        }

        /// <summary>
        /// 加载烟仓控件
        /// </summary>
        public void LoadLinBox()
        {
            //建立空的烟仓控件
            SortingLineBoxList sortingLineBoxList = SortingLineBoxList.GetLineBoxList();

            c_Cubes = new List<C_Cube>();
            cShelves = new Dictionary<string, C_Shelf>();
            //cbefortUpShelves = new List<C_Shelf>();
            //cbefortDownShelves =  new List<C_Shelf>();
            //cafterUpShelves = new List<C_Shelf>();
            //cafterDownShelves = new List<C_Shelf>();
            

            f1.Controls.Clear();
            f2.Controls.Clear();
            f3.Controls.Clear();
            f4.Controls.Clear();
            f5.Controls.Clear();
            f6.Controls.Clear();
            f7.Controls.Clear();
            f8.Controls.Clear();

            SortingSubLineList sortingSubLineList = SortingSubLineList.GetSubSortingLineList();
            if (sortingSubLineList.Count == 1)
            {
                f1.Width += f2.Width;
                top.SetColumnSpan(f1,3);
                panel1.Visible = false;
                top.SetColumnSpan(f3, 3);
                panel2.Visible = false;
                bottom.SetColumnSpan(f5, 3);
                panel4.Visible = false;
                bottom.SetColumnSpan(f7, 3);
                panel5.Visible = false;
                f2.Visible = false;
                f4.Visible = false;
                f6.Visible = false;
                f8.Visible = false;
                
            }
            

            if (sortingLineBoxList.Count > 0)
            {
                foreach (SortingLineBox sortingLineBox in sortingLineBoxList)
                {
                    if (sortingLineBox.PARENTLINEBOX == "1" && sortingLineBox.ABANDONPARENT == "2" && sortingLineBox.SublineSeq == 1)
                    {
                        C_Shelf cShelf = CreateShelf(sortingLineBox);
                        cShelves.Add(cShelf.Name, cShelf);

                        
                        cShelf.Margin = new Padding(0, 0, 1, 0);
                        InitLineBoxControl(cShelf,f1);
                    }
                    else if (sortingLineBox.PARENTLINEBOX == "1" && sortingLineBox.ABANDONPARENT == "2" && sortingLineBox.SublineSeq == 2)
                    {
                        C_Shelf cShelf = CreateShelf(sortingLineBox);
                        cShelves.Add(cShelf.Name, cShelf);
                        
                        cShelf.Margin = new Padding(0, 0, 1, 0);
                        InitLineBoxControl(cShelf, f1);
                    }
                    else if (sortingLineBox.PARENTLINEBOX == "1" && sortingLineBox.ABANDONPARENT == "1" && sortingLineBox.SublineSeq == 1)
                    {
                        C_Shelf cShelf = CreateShelf(sortingLineBox);
                        cShelves.Add(cShelf.Name, cShelf);
                        
                        cShelf.Margin = new Padding(0, 0, 1, 0);
                        InitLineBoxControl(cShelf, f3);
                    }
                    else if (sortingLineBox.PARENTLINEBOX == "1" && sortingLineBox.ABANDONPARENT == "1" && sortingLineBox.SublineSeq == 2)
                    {
                        C_Shelf cShelf = CreateShelf(sortingLineBox);
                        cShelves.Add(cShelf.Name, cShelf);
                        
                        cShelf.Margin = new Padding(0, 0, 1, 0);
                        InitLineBoxControl(cShelf, f3);
                    }
                    else if (sortingLineBox.PARENTLINEBOX == "2" && sortingLineBox.ABANDONPARENT == "2" && sortingLineBox.SublineSeq == 1)
                    {
                        C_Shelf cShelf = CreateShelf(sortingLineBox);
                        cShelves.Add(cShelf.Name, cShelf);
                        
                        cShelf.Margin = new Padding(0, 0, 1, 0);
                        InitLineBoxControl(cShelf, f5);
                    }
                    else if (sortingLineBox.PARENTLINEBOX == "2" && sortingLineBox.ABANDONPARENT == "2" && sortingLineBox.SublineSeq == 2)
                    {
                        C_Shelf cShelf = CreateShelf(sortingLineBox);
                        cShelves.Add(cShelf.Name, cShelf);
                        
                        cShelf.Margin = new Padding(0, 0, 1, 0);
                        InitLineBoxControl(cShelf, f5);
                    }
                    else if (sortingLineBox.PARENTLINEBOX == "2" && sortingLineBox.ABANDONPARENT == "1" && sortingLineBox.SublineSeq == 1)
                    {
                        C_Shelf cShelf = CreateShelf(sortingLineBox);
                        cShelves.Add(cShelf.Name, cShelf);
                        
                        cShelf.Margin = new Padding(0, 0, 1, 0);
                        InitLineBoxControl(cShelf, f7);
                    }
                    else if (sortingLineBox.PARENTLINEBOX == "2" && sortingLineBox.ABANDONPARENT == "1" && sortingLineBox.SublineSeq == 2)
                    {

                        C_Shelf cShelf = CreateShelf(sortingLineBox);
                        if (sortingLineBox.LineBoxCode == "123")
                        {
                            cShelf = CreateShelf(sortingLineBox);
                        }
                        else
                        {
                            cShelf = CreateShelf(sortingLineBox);
                        }
                        cShelves.Add(cShelf.Name, cShelf);
                        
                        cShelf.Margin = new Padding(0, 0, 1, 0);
                        InitLineBoxControl(cShelf, f7);
                    }
                }


                
            }

            //如果不能下达任务根据老的列表，给数码管发信号
            SortingTaskIssued sortingTaskIssued = SortingTaskIssued.GetSortingTaskIssued("0");
            if (sortingTaskIssued.PLCFLAG == 1)
            {
                ATOPTagSdk.instance.SetOrderNixielight(SortingLineTaskQueue.GetInstance().SortingLineTasks);
                UpdateLineboxNum();
            }

            //是否显示烟仓容量
            if (chkshowqty.Checked)
            {
                chkshowqty_CheckedChanged(null, null);
            }
        }

        private void InitLineBoxControl(C_Shelf cshelve, FlowLayoutPanel mainflowLayoutPanel)
        {
            
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                if (Convert.ToInt32(cshelve.Lineboxcode) % 2 == 0)
                {
                    flowLayoutPanel.BackColor = System.Drawing.Color.Silver;
                }
                else
                {
                    flowLayoutPanel.BackColor = System.Drawing.Color.Gainsboro;
                }

                flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.None;
                flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                flowLayoutPanel.Size = new System.Drawing.Size(cshelve.Width+1 , f1.Height);
                flowLayoutPanel.WrapContents = false;
                mainflowLayoutPanel.Controls.Add(flowLayoutPanel);

                flowLayoutPanel.Controls.Add(cshelve);
            
        }


        private void chkshowqty_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLineboxCapacity();
        }

        /// <summary>
        /// 更新盘点信息
        /// </summary>
        public void UpdateLineboxCapacity()
        {
            if (chkshowqty.Checked)
            {
                SortingLineBoxList sortingLineBoxList = SortingLineBoxList.GetOverLineBoxQty();
                SortingLineBoxList dynamicsortingLineBoxList = SortingLineBoxList.GetDynamicLineBoxList();

                foreach (SortingLineBox sortingLineBox in sortingLineBoxList)
                {
                    try
                    {
                        cShelves[sortingLineBox.LineBoxCode].ShowCigQty(sortingLineBox.NONQTY-sortingLineBox.PutNum);
                        cShelves[sortingLineBox.LineBoxCode].SetTooltip(sortingLineBox.NONQTY-sortingLineBox.PutNum, sortingLineBox.TOTQTY);
                    }
                    catch (Exception)
                    {
                    }
                }
                foreach (SortingLineBox sortingLineBox in dynamicsortingLineBoxList)
                {
                    try
                    {
                        cShelves[sortingLineBox.LineBoxCode].ShowCigQty(sortingLineBox.NONQTY - sortingLineBox.PutNum);
                        cShelves[sortingLineBox.LineBoxCode].SetTooltip(sortingLineBox.NONQTY - sortingLineBox.PutNum, sortingLineBox.TOTQTY);
                    }
                    catch (Exception)
                    {
                    }
                }



               
                
            }
            else
            {
                foreach (KeyValuePair<string, C_Shelf> cShelf in cShelves)
                {
                    cShelf.Value.ShowCigQty(0);
                }
            }
        }


        private void chkshowname_CheckedChanged(object sender, EventArgs e)
        {
            
            foreach (KeyValuePair<string, C_Shelf> cShelf in cShelves)
            {
                ((C_Shelf)cShelf.Value).ShowCigName(chkshowname.Checked);
            }
        }


        void cSortingTask_OnUpdateCSortingMainNumEvent(object sender, UpdateCSortingMainNumEventArgs e)
        {
            this.Invoke(new Action(UpdateLineboxNum));
        }


        private void UpdateLineboxNum()
        {
            foreach (KeyValuePair<string, C_Shelf> cShelf in cShelves)
            {
                if (cShelf.Value.PickNum != "")
                {
                    cShelf.Value.PickNum = "";
                }
                
            }
            if (ATOPTagSdk.Tags != null)
            {
                foreach (KeyValuePair<int, Tag> cigNum in ATOPTagSdk.Tags)
                {
                    if (cigNum.Value.Qty != 0)
                    {
                        if (cShelves[cigNum.Key.ToString()].PickNum != cigNum.Value.Qty.ToString())
                        {
                            cShelves[cigNum.Key.ToString()].PickNum = cigNum.Value.Qty.ToString();
                        }
                    }
                }
            }
            
        }

        void cSortingTask_OnUpdateCSortingMainCubeEvent(object sender, EventArgs e)
        {
            this.Invoke(new Action(UpdateCubes));
        }

        /// <summary>
        /// 根据小车的数据模型填充小车控件
        /// </summary>
        private void UpdateCubes()
        {
            if (c_Cubes.Count > 0)
            {
                if (SortingLineTaskQueue.GetInstance().CubesModel.Count > 0)
                {
                    for (int i = 0; i < SortingLineTaskQueue.GetInstance().CubesModel.Count; i++)
                    {
                        c_Cubes[i].labcustname.Text = SortingLineTaskQueue.GetInstance().CubesModel[i].Customername;
                        c_Cubes[i].labfinnum.Text = SortingLineTaskQueue.GetInstance().CubesModel[i].FinCignum.ToString() + "条";
                        //如果小车中卷烟数量与总量相同显示为红色
                        if (SortingLineTaskQueue.GetInstance().CubesModel[i].FinCignum == SortingLineTaskQueue.GetInstance().CubesModel[i].TotCignum)
                        {
                            c_Cubes[i].labfinnum.ForeColor = Color.Red;
                        }
                        else
                        {
                            c_Cubes[i].labfinnum.ForeColor = Color.Black;
                        }
                        c_Cubes[i].labindexno.Text = SortingLineTaskQueue.GetInstance().CubesModel[i].Indexno.ToString() + "号";

                        c_Cubes[i].SetTooltip(c_Cubes[i].labcustname.Text,SortingLineTaskQueue.GetInstance().CubesModel[i].SubLineCode, SortingLineTaskQueue.GetInstance().CubesModel[i].TotSortingLineTaskDetails);
                        c_Cubes[i].panelno.Style.BackgroundImage =
                            MonitorMain.Properties.Resources._20140808095108723_easyicon_net_48;
                        c_Cubes[i].panelno.Text = i.ToString() + "号";

                        //if (i == 0)
                        //{
                        //    c_Cubes[i].panelno.Style.BackgroundImage = global::MonitorMain.Properties.Resources.A;
                        //}
                        //else
                        //{
                        //    c_Cubes[i].panelno.Style.BackgroundImage = global::MonitorMain.Properties.Resources.B;
                        //}
                    }

                    
                }
                else
                {

                    foreach (C_Cube cCube in c_Cubes)
                    {
                        cCube.labcustname.Text = "";
                        cCube.labfinnum.Text = "0条";
                        cCube.labfinnum.ForeColor = Color.Black;
                        cCube.labindexno.Text = "0号";
                        cCube.SetTooltip();

                    }
                }

                
            }
            else
            {
                
            }
        }

        void CSortingTask_OnTaskMoved(object sender, EventArgs e)
        {
            if (c_Cubes != null)
            {
                //更新小车上完成的图标
                foreach (C_Cube cCube in c_Cubes)
                {
                    cCube.panelno.Style.BackgroundImage =
                        MonitorMain.Properties.Resources._20140808095338424_easyicon_net_48;
                }
                //更新界面上烟仓的可用库存
                this.Invoke(new Action(UpdateLineboxCapacity));
            }
            
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            ReLoad();
        }

        public void ResetCmain()
        {
            foreach (C_Cube cCube in c_Cubes)
            {
                cCube.labcustname.Text = "无任务";
                cCube.labfinnum.Text = "0条";
                cCube.labindexno.Text = "0号";
                cCube.SetTooltip();
            }

            foreach (KeyValuePair<string, C_Shelf> keyValuePair in cShelves)
            {
                keyValuePair.Value.PickNum = "";
            }
        }

       

        private void btnissued_Click(object sender, EventArgs e)
        {
            //CSortingTask_OnTaskMoved(null, null);
            //SortingLineTaskQueue.GetInstance().Move();

            ////当前AB区的任务已完成
            //SortingTaskIssued sortingTaskIssued = SortingTaskIssued.GetSortingTaskIssued("0");
            //sortingTaskIssued.PLCFLAG = 0;
            //sortingTaskIssued.Save();

            //SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = Application.StartupPath + "\\Sound\\订单完成.wav";
            //player.Load();
            //player.Play();


            //修改到达信息，分户完成
            SortingTaskArrive sortingTaskArrive = SortingTaskArrive.GetSortingTaskArrive("0");
            sortingTaskArrive.Value = "1";
            sortingTaskArrive.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //UpdateLineboxCapacity();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            frmEditCubeLocation frmEditCubeLocation = new frmEditCubeLocation(c_Cubes[1].Width);
            frmEditCubeLocation.OnUpdateCSortingMainCubeEvent += new EventHandler<EventArgs>(cSortingTask_OnUpdateCSortingMainCubeEvent);
            frmEditCubeLocation.ShowDialog();
        }


        public void ReLoad()
        {
            ATOPTagSdk.Tags = null;
            //获取任务列表
            SortingLineTaskQueue.GetInstance().LoadSortingLineTasks();
            LoadLinBox();
            LoadCube();

            chkshowqty.Checked = true;
        }
    }
}
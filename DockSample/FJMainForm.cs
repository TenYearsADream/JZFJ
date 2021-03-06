using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using BusinessLogic;
using BusinessLogic.DisplayBoards;
using BusinessLogic.Download;
using BusinessLogic.SortingProcess;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar;
using MonitorMain;
using MonitorMain.CustomContorl;
using MonitorMain.ToolView;
using PlcContract;
using WinFormDesigner;
using HDWLogic;
using MonitorMain.CustomContorl.Search;
using MonitorMain.Properties;
using AppUtility;
using LY.FuelStationPOS.Protocol;


namespace MonitorMain
{
    public partial class FJMainForm : Office2007RibbonForm
    {

        #region=======================变量定义===================
        //private PropertyWindow m_propertyWindow = new PropertyWindow();
        private DummyOutputWindow m_outputWindow = new DummyOutputWindow();
        private ToolWindow m_toolbox = new ToolWindow("S");
        string m_DefaultLayout = "";
        private Color formcolor = StyleManager.ColorTint;
        private bool checkcolor = false;
        static private FJMainForm _form;
        public CSortingTask cSortingTask;
        public CAbnSortingTask cAbnSortingTask;
        public CBox CBox;
        public CAbnBox CAbnBox;
        public C_SortingMain CSortingMain;
        WaitForm waitForm = new WaitForm();
        private CustomContorl.CLog cLog1;

        #endregion


        #region ===============窗体方法==================
        public static FJMainForm Instance
        {
            get
            {
                if (null == _form)
                    _form = new FJMainForm();
                return _form;
            }
        }

        public void CreateNewDocument(string formname,string formtext,object control)
		{
            foreach (DockContainerItem item in bar1.Items)
            {
                if (item.Name == formname)
                {
                    bar1.SelectedDockContainerItem = item;
                    return;
                }
            }
			// Create new DockContainerItem with the edit control and add it to the barDocuments
            DockContainerItem document = new DockContainerItem(formname, formtext);
			// Create control to host inside of new document
			document.Control= CreateForms.CreateNewDocumentControl(control.ToString());
			bar1.Items.Add(document);
			if(!bar1.Visible)
				bar1.Visible=true;
			bar1.SelectedDockTab=bar1.Items.IndexOf(document);
			bar1.RecalcLayout();
		}

        

        /// <summary>
        /// 错误提示信息输出
        /// </summary>
        /// <param name="referenceControl"></param>
        /// <param name="messageInfo"></param>
        public void Message(BaseItem referenceControl, string messageInfo)
        {
            DevComponents.DotNetBar.Balloon balloon = new DevComponents.DotNetBar.Balloon();
            balloon.Style = eBallonStyle.Office2007Alert;
            balloon.CaptionImage = balloonTipFocus.CaptionImage.Clone() as Image;
            balloon.CaptionText = "        警告";
            balloon.Text = messageInfo;
            balloon.AlertAnimation = eAlertAnimation.TopToBottom;
            balloon.AutoResize();
            balloon.AutoClose = true;
            balloon.AutoCloseTimeOut = 2;
            balloon.Owner = this;
            balloon.Show(referenceControl, false);
        }

        private void SetDockWinTitle()
        {
            ToolBoxBar.Text = "菜单栏";
            //propertyBar.Text = "状态栏";
            OutPutBar.Text = "日志栏";
            dockContainerItem4.Text = "监控窗口";
        }

        /// <summary>
        /// 输出信息显示
        /// </summary>
        /// <param name="logInfo"></param>
        public void SetLog(string logInfo)
        {
            if (m_outputWindow.SystemLog != null)
            {
                m_outputWindow.SystemLog = "\n";
            }
            m_outputWindow.SystemLog += logInfo + " —— " + DateTime.Now;

        }

        #endregion


        public FJMainForm()
        {
            AppUtil apputil = new AppUtil();
            this.Hide();
            InitializeComponent();
            m_toolbox.Dock = DockStyle.Fill;            
            ToolBoxpanelDock.Controls.Add(m_toolbox);
            try
            {
                dotNetBarManager1.LoadLayout(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),
                                                     "config\\DockPanel.config"));
            }
            catch (Exception)
            {}


            var frm = new SLogoForm();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    cSortingTask = new CSortingTask();
                    cSortingTask.OnTaskStatusChanged += new EventHandler<EventArgs>(cSortingTask_OnTaskStatusChanged);
                    cSortingTask.OnTaskStopFinished += new EventHandler<EventArgs>(cSortingTask_OnTaskStopFinished);
                    cAbnSortingTask = new CAbnSortingTask();
                    CBox = new CBox();
                    CAbnBox = new CAbnBox();
                    CSortingMain = new C_SortingMain();
                    labout.Controls.Add(cSortingTask);
                    panelDockContainer1.Controls.Add(cAbnSortingTask);
                    panelDockContainer2.Controls.Add(CBox);
                    panelDockContainer3.Controls.Add(CAbnBox);
                    panelDockContainer4.Controls.Add(CSortingMain);
                      
                    this.cLog1 = new MonitorMain.CustomContorl.CLog();
                    this.OutPutpanelDock.Controls.Add(this.cLog1);
                    this.cLog1.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.cLog1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    this.cLog1.Location = new System.Drawing.Point(0, 0);
                    this.cLog1.Name = "cLog1";
                    this.cLog1.Size = new System.Drawing.Size(1101, 133);
                    this.cLog1.TabIndex = 0;
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                        MessageBox.Show("无法连接到分拣机数据库");
                    else
                        throw;
                }

                Show();
            }
            else
            {
                Process p = Process.GetCurrentProcess();
                p.Kill();
                Application.Exit();
            }            
        }

        
        


        private void MainForm_Load(object sender, System.EventArgs e)
        {
            monitorLog = MonitorLog.NewMonitorLog();
            monitorLog.LOGNAME = "系统信息";
            monitorLog.LOGINFO = "分拣监控系统启动!";
            monitorLog.LOGLOCATION = "系统";
            monitorLog.LOGTYPE = 0;
            monitorLog.Save();

            //LoadDefaultLayout();
            SetDockWinTitle();

            // Load Quick Access Toolbar layout if one is saved from last session...
            LoadQuickAccessToolbar();

            SetSeverStatus();
            //SetOutPort();
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["IsStart"]))
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["IsStart"].Value = true.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                labtaskstatus.Text = "任务已启动";
                StartSorting();                
            }

            //Thread thread = new Thread(SetVision);
            //thread.Start();

            
        }

        

        public void SetVision()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(SetVision));
                }

                labnonvision.Text = SortingLineTask.GetSortingLineTaskDateByNo();
                lababnvision.Text = AbnSortingLineTask.GetSortingLineTaskDate();


                labsernonvision.Text = SortingLineTask.GetServerSortingLineTaskDate();
                labserabnvision.Text = AbnSortingLineTask.GetServerSortingLineTaskDate();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("selectForConnectTimeout"))
                    MessageBox.Show("无法连接到分拣信息服务器数据库");
                else
                    throw;
            }
                if (labnonvision.Text.Trim() != labsernonvision.Text.Trim())
                {
                    labnonvision.ForeColor = Color.Red;
                    labsernonvision.ForeColor = Color.Red;
                }
                else
                {
                    labnonvision.ForeColor = Color.Black;
                    labsernonvision.ForeColor = Color.Black;
                }

                if (lababnvision.Text.Trim() != labserabnvision.Text.Trim())
                {
                    lababnvision.ForeColor = Color.Red;
                    labserabnvision.ForeColor = Color.Red;
                }
                else
                {
                    lababnvision.ForeColor = Color.Black;
                    labserabnvision.ForeColor = Color.Black;
                }
            

        }

        private void SetSeverStatus()
        {
            if (OpcPlc.IsConnected)
            {
                labopcserver.ForeColor = Color.Black;
                labopcserver.Text = "OPC服务器已连接";
            }
        }


        public void SetOutPort()
        {
            if (DownloadData.GetTaskOutPortByLoc() == 0)
            {
                labelItem6.Text = "AB";
            }
            else if (DownloadData.GetTaskOutPortByLoc() == 1)
            {
                labelItem6.Text = "A";
            }
            else if(DownloadData.GetTaskOutPortByLoc() == 2)
            {
                labelItem6.Text = "B";
            }
        }

        void cSortingTask_OnTaskStatusChanged(object sender, EventArgs e)
        {

            if (OutPutBar.InvokeRequired)
            {
                OutPutBar.Invoke(new MethodInvoker(delegate()
                    {
                        BindOutPut(cSortingTask.taskStatus.ToString());
                    }));
            }
            else
            {
                OutPutBar.Text = "输出栏 -- 任务状态:" + cSortingTask.taskStatus;  
            }
        }

        private void BindOutPut(string log)
        {
            OutPutBar.Text = "输出栏 -- 任务状态:" + log;
        }

        

       
        private void LoadQuickAccessToolbar()
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\DevComponents\Ribbon");
            if (key != null)
            {
                try
                {
                    string layout = key.GetValue("MonitorLayout", "").ToString();
                    if (layout != "" && layout != null)
                        ribbonControl1.QatLayout = layout;
                }
                finally
                {
                    key.Close();
                }
            }
        }

        #region ===============窗体控件事件方法==================
        

      

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ribbonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            buttonItem14_Click(null, null);
            StartButton.ClosePopup();
        }

       

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("是否退出当前系统？","退出",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                this.Close();
            }
        }
        
        #endregion


        #region ==================停靠控制=======================


        /// <summary>
        /// Sets the visible property of DockContainerItem and hides the bar if the given item is the last visible item on the bar.
        /// It will also automatically display the bar if bar is not visible.
        /// </summary>
        /// <param name="item">DockContainerItem to set visibility for.</param>
        /// <param name="visible">Indicates the visibility of the item</param>
        private void SetDockContainerVisible(DevComponents.DotNetBar.DockContainerItem item, bool visible)
        {
            if (item == null || item.Visible == visible)
                return;

            int visibleCount = 0;
            DevComponents.DotNetBar.Bar containerBar = item.ContainerControl as DevComponents.DotNetBar.Bar;
            if (containerBar == null)
            {
                // If bar has not been assigned yet just set the visible property and exit
                item.Visible = visible;
                return;
            }

            DotNetBarManager manager = containerBar.Owner as DotNetBarManager;
            if (manager != null)
                manager.SuspendLayout = true;

            try
            {
                foreach (DevComponents.DotNetBar.BaseItem dockItem in containerBar.Items)
                    if (dockItem.Visible) visibleCount++;

                if (visible)
                {
                    item.Visible = true;
                    if (!containerBar.AutoHide && !containerBar.Visible && visibleCount <= 1)
                    {
                        containerBar.Visible = true;
                        if (containerBar.Tag == null)
                        {
                            containerBar.Tag = "";
                        }
                        if (containerBar.Tag.ToString() == "autohide")
                            containerBar.AutoHide = true;
                    }
                }
                else
                {
                    item.Visible = false;
                    if (visibleCount == 1)
                    {
                        // Remember auto-hide setting
                        if (containerBar.AutoHide)
                        {
                            containerBar.AutoHide = false;
                            containerBar.Tag = "autohide";
                        }
                        else
                            containerBar.Tag = "";

                        containerBar.Visible = false;
                    }
                }
            }
            finally
            {
                if (manager != null)
                    manager.SuspendLayout = false;
                else
                    containerBar.RecalcLayout();
            }
        }

        private void SaveDefaultLayout()
        {
            
            ArrayList customBars = new ArrayList();
            foreach (Bar bar in dotNetBarManager1.Bars)
            {
                if (!bar.CustomBar)
                {
                    bar.CustomBar = true;
                    customBars.Add(bar);
                }
            }
            m_DefaultLayout = dotNetBarManager1.LayoutDefinition;
            foreach (Bar bar in customBars)
            {
                bar.CustomBar = false;
            }
            //dotNetBarManager1.SaveLayout(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "config\\DockPanel.config"));
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            SetDockContainerVisible(dockContainerItem1, true);
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            //SetDockContainerVisible(dockContainerItem2, true);
        }

        
        private void btn_opration_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            SetDockContainerVisible(dockContainerItem9, true);
        }


        private void btn_defaultstyle_Click(object sender, EventArgs e)
        {
            dotNetBarManager1.LoadLayout(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),
                                                      "config\\DefaultDockPanel.config"));
            ribbonControl1.Expanded = true;
        }

        private void btn_minstyle_Click(object sender, EventArgs e)
        {
            SetDockContainerVisible(dockContainerItem1, false);
            
            SetDockContainerVisible(dockContainerItem9, false);
            ribbonControl1.Expanded = false;
        }


        private void btn_maxstyle_Click(object sender, EventArgs e)
        {
            SetDockContainerVisible(dockContainerItem1, true);
            //SetDockContainerVisible(dockContainerItem2, true);
            
            SetDockContainerVisible(dockContainerItem9, true);
            ribbonControl1.Expanded = true;
        }

        #endregion

        

        

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }


        # region  窗体换肤样式设置
        private void office07saliver_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007Silver;
            
        }

        private void office07blue_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007Blue;
            
        }

        private void office07black_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007Black;
            
        }

        private void office10saliver_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Silver;
            
        }

        private void office10blue_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Blue;
            
        }

        private void office10black_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Black;
            
        }

        private void vistastaly_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007VistaGlass;
            
        }

        private void win7style_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Windows7Blue;
            
        }

        private void colorPickerDropDown1_SelectedColorChanged(object sender, EventArgs e)
        {
            StyleManager.ColorTint = ((ColorPickerDropDown)sender).SelectedColor;
            formcolor = StyleManager.ColorTint;
        }

        private void colorPickerDropDown1_ColorPreview(object sender, ColorPreviewEventArgs e)
        {
            StyleManager.ColorTint = e.Color;
            checkcolor = false;
        }

        #endregion

        private void office2007StartButton1_Click(object sender, EventArgs e)
        {

        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save Quick Access Toolbar layout if it has changed...
            SaveQuickAccessToolbar();
            SaveDefaultLayout();
	        
            if (MessageBox.Show("是否退出系统？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //删除一个月前的数据
                //DownloadData.DeleteHistoryData();

                try
                {
                    DirectoryInfo TheFolder = new DirectoryInfo(Application.StartupPath + "\\Log\\");
                    //遍历文件夹
                    foreach (FileInfo NextFile in TheFolder.GetFiles())
                    {
                        if (NextFile.LastWriteTime < DateTime.Now.AddDays(-30))
                        {
                            NextFile.Delete();
                        }
                    }
                }
                catch (Exception)
                {


                }


            }
         
        }

        private void SaveQuickAccessToolbar()
        {
            if (ribbonControl1.QatLayoutChanged)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\DevComponents\Ribbon");
                try
                {
                    key.SetValue("MonitorLayout", ribbonControl1.QatLayout);
                }
                finally
                {
                    key.Close();
                }
            }
        }

        private void rad_style1_Click(object sender, EventArgs e)
        {
            
        }

        private void rad_style2_Click(object sender, EventArgs e)
        {
           
        }

        private void rad_style3_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_allcancel_Click(object sender, EventArgs e)
        {
           

        }

        public void buttonItem22_Click(object sender, EventArgs e)
        {
           
        }

        private Control _contentcontrol;
        private decimal m_DocumentCount;
        private decimal m_UniqueBarCount;
        private MonitorLog monitorLog;

        public Control ContentControl
        {
            get { return _contentcontrol; }
            set { _contentcontrol = value; }
        }

        private void btn_showshortcut_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_showshortcut_Click(object sender, EventArgs e)
        {
           
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 18)
            {
                btn_showshortcut_Click(null, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                btn_showshortcut_Click(null, null);
            }

            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        

        public void buttonItem15_Click(object sender, EventArgs e)
        {
            if (!buttonItem15.Checked)
            {                
                buttonItem15.Checked = true;
                buttonItem23.Checked = false;
                waitForm = new WaitForm();
                waitForm.Show();
                Thread thread = new Thread(cSortingTask.StopScanTask);
                thread.IsBackground = true;
                thread.Start();

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["IsStart"].Value = false.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                labtaskstatus.Text = "任务已停止";
            }
        }

        void cSortingTask_OnTaskStopFinished(object sender, EventArgs e)
        {
            if (!this.InvokeRequired)
                waitForm.Close();
            else
                waitForm.Invoke(new Action(WaitFormClose));

        }

        private void WaitFormClose()
        { 
            waitForm.Close();
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            
                if (SortingLineTaskList.IsSortingFinish())
                {
                    //cSortingTask.StopScanTask();
                    DownLoadProcessForm download =
                                new DownLoadProcessForm();
                    download.ShowDialog();
                }
                else
                {

                    DownLoadProcessForm download =
                                new DownLoadProcessForm();
                    download.ShowDialog();                   
                }
            

        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            if (!buttonItem23.Checked)
            {
                if (MessageBox.Show("请检查通道机与立式机补货是否准备完成，开始分拣订单任务？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    StartSorting();
                }
            }
        }

        private void StartSorting()
        {
            buttonItem23.Checked = true;
            buttonItem15.Checked = false;
            if (!SortingLineTask.IsIndexRepetition())
            {
                if (buttonItem23.Checked)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    config.AppSettings.Settings["IsStart"].Value = true.ToString();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    labtaskstatus.Text = "任务已启动";
                    cSortingTask.StartScanTask();
                }
            }
            else
            {
                MessageBox.Show("当前分拣任务存在重复的顺序号,无法开始分拣！");
            }
        }


        private void buttonItem24_Click(object sender, EventArgs e)
        {
            if (!buttonItem24.Checked)
            {
                if (SortingLineTaskList.IsSortingFinish())
                {
                    SortingFinish();
                    MessageBox.Show("分拣任务结束完成！");
                }
                else
                {
                    MessageBox.Show("分拣未完成，无法结束！");
                }
            }
            
        }

        public void SortingFinish()
        {
            SortingLineTask.UploadSortingStatus(2);

            buttonItem23.Checked = false;
            buttonItem15.Checked = false;

            buttonItem24.Enabled = false;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["IsStart"].Value = false.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            labtaskstatus.Text = "任务已停止";
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void bar1_DockTabClosing(object sender, DockTabClosingEventArgs e)
        {
            if (e.DockContainerItem.Equals(dockContainerItem6) || e.DockContainerItem.Equals(dockContainerItem5) || e.DockContainerItem.Equals(dockContainerItem2) || e.DockContainerItem.Equals(dockContainerItem10))
            {
                e.Cancel = true;
                balloonTipFocus.SetBalloonCaption((Control)sender,"提示");
                balloonTipFocus.SetBalloonText((Control)sender, "无法关闭分拣任务窗口");
                balloonTipFocus.ShowBalloon((Control) sender);
                
            }
            else
            {
                bar1.Items.Remove(e.DockContainerItem);
            }
        }

        private void buttonItem12_Click_2(object sender, EventArgs e)
        {
            ToolBoxBar.AutoHide = false;
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            LedForm ledForm = new LedForm();
            ledForm.Show();
        }

        private void buttonItem18_Click_1(object sender, EventArgs e)
        {
            CigTransfer cigTransfer = new CigTransfer();
            cigTransfer.ShowDialog();
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            OutPortTransferForm outPortTransfer = new OutPortTransferForm();
            outPortTransfer.ShowDialog();

        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonItem63_Click(object sender, EventArgs e)
        {
            buttonItem16_Click(null, null);
            StartButton.ClosePopup();
        }

        private void buttonItem64_Click(object sender, EventArgs e)
        {
            buttonItem18_Click_1(null, null);
            StartButton.ClosePopup();
        }

        private void buttonItem65_Click(object sender, EventArgs e)
        {
            buttonItem20_Click(null, null);
            StartButton.ClosePopup();
        }

        private void MenuItem_DoubleClick(object sender, EventArgs e)
        {
            CreateNewDocument(((BaseItem)sender).Name, ((BaseItem)sender).Text, ((BaseItem)sender).Tag);
            this.StartButton.ClosePopup();
        }

        private void CSortingTaskSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            ribbonControl1.Expanded = !ribbonControl1.Expanded;
            if (buttonItem1.Tag == "4444444444")
            {
                buttonItem1.Image = Resources._20141211105943101_easyicon_net_32;
                buttonItem1.Tag = "2962962963";
            }
            else
            {
                buttonItem1.Image =
                    Resources._20141211105933692_easyicon_net_32;
                buttonItem1.Tag = "4444444444";
            }
        }

        private void FJMainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        private void btnledauto_Click(object sender, EventArgs e)
        {
            //ledautoform = new LedForm();
            //btnledauto.Checked = !btnledauto.Checked;

            //if (btnledauto.Checked)
            //{
            //    ledtime.Start();
            //}
            //else
            //{
            //    ledtime.Stop();
            //}
            CCigInfoSearch cCigInfoSearch = new CCigInfoSearch();
            cCigInfoSearch.Show();

        }

        
        private LedForm ledautoform;
        bool isshowname = false;
        private void ledtime_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    isshowname = !isshowname;
            //    if (isshowname)
            //        ledautoform.CreateCigNamePic();
            //    else
            //        ledautoform.CreateCigNumPic();

            //    ledautoform.SendPic();
            //}
            //catch
            //{ }
        }


    }
}
  
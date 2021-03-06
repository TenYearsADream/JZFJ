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
using BusinessLogic.INTASKS;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar;
using MonitorMain;
//using MonitorMain.ToolView;
using MonitorMain.CustomContorl;
using MonitorMain.ToolView;
using PlcContract;
using WinFormDesigner;


namespace MonitorMain
{
    public partial class BHMainForm : Office2007RibbonForm
    {

        #region=======================变量定义===================
        //private PropertyWindow m_propertyWindow = new PropertyWindow();
        private DummyOutputWindow m_outputWindow = new DummyOutputWindow();
        private ToolWindow m_toolbox = new ToolWindow("B");
        string m_DefaultLayout = "";
        private Color formcolor = StyleManager.ColorTint;
        private bool checkcolor = false;
        static BHMainForm _form;
        private CInTask cinTask;


        #endregion


        #region ===============窗体方法==================
        public static BHMainForm Instance
        {
            get
            {
                if (null == _form)
                    _form = new BHMainForm();
                return _form;
            }
        }

        public void CreateNewDocument(string formname,string formtext,object controlname)
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
			document.Control= CreateForms.CreateNewDocumentControl( controlname.ToString());
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


        public BHMainForm()
        {
            InitializeComponent();
            m_toolbox.Dock = DockStyle.Fill;
            ToolBoxpanelDock.Controls.Add(m_toolbox);
            //dotNetBarManager1.LoadLayout(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"config\\DockPanel.config"));

            cinTask = new CInTask();
            cinTask.OnTaskStopFinished += new EventHandler<EventArgs>(cinTask_OnTaskStopFinished);
            panelDockContainer4.Controls.Add(cinTask);
            

            

            var frm = new SLogoForm();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
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

            labvision.Text = InTask.GetInTaskDate();
            //SetVision();
            monitorLog = MonitorLog.NewMonitorLog();
            monitorLog.LOGNAME = "系统信息";
            monitorLog.LOGINFO = "补货监控系统启动!";
            monitorLog.LOGLOCATION = "系统";
            monitorLog.LOGTYPE = 0;
            monitorLog.Save();
            //LoadDefaultLayout();
            SetDockWinTitle();
            SetLog(global::MonitorMain.Properties.Resources.StartUpTime + DateTime.Now);

            // Load Quick Access Toolbar layout if one is saved from last session...
            LoadQuickAccessToolbar();
            
            SetSeverStatus();

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["IsStart"]))
            {
                buttonItem23.Checked = true;
                StartInTask();
                labtaskstatus.Text = "任务已启动";
            }
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
        

        private void buttonItem12_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ribbonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            SuspendLayout();
           
            ResumeLayout(false);
            
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
            dotNetBarManager1.SaveLayout(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "config\\DockPanel.config"));
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            SetDockContainerVisible(dockContainerItem1, true);
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            
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
            
            SetDockContainerVisible(dockContainerItem9, true);
            ribbonControl1.Expanded = true;
        }

        #endregion



        public void SetVision()
        {
            labvision.Text = InTask.GetInTaskDate();
            //labservision.Text = InTask.GetServerInTaskDate();


            //if (labvision.Text.Trim() != labservision.Text.Trim())
            //{
            //    labelItem4.ForeColor = Color.Red;
            //    labelItem5.ForeColor = Color.Red;
            //    labvision.ForeColor = Color.Red;
            //    labservision.ForeColor = Color.Red;
            //}
            //else
            //{
            //    labelItem4.ForeColor = Color.Black;
            //    labelItem5.ForeColor = Color.Black;
            //    labvision.ForeColor = Color.Black;
            //    labservision.ForeColor = Color.Black;
            //}

        }

        private void SetSeverStatus()
        {
            if (OpcPlc.IsConnected)
            {
                labopcserver.ForeColor = Color.Black;
                labopcserver.Text = "OPC服务器已连接";
            }
        }

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
            //SetStartbuttonmenuVisible();
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

        

        private void rad_style1_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
           
        }

        private void rad_style2_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            
        }

        private void rad_style3_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            
        }

        private void ribbonBar6_LaunchDialog(object sender, EventArgs e)
        {
           
        }

        private void colorPickerDropDown1_PopupClose(object sender, EventArgs e)
        {
            if (!checkcolor)
            {
                StyleManager.ColorTint = formcolor;
            }
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
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                btn_showshortcut_Click(null, null);
            }
        }

        private void btn_uscreen_Click(object sender, EventArgs e)
        {
        }

        private void btn_lscreen_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonItem12_Click_1(object sender, EventArgs e)
        {
            
        }

        //打开停止等待窗口
        private WaitForm waitForm;
        private void buttonItem15_Click(object sender, EventArgs e)
        {
            if (!buttonItem15.Checked)
            {
                buttonItem15.Checked = true;
                buttonItem23.Checked = false;
                waitForm = new WaitForm();
                waitForm.Show();
                Thread thread = new Thread(cinTask.StopScanTask);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        //线程停止后关闭等待窗口
        void cinTask_OnTaskStopFinished(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["IsStart"].Value = false.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            labtaskstatus.Text = "任务已停止";
            waitForm.Close();
        }


        private void buttonItem23_Click(object sender, EventArgs e)
        {
            if (!buttonItem23.Checked)
            {
                if (MessageBox.Show("是否准备完成，开始补货任务？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonItem23.Checked = true;
                    StartInTask();
                }
            }
        }

        private void StartInTask()
        {
            buttonItem23.Checked = true;
            buttonItem15.Checked = false;

            if (!InTask.IsIndexRepetition())
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["IsStart"].Value = true.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                labtaskstatus.Text = "任务已启动";
                cinTask.StartScanTask();
            }
            else
            {
                MessageBox.Show("当前补货任务存在重复的顺序号,无法开始！");
            }
        }



        public void InTaskFinish()
        {           

            buttonItem23.Checked = false;
            buttonItem15.Checked = false;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["IsStart"].Value = false.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }



        private void buttonItem23_CheckedChanged(object sender, EventArgs e)
        {
            
        }


        private void buttonItem26_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void buttonItem18_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            InTaskFinish();
        }

        
        private void bar1_DockTabClosing(object sender, DockTabClosingEventArgs e)
        {
            
            if (e.DockContainerItem.Equals(dockContainerItem6))
            {
                e.Cancel = true;
                balloonTipFocus.SetBalloonCaption((Control)sender, "提示");
                balloonTipFocus.SetBalloonText((Control)sender, "无法关闭补货任务窗口");
                balloonTipFocus.ShowBalloon((Control)sender);
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

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcessesByName("MonitorMain");
            
            foreach (var item in process)
            {
                if (item.Id != Process.GetCurrentProcess().Id)
                {
                    item.Kill();
                }
            }
        }
    }
}
  
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO;
using KeerSolutions.MobileCommerce.AutoUpdate.AutoUpdateService;
using DevComponents.DotNetBar;

namespace KeerSolutions.MobileCommerce.AutoUpdate
{
    /// <summary>
    /// 更新窗体
    /// </summary>
    public partial class UpdateForm : Office2007Form
    {
        private int Listi = 0;
        #region Ctor
        /// <summary>
        /// 构造函数
        /// </summary>
        public UpdateForm()
        {
            InitializeComponent();


            btnFinish.Visible = false;  //完成 按钮隐藏
            btnNext.Visible = false;   //下一步 按钮隐藏
            lbState.Visible = false;   //消息提示 隐藏
            pbDownFile.Visible = false;  //进度条隐藏
            btnCheckUpdate.Enabled = false; //检测更新不可用
        }
        #endregion

        #region  窗体初始加载
        /// <summary>
        /// 窗体初始加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateForm_Load(object sender, EventArgs e)
        {
            //检测是否有更新
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion

        /// <summary>
        /// 检测更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckUpdate_Click(object sender, EventArgs e)
        {
            lvUpdateList.Items.Clear();
            lvUpdateList.Tag = null;
            btnFinish.Visible = false;  //完成 按钮隐藏
            btnNext.Visible = false;   //下一步 按钮隐藏
            lbState.Visible = false;   //消息提示 隐藏
            pbDownFile.Visible = false;  //进度条隐藏
            btnCheckUpdate.Enabled = false; //检测更新不可用
            //检测是否有更新
            backgroundWorker1.RunWorkerAsync();
        }

        private string serverUpdatePath = string.Empty;

        #region 下一步
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            //if(string.Compare(string))
            //if ()
            //{
            //    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "CopyFiles.exe", tempDirectoryPath);
            //    Process.GetCurrentProcess().Kill();
            //}

            Thread threadDown = new Thread(new ThreadStart(DownUpdateFile));
            threadDown.IsBackground = true;
            threadDown.Start();
        }

        private delegate void MyInvoke();
        private void DownUpdateFile()
        {
            if (lvUpdateList.InvokeRequired)
            {
                lvUpdateList.Invoke(new MyInvoke(DownUpdateFile), null);
            }
            else
            {
                if (string.IsNullOrEmpty(serverUpdatePath))
                {
                    MessageBox.Show("获取更新路径失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; ;
                }
                if (lvUpdateList.Tag == null)
                {
                    MessageBox.Show("获取文件信息失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; ;
                }
                ShowControlEnabled(btnCheckUpdate, false);
                ShowControlEnabled(lnkSetting, false);
                ShowControlEnabled(btnNext, false);
                ShowControlEnabled(btnCancel, false);
                string tempDirectoryPath = Path.Combine(Environment.CurrentDirectory, "hmsalesAutoUpdate");
                if (Directory.Exists(tempDirectoryPath))
                {
                    Directory.Delete(tempDirectoryPath, true);
                }
                Directory.CreateDirectory(tempDirectoryPath);
                List<string> liseFiles = (List<string>)lvUpdateList.Tag;
                pbDownFile.Maximum = lvUpdateList.Items.Count;
                for (int i = 0; i < lvUpdateList.Items.Count; i++)
                {
                    Listi = i;
                    long fileLength = 0;
                    lbState.Text = "正在下载更新文件,请稍后...";
                    pbDownFile.Value = 0;
                    
                    try
                    {
                        string strUrl = serverUpdatePath + "/" + liseFiles[i];

                        CWebClient webClient = new CWebClient();
                        webClient.Sequence = i;
                        if (webClient.IsBusy) //是否存在正在进行中的Web请求
                        {
                            Application.DoEvents();
                        }
                        //为webClient添加事件
                        webClient.DownloadProgressChanged +=
                            new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                        webClient.DownloadFileCompleted +=
                            new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                        //开始下载
                        webClient.DownloadFileAsync(new Uri(strUrl), tempDirectoryPath + "/" + liseFiles[i]);

                    }
                    catch(Exception ex)
                    {
                        ShowControlEnabled(btnCheckUpdate, true);
                        ShowControlEnabled(lnkSetting, true);
                        ShowControlEnabled(btnNext, true);
                        ShowControlEnabled(btnCancel, true);
                        MessageBox.Show("更新文件下载失败！" + ex.Message.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                try
                {
                    //if (File.Exists(tempDirectoryPath + "\\AutoUpdate.exe"))
                    //{
                    //    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "CopyFiles.exe", tempDirectoryPath);
                    //    Process.GetCurrentProcess().Kill();
                    //}
                    //else
                    //{


                    while (pbDownFile.Value < pbDownFile.Maximum)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }


                        //执行Sql
                        ExecuteSql(tempDirectoryPath + "\\ExecuteSql.sql");
                        lbState.Text = "正在复制文件,请稍后...";
                        //拷贝
                        CopyFile(tempDirectoryPath, AppDomain.CurrentDomain.BaseDirectory);
                        System.IO.Directory.Delete(tempDirectoryPath, true);
                        InvalidateControl();
                        this.Cursor = Cursors.Default;
                    //}
                }
                
                catch (Exception ex)
                {
                    ShowControlEnabled(btnCheckUpdate, true);
                    ShowControlEnabled(lnkSetting, true);
                    ShowControlEnabled(btnNext, true);
                    ShowControlEnabled(btnCancel, true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                lbState.Text = "下载被取消！";
            else
                lbState.Text = "下载完成！";
            pbDownFile.Value++;
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lvUpdateList.Items[((CWebClient)sender).Sequence].SubItems[1].Text = e.ProgressPercentage.ToString() + "%";
            lvUpdateList.Items[((CWebClient)sender).Sequence].SubItems[2].Text = e.TotalBytesToReceive / 1000 + "K";
        }

        /// <summary>
        /// 执行更新数据库操作
        /// </summary>
        /// <param name="sqlpath"></param>
        private void ExecuteSql(string sqlpath)
        {
            //if (File.Exists(sqlpath))
            //{
            //    lbState.Text = "正在执行数据库操作,请稍后...";
            //    using (var connection = new SQLiteConnection(Database.MobileCommerceConnection))
            //    {
            //        connection.Open();
            //        using (var tran = connection.BeginTransaction())
            //        {
            //            string[] fileline = File.ReadAllLines(sqlpath, Encoding.GetEncoding("GB2312"));

            //            try
            //            {
            //                for (int i = 0; i < fileline.Length; i++)
            //                {
            //                    string sql = fileline[i];
                                
            //                    try
            //                    {
            //                        if (sql.Trim() != "")
            //                        {
            //                            var command = new SQLiteCommand(sql, connection);
            //                            command.ExecuteNonQuery();
            //                        }
            //                    }
            //                    catch (SQLiteException exception)
            //                    {
            //                        if (exception.Message.ToLower().Contains("table") && exception.Message.ToLower().Contains("already exists"))
            //                        {
                                        
            //                        }
            //                        else if (exception.Message.ToLower().Contains("duplicate column name"))
            //                        {
                                        
            //                        }
            //                        else
            //                        {
            //                            throw;
            //                        }
            //                    }
                                
            //                }
            //                tran.Commit();
            //            }
            //            catch (Exception)
            //            {
            //                tran.Rollback();
            //                throw;
            //            }
            //        }
            //    }
            //}
            ////File.Delete(sqlpath);
        }

        //复制文件;
        public void CopyFile(string sourcePath, string objPath)
        {
            char[] split = @"\".ToCharArray();
            if (!Directory.Exists(objPath))
            {
                Directory.CreateDirectory(objPath);
            }
            string[] files = Directory.GetFiles(sourcePath);
            for (int i = 0; i < files.Length; i++)
            {
                string[] childfile = files[i].Split('\\');
                File.Copy(files[i], objPath + @"\" + childfile[childfile.Length - 1], true);
            }
            string[] dirs = Directory.GetDirectories(sourcePath);
            for (int i = 0; i < dirs.Length; i++)
            {
                string[] childdir = dirs[i].Split('\\');
                CopyFile(dirs[i], objPath + @"\" + childdir[childdir.Length - 1]);
            }
        }

        //重新绘制窗体部分控件属性
        private void InvalidateControl()
        {
            ShowControlEnabled(btnCheckUpdate, true);
            ShowControlEnabled(lnkSetting, true);
            ShowControlEnabled(btnNext, true);
            ShowControlEnabled(btnCancel, true);
            lbState.Text = "更新完成！";
            btnNext.Visible = false;
            btnCancel.Visible = false;
            btnFinish.Location = btnCancel.Location;
            btnFinish.Visible = true;
        }
        #endregion

        #region 检测更新，显示待更新文件
        /// <summary>
        ///  检测更新，显示待更新文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string strMsg = string.Empty;
            string updatePath = string.Empty;
            List<string> listFiles = CheckFilesForUpdate(out updatePath, out strMsg);
            if (listFiles == null)
            {
                if (string.IsNullOrEmpty(strMsg))
                {
                    ShowControlVisible(lbState, false);
                    ShowControlTextDefaultColor(btnCancel, "关闭");
                    pboxCheck.Image = Properties.Resources.checkover;
                    ShowControlTextDefaultColor(lblCheck, "更新检查完毕");
                    ShowControlTextDefaultColor(lblMessage, "已经是最新版本了,不需要更新!");
                }
                else
                {
                    pboxCheck.Image = Properties.Resources.checkover;
                    ShowControlTextDefaultColor(lblCheck, "检测更新失败");
                    ShowControlTextDefaultColor(lblMessage, string.Empty);
                    MessageBox.Show(strMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lvUpdateList.Tag = null;
            }
            else
            {
                foreach (string str in listFiles)
                {
                    string[] strItem = { str, string.Empty, string.Empty };
                    AddItems(new ListViewItem(strItem));
                }
                serverUpdatePath = updatePath; //保存待下载文件路径
                lvUpdateList.Tag = listFiles; //保存待下载文件列表
                ShowControlVisible(btnNext, true);
                ShowControlVisible(lbState, true);
                ShowControlVisible(pbDownFile, true);
                pboxCheck.Image = Properties.Resources.checkover;
                ShowControlTextDefaultColor(lblCheck, "更新检查完毕");
                ShowControlTextDefaultColor(lblMessage, "发现" + listFiles.Count.ToString() + "个可更新项!");
            }
        }
        #endregion

        #region 获取更新文件完成
        /// <summary>
        /// 获取更新文件完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCheckUpdate.Enabled = true; //检测更新不可用
        }
        #endregion

        #region 点击完成按钮
        /// <summary>
        /// 点击完成按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "MonitorMain.exe"))
            {
                Environment.Exit(0);
            }
            if (MessageBox.Show("更新完成,要马上启动应用程序吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Process p = new Process();
                p.StartInfo.FileName = "MonitorMain.exe";//需要启动的程序名       
                //p.StartInfo.Arguments = "-x     sourceFile.Arj     c:\temp";//启动参数       
                p.Start();//启动       
            }
            Environment.Exit(0);
        }
        #endregion

        #region 检测是否有文件更新，并返回文件列表和更新地址
        /// <summary>
        /// 通过webservice获取服务器上的文件信息,检测本地，返回待更新文件列表
        /// </summary>
        /// <param name="updatePath">待更新文件的地址</param>
        /// <returns></returns>
        public List<string> CheckFilesForUpdate(out string updatePath, out string strMsg)
        {
            strMsg = string.Empty;
            updatePath = string.Empty;
            try
            {
                AutoUpdateService.AutoUpdateSoapClient sc = new AutoUpdateSoapClient();
                AutoUpdateService.UpdateFileInfo[] list = sc.GetAllUpdateFileInfo();
                if (list.Length == 0)
                    return null;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (AutoUpdateService.UpdateFileInfo u in list)
                {
                    dic.Add(u.Name, u.Version);
                }
                string servicePath = sc.Endpoint.Address.ToString();
                updatePath = servicePath.Substring(0, servicePath.LastIndexOf('/')) + "/Update";
                //updatePath = Path.Combine(servicePath.Substring(0, servicePath.LastIndexOf('/')), "Update");
                if (dic.Count == 0 || updatePath.Length == 0)
                {//无更新
                    return null;
                }
                List<string> updateFiles = null;
                string locaDirlPath = AppDomain.CurrentDomain.BaseDirectory;
                string localFilePath = string.Empty;
                updateFiles = new List<string>();
                FileVersionInfo fvi = null;
                foreach (var temp in dic)
                {
                    localFilePath = Path.Combine(locaDirlPath, temp.Key);

                    if (string.IsNullOrEmpty(temp.Value) || !File.Exists(localFilePath))
                    {
                        string strUrl = updatePath + "/" + temp.Key.Trim();
                        WebRequest webReq = WebRequest.Create(strUrl);
                        WebResponse webRes = webReq.GetResponse();
                        
                        long totalBytes = webRes.ContentLength; //从WEB响应得到总字节数

                        if (File.Exists(localFilePath))
                        {
                            FileInfo fileInfo = new FileInfo(localFilePath);
                            if (totalBytes == fileInfo.Length)
                            {
                                webRes.Close();
                                continue;
                            }
                            else
                            {
                                webRes.Close();
                                updateFiles.Add(temp.Key);
                            }
                        }
                        else
                        {
                            webRes.Close();
                            updateFiles.Add(temp.Key);
                        }
                        
                        
                    }
                    else
                    {
                        fvi = FileVersionInfo.GetVersionInfo(localFilePath);
                        if (string.Compare(temp.Value, fvi.FileVersion, false) == 0)
                            continue;
                        else
                            updateFiles.Add(temp.Key);
                    }
                }
                if (updateFiles.Count == 0)
                {//无更新
                    return null;
                }
                return updateFiles;
            }
            catch (Exception ex)
            {
                strMsg = "检测更新失败，原因：" + ex.Message;
                return null;
            }
        }
        #endregion

        #region 委托方法
        //向列表中添加文件
        private delegate void MyInvokelist(ListViewItem lvwItem);
        public void AddItems(ListViewItem lvwItem)
        {
            if (lvUpdateList.InvokeRequired)
            {
                lvUpdateList.Invoke(new MyInvokelist(AddItems), new object[] { lvwItem });
            }
            else
            {
                lvUpdateList.Items.Add(lvwItem);
            }
        }
        //标记控件显示或隐藏
        private delegate void MyInvokeShowControlVisible(Control control, bool visible);
        private void ShowControlVisible(Control control, bool visible)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MyInvokeShowControlVisible(ShowControlVisible), new object[] { control, visible });
            }
            else
            {

                control.Visible = visible;
            }
        }
        //标记控件是否可用
        private delegate void MyInvokeShowControlEnabled(Control control, bool enabled);
        private void ShowControlEnabled(Control control, bool enabled)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MyInvokeShowControlVisible(ShowControlEnabled), new object[] { control, enabled });
            }
            else
            {
                control.Enabled = enabled;
            }
        }
        //指定控件显示的文字内容
        private delegate void MyInvokeShowControlTextDefaultColor(Control control, string strText);
        private void ShowControlTextDefaultColor(Control control, string strText)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MyInvokeShowControlTextDefaultColor(ShowControlTextDefaultColor), new object[] { control, strText });
            }
            else
            {

                control.Text = strText;
            }
        }
        #endregion

        #region 关闭窗体
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strIpAddress = string.Empty;
            string port = "80";
            try
            {
                AutoUpdateService.AutoUpdateSoapClient sc = new AutoUpdateSoapClient();
                string servicePath = sc.Endpoint.Address.ToString();
                string strIpAndPort = servicePath.Substring(0, servicePath.LastIndexOf('/')).Substring(7);
                string[] strArr = strIpAndPort.Split(':');
                strIpAddress = strArr[0];
                if (strArr.Length > 1)
                    port = strArr[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new SettingForm(strIpAddress, port).ShowDialog();

        }

        
        private void lnkSetting_Click(object sender, EventArgs e)
        {
            string strIpAddress = string.Empty;
            string port = "80";
            try
            {
                AutoUpdateService.AutoUpdateSoapClient sc = new AutoUpdateSoapClient();
                string servicePath = sc.Endpoint.Address.ToString();
                string strIpAndPort = servicePath.Substring(0, servicePath.LastIndexOf('/')).Substring(7);
                string[] strArr = strIpAndPort.Split(':');
                strIpAddress = strArr[0];
                if (strArr.Length > 1)
                    port = strArr[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new SettingForm(strIpAddress, port).ShowDialog();
        }

    }
}

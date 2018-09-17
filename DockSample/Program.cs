using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using AppUtility;
using BusinessLogic.Configuration;
using DevComponents.DotNetBar;

namespace MonitorMain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MessageBox.UseSystemLocalizedString = true;
            //MessageBox.EnableGlass = false;

            bool createNew;

            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {

                if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "分拣")
                {

                    Process[] processes = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
                    string currname = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    
                    foreach (Process process in processes)
                    {
                        string name = process.MainModule.FileName;
                        
                        if (currname == name && process.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                        {
                            MessageBox.Show("程序已经在运行中...");
                            System.Threading.Thread.Sleep(1000);
                            System.Environment.Exit(1);
                        }
                    }
                    try
                    {
                        AppUtility.AppUtil.SysMode = "s";
                        Application.Run(FJMainForm.Instance);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                        {
                            MessageBox.Show("无法连接到分机拣数据库");
                        }
                        else
                            MessageBox.Show(ex.Message);
                    }
                }


                if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "补货")
                {
                    AppUtility.AppUtil.SysMode = "i";
                    Application.Run(BHMainForm.Instance);
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "出口屏1")
                {
                    Process[] processes = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
                    string currname = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    foreach (Process process in processes)
                    {
                        string name = process.MainModule.FileName;
                        if (currname == name && process.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                        {
                            MessageBox.Show("程序已经在运行中...");
                            System.Threading.Thread.Sleep(1000);
                            System.Environment.Exit(1);
                        }
                    }
                    Application.Run(new OutPortForm("1"));
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "合单屏")
                {
                    Process[] processes = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
                    string currname = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    foreach (Process process in processes)
                    {
                        string name = process.MainModule.FileName;
                        if (currname == name && process.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                        {
                            //MessageBox.Show("程序已经在运行中...");
                            System.Threading.Thread.Sleep(1000);
                            System.Environment.Exit(1);
                        }
                    }
                    Application.Run(new PutPortForm("1"));
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "补货屏")
                {
                    Application.Run(new InPortForm());
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "品牌屏")
                {
                    Application.Run(new DisplayCigName());
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "作业看板")
                {
                    Application.Run(new EfficeForm());
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "烟仓")
                {
                    Application.Run(new DisLineBox());
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "混合仓")
                {
                    Application.Run(new DynamicBoxForm());
                }
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            //创建日志记录组件实例
            //log4net.ILog log = log4net.LogManager.GetLogger(e.GetType());
            //记录错误日志
            //log.Error("error", new Exception(str));
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            //创建日志记录组件实例
            //log4net.ILog log = log4net.LogManager.GetLogger(e.GetType());
            //记录错误日志
            //log.Error("error", new Exception(str));
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
    }
}
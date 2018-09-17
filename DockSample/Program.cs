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
            //����Ӧ�ó������쳣��ʽ��ThreadException����
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //����UI�߳��쳣
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //�����UI�߳��쳣
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MessageBox.UseSystemLocalizedString = true;
            //MessageBox.EnableGlass = false;

            bool createNew;

            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {

                if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "�ּ�")
                {

                    Process[] processes = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
                    string currname = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    
                    foreach (Process process in processes)
                    {
                        string name = process.MainModule.FileName;
                        
                        if (currname == name && process.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                        {
                            MessageBox.Show("�����Ѿ���������...");
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
                            MessageBox.Show("�޷����ӵ��ֻ������ݿ�");
                        }
                        else
                            MessageBox.Show(ex.Message);
                    }
                }


                if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "����")
                {
                    AppUtility.AppUtil.SysMode = "i";
                    Application.Run(BHMainForm.Instance);
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "������1")
                {
                    Process[] processes = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
                    string currname = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    foreach (Process process in processes)
                    {
                        string name = process.MainModule.FileName;
                        if (currname == name && process.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                        {
                            MessageBox.Show("�����Ѿ���������...");
                            System.Threading.Thread.Sleep(1000);
                            System.Environment.Exit(1);
                        }
                    }
                    Application.Run(new OutPortForm("1"));
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "�ϵ���")
                {
                    Process[] processes = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
                    string currname = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    foreach (Process process in processes)
                    {
                        string name = process.MainModule.FileName;
                        if (currname == name && process.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                        {
                            //MessageBox.Show("�����Ѿ���������...");
                            System.Threading.Thread.Sleep(1000);
                            System.Environment.Exit(1);
                        }
                    }
                    Application.Run(new PutPortForm("1"));
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "������")
                {
                    Application.Run(new InPortForm());
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "Ʒ����")
                {
                    Application.Run(new DisplayCigName());
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "��ҵ����")
                {
                    Application.Run(new EfficeForm());
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "�̲�")
                {
                    Application.Run(new DisLineBox());
                }
                if (ConfigurationSettings.AppSettings["Mode"].ToUpper() == "��ϲ�")
                {
                    Application.Run(new DynamicBoxForm());
                }
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            //������־��¼���ʵ��
            //log4net.ILog log = log4net.LogManager.GetLogger(e.GetType());
            //��¼������־
            //log.Error("error", new Exception(str));
            MessageBox.Show(str, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            //������־��¼���ʵ��
            //log4net.ILog log = log4net.LogManager.GetLogger(e.GetType());
            //��¼������־
            //log.Error("error", new Exception(str));
            MessageBox.Show(str, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        /// <summary>
        /// �����Զ����쳣��Ϣ
        /// </summary>
        /// <param name="ex">�쳣����</param>
        /// <param name="backStr">�����쳣��Ϣ����exΪnullʱ��Ч</param>
        /// <returns>�쳣�ַ����ı�</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************�쳣�ı�****************************");
            sb.AppendLine("������ʱ�䡿��" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("���쳣���͡���" + ex.GetType().Name);
                sb.AppendLine("���쳣��Ϣ����" + ex.Message);
                sb.AppendLine("����ջ���á���" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("��δ�����쳣����" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.IO;



namespace AppUtility
{
    using System.Net.Sockets;

    /// <summary>
    /// 公用的常量、变量、方法等 
    /// 所有层都可以调用，不可被继承
    /// </summary>
    public sealed class AppUtil
    {
        /// <summary>
        /// 本地连接字符串
        /// </summary>
        public static string _LocalConnectionString = "Server=" + GetAppConfig("LocationIP") + ";Port=" + GetAppConfig("LocationPort") +
                                      ";Database=" + GetAppConfig("LocationDatabase") + ";Uid=" +
                                      GetAppConfig("LocationUid") + ";Pwd=" + GetAppConfig("LocationPwd") + ";Allow User Variables=True"; //本地数据库连接

        /// <summary>
        /// 信息系统连接字符串
        /// </summary>
        public static string _FjInfoConnectionString = "Server=" + GetAppConfig("ServerIP") + ";Database=" + GetAppConfig("ServerDatabase") + ";Uid=" +
                                      GetAppConfig("ServerUid") + ";Pwd=" + GetAppConfig("ServerPwd") + ";Connect Timeout=30"; //本地数据库

        /// <summary>
        /// 打标机字符串
        /// </summary>
        public static string _TBConnectionString = "Server=" + GetAppConfig("FirstOutIP") + ";Database=" + GetAppConfig("FirstOutPort") + ";Uid=sa;Pwd=sa;"; //本地数据库

        ///// <summary>
        ///// Led Com口号
        ///// </summary>
        //public static string _Led = ConfigurationManager.AppSettings["LedCom"].ToString();

        /// <summary>
        /// opc服务器的IP
        /// </summary>
        public static string _Opc = ConfigurationManager.AppSettings["Opc"].ToString();

        /// <summary>
        /// 出口1IP
        /// </summary>
        public static string _FirstOutIP = ConfigurationManager.AppSettings["FirstOutIP"].ToString();

        /// <summary>
        /// 出口2的IP
        /// </summary>
        public static string _SecondOutIP = ConfigurationManager.AppSettings["SecondOutIP"].ToString();

        /// <summary>
        /// 出口1端口
        /// </summary>
        public static string _FirstOutPort = ConfigurationManager.AppSettings["FirstOutPort"].ToString();

        /// <summary>
        /// 出口2的端口
        /// </summary>
        public static string _SecondOutPort = ConfigurationManager.AppSettings["SecondOutPort"].ToString();

        /// <summary>
        /// 出口1的Socket连接状态
        /// </summary>
        public static bool _SocketFirstOutConnected = false; //socket连接是否连接上

        /// <summary>
        /// 出口2的Socket连接状态
        /// </summary>
        public static bool _SocketSecondOutConnected = false; //socket连接是否连接上

        public static string _PrintBarCode = "Data Source=10.69.224.218;Initial Catalog=BARCODEPRINTER;Persist Security Info=True;User ID=sa;Password =sa;Connect Timeout=5";

        public static int _IgnoreSecond = Convert.ToInt32(ConfigurationManager.AppSettings["IgnoreSecond"].ToString()); //效率计算时两单间忽略的时间

        public static bool _LimiltEff = Convert.ToBoolean(ConfigurationManager.AppSettings["LimiltEff"].ToString()); //是否开启效率最低下限8000

        /// <summary>
        /// 分拣线编号
        /// </summary>
        public static string _SortingLineId = ConfigurationManager.AppSettings["SortingLineId"].ToString();

        /// <summary>
        /// 异型分拣线编号
        /// </summary>
        public static string _AbnoSortingLineId = ConfigurationManager.AppSettings["AbnoSortingLineId"].ToString();

        /// <summary>
        /// 屏幕位置
        /// </summary>
        public static string _ScreenPosition = ConfigurationManager.AppSettings["ScreenPosition"];
        
        public static bool _Logout = false; //是否注销

        public static string _LineCode;

        /// <summary>
        /// 当前系统模式
        /// </summary>
        public static string SysMode="";

        /// <summary>
        /// 程序主界面标题
        /// </summary>
        public static string SysTitle;

        private static string serverConnectionString;


        public static string _LedCom1 = ConfigurationManager.AppSettings["LedCom1"];

        public static string _LedCom2 = ConfigurationManager.AppSettings["LedCom2"];

        public static string _LedCom3 = ConfigurationManager.AppSettings["LedCom3"];

        public static string _NLightCom = ConfigurationManager.AppSettings["NLightCom"];

        //存放双仓的地址位
        public static List<string> Put2LineBox = new List<string>();
    


        /// <summary>
        /// 构造函数
        /// </summary>
        public AppUtil()
        {           

            Put2LineBox.Add("10");
            Put2LineBox.Add("12");
            Put2LineBox.Add("22");
            Put2LineBox.Add("24");
            Put2LineBox.Add("34");
            Put2LineBox.Add("36");
            Put2LineBox.Add("46");
            Put2LineBox.Add("48");
            Put2LineBox.Add("58");
            Put2LineBox.Add("60");
            Put2LineBox.Add("70");
            Put2LineBox.Add("72");
            Put2LineBox.Add("82");
            Put2LineBox.Add("84");
        }


        /// <summary>
        /// 更新连接字符串
        /// </summary>
        /// <param name="newName">连接字符串名称</param>
        /// <param name="newConString">连接字符串内容</param>
        /// <param name="newProviderName">数据提供程序名称</param>
        public static void UpdateConnectionStringsConfig(string newName,
            string newConString)
        {
            bool isModified = ConfigurationManager.ConnectionStrings[newName] != null;
            //如果要更改的连接串已经存在  
            //新建一个连接字符串实例  
            ConnectionStringSettings mySettings =
                new ConnectionStringSettings(newName, newConString);
            // 打开可执行的配置文件*.exe.config  
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // 如果连接串已存在，首先删除它  
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }
            // 将新的连接串添加到配置文件中.  
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改  
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节  
            ConfigurationManager.RefreshSection("ConnectionStrings");
            _LocalConnectionString = config.ConnectionStrings.ConnectionStrings["MonitorString"].ToString();
            _FjInfoConnectionString = config.ConnectionStrings.ConnectionStrings["FjIntoString"].ToString();
        }


        /// <summary>
        /// 返回＊.exe.config文件中appSettings配置节的value项
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }


        /// <summary>
        /// 在＊.exe.config文件中appSettings配置节增加一对键、值对
        /// </summary>
        /// <param name="newKey"></param>
        /// <param name="newValue"></param>
        private static void UpdateAppConfig(string newKey, string newValue)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == newKey)
                {
                    isModified = true;
                }
            }

            // Open App.Config of executable  
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // You need to remove the old settings object before you can replace it  
            if (isModified)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            // Add an Application Setting.  
            config.AppSettings.Settings.Add(newKey, newValue);
            // Save the changes in App.config file.  
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.  
            ConfigurationManager.RefreshSection("appSettings");
        } 
        

        

        #region 获取本机IP地址
        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetHostIP()
        {
            IPHostEntry ieh = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipAddress in ieh.AddressList)
            {
                if (!ipAddress.IsIPv6LinkLocal)
                {
                    return ipAddress;
                }
            }
            return ieh.AddressList[0];
        }
        #endregion

        /// <summary>
        /// 创建txt文本日志，记录消息异常
        /// </summary>
        /// <param name="LogInfo"></param>
        public static void WriteTxtLog(string logfilename, string Message, string Exception)
        {
            try
            {
                FileStream file = null;
                //file = File.Create(logfilename);
                file = new FileStream(logfilename, FileMode.Append);
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(DateTime.Now.ToString());
                if (!string.IsNullOrEmpty(Message))
                {
                    sw.WriteLine(Message);
                }
                sw.WriteLine(Exception);
                sw.Close();
            }
            catch { }
        }


        /// <summary>半角转成全角
        /// 半角空格32,全角空格12288
        /// 其他字符半角33~126,其他字符全角65281~65374,相差65248
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string DBCToSBC(string input)
        {
            char[] cc = input.ToCharArray();
            for (int i = 0; i < cc.Length; i++)
            {
                if (cc[i] == 32)
                {
                    // 表示空格
                    cc[i] = (char)12288;
                    continue;
                }
                if (cc[i] < 127 && cc[i] > 32)
                {
                    cc[i] = (char)(cc[i] + 65248);
                }
            }
            return new string(cc);
        }


        

    }
}

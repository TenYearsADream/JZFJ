using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtility;
using OPCAutomation;

using System.IO;

namespace PlcContract
{
    /// <summary>
    /// PLC底层操作类
    /// </summary>
    public class OpcPlc
    {
        private object o1 = new object();
        private object o2 = new object();
        OPCServer myOpcServer;//OPC服务器对象
        OPCGroup myOpcGroup;//OPC组对象
        OPCBrowser browser;//OPC显示对象

        static public bool IsConnected;//OPC是否连接

        public static string path = Environment.CurrentDirectory + @"\Plc.txt";//PLC地址初始化文件，所有需要用的地址都必须写入文件，一行一个地址

        Dictionary<string, OPCItem> dic = new Dictionary<string,OPCItem>();//存放PLC中Item的字典

        public OpcPlc()
        {
            //初始化PLC连接
            myOpcServer = new OPCServer();
            myOpcServer.Connect("OPC.SimaticNet");

            IsConnected = Convert.ToBoolean(myOpcServer.ServerState);

            //在连接服务器添加组对象
            myOpcGroup = myOpcServer.OPCGroups.Add("S7:[S7 connection_1]");
         
            myOpcGroup.IsActive = true;
            myOpcGroup.IsSubscribed = true;
            myOpcGroup.DeadBand = 0;
            myOpcGroup.UpdateRate = 1000;
            
            //读取PLC初始化文件中的所有地址并添加到组对象中
            string[] itemStr = File.ReadAllLines(path);
            int i = 0;
            foreach (string item in itemStr)
            {
                i++;
                if (item.Contains('|'))
                {
                    foreach (string str in item.Split('|'))
                    {
                        OPCItem myOpcItem = myOpcGroup.OPCItems.AddItem(str, i);
                        dic.Add(str,myOpcItem);                        
                    }
                }
                else
                {
                    OPCItem myOpcItem = myOpcGroup.OPCItems.AddItem(item, i);
                    dic.Add(item, myOpcItem);                    
                }
            }
        }
        
        string str = "S7:[S7 connection_1]DB";
        //获取PLC对象中所有的Item
        public string ItemList()
        {
            browser = myOpcServer.CreateBrowser();
            browser.ShowBranches();
            browser.ShowLeafs(true);
            string i = "";
            foreach (var item in browser)
            {
                if (item.ToString().Contains(str))
                {
                    i += item.ToString() + "|";
                }
            }
            return i;
        }

        /// <summary>
        /// 读取PLC中的值
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public PlcValue GetPlcValue(string itemName)
        {
            lock (o1)
            {
                PlcValue plc = new PlcValue();
                OPCItem opcitem = dic[itemName];

                if (opcitem != null)
                {
                    object Value, Quality, TimeStamp;
                    opcitem.Read(1, out Value, out Quality, out TimeStamp);
                    plc.objectTimeStamp = TimeStamp;
                    plc.Quality = Quality;
                    plc.Value = Value;
                    plc.ClientHandle = opcitem.ClientHandle;
                }
                return plc;
            }
        }
        

        /// <summary>
        /// 写PLC中的值
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="plc"></param>
        /// <returns></returns>
        public bool SetPlcValue(string itemName,PlcValue plc)
        {
            lock (o2)
            {
                OPCItem opcitem = dic[itemName];
                if (opcitem != null)
                {
                    opcitem.Write(plc.Value);
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 断开PLC连接
        /// </summary>
        /// <returns></returns>
        public bool DisConn()
        {
            try
            {
                myOpcServer.OPCGroups.RemoveAll();
                myOpcServer.Disconnect();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// PLC中Item值的类
    /// </summary>
    public class PlcValue
    {
       public object Value { get; set; }
       public object Quality { get; set; }
       public object objectTimeStamp { get; set; }
       public object ClientHandle { get; set; }
    }
}

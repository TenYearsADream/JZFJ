#region 文件头

// /*******************************************************************************
//  *    系统名称  ： CigIntransit
//  *    创建时间  ： 2012/09/10/16:28
//  *    文件名    ： 
//  *    作者      :  祝旻
//  *              (C) Copyright keertech Corporation 2012
//  *               All Rights Reserved.
//  * *****************************************************************************

#endregion

namespace SocketCommunication
{
    #region

    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using AppUtility;
    using System.IO;
    using System.Reflection;

    #endregion

    internal class XmlSocketClient : SocketClient
    {
        
        #region Socket通讯相关
        

        #region 定时检查socket是否连接上

        public override void SetTimerReconn()
        {
            timer.Interval = 10000;
            timer.Tick += timerSocket_Tick;
            timer.Enabled = true;
            
        }

        
        /// <summary>
        ///   定时器事件
        /// </summary>
        private void timerSocket_Tick(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(TimeConnect);
        }


        /// <summary>
        /// Times the connect.
        /// </summary>
        /// <param name="o">The o.</param>
        private void TimeConnect(object o)
        {
            if (socket == null || socket.Connected == false)
            {
                ConnectServer();
            }
            else 
            {
                //定时心跳包发送
                SendJump();
               
            }
        }

       

        /// <summary>
        /// Sends the jump.
        /// </summary>
        private void SendJump()
        {
            string strgps = XmlCommand.GetJump("");
            SendMessage(SocketManager.FirstOut, strgps);
        }

        #endregion

        #region 连接服务器

        /// <summary>
        ///   连接服务器
        /// </summary>
        public override void ConnectServer()
        {
            try
            {
                if (socket == null)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
                if (remoteIep == null)
                {
                    remoteIep = new IPEndPoint(IPAddress.Parse(IP), Port);
                }
                socket.Connect(remoteIep);
                byte[] byteMessage =
                    Encoding.UTF8.GetBytes(XmlCommand.GetLoginXml("") + SendSuffix);
                //序列化，并把把字符串转成字节数组
                socket.SendTo(byteMessage, remoteIep);
                //ShowToolStripItemText(labelItem1, Color.Black, "网络连接成功");
                ThreadStart myThreaddelegate = ReceiveMessage;
                myThread = new Thread(myThreaddelegate);
                myThread.IsBackground = true;
                myThread.Start();
            }
            catch (SocketException sex)
            {
                if (socket != null) socket.Close();
                socket = null;
                //AppUtil.WriteTxtLog("无法连接到服务器", sex.Message);
                //ShowToolStripItemText(statusStrip1, Color.Red, "网络连接断开");
                OnSocketUnConnected();
            }
            catch (Exception ex)
            {
                if (socket != null) socket.Close();
                socket = null;
                //AppUtil.WriteTxtLog("未知错误", ex.Message);
                //ShowToolStripItemText(statusStrip1, Color.Red, "网络连接断开");
                OnSocketUnConnected();
            }
        }

        public override void ShutDowmServer()
        {
            timer.Enabled = false;
            if (socket != null)
            {
                socket.Close();
            }
            socket = null;
        }

        #endregion

        #region 接收服务器端数据

        /// <summary>
        ///   接收服务器端数据
        /// </summary>
        public override void ReceiveMessage()
        {
            var sb = new StringBuilder();
            while (true)
            {
                try
                {
                    //获取数据
                    int recv = socket.Receive(_msgBuffer, _msgBuffer.Length, 0);
                    string str = Encoding.UTF8.GetString(_msgBuffer, 0, recv);
                    if (str.Contains("<JobOrder>"))
                    {
                        OnDownloadRevice(new EventArgs());
                    }
                    sb.Append(str);

                    //如果数据以\0结束表示有新命令
                    if (sb.ToString().EndsWith(RiceveSuffix))
                    {
                        try
                        {
                            //分割命令
                            string[] strings = sb.ToString().Split('\0');
                            foreach (string strAllData in strings)
                            {
                                //如果无'>'表示非XML命令语句
                                if (strAllData.IndexOf(">") > -1)
                                {
                                    string header = strAllData.Substring(0, strAllData.IndexOf('>')); //得到头字符串
                                    header = header.Substring(header.IndexOf('<') + 1);
                                    string strXml = strAllData; //得到主体数据
                                    string port = socket.RemoteEndPoint.ToString().Remove(0,
                                                                                          socket.RemoteEndPoint.ToString
                                                                                              ().IndexOf(':') + 1);
                                    OnReceiveMessage(header, strXml, port);
                                    //ManageReceivedData(header, strJson); //处理接收到的数据
                                }
                                Thread.Sleep(100);
                            }
                        }
                        catch (Exception ex)
                        {
                            //AppUtil.WriteTxtLog("处理服务器消息异常", ex.Message);
                            //AppUtil.WriteTxtLog("异常时字符串", sb.ToString());
                            if (socket != null)
                            {
                                socket.Close();

                            }
                            socket = null;
                            OnSocketUnConnected();
                        }
                        finally
                        {
                            sb.Remove(0, sb.Length);
                        }
                    }
                }
                catch (Exception exception)
                {
                    //AppUtil.WriteTxtLog("接收服务器异常", exception.Message);
                    if (socket != null)
                    {
                        socket.Close();

                    }
                    socket = null;
                    OnSocketUnConnected();
                    break;
                }
            }
        }

        #endregion

        #region 向服务器端发送数据

        /// <summary>
        ///   向服务器端发送数据
        /// </summary>
        public override void SendMessage(string header, object obj)
        {
            string strResult = string.Empty;
            try
            {
                //对数据进行处理
                string strJson = obj.ToString();
                if (!string.IsNullOrEmpty(strJson))
                {
                    strResult = strJson + SendSuffix;
                }
                byte[] byteMessage = Encoding.UTF8.GetBytes(strResult); //把字符串转成字节数组
                socket.Send(byteMessage); //发送数据
                //log.Info(strResult);
                
                Thread.Sleep(100);
            }
            catch (SocketException es)
            {
                //AppUtil.WriteTxtLog("发送消息异常", es.Message);
                if (socket != null)
                {
                    socket.Close();

                }
                socket = null;
                OnSocketUnConnected();
            }
            catch (Exception ex)
            {
                //AppUtil.WriteTxtLog("发送消息异常", ex.Message);
                if (socket != null)
                {
                    socket.Close();

                }
                socket = null;
                OnSocketUnConnected();
            }
        }

        public override void SendMessage(byte[] byteMessage)
        {
            try
            {
                socket.Send(byteMessage); //发送数据
            }
            catch (SocketException es)
            {
                //log.Error("发送消息异常" + Environment.NewLine, es);
                //AppUtil._SocketConnected = false;
                OnSocketUnConnected();
            }
            catch (Exception ex)
            {
                //log.Error("发送消息异常" + Environment.NewLine, ex);
                //AppUtil._SocketConnected = false;
                OnSocketUnConnected();
            }
        }

        #endregion

        #endregion
    }
}
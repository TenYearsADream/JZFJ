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
    using System.Threading;
    using System.Windows.Forms;

    #endregion

    internal abstract class SocketClient
    {
        public const string RiceveSuffix = "\0";
        public const string SendSuffix = "\r\n";
        protected readonly byte[] _msgBuffer = new byte[1024 * 8]; //存放消息数据
        protected Thread myThread;
        protected IPEndPoint remoteIep;
        protected Socket socket;

        protected System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public string IP { get; set; }
        public int Port { get; set; }

        public bool IsSendGps { get; set; }

        public abstract void SetTimerReconn();

        public abstract void ConnectServer();

        public abstract void ShutDowmServer();

        public abstract void ReceiveMessage();

        public abstract void SendMessage(string header, object obj);

        public abstract void SendMessage(byte[] byteMessage);

        #region 事件委托 socket连接发送改变

        // 声明事件委托

        #region Delegates

        public delegate void SocketConnectedEventHandle();

        public delegate void SocketUnConnectedEventHandle();

        #endregion

        //定义事件
        public event SocketConnectedEventHandle EV_SocketConnected;
        //监视事件
        protected void OnSocketConnected()
        {
            if (EV_SocketConnected != null)
            {
                EV_SocketConnected();
            }
        }

        //定义事件
        public event SocketConnectedEventHandle EV_SocketUnConnected;
        //监视事件
        protected void OnSocketUnConnected()
        {
            if (EV_SocketUnConnected != null)
            {
                EV_SocketUnConnected();
            }
        }


        //定义事件
        public event EventHandler<ReceiveMessageEvenArgs> EV_ReceiveMessage;
        //监视事件
        protected void OnReceiveMessage(string header, string body, string port)
        {
            if (EV_ReceiveMessage != null)
            {
                EV_ReceiveMessage(null, new ReceiveMessageEvenArgs(header, body, port));
            }
        }

        public event EventHandler DownloadRevice;

        public void OnDownloadRevice(EventArgs e)
        {
            EventHandler handler = DownloadRevice;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}
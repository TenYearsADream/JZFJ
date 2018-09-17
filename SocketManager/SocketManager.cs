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

using BusinessLogic.Configuration;

namespace SocketCommunication
{
    #region

    using System;
    using System.Threading;
    using AppUtility;
    using System.Collections.Generic;

    #endregion

    public class SocketManager
    {
        private static SocketManager _socketManager;
        private static SocketClient _socket9129client;//GPS服务器
        private static SocketClient _socket9130client;//指令服务器
        public const string FirstOut = "FirstPort";
        public const string SecondOut = "SecondOut";
        private System.Windows.Forms.Timer sendTimer = new System.Windows.Forms.Timer();
        protected Thread myThread;

        public static SocketManager Instance
        {
            get { return _socketManager ?? (_socketManager = new SocketManager()); }
        }

        /// <summary>
        /// 未发送成功的消息队列
        /// </summary>
        public Queue<string> SendQueue { get; set; }

        public static ConvertType ConvertType { get; set; }


        public event EventHandler EV_Socket9129Connected;
        public event EventHandler EV_Socket9129UnConnected;

        public event EventHandler EV_Socket9130Connected;
        public event EventHandler EV_Socket9130UnConnected;

              

        public event EventHandler DownloadRevice;
        public void OnDownloadRevice(EventArgs e)
        {
            EventHandler handler = DownloadRevice;
            if (handler != null) handler(this, e);
        }


        public void Initialize(ConvertType convertType)
        {
            if (convertType == ConvertType.Xml)
            {
                _socket9129client = new XmlSocketClient();
                _socket9129client.IP = AppUtil._FirstOutIP;
                _socket9129client.Port = Int32.Parse(AppUtil._FirstOutPort);
                
                _socket9130client = new XmlSocketClient();
                _socket9130client.IP = AppUtil._SecondOutIP;
                _socket9130client.Port = Int32.Parse(AppUtil._SecondOutPort);
                
            }
            _socket9129client.EV_ReceiveMessage += _socketclient_EV_ReceiveMessage;
            _socket9129client.EV_SocketConnected += _socketclient_EV_SocketConnected;
            _socket9129client.EV_SocketUnConnected += _socketclient_EV_SocketUnConnected;
            _socket9129client.SetTimerReconn();

            _socket9130client.EV_ReceiveMessage += _socketclient_EV_ReceiveMessage;
            _socket9130client.EV_SocketConnected += _socket9130client_EV_SocketConnected;
            _socket9130client.EV_SocketUnConnected += _socket9130client_EV_SocketUnConnected;
            _socket9130client.DownloadRevice += new EventHandler(_socket9130client_DownloadRevice);
            _socket9130client.SetTimerReconn();
        }

        void _socket9130client_DownloadRevice(object sender, EventArgs e)
        {
            OnDownloadRevice(new EventArgs());
        }

        void sendTimer_Tick(object sender, EventArgs e)
        {
            ThreadStart myThreaddelegate = ReSendMessage;
            myThread = new Thread(myThreaddelegate);
            myThread.Start();
        }
        
        private void ReSendMessage()
        {
            if (SendQueue.Count > 0 && AppUtil._SocketFirstOutConnected)
            {
                string sendmessage = SendQueue.Dequeue();
                SendMessage(FirstOut, sendmessage);
            }
        }



        private void _socket9130client_EV_SocketUnConnected()
        {
            AppUtil._SocketFirstOutConnected = false;
            if (EV_Socket9130UnConnected != null)
            {
                EV_Socket9130UnConnected(null, new EventArgs());
            }
        }

        private void _socket9130client_EV_SocketConnected()
        {
            if (EV_Socket9130Connected != null)
            {
                EV_Socket9130Connected(null, new EventArgs());
            }
        }


        public void Close()
        {
            _socket9129client.ShutDowmServer();
            _socket9130client.ShutDowmServer();
            AppUtil._SocketSecondOutConnected = false;
            AppUtil._SocketFirstOutConnected = false;
        }

        public void ConnectServer()
        {
            _socket9130client.ConnectServer();
            _socket9129client.ConnectServer();
        }

        
        public void SendMessage(string header, object obj)
        {
            if (header == SecondOut)
            {
                _socket9129client.SendMessage(header, obj);
            }
            else if(header == FirstOut)
            {
                _socket9130client.SendMessage(header, obj);
            }
        }


        private void _socketclient_EV_SocketUnConnected()
        {
            AppUtil._SocketSecondOutConnected = false;
            if (EV_Socket9129UnConnected != null)
            {
                EV_Socket9129UnConnected(null, new EventArgs());
            }
        }

        private void _socketclient_EV_SocketConnected()
        {
            if (EV_Socket9129Connected != null)
            {
                EV_Socket9129Connected(null, new EventArgs());
            }
        }

        private void _socketclient_EV_ReceiveMessage(object sender, ReceiveMessageEvenArgs e)
        {
            try
            {
                ManageReceivedData(e.header, e.body, e.port);
            }
            catch (Exception ex)
            {
                //AppUtil.WriteTxtLog("处理数据出错", ex.Message);
            }
        }


        public void ManageReceivedData(string header, string strXml, string port)
        {
            if (String.Compare(header, "Logined", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (port == Settings.GetSettings().GetSettingByName("FirstOutPort").Value)
                {
                    AppUtil._SocketFirstOutConnected = true;
                    _socket9130client_EV_SocketConnected();
                }
                else if (port == Settings.GetSettings().GetSettingByName("FirstOutPort").Value)
                {
                    AppUtil._SocketSecondOutConnected = true;
                    _socketclient_EV_SocketConnected();
                }
            }

            if (String.Compare(header, "ArrivalConfirmReply", StringComparison.OrdinalIgnoreCase) == 0)
            {
                ArrivalConfirmReplyed(strXml);
            }

            if (String.Compare(header, "JobOrder", StringComparison.OrdinalIgnoreCase) == 0)
            {
                DownloadJobed(strXml);
            }

            if (String.Compare(header, "QueryJobOrderError", StringComparison.OrdinalIgnoreCase) == 0)
            {
                strXml = strXml.Replace("<QueryJobOrderError>", "").Replace("</QueryJobOrderError>", "");
                strXml = strXml.Replace("<Message>", "").Replace("</Message>", "");
                QueryJobOrderErrored(strXml);
            }
            if (String.Compare(header, "LoadingReadyReply", StringComparison.OrdinalIgnoreCase) == 0)
            {
                LoadingReadyed(strXml);
            }
            if (String.Compare(header, "RegisterCardReply", StringComparison.OrdinalIgnoreCase) == 0)
            {
                //strXml = strXml.Replace("<RegisterCardReply>", "").Replace("</RegisterCardReply>", "");
                //strXml = strXml.Replace("<CardNo>", "").Replace("</CardNo>", "");
                RegisterCardReplyed(strXml);
            }
            if (String.Compare(header, "DeliverLogReply", StringComparison.OrdinalIgnoreCase) == 0)
            {
                DeliverLogReplyed(strXml);
            }
            if (String.Compare(header, "烟包发送成功", StringComparison.OrdinalIgnoreCase) == 0)
            {
                SendBoxSuccessed("1", "1");
            }
        }

        #region 事件定义

        #region 接收客户确认信息

        public event EventHandler<ArrivalConfirmReplyArgs> EV_ArrivalConfirmReply;

        protected void ArrivalConfirmReplyed(string arrivalConfirmReply)
        {
            if (EV_ArrivalConfirmReply != null)
            {
                EV_ArrivalConfirmReply(null, new ArrivalConfirmReplyArgs(arrivalConfirmReply));
            }
        }


        public event EventHandler<DownloadJobArgs> EV_DownloadJob;

        protected void DownloadJobed(string downloadJob)
        {
            if (EV_DownloadJob != null)
            {
                EV_DownloadJob(null, new DownloadJobArgs(downloadJob));
            }
        }

        public event EventHandler<QueryJobOrderErrorArgs> EV_QueryJobOrderErrorArgs;

        protected void QueryJobOrderErrored(string error)
        {
            if (EV_QueryJobOrderErrorArgs != null)
            {
                EV_QueryJobOrderErrorArgs(null, new QueryJobOrderErrorArgs(error));
            }
        }

        public event EventHandler<QueryJobOrderErrorArgs> EV_LoadingReady;

        protected void LoadingReadyed(string loadingReady)
        {
            if (EV_LoadingReady != null)
            {
                EV_LoadingReady(null, new QueryJobOrderErrorArgs(loadingReady));
            }
        }

        public event EventHandler<RegisterCardReplyArgs> EV_RegisterCardReply;

        protected void RegisterCardReplyed(string registerCardReply)
        {
            if (EV_RegisterCardReply != null)
            {
                EV_RegisterCardReply(null, new RegisterCardReplyArgs(registerCardReply));
            }
        }

        public event EventHandler<DeliverLogReplyArgs> EV_DeliverLogReply;
        protected void DeliverLogReplyed(string deliverlogReply)
        {
            if (EV_DeliverLogReply != null)
            {
                EV_DeliverLogReply(null, new DeliverLogReplyArgs(deliverlogReply));
            }
        }

        public event EventHandler<SortingTaskEventArgs> EV_SendBoxSuccessed;
        protected void SendBoxSuccessed(string sortingtaskno,string outport)
        {
            if (EV_SendBoxSuccessed != null)
            {
                EV_SendBoxSuccessed(null, new SortingTaskEventArgs(sortingtaskno,outport));
            }
        }

        #endregion

        #endregion
    }


    public enum ConvertType
    {
        Json = 1,
        Xml = 2,
        Byte = 3
    }
    
}
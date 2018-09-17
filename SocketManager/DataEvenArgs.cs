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
    using System.Collections.Generic;

    #endregion

    public class ArrivalConfirmReplyArgs : EventArgs
    {
        public ArrivalConfirmReplyArgs(string arrivalConfirmReply)
        {
            ArrivalConfirmReply = arrivalConfirmReply;
        }

        public string ArrivalConfirmReply { get; set; }
    }

    public class DownloadJobArgs : EventArgs
    {
        public DownloadJobArgs(string downloadJob)
        {
            DownloadJob = downloadJob;
        }

        public string DownloadJob { get; set; }
    }

    public class QueryJobOrderErrorArgs : EventArgs
    {
        public QueryJobOrderErrorArgs(string error)
        {
            Error = error;
        }

        public string Error { get; set; }
    }

    public class RegisterCardReplyArgs : EventArgs
    {
        public RegisterCardReplyArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }


    public class DeliverLogReplyArgs : EventArgs
    {
        public DeliverLogReplyArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }


    public class DataEvenArgs : EventArgs
    {
        public DataEvenArgs(bool succeed, string message)
        {
            Succeed = succeed;
            Message = message;
        }

        public bool Succeed { get; set; }
        public string Message { get; set; }
    }

    public class BillCodeEvenArgs : EventArgs
    {
        public BillCodeEvenArgs(string[] billcodes)
        {
            BillCodes = billcodes;
        }

        public string[] BillCodes { get; set; }
    }


    public class AllocationBillCodesEvenArgs : EventArgs
    {
        public AllocationBillCodesEvenArgs(List<string> allocationbillcodes)
        {
            AllocationBillCodes = allocationbillcodes;
        }

        public List<string> AllocationBillCodes { get; set; }
    }


    public class ErrorMessageArgs : EventArgs
    {
        public ErrorMessageArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }

    public class MemberPointEventArgs : EventArgs
    {
        public MemberPointEventArgs()
        {
        }

        public MemberPointEventArgs(string memberCardNum, double point)
        {
            MemberCardNum = memberCardNum;
            Point = point;
        }

        public string MemberCardNum { get; set; }
        public double Point { get; set; }
    }

    public class SubmitTableEventArgs : EventArgs
    {
        public SubmitTableEventArgs()
        {
        }

        public SubmitTableEventArgs(int tableId)
        {
            TableId = tableId;
        }

        public int TableId { get; set; }
    }


    public class StorgeCodeBalanceArgs : EventArgs
    {
        public StorgeCodeBalanceArgs()
        {
            CardNo = string.Empty;
            Money = decimal.Zero;
        }

        public StorgeCodeBalanceArgs(string cardNo, decimal money)
        {
            CardNo = cardNo;
            Money = money;
        }

        public string CardNo { get; set; }
        public decimal Money { get; set; }
    }


    public class AllocationStorgeCardComptEvenArgs : EventArgs
    {
        public AllocationStorgeCardComptEvenArgs(string msg)
        {
            Msg = msg;
        }

        public string Msg { get; set; }
    }


    public class LockingInventoryEvenArgs : EventArgs
    {
        public LockingInventoryEvenArgs(string msg)
        {
            Msg = msg;
        }

        public string Msg { get; set; }
    }

    public class ReceiveMessageEvenArgs : EventArgs
    {
        public ReceiveMessageEvenArgs(string header, string body, string port)
        {
            this.header = header;
            this.body = body;
            this.port = port;
        }

        public string header { get; set; }
        public string body { get; set; }
        public string port { get; set; }
    }

    public class SalesOrderEventArgs : EventArgs
    {
        public SalesOrderEventArgs()
        {
        }

        public SalesOrderEventArgs(string orderNo)
        {
            OrderNo = orderNo;
        }

        public string OrderNo { get; set; }
    }


    public class SortingTaskEventArgs : EventArgs
    {
        public SortingTaskEventArgs()
        {
        }

        public SortingTaskEventArgs(string taskno,string outport)
        {
            TaskNo = taskno;
        }

        public string TaskNo { get; set; }
        public string OutPort { get; set; }
    }
}
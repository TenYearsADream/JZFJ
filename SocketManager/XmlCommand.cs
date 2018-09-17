#region 文件头

// /*******************************************************************************
//  *    系统名称  ： CigIntransit
//  *    创建时间  ： 2012/09/24/10:36
//  *    文件名    ： 
//  *    作者      :  祝旻
//  *              (C) Copyright keertech Corporation 2012
//  *               All Rights Reserved.
//  * *****************************************************************************

#endregion

namespace SocketCommunication
{
    #region

    using System.Globalization;
    using System.Xml;
    using AppUtility;
    
using System;

    #endregion

    public static class XmlCommand
    {
        private const string Login = "Login";
        private const string TerminalId = "terminalId";
        private const string ArrivalConfirm = "ArrivalConfirm";
        private const string Version = "version";
        private const string Time = "time";
        private const string Lon = "lon";
        private const string Lat = "lat";
        private const string OrderId = "orderId";
        private const string ClientCode = "clientCode";
        private const string IsLocationError = "isLocationError";
        private const string IsLackRoad = "isLackRoad";
        private const string ArrivalConfirmType = "arrivalConfirmType";
        private const string GpsSignal = "GPSSignal";
        private const string Type = "type";
        private const string DateTime = "dateTime";
        private const string Direction = "direction";
        private const string Speed = "speed";
        private const string Elevation = "elevation";
        private const string Odometer = "odometer";
        private const string Alert = "alert";
        private const string LoadingReady = "LoadingReady";
        private const string PathCode = "pathCode";
        private const string PathName = "pathName";
        private const string SellDate = "sellDate";
        private const string Allotypenum = "allotypeNum";
        private const string Piecenum = "pieceNum";
        private const string Packagesnum = "packagesNum";
        private const string RealAllotypenum = "realallotypeNum";
        private const string RealPiecenum = "realpieceNum";
        private const string RealPackagesnum = "realpackagesNum";
        private const string ClientNum = "clientNum";
        private const string Number = "number";
        private const string Totalnum = "totalNum";
        private const string RealTotalnum = "realtotalNum";
        private const string Jump = "Jump";
        private const string QueryJobOrder = "QueryJobOrder";
        private const string LineId = "lineId";
        private const string BaseDemand = "baseDemand";
        private const string AmtOrder = "amtOrder";
        private const string RegisterCard = "RegisterCard";
        private const string CardNo = "cardNo";
        private const string ComfirmReason = "ComfirmReason";
        private const string Success = "success";
        private const string Message = "message";
        private const string DeliverLog = "DeliverLog";
        private const string deliveryTime = "deliveryTime";
        private const string deliveryMileage = "deliveryMileage";
        private const string oilwear = "oilwear";
        private const string deliveryDamangenum = "deliveryDamangeNum";
        private const string deliveryDamange = "deliveryDamangeAmount";
        private const string mileageEnd = "mileageEnd";
        private const string oilNum = "oilNum";
        private const string oilAmount = "oilAmount";
        private const string carAmount = "carAmount";
        private const string Date = "date";
        private const string fuelCharge = "fuelCharge";
        private const string Boxs = "boxs";


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="terminalId"></param>
        /// <returns></returns>
        public static string GetLoginXml(string terminalId)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode loginnode = xmlDocument.CreateNode(XmlNodeType.Element, Login, "");
            XmlElement terminalIdElement = xmlDocument.CreateElement(TerminalId);
            terminalIdElement.InnerText = terminalId;
            loginnode.AppendChild(terminalIdElement);
            xmlDocument.AppendChild(loginnode);
            return xmlDocument.InnerXml;
        }


        

        public static string GetJump(string terminalId)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode jumpnode = xmlDocument.CreateNode(XmlNodeType.Element, Jump, "");
            XmlElement terminalIdElement = xmlDocument.CreateElement(TerminalId);
            terminalIdElement.InnerText = terminalId;
            jumpnode.AppendChild(terminalIdElement);
            xmlDocument.AppendChild(jumpnode);
            return xmlDocument.InnerXml;
        }

        
    }
}
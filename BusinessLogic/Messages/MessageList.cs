//// -----------------------------------------------------------------------
//// <copyright file="MessageList.cs"
////     project="BusinessLogic"
////     solution="PurchaseSalesInventory"
////     company="武汉科尔创新软件技术有限公司">
////     Copyright (c) KEERTECH. All rights reserved.
//// </copyright>
//// <author>TuB</author>
//// <created>2012-03-30</created>
//// <summary></summary>
//// -----------------------------------------------------------------------

//using System;

//using Csla;
//using Csla.Data;

//namespace BusinessLogic.Messages
//{
//    /// <summary>
//    /// 表示一个只读的消息列表
//    /// </summary>
//    [Serializable]
//    public class MessageList : ReadOnlyListBase<MessageList, MessageInfo>
//    {
//        #region  Factory Methods

//        public static MessageList GetMessageList()
//        {
//            return DataPortal.Fetch<MessageList>();
//        }

//        private MessageList()
//        {
//            /* require use of factory methods */
//        }

//        #endregion

//        #region  Data Access

//        private void DataPortal_Fetch()
//        {
//            RaiseListChangedEvents = false;
//            using (var cn = new SQLiteConnection(AppUtility.AppUtil._LocalConnectionString))
//            {
//                cn.Open();
//                using (var cm = cn.CreateCommand())
//                {
//                    cm.CommandText =
//                        "SELECT * FROM [t_Message]";
//                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
//                    {
//                        IsReadOnly = false;
//                        while (dr.Read())
//                            Add(new MessageInfo(dr));
//                        IsReadOnly = true;
//                    }
//                }
//            }
//            RaiseListChangedEvents = true;
//        }

//        #endregion
//    }
//}
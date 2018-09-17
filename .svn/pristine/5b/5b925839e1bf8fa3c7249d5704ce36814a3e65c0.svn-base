// -----------------------------------------------------------------------
// <copyright file="MessageInfo.cs"
//     project="BusinessLogic"
//     solution="PurchaseSalesInventory"
//     company="武汉科尔创新软件技术有限公司">
//     Copyright (c) KEERTECH. All rights reserved.
// </copyright>
// <author>TuB</author>
// <created>2012-03-30</created>
// <summary></summary>
// -----------------------------------------------------------------------

using System;
using Csla;
using Csla.Data;

namespace BusinessLogic.Messages
{
    /// <summary>
    /// 表示一个只读的消息信息
    /// </summary>
    [Serializable]
    public class MessageInfo : ReadOnlyBase<MessageInfo>
    {
        public int Id { get; private set; }
        public int MessageId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Replay { get; private set; }
        public bool IsConfirm { get; private set; }
        public DateTime CreatedOn { get; private set; }

        internal MessageInfo(SafeDataReader dr)
        {
            Id = dr.GetInt32("Id");
            MessageId = dr.GetInt32("MessageId");
            Title = dr.GetString("Title");
            Content = dr.GetString("Content");
            Replay = dr.GetString("Replay");
            IsConfirm = dr.GetBoolean("IsConfirm");
            CreatedOn = dr.GetDateTime("CreateOn");
        }
    }
}
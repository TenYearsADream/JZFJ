//// -----------------------------------------------------------------------
//// <copyright file="Message.cs"
////     project="BusinessLogic"
////     solution="PurchaseSalesInventory"
////     company="武汉科尔创新软件技术有限公司">
////     Copyright (c) KEERTECH. All rights reserved.
//// </copyright>
//// <author>TuB</author>
//// <created>2012-03-29</created>
//// <summary></summary>
//// -----------------------------------------------------------------------

//using System;
//using Csla;

//namespace BusinessLogic.Messages
//{
//    /// <summary>
//    /// 表示一个消息的Socket数据模型
//    /// </summary>
//    public class SDMessage
//    {
//        public int Id { get; set; }
//        public string Title { get; set; }
//        public string Content { get; set; }
//        public int IsConfirm { set; get; }
//    }

//    /// <summary>
//    /// 表示一个可编辑的消息类
//    /// </summary>
//    [Serializable]
//    public class Message : BusinessBase<Message>
//    {
//        #region  Business Methods

//        private static PropertyInfo<int> IdProperty = RegisterProperty<int>(m => m.Id, "标识号");

//        public int Id
//        {
//            get { return GetProperty(IdProperty); }
//            set { SetProperty(IdProperty, value); }
//        }

//        private static PropertyInfo<int> MessageIdProperty = RegisterProperty<int>(m => m.MessageId, "服务器信息标识号");
//        public int MessageId
//        {
//            get { return GetProperty(MessageIdProperty); }
//            set { SetProperty(MessageIdProperty, value); }
//        }

//        private static PropertyInfo<string> TitleProperty = RegisterProperty<string>(m => m.Title, "标题");
//        public string Title
//        {
//            get { return GetProperty(TitleProperty); }
//            set { SetProperty(TitleProperty, value); }
//        }

//        private static PropertyInfo<string> ContentProperty = RegisterProperty<string>(m => m.Content, "内容");
//        public string Content
//        {
//            get { return GetProperty(ContentProperty); }
//            set { SetProperty(ContentProperty, value); }
//        }

//        private static PropertyInfo<bool> IsConfirmProperty = RegisterProperty<bool>(m => m.IsConfirm, "是否需要确认");
//        public bool IsConfirm
//        {
//            get { return GetProperty(IsConfirmProperty); }
//            set { SetProperty(IsConfirmProperty, value); }
//        }

//        private static PropertyInfo<string> ReplayProperty = RegisterProperty<string>(m => m.Replay, "回复");
//        public string Replay
//        {
//            get { return GetProperty(ReplayProperty); }
//            set { SetProperty(ReplayProperty, value); }
//        }

//        private static PropertyInfo<DateTime> CreatedOnProperty = RegisterProperty<DateTime>(m => m.CreatedOn, "创建时间");
//        public DateTime CreatedOn
//        {
//            get { return GetProperty(CreatedOnProperty); }
//            set { SetProperty(CreatedOnProperty, value); }
//        }

//        public override string ToString()
//        {
//            return Id.ToString();
//        }

//        #endregion

//        #region  Validation Rules

//        protected override void AddBusinessRules()
//        {
//            ValidationRules.AddRule(Csla.Validation.CommonRules.StringMaxLength,
//                                    new Csla.Validation.CommonRules.MaxLengthRuleArgs(TitleProperty, 50));

//            ValidationRules.AddRule(Csla.Validation.CommonRules.StringMaxLength,
//                                    new Csla.Validation.CommonRules.MaxLengthRuleArgs(ContentProperty, 300));

//            ValidationRules.AddRule(Csla.Validation.CommonRules.StringMaxLength,
//                                    new Csla.Validation.CommonRules.MaxLengthRuleArgs(ReplayProperty, 300));
//        }

//        #endregion

//        #region  Authorization Rules

//        protected override void AddAuthorizationRules()
//        {
//            // add AuthorizationRules here
//        }

//        protected static void AddObjectAuthorizationRules()
//        {
//            // add object-level authorization rules here
//        }

//        #endregion

//        #region  Factory Methods

//        public static Message NewMessage(SDMessage message)
//        {
//            return DataPortal.Create<Message>(message);
//        }

//        public static Message GetMessage(int id)
//        {
//            return DataPortal.Fetch<Message>(new SingleCriteria<Message, int>(id));
//        }

//        public static void DeleteMessage(int id)
//        {
//            DataPortal.Delete(new SingleCriteria<Message, int>(id));
//        }

//        private Message()
//        {
//            /* require use of factory methods */
//        }

//        #endregion

//        #region  Data Access

//        [RunLocal]
//        protected void DataPortal_Create(SDMessage message)
//        {
//            using (BypassPropertyChecks)
//            {
//                LoadProperty(MessageIdProperty, message.Id);
//                LoadProperty(TitleProperty, message.Title);
//                LoadProperty(ContentProperty, message.Content);
//                LoadProperty(IsConfirmProperty, message.IsConfirm);
//                ValidationRules.CheckRules();
//            }
//        }

//        private void DataPortal_Fetch(SingleCriteria<Message, int> criteria)
//        {
//            using (BypassPropertyChecks)
//            {
//                using (var cn = new System.Data.SQLite.SQLiteConnection(AppUtility.AppUtil._LocalConnectionString))
//                {
//                    cn.Open();
//                    using (var cm = cn.CreateCommand())
//                    {
//                        cm.CommandText =
//                            "SELECT * FROM [t_Message] WHERE [id] = @id";
//                        cm.Parameters.AddWithValue("@id", criteria.Value);
//                        using (var dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
//                        {
//                            dr.Read();
//                            Id = dr.GetInt32("id");
//                            MessageId = dr.GetInt32("MessageId");
//                            Title = dr.GetString("Title");
//                            Content = dr.GetString("Content");
//                            IsConfirm = dr.GetBoolean("IsConfirm");
//                            Replay = dr.GetString("Replay");
//                            CreatedOn = dr.GetDateTime("CreatedOn");
//                        }
//                    }
//                }
//            }
//        }

//        [Transactional(TransactionalTypes.Manual)]
//        protected override void DataPortal_Insert()
//        {
//            using (BypassPropertyChecks)
//            {
//                using (var cn = new System.Data.SQLite.SQLiteConnection(AppUtility.AppUtil._LocalConnectionString))
//                {
//                    cn.Open();
//                    using (var cm = cn.CreateCommand())
//                    {
//                        cm.CommandText =
//                            "insert into [t_Message] ([MessageId], [Title], [Content], [IsConfirm], [Replay], [CreateOn]) values (@messageId, @title, @content, @isConfirm, @replay, @createdOn);Select last_insert_rowid();";
//                        cm.Parameters.AddWithValue("@messageId", MessageId);
//                        cm.Parameters.AddWithValue("@title", Title);
//                        cm.Parameters.AddWithValue("@content", Content);
//                        cm.Parameters.AddWithValue("@isConfirm", IsConfirm);
//                        cm.Parameters.AddWithValue("@replay", Replay);
//                        CreatedOn = DateTime.Now;
//                        cm.Parameters.AddWithValue("@createdOn", CreatedOn);
//                        LoadPropertyConvert(IdProperty, cm.ExecuteScalar());
//                    }
//                }
//            }
//        }

//        [Transactional(TransactionalTypes.Manual)]
//        protected override void DataPortal_Update()
//        {
//            using (BypassPropertyChecks)
//            {
//                using (var cn = new System.Data.SQLite.SQLiteConnection(AppUtility.AppUtil._LocalConnectionString))
//                {
//                    cn.Open();
//                    using (var cm = cn.CreateCommand())
//                    {
//                        cm.CommandText =
//                            "update [t_Message] set [MessageId] = @messageId, [Title] = @title, [Content] = @content, [IsConfirm] = @isConfirm, [Replay] = @replay where id = @id";
//                        cm.Parameters.AddWithValue("@messageId", MessageId);
//                        cm.Parameters.AddWithValue("@title", Title);
//                        cm.Parameters.AddWithValue("@content", Content);
//                        cm.Parameters.AddWithValue("@isConfirm", IsConfirm);
//                        cm.Parameters.AddWithValue("@replay", Replay);
//                        cm.Parameters.AddWithValue("@id", Id);
//                        cm.ExecuteNonQuery();
//                    }
//                }
//            }
//        }

//        [Transactional(TransactionalTypes.Manual)]
//        protected override void DataPortal_DeleteSelf()
//        {
//            DataPortal_Delete(new SingleCriteria<Message, int>(Id));
//        }

//        [Transactional(TransactionalTypes.Manual)]
//        private void DataPortal_Delete(SingleCriteria<Message, int> criteria)
//        {
//            using (var cn = new System.Data.SQLite.SQLiteConnection(AppUtility.AppUtil._LocalConnectionString))
//            {
//                cn.Open();
//                using (var cm = cn.CreateCommand())
//                {
//                    cm.CommandText = "delete from [t_Message] Where [id] = @id";
//                    cm.Parameters.AddWithValue("@id", criteria.Value);
//                    cm.ExecuteNonQuery();
//                }
//            }
//        }

//        #endregion

//        #region  Exists

//        public static bool Exists(int messageId)
//        {
//            return ExistsCommand.Exists(messageId);
//        }

//        [Serializable]
//        private class ExistsCommand : CommandBase
//        {
//            private int _messageId;
//            private bool _exists;

//            public bool MessageExists
//            {
//                get { return _exists; }
//            }

//            public static bool Exists(int messageId)
//            {
//                var result = DataPortal.Execute(new ExistsCommand(messageId));
//                return result.MessageExists;
//            }

//            private ExistsCommand(int messageId)
//            {
//                _messageId = messageId;
//            }

//            protected override void DataPortal_Execute()
//            {
//                using (var cn = new System.Data.SQLite.SQLiteConnection(AppUtility.AppUtil._LocalConnectionString))
//                {
//                    cn.Open();
//                    using (var cm = cn.CreateCommand())
//                    {
//                        cm.CommandText =
//                            "SELECT Count(1) FROM [t_Message] WHERE [MessageId] = @messageId";
//                        cm.Parameters.AddWithValue("@messageId", _messageId);
//                        _exists = Convert.ToInt32(cm.ExecuteScalar()) > 0;
//                    }
//                }
//            }
//        }

//        #endregion
//    }
//}
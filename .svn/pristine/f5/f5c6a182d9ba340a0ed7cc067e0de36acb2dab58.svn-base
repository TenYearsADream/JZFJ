// -----------------------------------------------------------------------
// <copyright file="SortingTaskArrive.cs"
//     project="BusinessLogic"
//     solution="PurchaseSalesInventory"
//     company="武汉科尔创新软件技术有限公司">
//     Copyright (c) KEERTECH. All rights reserved.
// </copyright>
// <author>TuB</author>
// <created>2012-02-24</created>
// <summary></summary>
// -----------------------------------------------------------------------

using System;
using System.Text;
using Csla;
using MySql.Data.MySqlClient;
using AppUtility;
using Csla.Data;

namespace BusinessLogic.arrive
{
    /// <summary>
    /// 表示系统设置的类
    /// </summary>
    [Serializable]
    public class SortingTaskArrive : BusinessBase<SortingTaskArrive>
    {
        #region  Business Methods



        private static PropertyInfo<string> IdProperty = RegisterProperty<string>(r => r.Id, "标识号");
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        private static readonly PropertyInfo<string> OutportCODEProperty = RegisterProperty<string>(p => p.OutportCODE,
                                                                                                  "出口编号");

        private static readonly PropertyInfo<string> ADDRESSCODEProperty = RegisterProperty<string>(
            p => p.ADDRESSCODE, "出口地址码");



        private static PropertyInfo<string> ValueProperty = RegisterProperty<string>(r => r.Value, "");

        public string Value
        {
            get { return GetProperty(ValueProperty); }
            set { SetProperty(ValueProperty, value); }
        }

        public string OutportCODE
        {
            get { return GetProperty(OutportCODEProperty); }
            set { SetProperty(OutportCODEProperty, value); }
        }

        public string ADDRESSCODE
        {
            get { return GetProperty(ADDRESSCODEProperty); }
            set { SetProperty(ADDRESSCODEProperty, value); }
        }

        #endregion

        #region  Validation Rules

        /// <summary>
        /// Adds the business rules.
        /// </summary>
        protected override void AddBusinessRules()
        {
            
        }

        #endregion

        #region  Authorization Rules

        /// <summary>
        /// Adds the authorization rules.
        /// </summary>
        protected void AddAuthorizationRules()
        {
            // add AuthorizationRules here
        }

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            // add object-level authorization rules here
        }

        #endregion

        #region  Factory Methods

        internal static SortingTaskArrive NewSortingTaskArrive()
        {
            return DataPortal.CreateChild<SortingTaskArrive>();
        }

        /// <summary>
        /// 0 混仓道在皮带上的数量
        /// 1 混仓卡烟报警
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SortingTaskArrive GetSortingTaskArrive(string id)
        {
            return DataPortal.Fetch<SortingTaskArrive>(id);

        }

        private SortingTaskArrive()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void DataPortal_Fetch(string id)
        {
            using (BypassPropertyChecks)
            {
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText =
                            "SELECT * FROM t_sortingtaskarrive WHERE id = " + id;
                        
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            dr.Read();
                            Id = dr.GetString("Id");
                            OutportCODE = dr.GetString("OutportCODE");
                            Value = dr.GetString("Value");
                            ADDRESSCODE = dr.GetString("ADDRESSCODE");
                        }
                    }

                }
                
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Insert()
        {
            using (BypassPropertyChecks)
            {
                using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        StringBuilder SQL = new StringBuilder();
                        SQL.Append("INSERT ");
                        SQL.Append("   INTO T_SORTINGTASKARRIVE ");
                        SQL.Append("        ( ");
                        SQL.Append("            ID,OUTPORTCODE,ADDRESSCODE,VALUE ");
                        SQL.Append("        ) ");
                        SQL.Append("        VALUES ");
                        SQL.Append("        ( ");
                        SQL.Append("            @ID,@OUTPORTCODE,@ADDRESSCODE,@VALUE ");
                        SQL.Append("        )");
                        cm.CommandText = SQL.ToString();
                        cm.Parameters.AddWithValue("@ID", GetProperty(IdProperty));
                        cm.Parameters.AddWithValue("@OUTPORTCODE", GetProperty(OutportCODEProperty));
                        cm.Parameters.AddWithValue("@ADDRESSCODE", GetProperty(ADDRESSCODEProperty));
                        cm.Parameters.AddWithValue("@VALUE", GetProperty(ValueProperty));
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Update()
        {
            using (BypassPropertyChecks)
            {
                using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        StringBuilder SQL = new StringBuilder();
                        SQL.Append("UPDATE T_SORTINGTASKARRIVE ");
                        SQL.Append("    SET ID = @ID,OUTPORTCODE = @OUTPORTCODE,ADDRESSCODE = @ADDRESSCODE,VALUE = @VALUE ");
                        SQL.Append("  WHERE ID = @ID");
                        cm.CommandText = SQL.ToString();

                        cm.Parameters.AddWithValue("@ID", Id);
                        cm.Parameters.AddWithValue("@OUTPORTCODE", OutportCODE);
                        cm.Parameters.AddWithValue("@ADDRESSCODE", ADDRESSCODE);
                        cm.Parameters.AddWithValue("@VALUE", Value);
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }

        //private void Child_DeleteSelf(System.Data.SQLite.SQLiteConnection cn)
        //{
        //    using (var cm = cn.CreateCommand())
        //    {
        //        cm.CommandText = "delete from [t_SortingTaskArrive] where [SortingTaskArriveId] = @SortingTaskArriveId";
        //        cm.Parameters.AddWithValue("@SortingTaskArriveId", Id);
        //        cm.ExecuteNonQuery();
        //    }
        //}

        #endregion

        //#region  Exists

        //public static bool Exists(int id, string name)
        //{
        //    return ExistsCommand.Exists(id, name);
        //}

        //[Serializable]
        //private class ExistsCommand : CommandBase
        //{
        //    private int _id;
        //    private string _name;
        //    private bool _exists;

        //    public bool SortingTaskArriveExists
        //    {
        //        get { return _exists; }
        //    }

        //    public static bool Exists(int id, string name)
        //    {
        //        ExistsCommand result = DataPortal.Execute(new ExistsCommand(id, name));
        //        return result.SortingTaskArriveExists;
        //    }

        //    private ExistsCommand(int id, string name)
        //    {
        //        _id = id;
        //        _name = name;
        //    }

        //    protected override void DataPortal_Execute()
        //    {
        //        using (var cn = new System.Data.SQLite.SQLiteConnection(AppUtility.AppUtil._LocalConnectionString))
        //        {
        //            cn.Open();
        //            using (var cm = cn.CreateCommand())
        //            {
        //                cm.CommandText = "SELECT COUNT(*) FROM [t_SortingTaskArrive] WHERE [SortingTaskArriveId] <> @id AND [Name] = @name";
        //                cm.Parameters.AddWithValue("@id", _id);
        //                cm.Parameters.AddWithValue("@name", _name);
        //                var count = (int)cm.ExecuteScalar();
        //                _exists = (count > 0);
        //            }
        //        }
        //    }
        //}

        //#endregion
    }
}
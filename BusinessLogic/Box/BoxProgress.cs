using System;
using System.Text;
using AppUtility;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Box
{
    [Serializable]
    public class BoxProgress : BusinessBase<BoxProgress>
    {
        private static PropertyInfo<string> IdProperty = RegisterProperty<string>(o => o.ID, "标识号");

        public string ID
        {
            get { return GetProperty(IdProperty); }
            set { LoadProperty(IdProperty, value); }
        }

        private static PropertyInfo<int> STATUSProperty = RegisterProperty<int>(o => o.STATUS, "分拣任务状态");

        public int STATUS
        {
            get { return GetProperty(STATUSProperty); }
            set { SetProperty(STATUSProperty, value); }
        }



       
        private static PropertyInfo<DateTime?> SORTINGTIMEProperty = RegisterProperty<DateTime?>(o => o.SORTINGTIME, "分拣开始时间");

        public DateTime? SORTINGTIME
        {
            get { return GetProperty(SORTINGTIMEProperty); }
            set { LoadProperty(SORTINGTIMEProperty, value); }
        }

        private static PropertyInfo<DateTime?> FINISHTIMEProperty = RegisterProperty<DateTime?>(o => o.FINISHTIME, "分拣完成时间");

        public DateTime? FINISHTIME
        {
            get { return GetProperty(FINISHTIMEProperty); }
            set { LoadProperty(FINISHTIMEProperty, value); }
        }

        #region  Factory Methods

        private BoxProgress()
        {
            /* require use of factory methods */
        }


        public static BoxProgress NewBoxProgress(string taskid)
        {
            var boxProgress = DataPortal.Create<BoxProgress>();
            boxProgress.ID = Guid.NewGuid().ToString();
            boxProgress.FINISHTIME = null;
            return boxProgress;
        }

        /// <summary>
        /// 获取烟包进度信息
        /// </summary>
        public static BoxProgress GetBoxProgress(string taskid)
        {
            return DataPortal.Fetch<BoxProgress>(new SingleCriteria<BoxProgress, string>(taskid));
        }

        #endregion

        #region  Data Access
        

        private void DataPortal_Fetch(SingleCriteria<BoxProgress, string> criteria)
        {
            using (BypassPropertyChecks)
            {
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText =
                            "SELECT * FROM T_BOX WHERE id = @id";
                        cm.Parameters.AddWithValue("@id", criteria.Value);
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            dr.Read();
                            LoadProperty(STATUSProperty, dr.GetInt32("STATUS"));
                            LoadProperty(SORTINGTIMEProperty, dr.GetDateTime("SORTINGTIME"));
                            LoadProperty(FINISHTIMEProperty, dr.GetDateTime("FINISHTIME"));
                            LoadProperty(IdProperty, dr.GetString("Id"));
                        }
                    }

                }
            }
        }

        //[Transactional(TransactionalTypes.Manual)]
        //protected override void DataPortal_Insert()
        //{
        //    using (BypassPropertyChecks)
        //    {
        //        using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
        //        {
        //            cn.Open();
        //            using (MySqlTransaction tran = cn.BeginTransaction())
        //            {
        //                using (var cm = cn.CreateCommand())
        //                {
        //                    StringBuilder SQL = new StringBuilder();
        //                    SQL.Append("INSERT ");
        //                    SQL.Append("   INTO T_BOXPROGRESS ");
        //                    SQL.Append("        ( ");
        //                    SQL.Append("            ID,STATUS,TASKID,SORTINGTIME,FINISHTIME ");
        //                    SQL.Append("        ) ");
        //                    SQL.Append("        VALUES ");
        //                    SQL.Append("        ( ");
        //                    SQL.Append("@id,@STATUS,@TASKID,@SORTINGTIME,@FINISHTIME");
        //                    SQL.Append("        )");

        //                    cm.CommandText = SQL.ToString();
        //                    cm.Parameters.AddWithValue("@id", ID);
        //                    cm.Parameters.AddWithValue("@STATUS", STATUS);
        //                    cm.Parameters.AddWithValue("@TASKID", TASKID);
        //                    cm.Parameters.AddWithValue("@SORTINGTIME", SORTINGTIME);
        //                    cm.Parameters.AddWithValue("@FINISHTIME", FINISHTIME);
        //                    cm.ExecuteNonQuery();



        //                    SQL = new StringBuilder();
        //                    SQL.Append("INSERT ");
        //                    SQL.Append("   INTO T_BOXPROGRESS_HISTORY ");
        //                    SQL.Append("        ( ");
        //                    SQL.Append("            ID,STATUS,TASKID,SORTINGTIME,FINISHTIME ");
        //                    SQL.Append("        ) ");
        //                    SQL.Append("        VALUES ");
        //                    SQL.Append("        ( ");
        //                    SQL.Append("@id,@STATUS,@TASKID,@SORTINGTIME,@FINISHTIME");
        //                    SQL.Append("        )");

        //                    cm.CommandText = SQL.ToString();
                            
        //                    cm.ExecuteNonQuery();
        //                }
        //                tran.Commit();
        //            }
        //        }
        //    }
        //}



        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Update()
        {
            using (BypassPropertyChecks)
            {
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (MySqlTransaction tran = cn.BeginTransaction())
                    {
                        try
                        {
                            using (var cm = cn.CreateCommand())
                            {
                                cm.Transaction = tran;
                                cm.CommandText =
                                    "update T_BOX set status = @status,SORTINGTIME = @SORTINGTIME,FINISHTIME = @FINISHTIME where id = @taskid";
                                cm.Parameters.AddWithValue("@status", STATUS);
                                cm.Parameters.AddWithValue("@SORTINGTIME", SORTINGTIME);
                                cm.Parameters.AddWithValue("@FINISHTIME", FINISHTIME);
                                cm.Parameters.AddWithValue("@taskid", ID);
                                cm.ExecuteNonQuery();

                                cm.CommandText =
                                    "update T_BOX_HISTORY set status = @status,SORTINGTIME = @SORTINGTIME,FINISHTIME = @FINISHTIME where id = @taskid";
                                

                                cm.ExecuteNonQuery();
                            }
                            tran.Commit();
                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
        }

        #endregion


       
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AppUtility;
using BusinessLogic.Log;
using BusinessLogic.Search;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.INTASKS
{
    /// <summary>
    /// 表示一个只读的消息列表
    /// </summary>
    [Serializable]
    public class InTaskList : ReadOnlyListBase<InTaskList, InTask>
    {
        #region  Factory Methods

        //监控日志
        private static MonitorLog monitorLog;

        /// <summary>
        /// Get a setting bsaed on its id value.
        /// </summary>
        /// <param name="id">Id value of the setting to return.</param>
        public InTask GetInTaskById(string id)
        {
            foreach (var item in this)
                if (item.ID == id)
                    return item;
            return null;
        }

        /// <summary>
        /// 获取未完成的补货任务列表
        /// </summary>
        public static InTaskList GetAllInTaskList()
        {
            InTaskList InTaskList= DataPortal.Fetch<InTaskList>();
            
            return InTaskList;
        }

        /// <summary>
        /// 获取需要补货的下一个任务,状态为0
        /// </summary>
        public static InTask GetComfirmRequestInTask()
        {
            InTaskList intasklist = GetFinInTaskList("0");

            if (intasklist.Count > 0)
                return GetFinInTaskList("0")[0];
            else
                return null;
        }

        /// <summary>
        /// 获取已完成的补货任务列表
        /// </summary>
        public static InTaskList GetFinInTaskList(string status)
        {
            return DataPortal.Fetch<InTaskList>(status);
        }

        /// <summary>
        /// 获取到某一序号为止所有的补货卷烟名称
        /// </summary>
        public static List<string> GetInTaskCigNamesByIndex(int index)
        {
            List<InTask> nextinTaskList = new List<InTask>();
            List<string> inTaskListNames = new List<string>();

            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();

                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT * FROM T_INTASK t WHERE t.type = 0 and t.STATUS = 1 order by t.SEQUENCENO desc limit 1";
                    //cm.Parameters.AddWithValue("@id", criteria.Value);
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {

                            InTask InTask;
                            InTask = InTask.GetInTask(dr);
                            nextinTaskList.Add(InTask);

                        }
                    }
                }


                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT * FROM (SELECT * FROM T_INTASK t WHERE t.type = 0 and t.status = 1 order by t.SEQUENCENO desc limit 4) t ORDER BY t.sequenceno";
                    //cm.Parameters.AddWithValue("@id", criteria.Value);
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {

                            InTask InTask;
                            InTask = InTask.GetInTask(dr);
                            nextinTaskList.Add(InTask);

                        }
                    }
                }


                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT * FROM T_INTASK t WHERE t.type = 0 and (t.status = 0  or t.status IS NULL) order by t.SEQUENCENO limit 4";
                    //cm.Parameters.AddWithValue("@id", criteria.Value);
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            
                            InTask InTask;
                            InTask = InTask.GetInTask(dr);
                            nextinTaskList.Add(InTask);
                            
                        }
                    }
                }
            }



            foreach (InTask inTask in nextinTaskList)
            {
                //if (inTask.INDEXNO > index)
                //{
                    inTaskListNames.Add(inTask.CIGNAME + "-" + inTask.BARCODE + "-" + inTask.INDEXNO);
                //}
            }

            return inTaskListNames;
        }


        /// <summary>
        /// 按条件查询补货任务列表
        /// </summary>
        public static InTaskList GetSearchInTaskList(string orderdate, string taskno, string cigcode, string cigname,string linecode,string sublinecode)
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            queryBuilder.orderdate = orderdate;
            queryBuilder.taskno = taskno;
            queryBuilder.cigcode = cigcode;
            queryBuilder.cigname = cigname;
            queryBuilder.linecode = linecode;
            queryBuilder.sublinecode = sublinecode;
            return DataPortal.Fetch<InTaskList>(queryBuilder);
        }


        /// <summary>
        /// 补货任务是否已完成
        /// </summary>
        public static bool IsInTaskFinish()
        {
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT count(1) FROM T_INTASK t  WHERE t.type = 0 and t.status = 0";
                    //cm.Parameters.AddWithValue("@id", criteria.Value);
                    int i = Convert.ToInt32(cm.ExecuteScalar());
                    if (i > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private InTaskList()
        {
            /* require use of factory methods */
        }

        #endregion


        #region  Data Access

        private void DataPortal_Fetch()
        {
            
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText =
                            "SELECT * FROM T_INTASK t WHERE t.type = 0  order by t.SEQUENCENO";
                        //cm.Parameters.AddWithValue("@id", criteria.Value);
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                IsReadOnly = false;
                                InTask InTask;
                                InTask = InTask.GetInTask(dr);
                                Add(InTask);
                                IsReadOnly = true;
                            }
                        }
                    }
                }
            
        }


        private void DataPortal_Fetch(string status)
        {
            if (status != "0")
            {
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText =
                            "SELECT  * FROM T_INTASK t WHERE t.type = 0 and t.status = " + status + " order by t.SEQUENCENO desc";
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                IsReadOnly = false;
                                InTask InTask;
                                InTask = InTask.GetInTask(dr);
                                Add(InTask);
                                IsReadOnly = true;
                            }
                        }

                    }
                }
            }
            else
            {
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText =
                            "SELECT  * FROM T_INTASK t WHERE t.type = 0 and t.status = " + status + " order by t.SEQUENCENO";
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                IsReadOnly = false;
                                InTask InTask;
                                InTask = InTask.GetInTask(dr);
                                Add(InTask);
                                IsReadOnly = true;
                            }
                        }

                    }
                }
            }
        }


        private void DataPortal_Fetch(QueryBuilder queryBuilder)
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT * FROM t_intask_history t  WHERE ");
                    SQL.Append("(1 = 1 and ((@INTASKNO is null) or (INTASKNO = @INTASKNO))) AND " +
                               "(1 = 1 and ((@ORDERDATE is null) or (ORDERDATE = @ORDERDATE))) AND " +
                               "(1 = 1 and ((@linecode is null) or (linecode = @linecode))) AND " +
                               "(1 = 1 and ((@sublinecode is null) or (sublinecode = @sublinecode))) AND " +
                               "((1 = 1 and ((@CigCode is null) or (CigCode = @CigCode))) OR " +
                               "(1 = 1 and ((@CigName is null) or (CigName like '%" + queryBuilder.cigname + "%')))) order by t.linecode,t.sublinecode,t.SEQUENCENO");
                    
                    cm.CommandText = SQL.ToString();
                    cm.Parameters.AddWithValue("@INTASKNO", queryBuilder.taskno);
                    cm.Parameters.AddWithValue("@ORDERDATE", queryBuilder.orderdate);
                    cm.Parameters.AddWithValue("@CigCode", queryBuilder.cigcode);
                    cm.Parameters.AddWithValue("@CigName", queryBuilder.cigname);
                    cm.Parameters.AddWithValue("@sublinecode", queryBuilder.sublinecode);
                    cm.Parameters.AddWithValue("@linecode", queryBuilder.linecode);
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            InTask InTask;
                            InTask = InTask.GetInTask(dr);
                            Add(InTask);
                        }
                        IsReadOnly = true;
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        #endregion
    }
}
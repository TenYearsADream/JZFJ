// -----------------------------------------------------------------------
// <copyright file="MessageList.cs"
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
using System.Data.SqlClient;
using AppUtility;
using BusinessLogic.Messages;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.SortingTask
{
    /// <summary>
    /// 表示一个只读的消息列表
    /// </summary>
    [Serializable]
    public class AbnSortingLineTaskList : ReadOnlyListBase<AbnSortingLineTaskList, AbnSortingLineTask>
    {
        #region  Factory Methods

        //监控日志
        private static MonitorLog monitorLog;

        /// <summary>
        /// Get a setting bsaed on its id value.
        /// </summary>
        /// <param name="id">Id value of the setting to return.</param>
        public AbnSortingLineTask GetAbnSortingLineTaskById(string id)
        {
            foreach (var item in this)
                if (item.ID == id)
                    return item;
            return null;
        }

        public static AbnSortingLineTaskList GetNonAbnSortingLineTaskList()
        {
            AbnSortingLineTaskList abnSortingLineTaskList = DataPortal.Fetch<AbnSortingLineTaskList>();

            return abnSortingLineTaskList;
        }

        public static AbnSortingLineTaskList GetFinAbnSortingLineTaskList(string status)
        {
            return DataPortal.Fetch<AbnSortingLineTaskList>(status);
        }


        public static bool IsSortingFinish()
        {
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (MySqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT count(1) FROM T_SORTING_LINE_TASK_ABNORMAL t WHERE t.status <> 2";
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


        public static bool IsSortingStart()
        {
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (MySqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT count(1) FROM T_SORTING_LINE_TASK_ABNORMAL t  WHERE t.status = 1  or t.status = 0";
                    //cm.Parameters.AddWithValue("@id", criteria.Value);
                    int i = Convert.ToInt32(cm.ExecuteScalar());
                    if (i > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private AbnSortingLineTaskList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void DataPortal_Fetch()
        {

            using (var cn = new MySqlConnection((AppUtil._LocalConnectionString)))
                {
                    cn.Open();
                    using (MySqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText =
                            "SELECT * FROM T_SORTING_LINE_TASK_ABNORMAL t WHERE t.status = 0 order by t.indexno";
                        //cm.Parameters.AddWithValue("@id", criteria.Value);
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                IsReadOnly = false;
                                AbnSortingLineTask abnSortingLineTask;
                                abnSortingLineTask = AbnSortingLineTask.GetAbnSortingLineTask(dr);
                                Add(abnSortingLineTask);
                                IsReadOnly = true;
                            }
                        }

                        //foreach (AbnSortingLineTask st in this)
                        //{
                        //    // load child objects
                        //    using (MySqlCommand cmProducts = cn.CreateCommand())
                        //    {
                        //        cmProducts.CommandText =
                        //            "SELECT * FROM T_SORTING_LINE_DETAIL_TASK_ABNORMAL tl WHERE tl.taskid =  @id";
                        //        cmProducts.Parameters.AddWithValue("@id", st.ID);
                        //        using (var drTaskDetails = new SafeDataReader(cmProducts.ExecuteReader()))
                        //        {
                        //            st.SortingLineTaskDetails = (AbnSortingLineTaskDetails.GetAbnSortingLineTaskDetails(drTaskDetails));
                        //        }
                        //    }
                        //}
                    }

                    
                }
            
        }


        private void DataPortal_Fetch(string status)
        {
            
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (MySqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText =
                            "SELECT * FROM T_SORTING_LINE_TASK_ABNORMAL t WHERE t.status = "+ status +" order by t.indexno desc";
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                IsReadOnly = false;
                                AbnSortingLineTask abnSortingLineTask;
                                abnSortingLineTask = AbnSortingLineTask.GetAbnSortingLineTask(dr);
                                Add(abnSortingLineTask);
                                IsReadOnly = true;
                            }
                        }

                        //foreach (AbnSortingLineTask st in this)
                        //{
                        //    // load child objects
                        //    using (MySqlCommand cmProducts = cn.CreateCommand())
                        //    {
                        //        cmProducts.CommandText =
                        //            "SELECT * FROM T_SORTING_LINE_DETAIL_TASK_ABNORMAL tl WHERE tl.taskid =  @id";
                        //        cmProducts.Parameters.AddWithValue("@id", st.ID);
                        //        using (var drTaskDetails = new SafeDataReader(cmProducts.ExecuteReader()))
                        //        {
                        //            st.SortingLineTaskDetails =
                        //                (AbnSortingLineTaskDetails.GetAbnSortingLineTaskDetails(drTaskDetails));
                        //        }
                        //    }
                        //}

                    }
                }
            
        }

        #endregion
    }
}
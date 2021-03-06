﻿// -----------------------------------------------------------------------
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
using System.Text;
using AppUtility;
using BusinessLogic.Messages;
using BusinessLogic.Search;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BusinessLogic.SortingTask
{
    /// <summary>
    /// 表示一个只读的消息列表
    /// </summary>
    [Serializable]
    public class SortingLineTaskList : ReadOnlyListBase<SortingLineTaskList, SortingLineTask>
    {
        #region  Factory Methods

        //监控日志
        private static MonitorLog monitorLog;

        /// <summary>
        /// Get a setting bsaed on its id value.
        /// </summary>
        /// <param name="id">Id value of the setting to return.</param>
        public SortingLineTask GetSortingLineTaskById(string id)
        {
            foreach (var item in this)
                if (item.ID == id)
                    return item;
            return null;
        }

        public static SortingLineTaskList GetNonSortingLineTaskList(bool isall)
        {
            SortingLineTaskList sortingLineTaskList= DataPortal.Fetch<SortingLineTaskList>(isall);
            
            return sortingLineTaskList;
        }

        public static SortingLineTaskList GetFinSortingLineTaskList(QueryCondition queryCondition)
        {
            return DataPortal.Fetch<SortingLineTaskList>(queryCondition);
        }


        public static SortingLineTaskList GetSortingLineTaskHistoryList(SearchArgs searchArgs)
        {
            return DataPortal.Fetch<SortingLineTaskList>(searchArgs);
        }


        public static bool IsSortingFinish()
        {
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (MySqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT count(1) FROM T_SORTING_LINE_TASK t WHERE t.status <> 2";
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
                        "SELECT count(1) FROM T_SORTING_LINE_TASK t WHERE t.status = 1";
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
                

        //static public string SortingTest()
        //{
        //    StringBuilder custno = new StringBuilder();

        //    using (var cn = new MySqlConnection((AppUtil._FjInfoConnectionString)))
        //    {
        //        cn.Open();
        //        using (MySqlCommand cm = cn.CreateCommand())
        //        {
                    
        //            StringBuilder SQL = new StringBuilder();
        //            SQL.Append("SELECT DISTINCT o.id,CONCAT(o.orderno,IFNULL(st.sortingindex,'')) AS orderno,o.customerno,c.shortname,od.cigaretteno,ci.cigarettename,od.amount,CONCAT(1+sl.1stoffset,'') AS taskno,st.indexno AS seq,l.deliverlineno,l.deliverlinename, CONCAT(p.orderDate,' 0:00:00') AS orderDate,CONCAT(IFNULL('2015-09-16',p.pickdate),' 0:00:00') AS pickDate,sl.1stline,1 AS pallete ");
        //            SQL.Append("FROM t_order o ");
        //            SQL.Append("JOIN t_client c                     ON c.customerno=o.customerno ");
        //            SQL.Append("JOIN tsp_plan p                     ON p.orderdate='2015-09-15' AND p.taskno='1' ");
        //            SQL.Append("JOIN tsp_sortingline pl             ON pl.planid=p.code  AND pl.lineid='7eb39480-2459-11e4-b9fd-74d43587ef93' ");
        //            SQL.Append("JOIN tsp_sortinglinedeliverline pdl ON pdl.sortinglineid=pl.code ");
        //            SQL.Append("JOIN t_line l                       ON l.deliverlineno=c.deliverlineid AND l.deliverlineno=pdl.code ");
        //            SQL.Append("JOIN t_orderdetail od               ON od.orderno=o.orderno ");
        //            SQL.Append("JOIN t_ciginfo ci                   ON ci.cigaretteno=od.cigaretteno ");
        //            SQL.Append("JOIN t_sorting_line_task st         ON st.orderdate='2015-09-15' AND st.sortingtaskno='1' AND st.custcode=o.customerno AND picklineid='7eb39480-2459-11e4-b9fd-74d43587ef93' ");
        //            SQL.Append("JOIN t_sorting_line_detail_task sd  ON st.id=sd.taskid AND od.cigaretteno=sd.cigcode ");
        //            SQL.Append("JOIN t_sortingline sl               ON sl.id='7eb39480-2459-11e4-b9fd-74d43587ef93' ");
        //            SQL.Append("WHERE o.orderdate='2015-09-15' ");
        //            SQL.Append("ORDER BY st.indexno,ci.cigaretteno");
        //            cm.CommandText =
        //                SQL.ToString();
                    

        //            //cm.Parameters.AddWithValue("@id", criteria.Value);
        //            using (var dr = new SafeDataReader(cm.ExecuteReader()))
        //            {
        //                while (dr.Read())
        //                {
        //                    custno.Append(dr.GetString("id"));
        //                    custno.Append(dr.GetString("orderno"));

        //                }
        //            }
        //        }

        //        return custno.ToString();
        //    }
        //}
        
        private SortingLineTaskList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void DataPortal_Fetch(bool isall)
        {

            using (var cn = new MySqlConnection((AppUtil._LocalConnectionString)))
                {
                    cn.Open();
                    using (MySqlCommand cm = cn.CreateCommand())
                    {
                        if (isall)
                        {
                            cm.CommandText =
                            "SELECT * FROM T_SORTING_LINE_TASK t WHERE t.status = 0 or t.status is null order by t.indexno";
                        }
                        else
                        {
                            cm.CommandText =
                            "SELECT * FROM T_SORTING_LINE_TASK t WHERE t.status = 0 or t.status is null order by t.indexno limit 100";
                        }
                        
                        //cm.Parameters.AddWithValue("@id", criteria.Value);
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                IsReadOnly = false;
                                SortingLineTask sortingLineTask;
                                sortingLineTask = SortingLineTask.GetSortingLineTask(dr);
                                Add(sortingLineTask);
                                IsReadOnly = true;
                            }
                        }
                    }

                    
                }
            
        }


        private void DataPortal_Fetch(QueryCondition queryCondition)
        {
            
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (MySqlCommand cm = cn.CreateCommand())
                    {
                        //用3状态代替查询1，2两种状态
                        if (queryCondition.Status == "3")
                        {
                            cm.CommandText =
                            "SELECT * FROM T_SORTING_LINE_TASK t WHERE t.status <> 0 order by t.indexno desc limit 100";
                        }
                        else
                        {
                            if (queryCondition.IsAll)
                            {
                                cm.CommandText =
                                "SELECT * FROM T_SORTING_LINE_TASK t WHERE t.status = " + queryCondition.Status + " order by t.indexno " + queryCondition.Sqce;
                            }
                            else
                            {
                                cm.CommandText =
                                    "SELECT * FROM T_SORTING_LINE_TASK t WHERE t.status = " + queryCondition.Status + " order by t.indexno "+ queryCondition.Sqce + " limit 100";
                            }
                        }
                        
                        
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                IsReadOnly = false;
                                SortingLineTask sortingLineTask;
                                sortingLineTask = SortingLineTask.GetSortingLineTask(dr);
                                Add(sortingLineTask);
                                IsReadOnly = true;
                            }
                        }

                        if (queryCondition.Status == "1")
                        {
                            foreach (SortingLineTask st in this)
                            {
                                // load child objects
                                using (MySqlCommand cmProducts = cn.CreateCommand())
                                {
                                    cmProducts.CommandText =
                                        "SELECT * FROM T_SORTING_LINE_DETAIL_TASK tl WHERE tl.taskid =  @id";
                                    cmProducts.Parameters.AddWithValue("@id", st.ID);
                                    using (var drTaskDetails = new SafeDataReader(cmProducts.ExecuteReader()))
                                    {
                                        st.SortingLineTaskDetails =
                                            (SortingLineTaskDetails.GetSortingLineTaskDetails(drTaskDetails));
                                    }
                                }
                            }
                        }
                        

                    }
                }
            
        }


        private void DataPortal_Fetch(SearchArgs searchArgs)
        {

            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (MySqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT * FROM T_SORTING_LINE_TASK t  where 1=1 ";

                    if (!string.IsNullOrEmpty(searchArgs.OrderDate))
                    {
                        cm.CommandText += " and t.ORDERDATE = '" + searchArgs.OrderDate + "'";
                    }

                    if (!string.IsNullOrEmpty(searchArgs.Batch))
                    {
                        cm.CommandText += " and t.SORTINGTASKNO = '" + searchArgs.Batch + "'";
                    }

                    if (!string.IsNullOrEmpty(searchArgs.LineCode))
                    {
                        cm.CommandText += " and t.PICKLINECODE = '" + searchArgs.LineCode + "'";
                    }

                    if (!string.IsNullOrEmpty(searchArgs.Customer))
                    {
                        cm.CommandText += " and t.CUSTCODE like  '%" + searchArgs.Customer + "%' or t.CUSTNAME like  '%" + searchArgs.Customer + "%'";
                    }
                    if (!string.IsNullOrEmpty(searchArgs.OutPort))
                    {
                        if (searchArgs.OutPort != "0")
                        {
                            cm.CommandText += " and t.outport = '" + searchArgs.OutPort + "'";
                        }                       
                        
                    }
                    cm.CommandText += " order by PICKLINECODE,indexno";

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            IsReadOnly = false;
                            SortingLineTask sortingLineTask;
                            sortingLineTask = SortingLineTask.GetSortingLineTask(dr);
                            Add(sortingLineTask);
                            IsReadOnly = true;
                        }
                    }
                }
            }

        }

        #endregion
    }

    public class QueryCondition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status">状态（1下达、2完成）</param>
        /// <param name="isall">是否显示全记录</param>
        /// <param name="picklinecode">分拣线号</param>
        public QueryCondition(string status,bool isall,string picklinecode,string sqce)
        {
            Status = status;
            IsAll = isall;
            PickLineCode = picklinecode;
            Sqce = sqce;
        }
        public string Status { get; set; }
        public bool IsAll { get; set; }
        public string PickLineCode { get; set; }
        public string Sqce { get; set; }
    }
}
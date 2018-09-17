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
using System.Collections.Generic;
using System.Text;
using AppUtility;
using BusinessLogic.Search;
using BusinessLogic.SortingTask;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.DisplayBoards
{
    /// <summary>
    /// 表示一个只读的消息列表
    /// </summary>
    [Serializable]
    public class DynamicBoxTaskList : ReadOnlyListBase<DynamicBoxTaskList, DynamicBoxTask>
    {
        #region  Factory Methods


        public static DynamicBoxTaskList GetDynamicBoxTaskList(QueryCondition queryCondition)
        {
            DynamicBoxTaskList dynamicBoxTaskList = DataPortal.Fetch<DynamicBoxTaskList>(queryCondition);
            
            return dynamicBoxTaskList;
        }

        public int GetSumQty()
        {
            int qty = 0;
            foreach (DynamicBoxTask dynamicBoxTask in this)
            {
                qty += dynamicBoxTask.InQty;
            }
            return qty;
        }


        public static List<string> GetDynamicBoxList()
        {
            List<string> boxcodes = new List<string>();
            using (var cn = new MySqlConnection((AppUtil._LocalConnectionString)))
            {
                cn.Open();
                using (MySqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT DISTINCT(lb.boxCode) FROM t_sorting_line_task t JOIN T_SORTING_LINE_DETAIL_TASK td ON t.id=td.taskid JOIN t_linebox lb ON td.lineboxcode=lb.boxcode WHERE isdynamicbox=1";

                    //cm.Parameters.AddWithValue("@id", criteria.Value);
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            boxcodes.Add(dr["boxCode"].ToString());
                        }
                    }
                }


            }
            return boxcodes;
        }




        private DynamicBoxTaskList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void DataPortal_Fetch(QueryCondition queryCondition)
        {

            using (var cn = new MySqlConnection((AppUtil._LocalConnectionString)))
                {
                    cn.Open();
                    using (MySqlCommand cm = cn.CreateCommand())
                    {

                        StringBuilder SQL = new StringBuilder();
                        SQL.Append("SELECT ");
                        SQL.Append(" td.id,   lb.boxname, ");
                        SQL.Append("    t.indexno, ");
                        SQL.Append("    lineboxcode, ");
                        SQL.Append("    cigcode, ");
                        SQL.Append("    qty AS inqty, ");
                        SQL.Append("    t.shortname, ");
                        SQL.Append("    t.linename, ");
                        SQL.Append("    td.cigname ");
                        SQL.Append("FROM ");
                        SQL.Append("    t_sorting_line_task t ");
                        SQL.Append("JOIN ");
                        SQL.Append("    T_SORTING_LINE_DETAIL_TASK td ");
                        SQL.Append("ON ");
                        SQL.Append("    t.id=td.taskid ");
                        SQL.Append("JOIN ");
                        SQL.Append("    t_linebox lb ");
                        SQL.Append("ON ");
                        SQL.Append("    td.lineboxcode=lb.boxcode ");
                        SQL.Append("WHERE ");
                        SQL.Append("    isdynamicbox=1 ");
                        SQL.Append("AND LINEBOXCODE = " + queryCondition.BoxCode + " And td.isin = " + queryCondition.Instatus);
                        SQL.Append(" ORDER BY ");
                        SQL.Append("    t.indexno " + queryCondition.Sequence + ", ");
                        SQL.Append("    td.cigcode " + queryCondition.Sequence);

                        cm.CommandText = SQL.ToString();
                      
                        
                        //cm.Parameters.AddWithValue("@id", criteria.Value);
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                IsReadOnly = false;
                                DynamicBoxTask dynamicBoxTask;
                                dynamicBoxTask = DynamicBoxTask.GetDynamicBoxTask(dr);
                                Add(dynamicBoxTask);
                                IsReadOnly = true;
                            }
                        }
                    }

                    
                }
            
        }

        public class QueryCondition
        {
            
            public QueryCondition(string boxcode,int instatus,string sequence)
            {
                BoxCode = boxcode;
                Instatus = instatus;
                Sequence = sequence;
            }
            public string BoxCode { get; set; }
            public int Instatus { get; set; }
            public string Sequence { get; set; }
        }

        #endregion
    }

   
}
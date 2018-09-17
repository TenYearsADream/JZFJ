using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Search;
using BusinessLogic.SortingTask;
using Csla;
using MySql.Data.MySqlClient;
using Csla.Data;

namespace BusinessLogic.Box
{
    /// <summary>
    /// 
    /// </summary>
    /// <author></author>
    /// <remarks>2011/3/3 9:46</remarks>
    [Serializable]
    public class CigBoxInfoList : ReadOnlyListBase<CigBoxInfoList,CigBoxInfo>
    {
        #region  Business Methods

        #endregion

        #region  Factory Methods

        private static CigBoxInfoList _list;


        /// <summary>
        /// 获取未完成烟包列表
        /// </summary>
        public static CigBoxInfoList GetNonCigBoxList(QueryCondition queryCondition)
        {
            return DataPortal.Fetch<CigBoxInfoList>(queryCondition);
            
        }

        /// <summary>
        /// 获取某一类型的烟包列表（常规或异形）
        /// </summary>
        public CigBoxInfo GetListByTypeCode(string id)
        {
            foreach (var item in this)
                if (item.ID == id)
                    return item;
            return null;
        }

        /// <summary>
        /// 获取所有烟包的条烟数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetSumCigQty(string id)
        {
            int sumcigqty = 0;
            foreach (var item in this)
                sumcigqty += item.BOXQTY;
            return sumcigqty;
        }



        /// <summary>
        /// 通过客户代码获取烟包
        /// </summary>
        static public List<CigBoxInfo> GetBoxInfoByCustiomNo(string custno,string indexno,string picklinecode)
        {
            List<CigBoxInfo> boxInfoList = new List<CigBoxInfo>();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT     * ");
                    SQL.Append("   FROM t_box a ");
                    SQL.Append("   JOIN t_sorting_line_task b ");
                    SQL.Append("     ON b.custcode = a.CUSTOMERNO and a.linecode = b.picklinecode");
                    SQL.Append(" join t_client c on a.CUSTOMERNO = c.CUSTOMERNO ");
                    SQL.Append("  WHERE a.CUSTOMERNO = '" + custno + "' and a.indexno = " + indexno );
                    SQL.Append(" ORDER BY BOXSEQ");
                    
                    
                    cm.CommandText = SQL.ToString();
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            CigBoxInfo info = new CigBoxInfo(dr);
                            // apply filter if necessary
                            boxInfoList.Add(info);
                        }
                    }
                }
            }
            return boxInfoList;
        }

        /// <summary>
        /// 通过序号获取烟包
        /// </summary>
        static public List<CigBoxInfo> GetBoxInfoByIndex(string sindexno,string eindexno, string picklinecode,string abpicklinecode)
        {
            List<CigBoxInfo> boxInfoList = new List<CigBoxInfo>();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT ");
                    SQL.Append("    * ");
                    SQL.Append("FROM ");
                    SQL.Append("    ( ");
                    SQL.Append("        SELECT ");
                    SQL.Append("            a.*,b.LINENAME,b.CORPNAME, ");
                    SQL.Append("            c.ADDRESS, ");
                    SQL.Append("            c.SHORTNAME custname ");
                    SQL.Append("        FROM ");
                    SQL.Append("            t_box a ");
                    SQL.Append("        JOIN ");
                    SQL.Append("            t_sorting_line_task b ");
                    SQL.Append("        ON ");
                    SQL.Append("            b.custcode = a.CUSTOMERNO ");
                    SQL.Append("        AND a.linecode = b.picklinecode ");
                    SQL.Append("        JOIN ");
                    SQL.Append("            t_client c ");
                    SQL.Append("        ON ");
                    SQL.Append("            a.CUSTOMERNO = c.CUSTOMERNO ");
                    SQL.Append("        WHERE ");
                    SQL.Append("            a.indexno >= " + sindexno + " ");
                    SQL.Append("        AND a.INDEXNO <= " + eindexno + " ");
                    SQL.Append("        AND a.LINECODE = '" + picklinecode + "') t1 ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( ");
                    SQL.Append("        SELECT ");
                    SQL.Append("            CUSTOMERNO, ");
                    SQL.Append("            SUM(BOXQTY) AbnoCount ");
                    SQL.Append("        FROM ");
                    SQL.Append("            t_box ");
                    SQL.Append("        WHERE ");
                    SQL.Append("            LINECODE = '" + abpicklinecode  + "' ");
                    SQL.Append("        GROUP BY ");
                    SQL.Append("            CUSTOMERNO) t2 ");
                    SQL.Append("ON ");
                    SQL.Append("    t1.customerno = t2.CUSTOMERNO ");
                    SQL.Append("ORDER BY ");
                    SQL.Append("    t1.indexno, ");
                    SQL.Append("    t1.boxseq");

                    cm.CommandText = SQL.ToString();
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            CigBoxInfo info = new CigBoxInfo(dr);
                            // apply filter if necessary
                            boxInfoList.Add(info);
                        }
                    }
                }
            }
            return boxInfoList;
        }



        /// <summary>
        /// 通过序号获取烟包
        /// </summary>
        static public int GetBoxIndex(string indexno, string boxseq,string picklinecode)
        {
            
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "SELECT count(1) as boxindex FROM t_box WHERE (INDEXNO < " + indexno + " OR (INDEXNO = " + indexno + " AND BOXSEQ<=" + boxseq + ")) and linecode = '"+ picklinecode  +"' ORDER BY INDEXNO,BOXSEQ";
                    
                   return Convert.ToInt32(cm.ExecuteScalar());
                   
                }
            }
            return 0;
        }






        /// <summary>
        /// 获取已完成的烟包列表
        /// </summary>
        public static CigBoxInfoList GetFinCigBoxList(QueryCondition queryCondition)
        {
            return DataPortal.Fetch<CigBoxInfoList>(queryCondition);
        }

        /// <summary>
        /// 通过查询条件查询烟包列表
        /// </summary>
        public static CigBoxInfoList GetCigBoxList(string orderdate, string taskno, string picklinecode, string customername)
        {
            Search.SearchArgs searchArgs = new SearchArgs();
            searchArgs.OrderDate = orderdate;
            searchArgs.Batch = taskno;
            searchArgs.LineCode = picklinecode;
            searchArgs.Customer = customername;
            return DataPortal.Fetch<CigBoxInfoList>(searchArgs);
        }

        /// <summary>
        /// 通过查询条件查询烟包包数
        /// </summary>
        public static int GetAbnoCigBoxCount(string orderdate, string taskno, string picklinecode, string custcode)
        {
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "select count(1) from t_box b where  b.LINECODE = @PICKLINECODE AND b.CUSTOMERNO = @CUSTCODE  ";
                    
                    
                    cm.Parameters.AddWithValue("@PICKLINECODE", picklinecode);
                    cm.Parameters.AddWithValue("@CUSTCODE", custcode);
                    try
                    {
                        return Convert.ToInt32(cm.ExecuteScalar());
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        return 0;
                    }
                }
            }
        }


        /// <summary>
        /// 通过查询条件查询烟包条数量
        /// </summary>
        public static int GetAbnoCigBoxNum(string orderdate, string taskno, string picklinecode, string custcode)
        {
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT CUSTOMERNO,SUM(BOXQTY) boxqty FROM t_box WHERE LINECODE = '" + picklinecode + "' AND CUSTOMERNO = '"+ custcode + "' GROUP BY CUSTOMERNO";

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            return dr.GetInt32("boxqty");
                        }
                    }
                }
            }
            return 0;
        }

       
        public static void InvalidateCache()
        {
            _list = null;
        }

        private CigBoxInfoList()
        {
            /* require use of factory methods */
        }



        #endregion

        #region  Data Access

        private void DataPortal_Fetch(bool isall)
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();

                    SQL.Append("SELECT     * ");
                    SQL.Append("   FROM t_box a ");
                    SQL.Append("   JOIN ");
                    SQL.Append("        (SELECT DISTINCT(t.custcode),t.custname,t.linename,t.corpname ");
                    SQL.Append("               FROM(SELECT     * ");
                    SQL.Append("                           FROM t_sorting_line_task ");
                    SQL.Append("                      UNION ");
                    SQL.Append("                     SELECT     * ");
                    SQL.Append("                           FROM t_sorting_line_task_abnormal) t) b ");
                    SQL.Append("     ON b.custcode = a.CUSTOMERNO ");
                    SQL.Append("  WHERE a.status = 0 ");
                    SQL.Append("ORDER BY a.LINECODE,a.INDEXNO,a.BOXSEQ");
                    if (!isall)
                    {
                        SQL.Append(" limit 100");
                    }
                    cm.CommandText = SQL.ToString();

                    
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            var info = new CigBoxInfo(dr);
                            // apply filter if necessary
                            this.Add(info);
                        }
                        IsReadOnly = true;
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        private void DataPortal_Fetch(QueryCondition queryCondition)
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    if (queryCondition.IsAll)
                    {
                        SQL.Append("SELECT     * ");
                        SQL.Append("   FROM t_box a ");
                        SQL.Append("   LEFT JOIN t_sorting_line_task b");
                        SQL.Append("     ON b.custcode = a.CUSTOMERNO ");
                        SQL.Append("  WHERE a.linecode = '" + queryCondition.PickLineCode + "'");
                        if (queryCondition.Status == "0")
                        {
                            SQL.Append(" and (a.status is null or a.status = " + queryCondition.Status + ")");
                        }
                        else
                        {
                            SQL.Append(" and a.status = " + queryCondition.Status);
                        }
                        SQL.Append(" ORDER BY a.LINECODE,a.INDEXNO,a.BOXSEQ");
                        cm.CommandText = SQL.ToString();
                    }
                    else
                    {
                        SQL.Append("SELECT     * ");
                        SQL.Append("   FROM t_box a ");
                        SQL.Append("   LEFT JOIN t_sorting_line_task b");
                        SQL.Append("     ON b.custcode = a.CUSTOMERNO ");
                        SQL.Append("  WHERE  a.linecode = '" + queryCondition.PickLineCode + "'");
                        if (queryCondition.Status == "0")
                        {
                            SQL.Append(" and (a.status is null or a.status = " + queryCondition.Status + ")");
                        }
                        else
                        {
                            SQL.Append(" and a.status = " + queryCondition.Status);
                        }
                        SQL.Append(" ORDER BY a.LINECODE,a.INDEXNO,a.BOXSEQ limit 100");
                        cm.CommandText = SQL.ToString();
                    }

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            var info = new CigBoxInfo(dr);
                            // apply filter if necessary
                            this.Add(info);
                        }
                        IsReadOnly = true;
                    }
                }
            }
            RaiseListChangedEvents = true;
        }


        private void DataPortal_Fetch(Search.SearchArgs searchArgs)
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "select b.*,s.CUSTNAME,s.LINENAME,s.corpname from t_box_history b Left JOIN (select DISTINCT(CUSTCODE),CUSTNAME,LINENAME,corpname from t_sorting_line_task_history where (1 = 1 and ((@SORT_DATE is null) or (ORDERDATE = @SORT_DATE)))) s on b.CUSTOMERNO = s.CUSTCODE  where " +
                        "(1 = 1 and ((@SORTINGTASKNO is null) or (b.SORTINGTASKNO = @SORTINGTASKNO))) AND " + 
                        "(1 = 1 and ((@SORT_DATE is null) or (b.ORDERDATE = @SORT_DATE))) AND " +
                         "(1 = 1 and ((@PICKLINECODE is null) or (b.LINECODE = @PICKLINECODE))) AND " +
                        "(1 = 1 and ((@CUSTNAME is null) or (s.CUSTNAME like '%" + searchArgs.Customer + "%')))" +
                        " order by LINECODE,INDEXNO,BOXSEQ ";
                    cm.Parameters.AddWithValue("@SORTINGTASKNO", searchArgs.Batch);
                    cm.Parameters.AddWithValue("@SORT_DATE", searchArgs.OrderDate);
                    cm.Parameters.AddWithValue("@PICKLINECODE", searchArgs.LineCode);
                    cm.Parameters.AddWithValue("@CUSTNAME", searchArgs.Customer);
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            var info = new CigBoxInfo(dr);
                            // apply filter if necessary
                            this.Add(info);
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

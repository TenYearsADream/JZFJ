using System;
using System.Text;
using Csla;
using MySql.Data.MySqlClient;
using Csla.Data;

namespace BusinessLogic.Search
{
    /// <summary>
    /// 
    /// </summary>
    /// <author></author>
    /// <remarks>2011/3/3 9:46</remarks>
    [Serializable]
    public class SortingCigInfoList : ReadOnlyListBase<SortingCigInfoList, SortingCigInfo>
    {
        #region  Business Methods

        #endregion

        #region  Factory Methods

        private static SortingCigInfoList _list;

        
        public static SortingCigInfoList GetList(string orderdate,string taskno,string cigcode,string cigname)
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            queryBuilder.orderdate = orderdate;
            queryBuilder.taskno = taskno;
            queryBuilder.cigcode = cigcode;
            queryBuilder.cigname = cigname;


            _list = DataPortal.Fetch<SortingCigInfoList>(queryBuilder);
            return _list;
        }

        public static SortingCigInfoList GetList()
        {
           _list = DataPortal.Fetch<SortingCigInfoList>();
            return _list;
        }

        
        public static void InvalidateCache()
        {
            _list = null;
        }

        private SortingCigInfoList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void DataPortal_Fetch(QueryBuilder queryBuilder)
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT     sh.orderdate,sh.SORTINGTASKNO,sdh.CIGCODE,sdh.CIGNAME,SUM(sdh.QTY) qty ");
                    SQL.Append("   FROM t_sorting_line_task_history sh ");
                    SQL.Append("   JOIN t_sorting_line_detail_task_history sdh ");
                    SQL.Append("     ON sh.ID = sdh.TASKID where");
                    SQL.Append("(1 = 1 and ((@SORTINGTASKNO is null) or (sh.SORTINGTASKNO = @SORTINGTASKNO))) AND " +
                               "(1 = 1 and ((@SORT_DATE is null) or (sh.ORDERDATE = @SORT_DATE))) AND " +
                               "(1 = 1 and ((@CigCode is null) or (sdh.CigCode = @CigCode))) AND " +
                               "(1 = 1 and ((@CigName is null) or (sdh.CigName like '%" + queryBuilder.cigname + "%')))");
                    SQL.Append(" GROUP BY sh.orderdate,sh.SORTINGTASKNO,sdh.CIGCODE,sdh.CIGNAME");
                    cm.CommandText = SQL.ToString();
                    cm.Parameters.AddWithValue("@SORTINGTASKNO", queryBuilder.taskno);
                    cm.Parameters.AddWithValue("@SORT_DATE", queryBuilder.orderdate);
                    cm.Parameters.AddWithValue("@CigCode", queryBuilder.cigcode);
                    cm.Parameters.AddWithValue("@CigName", queryBuilder.cigname);
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            var info = new SortingCigInfo(dr);
                            // apply filter if necessary
                            this.Add(info);
                        }
                        IsReadOnly = true;
                    }
                }
            }
            RaiseListChangedEvents = true;
        }


        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT     sh.orderdate,sh.SORTINGTASKNO,sdh.CIGCODE,sdh.CIGNAME,SUM(sdh.QTY) qty ");
                    SQL.Append("   FROM t_sorting_line_task sh ");
                    SQL.Append("   JOIN t_sorting_line_detail_task sdh ");
                    SQL.Append("     ON sh.ID = sdh.TASKID where sh.status = 1");
                    SQL.Append(" GROUP BY sh.orderdate,sh.SORTINGTASKNO,sdh.CIGCODE,sdh.CIGNAME");
                    cm.CommandText = SQL.ToString();
                    
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            var info = new SortingCigInfo(dr);
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

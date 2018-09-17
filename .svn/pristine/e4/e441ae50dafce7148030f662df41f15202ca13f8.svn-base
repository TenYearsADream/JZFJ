using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Search
{
    public class LineBoxProcessList:ReadOnlyListBase<LineBoxProcessList,LineBoxProcessInfo>
    {
        #region  Business Methods

        #endregion

        #region  Factory Methods

        private static LineBoxProcessList _list;

        
        public static LineBoxProcessList GetList(string type)
        {
            _list = DataPortal.Fetch<LineBoxProcessList>(type);
            return _list;
        }

        public static LineBoxProcessList GetList()
        {
            _list = DataPortal.Fetch<LineBoxProcessList>();
            return _list;
        }

        
        public static void InvalidateCache()
        {
            _list = null;
        }

        private LineBoxProcessList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void DataPortal_Fetch(string type)
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    if (type.ToLower() == "分拣")
                    {
                        SQL.Append("SELECT  l.BOXCODE, l.BOXNAME, tt.CIGCODE, CASE WHEN l.isdynamicbox = 1 THEN '混仓' ELSE tt.CIGNAME END cigname, ifnull(tt.TOTQTY,0) TOTQTY, ifnull(tw.NONQTY, 0) NONQTY, IFNULL(ty.FINQTY, 0) FINQTY ");
                        SQL.Append("FROM ");
                        SQL.Append("    (SELECT * ");
                        SQL.Append("        FROM t_linebox ");
                        SQL.Append("        WHERE boxCode <=89 ");
                        SQL.Append("    )l ");
                        SQL.Append("LEFT JOIN ");
                        SQL.Append("    (SELECT   sd.LINEBOXCODE,   sd.LINEBOXNAME,   sd.CIGCODE,   sd.CIGNAME,   SUM(sd.QTY) TOTQTY ");
                        SQL.Append("        FROM   t_sorting_line_detail_task sd ");
                        SQL.Append("        GROUP BY   sd.LINEBOXCODE,   sd.LINEBOXNAME ");
                        SQL.Append("         ");
                        SQL.Append("        ORDER BY   lineboxname ");
                        SQL.Append("    ) tt ON l.boxcode = tt.LINEBOXCODE ");
                        SQL.Append("LEFT JOIN ");
                        SQL.Append("    (SELECT  sd.LINEBOXCODE,  sd.LINEBOXNAME,  sd.CIGCODE,  sd.CIGNAME,  SUM(sd.QTY) NONQTY ");
                        SQL.Append("        FROM  t_sorting_line_task s ");
                        SQL.Append("        JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                        SQL.Append("        WHERE  s. STATUS = 0 OR s. STATUS = 1 OR s.status = null ");
                        SQL.Append("        GROUP BY  sd.LINEBOXCODE,  sd.LINEBOXNAME ");
                        SQL.Append("        ORDER BY   lineboxname ");
                        SQL.Append("    ) tw ON tt.LINEBOXCODE = tw.LINEBOXCODE ");
                        SQL.Append(" ");
                        SQL.Append("LEFT JOIN ");
                        SQL.Append("    (SELECT  sd.LINEBOXCODE,  sd.LINEBOXNAME,  sd.CIGCODE,  sd.CIGNAME,  SUM(sd.QTY) FINQTY ");
                        SQL.Append("        FROM  t_sorting_line_task s ");
                        SQL.Append("        JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                        SQL.Append("        WHERE  s. STATUS = 2 ");
                        SQL.Append("        GROUP BY  sd.LINEBOXCODE,  sd.LINEBOXNAME ");
                        SQL.Append("    ) ty ON tt.LINEBOXCODE = ty.LINEBOXCODE order by l.boxname" );
                    }
                    else if (type.ToLower() == "盘点")
                    {
                            SQL = new StringBuilder();
                            SQL.Append("SELECT lb.BOXCODE, lb.BOXNAME,tt.CIGCODE,tt.CIGNAME,  ifnull(tt.TOTQTY,0) TOTQTY, ifnull(tw.NONQTY, 0) NONQTY, IFNULL(ty.FINQTY, 0) FINQTY ");
                            SQL.Append("FROM ");
                            SQL.Append("    (SELECT * ");
                            SQL.Append("        FROM t_linebox lb ");
                            SQL.Append("        WHERE lb.putNum <> 5 AND lb.boxCode <=84 ");
                            SQL.Append("    ) lb ");
                            SQL.Append("LEFT JOIN ");
                            SQL.Append("    (SELECT   sd.LINEBOXCODE,sd.lineboxname,sd.CIGCODE,sd.CIGNAME,     SUM(sd.QTY) TOTQTY ");
                            SQL.Append("        FROM   t_sorting_line_detail_task sd ");
                            SQL.Append("        GROUP BY   sd.LINEBOXCODE ");
                            SQL.Append("         ");
                            SQL.Append("        ORDER BY   lineboxname ");
                            SQL.Append("    ) tt ON lb.BOXCODE = tt.LINEBOXCODE ");
                            SQL.Append("LEFT JOIN ");
                            SQL.Append("    (SELECT  sd.LINEBOXCODE,    SUM(sd.QTY) NONQTY ");
                            SQL.Append("        FROM  t_sorting_line_task s ");
                            SQL.Append("        JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                            SQL.Append("        WHERE  s. STATUS = 0 OR s. STATUS = 1 OR s.status = null");
                            SQL.Append("        GROUP BY  sd.LINEBOXCODE ");
                            SQL.Append("     ");
                            SQL.Append("    ) tw ON tt.LINEBOXCODE = tw.LINEBOXCODE ");
                            SQL.Append(" ");
                            SQL.Append("LEFT JOIN ");
                            SQL.Append("    (SELECT  sd.LINEBOXCODE,    SUM(sd.QTY) FINQTY ");
                            SQL.Append("        FROM  t_sorting_line_task s ");
                            SQL.Append("        JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                            SQL.Append("        WHERE  s. STATUS = 2 ");
                            SQL.Append("        GROUP BY  sd.LINEBOXCODE ");
                            SQL.Append("     ");
                            SQL.Append("    ) ty ON tt.LINEBOXCODE = ty.LINEBOXCODE ");
                            SQL.Append("ORDER BY lb.boxname");
                    }
                    
                    cm.CommandText = SQL.ToString();
                    
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            var info = new LineBoxProcessInfo(dr);
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
                    SQL.Append("SELECT lb.BOXCODE, lb.BOXNAME, tt.CIGCODE, tt.CIGNAME, ifnull(tt.TOTQTY, 0) TOTQTY ");
                    SQL.Append("FROM ");
                    SQL.Append("    (SELECT   * ");
                    SQL.Append("        FROM   v_sortinglinebox lb ");
                    SQL.Append("        WHERE   lb.putNum = 5 and lb.LINECODE = '" + AppUtility.AppUtil._SortingLineId + "'");
                    SQL.Append("     ");
                    SQL.Append("    ) lb ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    (SELECT  sd.LINEBOXCODE,  sd.lineboxname,  sd.CIGCODE,  sd.CIGNAME,  SUM(sd.QTY) TOTQTY ");
                    SQL.Append("        FROM  t_sorting_line_detail_task sd ");
                    SQL.Append("        GROUP BY  sd.LINEBOXCODE ");
                    SQL.Append("        ORDER BY  lineboxname ");
                    SQL.Append("    ) tt ON lb.BOXCODE = tt.LINEBOXCODE");

                    cm.CommandText = SQL.ToString();

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            var info = new LineBoxProcessInfo(dr);
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

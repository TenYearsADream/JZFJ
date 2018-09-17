using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtility;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.SortingTask
{
    public class SortingProgress
    {

        public int Qty { get; set; }
        public int TotQty { get; set; }
        public double Progress { get; set; } 

        public static Dictionary<string,string> GetSortingProcessInfo(string sortingdate, string taskno, string picklinecode)
        {
            Dictionary<string, string> sortingDictionary = new Dictionary<string, string>();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm1 = cn.CreateCommand())
                {
                    cm1.CommandText =
                        "SELECT * FROM t_sortline_process WHERE " +
                        "(1 = 1 and ((@SORTINGTASKNO is null) or (SORTINGTASKNO = @SORTINGTASKNO))) AND" +
                        "(1 = 1 and ((@SORT_DATE is null) or (ORDERDATE = @SORT_DATE))) AND" +
                        "(1 = 1 and ((@SORTLINE_CODE is null) or (PICKLINECODE = @SORTLINE_CODE)))";

                    cm1.Parameters.AddWithValue("@SORTINGTASKNO", taskno);
                    cm1.Parameters.AddWithValue("@SORT_DATE", sortingdate);
                    cm1.Parameters.AddWithValue("@SORTLINE_CODE", picklinecode);
                    using (var dr = new Csla.Data.SafeDataReader(cm1.ExecuteReader()))
                    {
                        if (dr.Read())
                        {

                            sortingDictionary.Add("SORTINGTASKNO",dr.GetString("SORTINGTASKNO"));
                            sortingDictionary.Add("ORDERDATE ", dr.GetString("ORDERDATE"));
                            sortingDictionary.Add("PICKLINECODE" , dr.GetString("PICKLINECODE"));
                            sortingDictionary.Add("PICKLINENAME", dr.GetString("PICKLINENAME"));
                            sortingDictionary.Add("QTY_PRODCUT_TOT" , dr.GetInt32("QTY_PRODCUT_TOT").ToString());
                            sortingDictionary.Add("QTY_ROUTE_TOT" , dr.GetInt32("QTY_ROUTE_TOT").ToString());
                            sortingDictionary.Add("QTY_CUSTOMER_TOT" , dr.GetInt32("QTY_CUSTOMER_TOT").ToString());
                            sortingDictionary.Add("QTY_PRODUCT" , dr.GetInt32("QTY_PRODUCT").ToString());
                            sortingDictionary.Add("QTY_ROUTE" , dr.GetInt32("QTY_ROUTE").ToString());
                            sortingDictionary.Add("QTY_CUSTOMER" , dr.GetInt32("QTY_CUSTOMER").ToString());
                            sortingDictionary.Add("CUSTOMER_CODE" , dr.GetString("CUSTOMER_CODE") != "" ? dr.GetString("CUSTOMER_CODE"):"无");
                            sortingDictionary.Add("CUSTOMER_DESC" , dr.GetString("CUSTOMER_DESC") != "" ? dr.GetString("CUSTOMER_DESC"):"无");
                            sortingDictionary.Add("ROUTE_CODE", dr.GetString("ROUTE_CODE") != "" ? dr.GetString("ROUTE_CODE") : "无");
                            sortingDictionary.Add("ROUTE_NAME", dr.GetString("ROUTE_NAME") != "" ? dr.GetString("ROUTE_NAME") : "无");
                            sortingDictionary.Add("RECEIVE_TIME" , dr.GetDateTime("RECEIVE_TIME").ToString());
                            sortingDictionary.Add("EFFICIENCY" , dr.GetDouble("EFFICIENCY").ToString("#0.00") + "条/小时");
                            sortingDictionary.Add("Progress", dr.GetDouble("Progress").ToString());
                        }
                    }
                }
            }
            return sortingDictionary;
        }

        public static SortingProgress GetSortingTaskProgress()
        {
            SortingProgress sortingProcess;
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT ");
                    SQL.Append("    ifnull(a.qty,0) qty , ");
                    SQL.Append("    b.totqty, ");
                    SQL.Append("    ifnull(a.qty,0)/b.totqty * 100 AS Progress ");
                    SQL.Append("FROM ");
                    SQL.Append("    ( ");
                    SQL.Append("        SELECT ");
                    SQL.Append("            SUM(td.QTY) AS qty ");
                    SQL.Append("        FROM ");
                    SQL.Append("            t_sorting_line_task t ");
                    SQL.Append("        JOIN ");
                    SQL.Append("            t_sorting_line_detail_task td ");
                    SQL.Append("        ON ");
                    SQL.Append("            t.id = td.taskid ");
                    SQL.Append("        WHERE ");
                    SQL.Append("            t.STATUS = 2 order by t.picklinecode) a, ");
                    SQL.Append("    ( ");
                    SQL.Append("        SELECT ");
                    SQL.Append("            SUM(td.QTY) AS totqty ");
                    SQL.Append("        FROM ");
                    SQL.Append("            t_sorting_line_task t ");
                    SQL.Append("        JOIN ");
                    SQL.Append("            t_sorting_line_detail_task td ");
                    SQL.Append("        ON ");
                    SQL.Append("            t.id = td.taskid order by t.picklinecode) b");
                    cm.CommandText = SQL.ToString();

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        sortingProcess = new SortingProgress();
                        sortingProcess.Qty = dr.GetInt32("qty");
                        sortingProcess.TotQty = dr.GetInt32("totqty");
                        sortingProcess.Progress = dr.GetDouble("Progress");
                    }
                }
                
            }
            return sortingProcess;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Print
{
    public class PrintRow
    {
        public int RowNum { get; set; }
        public float RowY { get; set; }
    }

    
    public class PrintRows : Dictionary<int, float>
    {
        /// <summary>
        /// 根据行字体的大小动态获取每行的位置
        /// </summary>
        public static PrintRows GetPrintRows()
        {
            PrintRows printRows = new PrintRows();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT c.y+1 row,SUM(c.maxfontsize) y ");
                    SQL.Append("FROM ( ");
                    SQL.Append("    (SELECT 0 y,0 maxfontsize ");
                    SQL.Append("    ) ");
                    SQL.Append("UNION ALL ");
                    SQL.Append("    (SELECT a.y,b.maxfontsize ");
                    SQL.Append("        FROM ");
                    SQL.Append("            (SELECT y,MAX(fontsize) maxfontsize ");
                    SQL.Append("                FROM t_printsetting ");
                    SQL.Append("                GROUP BY y ");
                    SQL.Append("                ORDER BY y ");
                    SQL.Append("            )a ");
                    SQL.Append("        JOIN ");
                    SQL.Append("            (SELECT y,MAX(fontsize) + 8 maxfontsize ");
                    SQL.Append("                FROM t_printsetting ");
                    SQL.Append("                GROUP BY y ");
                    SQL.Append("                ORDER BY y ");
                    SQL.Append("            )b ON a.y >= b.y ");//将小于当前行的每行高度关联出来
                    SQL.Append("    )) c ");
                    SQL.Append("GROUP BY c.y");//合计当前行以上的所有高度得到当前行的相对位置
                    cm.CommandText = SQL.ToString();
                    using (var dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            printRows.Add(dr.GetInt32("row"),dr.GetFloat("y"));
                        }
                    }
                }
            }
            return printRows;
        }
    }
}

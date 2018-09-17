using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Box;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Common
{
    public class SortingLine
    {




        /// <summary>
        /// 获取常规分拣线代码
        /// </summary>
        public static string GetNonSortingLineCode()
        {
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT     * ");
                    SQL.Append("   FROM t_sortingline ");
                    SQL.Append("  WHERE type = 1");

                    cm.CommandText = SQL.ToString();
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            return dr.GetString("linecode");
                        }
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 获取异形烟分拣线代码
        /// </summary>
        public static string GetAbNonSortingLineCode()
        {
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT     * ");
                    SQL.Append("   FROM t_sortingline ");
                    SQL.Append("  WHERE type = 2");

                    cm.CommandText = SQL.ToString();
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            return dr.GetString("linecode");
                        }
                    }
                }
            }
            return "";
        }

        
        }
}

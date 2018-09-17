using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtility;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Common
{
    public class SortingSubLine
    {

        public string sublineCode { get; set; }

        public string sublineName { get; set; }

        public string sublineid { get; set; }

        /// <summary>
        /// 子线的顺序，用于标记界面上小车顺序
        /// </summary>
        public int sequence { get; set; }

        public static string GetSortingSubLineCode(string SortingLineBoxCode)
        {
            string sublinecode;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    cm.CommandText =
                        "SELECT * FROM t_sortingline l JOIN t_sortingsubline sl ON l.ID = sl.lineId JOIN t_linebox li ON li.SUBLINEID = sl.ID WHERE l.LINECODE = '" + AppUtil._SortingLineId + "' AND li.BOXCODE = '" + SortingLineBoxCode + "' ORDER BY sl.sequence";
                    sublinecode = cm.ExecuteScalar().ToString();
                }
            }
            return sublinecode;
        }
    }



    public class SortingSubLineList:List<SortingSubLine>
    {
        /// <summary>
        /// 获取分拣子线代码
        /// </summary>
        public static SortingSubLineList GetSubSortingLineList()
        {
            SortingSubLineList subLineList = new SortingSubLineList();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    cm.CommandText =
                        "SELECT * FROM t_sortingline l JOIN t_sortingsubline sl ON l.ID = sl.lineId WHERE l.LINECODE = '" + AppUtil._SortingLineId + "' ORDER BY sl.sequence";
                    

                    
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            SortingSubLine sortingSubLine = new SortingSubLine();
                            sortingSubLine.sublineCode = dr.GetString("sublineCode");
                            sortingSubLine.sublineName = dr.GetString("sublineName");
                            sortingSubLine.sublineid = dr.GetString("id");
                            sortingSubLine.sequence = dr.GetInt32("sequence");
                            subLineList.Add(sortingSubLine);
                        }
                    }
                }
            }
            return subLineList;
        }
    }
}

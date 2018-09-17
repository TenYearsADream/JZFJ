using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.SortingTask;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Common
{
    public class SortingLineBoxList:List<SortingLineBox>
    {
        /// <summary>
        /// 获取已使用烟道列表
        /// </summary>
        public static SortingLineBoxList GetBindLineBoxList()
        {
            SortingLineBoxList sortingLineBoxList = new SortingLineBoxList();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT DISTINCT(td.LINEBOXCODE),td.LINEBOXNAME,td.CIGCODE,td.CIGNAME,tl.addressCode,tl.putNum,s.SORTINGTASKNO FROM t_sorting_line_task s join t_sorting_line_detail_task td ON s.ID = td.TASKID JOIN t_linebox tl ON td.LINEBOXCODE  = tl.boxCode ORDER by td.LINEBOXNAME");
                    
                    cm.CommandText = SQL.ToString();
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            bool isexist = false;
                            SortingLineBox sortingLineBox = new SortingLineBox();
                            sortingLineBox.Cigcode = dr.GetString("cigcode");
                            sortingLineBox.CigName = dr.GetString("cigname");
                            sortingLineBox.LineBoxCode = dr.GetString("lineboxcode");
                            sortingLineBox.LineBoxName = dr.GetString("lineboxname");
                            sortingLineBox.PlcAddress = dr.GetString("addresscode");
                            sortingLineBox.PutNum = dr.GetInt32("PutNum");
                            sortingLineBox.SortingTaskNo = dr.GetString("SortingTaskNo");
                            
                            for (int i = 0; i < sortingLineBoxList.Count; i++)
                            {
                                if (sortingLineBoxList[i].LineBoxCode == sortingLineBox.LineBoxCode)
                                {
                                    isexist = true;
                                    sortingLineBoxList[i].CigName += "," + sortingLineBox.CigName;
                                    break;
                                }
                            }
                            if (!isexist)
                            {
                                sortingLineBoxList.Add(sortingLineBox);
                            }
                            
                        }
                    }
                }
            }
            return sortingLineBoxList;
        }

        /// <summary>
        /// 获取未使用的烟道列表
        /// </summary>
        public static SortingLineBoxList GetEmptyLineBoxList()
        {
            SortingLineBoxList sortingLineBoxList = new SortingLineBoxList();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT tl.boxCode,tl.boxName,td.CIGCODE,td.CIGNAME,tl.addressCode,tl.putNum FROM t_linebox tl LEFT JOIN t_sorting_line_detail_task td ON td.LINEBOXCODE  = tl.boxCode where tl.boxType = 1 and td.CIGCODE is NULL ORDER by tl.addressCode");

                    cm.CommandText = SQL.ToString();
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            SortingLineBox sortingLineBox = new SortingLineBox();
                            sortingLineBox.Cigcode = dr.GetString("cigcode");
                            sortingLineBox.CigName = dr.GetString("cigname");
                            sortingLineBox.LineBoxCode = dr.GetString("boxcode");
                            sortingLineBox.LineBoxName = dr.GetString("boxname");
                            sortingLineBox.PlcAddress = dr.GetString("addresscode");
                            sortingLineBox.PutNum = dr.GetInt32("PutNum");
                            sortingLineBoxList.Add(sortingLineBox);
                        }
                    }
                }
            }
            return sortingLineBoxList;
        }


        /// <summary>
        /// 获取已使用全部烟道列表
        /// </summary>
        public static SortingLineBoxList GetLineBoxList()
        {
            SortingLineBoxList sortingLineBoxList = new SortingLineBoxList();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT * ");
                    SQL.Append("FROM (SELECT * ");
                    SQL.Append("        FROM t_linebox tl ");
                    SQL.Append("        WHERE tl.ISDYNAMICBOX = 0) tl ");
                    SQL.Append("LEFT JOIN t_sortingsubline sb ON tl.SUBLINEID = sb.ID ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  LINEBOXCODE,  CIGNAME,  cigcode,  SUM(qty) qty ");
                    SQL.Append("        FROM  t_sorting_line_detail_task ");
                    SQL.Append("        GROUP BY  LINEBOXCODE ) sd ON tl.boxcode = sd.LINEBOXCODE ");
                    SQL.Append("UNION ");
                    SQL.Append("SELECT * ");
                    SQL.Append("FROM (SELECT * ");
                    SQL.Append("        FROM t_linebox tl ");
                    SQL.Append("        WHERE tl.ISDYNAMICBOX = 1) tl ");
                    SQL.Append("LEFT JOIN t_sortingsubline sb ON tl.SUBLINEID = sb.ID ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  LINEBOXCODE,  '混合仓',  '',  SUM(qty) qty ");
                    SQL.Append("        FROM  t_sorting_line_detail_task ");
                    SQL.Append("        GROUP BY  LINEBOXCODE ) sd ON tl.boxcode = sd.LINEBOXCODE ");
                    cm.CommandText = SQL.ToString();
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            bool isexist = false;
                            SortingLineBox sortingLineBox = new SortingLineBox();
                            sortingLineBox.Cigcode = dr.GetString("cigcode");
                            sortingLineBox.CigName = dr.GetString("cigname");
                            sortingLineBox.LineBoxCode = dr.GetString("boxcode");
                            sortingLineBox.PutNum = dr.GetInt32("putnum");
                            sortingLineBox.PARENTLINEBOX = dr.GetString("PARENTLINEBOX");
                            sortingLineBox.ABANDONPARENT = dr.GetString("ABANDONPARENT");
                            sortingLineBox.SUBLINEID = dr.GetString("SUBLINEID");
                            sortingLineBox.TOTQTY = dr.GetInt32("qty");
                            sortingLineBox.SublineSeq = dr.GetInt32("sequence");
                            sortingLineBox.IsDynamicbox = dr.GetInt32("ISDYNAMICBOX");
                            sortingLineBoxList.Add(sortingLineBox);
                        }
                    }
                }
            }
            return sortingLineBoxList;
        }


        /// <summary>
        /// 转移烟道卷烟
        /// </summary>
        public static void TransactCigBox(SortingLineBox oldSortingLineBox, SortingLineBox newSortingLineBox)
        {
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
	            using (var cm = cn.CreateCommand())
	            {
		            using (var tran = cn.BeginTransaction())
		            {
			            StringBuilder SQL = new StringBuilder();

			            //更改源烟仓,目的烟仓为特殊烟仓
			            SQL.Append(
                            "UPDATE t_sorting_line_detail_task SET LINEBOXCODE = @newlineboxcode,LINEBOXNAME = @newlineboxname,ADDRESSCODE =@newaddresscode WHERE LINEBOXCODE = @oldlineboxcode");

			            cm.CommandText = SQL.ToString();
			            cm.Parameters.AddWithValue("@newlineboxcode", "999");
			            cm.Parameters.AddWithValue("@newlineboxname", "L999");
			            cm.Parameters.AddWithValue("@newaddresscode", 999);
			            cm.Parameters.AddWithValue("@oldlineboxcode", oldSortingLineBox.LineBoxCode);
			            cm.ExecuteNonQuery();

			           
			            SQL = new StringBuilder();
			            SQL.Append(
				            "UPDATE t_intask SET LINEBOXCODE = @newlineboxcode,LINEBOXNAME = @newlineboxname,ADDRESSCODE =@newaddresscode WHERE LINEBOXCODE = @oldlineboxcode");

			            cm.CommandText = SQL.ToString();
			            cm.Parameters.Clear();
			            cm.Parameters.AddWithValue("@newlineboxcode", "999");
			            cm.Parameters.AddWithValue("@newlineboxname", "L999");
			            cm.Parameters.AddWithValue("@newaddresscode", 999);
			            cm.Parameters.AddWithValue("@oldlineboxcode", oldSortingLineBox.LineBoxCode);

			            cm.ExecuteNonQuery();


                        SQL = new StringBuilder();
                        SQL.Append(
                            "UPDATE t_sorting_line_detail_task SET LINEBOXCODE = @newlineboxcode,LINEBOXNAME = @newlineboxname,ADDRESSCODE =@newaddresscode WHERE LINEBOXCODE = @oldlineboxcode");

                        cm.CommandText = SQL.ToString();
                        cm.Parameters.Clear();
                        cm.Parameters.AddWithValue("@newlineboxcode", "1000");
                        cm.Parameters.AddWithValue("@newlineboxname", "L1000");
                        cm.Parameters.AddWithValue("@newaddresscode", 1000);
                        cm.Parameters.AddWithValue("@oldlineboxcode", newSortingLineBox.LineBoxCode);
                        cm.ExecuteNonQuery();
                       

                        SQL = new StringBuilder();
                        SQL.Append(
                            "UPDATE t_intask SET LINEBOXCODE = @newlineboxcode,LINEBOXNAME = @newlineboxname,ADDRESSCODE =@newaddresscode WHERE LINEBOXCODE = @oldlineboxcode");

                        cm.CommandText = SQL.ToString();
                        cm.Parameters.Clear();
                        cm.Parameters.AddWithValue("@newlineboxcode", "1000");
                        cm.Parameters.AddWithValue("@newlineboxname", "L1000");
                        cm.Parameters.AddWithValue("@newaddresscode", 1000);
                        cm.Parameters.AddWithValue("@oldlineboxcode", newSortingLineBox.LineBoxCode);

                        cm.ExecuteNonQuery();

			            
			            //更改目的烟仓为源烟仓
			            //更改源烟仓为新烟仓

                        SQL = new StringBuilder();
			            SQL.Append(
                            "UPDATE t_sorting_line_detail_task SET LINEBOXCODE = @newlineboxcode,LINEBOXNAME = @newlineboxname,ADDRESSCODE =@newaddresscode WHERE LINEBOXCODE = @oldlineboxcode");

			            cm.CommandText = SQL.ToString();
			            cm.Parameters.Clear();
			            cm.Parameters.AddWithValue("@newlineboxcode", oldSortingLineBox.LineBoxCode);
			            cm.Parameters.AddWithValue("@newlineboxname", oldSortingLineBox.LineBoxName);
			            cm.Parameters.AddWithValue("@newaddresscode", oldSortingLineBox.PlcAddress);
			            cm.Parameters.AddWithValue("@oldlineboxcode", "1000");
			            cm.ExecuteNonQuery();


			            SQL = new StringBuilder();
			            SQL.Append(
				            "UPDATE t_intask SET LINEBOXCODE = @newlineboxcode,LINEBOXNAME = @newlineboxname,ADDRESSCODE =@newaddresscode WHERE LINEBOXCODE = @oldlineboxcode");

			            cm.CommandText = SQL.ToString();
			            cm.Parameters.Clear();
			            cm.Parameters.AddWithValue("@newlineboxcode", oldSortingLineBox.LineBoxCode);
			            cm.Parameters.AddWithValue("@newlineboxname", oldSortingLineBox.LineBoxName);
			            cm.Parameters.AddWithValue("@newaddresscode", oldSortingLineBox.PlcAddress);
			            cm.Parameters.AddWithValue("@oldlineboxcode", "1000");
			            cm.ExecuteNonQuery();


                        SQL = new StringBuilder();
                        SQL.Append(
                            "UPDATE t_sorting_line_detail_task SET LINEBOXCODE = @newlineboxcode,LINEBOXNAME = @newlineboxname,ADDRESSCODE =@newaddresscode WHERE LINEBOXCODE = @oldlineboxcode");

                        cm.CommandText = SQL.ToString();
                        cm.Parameters.Clear();
                        cm.Parameters.AddWithValue("@newlineboxcode", newSortingLineBox.LineBoxCode);
                        cm.Parameters.AddWithValue("@newlineboxname", newSortingLineBox.LineBoxName);
                        cm.Parameters.AddWithValue("@newaddresscode", newSortingLineBox.PlcAddress);
                        cm.Parameters.AddWithValue("@oldlineboxcode", "999");
                        cm.ExecuteNonQuery();


                        SQL = new StringBuilder();
                        SQL.Append(
                            "UPDATE t_intask SET LINEBOXCODE = @newlineboxcode,LINEBOXNAME = @newlineboxname,ADDRESSCODE =@newaddresscode WHERE LINEBOXCODE = @oldlineboxcode");

                        cm.CommandText = SQL.ToString();
                        cm.Parameters.Clear();
                        cm.Parameters.AddWithValue("@newlineboxcode", newSortingLineBox.LineBoxCode);
                        cm.Parameters.AddWithValue("@newlineboxname", newSortingLineBox.LineBoxName);
                        cm.Parameters.AddWithValue("@newaddresscode", newSortingLineBox.PlcAddress);
                        cm.Parameters.AddWithValue("@oldlineboxcode", "999");
                        cm.ExecuteNonQuery();

                        tran.Commit();
		            }
	            }
            }
        }


        /// <summary>
        /// 主界面上非混仓烟道的显示查询SQL
        /// </summary>
        /// <returns></returns>
        public static SortingLineBoxList GetLineNonBoxList()
        {
            SortingLineBoxList sortingLineBoxList = new SortingLineBoxList();

            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();

                    SQL.Append("SELECT  l.boxcode   LINEBOXCODE ,l.boxname LINEBOXname,l.putnum,l.sublineId,null as bindCig,l.addressCode, tt.CIGCODE,tt.CIGNAME,tt.TOTQTY,ifnull(tw.NONQTY,0) NONQTY,IFNULL(ty.FINQTY,0) FINQTY ");
                    SQL.Append("   FROM ");
                    SQL.Append("(SELECT * FROM t_linebox WHERE isDynamicBox = 0 ) l ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("(SELECT     sd.LINEBOXCODE,sd.LINEBOXNAME,sd.CIGCODE,sd.CIGNAME,SUM(sd.QTY) TOTQTY ");
                    SQL.Append("               FROM t_sorting_line_detail_task sd ");
                    SQL.Append("           GROUP BY sd.LINEBOXCODE,sd.LINEBOXNAME,sd.CIGCODE,sd.CIGNAME order by lineboxname) tt ");
                    SQL.Append("     ON tt.LINEBOXCODE = l.boxCode ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("        (SELECT     sd.LINEBOXCODE,sd.LINEBOXNAME,sd.CIGCODE,sd.CIGNAME,SUM(sd.QTY) NONQTY ");
                    SQL.Append("               FROM t_sorting_line_task s ");
                    SQL.Append("               JOIN t_sorting_line_detail_task sd ");
                    SQL.Append("                 ON s.ID = sd.TASKID ");
                    SQL.Append("              WHERE s.STATUS = 0 ");
                    SQL.Append("                    OR ");
                    SQL.Append("                    s.status = 1 ");
                    SQL.Append("           GROUP BY sd.LINEBOXCODE,sd.LINEBOXNAME,sd.CIGCODE,sd.CIGNAME) tw ");
                    SQL.Append("     ON tt.LINEBOXCODE = tw.LINEBOXCODE ");
                    SQL.Append("        AND ");
                    SQL.Append("        tt.cigcode = tw.cigcode ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("        (SELECT     sd.LINEBOXCODE,sd.LINEBOXNAME,sd.CIGCODE,sd.CIGNAME,SUM(sd.QTY) FINQTY ");
                    SQL.Append("               FROM t_sorting_line_task s ");
                    SQL.Append("               JOIN t_sorting_line_detail_task sd ");
                    SQL.Append("                 ON s.ID = sd.TASKID ");
                    SQL.Append("              WHERE s.STATUS = 2 ");
                    SQL.Append("           GROUP BY sd.LINEBOXCODE,sd.LINEBOXNAME,sd.CIGCODE,sd.CIGNAME) ty ");
                    SQL.Append("     ON tt.LINEBOXCODE = ty.LINEBOXCODE ");
                    SQL.Append("        AND ");
                    SQL.Append("        tt.cigcode = ty.cigcode ORDER BY (l.boxcode * 1)");



                    cm.CommandText = SQL.ToString();

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            SortingLineBox sortingLineBox = new SortingLineBox();

                            sortingLineBox.bindCig = dr.GetString("bindCig");
                            sortingLineBox.shelfNum = dr.GetInt32("putnum");
                            //sortingLineBox.sortinglinecode = dr.GetString("sortinglinecode");
                            sortingLineBox.PlcAddress = dr.GetString("addressCode");
                            sortingLineBox.sublineId = dr.GetString("sublineId");
                            sortingLineBox.LineBoxCode = dr.GetString("LINEBOXCODE");
                            sortingLineBox.LineBoxName = dr.GetString("LINEBOXNAME");
                            sortingLineBox.Cigcode = dr.GetString("CigCode");
                            sortingLineBox.CigName = dr.GetString("CigName");
                            sortingLineBox.TOTQTY = dr.GetInt32("TOTQTY");
                            sortingLineBox.NONQTY = dr.GetInt32("NONQTY");
                            sortingLineBox.FINQTY = dr.GetInt32("FINQTY");
                            sortingLineBoxList.Add(sortingLineBox);
                        }
                    }
                }
            }



            return sortingLineBoxList;
        }



        /// <summary>
        /// 主界面上混仓烟道的显示查询SQL
        /// </summary>
        /// <returns></returns>
        public static SortingLineBoxList GetDynamicLineBoxList()
        {
            SortingLineBoxList sortingLineBoxList = new SortingLineBoxList();

            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT l.boxcode LINEBOXCODE, l.boxname LINEBOXname, l.putnum, l.sublineId, NULL AS bindCig, l.addressCode, '' CIGCODE, '混合仓' CIGNAME, tt.TOTQTY, ifnull(tw.NONQTY, 0) NONQTY, IFNULL(ty.FINQTY, 0) FINQTY, IFNULL(tp.PUTQTY, 0) PUTQTY ");
                    SQL.Append("FROM (  SELECT   * ");
                    SQL.Append("        FROM   t_linebox ");
                    SQL.Append("        WHERE   isDynamicBox = 1 ) l ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  sd.LINEBOXCODE,  sd.LINEBOXNAME,  SUM(sd.QTY) TOTQTY ");
                    SQL.Append("        FROM  t_sorting_line_detail_task sd ");
                    SQL.Append("        GROUP BY  sd.LINEBOXCODE,  sd.LINEBOXNAME ");
                    SQL.Append("        ORDER BY  lineboxname ) tt ON tt.LINEBOXCODE = l.boxCode ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  sd.LINEBOXCODE,  sd.LINEBOXNAME,  SUM(sd.QTY) NONQTY ");
                    SQL.Append("        FROM  t_sorting_line_task s ");
                    SQL.Append("        JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                    SQL.Append("        WHERE  s. STATUS = 0 OR s. STATUS = 1 ");
                    SQL.Append("        GROUP BY  sd.LINEBOXCODE,  sd.LINEBOXNAME ) tw ON tt.LINEBOXCODE = tw.LINEBOXCODE ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  sd.LINEBOXCODE,  sd.LINEBOXNAME,  SUM(sd.QTY) FINQTY ");
                    SQL.Append("        FROM  t_sorting_line_task s ");
                    SQL.Append("        JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                    SQL.Append("        WHERE  s. STATUS = 2 ");
                    SQL.Append("        GROUP BY  sd.LINEBOXCODE,  sd.LINEBOXNAME ) ty ON tt.LINEBOXCODE = ty.LINEBOXCODE ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  sd.LINEBOXCODE,  sd.LINEBOXNAME,  '',  '混合仓',  SUM(sd.QTY) PUTQTY ");
                    SQL.Append("        FROM  t_sorting_line_task s ");
                    SQL.Append("        JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                    SQL.Append("        WHERE  s. STATUS = 1 AND sd.`status` = 2 ");
                    SQL.Append("        GROUP BY  sd.LINEBOXCODE,  sd.LINEBOXNAME ) tp ON tt.LINEBOXCODE = tp.LINEBOXCODE ");
                    SQL.Append(" ");
                    SQL.Append("ORDER BY (l.boxcode * 1)");

                    cm.CommandText = SQL.ToString();

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            SortingLineBox sortingLineBox = new SortingLineBox();

                            sortingLineBox.bindCig = dr.GetString("bindCig");
                            sortingLineBox.shelfNum = dr.GetInt32("putnum");
                            //sortingLineBox.sortinglinecode = dr.GetString("sortinglinecode");
                            sortingLineBox.PlcAddress = dr.GetString("addressCode");
                            sortingLineBox.sublineId = dr.GetString("sublineId");
                            sortingLineBox.LineBoxCode = dr.GetString("LINEBOXCODE");
                            sortingLineBox.LineBoxName = dr.GetString("LINEBOXNAME");
                            sortingLineBox.TOTQTY = dr.GetInt32("TOTQTY");
                            sortingLineBox.NONQTY = dr.GetInt32("NONQTY");
                            sortingLineBox.FINQTY = dr.GetInt32("FINQTY");
                            sortingLineBoxList.Add(sortingLineBox);
                        }
                    }
                }
            }



            return sortingLineBoxList;
        }



        public static SortingLineBoxList GetOverLineBoxQty()
        {
            SortingLineBoxList sortingLineBoxList = new SortingLineBoxList();

            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT l.boxcode LINEBOXCODE, l.boxname LINEBOXname, l.putnum, l.sublineId, NULL AS bindCig, l.addressCode, tt.CIGCODE, tt.CIGNAME, tt.TOTQTY, ifnull(tw.NONQTY, 0) NONQTY, IFNULL(ty.FINQTY, 0) FINQTY, IFNULL(tp.PUTQTY,0) PUTQTY ");
                    SQL.Append("FROM (  SELECT   * ");
                    SQL.Append("        FROM   t_linebox ");
                    SQL.Append("        WHERE   isDynamicBox = 0 ) l ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  sd.LINEBOXCODE,  sd.LINEBOXNAME,  sd.CIGCODE,  sd.CIGNAME,  SUM(sd.QTY) TOTQTY ");
                    SQL.Append("        FROM  t_sorting_line_detail_task sd ");
                    SQL.Append("        GROUP BY  sd.LINEBOXCODE,  sd.LINEBOXNAME,  sd.CIGCODE,  sd.CIGNAME ");
                    SQL.Append("        ORDER BY  lineboxname ) tt ON tt.LINEBOXCODE = l.boxCode ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  sd.LINEBOXCODE,  sd.LINEBOXNAME,  sd.CIGCODE,  sd.CIGNAME,  SUM(sd.QTY) NONQTY ");
                    SQL.Append("        FROM  t_sorting_line_task s ");
                    SQL.Append("        JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                    SQL.Append("        WHERE  s. STATUS = 0 OR s. STATUS = 1 ");
                    SQL.Append("        GROUP BY  sd.LINEBOXCODE,  sd.LINEBOXNAME,  sd.CIGCODE,  sd.CIGNAME ) tw ON tt.LINEBOXCODE = tw.LINEBOXCODE AND tt.cigcode = tw.cigcode ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  sd.LINEBOXCODE,  sd.LINEBOXNAME,  sd.CIGCODE,  sd.CIGNAME,  SUM(sd.QTY) FINQTY ");
                    SQL.Append("        FROM  t_sorting_line_task s ");
                    SQL.Append("        JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                    SQL.Append("        WHERE  s. STATUS = 2 ");
                    SQL.Append("        GROUP BY  sd.LINEBOXCODE,  sd.LINEBOXNAME,  sd.CIGCODE,  sd.CIGNAME ) ty ON tt.LINEBOXCODE = ty.LINEBOXCODE AND tt.cigcode = ty.cigcode ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  sd.LINEBOXCODE,  sd.LINEBOXNAME,  sd.CIGCODE,  sd.CIGNAME,  SUM(sd.QTY) PUTQTY ");
                    SQL.Append("        FROM  t_sorting_line_task s ");
                    SQL.Append("        JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                    SQL.Append("        WHERE  s. STATUS = 1 AND sd.`status` = 2 ");
                    SQL.Append("        GROUP BY  sd.LINEBOXCODE,  sd.LINEBOXNAME,  sd.CIGCODE,  sd.CIGNAME ) tp ON tt.LINEBOXCODE = tp.LINEBOXCODE AND tt.cigcode = tp.cigcode ");
                    SQL.Append(" ");
                    SQL.Append(" ");
                    SQL.Append(" ");
                    SQL.Append("ORDER BY (l.boxcode * 1)");

                    cm.CommandText = SQL.ToString();

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            SortingLineBox sortingLineBox = new SortingLineBox();

                            sortingLineBox.bindCig = dr.GetString("bindCig");
                            sortingLineBox.shelfNum = dr.GetInt32("putnum");
                            //sortingLineBox.sortinglinecode = dr.GetString("sortinglinecode");
                            sortingLineBox.PlcAddress = dr.GetString("addressCode");
                            sortingLineBox.sublineId = dr.GetString("sublineId");
                            sortingLineBox.LineBoxCode = dr.GetString("LINEBOXCODE");
                            sortingLineBox.LineBoxName = dr.GetString("LINEBOXNAME");
                            sortingLineBox.Cigcode = dr.GetString("CigCode");
                            sortingLineBox.CigName = dr.GetString("CigName");
                            sortingLineBox.TOTQTY = dr.GetInt32("TOTQTY");
                            sortingLineBox.NONQTY = dr.GetInt32("NONQTY");
                            sortingLineBox.FINQTY = dr.GetInt32("FINQTY");
                            sortingLineBox.PutNum = dr.GetInt32("PUTQTY");
                            sortingLineBoxList.Add(sortingLineBox);
                        }
                    }
                }
            }



            return sortingLineBoxList;

        }

    }


}

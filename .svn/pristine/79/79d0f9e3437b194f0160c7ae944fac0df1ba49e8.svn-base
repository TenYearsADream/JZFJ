using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AppUtility;
using Csla.Data;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace BusinessLogic.DisplayBoards
{
    public class OutPort:Dictionary<string,string>
    {
        /// <summary>
        /// 出口号
        /// </summary>
        public string OutPortNo { get; set; }

        public int Indexno { get; set; }


        public OutPort(int indexno)
        {
            Indexno = indexno;
            Add("OUTPORT", "");
            Add("CUSTNAME", "");
            Add("CUSTCODE", "");
            Add("MAXINDEX", "");
            Add("INDEXNO", "");
            Add("LINENAME", "");
            Add("CORPNAME", "");
            Add("CIGQTY", "");
            Add("BOXCOUNT", "");
            Add("CORPCOUNT", "");
            Add("MAXCORPCOUNT", "");
            Add("LINECOUNT", "");
            Add("MAXLINECOUNT", "");
            Add("COUNTLINE", "");
            Add("MAXCOUNTLINE", "");
            Add("CIGINFO", "");
        }

        public void GetCustInfo()
        {
            GetOutPortInfo();
            GetCustSeq();
        }

        /// <summary>
        /// 出口的相关信息
        /// </summary>
        public void GetOutPortInfo()
        {
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "P_GetOutPortInfo";
                    
                    cm.Parameters.Add(new MySqlParameter("@pindexno", MySqlDbType.Int32));
                    cm.Parameters["@pindexno"].Direction = ParameterDirection.Input;
                    cm.Parameters["@pindexno"].Value = Indexno;
                    
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        if (dr.Read())
                        {
                            if (dr.GetString("OUTPORT").ToString() == "1")
                                this["OUTPORT"] = "A";
                            if (dr.GetString("OUTPORT").ToString() == "2")
                                this["OUTPORT"] = "B";
                            this["CUSTNAME"] = dr.GetString("CUSTNAME");
                            this["CUSTCODE"] = dr.GetString("CUSTCODE");
                            if (IsExistAbnor())
                            {
                                this["CUSTNAME"] += "⊙";
                            }
                            if (IsExistDynamicBoxCig())
                            {
                                this["CUSTNAME"] += "×";
                            }
                            this["INDEXNO"] = dr.GetInt32("INDEXNO").ToString();
                            this["LINENAME"] = dr.GetString("LINENAME");
                            this["CORPNAME"] = dr.GetString("CORPNAME");
                            this["CIGQTY"] = dr.GetString("CIGQTY");
                            this["BOXCOUNT"] = dr.GetString("boxcount");
                            this["MAXINDEX"] = dr.GetString("maxindex");
                        }
                    }
                }

            }
        }


        ///// <summary>
        ///// 当前线路总顺序
        ///// </summary>
        //public void GetLineSeq()
        //{
        //    using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
        //    {
        //        cn.Open();
        //        using (var cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.StoredProcedure;


        //            cm.CommandText = "P_GetLineSeq";

        //            cm.Parameters.Add(new MySqlParameter("@pindexno", MySqlDbType.Int32));
        //            cm.Parameters["@pindexno"].Direction = ParameterDirection.Input;
        //            cm.Parameters["@pindexno"].Value = Indexno;
                    
        //            using (var dr = new SafeDataReader(cm.ExecuteReader()))
        //            {
        //                while (dr.Read())
        //                {
        //                    this["LINECOUNT"]=dr.GetString("linecount");
        //                    this["MAXLINECOUNT"]= dr.GetString("maxlinecount");
                            
        //                }


        //            }
        //        }

        //    }
        //}


        /// <summary>
        /// 当前客户的总顺序
        /// </summary>
        public void GetCustSeq()
        {
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "P_GetCustSeq";

                    cm.Parameters.Add(new MySqlParameter("@pindexno", MySqlDbType.Int32));
                    cm.Parameters["@pindexno"].Direction = ParameterDirection.Input;
                    cm.Parameters["@pindexno"].Value = Indexno;

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this["COUNTLINE"]= dr.GetString("countline");
                            this["MAXCOUNTLINE"] = dr.GetString("maxcountline");
                        }


                    }
                }

            }
        }

        /// <summary>
        /// 获取客户分拣卷烟明细
        /// </summary>
        public Dictionary<string,Color> GetCigInfo(ref int one,ref int two, ref int three)
        {
            Dictionary<string, Color> ciginfo = new Dictionary<string, Color>();
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "P_GetCigInfo";
                    cm.Parameters.Add(new MySqlParameter("@pindexno", MySqlDbType.Int32));

                    cm.Parameters["@pindexno"].Direction = ParameterDirection.Input;
                    cm.Parameters["@pindexno"].Value = Indexno;

                    //带双仓合并的名称
                    //StringBuilder SQL = new StringBuilder();
                    //SQL.Append("SELECT ");
                    //SQL.Append("    CASE ");
                    //SQL.Append("        WHEN g.boxcode IS NULL ");
                    //SQL.Append("        THEN t.lineboxcode ");
                    //SQL.Append("        ELSE concat(CONCAT(t.lineboxcode,'-'),ifnull(g.boxCode,'')) ");
                    //SQL.Append("    END, ");
                    //SQL.Append("    t.cigname, ");
                    //SQL.Append("    t.isdynamicbox, ");
                    //SQL.Append("    t.cigqty ");
                    //SQL.Append("FROM ");
                    //SQL.Append("    ( ");
                    //SQL.Append("        SELECT ");
                    //SQL.Append("            * ");
                    //SQL.Append("        FROM ");
                    //SQL.Append("            ( ");
                    //SQL.Append("                SELECT ");
                    //SQL.Append("                    t.1num LINEBOXCODE, ");
                    //SQL.Append("                    t.CIGNAME, ");
                    //SQL.Append("                    t.isDynamicBox, ");
                    //SQL.Append("                    SUM(t.QTY) CIGQTY, ");
                    //SQL.Append("                    t.groupId ");
                    //SQL.Append("                FROM ");
                    //SQL.Append("                    ( ");
                    //SQL.Append("                        SELECT ");
                    //SQL.Append("                            d.LINEBOXCODE, ");
                    //SQL.Append("                            g.boxCode, ");
                    //SQL.Append("                            CASE ");
                    //SQL.Append("                                WHEN g.boxCode IS NULL ");
                    //SQL.Append("                                THEN d.LINEBOXCODE ");
                    //SQL.Append("                                ELSE g.boxCode ");
                    //SQL.Append("                            END AS 1num, ");
                    //SQL.Append("                            d.CIGNAME, ");
                    //SQL.Append("                            l.isDynamicBox, ");
                    //SQL.Append("                            d.QTY, ");
                    //SQL.Append("                            l.groupId ");
                    //SQL.Append("                        FROM ");
                    //SQL.Append("                            t_sorting_line_task s ");
                    //SQL.Append("                        JOIN ");
                    //SQL.Append("                            t_sorting_line_detail_task d ");
                    //SQL.Append("                        ON ");
                    //SQL.Append("                            s.ID = d.TASKID ");
                    //SQL.Append("                        JOIN ");
                    //SQL.Append("                            t_linebox l ");
                    //SQL.Append("                        ON ");
                    //SQL.Append("                            d.LINEBOXCODE = l.boxCode ");
                    //SQL.Append("                        LEFT JOIN ");
                    //SQL.Append("                            t_linebox g ");
                    //SQL.Append("                        ON ");
                    //SQL.Append("                            l.groupId = g.groupId ");
                    //SQL.Append("                        AND l.putNum = 2 ");
                    //SQL.Append("                        AND g.putNum = 1 ");
                    //SQL.Append("                        WHERE ");
                    //SQL.Append("                            l.putNum IN (1, ");
                    //SQL.Append("                                         2, ");
                    //SQL.Append("                                         5) ");
                    //SQL.Append("                        AND s.INDEXNO = 4 ");
                    //SQL.Append("                        AND l.isDynamicBox = 0 ) t ");
                    //SQL.Append("                GROUP BY ");
                    //SQL.Append("                    t.1num ");
                    //SQL.Append("                UNION ");
                    //SQL.Append("                SELECT ");
                    //SQL.Append("                    d.LINEBOXCODE, ");
                    //SQL.Append("                    d.CIGNAME, ");
                    //SQL.Append("                    l.isDynamicBox, ");
                    //SQL.Append("                    d.QTY, ");
                    //SQL.Append("                    l.groupId ");
                    //SQL.Append("                FROM ");
                    //SQL.Append("                    t_sorting_line_task s ");
                    //SQL.Append("                JOIN ");
                    //SQL.Append("                    t_sorting_line_detail_task d ");
                    //SQL.Append("                ON ");
                    //SQL.Append("                    s.ID = d.TASKID ");
                    //SQL.Append("                JOIN ");
                    //SQL.Append("                    t_linebox l ");
                    //SQL.Append("                ON ");
                    //SQL.Append("                    d.LINEBOXCODE = l.boxCode ");
                    //SQL.Append("                WHERE ");
                    //SQL.Append("                    l.isDynamicBox = 1 ");
                    //SQL.Append("                AND s.INDEXNO =4 ) t ");
                    //SQL.Append("        ORDER BY ");
                    //SQL.Append("            t.LINEBOXCODE * 1) t ");
                    //SQL.Append("LEFT JOIN ");
                    //SQL.Append("    t_linebox g ");
                    //SQL.Append("ON ");
                    //SQL.Append("    t.groupId = g.groupId ");
                    //SQL.Append("AND g.putNum = 2");




                    //StringBuilder SQL = new StringBuilder();
                    //SQL.Append("SELECT ");
                    //SQL.Append("    * ");
                    //SQL.Append("FROM ");
                    //SQL.Append("    ( ");
                    //SQL.Append("        SELECT ");
                    //SQL.Append("            t.1num LINEBOXCODE, ");
                    //SQL.Append("            t.CIGNAME, ");
                    //SQL.Append("            t.isDynamicBox, ");
                    //SQL.Append("            SUM(t.QTY) CIGQTY ");
                    //SQL.Append("        FROM ");
                    //SQL.Append("            ( ");
                    //SQL.Append("                SELECT ");
                    //SQL.Append("                    d.LINEBOXCODE, ");
                    //SQL.Append("                    g.boxCode, ");
                    //SQL.Append("                    CASE ");
                    //SQL.Append("                        WHEN g.boxCode IS NULL ");
                    //SQL.Append("                        THEN d.LINEBOXCODE ");
                    //SQL.Append("                        ELSE g.boxCode ");
                    //SQL.Append("                    END AS 1num, ");
                    //SQL.Append("                    d.CIGNAME, ");
                    //SQL.Append("                    l.isDynamicBox, ");
                    //SQL.Append("                    d.QTY ");
                    //SQL.Append("                FROM ");
                    //SQL.Append("                    t_sorting_line_task s ");
                    //SQL.Append("                JOIN ");
                    //SQL.Append("                    t_sorting_line_detail_task d ");
                    //SQL.Append("                ON ");
                    //SQL.Append("                    s.ID = d.TASKID ");
                    //SQL.Append("                JOIN ");
                    //SQL.Append("                    t_linebox l ");
                    //SQL.Append("                ON ");
                    //SQL.Append("                    d.LINEBOXCODE = l.boxCode ");
                    //SQL.Append("                LEFT JOIN ");
                    //SQL.Append("                    t_linebox g ");
                    //SQL.Append("                ON ");
                    //SQL.Append("                    l.groupId = g.groupId ");
                    //SQL.Append("                AND l.putNum = 2 ");
                    //SQL.Append("                AND g.putNum =1 ");
                    //SQL.Append("                WHERE ");
                    //SQL.Append("                    l.putNum IN (1,2,5) ");
                    //SQL.Append("                AND s.INDEXNO =  " + Indexno + " ");
                    //SQL.Append("                AND l.isDynamicBox = 0 ) t ");
                    //SQL.Append("        GROUP BY ");
                    //SQL.Append("            t.1num ");
                    //SQL.Append("        UNION ");
                    //SQL.Append("        SELECT ");
                    //SQL.Append("            d.LINEBOXCODE, ");
                    //SQL.Append("            d.CIGNAME, ");
                    //SQL.Append("            l.isDynamicBox, ");
                    //SQL.Append("            d.QTY ");
                    //SQL.Append("        FROM ");
                    //SQL.Append("            t_sorting_line_task s ");
                    //SQL.Append("        JOIN ");
                    //SQL.Append("            t_sorting_line_detail_task d ");
                    //SQL.Append("        ON ");
                    //SQL.Append("            s.ID = d.TASKID ");
                    //SQL.Append("        JOIN ");
                    //SQL.Append("            t_linebox l ");
                    //SQL.Append("        ON ");
                    //SQL.Append("            d.LINEBOXCODE = l.boxCode ");
                    //SQL.Append("        WHERE ");
                    //SQL.Append("            l.isDynamicBox = 1 ");
                    //SQL.Append("        AND s.INDEXNO = " + Indexno + ") t ");
                    //SQL.Append("ORDER BY ");
                    //SQL.Append("    t.LINEBOXCODE * 1");
                    //cm.CommandText = SQL.ToString();

                    
 
            

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            //红塔山硬经典和硬经典100名字相同
                            string cigname = dr.GetString("CIGNAME");
                            if (cigname.Contains("红塔山"))
                            {
                                cigname = cigname.Replace("红塔山", "红塔");
                            }
                            Color color = Color.Red;
                            if (Convert.ToInt32(dr.GetString("LINEBOXCODE")) <= 36)
                            {
                                color = Color.LightGreen;
                                one += dr.GetInt32("CIGQTY");
                            }
                            if (Convert.ToInt32(dr.GetString("LINEBOXCODE")) > 36 && Convert.ToInt32(dr.GetString("LINEBOXCODE")) <= 72)
                            {
                                color = Color.Yellow;
                                two += dr.GetInt32("CIGQTY");
                            }
                            if (Convert.ToInt32(dr.GetString("LINEBOXCODE")) >= 72 && Convert.ToInt32(dr.GetString("LINEBOXCODE")) < 90)
                            {
                                color = Color.Aqua;
                                three += dr.GetInt32("CIGQTY");
                            }


                            if (cigname.Replace("(", "").Replace(")", "").Count() > 6)
                            {
                                string cigshortname = AppUtility.AppUtil.DBCToSBC(cigname.Replace("(", "").Replace(")", "")).Substring(0, 6);
                                
                                if (dr.GetInt32("isDynamicBox") == 1)
                                {
                                    ciginfo.Add(dr.GetString("LINEBOXCODE").PadRight(2) + "*｜" + cigshortname + "　" + dr.GetString("CIGQTY"), color);
                                }
                                else
                                {
                                    ciginfo.Add(dr.GetString("LINEBOXCODE").PadRight(2) + " ｜" + cigshortname + "　" + dr.GetString("CIGQTY"), color);
                                }

                            }
                            else
                            {

                                if (dr.GetInt32("isDynamicBox") == 1)
                                {
                                    ciginfo.Add(dr.GetString("LINEBOXCODE").PadRight(2) + "*｜" + AppUtility.AppUtil.DBCToSBC(cigname.Replace("(", "").Replace(")", "").PadRight(6, '　')) + "  " + dr.GetString("CIGQTY"), color);
                                }
                                else
                                {
                                    ciginfo.Add(dr.GetString("LINEBOXCODE").PadRight(2) + " ｜" + AppUtility.AppUtil.DBCToSBC(cigname.Replace("(", "").Replace(")", "").PadRight(6, '　')) + "  " + dr.GetString("CIGQTY"), color);
                                }


                            }
                        }
                    }
                }

            }
            return ciginfo;
        }

        /// <summary>
        /// 获取客户分拣卷烟明细
        /// </summary>
        public List<string> GetDownCigInfo()
        {
            List<string> ciginfo = new List<string>();
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "P_GetCigInfo";
                    cm.Parameters.Add(new MySqlParameter("@pindexno", MySqlDbType.Int32));

                    cm.Parameters["@pindexno"].Direction = ParameterDirection.Input;
                    cm.Parameters["@pindexno"].Value = Indexno;
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            if (Convert.ToInt16(dr.GetString("LINEBOXCODE")) >= 37 && Convert.ToInt16(dr.GetString("LINEBOXCODE")) <= 72)
                            {
                                if (dr.GetString("CIGNAME").Replace("(", "").Replace(")", "").Count() > 6)
                                {
                                    string cigshortname =
                                        dr.GetString("CIGNAME").Replace("(", "").Replace(")", "").Substring(0, 6);
                                    if (Convert.ToInt16(dr.GetString("LINEBOXCODE")) < 10)
                                    {
                                        if (IsExistDynamicBoxCig(dr.GetString("LINEBOXCODE")))
                                        {
                                            ciginfo.Add(dr.GetString("LINEBOXCODE") + "*｜" + cigshortname + "　" +
                                                        dr.GetString("CIGQTY"));
                                        }
                                        else
                                        {
                                            ciginfo.Add(dr.GetString("LINEBOXCODE") + " ｜" + cigshortname + "　" +
                                                        dr.GetString("CIGQTY"));
                                        }
                                    }
                                    else
                                    {
                                        ciginfo.Add(dr.GetString("LINEBOXCODE") + "｜" + cigshortname + "　" +
                                                    dr.GetString("CIGQTY"));
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt16(dr.GetString("LINEBOXCODE")) < 10)
                                    {
                                        if (IsExistDynamicBoxCig(dr.GetString("LINEBOXCODE")))
                                        {
                                            ciginfo.Add(dr.GetString("LINEBOXCODE") + "*｜" +
                                                        dr.GetString("CIGNAME")
                                                            .Replace("(", "")
                                                            .Replace(")", "")
                                                            .PadRight(6, '　') + "  " + dr.GetString("CIGQTY"));
                                        }
                                        else
                                        {
                                            ciginfo.Add(dr.GetString("LINEBOXCODE") + " ｜" +
                                                        dr.GetString("CIGNAME")
                                                            .Replace("(", "")
                                                            .Replace(")", "")
                                                            .PadRight(6, '　') + "  " + dr.GetString("CIGQTY"));
                                        }
                                    }
                                    else
                                    {
                                        ciginfo.Add(dr.GetString("LINEBOXCODE") + "｜" +
                                                    dr.GetString("CIGNAME")
                                                        .Replace("(", "")
                                                        .Replace(")", "")
                                                        .PadRight(6, '　') + "  " + dr.GetString("CIGQTY"));
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return ciginfo;
        }


        /// <summary>
        /// 获取客户分拣卷烟明细
        /// </summary>
        public List<string> GetUpCigInfo()
        {
            List<string> ciginfo = new List<string>();
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "P_GetCigInfo";
                    cm.Parameters.Add(new MySqlParameter("@pindexno", MySqlDbType.Int32));

                    cm.Parameters["@pindexno"].Direction = ParameterDirection.Input;
                    cm.Parameters["@pindexno"].Value = Indexno;
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            if (Convert.ToInt16(dr.GetString("LINEBOXCODE")) <= 36)
                            {
                                if (dr.GetString("CIGNAME").Replace("(", "").Replace(")", "").Count() > 6)
                                {
                                    string cigshortname =
                                        dr.GetString("CIGNAME").Replace("(", "").Replace(")", "").Substring(0, 6);
                                    if (Convert.ToInt16(dr.GetString("LINEBOXCODE")) < 10)
                                    {
                                        if (IsExistDynamicBoxCig(dr.GetString("LINEBOXCODE")))
                                        {
                                            ciginfo.Add(dr.GetString("LINEBOXCODE") + "*｜" + cigshortname + "　" +
                                                        dr.GetString("CIGQTY"));
                                        }
                                        else
                                        {
                                            ciginfo.Add(dr.GetString("LINEBOXCODE") + " ｜" + cigshortname + "　" +
                                                        dr.GetString("CIGQTY"));
                                        }
                                    }
                                    else
                                    {
                                        ciginfo.Add(dr.GetString("LINEBOXCODE") + "｜" + cigshortname + "　" +
                                                    dr.GetString("CIGQTY"));
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt16(dr.GetString("LINEBOXCODE")) < 10)
                                    {
                                        if (IsExistDynamicBoxCig(dr.GetString("LINEBOXCODE")))
                                        {
                                            ciginfo.Add(dr.GetString("LINEBOXCODE") + "*｜" +
                                                        dr.GetString("CIGNAME")
                                                            .Replace("(", "")
                                                            .Replace(")", "")
                                                            .PadRight(6, '　') + "  " + dr.GetString("CIGQTY"));
                                        }
                                        else
                                        {
                                            ciginfo.Add(dr.GetString("LINEBOXCODE") + " ｜" +
                                                        dr.GetString("CIGNAME")
                                                            .Replace("(", "")
                                                            .Replace(")", "")
                                                            .PadRight(6, '　') + "  " + dr.GetString("CIGQTY"));
                                        }
                                    }
                                    else
                                    {
                                        ciginfo.Add(dr.GetString("LINEBOXCODE") + "｜" +
                                                    dr.GetString("CIGNAME")
                                                        .Replace("(", "")
                                                        .Replace(")", "")
                                                        .PadRight(6, '　') + "  " + dr.GetString("CIGQTY"));
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return ciginfo;
        }


        /// <summary>
        /// 是否存在异型烟
        /// </summary>
        public bool IsExistAbnor()
        {
            object b;
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT count(1) FROM t_sorting_line_task_abnormal s WHERE s.indexno = @indexno";
                    cm.Parameters.Add(new MySqlParameter("@indexno", MySqlDbType.Int32));                    
                    cm.Parameters["@indexno"].Value = Indexno;
                    b = cm.ExecuteScalar();
                }

            }
            return Convert.ToBoolean(b);
        }


        /// <summary>
        /// 是否存在混合烟
        /// </summary>
        public bool IsExistDynamicBoxCig()
        {
            object b;
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT COUNT(1) FROM t_sorting_line_task s JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID JOIN t_linebox l ON sd.LINEBOXCODE = l.boxCode WHERE l.isDynamicBox = 1 AND s.indexno  = @indexno";
                    cm.Parameters.Add(new MySqlParameter("@indexno", MySqlDbType.Int32));
                    cm.Parameters["@indexno"].Value = Indexno;
                    b = cm.ExecuteScalar();
                }

            }
            return Convert.ToBoolean(b);
        }


        /// <summary>
        /// 是否存在混合烟
        /// </summary>
        public bool IsExistDynamicBoxCig(string LineboxCode)
        {
            object b;
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT COUNT(1) from t_linebox l  WHERE l.isDynamicBox = 1 AND l.boxCode  = @boxCode";
                    cm.Parameters.Add(new MySqlParameter("@boxCode", MySqlDbType.VarChar, 12));
                    cm.Parameters["@boxCode"].Value = LineboxCode;
                    b = cm.ExecuteScalar();
                }

            }
            return Convert.ToBoolean(b);
        }


        
        /// <summary>
        /// 当前客户的总顺序
        /// </summary>
        public static void SetEffice(int id,int num,int sec)
        {
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {                   

                    cm.CommandText = "insert into test (id,num,time) values (" + id + "," + num + "," + sec + ")";

                    cm.ExecuteNonQuery();
                }

            }
        }

    }
}

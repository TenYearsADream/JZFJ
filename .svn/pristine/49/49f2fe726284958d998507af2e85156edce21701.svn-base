using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Data;
using MySql.Data.MySqlClient;
using BusinessLogic.Search;
using System.Configuration;

namespace BusinessLogic.DisplayBoards
{
    
    public class LedDisplay
    {
       
        Cignames cignames = new Cignames();
        Dictionary<int, Cignames> groupCigName = new Dictionary<int, Cignames>();

        /// <summary>
        /// 获取分拣卷烟名称
        /// </summary>
        public string GetCigNames(int lednumber)
        {
            StringBuilder ledstring = new StringBuilder();
            foreach (string name in groupCigName[lednumber])
            {
                string cigname = AppUtility.AppUtil.DBCToSBC(name);                
                cigname = SubString(cigname);
                ledstring.Append(cigname);                
            }


            //if (lednumber == 8 || lednumber == 2)
            //{
            //    for (int i = 1; i <= 10; i++)
            //    {
            //        ledstring.Append(SubString(""));
            //    }
            //}
            return ledstring.ToString();
        }


        public void GetLedQTY(LineBoxProcessList lineboxprocesslist)
        {
            //LineBoxs.Clear();
            ////LineBoxProcessList lineboxprocesslist = LineBoxProcessList.GetList(ConfigurationSettings.AppSettings["Mode"].ToLower());
            //foreach (LineBoxProcessInfo item in lineboxprocesslist)
            //{
            //    if(!LineBoxs.ContainsKey(Convert.ToInt16( item.LINEBOXCODE)))
            //    {
            //        if (Convert.ToInt16(item.LINEBOXCODE) % 11 == 0)
            //        {
            //            LineBoxs[Convert.ToInt16(item.LINEBOXCODE) - 1] = (Convert.ToInt16(LineBoxs[Convert.ToInt16(item.LINEBOXCODE) - 1])).ToString() + "+" + (item.NONQTY).ToString(); 
            //        }


            //        LineBoxs.Add(Convert.ToInt16( item.LINEBOXCODE),item.NONQTY.ToString());
            //    }
            //    else
            //    {
            //        LineBoxs[Convert.ToInt16(item.LINEBOXCODE)] = (Convert.ToInt16(LineBoxs[Convert.ToInt16(item.LINEBOXCODE)]) + item.NONQTY).ToString(); 
            //    }
            //}
        }



        /// <summary>
        /// 获取LED所有烟道列表
        /// 包括订单中未分拣的卷烟
        /// </summary>
        public void GetLedLineboxs()
        {
            groupCigName.Clear();
            int i = 1;
            int group = 1;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT * ");
                    SQL.Append("FROM ");
                    SQL.Append("    (SELECT   CIGNAME,   boxname,   boxcode,   putnum ");
                    SQL.Append("        FROM ");
                    SQL.Append("            (SELECT     * ");
                    SQL.Append("                FROM     t_linebox lb ");
                    SQL.Append("                WHERE     lb.boxCode <= 84    AND lb.putNum = 1    AND lb.isdynamicbox <> 1    AND (lb.groupId = '' OR lb.groupId IS NULL) ");
                    SQL.Append("            ) lb ");
                    SQL.Append("        LEFT JOIN t_sorting_line_detail_task td ON td.lineboxcode = lb.boxcode ");
                    SQL.Append("        UNION ");
                    SQL.Append("        SELECT   CIGNAME,   boxname,   boxcode,   putnum ");
                    SQL.Append("        FROM ");
                    SQL.Append("            (SELECT     * ");
                    SQL.Append("                FROM     t_linebox lb ");
                    SQL.Append("                WHERE     lb.boxCode <= 84    AND lb.putNum = 2    AND lb.isdynamicbox <> 1 ");
                    SQL.Append("            ) lb ");
                    SQL.Append("        LEFT JOIN t_sorting_line_detail_task td ON td.lineboxcode = lb.boxcode ");
                    SQL.Append("        UNION ");
                    SQL.Append("        SELECT   CIGNAME,   boxname,   boxcode,   putnum ");
                    SQL.Append("        FROM ");
                    SQL.Append("            (SELECT     * ");
                    SQL.Append("                FROM     t_linebox lb ");
                    SQL.Append("                WHERE     lb.boxCode <= 84    AND lb.putNum = 1    AND lb.isdynamicbox <> 1    AND (lb.groupId IN ");
                    SQL.Append("                        (SELECT groupId ");
                    SQL.Append("                            FROM t_linebox ");
                    SQL.Append("                            WHERE putNum = 5 ");
                    SQL.Append("                        )) ");
                    SQL.Append("            ) lb ");
                    SQL.Append("        LEFT JOIN t_sorting_line_detail_task td ON td.lineboxcode = lb.boxcode ");
                    SQL.Append("         ");
                    SQL.Append("        UNION ");
                    SQL.Append("        SELECT    '混合烟仓' cigname,    lb.boxName,    lb.boxCode,    putnum ");
                    SQL.Append("        FROM    t_linebox lb ");
                    SQL.Append("        WHERE    lb.boxCode <= 84   AND lb.putNum = 1   AND lb.isdynamicbox = 1 ");
                    SQL.Append("    ) a ");
                    SQL.Append("ORDER BY a.boxcode * 1");

                    //获取所有通道的卷烟品牌
                    cm.CommandText = SQL.ToString();
                   
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            
                            try
                            {
                                cignames.Add(dr.GetString("cigname"));
                                i++;
                                //LED图片横向只能拼接5个品牌
                                //将70个单通道拼接成14组文字
                                if (i > 5)
                                {
                                    groupCigName.Add(group, cignames);
                                    cignames = new Cignames();
                                    group++;
                                    i = 1;
                                }
                            }
                            catch (Exception)
                            {
                                
                            }
                        }

                    }
                }

            }
            
        }

        public string SubString(string ledstring)
        {
            //卷烟名称大于8个字符
            if (ledstring.Length > 8)
            {
                //去掉左右括号
                ledstring = ledstring.Replace("（", "").Replace("）", "");
                
                if (ledstring.Length > 8)
                {
                    //去掉完后还是大于8个字符，截取前8个显示
                    ledstring = ledstring.Substring(0, 8);
                }
                else
                {
                    //小于等于8个用全角的空格补齐8个
                    ledstring = ledstring.PadRight(8,'　');
                }
            }
            else
            {
                //小于等于8个用全角的空格补齐8个
                ledstring = ledstring.PadRight(8, '　');
            }
            ledstring = ledstring.Replace("（", "　").Replace("）", "　");
            return ledstring;
        }


       

            

         
    }

    internal class Cignames:List<string>
    {

    }
}

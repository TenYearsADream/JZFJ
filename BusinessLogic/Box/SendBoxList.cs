using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Print;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Box
{
    public class SendBoxList:List<SendBoxInfo>
    {
        public static void GetSendBoxList(List<string>indexList,ref List<BusinessLogic.Print.PrintInfo> PSInfos)
        {
            string indexs = "0";
            

            foreach (string s in indexList)
            {
                indexs += "," + s;
            }
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT * ");
                    SQL.Append("FROM (  SELECT   s.CUSTCODE,   s.shortname,   s.LINENAME,   cl.address,   b.*,   sumqty.totqty ");
                    SQL.Append("         ");
                    SQL.Append("        FROM   t_sorting_line_task s ");
                    SQL.Append("        JOIN t_box b ON s.CUSTCODE = b.CUSTOMERNO ");
                    SQL.Append("        JOIN ");
                    SQL.Append("            (SELECT s.ID,SUM(sd.QTY) totqty ");
                    SQL.Append("                FROM t_sorting_line_task s ");
                    SQL.Append("                JOIN t_sorting_line_detail_task sd ON s.ID = sd.TASKID ");
                    SQL.Append("                GROUP BY s.ID) sumqty              ON s.ID = sumqty.ID ");
                    SQL.Append("        JOIN t_client cl                           ON s.CUSTCODE = cl.CUSTOMERNO ");
                    SQL.Append("        ORDER BY   b.INDEXNO,   b.BOXSEQ ) a ");
                    SQL.Append("LEFT JOIN ");
                    SQL.Append("    ( SELECT  CUSTOMERNO,  SUM(BOXQTY) abnboxqty ");
                    SQL.Append("        FROM  t_box ");
                    SQL.Append("        WHERE  LINECODE = '1002' ");
                    SQL.Append("        GROUP BY  CUSTOMERNO ) abn ON a.CUSTCODE = abn.CUSTOMERNO ");
                    SQL.Append("JOIN ");
                    SQL.Append("    ( SELECT  @ROW :=@ROW + 1 boxindex,  a.* ");
                    SQL.Append("        FROM  (   SELECT    s.indexno,    b.boxseq ");
                    SQL.Append("                FROM    t_sorting_line_task s ");
                    SQL.Append("                JOIN t_box b                                                              ON s.CUSTCODE = b.CUSTOMERNO ");
                    SQL.Append("                ORDER BY    s.indexno,    b.boxseq  ) a,  (SELECT @ROW := 0) b ) boxindex ON a.indexno = boxindex.indexno AND a.boxseq = boxindex.boxseq ");
                    SQL.Append("JOIN ");
                    SQL.Append("    (SELECT COUNT(1) cucount ");
                    SQL.Append("        FROM t_sorting_line_task) cu ");
                    SQL.Append("WHERE a.indexno IN (" + indexs + ") ");
                    SQL.Append("ORDER BY a.INDEXNO, a.boxseq");



                    cm.CommandText = SQL.ToString();

                    using (var dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                    {
                        PrintInfo PSInfo;
                        while (dr.Read())
                        {
                            PSInfo = new PrintInfo();
                            PSInfo.CustomerName = dr.GetString("shortname");
                            PSInfo.CustomerCode = dr.GetString("CUSTCODE");
                            PSInfo.IndexNo = dr.GetInt32("INDEXNO").ToString();
                            PSInfo.SortingDate = "(" + dr.GetString("ORDERDATE") + ")";
                            PSInfo.BoxNo = dr.GetInt32("BOXSEQ") + "/";
                            PSInfo.BoxCount = dr.GetInt32("BOXCOUNT").ToString();
                            PSInfo.CurrentNum = dr.GetInt32("BOXQTY") + "/" +
                                                dr.GetInt32("TOTQTY");
                            //PSInfo.TaskNumber = sortingLineTask.SortingLineTaskDetails.GetTotQty().ToString();
                            PSInfo.DelivyLine = dr.GetString("LINENAME");
                            PSInfo.CustomerSqe = "(" + PSInfo.IndexNo + "/" + dr.GetInt32("cucount") + ")户";
                            //PSInfo.CustomerTotSeq = outPort["MAXCOUNTLINE"];
                            PSInfo.AbnoBoxCount = "异" + dr.GetInt32("abnboxqty");
                            PSInfo.Address = dr.GetString("address");
                            PSInfo.BoxIndex = dr.GetInt32("BOXINDEX");
                            PSInfos.Add(PSInfo);
                        }
                    }
                }
            }
            
        }
    }
}

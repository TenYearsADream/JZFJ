using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AppUtility;
using BusinessLogic.SortingTask;
using Csla.Data;

namespace BusinessLogic.PrintBarcode
{
    public class PrintBarCodes
    {
        static public int GetPrintIndex()
        {
            int index=1;
            using (var cn = new SqlConnection(AppUtil._PrintBarCode))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    //cm.CommandText = "SELECT Max(OI_SEQUENCE) FROM bp_order_info WHERE oi_b_code = " + SortingLineTask.GetSortingLineTaskNo() + " AND oi_state = 1";
                    cm.CommandText = "SELECT Max(OI_SEQUENCE) FROM bp_order_info WHERE  oi_state = 1";
                    index =  Convert.ToInt32(cm.ExecuteScalar());
                }

            }
            return index;
        }

        static public List<PrintInfo> GetAVGPrintEffice()
        {
            List<PrintInfo> printinfos = new List<PrintInfo>();
            using (var cn = new SqlConnection(AppUtil._PrintBarCode))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    //cm.CommandText = "SELECT oi_retailer_name,oi_all_num,oi_start_time FROM bp_order_info WHERE oi_b_code = " + SortingLineTask.GetSortingLineTaskNo() + " AND oi_state = 2 and oi_start_time is not null order by oi_sequence ";
                    cm.CommandText = "SELECT oi_retailer_name,oi_all_num,oi_start_time FROM bp_order_info WHERE oi_state = 2 and oi_start_time is not null order by oi_sequence ";
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            PrintInfo printinfo = new PrintInfo();
                            printinfo.CustName = dr.GetString("oi_retailer_name");
                            printinfo.allnum = dr.GetInt32("oi_all_num");
                            printinfo.starttime = dr.GetDateTime("oi_start_time");
                            printinfos.Add(printinfo);
                        }
                    }
                }

            }
            return printinfos;
        }


        static public List<PrintInfo> GetCUTPrintEffice()
        {
            List<PrintInfo> printinfos = new List<PrintInfo>();
            using (var cn = new SqlConnection(AppUtil._PrintBarCode))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    //cm.CommandText = "SELECT * from (SELECT top 5 oi_sequence,oi_retailer_name,oi_all_num,oi_start_time FROM bp_order_info WHERE oi_b_code =" + SortingLineTask.GetSortingLineTaskNo() + " AND oi_state = 2 and oi_start_time is not null order by oi_sequence desc) t order by t.oi_sequence";
                    cm.CommandText = "SELECT * from (SELECT top 5 oi_sequence,oi_retailer_name,oi_all_num,oi_start_time FROM bp_order_info WHERE oi_state = 2 and oi_start_time is not null order by oi_sequence desc) t order by t.oi_sequence";
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            PrintInfo printinfo = new PrintInfo();
                            printinfo.CustName = dr.GetString("oi_retailer_name");
                            printinfo.allnum = dr.GetInt32("oi_all_num");
                            printinfo.starttime = dr.GetDateTime("oi_start_time");
                            printinfos.Add(printinfo);
                        }
                    }
                }

            }
            return printinfos;
        }
    }

    public class PrintInfo
    {
        public string CustName { get; set; }
        public int allnum { get; set; }
        public DateTime starttime { get; set; }
    }

}

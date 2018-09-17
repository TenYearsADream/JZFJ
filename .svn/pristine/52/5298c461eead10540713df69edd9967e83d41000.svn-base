using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BusinessLogic.Download;
using MySql.Data.MySqlClient;
using BusinessLogic.PrintBarcode;
using BusinessLogic.SortingTask;
using Csla.Data;

namespace BusinessLogic.SortingProcess
{
    public class SortingProcessList : List<SortingProcessInfo>
    {
        public static void GetSortingProcessList(object o)
        {
            SortingProcessList sortingProcessList = new SortingProcessList();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                MySqlTransaction tran = cn.BeginTransaction();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "P_SORTLINE_Efficiency";

                    using (var dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            SortingProcessInfo sortingProcess = new SortingProcessInfo();
                            sortingProcess.SORTINGTASKNO = dr.GetString("SORTINGTASKNO");
                            sortingProcess.ORDERDATE = dr.GetString("ORDERDATE");
                            sortingProcess.PICKLINECODE = dr.GetString("PICKLINECODE");
                            sortingProcess.PICKLINENAME = dr.GetString("PICKLINENAME");
                            sortingProcess.QTY_PRODCUT_TOT = dr.GetInt32("QTY_PRODCUT_TOT");
                            sortingProcess.QTY_ROUTE_TOT = dr.GetInt32("QTY_ROUTE_TOT");
                            sortingProcess.QTY_CUSTOMER_TOT = dr.GetInt32("QTY_CUSTOMER_TOT");
                            sortingProcess.QTY_PRODUCT = dr.GetInt32("QTY_PRODUCT");
                            sortingProcess.QTY_ROUTE = dr.GetInt32("QTY_ROUTE");
                            sortingProcess.QTY_CUSTOMER = dr.GetInt32("QTY_CUSTOMER");
                            sortingProcess.CUSTOMER_CODE = dr.GetString("CUSTOMER_CODE");
                            sortingProcess.CUSTOMER_DESC = dr.GetString("CUSTOMER_DESC");
                            sortingProcess.ROUTE_CODE = dr.GetString("ROUTE_CODE");
                            sortingProcess.ROUTE_NAME = dr.GetString("ROUTE_NAME");
                            sortingProcess.RECEIVE_TIME = DateTime.Now;
                            sortingProcess.EFFICIENCY = dr.GetDouble("EFFICIENCY");
                            sortingProcess.Progress = dr.GetDouble("Progress");
                            sortingProcessList.Add(sortingProcess);
                        }
                    }
                }

                try
                {
                    foreach (SortingProcessInfo sortingProcessInfo in sortingProcessList)
                    {
                        if (!sortingProcessInfo.IsExist())
                        {
                            using (var cm = cn.CreateCommand())
                            {
                                cm.Transaction = tran;
                                cm.CommandType = CommandType.Text;
                                StringBuilder SQL = new StringBuilder();
                                SQL.Append("INSERT ");
                                SQL.Append("   INTO t_sortline_process ");
                                SQL.Append("        ( ");
                                SQL.Append(
                                    "            ID,SORTINGTASKNO,ORDERDATE,PICKLINECODE,PICKLINENAME,QTY_PRODCUT_TOT,QTY_ROUTE_TOT,QTY_CUSTOMER_TOT,QTY_PRODUCT,QTY_ROUTE,QTY_CUSTOMER,CUSTOMER_CODE,CUSTOMER_DESC,ROUTE_CODE,ROUTE_NAME,EFFICIENCY,RECEIVE_TIME,Progress ");
                                SQL.Append("        ) ");
                                SQL.Append("        VALUES ");
                                SQL.Append("        ( ");
                                SQL.Append(
                                    "            @ID,@SORTINGTASKNO,@SORT_DATE,@SORTLINE_CODE,@SORTLINE_DESC,@QTY_PRODCUT_TOT,@QTY_ROUTE_TOT,@QTY_CUSTOMER_TOT,@QTY_PRODUCT,@QTY_ROUTE,@QTY_CUSTOMER,@CUSTOMER_CODE,@CUSTOMER_DESC,@ROUTE_CODE,@ROUTE_NAME,@EFFICIENCY,@RECEIVE_TIME,@Progress ");
                                SQL.Append("        )");
                                cm.CommandText = SQL.ToString();
                                cm.Parameters.AddWithValue("@ID", Guid.NewGuid().ToString());
                                cm.Parameters.AddWithValue("@SORTINGTASKNO", sortingProcessInfo.SORTINGTASKNO);
                                cm.Parameters.AddWithValue("@SORT_DATE", sortingProcessInfo.ORDERDATE);
                                cm.Parameters.AddWithValue("@SORTLINE_CODE", sortingProcessInfo.PICKLINECODE);
                                cm.Parameters.AddWithValue("@SORTLINE_DESC", sortingProcessInfo.PICKLINENAME);
                                cm.Parameters.AddWithValue("@QTY_PRODCUT_TOT", sortingProcessInfo.QTY_PRODCUT_TOT);
                                cm.Parameters.AddWithValue("@QTY_ROUTE_TOT", sortingProcessInfo.QTY_ROUTE_TOT);
                                cm.Parameters.AddWithValue("@QTY_CUSTOMER_TOT", sortingProcessInfo.QTY_CUSTOMER_TOT);
                                cm.Parameters.AddWithValue("@QTY_PRODUCT", sortingProcessInfo.QTY_PRODUCT);
                                cm.Parameters.AddWithValue("@QTY_ROUTE", sortingProcessInfo.QTY_ROUTE);
                                cm.Parameters.AddWithValue("@QTY_CUSTOMER", sortingProcessInfo.QTY_CUSTOMER);
                                cm.Parameters.AddWithValue("@CUSTOMER_CODE", sortingProcessInfo.CUSTOMER_CODE);
                                cm.Parameters.AddWithValue("@CUSTOMER_DESC", sortingProcessInfo.CUSTOMER_DESC);
                                cm.Parameters.AddWithValue("@ROUTE_CODE", sortingProcessInfo.ROUTE_CODE);
                                cm.Parameters.AddWithValue("@ROUTE_NAME", sortingProcessInfo.ROUTE_NAME);
                                cm.Parameters.AddWithValue("@EFFICIENCY", sortingProcessInfo.EFFICIENCY);
                                cm.Parameters.AddWithValue("@RECEIVE_TIME", sortingProcessInfo.RECEIVE_TIME);
                                cm.Parameters.AddWithValue("@Progress", sortingProcessInfo.Progress);
                                cm.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (var cm = cn.CreateCommand())
                            {
                                cm.Transaction = tran;
                                cm.CommandType = CommandType.Text;
                                StringBuilder SQL = new StringBuilder();

                                if (sortingProcessInfo.PICKLINECODE == o.ToString())
                                {
                                    SQL.Append("UPDATE t_sortline_process ");
                                    SQL.Append(
                                        "    SET PICKLINENAME = @SORTLINE_DESC,QTY_PRODCUT_TOT = @QTY_PRODCUT_TOT,QTY_ROUTE_TOT = @QTY_ROUTE_TOT,QTY_CUSTOMER_TOT = @QTY_CUSTOMER_TOT,QTY_PRODUCT = @QTY_PRODUCT,QTY_ROUTE = @QTY_ROUTE,QTY_CUSTOMER = @QTY_CUSTOMER,CUSTOMER_CODE = @CUSTOMER_CODE,CUSTOMER_DESC = @CUSTOMER_DESC,ROUTE_CODE = @ROUTE_CODE, ");
                                    SQL.Append(
                                        "        ROUTE_NAME = @ROUTE_NAME,RECEIVE_TIME = @RECEIVE_TIME,Progress=@Progress");
                                    SQL.Append(
                                        "  WHERE SORTINGTASKNO         = @SORTINGTASKNO and ORDERDATE = @SORT_DATE and PICKLINECODE = @SORTLINE_CODE");
                                }
                                else
                                {
                                    SQL.Append("UPDATE t_sortline_process ");
                                    SQL.Append(
                                        "    SET PICKLINENAME = @SORTLINE_DESC,QTY_PRODCUT_TOT = @QTY_PRODCUT_TOT,QTY_ROUTE_TOT = @QTY_ROUTE_TOT,QTY_CUSTOMER_TOT = @QTY_CUSTOMER_TOT,QTY_PRODUCT = @QTY_PRODUCT,QTY_ROUTE = @QTY_ROUTE,QTY_CUSTOMER = @QTY_CUSTOMER,CUSTOMER_CODE = @CUSTOMER_CODE,CUSTOMER_DESC = @CUSTOMER_DESC,ROUTE_CODE = @ROUTE_CODE, ");
                                    SQL.Append(
                                        "        ROUTE_NAME = @ROUTE_NAME,Progress=@Progress ");
                                    SQL.Append("  WHERE SORTINGTASKNO         = @SORTINGTASKNO and ORDERDATE = @SORT_DATE and PICKLINECODE = @SORTLINE_CODE");    
                                }

                                


                                cm.CommandText = SQL.ToString();
                                cm.Parameters.AddWithValue("@SORTINGTASKNO", sortingProcessInfo.SORTINGTASKNO);
                                cm.Parameters.AddWithValue("@SORT_DATE", sortingProcessInfo.ORDERDATE);
                                cm.Parameters.AddWithValue("@SORTLINE_CODE", sortingProcessInfo.PICKLINECODE);
                                cm.Parameters.AddWithValue("@SORTLINE_DESC", sortingProcessInfo.PICKLINENAME);
                                cm.Parameters.AddWithValue("@QTY_PRODCUT_TOT", sortingProcessInfo.QTY_PRODCUT_TOT);
                                cm.Parameters.AddWithValue("@QTY_ROUTE_TOT", sortingProcessInfo.QTY_ROUTE_TOT);
                                cm.Parameters.AddWithValue("@QTY_CUSTOMER_TOT", sortingProcessInfo.QTY_CUSTOMER_TOT);
                                cm.Parameters.AddWithValue("@QTY_PRODUCT", sortingProcessInfo.QTY_PRODUCT);
                                cm.Parameters.AddWithValue("@QTY_ROUTE", sortingProcessInfo.QTY_ROUTE);
                                cm.Parameters.AddWithValue("@QTY_CUSTOMER", sortingProcessInfo.QTY_CUSTOMER);
                                cm.Parameters.AddWithValue("@CUSTOMER_CODE", sortingProcessInfo.CUSTOMER_CODE);
                                cm.Parameters.AddWithValue("@CUSTOMER_DESC", sortingProcessInfo.CUSTOMER_DESC);
                                cm.Parameters.AddWithValue("@ROUTE_CODE", sortingProcessInfo.ROUTE_CODE);
                                cm.Parameters.AddWithValue("@ROUTE_NAME", sortingProcessInfo.ROUTE_NAME);                                
                                cm.Parameters.AddWithValue("@Progress", sortingProcessInfo.Progress);
                                if (sortingProcessInfo.PICKLINECODE == o.ToString())
                                {
                                    cm.Parameters.AddWithValue("@RECEIVE_TIME", sortingProcessInfo.RECEIVE_TIME);
                                }
                                cm.ExecuteNonQuery();
                            }
                        }
                    }
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
               

                
            }



            //return sortingProcessList;
        }

        public static SortingProcessList GetSortingProcessList(string sortingdate, string taskno, string picklinecode)
        {
            SortingProcessList sortingProcessList = new SortingProcessList();
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
                        while (dr.Read())
                        {
                            SortingProcessInfo sortingProcess = new SortingProcessInfo();
                            sortingProcess.SORTINGTASKNO = dr.GetString("SORTINGTASKNO");
                            sortingProcess.ORDERDATE = dr.GetString("ORDERDATE");
                            sortingProcess.PICKLINECODE = dr.GetString("PICKLINECODE");
                            sortingProcess.PICKLINENAME = dr.GetString("PICKLINENAME");
                            sortingProcess.QTY_PRODCUT_TOT = dr.GetInt32("QTY_PRODCUT_TOT");
                            sortingProcess.QTY_ROUTE_TOT = dr.GetInt32("QTY_ROUTE_TOT");
                            sortingProcess.QTY_CUSTOMER_TOT = dr.GetInt32("QTY_CUSTOMER_TOT");
                            sortingProcess.QTY_PRODUCT = dr.GetInt32("QTY_PRODUCT");
                            sortingProcess.QTY_ROUTE = dr.GetInt32("QTY_ROUTE");
                            sortingProcess.QTY_CUSTOMER = dr.GetInt32("QTY_CUSTOMER");
                            sortingProcess.CUSTOMER_CODE = dr.GetString("CUSTOMER_CODE");
                            sortingProcess.CUSTOMER_DESC = dr.GetString("CUSTOMER_DESC");
                            sortingProcess.ROUTE_CODE = dr.GetString("ROUTE_CODE");
                            sortingProcess.ROUTE_NAME = dr.GetString("ROUTE_NAME");
                            sortingProcess.RECEIVE_TIME = dr.GetDateTime("RECEIVE_TIME");
                            sortingProcess.EFFICIENCY = dr.GetDouble("EFFICIENCY");
                            sortingProcessList.Add(sortingProcess);
                        }
                    }
                }
            }
            return sortingProcessList;
        }

        public static void UpdateEfficincy()
        {
            DateTime? starttime = null;
            double second = 0;
            double passt = 0;

            double pnum = 0;
            double totolnum = 0;
            int ordernum = 0;
            try
            {
                List<PrintInfo> printinfos = PrintBarCodes.GetAVGPrintEffice();
                List<PrintInfo> cutprintinfos = PrintBarCodes.GetCUTPrintEffice();

                //Dictionary<string, double> effice = new Dictionary<string, double>();
                foreach (PrintInfo printinfo in printinfos)
                {


                    if (starttime == null)
                    {
                        pnum = printinfo.allnum;
                        starttime = printinfo.starttime;
                    }
                    else
                    {
                        second = Convert.ToDouble(ExecDateDiff(Convert.ToDateTime(starttime), printinfo.starttime));
                        if (second < AppUtility.AppUtil._IgnoreSecond)
                        {
                            totolnum += pnum;
                            passt += second;
                            ordernum++;
                        }
                        pnum = printinfo.allnum;
                        starttime = printinfo.starttime;

                    }
                }

                double efficincy = Math.Round((Math.Round((totolnum / passt), 9) * 3600), 0);

                using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText = "UPDATE t_sortline_process set EFFICIENCY = " + efficincy + " WHERE ORDERDATE = '" + SortingLineTask.GetSortingLineTaskDate() + "' AND PICKLINECODE = '" + SortingLine.GetSortingLineCode() + "' AND SORTINGTASKNO = '" + SortingLineTask.GetMinSortingLineTask().SORTINGTASKNO + "'";
                        cm.ExecuteNonQuery();
                    }
                }




                double maxavgeffic = 0;
                double maxcuteffic = 0;
                using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText = "select MaxavgEFFICIENCY from t_sortline_process WHERE ORDERDATE = '" + SortingLineTask.GetSortingLineTaskDate() + "' AND PICKLINECODE = '" + SortingLine.GetSortingLineCode() + "' AND SORTINGTASKNO = '" + SortingLineTask.GetMinSortingLineTask().SORTINGTASKNO + "'";
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                maxavgeffic = dr.GetDouble("MaxavgEFFICIENCY");
                            }
                        }
                    }
                }

                if (efficincy > maxavgeffic)
                {
                    using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                    {
                        cn.Open();
                        using (var cm = cn.CreateCommand())
                        {
                            cm.CommandText = "UPDATE t_sortline_process set MaxavgEFFICIENCY = " + efficincy + ",MaxavgEFFICIENCYTime = '" + DateTime.Now +"'  WHERE ORDERDATE = '" + SortingLineTask.GetSortingLineTaskDate() + "' AND PICKLINECODE = '" + SortingLine.GetSortingLineCode() + "' AND SORTINGTASKNO = '" + SortingLineTask.GetMinSortingLineTask().SORTINGTASKNO + "'";
                            cm.ExecuteNonQuery();
                        }
                    }
                }






                starttime = null;
                second = 0;
                passt = 0;

                pnum = 0;
                totolnum = 0;
                ordernum = 0;
                foreach (PrintInfo printinfo in cutprintinfos)
                {


                    if (starttime == null)
                    {
                        pnum = printinfo.allnum;
                        starttime = printinfo.starttime;
                    }
                    else
                    {
                        second = Convert.ToDouble(ExecDateDiff(Convert.ToDateTime(starttime), printinfo.starttime));
                        if (second < AppUtility.AppUtil._IgnoreSecond)
                        {
                            totolnum += pnum;
                            passt += second;
                            ordernum++;
                        }
                        pnum = printinfo.allnum;
                        starttime = printinfo.starttime;

                    }
                }

                efficincy = Math.Round((Math.Round((totolnum / passt), 9) * 3600), 0);


                using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText = "select MaxcutEFFICIENCY from t_sortline_process WHERE ORDERDATE = '" + SortingLineTask.GetSortingLineTaskDate() + "' AND PICKLINECODE = '" + SortingLine.GetSortingLineCode() + "' AND SORTINGTASKNO = '" + SortingLineTask.GetMinSortingLineTask().SORTINGTASKNO + "'";
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                maxcuteffic = dr.GetDouble("MaxcutEFFICIENCY");
                            }
                        }
                    }
                }

                if (efficincy > maxcuteffic)
                {
                    using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                    {
                        cn.Open();
                        using (var cm = cn.CreateCommand())
                        {
                            cm.CommandText = "UPDATE t_sortline_process set MaxcutEFFICIENCY = " + efficincy + ",MaxcutEFFICIENCYTime = '" + DateTime.Now + "'  WHERE ORDERDATE = '" + SortingLineTask.GetSortingLineTaskDate() + "' AND PICKLINECODE = '" + SortingLine.GetSortingLineCode() + "' AND SORTINGTASKNO = '" + SortingLineTask.GetMinSortingLineTask().SORTINGTASKNO + "'";
                            cm.ExecuteNonQuery();
                        }
                    }
                }


                
            }
            catch
            { }
        }


        /// <summary>
        /// 程序执行时间测试
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>返回(秒)单位，比如: 0.00239秒</returns>
        public static string ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //你想转的格式
            return ts3.TotalSeconds.ToString();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtility;
using BusinessLogic.SortingTask;
using Csla.Data;
using IBM.Data.DB2;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Common
{
    public class OutPortTransfer : List<SortingLineTask>
    {
        /// <summary>
        /// 获取某一出口的任务列表
        /// </summary>
        public static OutPortTransfer GetOutPortTaskList(string outportcode)
        {
            OutPortTransfer outPortTransfer = new OutPortTransfer();
            using (var cn = new MySqlConnection((AppUtil._LocalConnectionString)))
            {
                cn.Open();
                using (MySqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT * FROM T_SORTING_LINE_TASK t WHERE t.OUTPORT = @outportcode order by t.indexno";
                    cm.Parameters.AddWithValue("@outportcode", outportcode);


                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {

                            SortingLineTask sortingLineTask;
                            sortingLineTask = SortingLineTask.GetSortingLineTask(dr);
                            outPortTransfer.Add(sortingLineTask);

                        }
                    }
                }
            }
            return outPortTransfer;
        }

        /// <summary>
        /// 将任务转移到新出口
        /// </summary>
        public static void SetDisOutPort(string oldoutportcode,string newoutportcode)
        {
            string orderdate = "";
            string sortinglinecode = "";
            string batch = "";


            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        using (var cm = cn.CreateCommand())
                        {
                            cm.Transaction = tran;
                            StringBuilder SQL = new StringBuilder();
                            SQL.Append("UPDATE t_sorting_line_task    SET OUTPORT = '" + newoutportcode + "'  WHERE OUTPORT = '" + oldoutportcode +"'");
                            cm.CommandText = SQL.ToString();
                            cm.ExecuteNonQuery();
                            tran.Commit();

                            Download.DownloadData.SetOutPort();                            
                        }
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        }

        public static void SetDisOutPort()
        {
            string orderdate = "";
            string sortinglinecode = "";
            string batch = "";

            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        using (var cm = cn.CreateCommand())
                        {
                            cm.Transaction = tran;
                            StringBuilder SQL = new StringBuilder();
                            SQL.Append("UPDATE t_sorting_line_task s SET s.OUTPORT = 1 WHERE  MOD(s.INDEXNO,2) = 1 ORDER BY s.INDEXNO");
                            cm.CommandText = SQL.ToString();
                            cm.ExecuteNonQuery();

                            cm.Transaction = tran;
                            SQL = new StringBuilder();
                            SQL.Append("UPDATE t_sorting_line_task s SET s.OUTPORT = 2 WHERE  MOD(s.INDEXNO,2) = 0 ORDER BY s.INDEXNO");
                            cm.CommandText = SQL.ToString();
                            cm.ExecuteNonQuery();


                            int Aplcaddress = 1;
                            int Bplcaddress = 11;


                            SQL = new StringBuilder();
                            SQL.Append("SELECT * FROM t_sorting_line_task ORDER BY INDEXNO");

                            cm.CommandText = SQL.ToString();

                            StringBuilder updatesql = new StringBuilder();

                            using (var dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    orderdate = dr.GetString("orderdate");
                                    sortinglinecode = dr.GetString("PICKLINECODE");
                                    batch = dr.GetString("SORTINGTASKNO");


                                    //if (dr["OUTPORT"].ToString() == "1")
                                    //{
                                    //    updatesql.Append("update t_sorting_line_task set PLCADDRESS = '" +
                                    //                     Aplcaddress +
                                    //                     "' where id = '" + dr.GetString("id") + "';");

                                    //    Aplcaddress += 1;
                                    //    if (Aplcaddress > 10)
                                    //    {
                                    //        Aplcaddress = 1;
                                    //    }
                                    //}

                                    //if (dr["OUTPORT"].ToString() == "2")
                                    //{
                                    //    updatesql.Append("update t_sorting_line_task set PLCADDRESS = '" +
                                    //                     Bplcaddress +
                                    //                     "' where id = '" + dr.GetString("id") + "';");

                                    //    Bplcaddress += 1;
                                    //    if (Bplcaddress > 20)
                                    //    {
                                    //        Bplcaddress = 11;
                                    //    }
                                    //}

                                }
                            }


                            cm.CommandText = updatesql.ToString();
                            cm.ExecuteNonQuery();



                            tran.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        }



        public static void SetServerDisOutPort(string newoutportcode)
        {
            string orderdate = SortingLineTask.GetSortingLineTaskDate();
            
            string taskno = SortingLineTask.GetSortingLineTaskNo();


            using (var cn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        using (var cm = cn.CreateCommand())
                        {
                            cm.Transaction = tran;
                            StringBuilder SQL = new StringBuilder();
                            SQL.Append("UPDATE t_sorting_line_task    SET OUTPORT = '" + newoutportcode + "'  where orderdate = '" + orderdate + "' and taskno= '" + taskno + "' ");
                            cm.CommandText = SQL.ToString();
                            cm.ExecuteNonQuery();


                            tran.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        }



        public static void SetServerDisOutPort()
        {
            string orderdate = SortingLineTask.GetSortingLineTaskDate();

            string taskno = SortingLineTask.GetSortingLineTaskNo();


            using (var cn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        using (var cm = cn.CreateCommand())
                        {
                            cm.Transaction = tran;
                            StringBuilder SQL = new StringBuilder();
                            SQL.Append("UPDATE t_sorting_line_task s SET s.OUTPORT = '1' where MOD(s.INDEXNO,2) = 1 and orderdate = '"+ orderdate + "' and taskno= '"+ taskno+ "'");
                            cm.CommandText = SQL.ToString();
                            cm.ExecuteNonQuery();

                            cm.Transaction = tran;
                            SQL = new StringBuilder();
                            SQL.Append("UPDATE t_sorting_line_task s SET s.OUTPORT = '2' where MOD(s.INDEXNO,2) = 0 and orderdate = '" + orderdate + "' and taskno= '" + taskno + "'");
                            cm.CommandText = SQL.ToString();
                            cm.ExecuteNonQuery();


                            tran.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        }


        

    }
}

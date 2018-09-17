﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BusinessLogic.Configuration;
using BusinessLogic.SortingProcess;
using BusinessLogic.SortingTask;
using Csla.Data;

using MySql.Data.MySqlClient;
using System.Threading;
using AppUtility;
using IBM.Data.DB2;
using BusinessLogic.Common;

namespace BusinessLogic.Download
{
    public class DownloadData
    {

        /// <summary>
        /// 更新下载进度
        /// </summary>
        public static event EventHandler<DownloadPrecess> OnPrecessUpdate;
        /// <summary>
        /// 步骤开始
        /// </summary>
        public static event EventHandler<StepNameEvenArgs> OnProcessStart;
        /// <summary>
        /// 步骤完成
        /// </summary>
        public static event EventHandler<DownloadArgs> OnProcessFinish;
        /// <summary>
        /// 下载完成事件
        /// </summary>
        public static event EventHandler<EventArgs> OnDownLoadFinish;
        /// <summary>
        /// 下载进度出错
        /// </summary>
        public static event EventHandler<DownloadErrorArgs> OnProcessError;

        /// <summary>
        /// 烟包信息传输完成
        /// </summary>
        public static event EventHandler<DownloadArgs> OnTransferFinish;


        /// <summary>
        /// 总步骤总计
        /// </summary>
        private static int MainCount { get; set; }
        /// <summary>
        /// 当前总步骤
        /// </summary>
        private static int MainIndex { get; set; }
        /// <summary>
        /// 明细步骤总计
        /// </summary>
        private static int DetailCount { get; set; }
        /// <summary>
        /// 当前明细步骤
        /// </summary>
        private static int DetailIndex { get; set; }


        /// <summary>
        /// 开始下载
        /// </summary>
        public static void Start(object downloadargs)
        {
            
            int ordercount;
            int orderdetailcount;
            int incount;
            List<DownloadArgs> downloadArgslist = (List<DownloadArgs>)downloadargs;

            foreach (var downloadArgs in downloadArgslist)
            {
                MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "线程启动";
                monitorLog.LOGINFO = "分拣任务下载线程启动";
                monitorLog.LOGLOCATION = "线程操作";
                monitorLog.LOGTYPE = 1;
                monitorLog.Save();


                #region 卷烟分拣任务下载

                using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var tran = cn.BeginTransaction())
                    {
                        try
                        {
                            if (downloadArgs.OrderType == 1)
                            {
                                MainCount = 6;
                                MainIndex = 0;
                            }
                            else
                            {
                                MainCount = 5;
                                MainIndex = 0;
                            }

                            #region 基础数据下载
                            if (OnProcessStart != null)
                            {
                                OnProcessStart.Invoke(null,
                                                      new StepNameEvenArgs("", "同步基础数据"));
                            }
                            MainIndex++;
                            DetailCount = 4;
                            DetailIndex = 0;
                            //配送区域表
                            using (var cm = cn.CreateCommand())
                            {
                                
                                cm.Transaction = tran;
                                cm.CommandText = "delete from t_corp";
                                cm.ExecuteNonQuery();
                            }

                            using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                            {
                                remotecn.Open();

                                using (var remotecm = remotecn.CreateCommand())
                                {
                                    remotecm.CommandText = "SELECT * FROM t_corp";
                                    using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                    {
                                        while (dr.Read())
                                        {
                                            using (var cm = cn.CreateCommand())
                                            {
                                                cm.Transaction = tran;
                                                StringBuilder SQL = new StringBuilder();
                                                SQL.Append("INSERT ");
                                                SQL.Append("   INTO t_corp ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            REGIONNO,REGIONNAME,REGIONSEQUENCE,DIRECTCHANGE,type,shortName");
                                                SQL.Append("        ) ");
                                                SQL.Append("        VALUES ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            @REGIONNO,@REGIONNAME,@REGIONSEQUENCE,@DIRECTCHANGE,@type,@shortName");
                                                SQL.Append("        )");
                                                cm.CommandText = SQL.ToString();
                                                
                                                cm.Parameters.AddWithValue("@REGIONNO", dr.GetString("REGIONNO"));
                                                cm.Parameters.AddWithValue("@REGIONNAME", dr.GetString("REGIONNAME"));
                                                cm.Parameters.AddWithValue("@REGIONSEQUENCE", dr.GetInt32("REGIONSEQUENCE"));
                                                cm.Parameters.AddWithValue("@DIRECTCHANGE", dr.GetInt32("DIRECTCHANGE"));
                                                cm.Parameters.AddWithValue("@type", dr.GetInt32("type"));
                                                cm.Parameters.AddWithValue("@shortName", dr.GetString("shortName"));
                                                cm.ExecuteNonQuery();

                                            }

                                        }
                                    }
                                }
                            }

                            DetailIndex++;
                            if (OnPrecessUpdate != null)
                            {
                                OnPrecessUpdate.Invoke(null,
                                                       new DownloadPrecess(MainCount, MainIndex, DetailCount,
                                                                           DetailIndex));
                            }


                            //分拣线表
                            using (var cm = cn.CreateCommand())
                            {
                                cm.Transaction = tran;
                                cm.CommandText = "delete from T_SORTINGLINE";
                                cm.ExecuteNonQuery();
                            }

                            using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                            {
                                remotecn.Open();

                                using (var remotecm = remotecn.CreateCommand())
                                {
                                    remotecm.CommandText = "SELECT * FROM T_SORTINGLINE where linecode = '" + AppUtil._SortingLineId + "'" ;
                                    using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                    {
                                        while (dr.Read())
                                        {
                                            using (var cm = cn.CreateCommand())
                                            {
                                                cm.Transaction = tran;
                                                StringBuilder SQL = new StringBuilder();
                                                SQL.Append("INSERT ");
                                                SQL.Append("   INTO t_sortingline ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            ID,LINECODE,ROOMCODE,LINENAME,ISENABLED,EXITNUMBER,BALECAPACITY,CAGECAPACITY,ABNORCAPACITY,REMARK,TYPE ");
                                                SQL.Append("        ) ");
                                                SQL.Append("        VALUES ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            @ID,@LINECODE,@ROOMCODE,@LINENAME,@ISENABLED,@EXITNUMBER,@BALECAPACITY,@CAGECAPACITY,@ABNORCAPACITY,@REMARK,@TYPE");
                                                SQL.Append("        )");
                                                cm.CommandText = SQL.ToString();
                                                cm.Parameters.AddWithValue("@ID", dr.GetString("ID"));
                                                cm.Parameters.AddWithValue("@LINECODE", dr.GetString("LINECODE"));
                                                cm.Parameters.AddWithValue("@ROOMCODE", dr.GetString("ROOM_CODE"));
                                                cm.Parameters.AddWithValue("@LINENAME", dr.GetString("LINENAME"));
                                                cm.Parameters.AddWithValue("@ISENABLED", dr.GetInt32("ISENABLED"));
                                                cm.Parameters.AddWithValue("@EXITNUMBER", dr.GetInt32("EXITNUMBER"));
                                                cm.Parameters.AddWithValue("@BALECAPACITY", dr.GetInt32("BALECAPACITY"));
                                                cm.Parameters.AddWithValue("@CAGECAPACITY", dr.GetInt32("CAGECAPACITY"));
                                                cm.Parameters.AddWithValue("@ABNORCAPACITY", dr.GetInt32("ABNORCAPACITY"));
                                                cm.Parameters.AddWithValue("@REMARK", dr.GetString("REMARK"));
                                                cm.Parameters.AddWithValue("@TYPE", dr.GetString("LineTYPE"));


                                                cm.ExecuteNonQuery();

                                            }

                                        }
                                    }
                                }
                            }

                            DetailIndex++;
                            if (OnPrecessUpdate != null)
                            {
                                OnPrecessUpdate.Invoke(null,
                                                       new DownloadPrecess(MainCount, MainIndex, DetailCount,
                                                                           DetailIndex));
                            }

                            //分拣子线表
                            using (var cm = cn.CreateCommand())
                            {
                                cm.Transaction = tran;
                                cm.CommandText = "delete from t_sortingsubline";
                                cm.ExecuteNonQuery();
                            }

                            using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                            {
                                remotecn.Open();

                                using (var remotecm = remotecn.CreateCommand())
                                {
                                    remotecm.CommandText = "SELECT * FROM  t_sortingsubline ";
                                    using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                    {
                                        while (dr.Read())
                                        {
                                            using (var cm = cn.CreateCommand())
                                            {
                                                cm.Transaction = tran;
                                                StringBuilder SQL = new StringBuilder();
                                                SQL.Append("INSERT ");
                                                SQL.Append("   INTO t_sortingsubline ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            ID,sublineCode,sublineName,lineId,sequence ");
                                                SQL.Append("        ) ");
                                                SQL.Append("        VALUES ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            @ID,@sublineCode,@sublineName,@lineId,@sequence ");
                                                SQL.Append("        )");
                                                cm.CommandText = SQL.ToString();
                                                cm.Parameters.AddWithValue("@ID", dr.GetString("ID"));
                                                cm.Parameters.AddWithValue("@sublineCode", dr.GetString("sublineCode"));
                                                cm.Parameters.AddWithValue("@sublineName", dr.GetString("sublineName"));
                                                cm.Parameters.AddWithValue("@lineId", dr.GetString("lineId"));
                                                cm.Parameters.AddWithValue("@sequence", dr.GetInt32("sequence"));
                                                cm.ExecuteNonQuery();
                                            }

                                        }
                                    }
                                }
                            }

                            DetailIndex++;
                            if (OnPrecessUpdate != null)
                            {
                                OnPrecessUpdate.Invoke(null,
                                                       new DownloadPrecess(MainCount, MainIndex, DetailCount,
                                                                           DetailIndex));
                            }


                            //烟道表
                            using (var cm = cn.CreateCommand())
                            {
                                cm.Transaction = tran;
                                cm.CommandText = "delete from T_LINEBOX";
                                cm.ExecuteNonQuery();
                            }

                            using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                            {
                                remotecn.Open();

                                using (var remotecm = remotecn.CreateCommand())
                                {
                                    remotecm.CommandText = "SELECT s.LINECODE,l.* FROM t_sortingline s JOIN t_sortingsubline su ON s.ID = su.lineId JOIN t_linebox l ON l.sublineId = su.id where s.linecode = '" + AppUtil._SortingLineId + "'";
                                    using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                    {
                                        while (dr.Read())
                                        {
                                            using (var cm = cn.CreateCommand())
                                            {
                                                cm.Transaction = tran;
                                                StringBuilder SQL = new StringBuilder();
                                                SQL.Append("INSERT ");
                                                SQL.Append("   INTO T_LINEBOX ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            ID,BOXCODE,BOXNAME,BOXTYPE,ISENABLED,BINDCIG,ISDYNAMICBOX,SUBLINEID,ADDRESSCODE,PUTNUM,GROUPID,PARENTLINEBOX,ABANDONPARENT ");
                                                SQL.Append("        ) ");
                                                SQL.Append("        VALUES ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            @ID,@BOXCODE,@BOXNAME,@BOXTYPE,@ISENABLED,@BINDCIG,@ISDYNAMICBOX,@SUBLINEID,@ADDRESSCODE,@PUTNUM,@GROUPID,@PARENTLINEBOX,@ABANDONPARENT");
                                                SQL.Append("        )");
                                                cm.CommandText = SQL.ToString();
                                                cm.Parameters.AddWithValue("@ID", dr.GetString("ID"));
                                                cm.Parameters.AddWithValue("@BOXCODE", dr.GetString("BOXCODE"));
                                                cm.Parameters.AddWithValue("@BOXNAME", dr.GetString("BOXNAME"));
                                                cm.Parameters.AddWithValue("@BOXTYPE", dr.GetInt32("BOXTYPE"));
                                                cm.Parameters.AddWithValue("@ISENABLED", dr.GetString("ISENABLED"));
                                                cm.Parameters.AddWithValue("@BINDCIG", dr.GetString("BINDCIG"));
                                                cm.Parameters.AddWithValue("@ISDYNAMICBOX", dr.GetString("ISDYNAMICBOX"));
                                                cm.Parameters.AddWithValue("@SUBLINEID", dr.GetString("SUBLINEID"));
                                                cm.Parameters.AddWithValue("@ADDRESSCODE", dr.GetString("ADDRESSCODE"));
                                                cm.Parameters.AddWithValue("@PUTNUM", dr.GetInt32("PUTNUM"));
                                                cm.Parameters.AddWithValue("@GROUPID", dr.GetString("GROUPID"));
                                                cm.Parameters.AddWithValue("@PARENTLINEBOX",dr.GetString("PARENTLINEBOX"));
                                                cm.Parameters.AddWithValue("@ABANDONPARENT",
                                                    dr.GetString("ABANDONPARENT"));
                                                cm.ExecuteNonQuery();

                                            }

                                        }
                                    }
                                }
                            }


                            DetailIndex++;
                            if (OnPrecessUpdate != null)
                            {
                                OnPrecessUpdate.Invoke(null,
                                                       new DownloadPrecess(MainCount, MainIndex, DetailCount,
                                                                           DetailIndex));
                            }



                            //卷烟表
                            using (var cm = cn.CreateCommand())
                            {
                                cm.Transaction = tran;
                                cm.CommandText = "delete from t_ciginfo";
                                cm.ExecuteNonQuery();
                            }

                            using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                            {
                                remotecn.Open();

                                using (var remotecm = remotecn.CreateCommand())
                                {
                                    remotecm.CommandText = "SELECT * FROM t_ciginfo";
                                    using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                    {
                                        while (dr.Read())
                                        {
                                            using (var cm = cn.CreateCommand())
                                            {
                                                cm.Transaction = tran;
                                                StringBuilder SQL = new StringBuilder();
                                                SQL.Append("INSERT ");
                                                SQL.Append("   INTO t_ciginfo ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            CIGARETTENO,CIGARETTENAME,BARCODE,ISABNOR,ISSEIZURE,IBOXQUANTITY ");
                                                SQL.Append("        ) ");
                                                SQL.Append("        VALUES ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            @CIGARETTENO,@CIGARETTENAME,@BARCODE,@ISABNOR,@ISSEIZURE,@IBOXQUANTITY ");
                                                SQL.Append("        )");
                                                cm.CommandText = SQL.ToString();
                                                
                                                cm.Parameters.AddWithValue("@CIGARETTENO", dr.GetString("CIGARETTENO"));
                                                cm.Parameters.AddWithValue("@CIGARETTENAME", dr.GetString("CIGARETTENAME"));
                                                cm.Parameters.AddWithValue("@BARCODE", dr.GetString("BARCODE"));
                                                cm.Parameters.AddWithValue("@ISABNOR", dr.GetString("ISABNOR"));
                                                cm.Parameters.AddWithValue("@ISSEIZURE", dr.GetString("ISSEIZURE"));
                                                cm.Parameters.AddWithValue("@IBOXQUANTITY", dr.GetInt32("IBOXQUANTITY"));



                                                cm.ExecuteNonQuery();

                                            }

                                        }
                                    }
                                }
                            }


                            //客户表
                            using (var cm = cn.CreateCommand())
                            {
                                cm.Transaction = tran;
                                cm.CommandText = "delete from t_client";
                                cm.ExecuteNonQuery();
                            }

                            using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                            {
                                remotecn.Open();

                                using (var remotecm = remotecn.CreateCommand())
                                {
                                    remotecm.CommandText = "SELECT * FROM t_client";
                                    using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                    {
                                        while (dr.Read())
                                        {
                                            using (var cm = cn.CreateCommand())
                                            {
                                                cm.Transaction = tran;
                                                StringBuilder SQL = new StringBuilder();
                                                SQL.Append("INSERT ");
                                                SQL.Append("   INTO t_client ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            CUSTOMERNO,CUSTOMERNAME,DELIVERLINENO,TELEPHONE,SHORTNAME,ADDRESS ");
                                                SQL.Append("        ) ");
                                                SQL.Append("        VALUES ");
                                                SQL.Append("        ( ");
                                                SQL.Append("            @CUSTOMERNO,@CUSTOMERNAME,@DELIVERLINENO,@TELEPHONE,@SHORTNAME,@ADDRESS ");
                                                SQL.Append("        )");
                                                cm.CommandText = SQL.ToString();

                                                cm.Parameters.AddWithValue("@CUSTOMERNO", dr.GetString("CUSTOMERNO"));
                                                cm.Parameters.AddWithValue("@CUSTOMERNAME", dr.GetString("CUSTOMERNAME"));
                                                cm.Parameters.AddWithValue("@DELIVERLINENO", dr.GetString("DELIVERLINENO"));
                                                cm.Parameters.AddWithValue("@TELEPHONE", dr.GetString("TELEPHONE"));
                                                cm.Parameters.AddWithValue("@SHORTNAME", dr.GetString("SHORTNAME"));
                                                cm.Parameters.AddWithValue("@ADDRESS", dr.GetString("ADDRESS"));



                                                cm.ExecuteNonQuery();

                                            }

                                        }
                                    }
                                }
                            }

                            DetailIndex++;
                            if (OnPrecessUpdate != null)
                            {
                                OnPrecessUpdate.Invoke(null,
                                                       new DownloadPrecess(MainCount, MainIndex, DetailCount,
                                                                           DetailIndex));
                            }

                            #endregion

                            #region 常规烟下载
                            if (downloadArgs.OrderType == 1 || downloadArgs.OrderType == 2)
                            {
                                #region 订单主表下载

                                if (OnProcessStart != null)
                                {
                                    OnProcessStart.Invoke(null,
                                                          new StepNameEvenArgs(downloadArgs.LineName,"同步订单主表"));
                                }
                                MainIndex++;
                                using (var cm = cn.CreateCommand())
                                {
                                    cm.Transaction = tran;
                                    cm.CommandText = "delete from t_sorting_line_task";
                                    cm.ExecuteNonQuery();

                                    cm.CommandText = "delete from t_sorting_line_detail_task";
                                    cm.ExecuteNonQuery();

                                    cm.CommandText = "delete from T_INTASK ";
                                    cm.ExecuteNonQuery();

                                    cm.CommandText = "delete from t_box where linecode = '" + downloadArgs.LineCode +
                                                     "'";
                                    cm.ExecuteNonQuery();


                                    cm.CommandText = "delete from t_materialsdetail_detail";
                                    cm.ExecuteNonQuery();


	                                cm.CommandText = "delete from t_materialsdetail";
	                                cm.ExecuteNonQuery();

                                    
                                }

                                monitorLog = MonitorLog.NewMonitorLog();
                                monitorLog.LOGNAME = "数据库写入";
                                monitorLog.LOGINFO = "清除分拣订单成功!";
                                monitorLog.LOGLOCATION = "数据库";
                                monitorLog.LOGTYPE = 0;
                                monitorLog.Save();

                                monitorLog = MonitorLog.NewMonitorLog();
                                monitorLog.LOGNAME = "数据库写入";
                                monitorLog.LOGINFO = "开始插入分拣订单数据,订单日期:" + downloadArgs.OrderDate.ToString();
                                monitorLog.LOGLOCATION = "数据库";
                                monitorLog.LOGTYPE = 0;
                                monitorLog.Save();



                                using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                                {
                                    remotecn.Open();

                                    using (var remotecm = remotecn.CreateCommand())
                                    {
                                        StringBuilder SQL = new StringBuilder();
                                        SQL.Append("SELECT    count(1) ");
                                        SQL.Append("   FROM t_sorting_line_task where PICKLINECODE = '" +
                                                   downloadArgs.LineCode + "' and  orderdate  = '" +
                                                   downloadArgs.OrderDate +
                                                   "' and TASKNO = '" + downloadArgs.Batch + "'");
                                        remotecm.CommandText = SQL.ToString();
                                        ordercount = DetailCount = Convert.ToInt32(remotecm.ExecuteScalar());
                                        DetailIndex = 0;                                        
                                        
                                        SQL = new StringBuilder();
                                        SQL.Append("SELECT * ");
                                        SQL.Append("   FROM t_sorting_line_task where PICKLINECODE = '" +
                                                   downloadArgs.LineCode + "' and  orderdate  = '" +
                                                   downloadArgs.OrderDate +
                                                   "' and TASKNO = '" + downloadArgs.Batch + "' order by indexno");
                                        remotecm.CommandText = SQL.ToString();
                                        DB2DataAdapter db2DataAdapter = new DB2DataAdapter(remotecm.CommandText, remotecn);
                                        DataTable dt = new DataTable("sortinglinetask");
                                        db2DataAdapter.Fill(dt);



                                        //订单PLC地址
                                        //A通道为1-10的地址区
                                        //B通道为11-20的地址区
                                        int Aplcaddress = 1;
                                        int Bplcaddress = 11;

                                            foreach (DataRow dataRow in dt.Rows)
                                            {

                                            
                                                using (var cm = cn.CreateCommand())
                                                {
                                                    cm.Transaction = tran;

                                                    
                                                    SQL = new StringBuilder();
                                                    SQL.Append("INSERT ");
                                                    SQL.Append("   INTO t_sorting_line_task ");
                                                    SQL.Append("        ( ");
                                                    SQL.Append(
                                                        "            ID,SORTINGTASKNO,ORDERDATE,PICKLINECODE,PICKLINENAME,CUSTCODE,CUSTNAME,INDEXNO,OUTPORT,PLCADDRESS,LINECODE,LINENAME,CORPCODE,CORPNAME,shortname ");
                                                    SQL.Append("        ) ");
                                                    SQL.Append("        VALUES ");
                                                    SQL.Append("        ( ");
                                                    SQL.Append(
                                                        "            @ID,@SORTINGTASKNO,@ORDERDATE,@PICKLINECODE,@PICKLINENAME,@CUSTCODE,@CUSTNAME,@INDEXNO,@OUTPORT,@PLCADDRESS,@LINECODE,@LINENAME,@CORPCODE,@CORPNAME,@shortname ");
                                                    SQL.Append("        )");
                                                    cm.CommandText = SQL.ToString();
                                                    cm.Parameters.AddWithValue("@ID", dataRow["ID"]);
                                                    cm.Parameters.AddWithValue("@SORTINGTASKNO",
                                                                               dataRow["TASKNO"]);
                                                    cm.Parameters.AddWithValue("@PICKLINECODE",
                                                                               dataRow["PICKLINECODE"]);
                                                    cm.Parameters.AddWithValue("@ORDERDATE", dataRow["ORDERDATE"]);
                                                    cm.Parameters.AddWithValue("@PICKLINENAME",
                                                                               dataRow["PICKLINENAME"]);
                                                    cm.Parameters.AddWithValue("@CUSTCODE", dataRow["CUSTCODE"]);
                                                    cm.Parameters.AddWithValue("@CUSTNAME", dataRow["CUSTNAME"]);
                                                    cm.Parameters.AddWithValue("@INDEXNO", dataRow["INDEXNO"]);

                                                    if (downloadArgs.OutPut == "-1")
                                                    {
                                                        cm.Parameters.AddWithValue("@OUTPORT", dataRow["OUTPORT"]);
                                                    }
                                                    else if (downloadArgs.OutPut == "1")
                                                    {
                                                        cm.Parameters.AddWithValue("@OUTPORT", "1");
                                                    }
                                                    else if (downloadArgs.OutPut == "2")
                                                    {
                                                        cm.Parameters.AddWithValue("@OUTPORT", "2");
                                                    }
                                                    else if (downloadArgs.OutPut == "0")
                                                    {
                                                        if (Convert.ToInt32(dataRow["INDEXNO"]) % 2 == 0)
                                                        {
                                                            cm.Parameters.AddWithValue("@OUTPORT", "2");
                                                        }
                                                        else
                                                        {
                                                            cm.Parameters.AddWithValue("@OUTPORT", "1");
                                                        }
                                                    }
                                                    cm.Parameters.AddWithValue("@PLCADDRESS", 0);
                                                    //if (dataRow["OUTPORT"].ToString().Trim() == "1")
                                                    //{
                                                    //    cm.Parameters.AddWithValue("@PLCADDRESS", Aplcaddress);
                                                    //    Aplcaddress += 1;
                                                    //    if (Aplcaddress > 10)
                                                    //    {
                                                    //        Aplcaddress = 1;
                                                    //    }
                                                        
                                                    //}

                                                    //if (dataRow["OUTPORT"].ToString().Trim() == "2")
                                                    //{

                                                    //    cm.Parameters.AddWithValue("@PLCADDRESS", Bplcaddress);
                                                    //    Bplcaddress += 1;
                                                    //    if (Bplcaddress > 20)
                                                    //    {
                                                    //        Bplcaddress = 11;
                                                    //    }
                                                    //}
                                                    
                                                    ////出口1分配地址1-20号
                                                    //if (dataRow["OUTPORT"].ToString() == "1")
                                                    //{
                                                    //    cm.Parameters.AddWithValue("@PLCADDRESS", Aplcaddress);
                                                    //    Aplcaddress += 1;
                                                    //    if (Aplcaddress > 20)
                                                    //    {
                                                    //        Aplcaddress = 1;
                                                    //    }
                                                    //}

                                                    ////出口2分配地址1-20号（未使用将所有地址给1号使用）
                                                    //if (dataRow["OUTPORT"].ToString() == "2")
                                                    //{

                                                    //    cm.Parameters.AddWithValue("@PLCADDRESS", Bplcaddress);
                                                    //    Bplcaddress += 1;
                                                    //    if (Bplcaddress > 20)
                                                    //    {
                                                    //        Bplcaddress = 11;
                                                    //    }
                                                    //}

                                                    
                                                    cm.Parameters.AddWithValue("@LINECODE", dataRow["LINECODE"]);
                                                    cm.Parameters.AddWithValue("@LINENAME", dataRow["LINENAME"]);
                                                    cm.Parameters.AddWithValue("@CORPCODE", dataRow["CORPCODE"]);
                                                    cm.Parameters.AddWithValue("@CORPNAME", dataRow["CORPNAME"]);
                                                    cm.Parameters.AddWithValue("@shortname", dataRow["shortname"]);
                                                    cm.ExecuteNonQuery();






                                                    DetailIndex++;
                                                    
                                                    if (OnPrecessUpdate != null)
                                                    {
                                                        OnPrecessUpdate.Invoke(null,
                                                                               new DownloadPrecess(MainCount, MainIndex,
                                                                                                   DetailCount,
                                                                                                   DetailIndex));
                                                    }


                                                

                                            }
                                        }
                                    }
                                   
                                }


                                
                                if (OnPrecessUpdate != null)
                                {
                                    OnPrecessUpdate.Invoke(null,
                                                           new DownloadPrecess(MainCount, MainIndex, DetailCount,
                                                                               DetailIndex));
                                }                                
                                #endregion

                                #region 订单明细下载

                                if (OnProcessStart != null)
                                {
                                    OnProcessStart.Invoke(null,
                                                          new StepNameEvenArgs(downloadArgs.LineName, "同步订单明细表"));
                                }
                                MainIndex++;
                                using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                                {
                                    remotecn.Open();

                                    using (var remotecm = remotecn.CreateCommand())
                                    {
                                        StringBuilder SQL = new StringBuilder();
                                        SQL.Append("SELECT    count(1) ");
                                        SQL.Append(
                                            "   FROM t_sorting_line_task t join  t_sorting_line_detail_task dt on dt.taskid = t.id where t.PICKLINECODE = '" +
                                            downloadArgs.LineCode + "' and  t.orderdate  = '" + downloadArgs.OrderDate +
                                            "' and t.TASKNO = '" + downloadArgs.Batch + "'");
                                        remotecm.CommandText = SQL.ToString();
                                        orderdetailcount = DetailCount = Convert.ToInt32(remotecm.ExecuteScalar());
                                        DetailIndex = 0;

                                        SQL = new StringBuilder();
                                        SQL.Append("SELECT    dt.* ");
                                        SQL.Append(
                                            "   FROM t_sorting_line_task t join  t_sorting_line_detail_task dt on dt.taskid = t.id where t.PICKLINECODE = '" +
                                            downloadArgs.LineCode + "' and  t.orderdate  = '" + downloadArgs.OrderDate +
                                            "' and t.TASKNO = '" + downloadArgs.Batch + "'");
                                        remotecm.CommandText = SQL.ToString();
                                        using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                        {
                                            while (dr.Read())
                                            {
                                                using (var cm = cn.CreateCommand())
                                                {
                                                    cm.Transaction = tran;
                                                    SQL = new StringBuilder();
                                                    SQL.Append("INSERT ");
                                                    SQL.Append("   INTO t_sorting_line_detail_task ");
                                                    SQL.Append("        ( ");
                                                    SQL.Append(
                                                        "            ID,TASKID,SUBLINECODE,SUBLINENAME,LINEBOXCODE,LINEBOXNAME,ADDRESSCODE,CIGCODE,CIGNAME,QTY ");
                                                    SQL.Append("        ) ");
                                                    SQL.Append("        VALUES ");
                                                    SQL.Append("        ( ");
                                                    SQL.Append(
                                                        "            @ID,@TASKID,@SUBLINECODE,@SUBLINENAME,@LINEBOXCODE,@LINEBOXNAME,@ADDRESSCODE,@CIGCODE,@CIGNAME,@QTY ");
                                                    SQL.Append("        )");
                                                    cm.CommandText = SQL.ToString();
                                                    cm.Parameters.AddWithValue("@ID", dr.GetString("ID"));
                                                    cm.Parameters.AddWithValue("@TASKID",
                                                                               dr.GetString("TASKID"));
                                                    cm.Parameters.AddWithValue("@SUBLINECODE",
                                                                               dr.GetString("SUBLINECODE"));

                                                    cm.Parameters.AddWithValue("@SUBLINENAME",
                                                                               dr.GetString("SUBLINENAME"));
                                                    cm.Parameters.AddWithValue("@LINEBOXCODE",
                                                                               dr.GetString("LINEBOXCODE"));
                                                    cm.Parameters.AddWithValue("@LINEBOXNAME",
                                                                               dr.GetString("LINEBOXNAME"));
                                                    cm.Parameters.AddWithValue("@ADDRESSCODE",
                                                                               dr.GetString("ADDRESSCODE"));
                                                    cm.Parameters.AddWithValue("@CIGCODE", dr.GetString("CIGCODE"));
                                                    cm.Parameters.AddWithValue("@CIGNAME", dr.GetString("CIGNAME"));
                                                    cm.Parameters.AddWithValue("@QTY", dr.GetInt32("QTY"));
                                                    cm.ExecuteNonQuery();
                                                    DetailIndex++;

                                                    
                                                        if (OnPrecessUpdate != null)
                                                        {
                                                            OnPrecessUpdate.Invoke(null,
                                                                                   new DownloadPrecess(MainCount, MainIndex,
                                                                                                       DetailCount,
                                                                                                       DetailIndex));
                                                        }
                                                    
                                                }

                                            }
                                        }
                                    }
                                }                                

                                if (OnPrecessUpdate != null)
                                {
                                    OnPrecessUpdate.Invoke(null,
                                                           new DownloadPrecess(MainCount, MainIndex, DetailCount,
                                                                               DetailIndex));
                                }

                                

                                monitorLog = MonitorLog.NewMonitorLog();
                                monitorLog.LOGNAME = "数据库写入";
                                monitorLog.LOGINFO = "插入分拣订单数据成功,订单日期:" + downloadArgs.OrderDate.ToString() + " 主表:" +
                                                     ordercount + "明细:" + orderdetailcount;
                                monitorLog.LOGLOCATION = "数据库";
                                monitorLog.LOGTYPE = 0;
                                monitorLog.Save();

                                #endregion

                                #region 烟包数据


                                if (OnProcessStart != null)
                                {
                                    OnProcessStart.Invoke(null,
                                                          new StepNameEvenArgs(downloadArgs.LineName, "同步烟包表"));
                                }
                                MainIndex++;
                                using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                                {
                                    remotecn.Open();
                                    using (var remotecm = remotecn.CreateCommand())
                                    {
                                        StringBuilder SQL = new StringBuilder();
                                        SQL.Append("SELECT    count(1) ");
                                        SQL.Append("   FROM t_box where  TaskNo = '" + downloadArgs.Batch +
                                                   "' and orderdate  = '" + downloadArgs.OrderDate + "' and Linecode = '" +
                                                   downloadArgs.LineCode + "'");
                                        remotecm.CommandText = SQL.ToString();
                                        incount = DetailCount = Convert.ToInt32(remotecm.ExecuteScalar());
                                        DetailIndex = 0;

                                        SQL = new StringBuilder();
                                        SQL.Append("SELECT     * ");
                                        SQL.Append("   FROM t_box where TaskNo = '" + downloadArgs.Batch +
                                                   "' and orderdate  = '" + downloadArgs.OrderDate + "' and Linecode = '" +
                                                   downloadArgs.LineCode + "'");
                                        remotecm.CommandText = SQL.ToString();
                                        using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                        {
                                            while (dr.Read())
                                            {
                                                using (var cm = cn.CreateCommand())
                                                {
                                                    cm.Transaction = tran;
                                                    SQL = new StringBuilder();
                                                    SQL.Append("INSERT ");
                                                    SQL.Append("   INTO t_box ");
                                                    SQL.Append("        ( ");
                                                    SQL.Append(
                                                        "            ID,SORTINGTASKNO,ORDERDATE,boxCode,customerNo,boxCount,lineCode,lineId,boxQty,BOXSEQ,IndexNo ");
                                                    SQL.Append("        ) ");
                                                    SQL.Append("        VALUES ");
                                                    SQL.Append("        ( ");
                                                    SQL.Append(
                                                        "            @ID,@sortingTaskNo,@ORDERDATE,@boxCode,@customerNo,@boxCount,@lineCode,@lineId,@boxQty,@BOXSEQ,@IndexNo ");
                                                    SQL.Append("        )");
                                                    cm.CommandText = SQL.ToString();
                                                    cm.Parameters.AddWithValue("@ID", dr.GetString("ID"));
                                                    cm.Parameters.AddWithValue("@sortingTaskNo",
                                                                               dr.GetString("TaskNo"));
                                                    cm.Parameters.AddWithValue("@ORDERDATE",
                                                                               dr.GetString("ORDERDATE"));
                                                    cm.Parameters.AddWithValue("@boxCode",
                                                                               dr.GetString("boxCode"));
                                                    cm.Parameters.AddWithValue("@customerNo",
                                                                               dr.GetString("customerNo"));
                                                    cm.Parameters.AddWithValue("@boxCount",
                                                                               dr.GetInt32("boxCount"));
                                                    cm.Parameters.AddWithValue("@lineCode", dr.GetString("lineCode"));
                                                    cm.Parameters.AddWithValue("@lineId", dr.GetString("lineId"));
                                                    cm.Parameters.AddWithValue("@boxQty", dr.GetInt32("boxQty"));
                                                    cm.Parameters.AddWithValue("@BOXSEQ", dr.GetInt32("BOXSEQ"));
                                                    cm.Parameters.AddWithValue("@IndexNo", dr.GetInt32("IndexNo"));

                                                    cm.ExecuteNonQuery();
                                                    DetailIndex++;
                                                    if (OnPrecessUpdate != null)
                                                    {
                                                        OnPrecessUpdate.Invoke(null,
                                                                               new DownloadPrecess(MainCount, MainIndex,
                                                                                                   DetailCount,
                                                                                                   DetailIndex));
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }


                                if (OnPrecessUpdate != null)
                                {
                                    OnPrecessUpdate.Invoke(null,
                                                           new DownloadPrecess(MainCount, MainIndex, DetailCount,
                                                                               DetailIndex));
                                }


                                monitorLog = MonitorLog.NewMonitorLog();
                                monitorLog.LOGNAME = "数据库写入";
                                monitorLog.LOGINFO = "插入烟包数据成功,订单日期:" + downloadArgs.OrderDate.ToString() + " 主表:" +
                                                     incount;
                                monitorLog.LOGLOCATION = "数据库";
                                monitorLog.LOGTYPE = 0;
                                monitorLog.Save();

                                #endregion

                                //#region 领用单数据


                                //if (OnProcessStart != null)
                                //{
                                //    OnProcessStart.Invoke(null,
                                //                          new StepNameEvenArgs(downloadArgs.LineName, "同步领用单表"));
                                //}
                                //MainIndex++;
                                //using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                                //{
                                //    remotecn.Open();

                                //    using (var remotecm = remotecn.CreateCommand())
                                //    {
                                //        StringBuilder SQL = new StringBuilder();
                                //        SQL.Append("SELECT count(1) FROM t_materialsdetail m ");
                                //        SQL.Append("  where TaskNo = '" +
                                //                   downloadArgs.Batch +
                                //                   "' and orderdate  = '" + downloadArgs.OrderDate + "'");
                                //        remotecm.CommandText = SQL.ToString();
                                //        incount = DetailCount = Convert.ToInt32(remotecm.ExecuteScalar());
                                //        DetailIndex = 0;

                                //        SQL = new StringBuilder();
                                //        SQL.Append("SELECT * FROM t_materialsdetail m ");
                                //        SQL.Append("  where TaskNo = '" +
                                //                   downloadArgs.Batch +
                                //                   "' and orderdate  = '" + downloadArgs.OrderDate + "'");
                                //        remotecm.CommandText = SQL.ToString();
                                //        using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                //        {
                                //            while (dr.Read())
                                //            {
                                //                using (var cm = cn.CreateCommand())
                                //                {
                                //                    cm.Transaction = tran;
                                //                    SQL = new StringBuilder();
                                //                    SQL.Append(
                                //                        "INSERT INTO t_materialsdetail (id, orderDate,  sequenceNo, sortingTaskNo, status, lineId,taskno) VALUES (@id, @orderDate, @sequenceNo, @sortingTaskNo, @status, @lineId,@taskno);");
						                            
                                //                    cm.CommandText = SQL.ToString();
						                            
                                //                    cm.Parameters.AddWithValue("@id", dr.GetString("id"));
                                //                    cm.Parameters.AddWithValue("@orderDate", dr.GetString("orderDate"));
						                            
                                //                    cm.Parameters.AddWithValue("@sequenceNo", dr.GetString("sequenceNo"));
                                //                    cm.Parameters.AddWithValue("@sortingTaskNo", dr.GetString("sortingTaskNo"));
                                //                    cm.Parameters.AddWithValue("@status", dr.GetInt32("status"));
                                //                    cm.Parameters.AddWithValue("@lineId",  dr.GetString("lineId"));
                                //                    cm.Parameters.AddWithValue("@taskno", dr.GetString("taskno"));
                                                    
                                //                    cm.ExecuteNonQuery();
						                         
                                //                }

                                //            }
                                //        }
                                //    }
                                //}


                                //DetailIndex = 0;
                                //using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                                //{
                                //    remotecn.Open();

                                //    using (var remotecm = remotecn.CreateCommand())
                                //    {
                                //        StringBuilder SQL = new StringBuilder();
                                //        SQL.Append("SELECT count(1) FROM t_materialsdetail_detail WHERE materialsDetailId in (SELECT id FROM t_materialsdetail m ");
                                //        SQL.Append("  where TaskNo = '" +
                                //                   downloadArgs.Batch +
                                //                   "' and orderdate  = '" + downloadArgs.OrderDate + "')");
                                //        remotecm.CommandText = SQL.ToString();
                                //        incount = DetailCount = Convert.ToInt32(remotecm.ExecuteScalar());
                                        

                                //        SQL = new StringBuilder();
                                //        SQL.Append("SELECT * FROM t_materialsdetail_detail WHERE materialsDetailId in (SELECT id FROM t_materialsdetail m ");
                                //        SQL.Append("  where TaskNo = '" +
                                //                   downloadArgs.Batch +
                                //                   "' and orderdate  = '" + downloadArgs.OrderDate + "')");
                                //        remotecm.CommandText = SQL.ToString();
                                //        using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                //        {
                                //            while (dr.Read())
                                //            {
                                //                using (var cm = cn.CreateCommand())
                                //                {
                                //                    cm.Transaction = tran;
                                //                    SQL = new StringBuilder();
                                //                    SQL.Append(
                                //                        "INSERT INTO t_materialsdetail_detail (id, pickNum, qty, tQty, cigInfoId, materialsDetailId) VALUES (@id,@pickNum, @qty, @tQty, @cigInfoId, @materialsDetailId);");

                                //                    cm.CommandText = SQL.ToString();

                                //                    cm.Parameters.AddWithValue("@id", dr.GetString("id"));
                                //                    cm.Parameters.AddWithValue("@pickNum", dr.GetInt32("pickNum"));
                                //                    cm.Parameters.AddWithValue("@qty", dr.GetInt32("qty"));
                                //                    cm.Parameters.AddWithValue("@tQty", dr.GetInt32("tQty"));
                                //                    cm.Parameters.AddWithValue("@cigInfoId", dr.GetString("cigInfoId"));
                                //                    cm.Parameters.AddWithValue("@materialsDetailId", dr.GetString("materialsDetailId"));
                                                    
                                //                    cm.ExecuteNonQuery();
                                //                    DetailIndex++;


                                //                    if (OnPrecessUpdate != null)
                                //                    {
                                //                        OnPrecessUpdate.Invoke(null,
                                //                            new DownloadPrecess(MainCount, MainIndex,
                                //                                DetailCount,
                                //                                DetailIndex));
                                //                    }
                                //                }

                                //            }
                                //        }
                                //    }
                                //}


                                //if (OnPrecessUpdate != null)
                                //{
                                //    OnPrecessUpdate.Invoke(null,
                                //                           new DownloadPrecess(MainCount, MainIndex, DetailCount,
                                //                                               DetailIndex));
                                //}


                                //monitorLog = MonitorLog.NewMonitorLog();
                                //monitorLog.LOGNAME = "数据库写入";
                                //monitorLog.LOGINFO = "插入领用数据成功,订单日期:" + downloadArgs.OrderDate.ToString() + " 主表:" +
                                //                     incount;
                                //monitorLog.LOGLOCATION = "数据库";
                                //monitorLog.LOGTYPE = 0;
                                //monitorLog.Save();

                                //#endregion

                                #region 历史数据

                                

                                if (OnProcessStart != null)
                                {
                                    OnProcessStart.Invoke(null,
                                                          new StepNameEvenArgs(downloadArgs.LineName, "导入历史数据表"));
                                }
                                

                                MainIndex++;
                                DetailCount = 1;
                                DetailIndex = 0;
                                using (var cm = cn.CreateCommand())
                                {
                                    cm.Transaction = tran;

                                    cm.CommandText =
                                        "delete from T_SORTING_LINE_DETAIL_TASK_HISTORY  where taskid in (select ID from t_sorting_line_task_history where PICKLINECODE = '" +
                                        downloadArgs.LineCode + "')";
                                    cm.ExecuteNonQuery();

                                    cm.CommandText =
                                        "INSERT INTO T_SORTING_LINE_DETAIL_TASK_HISTORY SELECT * FROM T_SORTING_LINE_DETAIL_TASK";
                                    cm.ExecuteNonQuery();

                                    cm.CommandText =
                                        "delete from T_SORTING_LINE_TASK_HISTORY  where PICKLINECODE = '" +
                                        downloadArgs.LineCode + "'";
                                    cm.ExecuteNonQuery();

                                    cm.CommandText =
                                        "INSERT INTO t_sorting_line_task_history SELECT * FROM t_sorting_line_task";
                                    cm.ExecuteNonQuery();

                                    cm.CommandText =
                                        "delete from T_INTASK_HISTORY  where LINECODE = '" +
                                        downloadArgs.LineCode + "'";
                                    cm.ExecuteNonQuery();

                                    cm.CommandText =
                                        "INSERT INTO T_INTASK_HISTORY SELECT * FROM T_INTASK where LINECODE = '" +
                                        downloadArgs.LineCode + "' and  orderdate  = '" + downloadArgs.OrderDate +
                                        "' and INTASKNO = '" + downloadArgs.Batch + "'";
                                    cm.ExecuteNonQuery();

                                    cm.CommandText =
                                        "delete from T_BOX_HISTORY  where LINECODE = '" +
                                        downloadArgs.LineCode + "'";
                                    cm.ExecuteNonQuery();

                                    cm.CommandText =
                                        "INSERT INTO T_BOX_HISTORY SELECT * FROM T_BOX where LINECODE = '" +
                                        downloadArgs.LineCode + "' and  orderdate  = '" + downloadArgs.OrderDate +
                                        "' and SORTINGTASKNO = '" + downloadArgs.Batch + "'";
                                    cm.ExecuteNonQuery();


                                    cm.CommandText =
                                        "delete from T_Intask  where type <> 0";
                                    cm.ExecuteNonQuery();

                                    DetailIndex++;
                                }


                                if (OnPrecessUpdate != null)
                                {
                                    OnPrecessUpdate.Invoke(null,
                                                           new DownloadPrecess(MainCount, MainIndex, DetailCount,
                                                                               DetailIndex));
                                }

                                

                                //生成分拣效率进度
                                SortingProcessList.GetSortingProcessList("");

                                monitorLog = MonitorLog.NewMonitorLog();
                                monitorLog.LOGNAME = "数据库写入";
                                monitorLog.LOGINFO = "历史数据导入成功,订单日期:" + downloadArgs.OrderDate.ToString();
                                monitorLog.LOGLOCATION = "数据库";
                                monitorLog.LOGTYPE = 0;
                                monitorLog.Save();

                                tran.Commit();

                                //根据下载完成的数据设置任务地址位
                                SetOutPort();

                                SetServerOutPort(downloadArgs.OutPut);
                                
                                if (OnProcessFinish != null)
                                {
                                    OnProcessFinish.Invoke(null, downloadArgs);
                                }

                                #endregion

                            }
                            #endregion

                            #region 异形烟下载
                            //else if (downloadArgs.OrderType == 2)
                            //{
                               

                            //    #region 异型订单主表下载

                            //    if (OnProcessStart != null)
                            //    {
                            //        OnProcessStart.Invoke(null,
                            //                              new StepNameEvenArgs(downloadArgs.LineName, "同步异型烟订单主表"));
                            //    }
                            //    MainIndex++;
                            //    using (var cm = cn.CreateCommand())
                            //    {
                            //        cm.Transaction = tran;
                            //        cm.CommandText = "delete from T_SORTING_LINE_TASK_ABNORMAL";
                            //        cm.Parameters.AddWithValue("@orderdate", downloadArgs.OrderDate.ToString());
                            //        cm.ExecuteNonQuery();

                            //        cm.CommandText = "delete from T_SORTING_LINE_DETAIL_TASK_ABNORMAL";
                            //        cm.ExecuteNonQuery();

                            //        cm.CommandText = "delete from T_INTASK_ABNORMAL ";
                            //        cm.ExecuteNonQuery();
                                    

                            //        cm.CommandText = "delete from t_box where linecode = '" + downloadArgs.LineCode +
                            //                         "'";
                            //        cm.ExecuteNonQuery();
                            //    }

                            //    monitorLog = MonitorLog.NewMonitorLog();
                            //    monitorLog.LOGNAME = "数据库写入";
                            //    monitorLog.LOGINFO = "清除异型烟分拣订单成功!";
                            //    monitorLog.LOGLOCATION = "数据库";
                            //    monitorLog.LOGTYPE = 0;
                            //    monitorLog.Save();

                            //    monitorLog = MonitorLog.NewMonitorLog();
                            //    monitorLog.LOGNAME = "数据库写入";
                            //    monitorLog.LOGINFO = "开始插入异型烟分拣订单数据,订单日期:" + downloadArgs.OrderDate.ToString();
                            //    monitorLog.LOGLOCATION = "数据库";
                            //    monitorLog.LOGTYPE = 0;
                            //    monitorLog.Save();



                            //    using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                            //    {
                            //        remotecn.Open();

                            //        using (var remotecm = remotecn.CreateCommand())
                            //        {
                            //            StringBuilder SQL = new StringBuilder();
                            //            SQL.Append("SELECT    count(1) ");
                            //            SQL.Append("   FROM t_sorting_line_task where PICKLINECODE = '" +
                            //                       downloadArgs.LineCode + "' and  orderdate  = '" +
                            //                       downloadArgs.OrderDate +
                            //                       "' and TASKNO = '" + downloadArgs.Batch + "'");
                            //            remotecm.CommandText = SQL.ToString();
                            //            ordercount = DetailCount = Convert.ToInt32(remotecm.ExecuteScalar());
                            //            DetailIndex = 0;
                            //            SQL = new StringBuilder();
                            //            SQL.Append("SELECT * ");
                            //            SQL.Append("   FROM t_sorting_line_task where PICKLINECODE = '" +
                            //                       downloadArgs.LineCode + "' and  orderdate  = '" +
                            //                       downloadArgs.OrderDate +
                            //                       "' and TASKNO = '" + downloadArgs.Batch + "'");
                            //            remotecm.CommandText = SQL.ToString();
                            //            using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                            //            {
                            //                while (dr.Read())
                            //                {
                            //                    using (var cm = cn.CreateCommand())
                            //                    {
                            //                        cm.Transaction = tran;
                            //                        SQL = new StringBuilder();
                            //                        SQL.Append("INSERT ");
                            //                        SQL.Append("   INTO t_sorting_line_task_ABNORMAL ");
                            //                        SQL.Append("        ( ");
                            //                        SQL.Append(
                            //                            "            ID,SORTINGTASKNO,ORDERDATE,PICKLINECODE,PICKLINENAME,CUSTCODE,CUSTNAME,INDEXNO,OUTPORT,PLCADDRESS,LINECODE,LINENAME,CORPCODE,CORPNAME,shortname ");
                            //                        SQL.Append("        ) ");
                            //                        SQL.Append("        VALUES ");
                            //                        SQL.Append("        ( ");
                            //                        SQL.Append(
                            //                            "            @ID,@SORTINGTASKNO,@ORDERDATE,@PICKLINECODE,@PICKLINENAME,@CUSTCODE,@CUSTNAME,@INDEXNO,@OUTPORT,@PLCADDRESS,@LINECODE,@LINENAME,@CORPCODE,@CORPNAME,@shortname ");
                            //                        SQL.Append("        )");
                            //                        cm.CommandText = SQL.ToString();
                            //                        cm.Parameters.AddWithValue("@ID", dr.GetString("ID"));
                            //                        cm.Parameters.AddWithValue("@SORTINGTASKNO",
                            //                                                   dr.GetString("TASKNO"));
                            //                        cm.Parameters.AddWithValue("@PICKLINECODE",
                            //                                                   dr.GetString("PICKLINECODE"));
                            //                        cm.Parameters.AddWithValue("@ORDERDATE", dr.GetString("ORDERDATE"));
                            //                        cm.Parameters.AddWithValue("@PICKLINENAME",
                            //                                                   dr.GetString("PICKLINENAME"));
                            //                        cm.Parameters.AddWithValue("@CUSTCODE", dr.GetString("CUSTCODE"));
                            //                        cm.Parameters.AddWithValue("@CUSTNAME", dr.GetString("CUSTNAME"));
                            //                        cm.Parameters.AddWithValue("@INDEXNO", dr.GetInt32("INDEXNO"));
                            //                        cm.Parameters.AddWithValue("@OUTPORT", dr.GetString("OUTPORT"));
                            //                        cm.Parameters.AddWithValue("@PLCADDRESS", 0);
                            //                        cm.Parameters.AddWithValue("@LINECODE", dr.GetString("LINECODE"));
                            //                        cm.Parameters.AddWithValue("@LINENAME", dr.GetString("LINENAME"));
                            //                        cm.Parameters.AddWithValue("@CORPCODE", dr.GetString("CORPCODE"));
                            //                        cm.Parameters.AddWithValue("@CORPNAME", dr.GetString("CORPNAME"));
                            //                        cm.Parameters.AddWithValue("@shortname", dr.GetString("shortname"));
                            //                        cm.ExecuteNonQuery();
                            //                        DetailIndex++;

                            //                        if (OnPrecessUpdate != null)
                            //                        {
                            //                            OnPrecessUpdate.Invoke(null,
                            //                                                   new DownloadPrecess(MainCount, MainIndex,
                            //                                                                       DetailCount,
                            //                                                                       DetailIndex));
                            //                        }
                            //                    }

                            //                }
                            //            }
                            //        }
                            //    }


                            //    if (OnPrecessUpdate != null)
                            //    {
                            //        OnPrecessUpdate.Invoke(null,
                            //                               new DownloadPrecess(MainCount, MainIndex, DetailCount,
                            //                                                   DetailIndex));
                            //    }

                            //    #endregion

                            //    #region 异型订单明细下载

                            //    if (OnProcessStart != null)
                            //    {
                            //        OnProcessStart.Invoke(null,
                            //                              new StepNameEvenArgs(downloadArgs.LineName, "同步异型烟订单明细表"));
                            //    }
                            //    MainIndex++;

                            //    using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                            //    {
                            //        remotecn.Open();

                            //        using (var remotecm = remotecn.CreateCommand())
                            //        {
                            //            StringBuilder SQL = new StringBuilder();
                            //            SQL.Append("SELECT    count(1) ");
                            //            SQL.Append(
                            //                "   FROM t_sorting_line_task t join  t_sorting_line_detail_task dt on dt.taskid = t.id where t.PICKLINECODE = '" +
                            //                downloadArgs.LineCode + "' and  t.orderdate  = '" + downloadArgs.OrderDate +
                            //                "' and t.TASKNO = '" + downloadArgs.Batch + "'");
                            //            remotecm.CommandText = SQL.ToString();
                            //            orderdetailcount = DetailCount = Convert.ToInt32(remotecm.ExecuteScalar());
                            //            DetailIndex = 0;

                            //            SQL = new StringBuilder();
                            //            SQL.Append("SELECT    dt.* ");
                            //            SQL.Append(
                            //                "   FROM t_sorting_line_task t join  t_sorting_line_detail_task dt on dt.taskid = t.id where t.PICKLINECODE = '" +
                            //                downloadArgs.LineCode + "' and  t.orderdate  = '" + downloadArgs.OrderDate +
                            //                "' and t.TASKNO = '" + downloadArgs.Batch + "'");
                            //            remotecm.CommandText = SQL.ToString();
                            //            using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                            //            {
                            //                while (dr.Read())
                            //                {
                            //                    using (var cm = cn.CreateCommand())
                            //                    {
                            //                        cm.Transaction = tran;
                            //                        SQL = new StringBuilder();
                            //                        SQL.Append("INSERT ");
                            //                        SQL.Append("   INTO t_sorting_line_detail_task_ABNORMAL ");
                            //                        SQL.Append("        ( ");
                            //                        SQL.Append(
                            //                            "            ID,TASKID,SUBLINECODE,SUBLINENAME,LINEBOXCODE,LINEBOXNAME,ADDRESSCODE,CIGCODE,CIGNAME,QTY ");
                            //                        SQL.Append("        ) ");
                            //                        SQL.Append("        VALUES ");
                            //                        SQL.Append("        ( ");
                            //                        SQL.Append(
                            //                            "            @ID,@TASKID,@SUBLINECODE,@SUBLINENAME,@LINEBOXCODE,@LINEBOXNAME,@ADDRESSCODE,@CIGCODE,@CIGNAME,@QTY ");
                            //                        SQL.Append("        )");
                            //                        cm.CommandText = SQL.ToString();
                            //                        cm.Parameters.AddWithValue("@ID", dr.GetString("ID"));
                            //                        cm.Parameters.AddWithValue("@TASKID",
                            //                                                   dr.GetString("TASKID"));
                            //                        cm.Parameters.AddWithValue("@SUBLINECODE",
                            //                                                   dr.GetString("SUBLINECODE"));

                            //                        cm.Parameters.AddWithValue("@SUBLINENAME",
                            //                                                   dr.GetString("SUBLINENAME"));
                            //                        cm.Parameters.AddWithValue("@LINEBOXCODE",
                            //                                                   dr.GetString("LINEBOXCODE"));
                            //                        cm.Parameters.AddWithValue("@LINEBOXNAME",
                            //                                                   dr.GetString("LINEBOXNAME"));
                            //                        cm.Parameters.AddWithValue("@ADDRESSCODE",
                            //                                                   dr.GetString("ADDRESSCODE"));
                            //                        cm.Parameters.AddWithValue("@CIGCODE", dr.GetString("CIGCODE"));
                            //                        cm.Parameters.AddWithValue("@CIGNAME", dr.GetString("CIGNAME"));
                            //                        cm.Parameters.AddWithValue("@QTY", dr.GetInt32("QTY"));
                            //                        cm.ExecuteNonQuery();
                            //                        DetailIndex++;

                            //                        if (OnPrecessUpdate != null)
                            //                        {
                            //                            OnPrecessUpdate.Invoke(null,
                            //                                                   new DownloadPrecess(MainCount, MainIndex,
                            //                                                                       DetailCount,
                            //                                                                       DetailIndex));
                            //                        }
                            //                    }

                            //                }
                            //            }
                            //        }
                            //    }

                            //    if (OnPrecessUpdate != null)
                            //    {
                            //        OnPrecessUpdate.Invoke(null,
                            //                               new DownloadPrecess(MainCount, MainIndex, DetailCount,
                            //                                                   DetailIndex));
                            //    }

                            //    monitorLog = MonitorLog.NewMonitorLog();
                            //    monitorLog.LOGNAME = "数据库写入";
                            //    monitorLog.LOGINFO = "插入异型烟分拣订单数据成功,订单日期:" + downloadArgs.OrderDate.ToString() + " 主表:" +
                            //                         ordercount + "明细:" + orderdetailcount;
                            //    monitorLog.LOGLOCATION = "数据库";
                            //    monitorLog.LOGTYPE = 0;
                            //    monitorLog.Save();

                            //    #endregion

                            //    #region 异型烟包数据


                            //    if (OnProcessStart != null)
                            //    {
                            //        OnProcessStart.Invoke(null,
                            //                              new StepNameEvenArgs(downloadArgs.LineName, "同步异型烟包表"));
                            //    }
                            //    MainIndex++;
                            //    using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                            //    {
                            //        remotecn.Open();
                            //        using (var remotecm = remotecn.CreateCommand())
                            //        {
                            //            StringBuilder SQL = new StringBuilder();
                            //            SQL.Append("SELECT    count(1) ");
                            //            SQL.Append("   FROM t_box where  TaskNo = '" + downloadArgs.Batch +
                            //                       "' and orderdate  = '" + downloadArgs.OrderDate + "' and Linecode = '" +
                            //                       downloadArgs.LineCode + "'");
                            //            remotecm.CommandText = SQL.ToString();
                            //            incount = DetailCount = Convert.ToInt32(remotecm.ExecuteScalar());
                            //            DetailIndex = 0;

                            //            SQL = new StringBuilder();
                            //            SQL.Append("SELECT     * ");
                            //            SQL.Append("   FROM t_box where  TaskNo = '" + downloadArgs.Batch +
                            //                       "' and orderdate  = '" + downloadArgs.OrderDate + "' and Linecode = '" +
                            //                       downloadArgs.LineCode + "'");
                            //            remotecm.CommandText = SQL.ToString();
                            //            using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                            //            {
                            //                while (dr.Read())
                            //                {
                            //                    using (var cm = cn.CreateCommand())
                            //                    {
                            //                        cm.Transaction = tran;
                            //                        SQL = new StringBuilder();
                            //                        SQL.Append("INSERT ");
                            //                        SQL.Append("   INTO t_box ");
                            //                        SQL.Append("        ( ");
                            //                        SQL.Append(
                            //                            "            ID,SORTINGTASKNO,ORDERDATE,boxCode,customerNo,boxCount,lineCode,lineId,boxQty,BOXSEQ,IndexNo ");
                            //                        SQL.Append("        ) ");
                            //                        SQL.Append("        VALUES ");
                            //                        SQL.Append("        ( ");
                            //                        SQL.Append(
                            //                            "            @ID,@sortingTaskNo,@ORDERDATE,@boxCode,@customerNo,@boxCount,@lineCode,@lineId,@boxQty,@BOXSEQ,@IndexNo ");
                            //                        SQL.Append("        )");
                            //                        cm.CommandText = SQL.ToString();
                            //                        cm.Parameters.AddWithValue("@ID", dr.GetString("ID"));
                            //                        cm.Parameters.AddWithValue("@sortingTaskNo",
                            //                                                   dr.GetString("TaskNo"));
                            //                        cm.Parameters.AddWithValue("@ORDERDATE",
                            //                                                   dr.GetString("ORDERDATE"));
                            //                        cm.Parameters.AddWithValue("@boxCode",
                            //                                                   dr.GetString("boxCode"));
                            //                        cm.Parameters.AddWithValue("@customerNo",
                            //                                                   dr.GetString("customerNo"));
                            //                        cm.Parameters.AddWithValue("@boxCount",
                            //                                                   dr.GetInt32("boxCount"));
                            //                        cm.Parameters.AddWithValue("@lineCode", dr.GetString("lineCode"));
                            //                        cm.Parameters.AddWithValue("@lineId", dr.GetString("lineId"));
                            //                        cm.Parameters.AddWithValue("@boxQty", dr.GetInt32("boxQty"));
                            //                        cm.Parameters.AddWithValue("@BOXSEQ", dr.GetInt32("BOXSEQ"));
                            //                        cm.Parameters.AddWithValue("@IndexNo", dr.GetInt32("IndexNo"));

                            //                        cm.ExecuteNonQuery();
                            //                        DetailIndex++;
                            //                        if (OnPrecessUpdate != null)
                            //                        {
                            //                            OnPrecessUpdate.Invoke(null,
                            //                                                   new DownloadPrecess(MainCount, MainIndex,
                            //                                                                       DetailCount,
                            //                                                                       DetailIndex));
                            //                        }
                            //                    }

                            //                }
                            //            }
                            //        }
                            //    }


                            //    if (OnPrecessUpdate != null)
                            //    {
                            //        OnPrecessUpdate.Invoke(null,
                            //                               new DownloadPrecess(MainCount, MainIndex, DetailCount,
                            //                                                   DetailIndex));
                            //    }


                            //    monitorLog = MonitorLog.NewMonitorLog();
                            //    monitorLog.LOGNAME = "数据库写入";
                            //    monitorLog.LOGINFO = "插入异型烟包数据成功,订单日期:" + downloadArgs.OrderDate.ToString() + " 主表:" +
                            //                         incount;
                            //    monitorLog.LOGLOCATION = "数据库";
                            //    monitorLog.LOGTYPE = 0;
                            //    monitorLog.Save();

                            //    #endregion

                            //    #region 历史数据

                            //    MainIndex++;
                            //    if (OnProcessStart != null)
                            //    {
                            //        OnProcessStart.Invoke(null,
                            //                              new StepNameEvenArgs(downloadArgs.LineName, "导入历史数据表"));
                            //    }
                            //    using (var cm = cn.CreateCommand())
                            //    {
                            //        cm.Transaction = tran;

                            //        cm.CommandText =
                            //            "delete from T_SORTING_LINE_DETAIL_TASK_HISTORY  where taskid in (select ID from t_sorting_line_task_history where PICKLINECODE = '" +
                            //            downloadArgs.LineCode + "')";
                            //        cm.ExecuteNonQuery();

                            //        cm.CommandText =
                            //            "INSERT INTO T_SORTING_LINE_DETAIL_TASK_HISTORY SELECT * FROM T_SORTING_LINE_DETAIL_TASK_ABNORMAL";
                            //        cm.ExecuteNonQuery();


                            //        cm.CommandText =
                            //            "delete from T_SORTING_LINE_TASK_HISTORY  where PICKLINECODE = '" +
                            //            downloadArgs.LineCode + "'";
                            //        cm.ExecuteNonQuery();

                            //        cm.CommandText =
                            //            "INSERT INTO t_sorting_line_task_history SELECT * FROM T_SORTING_LINE_TASK_ABNORMAL";
                            //        cm.ExecuteNonQuery();

                            //        cm.CommandText =
                            //            "delete from T_BOX_HISTORY  where LINECODE = '" +
                            //            downloadArgs.LineCode + "'";
                            //        cm.ExecuteNonQuery();

                            //        cm.CommandText =
                            //            "INSERT INTO T_BOX_HISTORY SELECT * FROM T_BOX where LINECODE = '" +
                            //            downloadArgs.LineCode + "' and  orderdate  = '" + downloadArgs.OrderDate +
                            //            "' and SORTINGTASKNO = '" + downloadArgs.Batch + "'";
                            //        cm.ExecuteNonQuery();
                            //    }


                            //    if (OnPrecessUpdate != null)
                            //    {
                            //        OnPrecessUpdate.Invoke(null,
                            //                               new DownloadPrecess(MainCount, MainIndex, DetailCount,
                            //                                                   DetailIndex));
                            //    }

                                

                            //    //生成分拣效率进度
                            //    SortingProcessList.GetSortingProcessList("");

                            //    monitorLog = MonitorLog.NewMonitorLog();
                            //    monitorLog.LOGNAME = "数据库写入";
                            //    monitorLog.LOGINFO = "历史数据导入成功,订单日期:" + downloadArgs.OrderDate.ToString();
                            //    monitorLog.LOGLOCATION = "数据库";
                            //    monitorLog.LOGTYPE = 0;
                            //    monitorLog.Save();

                            //    tran.Commit();

                            //    if (OnProcessFinish != null)
                            //    {
                            //        OnProcessFinish.Invoke(null, downloadArgs);
                            //    }
                                

                            //    #endregion
                            //}
                           #endregion
                        }
                        catch (Exception ex)
                        {
                            if (tran != null)
                            {
                                tran.Rollback();
                            }
                            if (OnProcessError != null)
                            {
                                OnProcessError.Invoke(null, new DownloadErrorArgs(ex));
                            }
                            throw ex;
                        }
                    }
                }

                #endregion
            }
            SortingLineTask.UploadSortingStatus(1);

            if (OnDownLoadFinish != null)
            {
                OnDownLoadFinish.Invoke(null, new EventArgs());
            }
            Thread.Sleep(1000);
        }

        private static void SetServerOutPort(string outport)
        {
            if (outport == "-1")
            {
                return;
            }
            if (outport == "1")
            {
                OutPortTransfer.SetServerDisOutPort("1");
            }
            else if (outport == "2")
            {
                OutPortTransfer.SetServerDisOutPort("2");
            }
            else if (outport == "0")
            {
                OutPortTransfer.SetServerDisOutPort();
            }
        }

        public static void TransferOrderBox(object downloadarg)
        {
            
                if (OnProcessStart != null)
                {
                    OnProcessStart.Invoke(null,
                                          new StepNameEvenArgs("", "导出常规烟打标机数据"));
                }


                MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "数据库写入";
                monitorLog.LOGINFO = "导出打标机数据!";
                monitorLog.LOGLOCATION = "数据库";
                monitorLog.LOGTYPE = 0;
                monitorLog.Save();

                DownloadArgs downloadArgs = (DownloadArgs)downloadarg;
                DetailCount = 0;
                DetailIndex = 0;
                using (var cn = new SqlConnection(AppUtility.AppUtil._TBConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText = "delete from enshi_tb";
                        cm.ExecuteNonQuery();
                    }
                    using (var tran = cn.BeginTransaction())
                    {
                        using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                        {
                            remotecn.Open();

                            using (var remotecm = remotecn.CreateCommand())
                            {
                                remotecm.CommandType = CommandType.StoredProcedure;
                                remotecm.CommandText = "proc_getpackaging";
                                remotecm.Parameters.Add("@p_orderdate", downloadArgs.OrderDate);
                                remotecm.Parameters.Add("@p_taskno", downloadArgs.Batch);

                                DB2Parameter output = remotecm.Parameters.Add("@p_total", DB2Type.Integer);  //添加参数  
                                output.Direction = ParameterDirection.Output;
                                remotecm.ExecuteNonQuery();
                                DetailCount = Convert.ToInt32(output.Value);


                                using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                {
                                    while (dr.Read())
                                    {
                                        using (var cm = cn.CreateCommand())
                                        {
                                            cm.Transaction = tran;
                                            StringBuilder SQL = new StringBuilder();
                                            SQL.Append("INSERT ");
                                            SQL.Append("   INTO enshi_tb ");
                                            SQL.Append("        ( ");
                                            SQL.Append(
                                                "            id,orderno,taskno,orderdate,deliverlinename,indexno,custcode,customername,shortname,total,cigcode,cigname,qty,abqty");
                                            SQL.Append("        ) ");
                                            SQL.Append("        VALUES ");
                                            SQL.Append("        ( ");
                                            SQL.Append(
                                                "            @id,@orderno,@taskno,@orderdate,@deliverlinename,@indexno,@custcode,@customername,@shortname,@total,@cigcode,@cigname,@qty,@abqty");
                                            SQL.Append("        )");
                                            cm.CommandText = SQL.ToString();
                                            cm.Parameters.AddWithValue("@id", dr.GetInt16("id"));
                                            cm.Parameters.AddWithValue("@orderno", dr.GetString("orderno"));
                                            cm.Parameters.AddWithValue("@orderdate", dr.GetString("orderdate"));
                                            cm.Parameters.AddWithValue("@taskno", dr.GetString("taskno"));
                                            cm.Parameters.AddWithValue("@deliverlinename", dr.GetString("deliverlinename"));
                                            cm.Parameters.AddWithValue("@indexno", dr.GetInt16("indexno"));
                                            cm.Parameters.AddWithValue("@custcode", dr.GetString("custcode"));
                                            cm.Parameters.AddWithValue("@customername", dr.GetString("customername"));
                                            cm.Parameters.AddWithValue("@shortname", dr.GetString("shortname"));
                                            cm.Parameters.AddWithValue("@total", dr.GetInt16("total"));
                                            cm.Parameters.AddWithValue("@cigcode", dr.GetString("cigcode"));
                                            cm.Parameters.AddWithValue("@cigname", dr.GetString("cigname"));
                                            cm.Parameters.AddWithValue("@qty", dr.GetInt16("qty"));

                                            if (dr.GetInt16("abqty") == 0)
                                            {
                                                cm.Parameters.AddWithValue("@abqty", DBNull.Value);
                                            }
                                            else
                                            {
                                                cm.Parameters.AddWithValue("@abqty", dr.GetInt16("abqty"));
                                            }
                                            cm.Parameters["@abqty"].IsNullable = true;
                                            cm.ExecuteNonQuery();
                                            DetailIndex++;

                                            if (OnPrecessUpdate != null)
                                            {
                                                OnPrecessUpdate.Invoke(null,
                                                                       new DownloadPrecess(MainCount, MainIndex,
                                                                                           DetailCount,
                                                                                           DetailIndex));
                                            }
                                        }

                                    }
                                }

                            }
                        }
                        tran.Commit();
                    }
                }

                if (OnProcessStart != null)
                {
                    OnProcessStart.Invoke(null,
                                          new StepNameEvenArgs("", "导出异型烟打标机数据"));
                }

                DetailCount = 0;
                DetailIndex = 0;
                using (var cn = new SqlConnection(AppUtility.AppUtil._TBConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText = "delete from enshiyx_tb";
                        cm.ExecuteNonQuery();
                    }
                    using (var tran = cn.BeginTransaction())
                    {
                        using (var remotecn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
                        {
                            remotecn.Open();

                            using (var remotecm = remotecn.CreateCommand())
                            {
                                remotecm.CommandType = CommandType.StoredProcedure;
                                remotecm.CommandText = "proc_getabpackaging";
                                remotecm.Parameters.Add("@p_orderdate", downloadArgs.OrderDate);
                                remotecm.Parameters.Add("@p_taskno", downloadArgs.Batch);

                                DB2Parameter output = remotecm.Parameters.Add("@p_total", DB2Type.Integer);  //添加参数  
                                output.Direction = ParameterDirection.Output;
                                remotecm.ExecuteNonQuery();
                                DetailCount = Convert.ToInt32(output.Value);


                                using (var dr = new SafeDataReader(remotecm.ExecuteReader()))
                                {
                                    while (dr.Read())
                                    {
                                        using (var cm = cn.CreateCommand())
                                        {
                                            cm.Transaction = tran;
                                            StringBuilder SQL = new StringBuilder();
                                            SQL.Append("INSERT ");
                                            SQL.Append("   INTO enshiyx_tb ");
                                            SQL.Append("        ( ");
                                            SQL.Append(
                                                "            id,orderno,orderdate,deliverlinename,indexno,custcode,customername,shortname,total,cigcode,cigname,qty,abqty");
                                            SQL.Append("        ) ");
                                            SQL.Append("        VALUES ");
                                            SQL.Append("        ( ");
                                            SQL.Append(
                                                "            @id,@orderno,@orderdate,@deliverlinename,@indexno,@custcode,@customername,@shortname,@total,@cigcode,@cigname,@qty,@abqty");
                                            SQL.Append("        )");
                                            cm.CommandText = SQL.ToString();
                                            cm.Parameters.AddWithValue("@id", dr.GetInt16("id"));
                                            cm.Parameters.AddWithValue("@orderno", dr.GetString("orderno"));
                                            cm.Parameters.AddWithValue("@orderdate", dr.GetString("orderdate"));
                                            cm.Parameters.AddWithValue("@deliverlinename", dr.GetString("deliverlinename"));
                                            cm.Parameters.AddWithValue("@indexno", dr.GetInt16("indexno"));
                                            cm.Parameters.AddWithValue("@custcode", dr.GetString("custcode"));
                                            cm.Parameters.AddWithValue("@customername", dr.GetString("customername"));
                                            cm.Parameters.AddWithValue("@shortname", dr.GetString("shortname"));
                                            cm.Parameters.AddWithValue("@total", dr.GetInt16("total"));
                                            cm.Parameters.AddWithValue("@cigcode", dr.GetString("cigcode"));
                                            cm.Parameters.AddWithValue("@cigname", dr.GetString("cigname"));
                                            cm.Parameters.AddWithValue("@qty", dr.GetInt16("qty"));
                                            cm.Parameters.AddWithValue("@abqty", dr.GetInt16("abqty"));

                                            cm.ExecuteNonQuery();
                                            DetailIndex++;

                                            if (OnPrecessUpdate != null)
                                            {
                                                OnPrecessUpdate.Invoke(null,
                                                                       new DownloadPrecess(MainCount, MainIndex,
                                                                                           DetailCount,
                                                                                           DetailIndex));
                                            }
                                        }

                                    }
                                }

                            }
                        }
                        tran.Commit();
                    }
                }

            
            




            if (OnTransferFinish != null)
            {
                OnTransferFinish.Invoke(null,new DownloadArgs());
            }
        }

        /// <summary>
        /// 删除一个月前的数据
        /// </summary>
        public static void DeleteHistoryData()
        {
            string monthday = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
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
                            cm.CommandText = "delete from t_box_history where orderdate < '" + monthday + "'";
                            cm.ExecuteNonQuery();
                       
                            
                            cm.CommandText = "delete from t_intask_history where orderdate < '" + monthday + "'";
                            cm.ExecuteNonQuery();                       
                           
                            cm.CommandText = "delete sd.* FROM t_sorting_line_task_history s join t_sorting_line_detail_task_history sd ON s.ID = sd.TASKID WHERE s.ORDERDATE < '" + monthday + "'";
                            cm.ExecuteNonQuery();
                        
                            cm.CommandText = "delete FROM t_sorting_line_task_history  WHERE ORDERDATE < '" + monthday + "'";
                            cm.ExecuteNonQuery();

	                        cm.CommandText = "delete FROM t_monitorlog where createtime < '" + monthday + "'";
                            cm.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        if (tran != null)
                        {
                            tran.Rollback();
                        }                        
                    }
                }
            }
        }



        /// <summary>
        /// 取消下载
        /// </summary>
        public void Cancel()
        {
            
        }


        /// <summary>
        /// 获取分拣任务中包装机出口的数量
        /// </summary>
        /// <returns></returns>
        static public int GetTaskOutPortByLoc()
        {
            bool port1;
            bool port2;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "SELECT count(OUTPORT) twoport FROM	t_sorting_line_task s	WHERE	OUTPORT = 1	GROUP BY OUTPORT";
                    port1 = Convert.ToBoolean(cm.ExecuteScalar());
                    cm.CommandText = "SELECT count(OUTPORT) one FROM	t_sorting_line_task s	WHERE	OUTPORT = 2	GROUP BY OUTPORT";
                    port2 = Convert.ToBoolean(cm.ExecuteScalar());
                    if (port1 && port2)
                    {
                        return 0;
                    }
                    else if(port1)
                    {
                        return 1;
                    }
                    else if (port2)
                    {
                        return 2;
                    }

                }
                return -1;
            }
        }




        static public void SetOutPort()
        {
            //1和2表示单出口使用1-20号地址位
            //if (GetTaskOutPortByLoc() == 1 || GetTaskOutPortByLoc() == 2)
            //{
            //    using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            //    {
            //        cn.Open();
            //        using (var cm = cn.CreateCommand())
            //        {
            //            StringBuilder SQL = new StringBuilder();
            //            cm.CommandText = "UPDATE   t_sorting_line_task s set PLCADDRESS  =  CASE WHEN s.INDEXNO%20 =0 THEN 20 ELSE s.INDEXNO%20 END  ORDER BY s.INDEXNO";
            //            cm.ExecuteNonQuery();
            //        }
            //    }
            //}//0为双出口,按1出口占用1-10，2出口占用11-20地址位
            //else if (GetTaskOutPortByLoc() == 0)
            //{
            //    string orderdate = "";
            //    string sortinglinecode = "";
            //    string batch = "";

            //    using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            //    {
            //        cn.Open();
            //        using (var tran = cn.BeginTransaction())
            //        {
            //            try
            //            {
            //                using (var cm = cn.CreateCommand())
            //                {
            //                    cm.Transaction = tran;
            //                    StringBuilder SQL = new StringBuilder();
                                
            //                    int Aplcaddress = 1;
            //                    int Bplcaddress = 11;


            //                    SQL = new StringBuilder();
            //                    SQL.Append("SELECT * FROM t_sorting_line_task ORDER BY INDEXNO");

            //                    cm.CommandText = SQL.ToString();

            //                    StringBuilder updatesql = new StringBuilder();

            //                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
            //                    {
            //                        while (dr.Read())
            //                        {
            //                            orderdate = dr.GetString("orderdate");
            //                            sortinglinecode = dr.GetString("PICKLINECODE");
            //                            batch = dr.GetString("SORTINGTASKNO");


            //                            if (dr["OUTPORT"].ToString() == "1")
            //                            {
            //                                updatesql.Append("update t_sorting_line_task set PLCADDRESS = '" +
            //                                                 Aplcaddress +
            //                                                 "' where id = '" + dr.GetString("id") + "';");

            //                                Aplcaddress += 1;
            //                                if (Aplcaddress > 10)
            //                                {
            //                                    Aplcaddress = 1;
            //                                }
            //                            }

            //                            if (dr["OUTPORT"].ToString() == "2")
            //                            {
            //                                updatesql.Append("update t_sorting_line_task set PLCADDRESS = '" +
            //                                                 Bplcaddress +
            //                                                 "' where id = '" + dr.GetString("id") + "';");

            //                                Bplcaddress += 1;
            //                                if (Bplcaddress > 20)
            //                                {
            //                                    Bplcaddress = 11;
            //                                }
            //                            }

            //                        }
            //                    }


            //                    cm.CommandText = updatesql.ToString();
            //                    cm.ExecuteNonQuery();



            //                    tran.Commit();
            //                }
            //            }
            //            catch (Exception e)
            //            {
            //                tran.Rollback();
            //                throw e;
            //            }
            //        }
            //    }
            //}

        
        }

        
    }


    public class DownloadPrecess : EventArgs
    {
        public int MainCount { get; set; }
        public int MainIndex { get; set; }
        public int DetailCount { get; set; }
        public int DetailIndex { get; set; }

        public DownloadPrecess(int maincount,int mainindex,int detailcount,int detailindex)
        {
            MainCount = maincount;
            MainIndex = mainindex;
            DetailCount = detailcount;
            DetailIndex = detailindex;
        }
    }

    

    public class DownloadArgs:EventArgs
    {
        /// <summary>
        /// 订单日期
        /// </summary>
        public string OrderDate { get; set; }
        /// <summary>
        /// 分拣线代码
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 分拣线名称
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string Batch { get; set; }
        /// <summary>
        /// 订单类型（1常规2异形）
        /// </summary>
        public int OrderType { get; set; }

        public string OutPut { get; set; }
    }

    public class DownloadErrorArgs:EventArgs
    {
        public Exception exception { get; set; }
        public DownloadErrorArgs(Exception ex)
        {
            exception = ex;
        }

    }



}




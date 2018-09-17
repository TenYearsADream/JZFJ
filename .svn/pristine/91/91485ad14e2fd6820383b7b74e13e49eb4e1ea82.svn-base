// ########file = InTask.cs#############
// ########author = "祝旻" ##############
// ########created = 20140728#############

using System;
using System.Collections.Generic;
using System.Text;
using AppUtility;
using BusinessLogic.Log;
using Csla;
using Csla.Data;
using IBM.Data.DB2;
using MySql.Data.MySqlClient;

namespace BusinessLogic.INTASKS
{

    [Serializable]
    public class InTask : BusinessBase<InTask>
    {
        #region  Business Methods

        private static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(p => p.ID, "标识号");

        private static readonly PropertyInfo<int> INTASKNOProperty = RegisterProperty<int>(p => p.INTASKNO,
                                                                                                "主任务编号");

        private static readonly PropertyInfo<string> ORDERDATEProperty = RegisterProperty<string>(p => p.ORDERDATE,
                                                                                                  "订单日期");


        private static readonly PropertyInfo<string> CIGCODEProperty = RegisterProperty<string>(p => p.CIGCODE, "卷烟代码");

        private static readonly PropertyInfo<string> BARCODEProperty = RegisterProperty<string>(p => p.BARCODE, "卷烟件码");

        private static readonly PropertyInfo<string> CIGNAMEProperty = RegisterProperty<string>(p => p.CIGNAME, "卷烟名称");


        private static readonly PropertyInfo<string> PICKLINECODEProperty = RegisterProperty<string>(
            p => p.PICKLINECODE, "分拣线编号");

        private static readonly PropertyInfo<string> PICKLINENAMEProperty = RegisterProperty<string>(
            p => p.PICKLINENAME, "分拣线名称");

        private static readonly PropertyInfo<string> SUBLINECODEProperty = RegisterProperty<string>(
            p => p.SUBLINECODE, "子线编号");

        private static readonly PropertyInfo<string> INPORTCODEProperty = RegisterProperty<string>(
            p => p.INPORTCODE, "补货口编号");

        private static readonly PropertyInfo<string> LINEBOXCODEProperty = RegisterProperty<string>(p => p.LINEBOXCODE, "烟道代码");

        private static readonly PropertyInfo<string> LINEBOXNAMEProperty = RegisterProperty<string>(p => p.LINEBOXNAME, "烟道名称");

        private static readonly PropertyInfo<string> ADDRESSCODEProperty = RegisterProperty<string>(p => p.ADDRESSCODE, "烟道地址码");

        private static readonly PropertyInfo<int> INQTYProperty = RegisterProperty<int>(p => p.INQTY, "数量");

        private static readonly PropertyInfo<int> SEQUENCENOProperty = RegisterProperty<int>(p => p.INDEXNO, "顺序号");

        private static readonly PropertyInfo<int> PLCADDRESSProperty = RegisterProperty<int>(p => p.PLCADDRESS, "PLC地址");

        

        private static readonly PropertyInfo<int> StatusProperty = RegisterProperty<int>(p => p.Status, "订单任务的状态");


        private static readonly PropertyInfo<DateTime> SortingTimeProperty =
            RegisterProperty<DateTime>(p => p.SortingTime, "分拣任务下达时间");

        private static readonly PropertyInfo<DateTime> FinishTimeProperty =
            RegisterProperty<DateTime>(p => p.FinishTime, "分拣完成时间");


       
        public string ID
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        public int INTASKNO
        {
            get { return GetProperty(INTASKNOProperty); }
            set { SetProperty(INTASKNOProperty, value); }
        }

        public string ORDERDATE
        {
            get { return GetProperty(ORDERDATEProperty); }
            set { SetProperty(ORDERDATEProperty, value); }
        }



        public Int32 INDEXNO
        {
            get { return GetProperty(SEQUENCENOProperty); }
            set { SetProperty(SEQUENCENOProperty, value); }
        }

        public string CIGCODE
        {
            get { return GetProperty(CIGCODEProperty); }
            set { SetProperty(CIGCODEProperty, value); }
        }

        public string BARCODE
        {
            get { return GetProperty(BARCODEProperty); }
            set { SetProperty(BARCODEProperty, value); }
        }

        public string CIGNAME
        {
            get { return GetProperty(CIGNAMEProperty); }
            set { SetProperty(CIGNAMEProperty, value); }
        }

        public string PICKLINECODE
        {
            get { return GetProperty(PICKLINECODEProperty); }
            set { SetProperty(PICKLINECODEProperty, value); }
        }

        public string PICKLINENAME
        {
            get { return GetProperty(PICKLINENAMEProperty); }
            set { SetProperty(PICKLINENAMEProperty, value); }
        }

        public string SUBLINECODE
        {
            get { return GetProperty(SUBLINECODEProperty); }
            set { SetProperty(SUBLINECODEProperty, value); }
        }

        public string INPORTCODE
        {
            get { return GetProperty(INPORTCODEProperty); }
            set { SetProperty(INPORTCODEProperty, value); }
        }

        public string LINEBOXCODE
        {
            get { return GetProperty(LINEBOXCODEProperty); }
            set { SetProperty(LINEBOXCODEProperty, value); }
        }
        

        public string LINEBOXNAME
        {
            get { return GetProperty(LINEBOXNAMEProperty); }
            set { SetProperty(LINEBOXNAMEProperty, value); }
        }

        public string ADDRESSCODE
        {
            get { return GetProperty(ADDRESSCODEProperty); }
            set { SetProperty(ADDRESSCODEProperty, value); }
        }

        public Int32 INQTY
        {
            get { return GetProperty(INQTYProperty); }
            set { SetProperty(INQTYProperty, value); }
        }

        public Int32 PLCADDRESS
        {
            get { return GetProperty(PLCADDRESSProperty); }
            set { SetProperty(PLCADDRESSProperty, value); }
        }


        public Int32 Status
        {
            get { return GetProperty(StatusProperty); }
            set { SetProperty(StatusProperty, value); }
        }


        public DateTime SortingTime
        {
            get { return GetProperty(SortingTimeProperty); }
            set { SetProperty(SortingTimeProperty, value); }
        }

        public DateTime FinishTime
        {
            get { return GetProperty(FinishTimeProperty); }
            set { SetProperty(FinishTimeProperty, value); }
        }

        

        #endregion

        #region  Factory Methods

        private InTask()
        {
            /* require use of factory methods */
        }

        /// <summary>
        /// 获取补货任务
        /// </summary>
        public static InTask GetInTask(SafeDataReader dr)
        {
            return DataPortal.Fetch<InTask>(dr);
        }


        /// <summary>
        /// 按顺序号获取补货任务
        /// </summary>
        public static InTask GetInTaskByIndex(string index)
        {
            return DataPortal.Fetch<InTask>(index);
        }

        /// <summary>
        /// 获取已确认状态下的补货任务,状态为1
        /// </summary>
        public static InTask GetConfirmInTask()
        {
            return DataPortal.Fetch<InTask>();
        }

        /// <summary>
        /// 保存补货任务进度
        /// </summary>
        public void SaveInTaskProcess(string plctaskid)
        {
            InTaskProgress inTaskProgress;

            inTaskProgress = InTaskProgress.GetInTaskProgress(ID);
            if (Status == 0)
            {
                inTaskProgress.STATUS = 0;
                inTaskProgress.SORTINGTIME = null;
                inTaskProgress.FINISHTIME = null;
                inTaskProgress.PLCTASKID = plctaskid;
            }
            if (Status == 1)
            {
                inTaskProgress.STATUS = 1;
                inTaskProgress.SORTINGTIME = DateTime.Now;
                inTaskProgress.FINISHTIME = null;
                inTaskProgress.PLCTASKID = plctaskid;
            }
            if (Status == 2)
            {
                inTaskProgress.FINISHTIME = DateTime.Now;
            }
            inTaskProgress.STATUS = Status;

            inTaskProgress.Save();
        }


        /// <summary>
        /// 获取绑定到卧式机的卷烟代码
        /// </summary>
        public static Dictionary<int, string> GetBindCigCode()
        {
            string cigcode = "0";
            Dictionary<int, string> cigcodes = new Dictionary<int, string>();
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "SELECT DISTINCT(l.boxCode),sd.CIGCODE,sd.CIGNAME FROM t_linebox l LEFT JOIN t_sorting_line_detail_task sd ON l.boxCode = sd.LINEBOXCODE WHERE l.boxType = '0'";

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            if (dr.GetString("cigcode") == "")
                                cigcode = "0";
                            else
                                cigcode = dr.GetString("cigcode").Substring(1);	
                            cigcodes.Add(dr.GetInt32("boxcode"), cigcode);
                        }
                    }
                }
            }
            return cigcodes;
        }

        /// <summary>
        /// 获取补货任务的日期
        /// </summary>
        public static string GetInTaskDate()
        {
            string sortingdate = "";
            string taskno = "";
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "select * from t_intask limit 1";
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            taskno = dr.GetString("intaskno");
                            sortingdate = dr.GetString("ORDERDATE") + ":" + taskno;
                        }
                    }
                }

            }
            return sortingdate;
        }

        /// <summary>
        /// 获取服务器上补货任务日期
        /// </summary>
        public static string GetServerInTaskDate()
        {
            string sortingdate = "";
            string taskno = "";
            using (var cn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "select * from t_intask s JOIN t_sortingline sl ON s.linecode = sl.lineCode WHERE sl.type=1  order by orderdate desc limit 1";
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            taskno = dr.GetString("intaskno");
                            sortingdate = dr.GetString("ORDERDATE") + ":" + taskno;
                        }
                    }
                }

            }
            return sortingdate;
        }


        /// <summary>
        /// 获取补货任务的日期
        /// </summary>
        public static string GetMaxIndex()
        {

            string SEQUENCENO = "";
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "select max(SEQUENCENO) maxSEQUENCENO from t_intask limit 1";
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            SEQUENCENO = dr.GetString("maxSEQUENCENO");
                            
                        }
                    }
                }

            }
            return SEQUENCENO;
        }




        #endregion

        #region  Data Access

            private
            void DataPortal_Fetch(SafeDataReader dr)
        {
            LoadProperty(IdProperty, dr.GetString("ID"));
            LoadProperty(INTASKNOProperty, dr.GetString("INTASKNO"));
            LoadProperty(ORDERDATEProperty, dr.GetString("ORDERDATE"));
            LoadProperty(SEQUENCENOProperty, dr.GetString("SEQUENCENO"));
            LoadProperty(CIGCODEProperty, dr.GetString("CIGCODE"));
            LoadProperty(CIGNAMEProperty, dr.GetString("CIGNAME"));
            LoadProperty(BARCODEProperty, dr.GetString("BARCODE"));
            LoadProperty(PICKLINECODEProperty, dr.GetString("LINECODE"));
            LoadProperty(PICKLINENAMEProperty, dr.GetString("LINENAME"));
            LoadProperty(SUBLINECODEProperty, dr.GetString("SUBLINECODE"));
            LoadProperty(INPORTCODEProperty, dr.GetString("INPORTCODE"));
            LoadProperty(LINEBOXCODEProperty, dr.GetString("LINEBOXCODE"));
            LoadProperty(LINEBOXNAMEProperty, dr.GetString("LINEBOXNAME"));
            LoadProperty(ADDRESSCODEProperty, dr.GetString("ADDRESSCODE"));
            LoadProperty(INQTYProperty, dr.GetInt32("INQTY"));
            LoadProperty(PLCADDRESSProperty, dr.GetInt32("PLCADDRESS"));
            LoadProperty(StatusProperty, dr.GetInt32("Status"));
            LoadProperty(SortingTimeProperty, dr.GetDateTime("SortingTime"));
            LoadProperty(FinishTimeProperty, dr.GetDateTime("FinishTime"));
        }



        private void DataPortal_Fetch()
        {
            using (BypassPropertyChecks)
            {
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();


                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText =
                            "SELECT * FROM T_INTASK t  WHERE t.type = 0 and t.status = 1 order by t.SEQUENCENO desc limit 1,1";
                        //cm.Parameters.AddWithValue("@id", criteria.Value);
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                LoadProperty(IdProperty, dr.GetString("ID"));
                                LoadProperty(INTASKNOProperty, dr.GetString("INTASKNO"));
                                LoadProperty(ORDERDATEProperty, dr.GetString("ORDERDATE"));
                                LoadProperty(SEQUENCENOProperty, dr.GetString("SEQUENCENO"));
                                LoadProperty(CIGCODEProperty, dr.GetString("CIGCODE"));
                                LoadProperty(CIGNAMEProperty, dr.GetString("CIGNAME"));
                                LoadProperty(BARCODEProperty, dr.GetString("BARCODE"));
                                LoadProperty(PICKLINECODEProperty, dr.GetString("LINECODE"));
                                LoadProperty(PICKLINENAMEProperty, dr.GetString("LINENAME"));
                                LoadProperty(SUBLINECODEProperty, dr.GetString("SUBLINECODE"));
                                LoadProperty(INPORTCODEProperty, dr.GetString("INPORTCODE"));
                                LoadProperty(LINEBOXCODEProperty, dr.GetString("LINEBOXCODE"));
                                LoadProperty(LINEBOXNAMEProperty, dr.GetString("LINEBOXNAME"));
                                LoadProperty(ADDRESSCODEProperty, dr.GetString("ADDRESSCODE"));
                                LoadProperty(INQTYProperty, dr.GetInt32("INQTY"));
                                LoadProperty(PLCADDRESSProperty, dr.GetInt32("PLCADDRESS"));
                                LoadProperty(StatusProperty, dr.GetInt32("Status"));
                                LoadProperty(SortingTimeProperty, dr.GetDateTime("SortingTime"));
                                LoadProperty(FinishTimeProperty, dr.GetDateTime("FinishTime"));
                            }
                        }
                    }
                }
            }
        }





        private void DataPortal_Fetch(string plctaskno)
        {
            using (BypassPropertyChecks)
            {
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText =
                            "SELECT  * FROM T_INTASK t WHERE t.SEQUENCENO = @plctaskno limit 1";
                        cm.Parameters.AddWithValue("@plctaskno", Convert.ToInt32(plctaskno));
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                LoadProperty(IdProperty, dr.GetString("ID"));
                                LoadProperty(INTASKNOProperty, dr.GetString("INTASKNO"));
                                LoadProperty(ORDERDATEProperty, dr.GetString("ORDERDATE"));
                                LoadProperty(SEQUENCENOProperty, dr.GetString("SEQUENCENO"));
                                LoadProperty(CIGCODEProperty, dr.GetString("CIGCODE"));
                                LoadProperty(CIGNAMEProperty, dr.GetString("CIGNAME"));
                                LoadProperty(PICKLINECODEProperty, dr.GetString("LINECODE"));
                                LoadProperty(PICKLINENAMEProperty, dr.GetString("LINENAME"));
                                LoadProperty(SUBLINECODEProperty, dr.GetString("SUBLINECODE"));
                                LoadProperty(INPORTCODEProperty, dr.GetString("INPORTCODE"));
                                LoadProperty(BARCODEProperty, dr.GetString("BARCODE"));
                                LoadProperty(LINEBOXCODEProperty, dr.GetString("LINEBOXCODE"));
                                LoadProperty(LINEBOXNAMEProperty, dr.GetString("LINEBOXNAME"));
                                LoadProperty(ADDRESSCODEProperty, dr.GetString("ADDRESSCODE"));
                                LoadProperty(PLCADDRESSProperty, dr.GetInt32("PLCADDRESS"));
                                LoadProperty(INQTYProperty, dr.GetInt32("INQTY"));
                                LoadProperty(StatusProperty, dr.GetInt32("Status"));
                                LoadProperty(SortingTimeProperty, dr.GetDateTime("SortingTime"));
                                LoadProperty(FinishTimeProperty, dr.GetDateTime("FinishTime"));
                            }


                        }
                    }

                }
            }
        }

        

        #endregion

        #region  Exists

        /// <summary>
        /// 补货任务是否与当前日期匹配
        /// </summary>
        public static bool IsCurrentInTask()
        {
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT COUNT(1) FROM (SELECT  MAX(T_INTASK.ORDERDATE) da FROM T_INTASK)  t WHERE t.da = @Date";
                    cm.Parameters.AddWithValue("@Date", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                    if (int.Parse(cm.ExecuteScalar().ToString()) <= 0)
                    {
                        MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                        monitorLog.LOGNAME = "数据库读取";
                        monitorLog.LOGINFO = "当前补货任务日期与系统日期不符合!";
                        monitorLog.LOGLOCATION = "数据库";
                        monitorLog.LOGTYPE = 2;
                        monitorLog.Save();
                        return false;
                    }

                    return true;
                }
            }
        }

        /// <summary>
        /// 同一批次是否存在重复的顺序号
        /// </summary>
        /// <returns></returns>
        public static bool IsIndexRepetition()
        {
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT SEQUENCENO,COUNT(1)  FROM T_INTASK  GROUP BY SEQUENCENO HAVING count(1)> 1";
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                            monitorLog.LOGNAME = "数据库读取";
                            monitorLog.LOGINFO = "当前补货任务存在重复的顺序号!";
                            monitorLog.LOGLOCATION = "数据库";
                            monitorLog.LOGTYPE = 2;
                            monitorLog.Save();
                            return true;
                        }
                    }
                    return false;
                }
            }
        }

       

        #endregion
    }
}
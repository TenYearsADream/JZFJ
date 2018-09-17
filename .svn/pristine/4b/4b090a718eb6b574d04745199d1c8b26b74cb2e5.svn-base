// ########file = SortingLineTask.cs#############
// ########author = "祝旻" ##############
// ########created = 20140728#############
using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using AppUtility;
using BusinessLogic.Common;
using BusinessLogic.SortingProcess;
using Csla;
using Csla.Data;
using IBM.Data.DB2;
using MySql.Data.MySqlClient;

namespace BusinessLogic.SortingTask
{

    [Serializable]
    public class AbnSortingLineTask : BusinessBase<AbnSortingLineTask>
    {
        #region  Business Methods

        private static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(p => p.ID, "标识号");

        private static readonly PropertyInfo<int> SORTINGTASKNOProperty = RegisterProperty<int>(p => p.SORTINGTASKNO,
                                                                                                "主任务编号");

        private static readonly PropertyInfo<string> ORDERDATEProperty = RegisterProperty<string>(p => p.ORDERDATE,
                                                                                                  "订单日期");

        private static readonly PropertyInfo<string> PICKLINECODEProperty = RegisterProperty<string>(
            p => p.PICKLINECODE, "分拣线编号");

        private static readonly PropertyInfo<string> PICKLINENAMEProperty = RegisterProperty<string>(
            p => p.PICKLINENAME, "分拣线名称");

        private static readonly PropertyInfo<string> CUSTCODEProperty = RegisterProperty<string>(p => p.CUSTCODE, "客户编号");

        private static readonly PropertyInfo<string> CUSTNAMEProperty = RegisterProperty<string>(p => p.CUSTNAME, "客户姓名");

        private static readonly PropertyInfo<int> INDEXNOProperty = RegisterProperty<int>(p => p.INDEXNO, "流水号");

        private static readonly PropertyInfo<string> OUTPORTProperty = RegisterProperty<string>(p => p.OUTPORT, "出烟口");

        private static readonly PropertyInfo<int> StatusProperty = RegisterProperty<int>(p => p.Status, "订单任务的状态");

        private static readonly PropertyInfo<string> shortnameProperty = RegisterProperty<string>(p => p.shortname, "简称");

        private static readonly PropertyInfo<DateTime> SortingTimeProperty =
            RegisterProperty<DateTime>(p => p.SortingTime, "分拣任务下达时间");

        private static readonly PropertyInfo<DateTime> FinishTimeProperty =
            RegisterProperty<DateTime>(p => p.FinishTime, "分拣完成时间");


        private static readonly PropertyInfo<AbnSortingLineTaskDetails> SortingLineTaskDetailsProperty =
            RegisterProperty<AbnSortingLineTaskDetails>(p => p.SortingLineTaskDetails, "订单明细列表");

        public string ID
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        public int SORTINGTASKNO
        {
            get { return GetProperty(SORTINGTASKNOProperty); }
            set { SetProperty(SORTINGTASKNOProperty, value); }
        }

        public string ORDERDATE
        {
            get { return GetProperty(ORDERDATEProperty); }
            set { SetProperty(ORDERDATEProperty, value); }
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

        public string CUSTCODE
        {
            get { return GetProperty(CUSTCODEProperty); }
            set { SetProperty(CUSTCODEProperty, value); }
        }

        public string CUSTNAME
        {
            get { return GetProperty(CUSTNAMEProperty); }
            set { SetProperty(CUSTNAMEProperty, value); }
        }

        public Int32 INDEXNO
        {
            get { return GetProperty(INDEXNOProperty); }
            set { SetProperty(INDEXNOProperty, value); }
        }

        public string OUTPORT
        {
            get { return GetProperty(OUTPORTProperty); }
            set { SetProperty(OUTPORTProperty, value); }
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

        public string shortname
        {
            get { return GetProperty(shortnameProperty); }
            set { SetProperty(shortnameProperty, value); }
        }

        public AbnSortingLineTaskDetails SortingLineTaskDetails
        {
            get { return GetProperty(SortingLineTaskDetailsProperty); }
            set { SetProperty(SortingLineTaskDetailsProperty, value); }
        }

        #endregion

        #region  Factory Methods

        private AbnSortingLineTask()
        {
            /* require use of factory methods */
        }

        public static AbnSortingLineTask GetAbnSortingLineTask(SafeDataReader dr)
        {
            return DataPortal.Fetch<AbnSortingLineTask>(dr);
        }

        public static AbnSortingLineTask GetAbnSortingLineTask()
        {
            return DataPortal.Fetch<AbnSortingLineTask>();
        }

        public static AbnSortingLineTask GetAbnSortingLineByIndex(string index)
        {
            return DataPortal.Fetch<AbnSortingLineTask>(index);
        }

        public static AbnSortingLineTask GetMaxAbnSortingLineTask()
        {
            return DataPortal.Fetch<AbnSortingLineTask>();
        }

        public void SaveAbnSortingTaskProcess(int status)
        {
            AbnSortingTaskProgress abnSortingTaskProgress;

            abnSortingTaskProgress = AbnSortingTaskProgress.GetAbnSortingTaskProgress(ID);
            abnSortingTaskProgress.STATUS = status;
            if (status == 0)
            {
                abnSortingTaskProgress.SORTINGTIME = null;
                abnSortingTaskProgress.FINISHTIME = null;
            }
            if (status == 1)
            {
                abnSortingTaskProgress.SORTINGTIME = DateTime.Now;
                abnSortingTaskProgress.FINISHTIME = null;
            }
            if (status == 2)
            {
                abnSortingTaskProgress.SORTINGTIME = DateTime.Now;
                abnSortingTaskProgress.FINISHTIME = DateTime.Now;
            }
            abnSortingTaskProgress.Save();

            //重汇分拣进度
            try
            {
                Thread thread = new Thread(new ParameterizedThreadStart(SortingProcessList.GetSortingProcessList));
                thread.Start(SortingLine.GetAbNonSortingLineCode());
            }
            catch (Exception)
            {
            }
            //else
            //{
            //    abnSortingTaskProgress = AbnSortingTaskProgress.GetAbnSortingTaskProgress(ID);
            //    abnSortingTaskProgress.SORTINGTIME = DateTime.Now;
            //    abnSortingTaskProgress.FINISHTIME = DateTime.Now;
            //    abnSortingTaskProgress.STATUS = Status;
            //}

        }

        /// <summary>
        /// 合计分拣任务中的订单总量
        /// </summary>
        /// <returns></returns>
        public int SumOrderNumber()
        {
            int ordernumber = 0;
            foreach (var sortingLineTaskDetail in SortingLineTaskDetails)
            {
                ordernumber += sortingLineTaskDetail.QTY;
            }
            return ordernumber;
        }

        public static string GetSortingLineTaskDate()
        {
            string sortingdate = "";
            string taskno = "";
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "select * from T_SORTING_LINE_TASK_ABNORMAL limit 1";
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            taskno = dr.GetString("SORTINGTASKNO");
                            sortingdate = dr.GetString("ORDERDATE") + ":" + taskno;
                        }
                    }
                }

            }
            return sortingdate;
        }


        public static string GetServerSortingLineTaskDate()
        {
            string sortingdate = "";
            string taskno = "";
            using (var cn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "select * from t_sorting_line_task s JOIN t_sortingline sl ON s.PICKLINECODE = sl.lineCode WHERE sl.linetype= '2'  order by orderdate desc fetch first 1 row only";
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            taskno = dr.GetString("TASKNO");
                            sortingdate = dr.GetString("ORDERDATE") + ":" + taskno;
                        }
                    }
                }

            }
            return sortingdate;
        }


        #endregion

        #region  Data Access

        private void DataPortal_Fetch(SafeDataReader dr)
        {
            LoadProperty(IdProperty, dr.GetString("ID"));
            LoadProperty(SORTINGTASKNOProperty, dr.GetString("SORTINGTASKNO"));
            LoadProperty(ORDERDATEProperty, dr.GetString("ORDERDATE"));
            LoadProperty(PICKLINECODEProperty, dr.GetString("PICKLINECODE"));
            LoadProperty(PICKLINENAMEProperty, dr.GetString("PICKLINENAME"));
            LoadProperty(CUSTCODEProperty, dr.GetString("CUSTCODE"));
            LoadProperty(CUSTNAMEProperty, dr.GetString("CUSTNAME"));
            LoadProperty(INDEXNOProperty, dr.GetInt32("INDEXNO"));
            LoadProperty(OUTPORTProperty, dr.GetString("OUTPORT"));
            LoadProperty(StatusProperty, dr.GetInt32("Status"));
            LoadProperty(SortingTimeProperty, dr.GetDateTime("SortingTime"));
            LoadProperty(FinishTimeProperty, dr.GetDateTime("FinishTime"));
            LoadProperty(shortnameProperty, dr.GetString("shortname"));
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
                            "SELECT * FROM T_SORTING_LINE_TASK_ABNORMAL t  WHERE t.status = 0 order by t.indexno limit 1";
                        //cm.Parameters.AddWithValue("@id", criteria.Value);
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                LoadProperty(IdProperty, dr.GetString("ID"));
                                LoadProperty(SORTINGTASKNOProperty, dr.GetString("SORTINGTASKNO"));
                                LoadProperty(ORDERDATEProperty, dr.GetString("ORDERDATE"));
                                LoadProperty(PICKLINECODEProperty, dr.GetString("PICKLINECODE"));
                                LoadProperty(PICKLINENAMEProperty, dr.GetString("PICKLINENAME"));
                                LoadProperty(CUSTCODEProperty, dr.GetString("CUSTCODE"));
                                LoadProperty(CUSTNAMEProperty, dr.GetString("CUSTNAME"));
                                LoadProperty(INDEXNOProperty, dr.GetInt32("INDEXNO"));
                                LoadProperty(OUTPORTProperty, dr.GetString("OUTPORT"));
                                LoadProperty(StatusProperty, dr.GetInt32("Status"));
                                LoadProperty(SortingTimeProperty, dr.GetDateTime("SortingTime"));
                                LoadProperty(FinishTimeProperty, dr.GetDateTime("FinishTime"));
                            }


                        }
                    }

                    // load child objects
                    using (var cmProducts = cn.CreateCommand())
                    {
                        cmProducts.CommandText =
                            "SELECT * FROM T_SORTING_LINE_DETAIL_TASK_ABNORMAL tl WHERE tl.taskid =  @id and ";
                        cmProducts.Parameters.AddWithValue("@id", ID);
                        using (var drTaskDetails = new SafeDataReader(cmProducts.ExecuteReader()))
                        {
                            LoadProperty(SortingLineTaskDetailsProperty,
                                         AbnSortingLineTaskDetails.GetAbnSortingLineTaskDetails(drTaskDetails));
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
                            "SELECT * FROM T_SORTING_LINE_TASK_ABNORMAL t  WHERE t.indexno = @plctaskno limit 1";
                        cm.Parameters.AddWithValue("@plctaskno", Convert.ToInt32(plctaskno));
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                LoadProperty(IdProperty, dr.GetString("ID"));
                                LoadProperty(SORTINGTASKNOProperty, dr.GetString("SORTINGTASKNO"));
                                LoadProperty(ORDERDATEProperty, dr.GetString("ORDERDATE"));
                                LoadProperty(PICKLINECODEProperty, dr.GetString("PICKLINECODE"));
                                LoadProperty(PICKLINENAMEProperty, dr.GetString("PICKLINENAME"));
                                LoadProperty(CUSTCODEProperty, dr.GetString("CUSTCODE"));
                                LoadProperty(CUSTNAMEProperty, dr.GetString("CUSTNAME"));
                                LoadProperty(INDEXNOProperty, dr.GetInt32("INDEXNO"));
                                LoadProperty(OUTPORTProperty, dr.GetString("OUTPORT"));
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

       

        public static bool IsCurrentOrder()
        {
            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT COUNT(1) FROM (SELECT  MAX(T_SORTING_LINE_TASK_ABNORMAL.ORDERDATE ) da FROM T_SORTING_LINE_TASK_ABNORMAL)  t WHERE t.da = @Date";
                    cm.Parameters.AddWithValue("@Date", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                    if (int.Parse(cm.ExecuteScalar().ToString()) <= 0)
                    {
                        MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                        monitorLog.LOGNAME = "数据库读取";
                        monitorLog.LOGINFO = "当前异型烟订单日期与系统日期不符合!";
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
                        "SELECT SEQUENCENO,COUNT(1)  FROM T_INTASK_ABNORMAL  GROUP BY SEQUENCENO HAVING count(1)> 1";
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                            monitorLog.LOGNAME = "数据库读取";
                            monitorLog.LOGINFO = "当前异型烟补货任务存在重复的顺序号!";
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
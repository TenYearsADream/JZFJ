// ########file = InTaskIssued.cs#############
// ########author = "祝旻" ##############
// ########created = 20140728#############

using System;
using System.Text;
using AppUtility;
using BusinessLogic;
using BusinessLogic.INTASKS;
using BusinessLogic.SortingTask;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace HDWLogic.Issued
{
    [Serializable]
    public class InTaskIssued : BusinessBase<InTaskIssued>
    {
        #region  Business Methods

        private InTask m_inTask;

        private static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(p => p.ID, "标识号");

        private static readonly PropertyInfo<int> PLCFLAGProperty = RegisterProperty<int>(p => p.PLCFLAG,
                                                                                                "PLC的写入标志位，0可写入，1任务写入完成");

        private static readonly PropertyInfo<string> PLCTASKNOProperty = RegisterProperty<string>(p => p.PLCTASKNO,
                                                                                                  "任务号不能为0");

        private static readonly PropertyInfo<string> SLOCATIONProperty = RegisterProperty<string>(
            p => p.SLOCATION, "目的地址，对应出口数字编号1-20");


        private static readonly PropertyInfo<string> CIGCODEProperty = RegisterProperty<string>(
            p => p.CIGCODE, "卷烟代码");


        private static readonly PropertyInfo<string> BARCODEProperty = RegisterProperty<string>(
            p => p.BARCODE, "卷烟件码");

        private static readonly PropertyInfo<int> INQTYProperty = RegisterProperty<int>(
            p => p.INQTY, "补货卷烟的数量");


        

        

        public string ID
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        public int PLCFLAG
        {
            get { return GetProperty(PLCFLAGProperty); }
            set { SetProperty(PLCFLAGProperty, value); }
        }

        public string PLCTASKNO
        {
            get { return GetProperty(PLCTASKNOProperty); }
            set { SetProperty(PLCTASKNOProperty, value); }
        }

        public string SLOCATION
        {
            get { return GetProperty(SLOCATIONProperty); }
            set { SetProperty(SLOCATIONProperty, value); }
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




        public int INQTY
        {
            get { return GetProperty(INQTYProperty); }
            set { SetProperty(INQTYProperty, value); }
        }



        public void Reset()
        {
            PLCFLAG = 0;
            PLCTASKNO = "0";
            SLOCATION = "0";
            CIGCODE = "0";
            BARCODE = "0";
            INQTY = 0;
        }


        #endregion

        #region  Factory Methods

        private InTaskIssued()
        {
            /* require use of factory methods */
        }

        public static InTaskIssued NewInTaskIssued()
        {
            return DataPortal.Create<InTaskIssued>();
        }

        public static InTaskIssued GetInTaskIssued(string ID)
        {
            return DataPortal.Fetch<InTaskIssued>(new SingleCriteria<InTaskIssued, string>(ID));
        }


        public static InTaskIssued GetInTaskIssued(SafeDataReader dr)
        {
            return DataPortal.Fetch<InTaskIssued>(dr);
        }


        

        

        #endregion

        #region  Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            //m_inTask = InTask.GetInTask();
            using (BypassPropertyChecks)
            {
                LoadProperty(IdProperty, m_inTask.INDEXNO);
                LoadProperty(PLCFLAGProperty, 1);
                LoadProperty(PLCTASKNOProperty, InTaskIssuedList.GetInTaskIssuedList().LoadLastPLCTaskID());
                LoadProperty(SLOCATIONProperty, "DB0");
                LoadProperty(INQTYProperty, m_inTask.INQTY);
                LoadProperty(CIGCODEProperty,m_inTask.CIGCODE);
                LoadProperty(BARCODEProperty,m_inTask.BARCODE);

            }
        }


        private void DataPortal_Fetch(SafeDataReader dr)
        {
            LoadProperty(IdProperty, dr.GetString("ID"));
            LoadProperty(PLCFLAGProperty, dr.GetString("PLCFLAG"));
            LoadProperty(PLCTASKNOProperty, dr.GetString("PLCTASKNO"));
            LoadProperty(SLOCATIONProperty, dr.GetString("SLOCATION"));
            LoadProperty(INQTYProperty, dr.GetInt32("INQTY"));
            LoadProperty(CIGCODEProperty, dr.GetString("CIGCODE"));
            LoadProperty(BARCODEProperty, dr.GetString("BARCODE"));
        }

        /// <summary>
        /// 通过PLC中到达信号的地址号获取其中的任务信息
        /// </summary>
        /// <param name="slocationcode"></param>
        private void DataPortal_Fetch(string slocationcode)
        {
            //读取下达任务的任务信息
            
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Insert()
        {
            //PLC写入下达任务

            //throw new Exception("写入下达任务");


            using (BypassPropertyChecks)
            {
                using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var tran = cn.BeginTransaction())
                    {
                        try
                        {
                            using (var cm = cn.CreateCommand())
                            {

                                StringBuilder SQL = new StringBuilder();
SQL.Append("INSERT ");
SQL.Append("   INTO T_InTaskIssued ");
SQL.Append("        ( ");
SQL.Append("            ID,PLCFLAG,PLCTASKNO,SLOCATION,CIGCODE,BARCODE,INQTY ");
SQL.Append("        ) ");
SQL.Append("        VALUES ");
SQL.Append("        ( ");
SQL.Append("            @ID,@PLCFLAG,@PLCTASKNO,@SLOCATION,@CIGCODE,@BARCODE,@INQTY ");
                                SQL.Append("        )");
                                cm.CommandText = SQL.ToString();
                                cm.Parameters.AddWithValue("@ID", ID);
                                cm.Parameters.AddWithValue("@PLCFLAG", PLCFLAG);
                                cm.Parameters.AddWithValue("@PLCTASKNO", PLCTASKNO);
                                cm.Parameters.AddWithValue("@SLOCATION", SLOCATION);
                                cm.Parameters.AddWithValue("@CIGCODE", CIGCODE);
                                cm.Parameters.AddWithValue("@BARCODE", BARCODE);
                                cm.Parameters.AddWithValue("@INQTY", INQTY);
                                cm.ExecuteNonQuery();
                            }

                            

                            MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                            monitorLog.LOGNAME = "PLC补货任务下达";
                            monitorLog.LOGINFO = "PLCTASKNO:" + PLCTASKNO.PadRight(10);
                           
                            monitorLog.LOGINFO +=  CIGCODE + ":" +
                                                      BARCODE + ":" +
                                                      INQTY + "  ";
                            
                            monitorLog.LOGLOCATION = "PLC";
                            monitorLog.LOGTYPE = 0;
                            monitorLog.Save();
                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
        }


        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Update()
        {
            //PLC写入下达任务

            //throw new Exception("写入下达任务");


            using (BypassPropertyChecks)
            {
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
                                SQL.Append("UPDATE T_InTaskIssued ");
                                SQL.Append("    SET ID = @ID,PLCFLAG = @PLCFLAG,PLCTASKNO = @PLCTASKNO,SLOCATION = @SLOCATION,CIGCODE = @CIGCODE,BARCODE = @BARCODE,INQTY = @INQTY ");
                                SQL.Append("  WHERE ID = @ID");
                                cm.CommandText = SQL.ToString();
                                cm.Parameters.AddWithValue("@ID", ID);
                                cm.Parameters.AddWithValue("@PLCFLAG", PLCFLAG);
                                
                                cm.Parameters.AddWithValue("@PLCTASKNO", PLCTASKNO);
                                cm.Parameters.AddWithValue("@SLOCATION", SLOCATION);
                                cm.Parameters.AddWithValue("@CIGCODE", CIGCODE);
                                cm.Parameters.AddWithValue("@BARCODE", BARCODE);
                                cm.Parameters.AddWithValue("@INQTY", INQTY);
                                cm.ExecuteNonQuery();
                            }
                            tran.Commit();
                           
                            if (PLCTASKNO != "0" && SLOCATION != "0" && INQTY != 0)
                            {
                                m_inTask = InTask.GetInTaskByIndex(PLCTASKNO);
                                if (m_inTask != null)
                                {
                                    m_inTask.Status = 2;
                                    m_inTask.SaveInTaskProcess(PLCTASKNO);
                                }
                                MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                                monitorLog.LOGNAME = "PLC任务下达";
                                monitorLog.LOGINFO = "PLCTASKNO:" + PLCTASKNO.PadRight(10);
                                monitorLog.LOGINFO += CIGCODE + ":" +
                                                      BARCODE + ":" +
                                                      INQTY + "  ";
                                monitorLog.LOGLOCATION = "PLC";
                                monitorLog.LOGTYPE = 0;
                                monitorLog.Save();
                            }
                            //else
                            //{
                            //    m_sortingLineTask = SortingLineTask.GetSortingLineByIndex(PLCTASKNO);
                            //    if (m_sortingLineTask != null)
                            //    {
                            //        m_sortingLineTask.Status = 2;
                            //        m_sortingLineTask.SaveSortingTaskProcess(PLCTASKNO);
                            //    }
                            //}
                            
                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
        }

        #endregion

        
    }
}
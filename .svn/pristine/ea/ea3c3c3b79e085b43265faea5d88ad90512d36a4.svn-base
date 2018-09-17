// ########file = SortingTaskIssuedDetail.cs#############
// ########author = "祝旻" ##############
// ########created = 20140728#############

using System;
using System.Data.SqlClient;
using System.Text;
using BusinessLogic.SortingTask;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace HDWLogic.Issued
{
    [Serializable]
    public class SortingTaskIssuedDetail : BusinessBase<SortingTaskIssuedDetail>
    {
        #region  Business Methods

        private static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(p => p.ID, "标识号");

        private static readonly PropertyInfo<string> LINEBOXCODEProperty = RegisterProperty<string>(p => p.LINEBOXCODE,
                                                                                                  "烟仓编号");

        private static readonly PropertyInfo<string> ADDRESSCODEProperty = RegisterProperty<string>(
            p => p.ADDRESSCODE, "烟仓地址码");


        private static readonly PropertyInfo<int> QTYProperty = RegisterProperty<int>(p => p.QTY, "卷烟数量");


        public string ID
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }


        public string LINEBOXCODE
        {
            get { return GetProperty(LINEBOXCODEProperty); }
            set { SetProperty(LINEBOXCODEProperty, value); }
        }

        public string ADDRESSCODE
        {
            get { return GetProperty(ADDRESSCODEProperty); }
            set { SetProperty(ADDRESSCODEProperty, value); }
        }



        public Int32 QTY
        {
            get { return GetProperty(QTYProperty); }
            set { SetProperty(QTYProperty, value); }
        }


        #endregion

        #region  Business Rules

        protected override void AddBusinessRules()
        {
        }

        #endregion

        #region  Authorization Rules

        protected void AddAuthorizationRules()
        {
        }

        #endregion

        #region  Factory Methods

        private SortingTaskIssuedDetail()
        {
        }

        public static SortingTaskIssuedDetail NewSortingTaskIssuedDetail(SortingLineTaskDetail sortingLineTaskDetail)
        {
            return DataPortal.CreateChild<SortingTaskIssuedDetail>(sortingLineTaskDetail);
        }

        internal static SortingTaskIssuedDetail GetSortingTaskIssuedDetail()
        {
            return DataPortal.FetchChild<SortingTaskIssuedDetail>();
        }

        internal static SortingTaskIssuedDetail GetSortingTaskIssuedDetail(SafeDataReader dr)
        {
            return DataPortal.FetchChild<SortingTaskIssuedDetail>(dr);
        }


        public  void Save(SortingTaskIssued sortingTaskIssued,MySqlTransaction cn)
        {
            DataPortal.UpdateChild(this, new object[] {sortingTaskIssued, cn});
        }

        #endregion

        #region  Data Access

        private void Child_Create(SortingLineTaskDetail sortingLineTaskDetail)
        {
            LoadProperty(IdProperty, Guid.NewGuid().ToString());
            LoadProperty(LINEBOXCODEProperty,sortingLineTaskDetail.LINEBOXCODE);
            LoadProperty(ADDRESSCODEProperty, sortingLineTaskDetail.ADDRESSCODE);
            LoadProperty(QTYProperty, sortingLineTaskDetail.QTY);
        }

        private void Child_Fetch()
        {
            //LoadProperty(IdProperty, dr.GetInt32("ID"));
            //LoadProperty(LINEBOXCODEProperty, dr.GetString("LINEBOXCODE"));
            //LoadProperty(ADDRESSCODEProperty, dr.GetString("ADDRESSCODE"));
            //LoadProperty(QTYProperty, dr.GetInt32("QTY"));

            //对应从PLC中读取下达任务代码
            throw new Exception("对应从PLC中读取下达任务代码");
        }


        private void Child_Fetch(SafeDataReader dr)
        {
            try
            {
                LoadProperty(IdProperty, dr.GetString("ID"));
                LoadProperty(LINEBOXCODEProperty, dr.GetString("LINEBOXCODE"));
                LoadProperty(ADDRESSCODEProperty, dr.GetString("ADDRESSCODE"));
                LoadProperty(QTYProperty, dr.GetInt32("QTY"));
            }
            catch (Exception)
            {
                
                
            }
            
        }



        private void Child_Insert(SortingTaskIssued sortingTaskIssued, MySqlTransaction tran)
        {
            using (BypassPropertyChecks)
            {
                using (var cm = tran.Connection.CreateCommand())
                {
                    cm.Transaction = tran;
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("INSERT ");
                    SQL.Append("   INTO T_SORTINGTASKISSUEDDETAIL ");
                    SQL.Append("        ( ");
                    SQL.Append("            ID,TASKID,LINEBOXCODE,ADDRESSCODE,QTY ");
                    SQL.Append("        ) ");
                    SQL.Append("        VALUES ");
                    SQL.Append("        ( ");
                    SQL.Append("            @ID,@TASKID,@LINEBOXCODE,@ADDRESSCODE,@QTY ");
                    SQL.Append("        )");
                    cm.CommandText = SQL.ToString();

                    cm.Parameters.AddWithValue("@ID", ID);
                    cm.Parameters.AddWithValue("@TASKID", sortingTaskIssued.ID);
                    cm.Parameters.AddWithValue("@LINEBOXCODE", LINEBOXCODE);
                    cm.Parameters.AddWithValue("@ADDRESSCODE", ADDRESSCODE);
                    cm.Parameters.AddWithValue("@QTY", QTY);
                    cm.ExecuteNonQuery();
                }
            }
        }


        private void Child_Update(SortingTaskIssued sortingTaskIssued,MySqlConnection cn)
        {
            using (BypassPropertyChecks)
            {
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("INSERT ");
                    SQL.Append("   INTO T_SORTINGTASKISSUEDDETAIL ");
                    SQL.Append("        ( ");
                    SQL.Append("            ID,TASKID,LINEBOXCODE,ADDRESSCODE,QTY ");
                    SQL.Append("        ) ");
                    SQL.Append("        VALUES ");
                    SQL.Append("        ( ");
                    SQL.Append("            @ID,@TASKID,@LINEBOXCODE,@ADDRESSCODE,@QTY ");
                    SQL.Append("        )");
                    cm.CommandText = SQL.ToString();

                    cm.Parameters.AddWithValue("@ID", ID);
                    cm.Parameters.AddWithValue("@TASKID", "");
                    cm.Parameters.AddWithValue("@LINEBOXCODE", LINEBOXCODE);
                    cm.Parameters.AddWithValue("@ADDRESSCODE", ADDRESSCODE);
                    cm.Parameters.AddWithValue("@QTY", QTY);
                    cm.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}
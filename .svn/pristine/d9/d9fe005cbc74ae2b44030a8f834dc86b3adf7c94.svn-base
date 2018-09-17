// ########file = SortingLineTask.cs#############
// ########author = "祝旻" ##############
// ########created = 20140728#############

using System;
using System.Collections.Generic;
using System.Threading;
using AppUtility;
using BusinessLogic.Box;
using BusinessLogic.Common;
using BusinessLogic.SortingProcess;
using BusinessLogic.SortingTask;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.DisplayBoards
{

    [Serializable]
    public class DynamicBoxTask : BusinessBase<DynamicBoxTask>
    {
        #region  Business Methods

        private static readonly PropertyInfo<string> IDProperty = RegisterProperty<string>(p => p.Id, "ID");

        private static readonly PropertyInfo<string> BoxNameProperty = RegisterProperty<string>(p => p.BoxName, "烟仓名称");

        private static readonly PropertyInfo<string> BoxCodeProperty = RegisterProperty<string>(p => p.BoxCode, "烟仓编号");

        
        private static readonly PropertyInfo<string> CUSTCODEProperty = RegisterProperty<string>(p => p.CUSTCODE, "客户编号");

        private static readonly PropertyInfo<string> CUSTNAMEProperty = RegisterProperty<string>(p => p.CUSTNAME, "客户姓名");

        private static readonly PropertyInfo<int> INDEXNOProperty = RegisterProperty<int>(p => p.INDEXNO, "流水号");

        private static readonly PropertyInfo<string> CigNameProperty = RegisterProperty<string>(p => p.CigName, "卷烟名称");

        private static readonly PropertyInfo<int> InQtyProperty = RegisterProperty<int>(p => p.InQty, "数量");


        public string Id
        {
            get { return GetProperty(IDProperty); }
            set { SetProperty(IDProperty, value); }
        }

        public string BoxName
        {
            get { return GetProperty(BoxNameProperty); }
            set { SetProperty(BoxNameProperty, value); }
        }

        public string BoxCode
        {
            get { return GetProperty(BoxCodeProperty); }
            set { SetProperty(BoxCodeProperty, value); }
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


        public string CigName
        {
            get { return GetProperty(CigNameProperty); }
            set { SetProperty(CigNameProperty, value); }
        }

        public Int32 InQty
        {
            get { return GetProperty(InQtyProperty); }
            set { SetProperty(InQtyProperty, value); }
        }

        public void SaveIn()
        {
            using (BypassPropertyChecks)
            {
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (MySqlTransaction tran = cn.BeginTransaction())
                    {
                        try
                        {
                            using (var cm = cn.CreateCommand())
                            {
                                cm.Transaction = tran;
                                cm.CommandText =
                                    "update t_sorting_line_detail_task set isin = @status where id = @id";
                                cm.Parameters.AddWithValue("@status", 1);
                                cm.Parameters.AddWithValue("@id", this.Id);

                                cm.ExecuteNonQuery();
                            }
                            tran.Commit();
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

        #region  Factory Methods

        private DynamicBoxTask()
        {
            /* require use of factory methods */
        }

        public static DynamicBoxTask GetDynamicBoxTask(SafeDataReader dr)
        {
            return DataPortal.Fetch<DynamicBoxTask>(dr);
        }

        


        #endregion

        #region  Data Access

        private void DataPortal_Fetch(SafeDataReader dr)
        {
            LoadProperty(IDProperty, dr.GetString("id"));
            LoadProperty(BoxNameProperty, dr.GetString("BoxName"));
            LoadProperty(BoxCodeProperty, dr.GetString("LineBoxCode"));
            LoadProperty(CUSTNAMEProperty, dr.GetString("shortname"));
            LoadProperty(INDEXNOProperty, dr.GetInt32("INDEXNO"));
            LoadProperty(CigNameProperty, dr.GetString("CigName"));
           
            LoadProperty(InQtyProperty, dr.GetInt32("InQty"));
           
        }

      

        #endregion

       
    }
}
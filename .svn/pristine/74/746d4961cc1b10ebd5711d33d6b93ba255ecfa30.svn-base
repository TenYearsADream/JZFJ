// ########file = SortingLineTaskDetails.cs#############
// ########author = "祝旻" ##############
// ########created = 20140728#############
using System;
using System.Collections.Generic;
using System.Linq;
using AppUtility;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.SortingTask
{
    [Serializable]
    public class AbnSortingLineTaskDetails : BusinessListBase<AbnSortingLineTaskDetails, AbnSortingLineTaskDetail>
    {
        #region  Business Methods

        public AbnSortingLineTaskDetail GetAbnSortingLineTaskDetail(string productId)
        {
            return Enumerable.FirstOrDefault(this, item => item.ID == productId);
        }

        public bool Contains(string productId)
        {
            return Enumerable.Any(this, item => item.ID == productId);
        }
        public static AbnSortingLineTaskDetails GetGetSortingLineTaskDetailsByTaskId(string taskid)
        {
            return DataPortal.FetchChild<AbnSortingLineTaskDetails>(taskid);
        }
        #endregion

        #region  Factory Methods

        private AbnSortingLineTaskDetails()
        {
            /* require use of factory methods */
        }

        internal static AbnSortingLineTaskDetails GetAbnSortingLineTaskDetails(SafeDataReader dr)
        {
            return DataPortal.FetchChild<AbnSortingLineTaskDetails>(dr); ;
        }

        #endregion

        #region  Data Access

        private void Child_Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            while (dr.Read())
                Add(AbnSortingLineTaskDetail.GetAbnSortingLineTaskDetail(dr));
            RaiseListChangedEvents = true;
        }

        private void Child_Fetch(string taskid)
        {
            RaiseListChangedEvents = false;

            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT * FROM t_sorting_line_detail_task_abnormal where taskid = '" + taskid + "' order by cigcode";
                    cm.Parameters.AddWithValue("@taskid", taskid);
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            Add(AbnSortingLineTaskDetail.GetAbnSortingLineTaskDetail(dr));
                    }


                }
            }
            RaiseListChangedEvents = true;

        }

        #endregion
    }
}
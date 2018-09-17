// ########file = SortingLineTaskDetailsHistory.cs#############
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
    public class SortingLineTaskDetailsHistory : BusinessListBase<SortingLineTaskDetailsHistory, SortingLineTaskDetail>
    {
        #region  Business Methods

        public SortingLineTaskDetail GetSortingLineTaskDetail(string productId)
        {
            return Enumerable.FirstOrDefault(this, item => item.ID == productId);
        }

        public bool Contains(string productId)
        {
            return Enumerable.Any(this, item => item.ID == productId);
        }

        #endregion

        #region  Factory Methods

        private SortingLineTaskDetailsHistory()
        {
            /* require use of factory methods */
        }

        internal static SortingLineTaskDetailsHistory GetSortingLineTaskDetailsHistory(SafeDataReader dr)
        {
            return DataPortal.FetchChild<SortingLineTaskDetailsHistory>(dr);
            ;
        }

        public static SortingLineTaskDetailsHistory GetSortingLineTaskDetailsHistoryByTaskId(string taskid)
        {
            return DataPortal.FetchChild<SortingLineTaskDetailsHistory>(taskid);
        }

        

        #endregion

        #region  Data Access

        private void Child_Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            while (dr.Read())
                Add(SortingLineTaskDetail.GetSortingLineTaskDetail(dr));
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
                        "SELECT * FROM t_sorting_line_detail_task_history where taskid = '" + taskid + "' order by addresscode";
                    cm.Parameters.AddWithValue("@taskid", taskid);
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            Add(SortingLineTaskDetail.GetSortingLineTaskDetail(dr));
                    }


                }
            }
            RaiseListChangedEvents = true;

        }
    #endregion
    }
}
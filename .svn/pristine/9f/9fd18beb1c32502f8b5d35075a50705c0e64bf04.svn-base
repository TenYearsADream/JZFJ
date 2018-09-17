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
    public class SortingLineTaskDetails : BusinessListBase<SortingLineTaskDetails, SortingLineTaskDetail>
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

        public int GetTotQty()
        {
            int totqyt = 0;
            foreach (SortingLineTaskDetail sortingLineTaskDetail in this)
            {
                totqyt += sortingLineTaskDetail.QTY;
            }
            return totqyt;
        }

        public IEnumerable<SortingLineTaskDetail> GetAreaDetails(string areaid)
        {
            List<SortingLineTaskDetail> sortingLineTaskDetails = new List<SortingLineTaskDetail>();
            foreach (SortingLineTaskDetail sortingLineTaskDetail in this)
            {
                if (sortingLineTaskDetail.SUBLINECODE == areaid)
                {
                    sortingLineTaskDetails.Add(sortingLineTaskDetail);
                }
            }
            return sortingLineTaskDetails;
            //sublinec去掉100
            //return Enumerable.Where(this, item => item.SUBLINECODE.Replace("100","") == areaid);
        }

        public IEnumerable<SortingLineTaskDetail> GetLessAreaDetails(string areaid)
        {
            return Enumerable.Where(this, item => item.SUBLINECODE == areaid);
        }



        #endregion

        #region  Factory Methods

        private SortingLineTaskDetails()
        {
            /* require use of factory methods */
        }

        internal static SortingLineTaskDetails GetSortingLineTaskDetails(SafeDataReader dr)
        {
            return DataPortal.FetchChild<SortingLineTaskDetails>(dr);
            ;
        }

        public static SortingLineTaskDetails GetSortingLineTaskDetailsByTaskId(string taskid)
        {
            return DataPortal.FetchChild<SortingLineTaskDetails>(taskid);
        }

        public static SortingLineTaskDetails GetSortingLineTaskDetailsByIndex(int indexno)
        {
            return DataPortal.FetchChild<SortingLineTaskDetails>(indexno);
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
                        "SELECT * FROM T_SORTING_LINE_DETAIL_TASK where taskid = '" + taskid + "' order by LINEBOXNAME";
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

        private void Child_Fetch(int index)
        {
            RaiseListChangedEvents = false;

            using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "SELECT * FROM t_sorting_line_task s JOIN t_sorting_line_detail_task sd on s.ID = sd.TASKID WHERE s.INDEXNO = @index order by sd.lineboxname";
                    cm.Parameters.AddWithValue("@index", index);
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
// ########file = SortingTaskIssuedDetails.cs#############
// ########author = "祝旻" ##############
// ########created = 20140728#############

using System;
using System.Data.SqlClient;
using System.Linq;
using BusinessLogic.SortingTask;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace HDWLogic.Issued
{
    [Serializable]
    public class SortingTaskIssuedDetails : BusinessListBase<SortingTaskIssuedDetails, SortingTaskIssuedDetail>
    {
        #region  Business Methods

        public SortingTaskIssuedDetail GetSortingTaskIssuedDetail(string taskid)
        {
            return Enumerable.FirstOrDefault(this, item => item.ID == taskid);
        }

        public bool Contains(string taskid)
        {
            return Enumerable.Any(this, item => item.ID == taskid);
        }

        public void RemoveAll()
        {
            for (int i = this.Count-1; i >=0 ; i--)
            {
                this.RemoveAt(i);
            }
        }

        #endregion

        #region  Factory Methods

        private SortingTaskIssuedDetails()
        {
            /* require use of factory methods */
        }

        internal static SortingTaskIssuedDetails NewSortingTaskIssuedDetails(SortingLineTaskDetails sortingLineTaskDetails)
        {
            return DataPortal.CreateChild<SortingTaskIssuedDetails>(sortingLineTaskDetails);
        }

        internal static SortingTaskIssuedDetails GetSortingTaskIssuedDetails()
        {
            return DataPortal.FetchChild<SortingTaskIssuedDetails>();
        }

        internal static SortingTaskIssuedDetails GetSortingTaskIssuedDetails(SafeDataReader dr)
        {
            return DataPortal.FetchChild<SortingTaskIssuedDetails>(dr);
        }

        

        #endregion

        #region  Data Access

        private void Child_Create(SortingLineTaskDetails sortingLineTaskDetails)
        {
            RaiseListChangedEvents = false;
            foreach (var sortingLineTaskDetail in sortingLineTaskDetails)
                Add(SortingTaskIssuedDetail.NewSortingTaskIssuedDetail(sortingLineTaskDetail));
            RaiseListChangedEvents = true;
        }

        private void Child_Fetch()
        {
            RaiseListChangedEvents = false;
                Add(SortingTaskIssuedDetail.GetSortingTaskIssuedDetail());
            RaiseListChangedEvents = true;
        }


        private void Child_Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
                Add(SortingTaskIssuedDetail.GetSortingTaskIssuedDetail(dr));
            RaiseListChangedEvents = true;
        }


        protected  void Child_Update(SortingTaskIssued sortingTaskIssued,MySqlTransaction tran)
        {
            foreach (SortingTaskIssuedDetail sortingTaskIssuedDetail in this)
            {
                sortingTaskIssuedDetail.Save(sortingTaskIssued, tran);
            }
        }


        //private void Child_Insert(SortingTaskIssued sortingTaskIssued, SqlTransaction tran)
        //{
        //}

        #endregion
    }
}
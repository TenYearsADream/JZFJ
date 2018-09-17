// -----------------------------------------------------------------------
// <copyright file="SortingTaskArrives.cs"
//     project="BusinessLogic"
//     solution="PurchaseSalesInventory"
//     company="武汉科尔创新软件技术有限公司">
//     Copyright (c) KEERTECH. All rights reserved.
// </copyright>
// <author>TuB</author>
// <created>2012-02-24</created>
// <summary></summary>
// -----------------------------------------------------------------------

using System;
using BusinessLogic.Configuration;
using Csla;
using MySql.Data.MySqlClient;

namespace BusinessLogic.arrive
{
    /// <summary>
    /// 标识系统设置的集合类
    /// </summary>
    [Serializable]
    public class SortingTaskArrives : BusinessListBase<SortingTaskArrives, SortingTaskArrive>
    {
        #region  Business Methods

        /// <summary>
        /// Remove a SortingTaskArrive based on the SortingTaskArrive's id value.
        /// </summary>
        /// <param name="id">Id value of the SortingTaskArrive to remove.</param>
        public void Remove(string id)
        {
            foreach (var item in this)
                if (item.Id.Contains(id))
                {
                    Remove(item);
                    break;
                }
        }

        /// <summary>
        /// Get a SortingTaskArrive bsaed on its id value.
        /// </summary>
        /// <param name="id">Id value of the SortingTaskArrive to return.</param>
        public SortingTaskArrive GeSortingTaskArriveById(string id)
        {
            foreach (var item in this)
                if (item.Id == id)
                    return item;
            return null;
        }

        public SortingTaskArrive GetSortingTaskArriveByName(string outportCODE)
        {
            foreach (var item in this)
                if (item.OutportCODE == outportCODE)
                    return item;
            return null;
        }

        protected override object AddNewCore()
        {
            var item = SortingTaskArrive.NewSortingTaskArrive();
            Add(item);
            return item;
        }

        #endregion

        #region  Authorization Rules

        protected static void AddObjectAuthorizationRules()
        {
            // add object-level authorization rules here
        }

        #endregion

        #region  Factory Methods

        public static SortingTaskArrives GetSortingTaskArrives()
        {
            return DataPortal.Fetch<SortingTaskArrives>();
        }

        private SortingTaskArrives()
        {
            Saved += SortingTaskArrives_Saved;
            AllowNew = true;
        }

        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            Saved += SortingTaskArrives_Saved;
        }

        #endregion

        #region  Data Access

        private void SortingTaskArrives_Saved(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client and invalidates the SortingTaskArriveList cache
            //SortingTaskArriveList.InvalidateCache();
        }

        protected override void DataPortal_OnDataPortalInvokeComplete(DataPortalEventArgs e)
        {
            if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server &&
                e.Operation == DataPortalOperations.Update)
            {
                // this runs on the server and invalidates the UserList cache
                //SortingTaskArriveList.InvalidateCache();
            }
        }

        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "select * from t_SortingTaskArrive";

                    using (var dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            Add(SortingTaskArrive.GetSortingTaskArrive("0"));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        Child_Update(new[] { tran });
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        #endregion
    }
}
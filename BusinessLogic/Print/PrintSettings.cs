// -----------------------------------------------------------------------
// <copyright file="Settings.cs"
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

namespace BusinessLogic.Print
{
    /// <summary>
    /// 标识系统设置的集合类
    /// </summary>
    [Serializable]
    public class PrintSettings : BusinessListBase<PrintSettings, PrintSetting>
    {
        #region  Business Methods

        /// <summary>
        /// Remove a setting based on the setting's id value.
        /// </summary>
        /// <param name="id">Id value of the setting to remove.</param>
        public void Remove(string id)
        {
            foreach (var item in this)
                if (item.Id == id)
                {
                    Remove(item);
                    break;
                }
        }

        /// <summary>
        /// Get a setting bsaed on its id value.
        /// </summary>
        /// <param name="id">Id value of the setting to return.</param>
        public PrintSetting GetSettingById(string id)
        {
            foreach (var item in this)
                if (item.Id == id)
                    return item;
            return null;
        }

        

        protected override object AddNewCore()
        {
            var item = PrintSetting.NewSetting();
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

        public static PrintSettings GetSettings()
        {
            return DataPortal.Fetch<PrintSettings>();
        }

        private PrintSettings()
        {
            //Saved += Settings_Saved;
            AllowNew = true;
        }

        

        #endregion

        #region  Data Access

        //private void Settings_Saved(object sender, Csla.Core.SavedEventArgs e)
        //{
        //    // this runs on the client and invalidates the SettingList cache
        //    SettingList.InvalidateCache();
        //}

        //protected override void DataPortal_OnDataPortalInvokeComplete(DataPortalEventArgs e)
        //{
        //    if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server &&
        //        e.Operation == DataPortalOperations.Update)
        //    {
        //        // this runs on the server and invalidates the UserList cache
        //        SettingList.InvalidateCache();
        //    }
        //}

        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "select * from t_printsetting";

                    using (var dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            Add(PrintSetting.GetSetting(dr));
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
                        Child_Update(new[] { cn });
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
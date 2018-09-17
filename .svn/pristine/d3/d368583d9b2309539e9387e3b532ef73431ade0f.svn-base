// -----------------------------------------------------------------------
// <copyright file="MessageList.cs"
//     project="BusinessLogic"
//     solution="PurchaseSalesInventory"
//     company="武汉科尔创新软件技术有限公司">
//     Copyright (c) KEERTECH. All rights reserved.
// </copyright>
// <author>TuB</author>
// <created>2012-03-30</created>
// <summary></summary>
// -----------------------------------------------------------------------

using System;
using System.Data.SqlClient;
using AppUtility;
using BusinessLogic.SortingTask;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace HDWLogic.Issued
{
    /// <summary>
    /// 表示一个只读的消息列表
    /// </summary>
    [Serializable]
    public class InTaskIssuedList : ReadOnlyListBase<InTaskIssuedList, InTaskIssued>
    {
        #region  Factory Methods

        /// <summary>
        /// Get a setting bsaed on its id value.
        /// </summary>
        /// <param name="id">Id value of the setting to return.</param>
        public InTaskIssued GetSortingTaskIssuedById(string id)
        {
            foreach (var item in this)
                if (item.ID == id)
                    return item;
            return null;
        }

        public int LoadLastPLCTaskID()
        {
            int maxtaskid = 1;
            foreach (var item in this)
            {
                if (Int32.Parse(item.PLCTASKNO) > maxtaskid)
                    maxtaskid = Int32.Parse(item.PLCTASKNO);
            }
            return maxtaskid;
        }

        public static InTaskIssuedList GetInTaskIssuedList()
        {
            return DataPortal.Fetch<InTaskIssuedList>();
        }

        
        private InTaskIssuedList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void DataPortal_Fetch()
        {
            
                using (var cn = new MySqlConnection(AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText =
                            "SELECT  * FROM T_INTASKISSUED";
                        //cm.Parameters.AddWithValue("@id", criteria.Value);
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                IsReadOnly = false;
                                InTaskIssued inTaskIssued
                                 = InTaskIssued.GetInTaskIssued(dr);
                                Add(inTaskIssued);
                                IsReadOnly = true;
                            }
                        }
                    }

                    
                }
            
        }


        

        #endregion


        
    }
}
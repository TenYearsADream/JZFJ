using System;
using System.Text;
using AppUtility;
using BusinessLogic.Box;
using Csla;
using Csla.Data;
using IBM.Data.DB2;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <author></author>
    /// <remarks>2011/3/3 9:46</remarks>
    [Serializable]
    public class CigInfoList : ReadOnlyListBase<CigInfoList,CigInfo>
    {
        #region  Business Methods

        #endregion

        #region  Factory Methods

        private static CigInfoList _list;


        /// <summary>
        /// 获取未完成烟包列表
        /// </summary>
        public static CigInfoList GetCigList()
        {
            return DataPortal.Fetch<CigInfoList>();
            
        }

        /// <summary>
        /// 获取未完成烟包列表
        /// </summary>
        public static CigInfoList GetCigList(string ciginfo)
        {
            return DataPortal.Fetch<CigInfoList>(ciginfo);

        }

        /// <summary>
        /// 通过卷烟代码获取卷烟
        /// </summary>
        public CigInfo GetListByCode(string cigaretteno)
        {
            foreach (var item in this)
                if (item.CIGARETTENO == cigaretteno)
                    return item;
            return null;
        }




        
       
        public static void InvalidateCache()
        {
            _list = null;
        }

        private CigInfoList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            using (var cn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();

                    SQL.Append("SELECT c.CIGARETTENO,c.CIGARETTENAME,c.BARCODE,(case when b.boxCode is null then 9999 else b.boxcode*1 end) boxCODE ,b.boxName FROM t_ciginfo c LEFT JOIN (SELECT * from t_linebox b ) b  on c.CIGARETTENO = b.bindCig where c.ISSEIZURE = 0 ORDER BY boxCODE");
                    cm.CommandText = SQL.ToString();
                    //cm.Parameters.AddWithValue("@ciginfo",ciginfo);
                    
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            var info = new CigInfo(dr);
                            // apply filter if necessary
                            this.Add(info);
                        }
                        IsReadOnly = true;
                    }
                }
            }
            RaiseListChangedEvents = true;
        }


        private void DataPortal_Fetch(string ciginfo)
        {
            RaiseListChangedEvents = false;
            using (var cn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();

                    SQL.Append("SELECT c.CIGARETTENO,c.CIGARETTENAME,c.BARCODE,(case when b.boxCode is null then 9999 else b.boxcode*1 end) boxCODE ,b.boxName FROM t_ciginfo c LEFT JOIN (SELECT * from t_linebox b) b  on c.CIGARETTENO = b.bindCig where c.ISSEIZURE = 0 and (c.CIGARETTENO like '%" + ciginfo + "%' or c.CIGARETTENAME like '%" + ciginfo + "%') ORDER BY boxCODE");
                    cm.CommandText = SQL.ToString();
                    //cm.Parameters.AddWithValue("@ciginfo",ciginfo);

                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            var info = new CigInfo(dr);
                            // apply filter if necessary
                            this.Add(info);
                        }
                        IsReadOnly = true;
                    }
                }
            }
            RaiseListChangedEvents = true;
        }
        #endregion
    }

    
}

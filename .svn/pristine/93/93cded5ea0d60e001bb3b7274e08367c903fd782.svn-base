using System;
using Csla;
using MySql.Data.MySqlClient;
using Csla.Data;

namespace BusinessLogic.PlcDataSettings
{
    /// <summary>
    /// 
    /// </summary>
    /// <author></author>
    /// <remarks>2011/3/3 9:46</remarks>
    [Serializable]
    public class PLCDataInfoList : ReadOnlyListBase<PLCDataInfoList, PLCDataInfo>
    {
        #region  Business Methods

        #endregion

        #region  Factory Methods

        private static PLCDataInfoList _list;

        
        public static PLCDataInfoList GetList()
        {
            if (_list == null)
                _list = DataPortal.Fetch<PLCDataInfoList>();
            return _list;
        }

        public PLCDataInfo GetListByTypeCode(string Typecode)
        {
            foreach (var item in this)
                if (item.TYPECODE == Typecode)
                    return item;
            return null;
        }

       
        public static void InvalidateCache()
        {
            _list = null;
        }

        private PLCDataInfoList()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "select * from T_PLCDATA_SETTING";
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            var info = new PLCDataInfo(dr);
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

using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.SortingProcess
{
    public class SortingProcessInfo
    {
        public string SORTINGTASKNO { get; set; }
        public string ORDERDATE { get; set; }
        public string PICKLINECODE { get; set; }
        public string PICKLINENAME { get; set; }
        public int QTY_PRODCUT_TOT { get; set; }
        public int QTY_ROUTE_TOT { get; set; }
        public int QTY_CUSTOMER_TOT { get; set; }
        public int QTY_PRODUCT { get; set; }
        public int QTY_ROUTE { get; set; }
        public int QTY_CUSTOMER { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string CUSTOMER_DESC { get; set; }
        public string ROUTE_CODE { get; set; }
        public string ROUTE_NAME { get; set; }
        public double EFFICIENCY { get; set; }
        public DateTime RECEIVE_TIME { get; set; }
        public double Progress { get; set; }



        public bool IsExist()
        {
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select count(1) from T_SORTLINE_PROCESS where SORTINGTASKNO = '" + SORTINGTASKNO + "' and ORDERDATE = '" + ORDERDATE + "' and PICKLINECODE = '" + PICKLINECODE + "'";
                    return Convert.ToBoolean(cm.ExecuteScalar());
                }
            }
        }
    }
}

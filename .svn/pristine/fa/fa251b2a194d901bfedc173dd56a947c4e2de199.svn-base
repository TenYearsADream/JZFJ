using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.materials
{
    public class Materials
    {
	    public string ID { get; set; }
        public string orderDate { get; set; }
        public int sequenceNo { get; set; }
        public string sortingTaskNo { get; set; }
        public int status { get; set; }
	    public string statusname
	    {
		    get
		    {
			    if (status == 1)
			    {
				    return "已完成";
			    }
                return "未完成";
		    }
	    }

	    public MaterialsDetailList materialsDetailList;

        public void SaveMaterialsStatus()
        {
            
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("update t_materialsdetail set status = 1 where id = '" + ID + "'");

                    cm.CommandText = SQL.ToString();
	                cm.ExecuteNonQuery();
                }

            }
	        this.status = 1;
        }
    }
}

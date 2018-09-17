using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.materials
{
    public class MaterialsList : List<Materials>
    {

        public static MaterialsList GetMaterialsList()
        {
            MaterialsList materialsList = new MaterialsList();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("select m.* from t_materialsdetail m join t_sortingline l on m.lineId = l.ID AND l.LINECODE = '1001' ORDER BY m.sequenceNo");

                    cm.CommandText = SQL.ToString();
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {

                            Materials materials = new Materials();
	                        materials.ID = dr.GetString("ID");
                            materials.orderDate = dr.GetDateTime("orderDate").ToShortDateString();
                            materials.sequenceNo = dr.GetInt16("sequenceNo");
                            materials.sortingTaskNo = dr.GetString("TaskNo");
                            materials.status = dr.GetInt32("status");
                            materialsList.Add(materials);
                        }
                    }
                }
            }
            return materialsList;
        }

	    

	    
    }
}

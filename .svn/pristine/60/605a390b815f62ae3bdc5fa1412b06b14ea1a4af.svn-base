using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Common;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.materials
{
    public class MaterialsDetailList:List<MaterialsDetial>
    {

        public static MaterialsDetailList GetMaterialsDetailList(string Materialsid)
        {
            MaterialsDetailList materialsDetailList = new MaterialsDetailList();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("select *  from t_materialsdetail_detail d JOIN t_ciginfo sd ON d.cigInfoId = sd.CIGARETTENO where materialsDetailId = @Materialsid");
	                cm.Parameters.AddWithValue("@Materialsid", Materialsid);
                    cm.CommandText = SQL.ToString();
	                int rownum = 1;
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            MaterialsDetial materialsDetial = new MaterialsDetial();
                            materialsDetial.rownum = rownum++;
                            materialsDetial.materialsDetailId = dr.GetString("materialsDetailId");
                            materialsDetial.pickNum = dr.GetInt16("pickNum");
                            materialsDetial.qty = dr.GetInt32("qty");
                            materialsDetial.tQty = dr.GetInt32("tQty");
                            materialsDetial.cigInfoId = dr.GetString("cigInfoId");
                            materialsDetial.cigname = dr.GetString("CIGARETTENAME");
                            if (materialsDetial.cigname.Contains("("))
                            {

                                materialsDetial.cigname = materialsDetial.cigname.Insert(materialsDetial.cigname.IndexOf('('), Environment.NewLine);
	                            
                            }
                            materialsDetailList.Add(materialsDetial);
                        }
                    }
                }
            }
            return materialsDetailList;
        }
    }
}

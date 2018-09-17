using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.materials
{
	public class MaterialsDetial
    {
        public int rownum { get; set; }
		public int pickNum { get; set; }
        public int qty { get; set; }
        public int tQty { get; set; }
        public string cigInfoId { get; set; }
        public string cigname { get; set; }
        public string materialsDetailId { get; set; }
		public int sortingNum { get; set; }

        public static MaterialsDetial GetMaterialsDetialGroupBy(string Materialsid)
        {
            
            MaterialsDetial materialsDetail = new MaterialsDetial();
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    StringBuilder SQL = new StringBuilder();
                    SQL.Append("SELECT SUM(pickNum) picknum,SUM(qty) qty,SUM(tQty) tqty FROM `t_materialsdetail_detail` where materialsDetailId = @Materialsid");
	                cm.Parameters.AddWithValue("@Materialsid", Materialsid);
                    cm.CommandText = SQL.ToString();
	                int rownum = 1;
                    using (var dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            materialsDetail.cigname = "总合计";
                            materialsDetail.pickNum = dr.GetInt16("pickNum");
                            materialsDetail.qty = dr.GetInt32("qty");
                            materialsDetail.tQty = dr.GetInt32("tQty");
                        }
                    }
                }
            }
            return materialsDetail;
        }
        }
    }

   


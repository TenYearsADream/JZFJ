using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Test
{
    public class CreateTest
    {
        public void CreateTMTest(string cigcode,string barcode,string cigname,int maxNum)
        {
           

                int indexno = 1;
                int currentNum = 0;
                int plcaddress = 1;
            int boxcode = 67;
            
                using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (MySqlTransaction tran = cn.BeginTransaction())
                    {
                        using (var cm = cn.CreateCommand())
                        {
                            cm.Transaction = tran;

                            while (currentNum < maxNum)
                            {
                                cm.CommandText = "select * from T_INTASK ORDER BY SEQUENCENO DESC LIMIT 1 ";
                                try
                                {

	                                using (var dr = new SafeDataReader(cm.ExecuteReader()))
	                                {
		                                while (dr.Read())
		                                {
			                                indexno = dr.GetInt32("sequenceno");
			                                indexno++;

			                                plcaddress = dr.GetInt32("PLCADDRESS");
			                                plcaddress++;
			                                if (plcaddress > 30)
			                                {
				                                plcaddress = 1;

			                                }

			                                boxcode = dr.GetInt32("lineboxcode");
			                                boxcode++;
			                                if (boxcode > 70)
			                                {
				                                boxcode = 67;
			                                }
		                                }
	                                }

                                }
                                catch (InvalidCastException invalidCastException)
                                {
                                }

                                for (int lineboxcode = boxcode; lineboxcode <= 70; lineboxcode++)
                                {
                                    StringBuilder SQL = new StringBuilder();
                                    SQL.Append(
                                        "INSERT INTO `t_intask` (`id`, `intaskno`, `orderdate`, `cigcode`, `sequenceno`, `linecode`, `linename`, `sublinecode`, `inportcode`, `lineboxcode`, `lineboxname`, `addresscode`, `type`, `inqty`, `barCode`, `cigName`,PLCADDRESS) VALUES (@id, @intaskno, @orderdate, @cigcode, @sequenceno, @linecode, @linename, @sublinecode, @inportcode, @lineboxcode, @lineboxname, @addresscode, @type, @inqty, @barCode, @cigName,@PLCADDRESS)");

                                    cm.CommandText = SQL.ToString();
                                    cm.Parameters.Clear();
                                    cm.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                                    cm.Parameters.AddWithValue("@intaskno", "1");
                                    cm.Parameters.AddWithValue("@orderdate", DateTime.Now.ToString("yyyy-MM-dd"));
                                    cm.Parameters.AddWithValue("@cigcode", cigcode);
                                    cm.Parameters.AddWithValue("@sequenceno", indexno++);
                                    cm.Parameters.AddWithValue("@linecode", "1001");
                                    cm.Parameters.AddWithValue("@linename", "常规分拣线");
                                    cm.Parameters.AddWithValue("@sublinecode", "1001");
                                    cm.Parameters.AddWithValue("@inportcode", "1");
                                    cm.Parameters.AddWithValue("@lineboxcode", lineboxcode);
                                    cm.Parameters.AddWithValue("@lineboxname", "W" + lineboxcode);
                                    cm.Parameters.AddWithValue("@addresscode", lineboxcode);
                                    cm.Parameters.AddWithValue("@type", 0);
                                    cm.Parameters.AddWithValue("@inqty", 50);
                                    cm.Parameters.AddWithValue("@barCode", barcode);
                                    cm.Parameters.AddWithValue("@cigName", cigname);
                                    cm.Parameters.AddWithValue("@PLCADDRESS", plcaddress);
                                    cm.ExecuteNonQuery();
                                    currentNum += 50;

                                    plcaddress++;
                                    if (plcaddress > 30)
                                    {
                                        plcaddress = 1;

                                    }
                                }

                            }


                            indexno = 1;
                            currentNum = 0;
                            boxcode = 67;
                            long custcode = 422000000000;
                            int Aplcaddress = 1;


                            while (currentNum < maxNum)
                            {

                                cm.CommandText = "select * from t_sorting_line_task order by indexno desc limit 1";
	                            using (var dr = new SafeDataReader(cm.ExecuteReader()))
	                            {
		                            while (dr.Read())
		                            {
			                            indexno = dr.GetInt32("indexno");
			                            indexno++;

			                            Aplcaddress = dr.GetInt32("PLCADDRESS");
			                            Aplcaddress++;
			                            if (Aplcaddress > 20)
			                            {
				                            Aplcaddress = 1;
			                            }
		                            }
	                            }


                                StringBuilder SQL = new StringBuilder();

                                SQL = new StringBuilder();
                                SQL.Append("INSERT ");
                                SQL.Append("   INTO t_sorting_line_task ");
                                SQL.Append("        ( ");
                                SQL.Append(
                                    "            ID,SORTINGTASKNO,ORDERDATE,PICKLINECODE,PICKLINENAME,CUSTCODE,CUSTNAME,INDEXNO,OUTPORT,PLCADDRESS,LINECODE,LINENAME,CORPCODE,CORPNAME,shortname ");
                                SQL.Append("        ) ");
                                SQL.Append("        VALUES ");
                                SQL.Append("        ( ");
                                SQL.Append(
                                    "            @ID,@SORTINGTASKNO,@ORDERDATE,@PICKLINECODE,@PICKLINENAME,@CUSTCODE,@CUSTNAME,@INDEXNO,@OUTPORT,@PLCADDRESS,@LINECODE,@LINENAME,@CORPCODE,@CORPNAME,@shortname ");
                                SQL.Append("        )");
                                cm.CommandText = SQL.ToString();
                                cm.Parameters.Clear();
                                string id = Guid.NewGuid().ToString();
                                cm.Parameters.AddWithValue("@ID", id);
                                cm.Parameters.AddWithValue("@SORTINGTASKNO", "1");
                                cm.Parameters.AddWithValue("@PICKLINECODE", "1001");
                                cm.Parameters.AddWithValue("@ORDERDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                                cm.Parameters.AddWithValue("@PICKLINENAME", "常规分拣线");
                                cm.Parameters.AddWithValue("@CUSTCODE", custcode ++);
                                cm.Parameters.AddWithValue("@CUSTNAME", "通码客户" + indexno);
                                cm.Parameters.AddWithValue("@INDEXNO", indexno);
                                cm.Parameters.AddWithValue("@OUTPORT", "1");

                                //出口1分配地址1-20号
                                cm.Parameters.AddWithValue("@PLCADDRESS", Aplcaddress++);

                                cm.Parameters.AddWithValue("@LINECODE", "11422801020");
                                cm.Parameters.AddWithValue("@LINENAME", "恩施熊家岩");
                                cm.Parameters.AddWithValue("@CORPCODE", "11422801135");
                                cm.Parameters.AddWithValue("@CORPNAME", "(恩施)恩施");
                                cm.Parameters.AddWithValue("@shortname", "通码客户" + indexno);
                                cm.ExecuteNonQuery();
                                indexno ++;
                                Aplcaddress++;
                                if (Aplcaddress > 20)
                                {
                                    Aplcaddress = 1;
                                }


                                for (int lineboxcode = 67; lineboxcode <= 70; lineboxcode++)
                                {
                                    SQL = new StringBuilder();
                                    SQL.Append("INSERT ");
                                    SQL.Append("   INTO t_sorting_line_detail_task ");
                                    SQL.Append("        ( ");
                                    SQL.Append(
                                        "            ID,TASKID,SUBLINECODE,SUBLINENAME,LINEBOXCODE,LINEBOXNAME,ADDRESSCODE,CIGCODE,CIGNAME,QTY ");
                                    SQL.Append("        ) ");
                                    SQL.Append("        VALUES ");
                                    SQL.Append("        ( ");
                                    SQL.Append(
                                        "            @ID,@TASKID,@SUBLINECODE,@SUBLINENAME,@LINEBOXCODE,@LINEBOXNAME,@ADDRESSCODE,@CIGCODE,@CIGNAME,@QTY ");
                                    SQL.Append("        )");
                                    cm.CommandText = SQL.ToString();
                                    cm.Parameters.Clear();
                                    cm.Parameters.AddWithValue("@ID", Guid.NewGuid().ToString());
                                    cm.Parameters.AddWithValue("@TASKID", id);
                                    cm.Parameters.AddWithValue("@SUBLINECODE", "1001");
                                    cm.Parameters.AddWithValue("@SUBLINENAME", "卧式子线1");
                                    cm.Parameters.AddWithValue("@LINEBOXCODE", lineboxcode);
                                    cm.Parameters.AddWithValue("@LINEBOXNAME", "W" + lineboxcode);
                                    cm.Parameters.AddWithValue("@ADDRESSCODE", lineboxcode);
                                    cm.Parameters.AddWithValue("@CIGCODE", cigcode);
                                    cm.Parameters.AddWithValue("@CIGNAME", cigname);
                                    cm.Parameters.AddWithValue("@QTY", 50);
                                    cm.ExecuteNonQuery();
                                    currentNum +=50;
                                }

                            }

                        }
                        tran.Commit();
                    }
                }
            
        }



        public void CreateLSTMTest(string cigcode, string barcode, string cigname, int maxNum)
        {


            int indexno = 1;
            int currentNum = 0;
            int plcaddress = 1;

           

            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (MySqlTransaction tran = cn.BeginTransaction())
                {
                    using (var cm = cn.CreateCommand())
                    {
                        cm.Transaction = tran;

                        
                            indexno = 1;
                            currentNum = 0;
                            //boxcode = 67;
                            long custcode = 422000000000;
                            int Aplcaddress = 1;


                        while (currentNum < maxNum)
                        {

                            cm.CommandText = "select * from t_sorting_line_task order by indexno desc limit 1";
                            using (var dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    indexno = dr.GetInt32("indexno");
                                    indexno++;

                                    Aplcaddress = dr.GetInt32("PLCADDRESS");
                                    Aplcaddress++;
                                    if (Aplcaddress > 20)
                                    {
                                        Aplcaddress = 1;
                                    }
                                }
                            }


                            StringBuilder SQL = new StringBuilder();

                            SQL = new StringBuilder();
                            SQL.Append("INSERT ");
                            SQL.Append("   INTO t_sorting_line_task ");
                            SQL.Append("        ( ");
                            SQL.Append(
                                "            ID,SORTINGTASKNO,ORDERDATE,PICKLINECODE,PICKLINENAME,CUSTCODE,CUSTNAME,INDEXNO,OUTPORT,PLCADDRESS,LINECODE,LINENAME,CORPCODE,CORPNAME,shortname ");
                            SQL.Append("        ) ");
                            SQL.Append("        VALUES ");
                            SQL.Append("        ( ");
                            SQL.Append(
                                "            @ID,@SORTINGTASKNO,@ORDERDATE,@PICKLINECODE,@PICKLINENAME,@CUSTCODE,@CUSTNAME,@INDEXNO,@OUTPORT,@PLCADDRESS,@LINECODE,@LINENAME,@CORPCODE,@CORPNAME,@shortname ");
                            SQL.Append("        )");
                            cm.CommandText = SQL.ToString();
                            cm.Parameters.Clear();
                            string id = Guid.NewGuid().ToString();
                            cm.Parameters.AddWithValue("@ID", id);
                            cm.Parameters.AddWithValue("@SORTINGTASKNO", "1");
                            cm.Parameters.AddWithValue("@PICKLINECODE", "1001");
                            cm.Parameters.AddWithValue("@ORDERDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                            cm.Parameters.AddWithValue("@PICKLINENAME", "常规分拣线");
                            cm.Parameters.AddWithValue("@CUSTCODE", custcode++);
                            cm.Parameters.AddWithValue("@CUSTNAME", "通码客户" + indexno);
                            cm.Parameters.AddWithValue("@INDEXNO", indexno);

                            if (Aplcaddress % 2 == 1)
                            {
                                cm.Parameters.AddWithValue("@OUTPORT", "1");    
                            }
                            else
                            {
                                cm.Parameters.AddWithValue("@OUTPORT", "2");
                            }
                            

                            //出口1分配地址1-20号
                            cm.Parameters.AddWithValue("@PLCADDRESS", Aplcaddress++);

                            cm.Parameters.AddWithValue("@LINECODE", "11422801020");
                            cm.Parameters.AddWithValue("@LINENAME", "荆州直送1-周一");
                            cm.Parameters.AddWithValue("@CORPCODE", "11422801135");
                            cm.Parameters.AddWithValue("@CORPNAME", "(荆州)城区");
                            cm.Parameters.AddWithValue("@shortname", "通码客户" + indexno);
                            cm.ExecuteNonQuery();
                            indexno++;
                            Aplcaddress++;
                            if (Aplcaddress > 20)
                            {
                                Aplcaddress = 1;
                            }


                            for (int lineboxcode = 1; lineboxcode <= 66; lineboxcode++)
                            {
                                SQL = new StringBuilder();
                                SQL.Append("INSERT ");
                                SQL.Append("   INTO t_sorting_line_detail_task ");
                                SQL.Append("        ( ");
                                SQL.Append(
                                    "            ID,TASKID,SUBLINECODE,SUBLINENAME,LINEBOXCODE,LINEBOXNAME,ADDRESSCODE,CIGCODE,CIGNAME,QTY ");
                                SQL.Append("        ) ");
                                SQL.Append("        VALUES ");
                                SQL.Append("        ( ");
                                SQL.Append(
                                    "            @ID,@TASKID,@SUBLINECODE,@SUBLINENAME,@LINEBOXCODE,@LINEBOXNAME,@ADDRESSCODE,@CIGCODE,@CIGNAME,@QTY ");
                                SQL.Append("        )");
                                cm.CommandText = SQL.ToString();
                                cm.Parameters.Clear();
                                cm.Parameters.AddWithValue("@ID", Guid.NewGuid().ToString());
                                cm.Parameters.AddWithValue("@TASKID", id);
                                cm.Parameters.AddWithValue("@SUBLINECODE", "1002");
                                cm.Parameters.AddWithValue("@SUBLINENAME", "立式子线1");
                                cm.Parameters.AddWithValue("@LINEBOXCODE", lineboxcode);
                                cm.Parameters.AddWithValue("@LINEBOXNAME", "W" + lineboxcode);
                                cm.Parameters.AddWithValue("@ADDRESSCODE", lineboxcode);
                                cm.Parameters.AddWithValue("@CIGCODE", cigcode);
                                cm.Parameters.AddWithValue("@CIGNAME", cigname);
                                cm.Parameters.AddWithValue("@QTY", 8);
                                cm.ExecuteNonQuery();
                                currentNum += 8;
                            }

                        }


                        tran.Commit();
                    }
                }

            }
        }


        public void DeleteTM()
        {
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (MySqlTransaction tran = cn.BeginTransaction())
                {
                    using (var cm = cn.CreateCommand())
                    {
                        cm.Transaction = tran;
                        cm.CommandText = "delete from t_sorting_line_task";
                        cm.ExecuteNonQuery();

                        cm.CommandText = "delete from t_sorting_line_detail_task";
                        cm.ExecuteNonQuery();

                        cm.CommandText = "delete from T_INTASK ";
                        cm.ExecuteNonQuery();

                        cm.CommandText = "delete from t_box ";
                        cm.ExecuteNonQuery();

                        tran.Commit();
                    }
                }
            }
        }
    }
}

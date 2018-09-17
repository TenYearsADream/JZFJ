using System.Collections.Generic;
using BusinessLogic.Configuration;
using IBM.Data.DB2;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Download
{
    public class SubSortingLineList : List<SubSortingLine>
    {
        public static SubSortingLineList GetSubSortingLines(bool isaddnull)
        {
            SubSortingLineList subSortingLineList = new SubSortingLineList();
            if (isaddnull)
            {
                subSortingLineList.Add(new SubSortingLine());
            }
            using (var cn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "select * from t_sortingsubline";

                    using (var dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            SubSortingLine subSortingLine = new SubSortingLine();
                            subSortingLine.ID = dr.GetString("sublineCode");
                            subSortingLine.Name = dr.GetString("sublineName");
                            subSortingLineList.Add(subSortingLine);
                        }
                    }
                }
            }
            return subSortingLineList;
        }
    }
}

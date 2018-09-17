using System.Collections.Generic;
using BusinessLogic.Configuration;
using IBM.Data.DB2;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Download
{
    public class SortingLineList:List<SortingLine>
    {
        public static SortingLineList GetSortingLines(bool isaddnull)
        {
            SortingLineList sortingLineList = new SortingLineList();
            if (isaddnull)
            {
                sortingLineList.Add(new SortingLine());
            }
            using (var cn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "select * from T_SORTINGLINE order by Linecode";

                    using (var dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            SortingLine sortingLine = new SortingLine();
                            sortingLine.ID = dr.GetString("LineCode");
                            sortingLine.Name = dr.GetString("LineName");
                            sortingLine.Type = dr.GetString("LineType");
                            sortingLineList.Add(sortingLine);
                        }
                    }
                }
            }
            return sortingLineList;
        }

        public static SortingLine GetSortingLineByCode(string code)
        {
            foreach (var sortingline in GetSortingLines(false))
            {
                if (sortingline.ID == code)
                {
                    return sortingline;
                }
            }
            return null;
        }
    }
}

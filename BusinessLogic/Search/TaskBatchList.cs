using System.Collections.Generic;
using BusinessLogic.Configuration;
using IBM.Data.DB2;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Download
{
    public class TaskBatchList : List<TaskBatch>
    {
        public static TaskBatchList GetTaskBatchs(string orderdate, bool isaddnull)
        {
            TaskBatchList taskBatchList = new TaskBatchList();
            if (isaddnull)
            {
                taskBatchList.Add(new TaskBatch());
            }
            using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "SELECT DISTINCT(sortingtaskno) FROM t_sorting_line_task_history tsp WHERE  tsp.orderDate = '" + orderdate + "'";

                    using (var dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            TaskBatch taskBatch = new TaskBatch();
                            taskBatch.ID = dr.GetString("sortingtaskno");
                            taskBatch.Name = dr.GetString("sortingtaskno");
                            taskBatchList.Add(taskBatch);
                        }
                    }
                }
            }
            return taskBatchList;
        }
    }

    public class TaskInfoList : List<TaskInfo>
    {
        public static TaskInfoList GetServerTaskBatchs(string orderdate, bool isaddnull)
        {
            TaskInfoList taskBatchList = new TaskInfoList();
            if (isaddnull)
            {
                taskBatchList.Add(new TaskInfo());
            }
            using (var cn = new DB2Connection(AppUtility.AppUtil._FjInfoConnectionString))
            {
                cn.Open();
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText = "select * from tsp_plan tsp join t_sortingline s on tsp.sortinglines = s.id WHERE  tsp.orderDate = '" + orderdate + "'";

                    using (var dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            TaskInfo taskInfo = new TaskInfo();
                            taskInfo.TaskNo = dr.GetString("taskno");
                            taskInfo.LineName = dr.GetString("linename");
                            taskInfo.LineCode = dr.GetString("linecode");
                            taskInfo.LineType = dr.GetString("linetype");
                            taskBatchList.Add(taskInfo);
                        }
                    }
                }
            }
            return taskBatchList;
        }
    }
}

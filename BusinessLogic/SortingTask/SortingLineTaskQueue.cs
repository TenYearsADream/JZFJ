using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AppUtility;
using BusinessLogic.Common;
using BusinessLogic.Download;
using HDWLogic;

namespace BusinessLogic.SortingTask
{
    /// <summary>
    /// 正在分拣的任务队列
    /// </summary>
    public class SortingLineTaskQueue
    {
        private static SortingLineTaskQueue _sortingLineTaskQueue;
        public static event EventHandler<EventArgs> OnUpdateCSortingMainCubeEvent;

        public static SortingLineTaskQueue GetInstance()
        {
            if (_sortingLineTaskQueue == null)
            {
                _sortingLineTaskQueue = new SortingLineTaskQueue();
            }
            return _sortingLineTaskQueue;
        }

        public SortingLineTaskQueue()
        {
            SortingSubLineList sortingSubLineList = SortingSubLineList.GetSubSortingLineList();
            QueueMaxCount = sortingSubLineList.Count ;
            SortingLineTasks = new SortingLineTask[QueueMaxCount+1];
        }

        /// <summary>
        /// 队列的最大容量取决于子线表中的当前分拣线子线个数
        /// </summary>
        public int QueueMaxCount { get; set; }

        /// <summary>
        /// 需要处理的订单数组，数量为QueueMaxCount+1
        /// </summary>
        public SortingLineTask[] SortingLineTasks { get; set; }

        /// <summary>
        /// 小车的数据模型列表，根据订单数组去初始化
        /// </summary>
        public List<CubeModel> CubesModel = new List<CubeModel>();

        /// <summary>
        /// 获取状态为已下达的任务，构建小车的列表数据
        /// </summary>
        /// <returns></returns>
        public void LoadSortingLineTasks()
        {
            SortingLineTasks = new SortingLineTask[QueueMaxCount + 1];
            SortingLineTaskList sortingLineTaskList = SortingLineTaskList.GetFinSortingLineTaskList(new QueryCondition("1", true, AppUtil._SortingLineId,"asc"));

            if (QueueMaxCount > 0)
            {
                //将获取到的任务按顺序进入分拣队列
                foreach (SortingLineTask sortingLineTask in sortingLineTaskList)
                {
                    SortingLineTasks[sortingLineTask.PLCADDRESS] = sortingLineTask;
                }
            }
            else
            {
                throw new Exception("分拣子线为0，无法建立数据！");
            }
        }

        /// <summary>
        /// 将任务对象加入到分拣队列
        /// </summary>
        /// <param name="sortingLineTask"></param>
        public void Enqueue(SortingLineTask sortingLineTask)
        {
            if (sortingLineTask != null && sortingLineTask.INDEXNO > 0)
            {
                //第0的位置总是空置这样与子线对应都从1开始
                SortingLineTasks[1] = sortingLineTask;
                SortingLineTasks[1].Status = 1;
                SortingLineTasks[1].PLCADDRESS = 1;
                SortingLineTasks[1].SaveSortingTaskProcess(SortingLineTasks[1].ID);
            }
            CreateCubesModel();
        }

        /// <summary>
        /// 让队列向前移动
        /// </summary>
        public void Move()
        {
            //所有队列向前移动
            for (int i = SortingLineTasks.Length - 1; i > 0; i--)
            {
                SortingLineTasks[i] = SortingLineTasks[i - 1];
            }

            for (int i = SortingLineTasks.Length - 1; i > 0; i--)
            {
                if (SortingLineTasks[i] != null && SortingLineTasks[i].INDEXNO > 0)
                {
                    SortingLineTasks[i].Status = 1;
                    SortingLineTasks[i].PLCADDRESS = i;
                    SortingLineTasks[i].SaveSortingTaskProcess(SortingLineTasks[i].ID);
                }
            }
            CreateCubesModel();
        }


        /// <summary>
        /// 根据子线的数量建立小车模型
        /// 将SortingLineTasks任务列表的数据填充到小车
        /// </summary>
        public void CreateCubesModel()
        {
            CubesModel.Clear();
            SortingSubLine[] sortingSubLineList = SortingSubLineList.GetSubSortingLineList().OrderBy(o => o.sequence).ToArray();

            //将分拣任务填充到小车中
            for (int i = 1; i < SortingLineTasks.Length; i++)
            {
                CubeModel cubeModel = new CubeModel();
                if (SortingLineTasks[i] != null)
                {
                    cubeModel.Customername = SortingLineTasks[i].ShortName;
                    cubeModel.Indexno = SortingLineTasks[i].INDEXNO;
                    cubeModel.TotSortingLineTaskDetails = SortingLineTasks[i].SortingLineTaskDetails;
                    cubeModel.FinSortingLineTaskDetails = SortingLineTasks[i].SortingLineTaskDetails.GetLessAreaDetails(sortingSubLineList[i-1].sublineCode);
                    cubeModel.TotCignum = SortingLineTasks[i].SumOrderNumber();
                    cubeModel.SortingLineTask = SortingLineTasks[i];
                    cubeModel.SubLineCode = sortingSubLineList[i - 1].sublineCode;
                    foreach (SortingLineTaskDetail finSortingLineTaskDetail in cubeModel.FinSortingLineTaskDetails)
                    {
                        cubeModel.FinCignum += finSortingLineTaskDetail.QTY;
                    }

                }
                //PLCADDRESS表示订单在小车模型中的位置，需要与界面中的CCube对应
                CubesModel.Add(cubeModel);
            }

            InvokeOnUpdateCubeEvent();
        }

        public void InvokeOnUpdateCubeEvent()
        {
            //更新前台小车控件的信息
            if (OnUpdateCSortingMainCubeEvent != null)
            {
                OnUpdateCSortingMainCubeEvent.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// 将队列移动到最前的任务设置为已完成
        /// </summary>
        public void SaveTaskFinish()
        {
            if (SortingLineTasks[QueueMaxCount] != null && SortingLineTasks[QueueMaxCount].INDEXNO > 0)
            {
                MonitorLog monitorLog = MonitorLog.NewMonitorLog();
                monitorLog.LOGNAME = "任务完成";
                monitorLog.LOGINFO = " 完成任务号" + SortingLineTasks[QueueMaxCount].INDEXNO;
                monitorLog.LOGLOCATION = "数据库";
                monitorLog.LOGTYPE = 0;
                monitorLog.Save();

                SortingLineTasks[QueueMaxCount].Status = 2;
                SortingLineTasks[QueueMaxCount].PLCADDRESS = QueueMaxCount + 1;
                SortingLineTasks[QueueMaxCount].SaveSortingTaskProcess(SortingLineTasks[QueueMaxCount].ID);
                
            }
        }

    }
}

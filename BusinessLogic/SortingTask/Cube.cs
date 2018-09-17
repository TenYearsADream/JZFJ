using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.SortingTask;

namespace HDWLogic
{
    public class CubeModel
    {
        /// <summary>
        /// 当前任务对应的子线区域编号
        /// </summary>
        public string SubLineCode;
        /// <summary>
        /// 分拣任务序号
        /// </summary>
        public int Indexno { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string Customername { get; set; }
        /// <summary>
        /// 未完成的卷烟数量
        /// </summary>
        public int NonCignum { get; set; }
        /// <summary>
        /// 已分拣完的卷烟数量
        /// </summary>
        public int FinCignum { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotCignum { get; set; }
        /// <summary>
        /// 已完成的分拣卷烟列表
        /// </summary>
        public IEnumerable<SortingLineTaskDetail> FinSortingLineTaskDetails { get; set; }
        /// <summary>
        /// 当前任务总分拣卷烟列表
        /// </summary>
        public IEnumerable<SortingLineTaskDetail> TotSortingLineTaskDetails { get; set; }
        /// <summary>
        /// 当前分拣任务对象
        /// </summary>
        public SortingLineTask SortingLineTask { get; set; }
    }
}

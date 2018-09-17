using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.SortingTask;

namespace BusinessLogic.Box
{
    public class SendBoxInfo
    {
        public string ID { get; private set; }
        /// <summary>
        /// 分拣批次
        /// </summary>
        public string SORTINGTASKNO { get; private set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public string ORDERDATE { get; private set; }
        /// <summary>
        /// 烟包代码
        /// </summary>
        public string BOXCODE { get; private set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        public string CUSTOMERNO { get; private set; }
        /// <summary>
        /// 客户名
        /// </summary>
        public string ShortName { get; private set; }
        /// <summary>
        /// 线路代码
        /// </summary>
        public string LINECODE { get; private set; }
        public string LINEID { get; private set; }
        /// <summary>
        /// 合计
        /// </summary>
        public int BOXCOUNT { get; private set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int BOXQTY { get; private set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int STATUS { get; private set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 配送区域名
        /// </summary>
        public string CorpName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime SORTINGTIME { get; private set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime FINISHTIME { get; private set; }
        /// <summary>
        /// 包序
        /// </summary>
        public int BOXSEQ { get; set; }
        /// <summary>
        /// 烟包所在客户的顺序
        /// </summary>
        public int IndexNO { get; set; }

        public string Address { get; set; }

        public int AbnoCount { get; set; }


        
    }
}

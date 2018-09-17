using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Common
{
    public class SortingLineBox
    {
        /// <summary>
        /// 烟道代码
        /// </summary>
        public string LineBoxCode { get; set; }
        /// <summary>
        /// 烟道名称
        /// </summary>
        public string LineBoxName { get; set; }
        /// <summary>
        /// 烟道在PLC地址位
        /// </summary>
        public string PlcAddress { get; set; }
        /// <summary>
        /// 卷烟代码
        /// </summary>
        public string Cigcode { get; set; }
        /// <summary>
        /// 卷烟名称
        /// </summary>
        public string CigName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int PutNum { get; set; }
        /// <summary>
        /// 分拣任务号
        /// </summary>
        public string SortingTaskNo { get; set; }

        public string sortinglinecode { get; set; }

        /// <summary>
        /// 区分货架式的单双通道
        /// </summary>
        public int shelfNum { get; set; }

        public string sublineId { get; set; }

        public string bindCig { get; set; }

        public int TOTQTY { get; set; }
        public int NONQTY { get; set; }
        public int FINQTY { get; set; }
        public int OUTQTY { get; set; }

        /// <summary>
        /// 烟仓所属的排数1、前排 2、后排
        /// </summary>
        public string PARENTLINEBOX { get;  set; }

        /// <summary>
        /// 层数 1层 2层
        /// </summary>
        public string ABANDONPARENT { get; set; }

        /// <summary>
        /// 子线ID
        /// </summary>
        public string SUBLINEID { get; set; }

        /// <summary>
        /// 烟道所处的子线顺序（用于标记烟道上界面上的位置）
        /// </summary>
        public int SublineSeq { get; set; }

        /// <summary>
        /// 是否混合仓
        /// </summary>
        public int IsDynamicbox { get; set; }

    }
}

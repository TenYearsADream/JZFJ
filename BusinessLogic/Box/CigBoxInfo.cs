using System;
using System.Text;
using Csla;
using Csla.Data;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Box
{
    
    [Serializable]
    public class CigBoxInfo : ReadOnlyBase<CigBoxInfo>
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
        public string CUSTOMERName { get; private set; }
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

        /// <summary>
        /// 保存烟包完成进度
        /// </summary>
        static public void SaveProcess(string boxuuid,int status)
        {
            BoxProgress boxProgress;
            boxProgress = BoxProgress.GetBoxProgress(boxuuid);
            if (status == 0)
            {
                
                boxProgress.STATUS = status;
                boxProgress.SORTINGTIME = null;
                boxProgress.FINISHTIME =null;
                boxProgress.Save();
            }
            if (status == 1)
            {
                boxProgress.STATUS = status;
                boxProgress.SORTINGTIME = DateTime.Now;
                boxProgress.FINISHTIME = null;
                boxProgress.Save();
            }
            if (status == 2)
            {
                boxProgress.STATUS = status;
                boxProgress.SORTINGTIME = DateTime.Now;
                boxProgress.FINISHTIME = DateTime.Now;
                boxProgress.Save();
            }
        }

        private CigBoxInfo()
        {
            /* require use of factory methods */
        }

        internal CigBoxInfo(SafeDataReader dr)
        {
            ID = dr.GetString("ID");
            SORTINGTASKNO = dr.GetString("SORTINGTASKNO");
            ORDERDATE = dr.GetString("ORDERDATE");
            BOXCODE = dr.GetString("BOXCODE");
            CUSTOMERNO = dr.GetString("CUSTOMERNO");
            CUSTOMERName = dr.GetString("custname");
            LINECODE = dr.GetString("LINECODE");
            LINEID = dr.GetString("LINEID");
            BOXCOUNT = dr.GetInt32("BOXCOUNT");
            BOXQTY = dr.GetInt32("BOXQTY");
            STATUS = dr.GetInt32("STATUS");
            SORTINGTIME = dr.GetDateTime("SORTINGTIME");
            FINISHTIME = dr.GetDateTime("FINISHTIME");
            LineName = dr.GetString("LineName");
            CorpName = dr.GetString("CorpName");
            BOXSEQ = dr.GetInt32("BOXSEQ");
            IndexNO = dr.GetInt32("IndexNO");

            try
            {
                AbnoCount = dr.GetInt32("AbnoCount");
            }
            catch (Exception)
            {
                
                
            }
            try
            {
                Address = dr.GetString("address");
            }
            catch (Exception)
            {
                
                
            }
            
        }
    }
}

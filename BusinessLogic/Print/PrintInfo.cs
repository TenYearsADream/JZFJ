namespace BusinessLogic.Print
{
    /// <summary>
    /// 发票上要打印的信息类
    /// </summary>
    public class PrintInfo
    {

        //客户名
        private string customername;
        public string CustomerName
        {
            get { return customername; }
            set { customername = value; }
        }

	    public string CustomerCode { get; set; }

        //顺序号
        private string indexno;
        public string IndexNo
        {
            get { return indexno; }
            set { indexno = value; }
        }

        //当前包的数量
	    public string CurrentNum { get; set; }

        //总数量
        //private string tasknumber;
        //public string TaskNumber
        //{
        //    get { return tasknumber; }
        //    set { tasknumber = value; }
        //}

        //包序
        private string boxno;
        public string BoxNo
        {
            get { return boxno; }
            set { boxno = value; }
        }

        //总包数
	    public string BoxCount { get; set; }

        //当前客户在线路中的顺序
	    public string CustomerSqe { get; set; }

        //当前客户线路的总顺序
	    //public string CustomerTotSeq { get; set; }

        //当前客户在线路中的包顺序
        public string CustomerBoxSqe { get; set; }

        //当前客户线路的包总顺序
        //public string CustomerBoxTotSeq { get; set; }

        /// <summary>
        /// 送货线路
        /// </summary>
        public string DelivyLine { get; set; }

        /// <summary>
        /// 分拣日期
        /// </summary>
        public string SortingDate { get; set; }

        /// <summary>
        /// 异形烟条数
        /// </summary>
        public string AbnoBoxCount { get; set; }

        public string Address { get; set; }

        /// <summary>
        /// 总包序
        /// </summary>
        public int BoxIndex { get; set; }


    }
}

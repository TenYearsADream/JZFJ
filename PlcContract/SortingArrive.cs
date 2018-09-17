using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlcContract
{
    /// <summary>
    /// 烟条到达信号（尾到，可以结束该任务）
    /// </summary>
    public class SortingArrive:Dictionary<int,string>
    {
        public SortingArrive()
        {
            Add(1,"S7:[S7 connection_1]DB10,INT50");
            Add(2,"S7:[S7 connection_1]DB10,INT52");
            Add(3,"S7:[S7 connection_1]DB10,INT54");
            Add(4,"S7:[S7 connection_1]DB10,INT56");
            Add(5,"S7:[S7 connection_1]DB10,INT58");
            Add(6,"S7:[S7 connection_1]DB10,INT60");
            Add(7,"S7:[S7 connection_1]DB10,INT62");
            Add(8,"S7:[S7 connection_1]DB10,INT64");
            Add(9,"S7:[S7 connection_1]DB10,INT66");
            Add(10,"S7:[S7 connection_1]DB10,INT68");
            Add(11,"S7:[S7 connection_1]DB10,INT70");
            Add(12,"S7:[S7 connection_1]DB10,INT72");
            Add(13,"S7:[S7 connection_1]DB10,INT74");
            Add(14,"S7:[S7 connection_1]DB10,INT76");
            Add(15,"S7:[S7 connection_1]DB10,INT78");
            Add(16,"S7:[S7 connection_1]DB10,INT80");
            Add(17,"S7:[S7 connection_1]DB10,INT82");
            Add(18,"S7:[S7 connection_1]DB10,INT84");
            Add(19,"S7:[S7 connection_1]DB10,INT86");
            Add(20,"S7:[S7 connection_1]DB10,INT88");
        }
    }
}

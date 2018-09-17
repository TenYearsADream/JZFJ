using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlcContract
{
    /// <summary>
    /// 装箱完成信号（读取烟条到达，写入回应信号1）
    /// </summary>
    public class SorgingPackingFinished : Dictionary<int,string>
    {
        public SorgingPackingFinished()
        {
            Add(1,"S7:[S7 connection_1]DB10,INT0");
            Add(2,"S7:[S7 connection_1]DB10,INT2");
            Add(3,"S7:[S7 connection_1]DB10,INT4");
            Add(4,"S7:[S7 connection_1]DB10,INT6");
            Add(5,"S7:[S7 connection_1]DB10,INT8");
            Add(6,"S7:[S7 connection_1]DB10,INT10");
            Add(7,"S7:[S7 connection_1]DB10,INT12");
            Add(8,"S7:[S7 connection_1]DB10,INT14");
            Add(9,"S7:[S7 connection_1]DB10,INT16");
            Add(10,"S7:[S7 connection_1]DB10,INT18");
            Add(11, "S7:[S7 connection_1]DB10,INT20");
            Add(12,"S7:[S7 connection_1]DB10,INT22");
            Add(13,"S7:[S7 connection_1]DB10,INT24");
            Add(14,"S7:[S7 connection_1]DB10,INT26");
            Add(15,"S7:[S7 connection_1]DB10,INT28");
            Add(16,"S7:[S7 connection_1]DB10,INT30");
            Add(17,"S7:[S7 connection_1]DB10,INT32");
            Add(18,"S7:[S7 connection_1]DB10,INT34");
            Add(19,"S7:[S7 connection_1]DB10,INT36");
            Add(20,"S7:[S7 connection_1]DB10,INT38");
        }
    }
}

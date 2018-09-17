using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlcContract
{
    public class InTaskCigStore:Dictionary<int,string>
    {
        public InTaskCigStore()
        {
            Add(67, "S7:[S7 connection_1]DB54,DINT0");
            Add(68, "S7:[S7 connection_1]DB54,DINT4");
            Add(69, "S7:[S7 connection_1]DB54,DINT8");
            Add(70, "S7:[S7 connection_1]DB54,DINT12");
            Add(71, "S7:[S7 connection_1]DB54,DINT16");
            Add(72, "S7:[S7 connection_1]DB54,DINT20");
            Add(73, "S7:[S7 connection_1]DB54,DINT24");
            Add(74, "S7:[S7 connection_1]DB54,DINT28");
        }
    }
}

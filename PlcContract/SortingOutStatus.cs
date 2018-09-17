using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlcContract
{
    public class SortingOutStatus:Dictionary<int,string>
    {
        public SortingOutStatus()
        {
            Add(1,"S7:[S7 connection_1]DB10,INT100");
            Add(2,"S7:[S7 connection_1]DB10,INT102");
            Add(3,"S7:[S7 connection_1]DB10,INT104");
            Add(4,"S7:[S7 connection_1]DB10,INT106");
            Add(5,"S7:[S7 connection_1]DB10,INT108");
            Add(6,"S7:[S7 connection_1]DB10,INT110");
            Add(7,"S7:[S7 connection_1]DB10,INT112");
            Add(8,"S7:[S7 connection_1]DB10,INT114");
            Add(9,"S7:[S7 connection_1]DB10,INT116");
            Add(10,"S7:[S7 connection_1]DB10,INT118");
            Add(11,"S7:[S7 connection_1]DB10,INT120");
            Add(12,"S7:[S7 connection_1]DB10,INT122");
            Add(13,"S7:[S7 connection_1]DB10,INT124");
            Add(14,"S7:[S7 connection_1]DB10,INT126");
            Add(15,"S7:[S7 connection_1]DB10,INT128");
            Add(16,"S7:[S7 connection_1]DB10,INT130");
            Add(17,"S7:[S7 connection_1]DB10,INT132");
            Add(18,"S7:[S7 connection_1]DB10,INT134");
            Add(19,"S7:[S7 connection_1]DB10,INT136");
            Add(20,"S7:[S7 connection_1]DB10,INT138");
        }
    }
}

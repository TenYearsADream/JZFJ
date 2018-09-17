using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlcContract
{
    public class IntaskScanList
    {
        IntaskModel mdl1 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B0" };
        IntaskModel mdl2 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B10" };
        IntaskModel mdl3 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B20" };
        IntaskModel mdl4 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B30" };
        IntaskModel mdl5 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B40" };
        IntaskModel mdl6 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B50" };
        IntaskModel mdl7 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B60" };
        IntaskModel mdl8 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B70" };
        IntaskModel mdl9 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B80" };
        IntaskModel mdl10 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B90" };
        IntaskModel mdl11 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B100" };
        IntaskModel mdl12 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B110" };
        IntaskModel mdl13 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B120" };
        IntaskModel mdl14 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B130" };
        IntaskModel mdl15 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B140" };
        IntaskModel mdl16 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B150" };
        IntaskModel mdl17 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B160" };
        IntaskModel mdl18 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B170" };
        IntaskModel mdl19 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B180" };
        IntaskModel mdl20 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B190" };
        IntaskModel mdl21 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B200" };
        IntaskModel mdl22 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B210" };
        IntaskModel mdl23 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B220" };
        IntaskModel mdl24 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B230" };
        IntaskModel mdl25 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B240" };
        IntaskModel mdl26 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B250" };
        IntaskModel mdl27 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B260" };
        IntaskModel mdl28 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B270" };
        IntaskModel mdl29 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B280" };
        IntaskModel mdl30 = new IntaskModel() { TaskNoAddr = "S7:[S7 connection_1]DB52,B290" };


        public static Dictionary<int, IntaskModel> dic;
       public IntaskScanList()
       {
           dic = new Dictionary<int, IntaskModel>();
           dic.Add(1, mdl1);
           dic.Add(2, mdl2);
           dic.Add(3, mdl3);
           dic.Add(4, mdl4);
           dic.Add(5, mdl5);
           dic.Add(6, mdl6);
           dic.Add(7, mdl7);
           dic.Add(8, mdl8);
           dic.Add(9, mdl9);
           dic.Add(10, mdl10);
           dic.Add(11, mdl11);
           dic.Add(12, mdl12);
           dic.Add(13, mdl13);
           dic.Add(14, mdl14);
           dic.Add(15, mdl15);
           dic.Add(16, mdl16);
           dic.Add(17, mdl17);
           dic.Add(18, mdl18);
           dic.Add(19, mdl19);
           dic.Add(20, mdl20);
           dic.Add(21, mdl21);
           dic.Add(22, mdl22);
           dic.Add(23, mdl23);
           dic.Add(24, mdl24);
           dic.Add(25, mdl25);
           dic.Add(26, mdl26);
           dic.Add(27, mdl27);
           dic.Add(28, mdl28);
           dic.Add(29, mdl29);
           dic.Add(30, mdl30);
       }
    }
}

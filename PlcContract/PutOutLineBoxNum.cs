using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlcContract
{
    public class PutOutLineBoxNum:Dictionary<int,string>
    {
        /// <summary>
        /// PLC中皮带上对应卷烟的数量（不包括卧式机）
        /// 每一个地址位对应一个烟道
        /// </summary>
        public PutOutLineBoxNum()
        {            
            this.Add(1, "S7:[S7 connection_1]DB57,INT0");
            this.Add(2, "S7:[S7 connection_1]DB57,INT2");
            this.Add(3, "S7:[S7 connection_1]DB57,INT4");
            this.Add(4, "S7:[S7 connection_1]DB57,INT6");
            this.Add(5, "S7:[S7 connection_1]DB57,INT8");
            this.Add(6, "S7:[S7 connection_1]DB57,INT10");
            this.Add(7, "S7:[S7 connection_1]DB57,INT12");
            this.Add(8, "S7:[S7 connection_1]DB57,INT14");
            this.Add(9, "S7:[S7 connection_1]DB57,INT16");
            this.Add(10, "S7:[S7 connection_1]DB57,INT18");
            this.Add(11, "S7:[S7 connection_1]DB57,INT20");
            this.Add(12, "S7:[S7 connection_1]DB57,INT22");
            this.Add(13, "S7:[S7 connection_1]DB57,INT24");
            this.Add(14, "S7:[S7 connection_1]DB57,INT26");
            this.Add(15, "S7:[S7 connection_1]DB57,INT28");
            this.Add(16, "S7:[S7 connection_1]DB57,INT30");
            this.Add(17, "S7:[S7 connection_1]DB57,INT32");
            this.Add(18, "S7:[S7 connection_1]DB57,INT34");
            this.Add(19, "S7:[S7 connection_1]DB57,INT36");
            this.Add(20, "S7:[S7 connection_1]DB57,INT38");
            this.Add(21, "S7:[S7 connection_1]DB57,INT40");
            this.Add(22, "S7:[S7 connection_1]DB57,INT42");
            this.Add(23, "S7:[S7 connection_1]DB57,INT44");
            this.Add(24, "S7:[S7 connection_1]DB57,INT46");
            this.Add(25, "S7:[S7 connection_1]DB57,INT48");
            this.Add(26, "S7:[S7 connection_1]DB57,INT50");
            this.Add(27, "S7:[S7 connection_1]DB57,INT52");
            this.Add(28, "S7:[S7 connection_1]DB57,INT54");
            this.Add(29, "S7:[S7 connection_1]DB57,INT56");
            this.Add(30, "S7:[S7 connection_1]DB57,INT58");
            this.Add(31, "S7:[S7 connection_1]DB57,INT60");
            this.Add(32, "S7:[S7 connection_1]DB57,INT62");
            this.Add(33, "S7:[S7 connection_1]DB57,INT64");
            this.Add(34, "S7:[S7 connection_1]DB57,INT66");
            this.Add(35, "S7:[S7 connection_1]DB57,INT68");
            this.Add(36, "S7:[S7 connection_1]DB57,INT70");
            this.Add(37, "S7:[S7 connection_1]DB57,INT72");
            this.Add(38, "S7:[S7 connection_1]DB57,INT74");
            this.Add(39, "S7:[S7 connection_1]DB57,INT76");
            this.Add(40, "S7:[S7 connection_1]DB57,INT78");
            this.Add(41, "S7:[S7 connection_1]DB57,INT80");
            this.Add(42, "S7:[S7 connection_1]DB57,INT82");
            this.Add(43, "S7:[S7 connection_1]DB57,INT84");
            this.Add(44, "S7:[S7 connection_1]DB57,INT86");
            this.Add(45, "S7:[S7 connection_1]DB57,INT88");
            this.Add(46, "S7:[S7 connection_1]DB57,INT90");
            this.Add(47, "S7:[S7 connection_1]DB57,INT92");
            this.Add(48, "S7:[S7 connection_1]DB57,INT94");
            this.Add(49, "S7:[S7 connection_1]DB57,INT96");
            this.Add(50, "S7:[S7 connection_1]DB57,INT98");
            this.Add(51, "S7:[S7 connection_1]DB57,INT100");
            this.Add(52, "S7:[S7 connection_1]DB57,INT102");
            this.Add(53, "S7:[S7 connection_1]DB57,INT104");
            this.Add(54, "S7:[S7 connection_1]DB57,INT106");
            this.Add(55, "S7:[S7 connection_1]DB57,INT108");
            this.Add(56, "S7:[S7 connection_1]DB57,INT110");
            this.Add(57, "S7:[S7 connection_1]DB57,INT112");
            this.Add(58, "S7:[S7 connection_1]DB57,INT114");
            this.Add(59, "S7:[S7 connection_1]DB57,INT116");
            this.Add(60, "S7:[S7 connection_1]DB57,INT118");
            this.Add(61, "S7:[S7 connection_1]DB57,INT120");
            this.Add(62, "S7:[S7 connection_1]DB57,INT122");
            this.Add(63, "S7:[S7 connection_1]DB57,INT124");
            this.Add(64, "S7:[S7 connection_1]DB57,INT126");
            this.Add(65, "S7:[S7 connection_1]DB57,INT128");
            this.Add(66, "S7:[S7 connection_1]DB57,INT130");
            this.Add(67, "S7:[S7 connection_1]DB57,INT132");
            this.Add(68, "S7:[S7 connection_1]DB57,INT134");
            this.Add(69, "S7:[S7 connection_1]DB57,INT136");
            this.Add(70, "S7:[S7 connection_1]DB57,INT138");
            this.Add(71, "S7:[S7 connection_1]DB57,INT140");
            this.Add(72, "S7:[S7 connection_1]DB57,INT142");
            this.Add(73, "S7:[S7 connection_1]DB57,INT144");
            this.Add(74, "S7:[S7 connection_1]DB57,INT146");
            this.Add(75, "S7:[S7 connection_1]DB57,INT148");
            this.Add(76, "S7:[S7 connection_1]DB57,INT150");
            this.Add(77, "S7:[S7 connection_1]DB57,INT152");
            this.Add(78, "S7:[S7 connection_1]DB57,INT154");
            this.Add(79, "S7:[S7 connection_1]DB57,INT156");
            this.Add(80, "S7:[S7 connection_1]DB57,INT158");
            this.Add(81, "S7:[S7 connection_1]DB57,INT160");
            this.Add(82, "S7:[S7 connection_1]DB57,INT162");
            this.Add(83, "S7:[S7 connection_1]DB57,INT164");
            this.Add(84, "S7:[S7 connection_1]DB57,INT166");
        }
    }
}

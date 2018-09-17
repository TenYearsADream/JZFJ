using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlcContract
{
    /// <summary>
    /// 分拣任务下达
    /// </summary>
    public class SortingIssued : Dictionary<string,string>
    {
        public SortingIssued()
        {
            //写入标志
            this.Add("flag", "S7:[S7 connection_1]DB1,INT0");
            //任务号
            this.Add("taskno","S7:[S7 connection_1]DB1,DINT2");
            //虚出口号
            this.Add("outno", "S7:[S7 connection_1]DB1,INT6");
            //总条数
            this.Add("totnumber", "S7:[S7 connection_1]DB1,INT8");
            //所有烟仓号的集合
            this.Add("1", "S7:[S7 connection_1]DB1,INT10");
            this.Add("2", "S7:[S7 connection_1]DB1,INT12");
            this.Add("3", "S7:[S7 connection_1]DB1,INT14");
            this.Add("4", "S7:[S7 connection_1]DB1,INT16");
            this.Add("5", "S7:[S7 connection_1]DB1,INT18");
            this.Add("6", "S7:[S7 connection_1]DB1,INT20");
            this.Add("7", "S7:[S7 connection_1]DB1,INT22");
            this.Add("8", "S7:[S7 connection_1]DB1,INT24");
            this.Add("9", "S7:[S7 connection_1]DB1,INT26");
            this.Add("10", "S7:[S7 connection_1]DB1,INT28");
            this.Add("11", "S7:[S7 connection_1]DB1,INT30");
            this.Add("12", "S7:[S7 connection_1]DB1,INT32");
            this.Add("13", "S7:[S7 connection_1]DB1,INT34");
            this.Add("14", "S7:[S7 connection_1]DB1,INT36");
            this.Add("15", "S7:[S7 connection_1]DB1,INT38");
            this.Add("16", "S7:[S7 connection_1]DB1,INT40");
            this.Add("17", "S7:[S7 connection_1]DB1,INT42");
            this.Add("18", "S7:[S7 connection_1]DB1,INT44");
            this.Add("19", "S7:[S7 connection_1]DB1,INT46");
            this.Add("20", "S7:[S7 connection_1]DB1,INT48");
            this.Add("21", "S7:[S7 connection_1]DB1,INT50");
            this.Add("22", "S7:[S7 connection_1]DB1,INT52");
            this.Add("23", "S7:[S7 connection_1]DB1,INT54");
            this.Add("24", "S7:[S7 connection_1]DB1,INT56");
            this.Add("25", "S7:[S7 connection_1]DB1,INT58");
            this.Add("26", "S7:[S7 connection_1]DB1,INT60");
            this.Add("27", "S7:[S7 connection_1]DB1,INT62");
            this.Add("28", "S7:[S7 connection_1]DB1,INT64");
            this.Add("29", "S7:[S7 connection_1]DB1,INT66");
            this.Add("30", "S7:[S7 connection_1]DB1,INT68");
            this.Add("31", "S7:[S7 connection_1]DB1,INT70");
            this.Add("32", "S7:[S7 connection_1]DB1,INT72");
            this.Add("33", "S7:[S7 connection_1]DB1,INT74");
            this.Add("34", "S7:[S7 connection_1]DB1,INT76");
            this.Add("35", "S7:[S7 connection_1]DB1,INT78");
            this.Add("36", "S7:[S7 connection_1]DB1,INT80");
            this.Add("37", "S7:[S7 connection_1]DB1,INT82");
            this.Add("38", "S7:[S7 connection_1]DB1,INT84");
            this.Add("39", "S7:[S7 connection_1]DB1,INT86");
            this.Add("40", "S7:[S7 connection_1]DB1,INT88");
            this.Add("41", "S7:[S7 connection_1]DB1,INT90");
            this.Add("42", "S7:[S7 connection_1]DB1,INT92");
            this.Add("43", "S7:[S7 connection_1]DB1,INT94");
            this.Add("44", "S7:[S7 connection_1]DB1,INT96");
            this.Add("45", "S7:[S7 connection_1]DB1,INT98");
            this.Add("46", "S7:[S7 connection_1]DB1,INT100");
            this.Add("47", "S7:[S7 connection_1]DB1,INT102");
            this.Add("48", "S7:[S7 connection_1]DB1,INT104");
            this.Add("49", "S7:[S7 connection_1]DB1,INT106");
            this.Add("50", "S7:[S7 connection_1]DB1,INT108");
            this.Add("51", "S7:[S7 connection_1]DB1,INT110");
            this.Add("52", "S7:[S7 connection_1]DB1,INT112");
            this.Add("53", "S7:[S7 connection_1]DB1,INT114");
            this.Add("54", "S7:[S7 connection_1]DB1,INT116");
            this.Add("55", "S7:[S7 connection_1]DB1,INT118");
            this.Add("56", "S7:[S7 connection_1]DB1,INT120");
            this.Add("57", "S7:[S7 connection_1]DB1,INT122");
            this.Add("58", "S7:[S7 connection_1]DB1,INT124");
            this.Add("59", "S7:[S7 connection_1]DB1,INT126");
            this.Add("60", "S7:[S7 connection_1]DB1,INT128");
            this.Add("61", "S7:[S7 connection_1]DB1,INT130");
            this.Add("62", "S7:[S7 connection_1]DB1,INT132");
            this.Add("63", "S7:[S7 connection_1]DB1,INT134");
            this.Add("64", "S7:[S7 connection_1]DB1,INT136");
            this.Add("65", "S7:[S7 connection_1]DB1,INT138");
            this.Add("66", "S7:[S7 connection_1]DB1,INT140");
            this.Add("67", "S7:[S7 connection_1]DB1,INT142");
            this.Add("68", "S7:[S7 connection_1]DB1,INT144");
            this.Add("69", "S7:[S7 connection_1]DB1,INT146");
            this.Add("70", "S7:[S7 connection_1]DB1,INT148");
            this.Add("71", "S7:[S7 connection_1]DB1,INT150");
            this.Add("72", "S7:[S7 connection_1]DB1,INT152");
            this.Add("73", "S7:[S7 connection_1]DB1,INT154");
            this.Add("74", "S7:[S7 connection_1]DB1,INT156");
            this.Add("75", "S7:[S7 connection_1]DB1,INT158");
            this.Add("76", "S7:[S7 connection_1]DB1,INT160");
            this.Add("77", "S7:[S7 connection_1]DB1,INT162");
            this.Add("78", "S7:[S7 connection_1]DB1,INT164");
            this.Add("79", "S7:[S7 connection_1]DB1,INT166");
            this.Add("80", "S7:[S7 connection_1]DB1,INT168");
            this.Add("81", "S7:[S7 connection_1]DB1,INT170");
            this.Add("82", "S7:[S7 connection_1]DB1,INT172");
            this.Add("83", "S7:[S7 connection_1]DB1,INT174");
            this.Add("84", "S7:[S7 connection_1]DB1,INT176");
            //由于电控协议中85号仓位被其它设备占用
            //所以85号烟仓从INT180开始，具体参考电控协议
            this.Add("85", "S7:[S7 connection_1]DB1,INT180");
            this.Add("86", "S7:[S7 connection_1]DB1,INT182");
            this.Add("87", "S7:[S7 connection_1]DB1,INT184");
            this.Add("88", "S7:[S7 connection_1]DB1,INT186");
            this.Add("89", "S7:[S7 connection_1]DB1,INT188");

            //烟仓合计
            this.Add("90", "S7:[S7 connection_1]DB1,INT178");
            this.Add("91", "S7:[S7 connection_1]DB1,INT190");
            this.Add("92", "S7:[S7 connection_1]DB1,INT192");
            this.Add("93", "S7:[S7 connection_1]DB1,INT194");
            this.Add("94", "S7:[S7 connection_1]DB1,INT196");
        }
    }
}

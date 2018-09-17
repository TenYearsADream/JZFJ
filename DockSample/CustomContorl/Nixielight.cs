using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessLogic.Common;
using LY.FuelStationPOS.Protocol;
using BusinessLogic.Search;
using PlcContract;
using AppUtility;
using BusinessLogic.SortingTask;

namespace MonitorMain.CustomContorl
{
    public partial class Nixielight : UserControl
    {
        public Nixielight()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Nixielight_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dictionary<int,int> senDictionary = new Dictionary<int, int>();
            senDictionary.Add(ingboxcode.Value,ingqty.Value);
            NixielightSDK.SendByMODBUS(senDictionary);	        
        }

        

        


        private Dictionary<int, int> SendContexts;
        public void SendByASCII(Dictionary<int, int> sendcontexts)
        {
            SendContexts = sendcontexts;
            StringBuilder sb = null;
		    SerialPortDao serialPortDao = SerialPortDao.GetSerialPortDao();
            serialPortDao.Open();
            
	        try
	        {
                
                //KeyValuePair<int, int>  sendcontext = sendcontexts[1];
		        foreach (KeyValuePair<int, int> sendcontext in sendcontexts)
		        {
                    //$001,1234#  显示 1234；其中 001 是屏的地址码。若是 3 位数码管，只能发送 3 个 ASCII 字符。
                    //$001,#  不显示
			        sb = new StringBuilder();
			        sb.Append("$");
			        sb.Append((sendcontext.Key + 10).ToString("D3"));//物理地址大于仓道号10
			        sb.Append(",");
                    if (sendcontext.Value == 0)
                    {
                        sb.Append("");
                    }
                    else
                    {
                        sb.Append(sendcontext.Value);
                    }
			        sb.Append("#");
			        serialPortDao.SendData(sb.ToString());
			        Thread.Sleep(30);
		        }              


		        serialPortDao.Close();
	        }
	        catch (Exception)
	        {
		        throw;
	        }
	        finally
	        {
		        serialPortDao.Close();
	        }
           
        }

        

	    public void SendByNon(Dictionary<int, int> sendcontexts)
	    {
	    }

        private void buttonX1_Click(object sender, EventArgs e)  
        {
            //for (int j = 111;j < 1000; j=j + 111)
            //{
            //    Dictionary<int, int> senDictionary = new Dictionary<int, int>();
            //    for (int i = 1; i <= 84; i++)
            //    {
            //        //senDictionary.Add(i, ingqty.Value);
            //        senDictionary.Add(i, j);
            //    }
            //    SendByMODBUS(senDictionary);
            //}

            Dictionary<int, int> senDictionary = new Dictionary<int, int>();
            for (int i = 1; i <= 84; i++)
            {
                //senDictionary.Add(i, ingqty.Value);
                senDictionary.Add(i, 888);
            }
            NixielightSDK.SendByMODBUS(senDictionary);
            
        }

        public void SendNull()
        {
            Dictionary<int, int> senDictionary = new Dictionary<int, int>();
            for (int i = 1; i <= 84; i++)
            {
                //senDictionary.Add(i, ingqty.Value);
                senDictionary.Add(i, 0);
            }
            NixielightSDK.SendByMODBUS(senDictionary);
        }


        public bool SendPD()
        {
            try
            {
                Dictionary<int, int> senDictionary = new Dictionary<int, int>();

                LineBoxProcessList lineboxprocesslist = LineBoxProcessList.GetList("盘点");

                OperateOpcAndSoft operateOpcAndSoft = new OperateOpcAndSoft();
                Dictionary<int, int> putoutnums = operateOpcAndSoft.GetPutOutNum();

                for (int i = 0; i < lineboxprocesslist.Count; i++)
                {
                    if (putoutnums.ContainsKey(Convert.ToInt32(lineboxprocesslist[i].LINEBOXCODE)))
                    {
                        lineboxprocesslist[i].OUTQTY = putoutnums[Convert.ToInt32(lineboxprocesslist[i].LINEBOXCODE)];
                        lineboxprocesslist[i].NONQTY = (lineboxprocesslist[i].NONQTY - lineboxprocesslist[i].OUTQTY);
                    }

                    //if (i == 9 || i == 11 || i == 21 || i == 23 || i == 33 || i == 36 || i == 45 || i == 47 || i == 57 || i == 59 || i == 69 || i == 71 || i == 81 || i == 83)
                    //将双仓的数量与前一个单仓相加
                    if (AppUtil.Put2LineBox.Contains(lineboxprocesslist[i].LINEBOXCODE))
                    {
                        lineboxprocesslist[i - 1].NONQTY = lineboxprocesslist[i - 1].NONQTY + lineboxprocesslist[i].NONQTY;
                    }

                }

                for (int i = 0; i < lineboxprocesslist.Count; i++)
                {
                    senDictionary.Add(Convert.ToInt32(lineboxprocesslist[i].LINEBOXCODE), lineboxprocesslist[i].NONQTY);
                }

                NixielightSDK.SendByMODBUS(senDictionary);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

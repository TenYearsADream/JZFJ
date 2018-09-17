using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppUtility;
using BusinessLogic.Common;
using BusinessLogic.SortingTask;
using HDWLogic;
using LY.FuelStationPOS.Protocol;

namespace MonitorMain
{
    public class NixielightSDK
    {
        static public void SendByMODBUS(Dictionary<int, int> sendcontexts)
        {
            SerialPortDao serialPortDao = SerialPortDao.GetSerialPortDao();
            byte[] sendcode = null;
            try
            {
                if (sendcontexts != null)
                {
                    serialPortDao.Open();
                }
                foreach (KeyValuePair<int, int> sendcontext in sendcontexts)
                {
                    
                    if (sendcontext.Value > 0)
                    {
                        byte[] recevedata = new byte[2];
                        byte address;
                        const byte functioncode = 0x06;
                        byte[] register = new byte[2];
                        byte[] code = new byte[2];
                        byte[] crc = new byte[2];
                        sendcode = new byte[8];

                        address = Convert.ToByte(sendcontext.Key + 10);
                        string a = sendcontext.Value.ToString("x4");
                        code = strToToHexByte(a);
                        sendcode[0] = address;
                        sendcode[1] = functioncode;
                        sendcode[2] = register[0];
                        sendcode[3] = register[1];
                        sendcode[4] = code[0];
                        sendcode[5] = code[1];
                        crc = CRC.crc_16(sendcode, 6);
                        sendcode[6] = crc[6];
                        sendcode[7] = crc[7];
                        //cobsendcontext.Items.Clear();
                        foreach (byte b in sendcode)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(b.ToString("X2"));
                            //cobsendcontext.Items.Add(sb.ToString());
                        }
                        serialPortDao.SendCommand(sendcode, ref recevedata, 3);
                        //Thread.Sleep(5);

                    }
                    else
                    {
                        byte[] recevedata = new byte[2];
                        byte address;
                        const byte functioncode = 0x10;
                        byte[] register = new byte[2];
                        byte[] registercount = new byte[2];
                        byte[] code = new byte[2];
                        byte[] crc = new byte[2];
                        sendcode = new byte[21];

                        address = Convert.ToByte(sendcontext.Key + 10);
                        sendcode[0] = address;
                        sendcode[1] = functioncode;
                        sendcode[2] = 0;
                        sendcode[3] = 112;
                        sendcode[4] = 0;
                        sendcode[5] = 6;
                        sendcode[6] = 12;

                        for (int i = 7; i <= 18; i++)
                        {
                            sendcode[i] = 0;
                        }
                        crc = CRC.crc_16(sendcode, 19);
                        sendcode[19] = crc[19];
                        sendcode[20] = crc[20];
                        //cobsendcontext.Items.Clear();
                        foreach (byte b in sendcode)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(b.ToString("X2"));
                            //cobsendcontext.Items.Add(sb.ToString());
                        }

                        serialPortDao.SendCommand(sendcode, ref recevedata, 3);

                        //Thread.Sleep(10);
                    }
                }


                //serialPortDao.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //serialPortDao.Close();
            }
        }


        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        /// <summary>
        /// 发送订单到数码管
        /// </summary>
        static  public Dictionary<int, Tag> SetOrderNixielight(SortingLineTask[] sortingLineTasks)
        {
            Dictionary<int, int> senDictionary = new Dictionary<int, int>();
            Dictionary<int,Tag> tagDictionary = new Dictionary<int, Tag>();

            int sortinglineboxcount = SortingLineBoxList.GetLineBoxList().Count;

            try
            {
                for (int i = 1; i <= sortinglineboxcount; i++)
                {
                    senDictionary.Add(i, 0);
                }

                SortingSubLine[] sortingSubLineList = SortingSubLineList.GetSubSortingLineList().OrderBy(o => o.sequence).ToArray();

                

                for (int j = 1; j < sortingLineTasks.Length; j++)
                {
                    if (sortingLineTasks[j] != null)
                    {
                        //当前子线包含的所有任务明细列表
                        IEnumerable<SortingLineTaskDetail> sortingLineTaskDetails =
                            sortingLineTasks[j].SortingLineTaskDetails.GetAreaDetails(sortingSubLineList[j-1].sublineCode);

                        foreach (SortingLineTaskDetail detail in sortingLineTaskDetails)
                        {
                            try
                            {
                                tagDictionary.Add(Convert.ToInt32(detail.LINEBOXCODE),new Tag(sortingLineTasks[j].ID,Convert.ToInt32(detail.LINEBOXCODE),detail.QTY));
                                senDictionary[Convert.ToInt32(detail.LINEBOXCODE)] = detail.QTY;
                            }
                            catch (Exception)
                            {


                            }

                        }

                        //NixielightSDK.SendByMODBUS(senDictionary);
                    }
                }


            }
            catch (Exception)
            {


            }

            return tagDictionary;
        }
    }
}

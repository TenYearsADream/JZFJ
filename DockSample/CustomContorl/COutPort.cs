using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.DisplayBoards;
using DevComponents.DotNetBar;
using BusinessLogic.PrintBarcode;
using BusinessLogic.SortingTask;
using System.Media;
using BusinessLogic.Log;
using BusinessLogic.SortingProcess;
using PlcContract;
using AppUtility;
using MySql.Data.MySqlClient;
using Csla.Data;
using BusinessLogic.Download;

namespace MonitorMain.CustomContorl
{
    public partial class COutPort : UserControl
    {
        OutPort _outport;
        OutPort _poutport;
        OutPort _noutport;


        int indexno = 0;
        int pindexno = 0;
        int nindexno = 0;



        public string OutPortNo { get; set; }
        public string POutPortNo { get; set; }
        public string NOutPortNo { get; set; }

        string NCustName = "";
        bool isalert = false;

        OperateOpcAndSoft opert;

        public COutPort()
        {
            AppUtil apputil = new AppUtil();
            InitializeComponent();
            
        }

        public void Start()
        {
            GetOutPortInfo();
            GetPOutPortInfo();
            GetNOutPortInfo();
            timer1.Start();
            timer2.Start();

        }

        private void GetOutPortInfo()
        {
            
            opert = new OperateOpcAndSoft();
            
            GetFirstCode();
            _outport = new OutPort(indexno);
            _outport.GetCustInfo();
            int onesum = 0;
            int twosum = 0;
            int threesum = 0;
            Dictionary<string,Color> ciginfo = _outport.GetCigInfo(ref onesum,ref twosum,ref threesum);
            labonesum.Text = onesum.ToString();
            labtwosum.Text = twosum.ToString();
            labthreesum.Text = threesum.ToString();
            labonetwosum.Text = (onesum + twosum).ToString();
            foreach (Control control in this.panelEx2.Controls)
            {
                if (control is LabelX && control.Tag != null)
                {
                    if (_outport.ContainsKey(control.Tag.ToString()))
                    {
                        ((LabelX)control).Text = _outport[control.Tag.ToString()];    
                    }
                    
                }
                
            }

            foreach (Control control in this.panel6.Controls)
            {
                if (control is LabelX && control.Tag != null)
                {
                    if (_outport.ContainsKey(control.Tag.ToString()))
                    {
                        ((LabelX)control).Text = _outport[control.Tag.ToString()];
                    }

                }

            }


            itemPanel1.BeginUpdate();
            itemPanel1.Items.Clear();
            foreach (var s in ciginfo)
            {
                
                LabelItem labelItem = new LabelItem();
                labelItem.Text = s.Key.Replace("("," ").Replace(")","");
                labelItem.Font = new System.Drawing.Font("黑体", 14);
                labelItem.BorderSide = eBorderSide.All;
                labelItem.BorderType = eBorderType.Bump;
                if (s.Key.Contains("*"))
                {
                    labelItem.ForeColor = Color.Red;
                }
                else
                {
                    labelItem.ForeColor = s.Value;
                }
                labelItem.TextLineAlignment = StringAlignment.Center;
                labelItem.Width = 225;
                labelItem.Height = 25;
                //labelItem.WordWrap = true;
                itemPanel1.Items.Add(labelItem);
                

                



            }
            itemPanel1.EndUpdate();
        }

        private void GetPOutPortInfo()
        {
            _poutport = new OutPort(pindexno);
            _poutport.GetCustInfo();
            int onesum = 0;
            int twosum = 0;
            int threesum = 0;
            Dictionary<string, Color> ciginfo = _poutport.GetCigInfo(ref onesum, ref twosum, ref threesum);
            labponesum.Text = onesum.ToString();
            labptwosum.Text = twosum.ToString();
            labpthreesum.Text = threesum.ToString();
            labponetwosum.Text = (onesum + twosum).ToString();

            labelX31.Text = _poutport["INDEXNO"];
            foreach (Control control in this.panel4.Controls)
            {
                if (control is LabelX && control.Tag != null)
                {
                    if (_poutport.ContainsKey(control.Tag.ToString()))
                    {
                        ((LabelX)control).Text = _poutport[control.Tag.ToString()];
                    }

                }
            }

            itemPanel2.BeginUpdate();
            itemPanel2.Items.Clear();
            
            foreach (var s in ciginfo)
            {
                LabelItem labelItem = new LabelItem();
                labelItem.Text = s.Key.Replace("(", " ").Replace(")", "");
                labelItem.Font = new System.Drawing.Font("黑体", 14);
                if (s.Key.Contains("*"))
                {
                    labelItem.ForeColor = Color.Red;
                }
                else
                {
                    labelItem.ForeColor = s.Value;
                }
                labelItem.BorderSide = eBorderSide.All;
                labelItem.BorderType = eBorderType.Bump;                
                labelItem.TextLineAlignment = StringAlignment.Center;
                labelItem.Width = 225;
                labelItem.Height = 25;
                //labelItem.WordWrap = true;
                itemPanel2.Items.Add(labelItem);
            }
            itemPanel2.EndUpdate();
        }

        private void GetNOutPortInfo()
        {
            _noutport = new OutPort(nindexno);
            _noutport.GetCustInfo();
            int onesum = 0;
            int twosum = 0;
            int threesum = 0;
            Dictionary<string, Color> ciginfo = _noutport.GetCigInfo(ref onesum, ref twosum, ref threesum);
            labnonesum.Text = onesum.ToString();
            labntwosum.Text = twosum.ToString();
            labnthreesum.Text = threesum.ToString();
            labnonetwosum.Text = (onesum + twosum).ToString();

            labelX29.Text = _noutport["INDEXNO"];
            foreach (Control control in this.panel5.Controls)
            {
                if (control is LabelX && control.Tag != null)
                {
                    if (_noutport.ContainsKey(control.Tag.ToString()))
                    {
                        ((LabelX)control).Text = _noutport[control.Tag.ToString()];
                    }

                }
            }
            

            if ((!string.IsNullOrEmpty(labncustname.Text)) && (labncustname.Text.Contains("×")) && (labncustname.Text != NCustName))
            {
                NCustName = labncustname.Text;
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = Application.StartupPath + "\\Sound\\下一订单.wav";
                player.Load();
                player.Play();
            }


            itemPanel3.BeginUpdate();
            itemPanel3.Items.Clear();
            
            foreach (var s in ciginfo)
            {
                LabelItem labelItem = new LabelItem();
                labelItem.Text = s.Key.Replace("(", " ").Replace(")", "");
                labelItem.Font = new System.Drawing.Font("黑体", 14);
                if (s.Key.Contains("*"))
                {
                    labelItem.ForeColor = Color.Red;
                }
                else
                {
                    labelItem.ForeColor = s.Value;
                }
                labelItem.BorderSide = eBorderSide.All;
                labelItem.BorderType = eBorderType.Bump;                
                labelItem.TextLineAlignment = StringAlignment.Center;
                labelItem.Width = 225;
                labelItem.Height = 25;
                labelItem.WordWrap = true;
                itemPanel3.Items.Add(labelItem);
            }
            itemPanel3.EndUpdate();
            
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           
            try
            {
                //获取当前，上一个，下一个客户的基本信息
                GetOutPortInfo();
                GetPOutPortInfo();
                GetNOutPortInfo();

                //获取平均效率的列表（当天所有打完码的客户）
                List<PrintInfo> printinfos = PrintBarCodes.GetAVGPrintEffice();
                //获取当前效率的列表（现在系统所有打完码的客户）
                List<PrintInfo> cutprintinfos = PrintBarCodes.GetCUTPrintEffice();                

                //计算当前效率
                double tzeff = SetEff(cutprintinfos);

                labavgeffice.Text = tzeff.ToString() + "条/小时";

                if (labavgeffice.Text.Contains("非数字"))
                    labavgeffice.Text = "0" + "条/小时";

                using (var cn = new MySqlConnection(AppUtility.AppUtil._LocalConnectionString))
                {
                    cn.Open();
                    using (var cm = cn.CreateCommand())
                    {
                        cm.CommandText = "select MaxcutEFFICIENCY from t_sortline_process WHERE ORDERDATE = '" + SortingLineTask.GetSortingLineTaskDate() + "' AND PICKLINECODE = '" + SortingLine.GetSortingLineCode() + "' AND SORTINGTASKNO = '" + SortingLineTask.GetMinSortingLineTask().SORTINGTASKNO + "'";
                        using (var dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                labcuteffice.Text = dr.GetDouble("MaxcutEFFICIENCY").ToString() + "条/小时";
                            }
                        }
                    }
                }

                //计算平均效率
                //tzeff = SetEff(printinfos);

                //labavgeffice.Text = tzeff.ToString() + "条/小时";;

                //if (labavgeffice.Text.Contains("非数字"))
                //    labavgeffice.Text = "0" + "条/小时";

                //计算分拣进度
                SortingProgress sortingprogress = SortingProgress.GetSortingTaskProgress();
                prosorting.Maximum = sortingprogress.TotQty;
                prosorting.Value = sortingprogress.Qty;
                prosorting.Text = (sortingprogress.Qty + "/" + sortingprogress.TotQty).PadRight(15,' ') +
                                  Math.Round(
                                      Convert.ToDouble(sortingprogress.Qty)/Convert.ToDouble(sortingprogress.TotQty), 3)*
                                  100 + "％";

            }
            catch
            {
            }
        }

        private void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
        }

        private void labelX18_Click(object sender, EventArgs e)
        {

        }

        private void GetFirstCode()
        {
            try
            {
                indexno = PrintBarCodes.GetPrintIndex();
                if (indexno > 0)
                {
                    pindexno = indexno - 1;
                    nindexno = indexno + 1;
                }
                else
                {
                    pindexno = 0;
                    nindexno = 0;
                }
            }
            catch(Exception ex)
            {
                //string a = ex.Message;
            }
        }

        private string GetPCustCigInfo()
        {            
            SortingLineTask sortingLineTask;
            if (indexno > 0)
            {                
                sortingLineTask = SortingLineTask.GetSortingLineByIndex(pindexno.ToString());
                return sortingLineTask.CUSTCODE;
                //SortingLineTaskDetails sortingLineTaskDetails = SortingLineTaskDetails.GetSortingLineTaskDetailsByIndex(indexno);
            }
            return "0";
        }


        private string GetNCustCigInfo()
        {            
            SortingLineTask sortingLineTask;
            if (indexno > 0)
            {                
                sortingLineTask = SortingLineTask.GetSortingLineByIndex(nindexno.ToString());
                return sortingLineTask.CUSTCODE;
                //SortingLineTaskDetails sortingLineTaskDetails = SortingLineTaskDetails.GetSortingLineTaskDetailsByIndex(indexno);
            }
            return "0";
        }

        /// <summary>
        /// 程序执行时间测试
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>返回(秒)单位，比如: 0.00239秒</returns>
        public string ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //你想转的格式
            return ts3.TotalSeconds.ToString();
        }



        private double SetEff(List<PrintInfo> printinfos)
        {
            DateTime? starttime = null;
            double second = 0;
            double passt = 0;

            double pnum = 0;
            double totolnum = 0;
            int ordernum = 0;
            double waittime = 0;

            
            //Dictionary<string, double> effice = new Dictionary<string, double>();
            foreach (PrintInfo printinfo in printinfos)
            {
                if (starttime == null)
                {
                    pnum = printinfo.allnum;
                    starttime = printinfo.starttime;
                }
                else
                {
                    second = Convert.ToDouble(ExecDateDiff(Convert.ToDateTime(starttime), printinfo.starttime));
                    if (second < AppUtility.AppUtil._IgnoreSecond)
                    {
                        totolnum += pnum;
                        passt += second;
                        ordernum++;
                    }
                    else
                    {
                        waittime += second;
                    }
                    pnum = printinfo.allnum;
                    starttime = printinfo.starttime;

                }
            }




            double eff = Math.Round((Math.Round((totolnum / passt), 9) * 3600), 0);
            double tzeff;
            if (AppUtility.AppUtil._LimiltEff)
            {
                tzeff = (8000 - ((Convert.ToInt32(eff) / 1000) * 1000)) + eff;
            }
            else
            {
                tzeff = eff;
            }
            return tzeff;
        }

        /// <summary>
        /// 播放缺烟及卡烟语音
        /// </summary>
        /// <param name="o"></param>
        private void PlayBlockSound(object o)
        {
            
            LineBoxStatus lineboxstatus = (LineBoxStatus)o;
            
            int lineboxidint = Convert.ToInt32(lineboxstatus.lineboxcode);
            if (lineboxidint > 0)
            {
                int remainder = lineboxidint % 10;

                lineboxstatus.lineboxcode = (lineboxidint - remainder) / 10;
                SoundPlayer player;
			try
                {
                if (lineboxstatus.lineboxcode > 0)
                {
                    player = new SoundPlayer();
                    player.SoundLocation = Application.StartupPath + "\\Sound\\" + lineboxstatus.lineboxcode + ".wav";
                    player.Load();
                    player.Play();
                    Thread.Sleep(700);
                    player = new SoundPlayer();
                    player.SoundLocation = Application.StartupPath + "\\Sound\\10.wav";
                    player.Load();
                    player.Play();
                    Thread.Sleep(700);
                }


                if (remainder > 0)
                {
                    player = new SoundPlayer();
                    player.SoundLocation = Application.StartupPath + "\\Sound\\" + remainder + ".wav";
                    player.Load();
                    player.Play();
                    Thread.Sleep(700);
                }

                if (lineboxstatus.status == 8)
                {
                    player = new SoundPlayer();
                    player.SoundLocation = Application.StartupPath + "\\Sound\\卡烟.wav";
                    player.Load();
                    player.Play();
                }

                if (lineboxstatus.status == 4)
                {
                    player = new SoundPlayer();
                    player.SoundLocation = Application.StartupPath + "\\Sound\\缺烟.wav";
                    player.Load();
                    player.Play();
                }

                if (lineboxstatus.status == 16)
                {
                    player = new SoundPlayer();
                    player.SoundLocation = Application.StartupPath + "\\Sound\\挂烟.wav";
                    player.Load();
                    player.Play();
                }
            }
		 catch
                { }
            }
        }
		
		/// <summary>
		/// 播放挂烟语音
		/// </summary>
		
        public void PlayHangSound(object o)
		{    
		//try
            //{
            //    SoundPlayer player = new SoundPlayer();
            //    player.SoundLocation = Application.StartupPath + "\\Sound\\挂烟.wav";
            //    player.Load();
            //    player.Play();
            //}
            //catch
            //{ }

            LineBoxStatus lineboxstatus = (LineBoxStatus)o;

            int lineboxidint = Convert.ToInt32(lineboxstatus.lineboxcode);
            if (lineboxidint > 0)
            {
                int remainder = lineboxidint % 10;

                lineboxstatus.lineboxcode = (lineboxidint - remainder) / 10;
                SoundPlayer player;

                try
                {
                    if (lineboxstatus.lineboxcode > 0)
                    {
                        player = new SoundPlayer();
                        player.SoundLocation = Application.StartupPath + "\\Sound\\" + lineboxstatus.lineboxcode + ".wav";
                        player.Load();
                        player.Play();
                        Thread.Sleep(700);
                        player = new SoundPlayer();
                        player.SoundLocation = Application.StartupPath + "\\Sound\\10.wav";
                        player.Load();
                        player.Play();
                        Thread.Sleep(700);
                    }
                    if (remainder > 0)
                    {
                        player = new SoundPlayer();
                        player.SoundLocation = Application.StartupPath + "\\Sound\\" + remainder + ".wav";
                        player.Load();
                        player.Play();
                        Thread.Sleep(700);
                    }
                    if (lineboxstatus.status == 1)
                    {
                        player = new SoundPlayer();
                        player.SoundLocation = Application.StartupPath + "\\Sound\\挂烟.wav";
                        player.Load();
                        player.Play();
                    }

                }
                catch
                { }
            }
        }

        private void timer2_Elapsed_1(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
			{
			  	LineBoxStatus hanglineboxstatus;
                LineBoxStatus lineboxstatus;
                

                if (OperateOpcAndSoft.plc != null)
                {
                    //hanglineboxstatus = opert.SubLineStatus();
                    //if (hanglineboxstatus != null && hanglineboxstatus.status == 1)
                    //{

                    //    if (hanglineboxstatus.lineboxcode.ToString() != labblockbox.Text)
                    //    {
                    //        try
                    //        {
                    //            SortingFault.SaveFaultBoxStatus(hanglineboxstatus.lineboxcode,hanglineboxstatus.status);

                    //            OperationLog operationLog = OperationLog.NewOperationLog();
                    //            operationLog.OPERATIONCODE = "挂烟";
                    //            operationLog.OPERATIONNAME = hanglineboxstatus.lineboxcode.ToString();
                    //            operationLog.Save();
                    //        }
                    //        catch
                    //        { }


                    //        labblockbox.Text = hanglineboxstatus.lineboxcode.ToString();
                    //        labblockbox.ForeColor = Color.Red;
                    //        labboxstatus.ForeColor = Color.Red;
                    //        labblockname.ForeColor = Color.Red;
                    //        if (SortingLineTaskDetail.GetSortingLineBoxCigNumber(hanglineboxstatus.lineboxcode) == 1)
                    //        {
                    //            labblockname.Text = SortingLineTaskDetail.GetSortingLineBoxCigName(hanglineboxstatus.lineboxcode);
                    //        }
                    //        else
                    //        {
                    //            labblockname.Text = "混仓品牌";
                    //        }

                    //        if (hanglineboxstatus.status == 1)
                    //        {
                    //            labboxstatus.Text = "挂烟";
                    //        }
                            
                    //        Thread thread = new Thread(new ParameterizedThreadStart(PlayHangSound));
                    //        thread.Start(hanglineboxstatus);
                    //    }

                    //}
                    
                    lineboxstatus = opert.GetLineBoxException();
                    if (lineboxstatus != null)
                    {
                        if (lineboxstatus.lineboxcode.ToString() != labblockbox.Text)
                        {
                            try
                            {
                                SortingFault.SaveFaultBoxStatus(lineboxstatus.lineboxcode, lineboxstatus.status,lineboxstatus.putnum);

                                OperationLog operationLog = OperationLog.NewOperationLog();
                                if (lineboxstatus.status == 8)
                                {
                                    operationLog.OPERATIONCODE = "卡烟";

                                    //发送当前已打出的条烟到数码管
                                    //SendTaskPutNiLight(lineboxstatus.lineboxcode);
                                    //Thread thread = new Thread(new ParameterizedThreadStart(SendTaskPutNiLight));
                                    //thread.Start(lineboxstatus.lineboxcode);
                                }
                                if (lineboxstatus.status == 4)
                                {
                                    operationLog.OPERATIONCODE = "缺烟";
                                }

                                if (lineboxstatus.status == 16)
                                {
                                    operationLog.OPERATIONCODE = "挂烟";
                                    
                                }

                                operationLog.OPERATIONNAME = lineboxstatus.lineboxcode.ToString();
                                operationLog.Save();
                            }
                            catch
                            { }


                            labblockbox.Text = lineboxstatus.lineboxcode.ToString();
                            labblockbox.ForeColor = Color.Red;
                            labboxstatus.ForeColor = Color.Red;
                            labblockname.ForeColor = Color.Red;
                            if (SortingLineTaskDetail.GetSortingLineBoxCigNumber(lineboxstatus.lineboxcode) == 1)
                            {
                                labblockname.Text = SortingLineTaskDetail.GetSortingLineBoxCigName(lineboxstatus.lineboxcode);
                            }
                            else
                            {
                                labblockname.Text = "混仓品牌";
                            }

                            if (lineboxstatus.status == 4)
                            {
                                labboxstatus.Text = "缺烟";
                            }
                            if (lineboxstatus.status == 8)
                            {
                                labboxstatus.Text = "卡烟";
                            }
                            if (lineboxstatus.status == 16)
                            {
                                labboxstatus.Text = "挂烟";
                            }
                            Thread thread1 = new Thread(new ParameterizedThreadStart(PlayBlockSound));
                            thread1.Start(lineboxstatus);
                            //发送当前已打出的条烟到数码管
                            SendTaskPutNiLight(lineboxstatus.lineboxcode);
                        }

                    }
                    //if (hanglineboxstatus == null && lineboxstatus == null)
                    if ( lineboxstatus == null && labboxstatus.Text != "正常")
                    {
                        SortingFault.SaveFaultBoxStatus(0, 0,0);
                        labboxstatus.Text = "正常";
                        labboxstatus.ForeColor = Color.Green;
                        labblockbox.Text = "无";
                        labblockbox.ForeColor = Color.Green;
                        labblockname.Text = "无";
                        labblockname.ForeColor = Color.Green;
                        Nixielight ni = new Nixielight();
                        ni.SendNull();
                    }



                }
                else
                {
                    try
                    {
                        OpcPlc opcPlc = new OpcPlc();
                        OperateOpcAndSoft.plc = opcPlc;
                    }
                    catch
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                try
                {
                    OperationLog operationLog = OperationLog.NewOperationLog();
                    operationLog.OPERATIONCODE = "出现异常";
                    operationLog.OPERATIONNAME = ex.Message;
                    operationLog.Save();
                }
                catch (Exception)
                {
                    
                    
                }
                
            }
        }

        private void SendTaskPutNiLight(object o)
        {
            try
            {
                Dictionary<int, int> senDictionary = new Dictionary<int, int>();

                senDictionary = opert.GetTaskOutNum(o);

                NixielightSDK.SendByMODBUS(senDictionary);         
            }
            catch (Exception)
            {

                
            }
               
        }

        private void COutPort_Load(object sender, EventArgs e)
        {
            try
            {
                InitPLC();
            }
            catch
            { }
        }


        public void InitPLC()
        {
            try
            {
                OpcPlc opcPlc = new OpcPlc();
                OperateOpcAndSoft.plc = opcPlc;
            }
            catch
            { }
        }

        private void labonesum_Click(object sender, EventArgs e)
        {

        }
    }
}

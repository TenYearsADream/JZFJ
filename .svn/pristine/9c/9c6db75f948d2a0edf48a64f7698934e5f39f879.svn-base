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

namespace MonitorMain.CustomContorl
{
    /// <summary>
    /// 用于显示合单区的监控屏
    /// 数据来源于分拣监控大屏存于数据库的数据
    /// </summary>
    public partial class CPutPort : UserControl
    {
        OutPort _outport;
        OutPort _poutport;
        OutPort _noutport;

        //上层皮带的任务号
        int upindexno = 0;
        int uppindexno = 0;
        int upnindexno = 0;

        //下层皮带的任务号
        int downindexno = 0;
        int downpindexno = 0;
        int downnindexno = 0;


        public string OutPortNo { get; set; }
        public string POutPortNo { get; set; }
        public string NOutPortNo { get; set; }

        string NCustName = "";
        bool isalert = false;

       
        public CPutPort()
        {
            InitializeComponent();
        }

        public void Start()
        {
            
            GetUpPutInfo();
            GetDownPutInfo();
            timer1.Start();
            timer2.Start();

        }

        /// <summary>
        /// 获取上层皮带监控信息
        /// </summary>
        private void GetUpPutInfo()
        {

            //上层皮带当前客户信息
            GetUpCustIndex();
            _outport = new OutPort(upindexno);
            _outport.GetOutPortInfo();

            labelX2.Text = _outport["INDEXNO"];
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
            //上层皮带当前客户的卷烟明细
            itemPanel1.BeginUpdate();
            itemPanel1.Items.Clear();
            _outport = new OutPort(upindexno);

            LabelItem titlelabelItem = new LabelItem();
            titlelabelItem.Text = "当前客户";
            titlelabelItem.TextLineAlignment = StringAlignment.Center;
            titlelabelItem.ItemAlignment = eItemAlignment.Center;
            titlelabelItem.Width = itemPanel1.Width;
            titlelabelItem.Font = new System.Drawing.Font("黑体", 20);
            titlelabelItem.ForeColor = Color.Yellow;
            titlelabelItem.TextLineAlignment = StringAlignment.Center;
            titlelabelItem.Width = itemPanel1.Width;
            titlelabelItem.Height = 35;
            itemPanel1.Items.Add(titlelabelItem);


            List<string> ciginfo = _outport.GetUpCigInfo();
            foreach (string s in ciginfo)
            {
                LabelItem labelItem = new LabelItem();
                labelItem.Text = s.Replace("(", " ").Replace(")", "");
                labelItem.Font = new System.Drawing.Font("黑体", 18);
                if (s.Contains("*"))
                {
                    labelItem.ForeColor = Color.Red;
                }
                else
                {
                    labelItem.ForeColor = Color.Red;
                }
                labelItem.BorderSide = eBorderSide.All;
                labelItem.BorderType = eBorderType.Bump;
                labelItem.TextLineAlignment = StringAlignment.Center;
                labelItem.Width = 305;
                labelItem.Height = 35;
                //labelItem.WordWrap = true;
                itemPanel1.Items.Add(labelItem);
            }
            itemPanel1.EndUpdate();


            //上层皮带下一客户的卷烟明细
            itemPanel2.BeginUpdate();
            itemPanel2.Items.Clear();

            titlelabelItem = new LabelItem();            
            titlelabelItem.Text = "下一客户";
            titlelabelItem.Font = new System.Drawing.Font("黑体", 20);
            titlelabelItem.ForeColor = Color.Yellow;
            titlelabelItem.TextLineAlignment = StringAlignment.Center;
            titlelabelItem.ItemAlignment = eItemAlignment.Center;
            titlelabelItem.Width = itemPanel1.Width;
            titlelabelItem.Height = 35;
            itemPanel2.Items.Add(titlelabelItem);
            _poutport = new OutPort(uppindexno);
            ciginfo = _poutport.GetUpCigInfo();
            foreach (string s in ciginfo)
            {
                LabelItem labelItem = new LabelItem();
                labelItem.Text = s.Replace("(", " ").Replace(")", "");
                labelItem.Font = new System.Drawing.Font("黑体", 18);
                if (s.Contains("*"))
                {
                    labelItem.ForeColor = Color.Red;
                }
                else
                {
                    labelItem.ForeColor = Color.Yellow;
                }
                labelItem.BorderSide = eBorderSide.All;
                labelItem.BorderType = eBorderType.Bump;
                labelItem.TextLineAlignment = StringAlignment.Center;
                labelItem.Width = 305;
                labelItem.Height = 35;
                itemPanel2.Items.Add(labelItem);
            }
            itemPanel2.EndUpdate();
        }

        private void GetDownPutInfo()
        {
            GetDownCustIndex();
            _outport = new OutPort(downindexno);
            _outport.GetOutPortInfo();

            labelX5.Text = _outport["INDEXNO"];
            foreach (Control control in this.panel5.Controls)
            {
                if (control is LabelX && control.Tag != null)
                {
                    if (_outport.ContainsKey(control.Tag.ToString()))
                    {
                        ((LabelX)control).Text = _outport[control.Tag.ToString()];
                    }

                }
            }

            //下层当前客户卷烟
            itemPanel3.BeginUpdate();
            itemPanel3.Items.Clear();
            _outport = new OutPort(downindexno);
            LabelItem titlelabelItem = new LabelItem();
            titlelabelItem.Text = "当前客户";
            titlelabelItem.Font = new System.Drawing.Font("黑体", 20);
            titlelabelItem.ForeColor = Color.Aqua;
            titlelabelItem.TextLineAlignment = StringAlignment.Center;
            titlelabelItem.Width = 305;
            titlelabelItem.Height = 35;
            itemPanel3.Items.Add(titlelabelItem);
            List<string> ciginfo = _outport.GetDownCigInfo();
            foreach (string s in ciginfo)
            {
                LabelItem labelItem = new LabelItem();
                labelItem.Text = s.Replace("(", " ").Replace(")", "");
                labelItem.Font = new System.Drawing.Font("黑体", 18);
                if (s.Contains("*"))
                {
                    labelItem.ForeColor = Color.Red;
                }
                else
                {
                    labelItem.ForeColor = Color.Red;
                }
                labelItem.BorderSide = eBorderSide.All;
                labelItem.BorderType = eBorderType.Bump;
                labelItem.TextLineAlignment = StringAlignment.Center;
                labelItem.Width = 305;
                labelItem.Height = 35;
                labelItem.WordWrap = true;
                itemPanel3.Items.Add(labelItem);
            }
            itemPanel3.EndUpdate();

            //下层下一客户卷烟
            itemPanel4.BeginUpdate();
            itemPanel4.Items.Clear();

            titlelabelItem = new LabelItem();
            titlelabelItem.Text = "下一客户";
            titlelabelItem.Font = new System.Drawing.Font("黑体", 20);
            titlelabelItem.ForeColor = Color.Aqua;
            titlelabelItem.TextLineAlignment = StringAlignment.Center;
            titlelabelItem.Width = 305;
            titlelabelItem.Height = 35;
            itemPanel4.Items.Add(titlelabelItem);
            _noutport = new OutPort(downpindexno);
            ciginfo = _noutport.GetDownCigInfo();
            foreach (string s in ciginfo)
            {
                LabelItem labelItem = new LabelItem();
                labelItem.Text = s.Replace("(", " ").Replace(")", "");
                labelItem.Font = new System.Drawing.Font("黑体", 18);
                if (s.Contains("*"))
                {
                    labelItem.ForeColor = Color.Red;
                }
                else
                {
                    labelItem.ForeColor = Color.Aqua;
                }
                labelItem.BorderSide = eBorderSide.All;
                labelItem.BorderType = eBorderType.Bump;                
                labelItem.TextLineAlignment = StringAlignment.Center;
                labelItem.Width = 305;
                labelItem.Height = 35;
                labelItem.WordWrap = true;
                itemPanel4.Items.Add(labelItem);
            }
            itemPanel4.EndUpdate();

           
            
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            try
            {
                //获取上层下层客户的基本信息
                GetUpPutInfo();
                GetDownPutInfo();

                ////获取平均效率的列表（当天所有打完码的客户）
                //List<PrintInfo> printinfos = PrintBarCodes.GetAVGPrintEffice();
                ////获取当前效率的列表（现在系统所有打完码的客户）
                //List<PrintInfo> cutprintinfos = PrintBarCodes.GetCUTPrintEffice();                

                ////计算当前效率
                //double tzeff = SetEff(cutprintinfos);

                //labcuteffice.Text = tzeff.ToString() + "条/小时";

                //if (labcuteffice.Text.Contains("非数字"))
                //    labcuteffice.Text = "0" + "条/小时";

                ////计算平均效率
                //tzeff = SetEff(printinfos);

                //labavgeffice.Text = tzeff.ToString() + "条/小时";;

                //if (labavgeffice.Text.Contains("非数字"))
                //    labavgeffice.Text = "0" + "条/小时";

                ////计算分拣进度
                //SortingProgress sortingprogress = SortingProgress.GetSortingTaskProgress();
                //prosorting.Maximum = sortingprogress.TotQty;
                //prosorting.Value = sortingprogress.Qty;
                //prosorting.Text = (sortingprogress.Qty + "/" + sortingprogress.TotQty).PadRight(6,' ') +
                //                  Math.Round(
                //                      Convert.ToDouble(sortingprogress.Qty)/Convert.ToDouble(sortingprogress.TotQty), 3)*
                //                  100 + "％";

            }
            catch
            {
            }
        }

       
        /// <summary>
        /// 获取上层皮带流水号对应的客户代码
        /// </summary>
        /// <returns></returns>
        private void GetUpCustIndex()
        {
            try
            {
                upindexno = PutInfo.GetUpPutIndex();// PrintBarCodes.GetPrintIndex();

            }
            catch
            {
            }

            uppindexno = upindexno + 1;
        }

        private string GetUpPCustCigInfo()
        {            
            SortingLineTask sortingLineTask;
            if (upindexno > 0)
            {                
                sortingLineTask = SortingLineTask.GetSortingLineByIndex(uppindexno.ToString());
                return sortingLineTask.CUSTCODE;
                //SortingLineTaskDetails sortingLineTaskDetails = SortingLineTaskDetails.GetSortingLineTaskDetailsByIndex(indexno);
            }
            return "0";
        }


        private void GetDownCustIndex()
        {
            try
            {
                downindexno = PutInfo.GetDownPutIndex();// PrintBarCodes.GetPrintIndex();

            }
            catch
            {
            }
            
            
                downpindexno = downindexno + 1;
            
            
        }

        private string GetDownPCustCigInfo()
        {
            SortingLineTask sortingLineTask;
            if (downindexno > 0)
            {
                sortingLineTask = SortingLineTask.GetSortingLineByIndex(downpindexno.ToString());
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


                //hanglineboxstatus = SortingFault.GetFaultLineBoxStatus();

                //if (hanglineboxstatus != null && hanglineboxstatus.status == 1)
                //{

                //    if (hanglineboxstatus.lineboxcode.ToString() != labblockbox.Text)
                //    {
                //        try
                //        {
                //            OperationLog operationLog = OperationLog.NewOperationLog();
                //            operationLog.OPERATIONCODE = "挂烟";
                //            operationLog.OPERATIONNAME = hanglineboxstatus.lineboxcode.ToString();
                //            operationLog.Save();
                //        }
                //        catch
                //        {
                //        }


                //        labblockbox.Text = hanglineboxstatus.lineboxcode.ToString();
                //        labblockbox.ForeColor = Color.Red;
                //        labboxstatus.ForeColor = Color.Red;
                //        labblockname.ForeColor = Color.Red;
                //        if (SortingLineTaskDetail.GetSortingLineBoxCigNumber(hanglineboxstatus.lineboxcode) == 1)
                //        {
                //            labblockname.Text =
                //                SortingLineTaskDetail.GetSortingLineBoxCigName(hanglineboxstatus.lineboxcode);
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


                lineboxstatus = SortingFault.GetFaultLineBoxStatus();
                if (lineboxstatus != null && (lineboxstatus.status == 4 || lineboxstatus.status == 8 || lineboxstatus.status == 16))
                {
                    if (lineboxstatus.lineboxcode.ToString() != labblockbox.Text)
                    {
                        try
                        {
                            //OperationLog operationLog = OperationLog.NewOperationLog();
                            //if (lineboxstatus.status == 8)
                            //{
                            //    operationLog.OPERATIONCODE = "卡烟";

                            //}
                            //if (lineboxstatus.status == 4)
                            //{
                            //    operationLog.OPERATIONCODE = "缺烟";
                            //}
                            //if (lineboxstatus.status == 16)
                            //{
                            //    operationLog.OPERATIONCODE = "挂烟";
                            //}
                            //operationLog.OPERATIONNAME = lineboxstatus.lineboxcode.ToString();
                            //operationLog.Save();
                        }
                        catch
                        {
                        }


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
                            labputnum.Text = lineboxstatus.putnum.ToString();
                        }
                        if (lineboxstatus.status == 8)
                        {
                            labboxstatus.Text = "卡烟";
                            labputnum.Text = lineboxstatus.putnum.ToString();
                        }
                        if (lineboxstatus.status == 16)
                        {
                            labboxstatus.Text = "挂烟";
                            labputnum.Text = lineboxstatus.putnum.ToString();
                        }
                        
                        Thread thread = new Thread(new ParameterizedThreadStart(PlayBlockSound));
                        thread.Start(lineboxstatus);
                    }

                }
                if (lineboxstatus == null)
                {
                    labboxstatus.Text = "正常";
                    labboxstatus.ForeColor = Color.Green;
                    labblockbox.Text = "无";
                    labblockbox.ForeColor = Color.Green;
                    labblockname.Text = "无";
                    labblockname.ForeColor = Color.Green;
                    labputnum.Text = "0";
                }




            }
            catch (Exception ex)
            {
                OperationLog operationLog = OperationLog.NewOperationLog();
                operationLog.OPERATIONCODE = "出现异常";
                operationLog.OPERATIONNAME = ex.Message.Substring(0, 250);
                operationLog.Save();
            }

        }


    }
}

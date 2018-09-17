﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using HDWLogic;
using PlcContract;
//using SocketCommunication;

namespace MonitorMain
{
    public partial class SLogoForm : Office2007RibbonForm
    {
        public SLogoForm()
        {
            InitializeComponent();
        }

        

        private void SLogoForm_Load(object sender, EventArgs e)
        {
            if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "分拣")
            {
                labsystitle.Text = "<b><font size='+6'>物流分拣任务系统</font></b>";

            }
            if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "补货")
            {
                labsystitle.Text = "<b><font size='+6'>物流补货任务系统</font></b>";
            }


            


            reflectionLabel2.Text = "初始化PLC连接...";
            Thread thread = new Thread(InitPLC);
            thread.Start();

            //reflectionLabel2.Text = "初始化电子标签...";
            
        }

       


        private void InitSocket()
        {
            //SocketManager.Instance.Initialize(ConvertType.Xml);
            //SocketManager.Instance.ConnectServer();
        }

        private void InitPLC()
        {
            try
            {
                OpcPlc opcPlc = new OpcPlc();
                OperateOpcAndSoft.plc = opcPlc;
            }
            catch (Exception ex)
            {
                if (
                    MessageBox.Show("初始化PLC出现错误！是否退出查明原因？" + Environment.NewLine + ex.Message, "错误",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Environment.Exit(1);
                }
            }
            //////Thread.Sleep(1000);
            DialogResult = DialogResult.OK;
            this.BeginInvoke(new Action(Close));
        }
    }
}

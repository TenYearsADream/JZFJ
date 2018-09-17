using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace MonitorMain.CustomContorl
{
    public partial class CLog : UserControl
    {
        private DataEvenArgs dataEvenArgs;
       public CLog()
       {
           InitializeComponent();
           MonitorLog.OnLogCreate += new EventHandler<DataEvenArgs>(MonitorLog_OnLogCreate);
           txtLog.ReadOnly = true;
       }

       void MonitorLog_OnLogCreate(object sender, DataEvenArgs e)
       {
           dataEvenArgs = e;
           if(!this.InvokeRequired)
                SetLog();
           else
           {
               this.Invoke(new Action(SetLog));
           }
       }

        private void SetLog()
        {
            txtLog.SelectionStart = txtLog.Text.Length; //设置插入符位置为文本框末
            txtLog.SelectionColor = dataEvenArgs.Color; //设置文本颜色
            txtLog.AppendText(dataEvenArgs.Createtime.ToString().PadRight(20) + dataEvenArgs.Type.PadRight(10) + dataEvenArgs.Logname.PadRight(10) +
                              dataEvenArgs.Loginfo + Environment.NewLine); //输出文本，换行
            txtLog.ScrollToCaret(); //滚动条滚到到最新插入行
        }

        

        private void CLog_Load(object sender, EventArgs e)
       {
           
       }
    }

    
}

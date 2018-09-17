using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Search;
using DevComponents.DotNetBar;

namespace MonitorMain.CustomContorl
{
    public partial class CDisplayCigName : UserControl
    {
        Dictionary<string, PanelEx> panelExs = new Dictionary<string, PanelEx>();
        public CDisplayCigName()
        {
            InitializeComponent();
            panelExs.Add("67", panelEx67);
            panelExs.Add("68", panelEx68);
            panelExs.Add("69", panelEx69);
            panelExs.Add("70", panelEx70);
            panelExs.Add("71", panelEx71);
            panelExs.Add("72", panelEx72);
            panelExs.Add("73", panelEx73);
            panelExs.Add("74", panelEx74);
        }

        private void CDisplayCigName_Load(object sender, EventArgs e)
        {
            LoadCig();
        }

        private void LoadCig()
        {
            LineBoxProcessList lineBoxProcessList = LineBoxProcessList.GetList(ConfigurationSettings.AppSettings["Mode"].ToLower());

            foreach (LineBoxProcessInfo lineBoxProcessInfo in lineBoxProcessList)
            {
                if (panelExs.ContainsKey(lineBoxProcessInfo.LINEBOXCODE))
                {
                    panelExs[lineBoxProcessInfo.LINEBOXCODE].Text = lineBoxProcessInfo.LINEBOXNAME + Environment.NewLine;
                    panelExs[lineBoxProcessInfo.LINEBOXCODE].Text += Environment.NewLine;
                    panelExs[lineBoxProcessInfo.LINEBOXCODE].Text += lineBoxProcessInfo.CigName + Environment.NewLine;
                    panelExs[lineBoxProcessInfo.LINEBOXCODE].Text += Environment.NewLine;
                    panelExs[lineBoxProcessInfo.LINEBOXCODE].Text += lineBoxProcessInfo.FINQTY + "|" + lineBoxProcessInfo.NONQTY +
                                                                     Environment.NewLine;
                    panelExs[lineBoxProcessInfo.LINEBOXCODE].Text += Environment.NewLine;
                    panelExs[lineBoxProcessInfo.LINEBOXCODE].Text += lineBoxProcessInfo.TOTQTY;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadCig();
        }
    }
}

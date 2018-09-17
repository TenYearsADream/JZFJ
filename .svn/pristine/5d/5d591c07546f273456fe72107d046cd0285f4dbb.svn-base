using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessLogic.Download;
using BusinessLogic.SortingProcess;
using BusinessLogic.SortingTask;
using DevComponents.DotNetBar;

namespace MonitorMain.CustomContorl.Search
{
    public partial class CSortingEfficiencyDis : UserControl
    {
        private SortingProgress sortingProgress;
        private Dictionary<string, string> soDictionary;

        public CSortingEfficiencyDis()
        {
            InitializeComponent();
            dateTimeInput1.Value = DateTime.Now.AddDays(-1);
        }

        private void CSortingEfficiencyDis_Load(object sender, EventArgs e)
        {
            customButton1.Pulse(10);            
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            soDictionary = null;
            string batch = null;
            string linecode = null;
            if (!string.IsNullOrEmpty(cobbatch.SelectedValue as string))
            {
                batch = cobbatch.SelectedValue as string;
            }
            if (!string.IsNullOrEmpty(cobSortingLine.SelectedValue as string))
            {
                linecode = cobSortingLine.SelectedValue as string;
            }

            soDictionary = SortingProgress.GetSortingProcessInfo(dateTimeInput1.Value.ToString("yyyy-MM-dd"), batch, linecode);
            foreach (Control control in panelEx2.Controls)
            {
                if (control is LabelX)
                {
                    var labelX = (LabelX)control as LabelX;
                    if (labelX.Tag != null)
                    {
                        try
                        {
                            labelX.Text = soDictionary[labelX.Tag.ToString()];
                        }
                        catch (Exception)
                        {
                        }
                        
                    }    
                }
            }

            
            Thread thread = new Thread(StartProgress);
            thread.Start();
            try
            {
                labProcess.Text = soDictionary["QTY_PRODUCT"] + "/" + soDictionary["QTY_PRODCUT_TOT"] + "条 - " + soDictionary["Progress"] + "%";
            }
            catch
            { }
        }

        //计算仪表盘的动画
        private void StartProgress()
        {
            int progress = 0;
            try
            {
                progress = Convert.ToInt32(Convert.ToDouble(soDictionary["QTY_PRODUCT"]) / Convert.ToDouble(soDictionary["QTY_PRODCUT_TOT"]) * 100);
            }
            catch
            {
            }
            if (progress > 100 - 5)
            {
                for (int i = 1; i <= progress; i++)
                {
                    knobControl1.Value = i;
                    Thread.Sleep(10);
                }
            }
            else
            {
                for (int i = 1; i <= progress + 5; i++)
                {
                    knobControl1.Value = i;
                    Thread.Sleep(10);
                }

                for (int i = 1; i <= 5; i++)
                {
                    knobControl1.Value = progress + 5 - i;
                    Thread.Sleep(50);
                }
            }
            
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            cobbatch.SelectedText = "";
            cobbatch.SelectedValue = "";
            cobbatch.Text = "";
            cobbatch.DataSource = TaskBatchList.GetTaskBatchs(dateTimeInput1.Value.Date.ToString("yyyy-MM-dd"), false);
            cobSortingLine.DataSource = SortingLineList.GetSortingLines(false);
        }
    }
}

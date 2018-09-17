﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.SortingTask;
using MonitorMain.CustomContorl;

namespace MonitorMain
{
    public partial class frmEditCubeLocation : Form
    {
        private int _width;
        public static event EventHandler<EventArgs> OnUpdateCSortingMainCubeEvent;

        public frmEditCubeLocation(int width)
        {
            InitializeComponent();
            _width = width;
        }

        private void frmEditCubeLocation_Load(object sender, EventArgs e)
        {
            LoadTask();
        }

        private void LoadTask()
        {
            flowLayoutPanel1.Controls.Clear();
            //获取小车的数据模型
            SortingLineTaskQueue.GetInstance().LoadSortingLineTasks();
            foreach (SortingLineTask sortingLineTask in SortingLineTaskQueue.GetInstance().SortingLineTasks)
            {
                if (sortingLineTask != null)
                {
                    CTask cuCTask = new CTask();
                    cuCTask.labindexno.Text = sortingLineTask.INDEXNO.ToString();
                    cuCTask.labcustname.Text = sortingLineTask.ShortName;
                    cuCTask.txtlocation.DataBindings.Add(new Binding("value", sortingLineTask, "PLCADDRESS"));
                    cuCTask.Width = _width;
                    flowLayoutPanel1.Controls.Add(cuCTask);
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            foreach (SortingLineTask sortingLineTask in SortingLineTaskQueue.GetInstance().SortingLineTasks)
            {
                if (sortingLineTask != null && sortingLineTask.INDEXNO > 0)
                {
                    sortingLineTask.SaveSortingTaskProcess(sortingLineTask.ID);
                }
            }
            LoadTask();
            SortingLineTaskQueue.GetInstance().CreateCubesModel();
            //更新前台小车控件的信息
            if (OnUpdateCSortingMainCubeEvent != null)
            {
                OnUpdateCSortingMainCubeEvent.Invoke(this, new EventArgs());
            }
        }
    }
}

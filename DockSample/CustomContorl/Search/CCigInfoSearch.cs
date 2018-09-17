using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Common;
using BusinessLogic.Test;

namespace MonitorMain.CustomContorl.Search
{
    public partial class CCigInfoSearch : Form
    {
        private string _lineboxcode;
        public event EventHandler BindCigComplete;

        public CCigInfoSearch()
        {
            InitializeComponent();
        }

        public CCigInfoSearch(string lineboxcode)
        {
            InitializeComponent();
            _lineboxcode = lineboxcode;
        }

        

        private void txtCigCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
	            if (!string.IsNullOrEmpty(txtCigCode.Text.Trim()))
	            {
                    CigInfoList cigInfoList = CigInfoList.GetCigList(txtCigCode.Text.Trim());
                    dgvSortingCig.DataSource = cigInfoList;
	            }
	            else
	            {
                    CigInfoList cigInfoList = CigInfoList.GetCigList();
                    dgvSortingCig.DataSource = cigInfoList;
	            }
               
            }
        }

        private void CCigInfoSearch_Load(object sender, EventArgs e)
        {
            CigInfoList cigInfoList = CigInfoList.GetCigList();
            dgvSortingCig.DataSource = cigInfoList;
        }

        private void dgvSortingCig_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否选择当前卷烟？","提示",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int index = dgvSortingCig.CurrentRow.Index;
                    txt_cigcode.Text = dgvSortingCig.Rows[index].Cells["cIGARETTENODataGridViewTextBoxColumn"].Value.ToString();
                    txt_cigname.Text = dgvSortingCig.Rows[index].Cells["cIGARETTENAMEDataGridViewTextBoxColumn"].Value.ToString();
                    txt_barcode.Text = dgvSortingCig.Rows[index].Cells["bARCODEDataGridViewTextBoxColumn"].Value.ToString();
                    
                }
                catch { }
            }
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cigcode.Text.Trim()) && !string.IsNullOrEmpty(txt_cigname.Text.Trim()) && !string.IsNullOrEmpty(txt_barcode.Text.Trim()) && int_num.Value > 0) 
            {
                CreateTest createTest = new CreateTest();
                createTest.CreateTMTest(txt_cigcode.Text.Trim(), txt_barcode.Text.Trim(), txt_cigname.Text.Trim(),int_num.Value);
                MessageBox.Show("生成成功！");
                FJMainForm.Instance.cSortingTask.ReLoad();
            }
            else
            {
                MessageBox.Show("信息不全！");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否进行清除数据？","",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CreateTest createTest = new CreateTest();
                createTest.DeleteTM();
                MessageBox.Show("清除成功！");
                FJMainForm.Instance.cSortingTask.ReLoad();
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cigcode.Text.Trim()) && !string.IsNullOrEmpty(txt_cigname.Text.Trim()) && !string.IsNullOrEmpty(txt_barcode.Text.Trim()) && int_num.Value > 0)
            {
                CreateTest createTest = new CreateTest();
                createTest.CreateLSTMTest(txt_cigcode.Text.Trim(), txt_barcode.Text.Trim(), txt_cigname.Text.Trim(), int_num.Value);
                MessageBox.Show("生成成功！");
                FJMainForm.Instance.cSortingTask.ReLoad();
            }
            else
            {
                MessageBox.Show("信息不全！");
            }
        }

        
    }

    
}

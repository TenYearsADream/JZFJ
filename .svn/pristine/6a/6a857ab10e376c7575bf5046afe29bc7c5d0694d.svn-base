using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Text.RegularExpressions;

namespace KeerSolutions.MobileCommerce.AutoUpdate
{
    /// <summary>
    /// 设置
    /// </summary>
    public partial class SettingForm : Form
    {
        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        public SettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strIPAddress"></param>
        /// <param name="port"></param>
        public SettingForm(string strIPAddress,string port)
        {
            InitializeComponent();
            txtIPAddress.Text = strIPAddress;
            txtIPAddress.Tag = strIPAddress;
            txtPort.Text = port;
            txtPort.Tag = port;
        }
        #endregion

        #region 保存设置
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strIPAddress = txtIPAddress.Text.Trim();
            string strPort = txtPort.Text.Trim();
            //此处验证
            string pattern = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
            if (!new Regex(pattern).IsMatch(strIPAddress))
            {
                MessageBox.Show("IP地址无效！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int port=0;
            if (!int.TryParse(strPort, out port) || port == 0)
            {
                MessageBox.Show("端口配置无效！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.Compare(strIPAddress, txtIPAddress.Tag.ToString()) == 0 && string.Compare(strPort, txtPort.Tag.ToString()) == 0)
            {
                MessageBox.Show("配置没有更改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //验证通过
            XmlDocument doc = new XmlDocument();
            try
            {
                string strFileName = AppDomain.CurrentDomain.BaseDirectory + "AutoUpdate.exe.config";
                doc.Load(strFileName);
                //找出名称为“add”的所有元素
                XmlNodeList nodes = doc.GetElementsByTagName("client");
                nodes = nodes[0].ChildNodes;
                for (int i = 0; i < nodes.Count; i++)
                {
                    switch (nodes[i].Name)
                    {
                        case "endpoint":
                            nodes[i].Attributes["address"].Value = "http://" + strIPAddress + ":" + strPort + "/AutoUpdate.asmx";
                            break;
                        default:
                            break;
                    }
                }
                doc.Save(AppDomain.CurrentDomain.BaseDirectory + "AutoUpdate.exe.config");
                if (MessageBox.Show("保存完成,要马上重启动吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Application.Restart();    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

    }
}

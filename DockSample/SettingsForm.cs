using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppUtility;
using BusinessLogic.Configuration;
using BusinessLogic.Download;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using MySql.Data.MySqlClient;

namespace MonitorMain
{
    public partial class SettingsForm : Office2007Form
    {
        private Dictionary<string, Control> FormControls = new Dictionary<string, Control>();
        private Settings settings;
        private string _mode;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void LoadSettings()
        {
            try
            {
                foreach (Control control in groupPanel1.Controls)
                {
                    if (control is IpAddressInput)
                    {
                        var ipAddressInput = (IpAddressInput) control as IpAddressInput;
                        ipAddressInput.Value = ConfigurationSettings.AppSettings[ipAddressInput.Tag.ToString()];
                    }
                    if (control is TextBoxX)
                    {
                        var textbox = (TextBoxX)control as TextBoxX;
                        textbox.Text = ConfigurationSettings.AppSettings[textbox.Tag.ToString()];
                    }
                }


                foreach (Control control in groupPanel2.Controls)
                {
                    if (control is IpAddressInput)
                    {
                        var ipAddressInput = (IpAddressInput)control as IpAddressInput;
                        ipAddressInput.Value = ConfigurationSettings.AppSettings[ipAddressInput.Tag.ToString()];
                    }
                    if (control is TextBoxX)
                    {
                        var textbox = (TextBoxX)control as TextBoxX;
                        textbox.Text = ConfigurationSettings.AppSettings[textbox.Tag.ToString()];
                    }
                }

                foreach (Control control in groupPanel3.Controls)
                {
                    if (control is IpAddressInput)
                    {
                        var ipAddressInput = (IpAddressInput)control as IpAddressInput;
                        ipAddressInput.Value = ConfigurationSettings.AppSettings[ipAddressInput.Tag.ToString()];
                    }
                    if (control is TextBoxX)
                    {
                        var textbox = (TextBoxX)control as TextBoxX;
                        textbox.Text = ConfigurationSettings.AppSettings[textbox.Tag.ToString()];
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }




            if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "分拣")
            {
                _mode = "分拣";
                checkBoxX1.Checked = true;
            }
            if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "补货")
            {
                _mode = "补货";
                checkBoxX2.Checked = true;
            }
            if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "出口屏1")
            {
                _mode = "出口屏1";
                checkBoxX3.Checked = true;
            }
            if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "出口屏2")
            {
                _mode = "出口屏2";
                checkBoxX4.Checked = true;
            }
            if (ConfigurationSettings.AppSettings["Mode"].ToLower() == "补货屏")
            {
                _mode = "补货屏";
                checkBoxX6.Checked = true;
            }

        }

        private void SaveSettings()
        {
            //foreach (var formControl in FormControls)
            //{
            //    if (formControl.Value is TextBoxX)
            //    {
            //        settings.GetSettingByName(formControl.Key).Value = ((TextBoxX) formControl.Value).Text;
            //    }

            //    if (formControl.Value is IpAddressInput)
            //    {
            //        settings.GetSettingByName(formControl.Key).Value = ((IpAddressInput)formControl.Value).Value;
            //    }
            //    if (formControl.Value is CheckBoxX)
            //    {
            //        if (settings.GetSettingByName(formControl.Key) != null)
            //        {
            //            settings.GetSettingByName(formControl.Key).Value = ((CheckBoxX)formControl.Value).Checked.ToString();
            //        }
            //    }
            //    if (formControl.Value is ComboBoxEx)
            //    {
            //        if (settings.GetSettingByName(formControl.Key) != null)
            //        {
            //            settings.GetSettingByName(formControl.Key).Value = ((ComboBoxEx)formControl.Value).SelectedValue.ToString();
            //        }
            //    }
            //}

            Configuration config;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (Control control in groupPanel1.Controls)
            {
                if (control is IpAddressInput)
                {
                    var ipAddressInput = (IpAddressInput)control as IpAddressInput;
                    

                    if (config.AppSettings.Settings[ipAddressInput.Tag.ToString()] == null)
                    {
                        config.AppSettings.Settings.Add(ipAddressInput.Tag.ToString(), ipAddressInput.Value);
                        config.Save();
                    }
                    else
                    {
                        config.AppSettings.Settings[ipAddressInput.Tag.ToString()].Value = ipAddressInput.Value;
                        config.Save(ConfigurationSaveMode.Modified);    
                    }
                    
                    ConfigurationManager.RefreshSection("appSettings");
                }
                if (control is TextBoxX)
                {
                    var textbox = (TextBoxX)control as TextBoxX;

                    if (config.AppSettings.Settings[textbox.Tag.ToString()] == null)
                    {
                        config.AppSettings.Settings.Add(textbox.Tag.ToString(), textbox.Text);
                        config.Save();
                    }
                    else
                    {
                        config.AppSettings.Settings[textbox.Tag.ToString()].Value = textbox.Text;
                        config.Save(ConfigurationSaveMode.Modified);
                    }
                }
            }


            foreach (Control control in groupPanel2.Controls)
            {
                if (control is IpAddressInput)
                {
                    var ipAddressInput = (IpAddressInput)control as IpAddressInput;


                    if (config.AppSettings.Settings[ipAddressInput.Tag.ToString()] == null)
                    {
                        config.AppSettings.Settings.Add(ipAddressInput.Tag.ToString(), ipAddressInput.Value);
                        config.Save();
                    }
                    else
                    {
                        config.AppSettings.Settings[ipAddressInput.Tag.ToString()].Value = ipAddressInput.Value;
                        config.Save(ConfigurationSaveMode.Modified);
                    }

                    ConfigurationManager.RefreshSection("appSettings");
                }
                if (control is TextBoxX)
                {
                    var textbox = (TextBoxX)control as TextBoxX;

                    if (config.AppSettings.Settings[textbox.Tag.ToString()] == null)
                    {
                        config.AppSettings.Settings.Add(textbox.Tag.ToString(), textbox.Text);
                        config.Save();
                    }
                    else
                    {
                        config.AppSettings.Settings[textbox.Tag.ToString()].Value = textbox.Text;
                        config.Save(ConfigurationSaveMode.Modified);
                    }
                }
            }

            foreach (Control control in groupPanel3.Controls)
            {
                if (control is IpAddressInput)
                {
                    var ipAddressInput = (IpAddressInput)control as IpAddressInput;


                    if (config.AppSettings.Settings[ipAddressInput.Tag.ToString()] == null)
                    {
                        config.AppSettings.Settings.Add(ipAddressInput.Tag.ToString(), ipAddressInput.Value);
                        config.Save();
                    }
                    else
                    {
                        config.AppSettings.Settings[ipAddressInput.Tag.ToString()].Value = ipAddressInput.Value;
                        config.Save(ConfigurationSaveMode.Modified);
                    }

                    ConfigurationManager.RefreshSection("appSettings");
                }
                if (control is TextBoxX)
                {
                    var textbox = (TextBoxX)control as TextBoxX;

                    if (config.AppSettings.Settings[textbox.Tag.ToString()] == null)
                    {
                        config.AppSettings.Settings.Add(textbox.Tag.ToString(), textbox.Text);
                        config.Save();
                    }
                    else
                    {
                        config.AppSettings.Settings[textbox.Tag.ToString()].Value = textbox.Text;
                        config.Save(ConfigurationSaveMode.Modified);
                    }
                }
            }


            //AppUtil.UpdateConnectionStringsConfig("MonitorString",
            //                                      "Server=" + locationip + ";Port=" + LocationPort + ";Database=" + locationdatabase + ";Uid=" +
            //                                      LocationUid + ";Pwd=" + LocationPwd + ";");

            //AppUtil.UpdateConnectionStringsConfig("FjIntoString",
            //                                     "Server=" + ServerIP  + ";Port=" + ServerPort + ";Database=" + ServerDatabase + ";Uid=" +
            //                                     ServerUid + ";Pwd=" + ServerPwd + ";");

            //config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["Mode"].Value = _mode;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            

            MessageBox.Show("设置保存成功,程序需要重新启动！");
            Process p = new Process();
            p.StartInfo.FileName = "MonitorMain.exe";//需要启动的程序名       
            p.Start();//启动 

            System.Environment.Exit(1);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadControl();
            LoadSettings();
        }

        private void LoadControl()
        {
            foreach (Control control in groupPanel1.Controls)
            {
                if (control.Tag != null)
                {
                    FormControls.Add(control.Tag.ToString().ToLower(), control);
                }
            }
            foreach (Control control in groupPanel2.Controls)
            {
                if (control.Tag != null)
                    FormControls.Add(control.Tag.ToString().ToLower(), control);
            }
            foreach (Control control in groupPanel3.Controls)
            {
                if (control.Tag != null)
                    FormControls.Add(control.Tag.ToString().ToLower(), control);
            }
            

            //cobSortingline.SelectedValue = settings.GetSettingByName("LineCode");
        }

        private void btiSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            _mode = checkBoxX1.Tag.ToString();
        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            _mode = checkBoxX2.Tag.ToString();
        }

        private void checkBoxX3_CheckedChanged(object sender, EventArgs e)
        {
            _mode = checkBoxX3.Tag.ToString();
        }

        private void checkBoxX4_CheckedChanged(object sender, EventArgs e)
        {
            _mode = checkBoxX4.Tag.ToString();
        }

        private void checkBoxX6_CheckedChanged(object sender, EventArgs e)
        {
            _mode = checkBoxX6.Tag.ToString();
        }

        private void textBoxX8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX9_TextChanged(object sender, EventArgs e)
        {

        }

        private void ipAddressInput4_Click(object sender, EventArgs e)
        {

        }

        private void ipAddressInput3_Click(object sender, EventArgs e)
        {

        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void labelX10_Click(object sender, EventArgs e)
        {

        }

        private void labelX11_Click(object sender, EventArgs e)
        {

        }

        private void labelX12_Click(object sender, EventArgs e)
        {

        }

        private void labelX13_Click(object sender, EventArgs e)
        {

        }

        private void sortingLineListBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}

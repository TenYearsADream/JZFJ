﻿using System.Windows.Forms;

namespace MonitorMain.CustomContorl
{
    partial class C_SortingMain
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cubeLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bottom = new System.Windows.Forms.TableLayoutPanel();
            this.f8 = new System.Windows.Forms.FlowLayoutPanel();
            this.f7 = new System.Windows.Forms.FlowLayoutPanel();
            this.f6 = new System.Windows.Forms.FlowLayoutPanel();
            this.f5 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.top = new System.Windows.Forms.TableLayoutPanel();
            this.f4 = new System.Windows.Forms.FlowLayoutPanel();
            this.f2 = new System.Windows.Forms.FlowLayoutPanel();
            this.f3 = new System.Windows.Forms.FlowLayoutPanel();
            this.f1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.btnissued = new DevComponents.DotNetBar.ButtonX();
            this.btnedit = new DevComponents.DotNetBar.ButtonX();
            this.btnrefresh = new DevComponents.DotNetBar.ButtonX();
            this.chkshowname = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkshowqty = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            this.bottom.SuspendLayout();
            this.top.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cubeLayoutPanel);
            this.panel3.Controls.Add(this.bottom);
            this.panel3.Controls.Add(this.top);
            this.panel3.Controls.Add(this.panelEx4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1161, 464);
            this.panel3.TabIndex = 2;
            // 
            // cubeLayoutPanel
            // 
            this.cubeLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1158F));
            this.cubeLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeLayoutPanel.Location = new System.Drawing.Point(0, 429);
            this.cubeLayoutPanel.Name = "cubeLayoutPanel";
            this.cubeLayoutPanel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cubeLayoutPanel.RowCount = 1;
            this.cubeLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cubeLayoutPanel.Size = new System.Drawing.Size(1161, 35);
            this.cubeLayoutPanel.TabIndex = 6;
            // 
            // bottom
            // 
            this.bottom.ColumnCount = 3;
            this.bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.bottom.Controls.Add(this.f8, 2, 1);
            this.bottom.Controls.Add(this.f7, 0, 1);
            this.bottom.Controls.Add(this.f6, 2, 0);
            this.bottom.Controls.Add(this.f5, 0, 0);
            this.bottom.Controls.Add(this.panel4, 1, 0);
            this.bottom.Controls.Add(this.panel5, 1, 1);
            this.bottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottom.Location = new System.Drawing.Point(0, 229);
            this.bottom.Name = "bottom";
            this.bottom.RowCount = 2;
            this.bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bottom.Size = new System.Drawing.Size(1161, 200);
            this.bottom.TabIndex = 11;
            // 
            // f8
            // 
            this.f8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f8.Location = new System.Drawing.Point(1164, 100);
            this.f8.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.f8.Name = "f8";
            this.f8.Size = new System.Drawing.Size(1, 97);
            this.f8.TabIndex = 21;
            this.f8.Visible = false;
            this.f8.WrapContents = false;
            // 
            // f7
            // 
            this.f7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f7.Location = new System.Drawing.Point(3, 100);
            this.f7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.f7.Name = "f7";
            this.f7.Size = new System.Drawing.Size(1155, 97);
            this.f7.TabIndex = 20;
            this.f7.WrapContents = false;
            // 
            // f6
            // 
            this.f6.BackColor = System.Drawing.Color.Silver;
            this.f6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f6.Location = new System.Drawing.Point(1164, 3);
            this.f6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.f6.Name = "f6";
            this.f6.Size = new System.Drawing.Size(1, 97);
            this.f6.TabIndex = 19;
            this.f6.Visible = false;
            this.f6.WrapContents = false;
            // 
            // f5
            // 
            this.f5.BackColor = System.Drawing.Color.Silver;
            this.f5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f5.Location = new System.Drawing.Point(3, 3);
            this.f5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.f5.Name = "f5";
            this.f5.Size = new System.Drawing.Size(1155, 97);
            this.f5.TabIndex = 18;
            this.f5.WrapContents = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1164, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 94);
            this.panel4.TabIndex = 17;
            this.panel4.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1164, 103);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 94);
            this.panel5.TabIndex = 17;
            this.panel5.Visible = false;
            // 
            // top
            // 
            this.top.ColumnCount = 3;
            this.top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.top.Controls.Add(this.f4, 3, 1);
            this.top.Controls.Add(this.f2, 2, 0);
            this.top.Controls.Add(this.f3, 0, 1);
            this.top.Controls.Add(this.f1, 0, 0);
            this.top.Controls.Add(this.panel1, 1, 0);
            this.top.Controls.Add(this.panel2, 1, 1);
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.Location = new System.Drawing.Point(0, 29);
            this.top.Name = "top";
            this.top.RowCount = 1;
            this.top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.top.Size = new System.Drawing.Size(1161, 200);
            this.top.TabIndex = 10;
            // 
            // f4
            // 
            this.f4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f4.Location = new System.Drawing.Point(1164, 100);
            this.f4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.f4.Name = "f4";
            this.f4.Size = new System.Drawing.Size(1, 97);
            this.f4.TabIndex = 18;
            this.f4.Visible = false;
            this.f4.WrapContents = false;
            // 
            // f2
            // 
            this.f2.BackColor = System.Drawing.Color.Silver;
            this.f2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f2.Location = new System.Drawing.Point(1164, 3);
            this.f2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.f2.Name = "f2";
            this.f2.Size = new System.Drawing.Size(1, 97);
            this.f2.TabIndex = 16;
            this.f2.Visible = false;
            this.f2.WrapContents = false;
            // 
            // f3
            // 
            this.f3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f3.Location = new System.Drawing.Point(3, 100);
            this.f3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.f3.Name = "f3";
            this.f3.Size = new System.Drawing.Size(1155, 97);
            this.f3.TabIndex = 15;
            this.f3.WrapContents = false;
            // 
            // f1
            // 
            this.f1.BackColor = System.Drawing.Color.Silver;
            this.f1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.f1.Location = new System.Drawing.Point(3, 3);
            this.f1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.f1.Name = "f1";
            this.f1.Size = new System.Drawing.Size(1155, 97);
            this.f1.TabIndex = 9;
            this.f1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1164, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 94);
            this.panel1.TabIndex = 17;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1164, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 94);
            this.panel2.TabIndex = 17;
            this.panel2.Visible = false;
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.btnissued);
            this.panelEx4.Controls.Add(this.btnedit);
            this.panelEx4.Controls.Add(this.btnrefresh);
            this.panelEx4.Controls.Add(this.chkshowname);
            this.panelEx4.Controls.Add(this.chkshowqty);
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx4.Location = new System.Drawing.Point(0, 0);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(1161, 29);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 9;
            // 
            // btnissued
            // 
            this.btnissued.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnissued.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnissued.Image = global::MonitorMain.Properties.Resources._20140808095338424_easyicon_net_48;
            this.btnissued.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnissued.Location = new System.Drawing.Point(287, 5);
            this.btnissued.Name = "btnissued";
            this.btnissued.Size = new System.Drawing.Size(106, 20);
            this.btnissued.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnissued.TabIndex = 2;
            this.btnissued.Text = "分户盒信号";
            this.btnissued.Click += new System.EventHandler(this.btnissued_Click);
            // 
            // btnedit
            // 
            this.btnedit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnedit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnedit.Image = global::MonitorMain.Properties.Resources._20101012075538848_easyicon_cn_32;
            this.btnedit.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btnedit.Location = new System.Drawing.Point(406, 5);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(60, 20);
            this.btnedit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnedit.TabIndex = 2;
            this.btnedit.Text = "编辑";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnrefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnrefresh.Image = global::MonitorMain.Properties.Resources._20101012082627362_easyicon_cn_16;
            this.btnrefresh.Location = new System.Drawing.Point(208, 5);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(60, 20);
            this.btnrefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnrefresh.TabIndex = 2;
            this.btnrefresh.Text = "刷新";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // chkshowname
            // 
            this.chkshowname.AutoSize = true;
            // 
            // 
            // 
            this.chkshowname.BackgroundStyle.Class = "";
            this.chkshowname.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkshowname.Location = new System.Drawing.Point(6, 8);
            this.chkshowname.Name = "chkshowname";
            this.chkshowname.Size = new System.Drawing.Size(76, 18);
            this.chkshowname.TabIndex = 1;
            this.chkshowname.Text = "显示品牌";
            this.chkshowname.CheckedChanged += new System.EventHandler(this.chkshowname_CheckedChanged);
            // 
            // chkshowqty
            // 
            this.chkshowqty.AutoSize = true;
            // 
            // 
            // 
            this.chkshowqty.BackgroundStyle.Class = "";
            this.chkshowqty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkshowqty.Location = new System.Drawing.Point(103, 8);
            this.chkshowqty.Name = "chkshowqty";
            this.chkshowqty.Size = new System.Drawing.Size(76, 18);
            this.chkshowqty.TabIndex = 1;
            this.chkshowqty.Text = "显示容量";
            this.chkshowqty.CheckedChanged += new System.EventHandler(this.chkshowqty_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // C_SortingMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "C_SortingMain";
            this.Size = new System.Drawing.Size(1161, 464);
            this.Load += new System.EventHandler(this.C_SortingMain_Load);
            this.panel3.ResumeLayout(false);
            this.bottom.ResumeLayout(false);
            this.top.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private TableLayoutPanel cubeLayoutPanel;
        private Timer timer1;
        private TableLayoutPanel bottom;
        private FlowLayoutPanel f8;
        private FlowLayoutPanel f7;
        private FlowLayoutPanel f6;
        private FlowLayoutPanel f5;
        private Panel panel4;
        private Panel panel5;
        private TableLayoutPanel top;
        private FlowLayoutPanel f4;
        private FlowLayoutPanel f2;
        private FlowLayoutPanel f3;
        private FlowLayoutPanel f1;
        private Panel panel1;
        private Panel panel2;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.ButtonX btnissued;
        private DevComponents.DotNetBar.ButtonX btnedit;
        private DevComponents.DotNetBar.ButtonX btnrefresh;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkshowname;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkshowqty;
       
    }
}

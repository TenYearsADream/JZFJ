namespace MonitorMain.CustomContorl
{
    partial class C_Cube
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
            this.panelno = new DevComponents.DotNetBar.PanelEx();
            this.labfinnum = new DevComponents.DotNetBar.LabelX();
            this.labcustname = new DevComponents.DotNetBar.LabelX();
            this.labindexno = new DevComponents.DotNetBar.LabelX();
            this.superTooltip1 = new DevComponents.DotNetBar.SuperTooltip();
            this.panelno.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelno
            // 
            this.panelno.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelno.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelno.Controls.Add(this.labfinnum);
            this.panelno.Controls.Add(this.labcustname);
            this.panelno.Controls.Add(this.labindexno);
            this.panelno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelno.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelno.Location = new System.Drawing.Point(0, 0);
            this.panelno.Name = "panelno";
            this.panelno.Size = new System.Drawing.Size(122, 150);
            this.panelno.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelno.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelno.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.BottomLeft;
            this.panelno.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelno.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelno.Style.ForeColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panelno.Style.GradientAngle = 90;
            this.panelno.Style.LineAlignment = System.Drawing.StringAlignment.Near;
            this.panelno.TabIndex = 0;
            this.panelno.TextDockConstrained = false;
            // 
            // labfinnum
            // 
            // 
            // 
            // 
            this.labfinnum.BackgroundStyle.Class = "";
            this.labfinnum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labfinnum.Dock = System.Windows.Forms.DockStyle.Top;
            this.labfinnum.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labfinnum.Location = new System.Drawing.Point(0, 71);
            this.labfinnum.Name = "labfinnum";
            this.labfinnum.Size = new System.Drawing.Size(122, 17);
            this.labfinnum.TabIndex = 2;
            this.labfinnum.Text = "100";
            this.labfinnum.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labcustname
            // 
            // 
            // 
            // 
            this.labcustname.BackgroundStyle.Class = "";
            this.labcustname.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labcustname.Dock = System.Windows.Forms.DockStyle.Top;
            this.labcustname.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labcustname.Location = new System.Drawing.Point(0, 19);
            this.labcustname.Name = "labcustname";
            this.labcustname.Size = new System.Drawing.Size(122, 52);
            this.labcustname.TabIndex = 1;
            this.labcustname.Text = "客户姓名";
            this.labcustname.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labcustname.WordWrap = true;
            // 
            // labindexno
            // 
            // 
            // 
            // 
            this.labindexno.BackgroundStyle.Class = "";
            this.labindexno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labindexno.Dock = System.Windows.Forms.DockStyle.Top;
            this.labindexno.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labindexno.Location = new System.Drawing.Point(0, 0);
            this.labindexno.Name = "labindexno";
            this.labindexno.Size = new System.Drawing.Size(122, 19);
            this.labindexno.TabIndex = 0;
            this.labindexno.Text = "(1)";
            this.labindexno.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // C_Cube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelno);
            this.Name = "C_Cube";
            this.Size = new System.Drawing.Size(122, 150);
            this.superTooltip1.SetSuperTooltip(this, new DevComponents.DotNetBar.SuperTooltipInfo("<br>sfsdfsfsfsdfdsfsfsdfsdf<br>aaa</br>", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.System));
            this.panelno.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.PanelEx panelno;
        public DevComponents.DotNetBar.LabelX labfinnum;
        public DevComponents.DotNetBar.LabelX labcustname;
        public DevComponents.DotNetBar.LabelX labindexno;
        private DevComponents.DotNetBar.SuperTooltip superTooltip1;
    }
}

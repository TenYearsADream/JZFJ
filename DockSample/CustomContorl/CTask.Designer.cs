using System.Windows.Forms;

namespace MonitorMain.CustomContorl
{
    partial class CTask
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
            this.superTooltip1 = new DevComponents.DotNetBar.SuperTooltip();
            this.panelno = new DevComponents.DotNetBar.PanelEx();
            this.txtlocation = new DevComponents.Editors.IntegerInput();
            this.labcustname = new DevComponents.DotNetBar.LabelX();
            this.labindexno = new DevComponents.DotNetBar.LabelX();
            this.panelno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtlocation)).BeginInit();
            this.SuspendLayout();
            // 
            // panelno
            // 
            this.panelno.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelno.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelno.Controls.Add(this.txtlocation);
            this.panelno.Controls.Add(this.labcustname);
            this.panelno.Controls.Add(this.labindexno);
            this.panelno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelno.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelno.Location = new System.Drawing.Point(0, 0);
            this.panelno.Name = "panelno";
            this.panelno.Size = new System.Drawing.Size(50, 110);
            this.panelno.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelno.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelno.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelno.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelno.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelno.Style.ForeColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panelno.Style.GradientAngle = 90;
            this.panelno.TabIndex = 0;
            // 
            // txtlocation
            // 
            // 
            // 
            // 
            this.txtlocation.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtlocation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtlocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtlocation.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtlocation.Location = new System.Drawing.Point(0, 71);
            this.txtlocation.MaxValue = 30;
            this.txtlocation.MinValue = 1;
            this.txtlocation.Name = "txtlocation";
            this.txtlocation.Size = new System.Drawing.Size(50, 26);
            this.txtlocation.TabIndex = 5;
            this.txtlocation.Value = 1;
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
            this.labcustname.Size = new System.Drawing.Size(50, 52);
            this.labcustname.TabIndex = 4;
            this.labcustname.Text = "人名字";
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
            this.labindexno.Size = new System.Drawing.Size(50, 19);
            this.labindexno.TabIndex = 3;
            this.labindexno.Text = "(1)";
            this.labindexno.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // CTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelno);
            this.Name = "CTask";
            this.Size = new System.Drawing.Size(50, 110);
            this.panelno.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtlocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTooltip superTooltip1;
        public DevComponents.DotNetBar.PanelEx panelno;
        public DevComponents.Editors.IntegerInput txtlocation;
        public DevComponents.DotNetBar.LabelX labcustname;
        public DevComponents.DotNetBar.LabelX labindexno;
    }
}

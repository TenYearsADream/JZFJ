﻿namespace MonitorMain.CustomContorl
{
    partial class C_Shelf
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
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.labshelfcode = new DevComponents.DotNetBar.LabelX();
            this.labcqty = new DevComponents.DotNetBar.LabelX();
            this.superTooltip1 = new DevComponents.DotNetBar.SuperTooltip();
            this.SuspendLayout();
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.Class = "";
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarX1.Location = new System.Drawing.Point(0, 15);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Orientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.progressBarX1.Size = new System.Drawing.Size(41, 141);
            this.progressBarX1.TabIndex = 0;
            this.progressBarX1.TextVisible = true;
            this.progressBarX1.Value = 100;
            // 
            // labshelfcode
            // 
            // 
            // 
            // 
            this.labshelfcode.BackgroundStyle.Class = "";
            this.labshelfcode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labshelfcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.labshelfcode.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labshelfcode.Location = new System.Drawing.Point(0, 0);
            this.labshelfcode.Name = "labshelfcode";
            this.labshelfcode.Size = new System.Drawing.Size(41, 15);
            this.labshelfcode.TabIndex = 1;
            this.labshelfcode.Text = "1号";
            this.labshelfcode.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labcqty
            // 
            this.labcqty.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labcqty.BackgroundStyle.Class = "";
            this.labcqty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labcqty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labcqty.ForeColor = System.Drawing.Color.Red;
            this.labcqty.Location = new System.Drawing.Point(14, 22);
            this.labcqty.Name = "labcqty";
            this.labcqty.Size = new System.Drawing.Size(10, 77);
            this.labcqty.TabIndex = 1;
            this.labcqty.Text = "111";
            this.labcqty.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labcqty.WordWrap = true;
            this.labcqty.Click += new System.EventHandler(this.labcqty_Click);
            // 
            // C_Shelf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labcqty);
            this.Controls.Add(this.progressBarX1);
            this.Controls.Add(this.labshelfcode);
            this.Name = "C_Shelf";
            this.Size = new System.Drawing.Size(41, 156);
            this.Load += new System.EventHandler(this.C_Shelf_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private DevComponents.DotNetBar.LabelX labshelfcode;
        private DevComponents.DotNetBar.LabelX labcqty;
        private DevComponents.DotNetBar.SuperTooltip superTooltip1;
    }
}

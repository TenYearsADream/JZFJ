using System.Windows.Forms;

namespace MonitorMain
{
    partial class SLogoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.reflectionLabel2 = new DevComponents.DotNetBar.LabelX();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.labsystitle = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarX1
            // 
            this.progressBarX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.progressBarX1.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor;
            this.progressBarX1.BackgroundStyle.Class = "";
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Location = new System.Drawing.Point(30, 194);
            this.progressBarX1.Minimum = 10;
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.progressBarX1.Size = new System.Drawing.Size(471, 10);
            this.progressBarX1.Step = 100;
            this.progressBarX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.progressBarX1.TabIndex = 2;
            this.progressBarX1.Text = "progressBarX1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MonitorMain.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(50, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 112);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // reflectionLabel2
            // 
            this.reflectionLabel2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.reflectionLabel2.BackgroundStyle.Class = "";
            this.reflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reflectionLabel2.Location = new System.Drawing.Point(50, 157);
            this.reflectionLabel2.Name = "reflectionLabel2";
            this.reflectionLabel2.Size = new System.Drawing.Size(119, 17);
            this.reflectionLabel2.TabIndex = 6;
            this.reflectionLabel2.Text = "labelX1";
            // 
            // reflectionLabel1
            // 
            this.reflectionLabel1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.Class = "";
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.reflectionLabel1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reflectionLabel1.Location = new System.Drawing.Point(176, 45);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(298, 58);
            this.reflectionLabel1.TabIndex = 8;
            this.reflectionLabel1.Text = "<b><font size=\"+12\">湖北荆州市烟草公司</font></b>";
            // 
            // labsystitle
            // 
            this.labsystitle.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labsystitle.BackgroundStyle.Class = "";
            this.labsystitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labsystitle.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labsystitle.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labsystitle.Location = new System.Drawing.Point(176, 109);
            this.labsystitle.Name = "labsystitle";
            this.labsystitle.Size = new System.Drawing.Size(298, 39);
            this.labsystitle.TabIndex = 8;
            this.labsystitle.Text = "<b><font size=\"+6\">物流分拣任务系统</font></b>";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(31, 234);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(468, 36);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "Copyright© 2015 湖北金叶科技有限公司\r\nHubei Golden Leaf Science and Technology Co., Ltd All" +
                " rights";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // SLogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.BackgroundImage = global::MonitorMain.Properties.Resources.登录12_05;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(530, 313);
            this.Controls.Add(this.labsystitle);
            this.Controls.Add(this.reflectionLabel1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.reflectionLabel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.progressBarX1);
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SLogoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogoForm";
            this.Load += new System.EventHandler(this.SLogoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private PictureBox pictureBox2;
        private DevComponents.DotNetBar.LabelX reflectionLabel2;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel labsystitle;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}
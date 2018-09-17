namespace MonitorMain
{
    partial class PutPortForm
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
            this.cOutPort1 = new MonitorMain.CustomContorl.CPutPort();
            this.SuspendLayout();
            // 
            // cOutPort1
            // 
            this.cOutPort1.BackColor = System.Drawing.Color.Black;
            this.cOutPort1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cOutPort1.Location = new System.Drawing.Point(0, 0);
            this.cOutPort1.Name = "cOutPort1";
            this.cOutPort1.NOutPortNo = null;
            this.cOutPort1.OutPortNo = null;
            this.cOutPort1.POutPortNo = null;
            this.cOutPort1.Size = new System.Drawing.Size(1199, 800);
            this.cOutPort1.TabIndex = 0;
            // 
            // OutPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1199, 800);
            this.Controls.Add(this.cOutPort1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "OutPortForm";
            this.Text = "分拣信息监控看板";
            this.Load += new System.EventHandler(this.OutPortForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OutPortForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomContorl.CPutPort cOutPort1;


    }
}
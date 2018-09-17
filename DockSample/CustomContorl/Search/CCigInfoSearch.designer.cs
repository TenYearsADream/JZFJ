namespace MonitorMain.CustomContorl.Search
{
    partial class CCigInfoSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cigInfoListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtCigCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dgvSortingCig = new MonitorMain.CustomContorl.DoubleBufferDataGridViewX();
            this.cIGARETTENODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIGARETTENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bARCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineBoxCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineBoxNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.int_num = new DevComponents.Editors.IntegerInput();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cigname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cigcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cigInfoListBindingSource)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortingCig)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.int_num)).BeginInit();
            this.SuspendLayout();
            // 
            // cigInfoListBindingSource
            // 
            this.cigInfoListBindingSource.DataSource = typeof(BusinessLogic.Common.CigInfoList);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.txtCigCode);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(993, 95);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 5;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.labelX5.Location = new System.Drawing.Point(325, 21);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(291, 30);
            this.labelX5.TabIndex = 18;
            this.labelX5.Text = "卷烟品牌查询";
            this.labelX5.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txtCigCode
            // 
            // 
            // 
            // 
            this.txtCigCode.Border.Class = "TextBoxBorder";
            this.txtCigCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCigCode.FocusHighlightEnabled = true;
            this.txtCigCode.Location = new System.Drawing.Point(90, 69);
            this.txtCigCode.Name = "txtCigCode";
            this.txtCigCode.Size = new System.Drawing.Size(189, 21);
            this.txtCigCode.TabIndex = 15;
            this.txtCigCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCigCode_KeyDown);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(3, 68);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(118, 23);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "卷烟信息：";
            // 
            // dgvSortingCig
            // 
            this.dgvSortingCig.AllowUserToAddRows = false;
            this.dgvSortingCig.AllowUserToDeleteRows = false;
            this.dgvSortingCig.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvSortingCig.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSortingCig.AutoGenerateColumns = false;
            this.dgvSortingCig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSortingCig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSortingCig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIGARETTENODataGridViewTextBoxColumn,
            this.cIGARETTENAMEDataGridViewTextBoxColumn,
            this.bARCODEDataGridViewTextBoxColumn,
            this.lineBoxCodeDataGridViewTextBoxColumn,
            this.lineBoxNameDataGridViewTextBoxColumn});
            this.dgvSortingCig.DataSource = this.cigInfoListBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSortingCig.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSortingCig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSortingCig.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvSortingCig.Location = new System.Drawing.Point(0, 95);
            this.dgvSortingCig.MultiSelect = false;
            this.dgvSortingCig.Name = "dgvSortingCig";
            this.dgvSortingCig.ReadOnly = true;
            this.dgvSortingCig.RowHeadersWidth = 70;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvSortingCig.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSortingCig.RowTemplate.Height = 23;
            this.dgvSortingCig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSortingCig.Size = new System.Drawing.Size(993, 243);
            this.dgvSortingCig.TabIndex = 6;
            this.dgvSortingCig.DoubleClick += new System.EventHandler(this.dgvSortingCig_DoubleClick);
            // 
            // cIGARETTENODataGridViewTextBoxColumn
            // 
            this.cIGARETTENODataGridViewTextBoxColumn.DataPropertyName = "CIGARETTENO";
            this.cIGARETTENODataGridViewTextBoxColumn.HeaderText = "卷烟代码";
            this.cIGARETTENODataGridViewTextBoxColumn.Name = "cIGARETTENODataGridViewTextBoxColumn";
            this.cIGARETTENODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cIGARETTENAMEDataGridViewTextBoxColumn
            // 
            this.cIGARETTENAMEDataGridViewTextBoxColumn.DataPropertyName = "CIGARETTENAME";
            this.cIGARETTENAMEDataGridViewTextBoxColumn.HeaderText = "卷烟名称";
            this.cIGARETTENAMEDataGridViewTextBoxColumn.Name = "cIGARETTENAMEDataGridViewTextBoxColumn";
            this.cIGARETTENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bARCODEDataGridViewTextBoxColumn
            // 
            this.bARCODEDataGridViewTextBoxColumn.DataPropertyName = "BARCODE";
            this.bARCODEDataGridViewTextBoxColumn.HeaderText = "条码";
            this.bARCODEDataGridViewTextBoxColumn.Name = "bARCODEDataGridViewTextBoxColumn";
            this.bARCODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lineBoxCodeDataGridViewTextBoxColumn
            // 
            this.lineBoxCodeDataGridViewTextBoxColumn.DataPropertyName = "LineBoxCode";
            this.lineBoxCodeDataGridViewTextBoxColumn.HeaderText = "已绑定烟仓号";
            this.lineBoxCodeDataGridViewTextBoxColumn.Name = "lineBoxCodeDataGridViewTextBoxColumn";
            this.lineBoxCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lineBoxCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // lineBoxNameDataGridViewTextBoxColumn
            // 
            this.lineBoxNameDataGridViewTextBoxColumn.DataPropertyName = "LineBoxName";
            this.lineBoxNameDataGridViewTextBoxColumn.HeaderText = "已绑定烟仓名称";
            this.lineBoxNameDataGridViewTextBoxColumn.Name = "lineBoxNameDataGridViewTextBoxColumn";
            this.lineBoxNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lineBoxNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.buttonX2);
            this.panelEx2.Controls.Add(this.buttonX3);
            this.panelEx2.Controls.Add(this.buttonX1);
            this.panelEx2.Controls.Add(this.int_num);
            this.panelEx2.Controls.Add(this.txt_barcode);
            this.panelEx2.Controls.Add(this.label4);
            this.panelEx2.Controls.Add(this.label3);
            this.panelEx2.Controls.Add(this.txt_cigname);
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.txt_cigcode);
            this.panelEx2.Controls.Add(this.label1);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 338);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(993, 115);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 7;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(618, 64);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(118, 39);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 7;
            this.buttonX2.Text = "数据清除";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(378, 64);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(118, 39);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 7;
            this.buttonX3.Text = "生成立式";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(133, 64);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(118, 39);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 7;
            this.buttonX1.Text = "生成卧式";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // int_num
            // 
            // 
            // 
            // 
            this.int_num.BackgroundStyle.Class = "DateTimeInputBackground";
            this.int_num.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.int_num.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.int_num.Location = new System.Drawing.Point(700, 19);
            this.int_num.Name = "int_num";
            this.int_num.ShowUpDown = true;
            this.int_num.Size = new System.Drawing.Size(166, 21);
            this.int_num.TabIndex = 6;
            // 
            // txt_barcode
            // 
            this.txt_barcode.Location = new System.Drawing.Point(501, 19);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(123, 21);
            this.txt_barcode.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(647, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "数量(条)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "件码";
            // 
            // txt_cigname
            // 
            this.txt_cigname.Location = new System.Drawing.Point(281, 19);
            this.txt_cigname.Name = "txt_cigname";
            this.txt_cigname.Size = new System.Drawing.Size(123, 21);
            this.txt_cigname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "卷烟名称";
            // 
            // txt_cigcode
            // 
            this.txt_cigcode.Location = new System.Drawing.Point(70, 19);
            this.txt_cigcode.Name = "txt_cigcode";
            this.txt_cigcode.Size = new System.Drawing.Size(123, 21);
            this.txt_cigcode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "卷烟代码";
            // 
            // CCigInfoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 453);
            this.Controls.Add(this.dgvSortingCig);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Name = "CCigInfoSearch";
            this.Load += new System.EventHandler(this.CCigInfoSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cigInfoListBindingSource)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortingCig)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.int_num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferDataGridViewX dgvSortingCig;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCigCode;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.BindingSource cigInfoListBindingSource;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.TextBox txt_cigname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_cigcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Label label3;
        private DevComponents.Editors.IntegerInput int_num;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIGARETTENODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIGARETTENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bARCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineBoxCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineBoxNameDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
    }
}

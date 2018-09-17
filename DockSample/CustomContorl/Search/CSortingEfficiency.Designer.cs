namespace MonitorMain.CustomContorl
{
    partial class CSortingEfficiency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSortingEfficiency));
            this.dgvSortingEfficiency = new MonitorMain.CustomContorl.DoubleBufferDataGridViewX();
            this.sORTINGTASKNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oRDERDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pICKLINECODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pICKLINENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTYPRODCUTTOTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTYPRODUCTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTYROUTETOTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTYROUTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTYCUSTOMERTOTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTYCUSTOMERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERDESCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOUTECODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOUTENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFICIENCYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rECEIVETIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortingProcessListBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cobSortingLine = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cobbatch = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.footSumLabel1 = new MonitorMain.CustomContorl.FootSumLabel();
            this.customButton1 = new MonitorMain.CustomContorl.Search.CustomButton();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortingEfficiency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortingProcessListBindingSource1)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSortingEfficiency
            // 
            this.dgvSortingEfficiency.AllowUserToAddRows = false;
            this.dgvSortingEfficiency.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvSortingEfficiency.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSortingEfficiency.AutoGenerateColumns = false;
            this.dgvSortingEfficiency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSortingEfficiency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sORTINGTASKNODataGridViewTextBoxColumn,
            this.oRDERDATEDataGridViewTextBoxColumn,
            this.pICKLINECODEDataGridViewTextBoxColumn,
            this.pICKLINENAMEDataGridViewTextBoxColumn,
            this.qTYPRODCUTTOTDataGridViewTextBoxColumn,
            this.qTYPRODUCTDataGridViewTextBoxColumn,
            this.qTYROUTETOTDataGridViewTextBoxColumn,
            this.qTYROUTEDataGridViewTextBoxColumn,
            this.qTYCUSTOMERTOTDataGridViewTextBoxColumn,
            this.qTYCUSTOMERDataGridViewTextBoxColumn,
            this.cUSTOMERCODEDataGridViewTextBoxColumn,
            this.cUSTOMERDESCDataGridViewTextBoxColumn,
            this.rOUTECODEDataGridViewTextBoxColumn,
            this.rOUTENAMEDataGridViewTextBoxColumn,
            this.eFFICIENCYDataGridViewTextBoxColumn,
            this.rECEIVETIMEDataGridViewTextBoxColumn});
            this.dgvSortingEfficiency.DataSource = this.sortingProcessListBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSortingEfficiency.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSortingEfficiency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSortingEfficiency.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSortingEfficiency.Location = new System.Drawing.Point(0, 99);
            this.dgvSortingEfficiency.Name = "dgvSortingEfficiency";
            this.dgvSortingEfficiency.ReadOnly = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvSortingEfficiency.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSortingEfficiency.RowTemplate.Height = 23;
            this.dgvSortingEfficiency.Size = new System.Drawing.Size(876, 296);
            this.dgvSortingEfficiency.TabIndex = 0;
            this.dgvSortingEfficiency.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvSortingEfficiency_Scroll);
            // 
            // sORTINGTASKNODataGridViewTextBoxColumn
            // 
            this.sORTINGTASKNODataGridViewTextBoxColumn.DataPropertyName = "SORTINGTASKNO";
            this.sORTINGTASKNODataGridViewTextBoxColumn.HeaderText = "SORTINGTASKNO";
            this.sORTINGTASKNODataGridViewTextBoxColumn.Name = "sORTINGTASKNODataGridViewTextBoxColumn";
            this.sORTINGTASKNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oRDERDATEDataGridViewTextBoxColumn
            // 
            this.oRDERDATEDataGridViewTextBoxColumn.DataPropertyName = "ORDERDATE";
            this.oRDERDATEDataGridViewTextBoxColumn.HeaderText = "ORDERDATE";
            this.oRDERDATEDataGridViewTextBoxColumn.Name = "oRDERDATEDataGridViewTextBoxColumn";
            this.oRDERDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pICKLINECODEDataGridViewTextBoxColumn
            // 
            this.pICKLINECODEDataGridViewTextBoxColumn.DataPropertyName = "PICKLINECODE";
            this.pICKLINECODEDataGridViewTextBoxColumn.HeaderText = "PICKLINECODE";
            this.pICKLINECODEDataGridViewTextBoxColumn.Name = "pICKLINECODEDataGridViewTextBoxColumn";
            this.pICKLINECODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pICKLINENAMEDataGridViewTextBoxColumn
            // 
            this.pICKLINENAMEDataGridViewTextBoxColumn.DataPropertyName = "PICKLINENAME";
            this.pICKLINENAMEDataGridViewTextBoxColumn.HeaderText = "PICKLINENAME";
            this.pICKLINENAMEDataGridViewTextBoxColumn.Name = "pICKLINENAMEDataGridViewTextBoxColumn";
            this.pICKLINENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qTYPRODCUTTOTDataGridViewTextBoxColumn
            // 
            this.qTYPRODCUTTOTDataGridViewTextBoxColumn.DataPropertyName = "QTY_PRODCUT_TOT";
            this.qTYPRODCUTTOTDataGridViewTextBoxColumn.HeaderText = "QTY_PRODCUT_TOT";
            this.qTYPRODCUTTOTDataGridViewTextBoxColumn.Name = "qTYPRODCUTTOTDataGridViewTextBoxColumn";
            this.qTYPRODCUTTOTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qTYPRODUCTDataGridViewTextBoxColumn
            // 
            this.qTYPRODUCTDataGridViewTextBoxColumn.DataPropertyName = "QTY_PRODUCT";
            this.qTYPRODUCTDataGridViewTextBoxColumn.HeaderText = "QTY_PRODUCT";
            this.qTYPRODUCTDataGridViewTextBoxColumn.Name = "qTYPRODUCTDataGridViewTextBoxColumn";
            this.qTYPRODUCTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qTYROUTETOTDataGridViewTextBoxColumn
            // 
            this.qTYROUTETOTDataGridViewTextBoxColumn.DataPropertyName = "QTY_ROUTE_TOT";
            this.qTYROUTETOTDataGridViewTextBoxColumn.HeaderText = "QTY_ROUTE_TOT";
            this.qTYROUTETOTDataGridViewTextBoxColumn.Name = "qTYROUTETOTDataGridViewTextBoxColumn";
            this.qTYROUTETOTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qTYROUTEDataGridViewTextBoxColumn
            // 
            this.qTYROUTEDataGridViewTextBoxColumn.DataPropertyName = "QTY_ROUTE";
            this.qTYROUTEDataGridViewTextBoxColumn.HeaderText = "QTY_ROUTE";
            this.qTYROUTEDataGridViewTextBoxColumn.Name = "qTYROUTEDataGridViewTextBoxColumn";
            this.qTYROUTEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qTYCUSTOMERTOTDataGridViewTextBoxColumn
            // 
            this.qTYCUSTOMERTOTDataGridViewTextBoxColumn.DataPropertyName = "QTY_CUSTOMER_TOT";
            this.qTYCUSTOMERTOTDataGridViewTextBoxColumn.HeaderText = "QTY_CUSTOMER_TOT";
            this.qTYCUSTOMERTOTDataGridViewTextBoxColumn.Name = "qTYCUSTOMERTOTDataGridViewTextBoxColumn";
            this.qTYCUSTOMERTOTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qTYCUSTOMERDataGridViewTextBoxColumn
            // 
            this.qTYCUSTOMERDataGridViewTextBoxColumn.DataPropertyName = "QTY_CUSTOMER";
            this.qTYCUSTOMERDataGridViewTextBoxColumn.HeaderText = "QTY_CUSTOMER";
            this.qTYCUSTOMERDataGridViewTextBoxColumn.Name = "qTYCUSTOMERDataGridViewTextBoxColumn";
            this.qTYCUSTOMERDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cUSTOMERCODEDataGridViewTextBoxColumn
            // 
            this.cUSTOMERCODEDataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_CODE";
            this.cUSTOMERCODEDataGridViewTextBoxColumn.HeaderText = "CUSTOMER_CODE";
            this.cUSTOMERCODEDataGridViewTextBoxColumn.Name = "cUSTOMERCODEDataGridViewTextBoxColumn";
            this.cUSTOMERCODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cUSTOMERDESCDataGridViewTextBoxColumn
            // 
            this.cUSTOMERDESCDataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_DESC";
            this.cUSTOMERDESCDataGridViewTextBoxColumn.HeaderText = "CUSTOMER_DESC";
            this.cUSTOMERDESCDataGridViewTextBoxColumn.Name = "cUSTOMERDESCDataGridViewTextBoxColumn";
            this.cUSTOMERDESCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rOUTECODEDataGridViewTextBoxColumn
            // 
            this.rOUTECODEDataGridViewTextBoxColumn.DataPropertyName = "ROUTE_CODE";
            this.rOUTECODEDataGridViewTextBoxColumn.HeaderText = "ROUTE_CODE";
            this.rOUTECODEDataGridViewTextBoxColumn.Name = "rOUTECODEDataGridViewTextBoxColumn";
            this.rOUTECODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rOUTENAMEDataGridViewTextBoxColumn
            // 
            this.rOUTENAMEDataGridViewTextBoxColumn.DataPropertyName = "ROUTE_NAME";
            this.rOUTENAMEDataGridViewTextBoxColumn.HeaderText = "ROUTE_NAME";
            this.rOUTENAMEDataGridViewTextBoxColumn.Name = "rOUTENAMEDataGridViewTextBoxColumn";
            this.rOUTENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eFFICIENCYDataGridViewTextBoxColumn
            // 
            this.eFFICIENCYDataGridViewTextBoxColumn.DataPropertyName = "EFFICIENCY";
            this.eFFICIENCYDataGridViewTextBoxColumn.HeaderText = "EFFICIENCY";
            this.eFFICIENCYDataGridViewTextBoxColumn.Name = "eFFICIENCYDataGridViewTextBoxColumn";
            this.eFFICIENCYDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rECEIVETIMEDataGridViewTextBoxColumn
            // 
            this.rECEIVETIMEDataGridViewTextBoxColumn.DataPropertyName = "RECEIVE_TIME";
            this.rECEIVETIMEDataGridViewTextBoxColumn.HeaderText = "RECEIVE_TIME";
            this.rECEIVETIMEDataGridViewTextBoxColumn.Name = "rECEIVETIMEDataGridViewTextBoxColumn";
            this.rECEIVETIMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sortingProcessListBindingSource1
            // 
            this.sortingProcessListBindingSource1.DataSource = typeof(BusinessLogic.SortingProcess.SortingProcessList);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.customButton1);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.dateTimeInput1);
            this.panelEx1.Controls.Add(this.cobSortingLine);
            this.panelEx1.Controls.Add(this.cobbatch);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(876, 99);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // dateTimeInput1
            // 
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.FocusHighlightEnabled = true;
            this.dateTimeInput1.Location = new System.Drawing.Point(128, 27);
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.Class = "";
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2014, 8, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(118, 21);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 13;
            this.dateTimeInput1.Value = new System.DateTime(2014, 8, 8, 0, 0, 0, 0);
            this.dateTimeInput1.ValueChanged += new System.EventHandler(this.dateTimeInput1_ValueChanged);
            // 
            // cobSortingLine
            // 
            this.cobSortingLine.DisplayMember = "Name";
            this.cobSortingLine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cobSortingLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSortingLine.FocusHighlightEnabled = true;
            this.cobSortingLine.FormattingEnabled = true;
            this.cobSortingLine.ItemHeight = 15;
            this.cobSortingLine.Location = new System.Drawing.Point(417, 68);
            this.cobSortingLine.Name = "cobSortingLine";
            this.cobSortingLine.Size = new System.Drawing.Size(118, 21);
            this.cobSortingLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cobSortingLine.TabIndex = 11;
            this.cobSortingLine.ValueMember = "ID";
            // 
            // cobbatch
            // 
            this.cobbatch.DisplayMember = "Name";
            this.cobbatch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cobbatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobbatch.FocusHighlightEnabled = true;
            this.cobbatch.FormattingEnabled = true;
            this.cobbatch.ItemHeight = 15;
            this.cobbatch.Location = new System.Drawing.Point(128, 66);
            this.cobbatch.Name = "cobbatch";
            this.cobbatch.Size = new System.Drawing.Size(92, 21);
            this.cobbatch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cobbatch.TabIndex = 12;
            this.cobbatch.ValueMember = "ID";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(10, 65);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(118, 23);
            this.labelX4.TabIndex = 8;
            this.labelX4.Text = "下载批次选择：";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(300, 67);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(135, 23);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "分拣线选择：";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(10, 26);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(135, 23);
            this.labelX3.TabIndex = 10;
            this.labelX3.Text = "下载订单日期：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            // 
            // footSumLabel1
            // 
            this.footSumLabel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.footSumLabel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.footSumLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footSumLabel1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.footSumLabel1.Location = new System.Drawing.Point(0, 395);
            this.footSumLabel1.Name = "footSumLabel1";
            this.footSumLabel1.Size = new System.Drawing.Size(876, 26);
            this.footSumLabel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.footSumLabel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.footSumLabel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.footSumLabel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.footSumLabel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.footSumLabel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.footSumLabel1.Style.GradientAngle = 90;
            this.footSumLabel1.TabIndex = 2;
            // 
            // customButton1
            // 
            this.customButton1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.customButton1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.customButton1.Image = ((System.Drawing.Image)(resources.GetObject("customButton1.Image")));
            this.customButton1.ImageTextSpacing = 10;
            this.customButton1.Location = new System.Drawing.Point(615, 29);
            this.customButton1.Name = "customButton1";
            this.customButton1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.customButton1.Size = new System.Drawing.Size(100, 59);
            this.customButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.customButton1.TabIndex = 19;
            this.customButton1.Text = "查询";
            this.customButton1.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.labelX1.Location = new System.Drawing.Point(318, 19);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(291, 30);
            this.labelX1.TabIndex = 20;
            this.labelX1.Text = "分拣线效率查询";
            this.labelX1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // CSortingEfficiency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSortingEfficiency);
            this.Controls.Add(this.footSumLabel1);
            this.Controls.Add(this.panelEx1);
            this.Name = "CSortingEfficiency";
            this.Size = new System.Drawing.Size(876, 421);
            this.Load += new System.EventHandler(this.CSortingEfficiency_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortingEfficiency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortingProcessListBindingSource1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferDataGridViewX dgvSortingEfficiency;
        private System.Windows.Forms.DataGridViewTextBoxColumn sORTDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sORTLINECODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sORTLINEDESCDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cobSortingLine;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cobbatch;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.BindingSource sortingProcessListBindingSource1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sORTINGTASKNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oRDERDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pICKLINECODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pICKLINENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTYPRODCUTTOTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTYPRODUCTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTYROUTETOTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTYROUTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTYCUSTOMERTOTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTYCUSTOMERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERDESCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rOUTECODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rOUTENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eFFICIENCYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rECEIVETIMEDataGridViewTextBoxColumn;
        private FootSumLabel footSumLabel1;
        private Search.CustomButton customButton1;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}

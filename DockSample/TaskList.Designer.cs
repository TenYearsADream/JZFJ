namespace MonitorMain
{
    partial class TaskList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sortingLineTaskDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sortingLineTaskListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.dgviewnonedetail = new MonitorMain.CustomContorl.DoubleBufferDataGridViewX();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sORTINGTASKNODataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oRDERDATEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUBLINECODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUBLINENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lINEBOXCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lINEBOXNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDDRESSCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIGCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIGNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgviewnone = new MonitorMain.CustomContorl.DoubleBufferDataGridViewX();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sORTINGTASKNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oRDERDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pICKLINECODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pICKLINENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNDEXNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oUTPORTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CORPNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortingTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sortingLineTaskDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortingLineTaskListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewnonedetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewnone)).BeginInit();
            this.SuspendLayout();
            // 
            // sortingLineTaskDetailsBindingSource
            // 
            this.sortingLineTaskDetailsBindingSource.DataSource = typeof(BusinessLogic.SortingTask.SortingLineTaskDetails);
            // 
            // sortingLineTaskListBindingSource
            // 
            this.sortingLineTaskListBindingSource.DataSource = typeof(BusinessLogic.SortingTask.SortingLineTaskList);
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(161)))), ((int)(((byte)(171)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(161)))), ((int)(((byte)(171)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(161)))), ((int)(((byte)(171)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(161)))), ((int)(((byte)(171)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 343);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(853, 7);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 11;
            this.expandableSplitter1.TabStop = false;
            // 
            // dgviewnonedetail
            // 
            this.dgviewnonedetail.AllowUserToAddRows = false;
            this.dgviewnonedetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgviewnonedetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgviewnonedetail.AutoGenerateColumns = false;
            this.dgviewnonedetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgviewnonedetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.sORTINGTASKNODataGridViewTextBoxColumn1,
            this.oRDERDATEDataGridViewTextBoxColumn1,
            this.sUBLINECODEDataGridViewTextBoxColumn,
            this.sUBLINENAMEDataGridViewTextBoxColumn,
            this.lINEBOXCODEDataGridViewTextBoxColumn,
            this.lINEBOXNAMEDataGridViewTextBoxColumn,
            this.aDDRESSCODEDataGridViewTextBoxColumn,
            this.qTYDataGridViewTextBoxColumn,
            this.cIGCODEDataGridViewTextBoxColumn,
            this.cIGNAMEDataGridViewTextBoxColumn});
            this.dgviewnonedetail.DataSource = this.sortingLineTaskDetailsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgviewnonedetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgviewnonedetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgviewnonedetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgviewnonedetail.Location = new System.Drawing.Point(0, 350);
            this.dgviewnonedetail.Name = "dgviewnonedetail";
            this.dgviewnonedetail.ReadOnly = true;
            this.dgviewnonedetail.RowHeadersWidth = 70;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgviewnonedetail.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgviewnonedetail.RowTemplate.Height = 23;
            this.dgviewnonedetail.Size = new System.Drawing.Size(853, 148);
            this.dgviewnonedetail.TabIndex = 10;
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            this.iDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // sORTINGTASKNODataGridViewTextBoxColumn1
            // 
            this.sORTINGTASKNODataGridViewTextBoxColumn1.DataPropertyName = "SORTINGTASKNO";
            this.sORTINGTASKNODataGridViewTextBoxColumn1.HeaderText = "SORTINGTASKNO";
            this.sORTINGTASKNODataGridViewTextBoxColumn1.Name = "sORTINGTASKNODataGridViewTextBoxColumn1";
            this.sORTINGTASKNODataGridViewTextBoxColumn1.ReadOnly = true;
            this.sORTINGTASKNODataGridViewTextBoxColumn1.Visible = false;
            // 
            // oRDERDATEDataGridViewTextBoxColumn1
            // 
            this.oRDERDATEDataGridViewTextBoxColumn1.DataPropertyName = "ORDERDATE";
            this.oRDERDATEDataGridViewTextBoxColumn1.HeaderText = "ORDERDATE";
            this.oRDERDATEDataGridViewTextBoxColumn1.Name = "oRDERDATEDataGridViewTextBoxColumn1";
            this.oRDERDATEDataGridViewTextBoxColumn1.ReadOnly = true;
            this.oRDERDATEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // sUBLINECODEDataGridViewTextBoxColumn
            // 
            this.sUBLINECODEDataGridViewTextBoxColumn.DataPropertyName = "SUBLINECODE";
            this.sUBLINECODEDataGridViewTextBoxColumn.HeaderText = "SUBLINECODE";
            this.sUBLINECODEDataGridViewTextBoxColumn.Name = "sUBLINECODEDataGridViewTextBoxColumn";
            this.sUBLINECODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.sUBLINECODEDataGridViewTextBoxColumn.Visible = false;
            // 
            // sUBLINENAMEDataGridViewTextBoxColumn
            // 
            this.sUBLINENAMEDataGridViewTextBoxColumn.DataPropertyName = "SUBLINENAME";
            this.sUBLINENAMEDataGridViewTextBoxColumn.HeaderText = "SUBLINENAME";
            this.sUBLINENAMEDataGridViewTextBoxColumn.Name = "sUBLINENAMEDataGridViewTextBoxColumn";
            this.sUBLINENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lINEBOXCODEDataGridViewTextBoxColumn
            // 
            this.lINEBOXCODEDataGridViewTextBoxColumn.DataPropertyName = "LINEBOXCODE";
            this.lINEBOXCODEDataGridViewTextBoxColumn.HeaderText = "LINEBOXCODE";
            this.lINEBOXCODEDataGridViewTextBoxColumn.Name = "lINEBOXCODEDataGridViewTextBoxColumn";
            this.lINEBOXCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.lINEBOXCODEDataGridViewTextBoxColumn.Visible = false;
            // 
            // lINEBOXNAMEDataGridViewTextBoxColumn
            // 
            this.lINEBOXNAMEDataGridViewTextBoxColumn.DataPropertyName = "LINEBOXNAME";
            this.lINEBOXNAMEDataGridViewTextBoxColumn.HeaderText = "LINEBOXNAME";
            this.lINEBOXNAMEDataGridViewTextBoxColumn.Name = "lINEBOXNAMEDataGridViewTextBoxColumn";
            this.lINEBOXNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDDRESSCODEDataGridViewTextBoxColumn
            // 
            this.aDDRESSCODEDataGridViewTextBoxColumn.DataPropertyName = "ADDRESSCODE";
            this.aDDRESSCODEDataGridViewTextBoxColumn.HeaderText = "ADDRESSCODE";
            this.aDDRESSCODEDataGridViewTextBoxColumn.Name = "aDDRESSCODEDataGridViewTextBoxColumn";
            this.aDDRESSCODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qTYDataGridViewTextBoxColumn
            // 
            this.qTYDataGridViewTextBoxColumn.DataPropertyName = "QTY";
            this.qTYDataGridViewTextBoxColumn.HeaderText = "QTY";
            this.qTYDataGridViewTextBoxColumn.Name = "qTYDataGridViewTextBoxColumn";
            this.qTYDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cIGCODEDataGridViewTextBoxColumn
            // 
            this.cIGCODEDataGridViewTextBoxColumn.DataPropertyName = "CIGCODE";
            this.cIGCODEDataGridViewTextBoxColumn.HeaderText = "CIGCODE";
            this.cIGCODEDataGridViewTextBoxColumn.Name = "cIGCODEDataGridViewTextBoxColumn";
            this.cIGCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cIGCODEDataGridViewTextBoxColumn.Visible = false;
            // 
            // cIGNAMEDataGridViewTextBoxColumn
            // 
            this.cIGNAMEDataGridViewTextBoxColumn.DataPropertyName = "CIGNAME";
            this.cIGNAMEDataGridViewTextBoxColumn.HeaderText = "CIGNAME";
            this.cIGNAMEDataGridViewTextBoxColumn.Name = "cIGNAMEDataGridViewTextBoxColumn";
            this.cIGNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgviewnone
            // 
            this.dgviewnone.AllowUserToAddRows = false;
            this.dgviewnone.AllowUserToDeleteRows = false;
            this.dgviewnone.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgviewnone.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgviewnone.AutoGenerateColumns = false;
            this.dgviewnone.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgviewnone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.sORTINGTASKNODataGridViewTextBoxColumn,
            this.oRDERDATEDataGridViewTextBoxColumn,
            this.pICKLINECODEDataGridViewTextBoxColumn,
            this.pICKLINENAMEDataGridViewTextBoxColumn,
            this.cUSTCODEDataGridViewTextBoxColumn,
            this.cUSTNAMEDataGridViewTextBoxColumn,
            this.ShortName,
            this.iNDEXNODataGridViewTextBoxColumn,
            this.oUTPORTDataGridViewTextBoxColumn,
            this.LINENAME,
            this.CORPNAME,
            this.statusDataGridViewTextBoxColumn,
            this.sortingTimeDataGridViewTextBoxColumn,
            this.FinishTime});
            this.dgviewnone.DataSource = this.sortingLineTaskListBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgviewnone.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgviewnone.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgviewnone.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgviewnone.Location = new System.Drawing.Point(0, 0);
            this.dgviewnone.Name = "dgviewnone";
            this.dgviewnone.ReadOnly = true;
            this.dgviewnone.RowHeadersWidth = 70;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgviewnone.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgviewnone.RowTemplate.Height = 23;
            this.dgviewnone.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgviewnone.Size = new System.Drawing.Size(853, 343);
            this.dgviewnone.TabIndex = 9;
            this.dgviewnone.SelectionChanged += new System.EventHandler(this.dgviewnone_SelectionChanged);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // sORTINGTASKNODataGridViewTextBoxColumn
            // 
            this.sORTINGTASKNODataGridViewTextBoxColumn.DataPropertyName = "SORTINGTASKNO";
            this.sORTINGTASKNODataGridViewTextBoxColumn.HeaderText = "SORTINGTASKNO";
            this.sORTINGTASKNODataGridViewTextBoxColumn.Name = "sORTINGTASKNODataGridViewTextBoxColumn";
            this.sORTINGTASKNODataGridViewTextBoxColumn.ReadOnly = true;
            this.sORTINGTASKNODataGridViewTextBoxColumn.Visible = false;
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
            this.pICKLINECODEDataGridViewTextBoxColumn.Visible = false;
            // 
            // pICKLINENAMEDataGridViewTextBoxColumn
            // 
            this.pICKLINENAMEDataGridViewTextBoxColumn.DataPropertyName = "PICKLINENAME";
            this.pICKLINENAMEDataGridViewTextBoxColumn.HeaderText = "PICKLINENAME";
            this.pICKLINENAMEDataGridViewTextBoxColumn.Name = "pICKLINENAMEDataGridViewTextBoxColumn";
            this.pICKLINENAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cUSTCODEDataGridViewTextBoxColumn
            // 
            this.cUSTCODEDataGridViewTextBoxColumn.DataPropertyName = "CUSTCODE";
            this.cUSTCODEDataGridViewTextBoxColumn.HeaderText = "CUSTCODE";
            this.cUSTCODEDataGridViewTextBoxColumn.Name = "cUSTCODEDataGridViewTextBoxColumn";
            this.cUSTCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTCODEDataGridViewTextBoxColumn.Visible = false;
            // 
            // cUSTNAMEDataGridViewTextBoxColumn
            // 
            this.cUSTNAMEDataGridViewTextBoxColumn.DataPropertyName = "CUSTNAME";
            this.cUSTNAMEDataGridViewTextBoxColumn.HeaderText = "CUSTNAME";
            this.cUSTNAMEDataGridViewTextBoxColumn.Name = "cUSTNAMEDataGridViewTextBoxColumn";
            this.cUSTNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ShortName
            // 
            this.ShortName.DataPropertyName = "ShortName";
            this.ShortName.HeaderText = "ShortName";
            this.ShortName.Name = "ShortName";
            this.ShortName.ReadOnly = true;
            // 
            // iNDEXNODataGridViewTextBoxColumn
            // 
            this.iNDEXNODataGridViewTextBoxColumn.DataPropertyName = "INDEXNO";
            this.iNDEXNODataGridViewTextBoxColumn.HeaderText = "INDEXNO";
            this.iNDEXNODataGridViewTextBoxColumn.Name = "iNDEXNODataGridViewTextBoxColumn";
            this.iNDEXNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oUTPORTDataGridViewTextBoxColumn
            // 
            this.oUTPORTDataGridViewTextBoxColumn.DataPropertyName = "OUTPORT";
            this.oUTPORTDataGridViewTextBoxColumn.HeaderText = "OUTPORT";
            this.oUTPORTDataGridViewTextBoxColumn.Name = "oUTPORTDataGridViewTextBoxColumn";
            this.oUTPORTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // LINENAME
            // 
            this.LINENAME.DataPropertyName = "LINENAME";
            this.LINENAME.HeaderText = "LINENAME";
            this.LINENAME.Name = "LINENAME";
            this.LINENAME.ReadOnly = true;
            // 
            // CORPNAME
            // 
            this.CORPNAME.DataPropertyName = "CORPNAME";
            this.CORPNAME.HeaderText = "CORPNAME";
            this.CORPNAME.Name = "CORPNAME";
            this.CORPNAME.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sortingTimeDataGridViewTextBoxColumn
            // 
            this.sortingTimeDataGridViewTextBoxColumn.DataPropertyName = "SortingTime";
            this.sortingTimeDataGridViewTextBoxColumn.HeaderText = "SortingTime";
            this.sortingTimeDataGridViewTextBoxColumn.Name = "sortingTimeDataGridViewTextBoxColumn";
            this.sortingTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FinishTime
            // 
            this.FinishTime.DataPropertyName = "FinishTime";
            this.FinishTime.HeaderText = "FinishTime";
            this.FinishTime.Name = "FinishTime";
            this.FinishTime.ReadOnly = true;
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 498);
            this.Controls.Add(this.dgviewnonedetail);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.dgviewnone);
            this.Name = "TaskList";
            this.Text = "任务列表";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TaskList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sortingLineTaskDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortingLineTaskListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewnonedetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewnone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomContorl.DoubleBufferDataGridViewX dgviewnonedetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sORTINGTASKNODataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn oRDERDATEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUBLINECODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUBLINENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lINEBOXCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lINEBOXNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDDRESSCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIGCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIGNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sortingLineTaskDetailsBindingSource;
        private System.Windows.Forms.BindingSource sortingLineTaskListBindingSource;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private CustomContorl.DoubleBufferDataGridViewX dgviewnone;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sORTINGTASKNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oRDERDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pICKLINECODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pICKLINENAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNDEXNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oUTPORTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CORPNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortingTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishTime;

    }
}
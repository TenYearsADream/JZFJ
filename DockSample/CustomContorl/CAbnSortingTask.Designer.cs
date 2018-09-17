using System.Windows.Forms;

namespace MonitorMain.CustomContorl
{
    sealed partial class CAbnSortingTask
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates1 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates2 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAbnSortingTask));
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgviewfindetail = new MonitorMain.CustomContorl.DoubleBufferDataGridViewX();
            this.dgviewfin = new MonitorMain.CustomContorl.DoubleBufferDataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置分拣未完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置分拣已完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgviewnone = new MonitorMain.CustomContorl.DoubleBufferDataGridViewX();
            this.dgviewnonedetail = new MonitorMain.CustomContorl.DoubleBufferDataGridViewX();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labindexno = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labcustname = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labcustcode = new DevComponents.DotNetBar.LabelX();
            this.labSortingtaskno = new DevComponents.DotNetBar.LabelX();
            this.labpicklinename = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.laborderdate = new DevComponents.DotNetBar.LabelX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.abnSortingLineTaskListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sORTINGTASKNODataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oRDERDATEDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUBLINECODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUBLINENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lINEBOXCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lINEBOXNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDDRESSCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIGCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIGNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abnSortingLineTaskDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sORTINGTASKNODataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oRDERDATEDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUBLINECODEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUBLINENAMEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lINEBOXCODEDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lINEBOXNAMEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDDRESSCODEDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIGCODEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIGNAMEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTYDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sORTINGTASKNODataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oRDERDATEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pICKLINECODEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pICKLINENAMEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTCODEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTNAMEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNDEXNODataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oUTPORTDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortingTimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishTimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abnSortingLineTaskListBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sortingTaskArrivesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sortingTaskIssuedListBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sORTINGTASKNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oRDERDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pICKLINECODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pICKLINENAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNDEXNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oUTPORTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortingTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSorting = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewfindetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewfin)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewnone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewnonedetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abnSortingLineTaskListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abnSortingLineTaskDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abnSortingLineTaskListBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortingTaskArrivesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortingTaskIssuedListBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgviewfindetail);
            this.groupPanel2.Controls.Add(this.dgviewfin);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1014, 477);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "分拣优化已完成订单";
            // 
            // dgviewfindetail
            // 
            this.dgviewfindetail.AllowUserToAddRows = false;
            this.dgviewfindetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgviewfindetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgviewfindetail.AutoGenerateColumns = false;
            this.dgviewfindetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgviewfindetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgviewfindetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn7,
            this.sORTINGTASKNODataGridViewTextBoxColumn3,
            this.oRDERDATEDataGridViewTextBoxColumn3,
            this.sUBLINECODEDataGridViewTextBoxColumn1,
            this.sUBLINENAMEDataGridViewTextBoxColumn1,
            this.lINEBOXCODEDataGridViewTextBoxColumn2,
            this.lINEBOXNAMEDataGridViewTextBoxColumn1,
            this.aDDRESSCODEDataGridViewTextBoxColumn3,
            this.cIGCODEDataGridViewTextBoxColumn1,
            this.cIGNAMEDataGridViewTextBoxColumn1,
            this.qTYDataGridViewTextBoxColumn2});
            this.dgviewfindetail.DataSource = this.abnSortingLineTaskDetailsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgviewfindetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgviewfindetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgviewfindetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgviewfindetail.Location = new System.Drawing.Point(0, 220);
            this.dgviewfindetail.Name = "dgviewfindetail";
            this.dgviewfindetail.ReadOnly = true;
            this.dgviewfindetail.RowHeadersWidth = 70;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgviewfindetail.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgviewfindetail.RowTemplate.Height = 23;
            this.dgviewfindetail.Size = new System.Drawing.Size(1008, 233);
            this.dgviewfindetail.TabIndex = 3;
            this.dgviewfindetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgviewnone_RowPostPaint);
            // 
            // dgviewfin
            // 
            this.dgviewfin.AllowUserToAddRows = false;
            this.dgviewfin.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgviewfin.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgviewfin.AutoGenerateColumns = false;
            this.dgviewfin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgviewfin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgviewfin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.sORTINGTASKNODataGridViewTextBoxColumn1,
            this.oRDERDATEDataGridViewTextBoxColumn1,
            this.pICKLINECODEDataGridViewTextBoxColumn1,
            this.pICKLINENAMEDataGridViewTextBoxColumn1,
            this.cUSTCODEDataGridViewTextBoxColumn1,
            this.cUSTNAMEDataGridViewTextBoxColumn1,
            this.iNDEXNODataGridViewTextBoxColumn1,
            this.oUTPORTDataGridViewTextBoxColumn1,
            this.statusDataGridViewTextBoxColumn1,
            this.sortingTimeDataGridViewTextBoxColumn1,
            this.finishTimeDataGridViewTextBoxColumn1});
            this.dgviewfin.ContextMenuStrip = this.contextMenuStrip1;
            this.dgviewfin.DataSource = this.abnSortingLineTaskListBindingSource1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgviewfin.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgviewfin.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgviewfin.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgviewfin.Location = new System.Drawing.Point(0, 0);
            this.dgviewfin.Name = "dgviewfin";
            this.dgviewfin.ReadOnly = true;
            this.dgviewfin.RowHeadersWidth = 70;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgviewfin.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgviewfin.RowTemplate.Height = 23;
            this.dgviewfin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgviewfin.Size = new System.Drawing.Size(1008, 220);
            this.dgviewfin.TabIndex = 2;
            this.dgviewfin.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgviewnone_RowPostPaint);
            this.dgviewfin.SelectionChanged += new System.EventHandler(this.dgviewfin_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置分拣未完成ToolStripMenuItem,
            this.设置分拣已完成ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 48);
            // 
            // 设置分拣未完成ToolStripMenuItem
            // 
            this.设置分拣未完成ToolStripMenuItem.Name = "设置分拣未完成ToolStripMenuItem";
            this.设置分拣未完成ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.设置分拣未完成ToolStripMenuItem.Text = "设置分拣未完成";
            this.设置分拣未完成ToolStripMenuItem.Click += new System.EventHandler(this.设置分拣未完成ToolStripMenuItem_Click);
            // 
            // 设置分拣已完成ToolStripMenuItem
            // 
            this.设置分拣已完成ToolStripMenuItem.Name = "设置分拣已完成ToolStripMenuItem";
            this.设置分拣已完成ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.设置分拣已完成ToolStripMenuItem.Text = "设置分拣已完成";
            this.设置分拣已完成ToolStripMenuItem.Visible = false;
            // 
            // dgviewnone
            // 
            this.dgviewnone.AllowUserToAddRows = false;
            this.dgviewnone.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgviewnone.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgviewnone.AutoGenerateColumns = false;
            this.dgviewnone.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgviewnone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgviewnone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.sORTINGTASKNODataGridViewTextBoxColumn,
            this.oRDERDATEDataGridViewTextBoxColumn,
            this.pICKLINECODEDataGridViewTextBoxColumn,
            this.pICKLINENAMEDataGridViewTextBoxColumn,
            this.cUSTCODEDataGridViewTextBoxColumn,
            this.shortname,
            this.cUSTNAMEDataGridViewTextBoxColumn,
            this.iNDEXNODataGridViewTextBoxColumn,
            this.oUTPORTDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.sortingTimeDataGridViewTextBoxColumn,
            this.finishTimeDataGridViewTextBoxColumn,
            this.btnSorting});
            this.dgviewnone.DataSource = this.abnSortingLineTaskListBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgviewnone.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgviewnone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgviewnone.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgviewnone.Location = new System.Drawing.Point(409, 0);
            this.dgviewnone.Name = "dgviewnone";
            this.dgviewnone.ReadOnly = true;
            this.dgviewnone.RowHeadersWidth = 70;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgviewnone.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgviewnone.RowTemplate.Height = 23;
            this.dgviewnone.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgviewnone.Size = new System.Drawing.Size(605, 440);
            this.dgviewnone.TabIndex = 0;
            this.dgviewnone.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgviewnone_CellContentClick);
            this.dgviewnone.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgviewnone_RowPostPaint);
            this.dgviewnone.SelectionChanged += new System.EventHandler(this.dgviewnone_SelectionChanged);
            // 
            // dgviewnonedetail
            // 
            this.dgviewnonedetail.AllowUserToAddRows = false;
            this.dgviewnonedetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgviewnonedetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgviewnonedetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgviewnonedetail.AutoGenerateColumns = false;
            this.dgviewnonedetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgviewnonedetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgviewnonedetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn6,
            this.sORTINGTASKNODataGridViewTextBoxColumn2,
            this.oRDERDATEDataGridViewTextBoxColumn2,
            this.sUBLINECODEDataGridViewTextBoxColumn,
            this.sUBLINENAMEDataGridViewTextBoxColumn,
            this.lINEBOXCODEDataGridViewTextBoxColumn,
            this.lINEBOXNAMEDataGridViewTextBoxColumn,
            this.aDDRESSCODEDataGridViewTextBoxColumn,
            this.cIGCODEDataGridViewTextBoxColumn,
            this.cIGNAMEDataGridViewTextBoxColumn,
            this.qTYDataGridViewTextBoxColumn});
            this.dgviewnonedetail.DataSource = this.abnSortingLineTaskDetailsBindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgviewnonedetail.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgviewnonedetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgviewnonedetail.Location = new System.Drawing.Point(2, 187);
            this.dgviewnonedetail.Name = "dgviewnonedetail";
            this.dgviewnonedetail.ReadOnly = true;
            this.dgviewnonedetail.RowHeadersWidth = 70;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgviewnonedetail.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgviewnonedetail.RowTemplate.Height = 23;
            this.dgviewnonedetail.Size = new System.Drawing.Size(409, 201);
            this.dgviewnonedetail.TabIndex = 1;
            this.dgviewnonedetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgviewnone_RowPostPaint);
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.FixedTabSize = new System.Drawing.Size(0, 35);
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.SelectedTabIndex = 1;
            this.superTabControl1.Size = new System.Drawing.Size(1014, 477);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 1;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.dgviewnone);
            this.superTabControlPanel1.Controls.Add(this.panelEx1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 37);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1014, 440);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Controls.Add(this.btnFinish);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(409, 440);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.dgviewnonedetail);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.labindexno);
            this.panelEx2.Controls.Add(this.labelX7);
            this.panelEx2.Controls.Add(this.labcustname);
            this.panelEx2.Controls.Add(this.labelX9);
            this.panelEx2.Controls.Add(this.labcustcode);
            this.panelEx2.Controls.Add(this.labSortingtaskno);
            this.panelEx2.Controls.Add(this.labpicklinename);
            this.panelEx2.Controls.Add(this.labelX11);
            this.panelEx2.Controls.Add(this.laborderdate);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(409, 388);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 3;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(6, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(119, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "任务号";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(6, 42);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(119, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "订单日期";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(6, 71);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(119, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "分拣线名称";
            // 
            // labindexno
            // 
            // 
            // 
            // 
            this.labindexno.BackgroundStyle.Class = "";
            this.labindexno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labindexno.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labindexno.Location = new System.Drawing.Point(125, 158);
            this.labindexno.Name = "labindexno";
            this.labindexno.Size = new System.Drawing.Size(283, 23);
            this.labindexno.TabIndex = 0;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX7.Location = new System.Drawing.Point(6, 100);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(119, 23);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "客户代码";
            // 
            // labcustname
            // 
            // 
            // 
            // 
            this.labcustname.BackgroundStyle.Class = "";
            this.labcustname.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labcustname.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labcustname.Location = new System.Drawing.Point(125, 129);
            this.labcustname.Name = "labcustname";
            this.labcustname.Size = new System.Drawing.Size(283, 23);
            this.labcustname.TabIndex = 0;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX9.Location = new System.Drawing.Point(6, 129);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(119, 23);
            this.labelX9.TabIndex = 0;
            this.labelX9.Text = "客户名称";
            // 
            // labcustcode
            // 
            // 
            // 
            // 
            this.labcustcode.BackgroundStyle.Class = "";
            this.labcustcode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labcustcode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labcustcode.Location = new System.Drawing.Point(125, 100);
            this.labcustcode.Name = "labcustcode";
            this.labcustcode.Size = new System.Drawing.Size(283, 23);
            this.labcustcode.TabIndex = 0;
            // 
            // labSortingtaskno
            // 
            // 
            // 
            // 
            this.labSortingtaskno.BackgroundStyle.Class = "";
            this.labSortingtaskno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labSortingtaskno.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSortingtaskno.Location = new System.Drawing.Point(125, 13);
            this.labSortingtaskno.Name = "labSortingtaskno";
            this.labSortingtaskno.Size = new System.Drawing.Size(283, 23);
            this.labSortingtaskno.TabIndex = 0;
            // 
            // labpicklinename
            // 
            // 
            // 
            // 
            this.labpicklinename.BackgroundStyle.Class = "";
            this.labpicklinename.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labpicklinename.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labpicklinename.Location = new System.Drawing.Point(125, 71);
            this.labpicklinename.Name = "labpicklinename";
            this.labpicklinename.Size = new System.Drawing.Size(283, 23);
            this.labpicklinename.TabIndex = 0;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX11.Location = new System.Drawing.Point(6, 158);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(119, 23);
            this.labelX11.TabIndex = 0;
            this.labelX11.Text = "顺序号";
            // 
            // laborderdate
            // 
            // 
            // 
            // 
            this.laborderdate.BackgroundStyle.Class = "";
            this.laborderdate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.laborderdate.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.laborderdate.Location = new System.Drawing.Point(125, 42);
            this.laborderdate.Name = "laborderdate";
            this.laborderdate.Size = new System.Drawing.Size(283, 23);
            this.laborderdate.TabIndex = 0;
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFinish.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFinish.Image = global::MonitorMain.Properties.Resources._20140808095338424_easyicon_net_48;
            this.btnFinish.Location = new System.Drawing.Point(0, 388);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(409, 52);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "分拣完成";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Image = global::MonitorMain.Properties.Resources._20141030100358913_easyicon_net_16;
            this.superTabItem1.Name = "superTabItem1";
            superTabItemStateColorTable1.OuterBorder = System.Drawing.Color.Gray;
            superTabColorStates1.Normal = superTabItemStateColorTable1;
            superTabItemColorTable1.Default = superTabColorStates1;
            this.superTabItem1.TabColor = superTabItemColorTable1;
            this.superTabItem1.Text = "分拣未完成任务";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.groupPanel2);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1014, 477);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Image = global::MonitorMain.Properties.Resources._20141030100358913_easyicon_net_16;
            this.superTabItem2.Name = "superTabItem2";
            superTabItemStateColorTable2.OuterBorder = System.Drawing.Color.Gray;
            superTabColorStates2.Normal = superTabItemStateColorTable2;
            superTabItemColorTable2.Default = superTabColorStates2;
            this.superTabItem2.TabColor = superTabItemColorTable2;
            this.superTabItem2.Text = "分拣已完成任务";
            // 
            // abnSortingLineTaskListBindingSource
            // 
            this.abnSortingLineTaskListBindingSource.DataSource = typeof(BusinessLogic.SortingTask.AbnSortingLineTaskList);
            // 
            // iDDataGridViewTextBoxColumn6
            // 
            this.iDDataGridViewTextBoxColumn6.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn6.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn6.Name = "iDDataGridViewTextBoxColumn6";
            this.iDDataGridViewTextBoxColumn6.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn6.Visible = false;
            // 
            // sORTINGTASKNODataGridViewTextBoxColumn2
            // 
            this.sORTINGTASKNODataGridViewTextBoxColumn2.DataPropertyName = "SORTINGTASKNO";
            this.sORTINGTASKNODataGridViewTextBoxColumn2.HeaderText = "SORTINGTASKNO";
            this.sORTINGTASKNODataGridViewTextBoxColumn2.Name = "sORTINGTASKNODataGridViewTextBoxColumn2";
            this.sORTINGTASKNODataGridViewTextBoxColumn2.ReadOnly = true;
            this.sORTINGTASKNODataGridViewTextBoxColumn2.Visible = false;
            // 
            // oRDERDATEDataGridViewTextBoxColumn2
            // 
            this.oRDERDATEDataGridViewTextBoxColumn2.DataPropertyName = "ORDERDATE";
            this.oRDERDATEDataGridViewTextBoxColumn2.HeaderText = "ORDERDATE";
            this.oRDERDATEDataGridViewTextBoxColumn2.Name = "oRDERDATEDataGridViewTextBoxColumn2";
            this.oRDERDATEDataGridViewTextBoxColumn2.ReadOnly = true;
            this.oRDERDATEDataGridViewTextBoxColumn2.Visible = false;
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
            this.sUBLINENAMEDataGridViewTextBoxColumn.Visible = false;
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
            this.lINEBOXNAMEDataGridViewTextBoxColumn.Visible = false;
            // 
            // aDDRESSCODEDataGridViewTextBoxColumn
            // 
            this.aDDRESSCODEDataGridViewTextBoxColumn.DataPropertyName = "ADDRESSCODE";
            this.aDDRESSCODEDataGridViewTextBoxColumn.HeaderText = "ADDRESSCODE";
            this.aDDRESSCODEDataGridViewTextBoxColumn.Name = "aDDRESSCODEDataGridViewTextBoxColumn";
            this.aDDRESSCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.aDDRESSCODEDataGridViewTextBoxColumn.Visible = false;
            // 
            // cIGCODEDataGridViewTextBoxColumn
            // 
            this.cIGCODEDataGridViewTextBoxColumn.DataPropertyName = "CIGCODE";
            this.cIGCODEDataGridViewTextBoxColumn.HeaderText = "CIGCODE";
            this.cIGCODEDataGridViewTextBoxColumn.Name = "cIGCODEDataGridViewTextBoxColumn";
            this.cIGCODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cIGNAMEDataGridViewTextBoxColumn
            // 
            this.cIGNAMEDataGridViewTextBoxColumn.DataPropertyName = "CIGNAME";
            this.cIGNAMEDataGridViewTextBoxColumn.HeaderText = "CIGNAME";
            this.cIGNAMEDataGridViewTextBoxColumn.Name = "cIGNAMEDataGridViewTextBoxColumn";
            this.cIGNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qTYDataGridViewTextBoxColumn
            // 
            this.qTYDataGridViewTextBoxColumn.DataPropertyName = "QTY";
            this.qTYDataGridViewTextBoxColumn.HeaderText = "QTY";
            this.qTYDataGridViewTextBoxColumn.Name = "qTYDataGridViewTextBoxColumn";
            this.qTYDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // abnSortingLineTaskDetailsBindingSource
            // 
            this.abnSortingLineTaskDetailsBindingSource.DataSource = typeof(BusinessLogic.SortingTask.AbnSortingLineTaskDetails);
            // 
            // iDDataGridViewTextBoxColumn7
            // 
            this.iDDataGridViewTextBoxColumn7.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn7.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn7.Name = "iDDataGridViewTextBoxColumn7";
            this.iDDataGridViewTextBoxColumn7.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn7.Visible = false;
            // 
            // sORTINGTASKNODataGridViewTextBoxColumn3
            // 
            this.sORTINGTASKNODataGridViewTextBoxColumn3.DataPropertyName = "SORTINGTASKNO";
            this.sORTINGTASKNODataGridViewTextBoxColumn3.HeaderText = "SORTINGTASKNO";
            this.sORTINGTASKNODataGridViewTextBoxColumn3.Name = "sORTINGTASKNODataGridViewTextBoxColumn3";
            this.sORTINGTASKNODataGridViewTextBoxColumn3.ReadOnly = true;
            this.sORTINGTASKNODataGridViewTextBoxColumn3.Visible = false;
            // 
            // oRDERDATEDataGridViewTextBoxColumn3
            // 
            this.oRDERDATEDataGridViewTextBoxColumn3.DataPropertyName = "ORDERDATE";
            this.oRDERDATEDataGridViewTextBoxColumn3.HeaderText = "ORDERDATE";
            this.oRDERDATEDataGridViewTextBoxColumn3.Name = "oRDERDATEDataGridViewTextBoxColumn3";
            this.oRDERDATEDataGridViewTextBoxColumn3.ReadOnly = true;
            this.oRDERDATEDataGridViewTextBoxColumn3.Visible = false;
            // 
            // sUBLINECODEDataGridViewTextBoxColumn1
            // 
            this.sUBLINECODEDataGridViewTextBoxColumn1.DataPropertyName = "SUBLINECODE";
            this.sUBLINECODEDataGridViewTextBoxColumn1.HeaderText = "SUBLINECODE";
            this.sUBLINECODEDataGridViewTextBoxColumn1.Name = "sUBLINECODEDataGridViewTextBoxColumn1";
            this.sUBLINECODEDataGridViewTextBoxColumn1.ReadOnly = true;
            this.sUBLINECODEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // sUBLINENAMEDataGridViewTextBoxColumn1
            // 
            this.sUBLINENAMEDataGridViewTextBoxColumn1.DataPropertyName = "SUBLINENAME";
            this.sUBLINENAMEDataGridViewTextBoxColumn1.HeaderText = "SUBLINENAME";
            this.sUBLINENAMEDataGridViewTextBoxColumn1.Name = "sUBLINENAMEDataGridViewTextBoxColumn1";
            this.sUBLINENAMEDataGridViewTextBoxColumn1.ReadOnly = true;
            this.sUBLINENAMEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // lINEBOXCODEDataGridViewTextBoxColumn2
            // 
            this.lINEBOXCODEDataGridViewTextBoxColumn2.DataPropertyName = "LINEBOXCODE";
            this.lINEBOXCODEDataGridViewTextBoxColumn2.HeaderText = "LINEBOXCODE";
            this.lINEBOXCODEDataGridViewTextBoxColumn2.Name = "lINEBOXCODEDataGridViewTextBoxColumn2";
            this.lINEBOXCODEDataGridViewTextBoxColumn2.ReadOnly = true;
            this.lINEBOXCODEDataGridViewTextBoxColumn2.Visible = false;
            // 
            // lINEBOXNAMEDataGridViewTextBoxColumn1
            // 
            this.lINEBOXNAMEDataGridViewTextBoxColumn1.DataPropertyName = "LINEBOXNAME";
            this.lINEBOXNAMEDataGridViewTextBoxColumn1.HeaderText = "LINEBOXNAME";
            this.lINEBOXNAMEDataGridViewTextBoxColumn1.Name = "lINEBOXNAMEDataGridViewTextBoxColumn1";
            this.lINEBOXNAMEDataGridViewTextBoxColumn1.ReadOnly = true;
            this.lINEBOXNAMEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // aDDRESSCODEDataGridViewTextBoxColumn3
            // 
            this.aDDRESSCODEDataGridViewTextBoxColumn3.DataPropertyName = "ADDRESSCODE";
            this.aDDRESSCODEDataGridViewTextBoxColumn3.HeaderText = "ADDRESSCODE";
            this.aDDRESSCODEDataGridViewTextBoxColumn3.Name = "aDDRESSCODEDataGridViewTextBoxColumn3";
            this.aDDRESSCODEDataGridViewTextBoxColumn3.ReadOnly = true;
            this.aDDRESSCODEDataGridViewTextBoxColumn3.Visible = false;
            // 
            // cIGCODEDataGridViewTextBoxColumn1
            // 
            this.cIGCODEDataGridViewTextBoxColumn1.DataPropertyName = "CIGCODE";
            this.cIGCODEDataGridViewTextBoxColumn1.HeaderText = "CIGCODE";
            this.cIGCODEDataGridViewTextBoxColumn1.Name = "cIGCODEDataGridViewTextBoxColumn1";
            this.cIGCODEDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cIGNAMEDataGridViewTextBoxColumn1
            // 
            this.cIGNAMEDataGridViewTextBoxColumn1.DataPropertyName = "CIGNAME";
            this.cIGNAMEDataGridViewTextBoxColumn1.HeaderText = "CIGNAME";
            this.cIGNAMEDataGridViewTextBoxColumn1.Name = "cIGNAMEDataGridViewTextBoxColumn1";
            this.cIGNAMEDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // qTYDataGridViewTextBoxColumn2
            // 
            this.qTYDataGridViewTextBoxColumn2.DataPropertyName = "QTY";
            this.qTYDataGridViewTextBoxColumn2.HeaderText = "QTY";
            this.qTYDataGridViewTextBoxColumn2.Name = "qTYDataGridViewTextBoxColumn2";
            this.qTYDataGridViewTextBoxColumn2.ReadOnly = true;
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
            // 
            // oRDERDATEDataGridViewTextBoxColumn1
            // 
            this.oRDERDATEDataGridViewTextBoxColumn1.DataPropertyName = "ORDERDATE";
            this.oRDERDATEDataGridViewTextBoxColumn1.HeaderText = "ORDERDATE";
            this.oRDERDATEDataGridViewTextBoxColumn1.Name = "oRDERDATEDataGridViewTextBoxColumn1";
            this.oRDERDATEDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // pICKLINECODEDataGridViewTextBoxColumn1
            // 
            this.pICKLINECODEDataGridViewTextBoxColumn1.DataPropertyName = "PICKLINECODE";
            this.pICKLINECODEDataGridViewTextBoxColumn1.HeaderText = "PICKLINECODE";
            this.pICKLINECODEDataGridViewTextBoxColumn1.Name = "pICKLINECODEDataGridViewTextBoxColumn1";
            this.pICKLINECODEDataGridViewTextBoxColumn1.ReadOnly = true;
            this.pICKLINECODEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // pICKLINENAMEDataGridViewTextBoxColumn1
            // 
            this.pICKLINENAMEDataGridViewTextBoxColumn1.DataPropertyName = "PICKLINENAME";
            this.pICKLINENAMEDataGridViewTextBoxColumn1.HeaderText = "PICKLINENAME";
            this.pICKLINENAMEDataGridViewTextBoxColumn1.Name = "pICKLINENAMEDataGridViewTextBoxColumn1";
            this.pICKLINENAMEDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cUSTCODEDataGridViewTextBoxColumn1
            // 
            this.cUSTCODEDataGridViewTextBoxColumn1.DataPropertyName = "CUSTCODE";
            this.cUSTCODEDataGridViewTextBoxColumn1.HeaderText = "CUSTCODE";
            this.cUSTCODEDataGridViewTextBoxColumn1.Name = "cUSTCODEDataGridViewTextBoxColumn1";
            this.cUSTCODEDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cUSTNAMEDataGridViewTextBoxColumn1
            // 
            this.cUSTNAMEDataGridViewTextBoxColumn1.DataPropertyName = "CUSTNAME";
            this.cUSTNAMEDataGridViewTextBoxColumn1.HeaderText = "CUSTNAME";
            this.cUSTNAMEDataGridViewTextBoxColumn1.Name = "cUSTNAMEDataGridViewTextBoxColumn1";
            this.cUSTNAMEDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // iNDEXNODataGridViewTextBoxColumn1
            // 
            this.iNDEXNODataGridViewTextBoxColumn1.DataPropertyName = "INDEXNO";
            this.iNDEXNODataGridViewTextBoxColumn1.HeaderText = "INDEXNO";
            this.iNDEXNODataGridViewTextBoxColumn1.Name = "iNDEXNODataGridViewTextBoxColumn1";
            this.iNDEXNODataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // oUTPORTDataGridViewTextBoxColumn1
            // 
            this.oUTPORTDataGridViewTextBoxColumn1.DataPropertyName = "OUTPORT";
            this.oUTPORTDataGridViewTextBoxColumn1.HeaderText = "OUTPORT";
            this.oUTPORTDataGridViewTextBoxColumn1.Name = "oUTPORTDataGridViewTextBoxColumn1";
            this.oUTPORTDataGridViewTextBoxColumn1.ReadOnly = true;
            this.oUTPORTDataGridViewTextBoxColumn1.Visible = false;
            // 
            // statusDataGridViewTextBoxColumn1
            // 
            this.statusDataGridViewTextBoxColumn1.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn1.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn1.Name = "statusDataGridViewTextBoxColumn1";
            this.statusDataGridViewTextBoxColumn1.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn1.Visible = false;
            // 
            // sortingTimeDataGridViewTextBoxColumn1
            // 
            this.sortingTimeDataGridViewTextBoxColumn1.DataPropertyName = "SortingTime";
            this.sortingTimeDataGridViewTextBoxColumn1.HeaderText = "SortingTime";
            this.sortingTimeDataGridViewTextBoxColumn1.Name = "sortingTimeDataGridViewTextBoxColumn1";
            this.sortingTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // finishTimeDataGridViewTextBoxColumn1
            // 
            this.finishTimeDataGridViewTextBoxColumn1.DataPropertyName = "FinishTime";
            this.finishTimeDataGridViewTextBoxColumn1.HeaderText = "FinishTime";
            this.finishTimeDataGridViewTextBoxColumn1.Name = "finishTimeDataGridViewTextBoxColumn1";
            this.finishTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // abnSortingLineTaskListBindingSource1
            // 
            this.abnSortingLineTaskListBindingSource1.DataSource = typeof(BusinessLogic.SortingTask.AbnSortingLineTaskList);
            // 
            // sortingTaskArrivesBindingSource
            // 
            this.sortingTaskArrivesBindingSource.DataSource = typeof(BusinessLogic.arrive.SortingTaskArrives);
            // 
            // sortingTaskIssuedListBindingSource1
            // 
            this.sortingTaskIssuedListBindingSource1.DataSource = typeof(HDWLogic.Issued.SortingTaskIssuedList);
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
            // 
            // shortname
            // 
            this.shortname.DataPropertyName = "shortname";
            this.shortname.HeaderText = "shortname";
            this.shortname.Name = "shortname";
            this.shortname.ReadOnly = true;
            // 
            // cUSTNAMEDataGridViewTextBoxColumn
            // 
            this.cUSTNAMEDataGridViewTextBoxColumn.DataPropertyName = "CUSTNAME";
            this.cUSTNAMEDataGridViewTextBoxColumn.HeaderText = "CUSTNAME";
            this.cUSTNAMEDataGridViewTextBoxColumn.Name = "cUSTNAMEDataGridViewTextBoxColumn";
            this.cUSTNAMEDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.oUTPORTDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Visible = false;
            // 
            // sortingTimeDataGridViewTextBoxColumn
            // 
            this.sortingTimeDataGridViewTextBoxColumn.DataPropertyName = "SortingTime";
            this.sortingTimeDataGridViewTextBoxColumn.HeaderText = "SortingTime";
            this.sortingTimeDataGridViewTextBoxColumn.Name = "sortingTimeDataGridViewTextBoxColumn";
            this.sortingTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // finishTimeDataGridViewTextBoxColumn
            // 
            this.finishTimeDataGridViewTextBoxColumn.DataPropertyName = "FinishTime";
            this.finishTimeDataGridViewTextBoxColumn.HeaderText = "FinishTime";
            this.finishTimeDataGridViewTextBoxColumn.Name = "finishTimeDataGridViewTextBoxColumn";
            this.finishTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnSorting
            // 
            this.btnSorting.HeaderText = "完成分拣";
            this.btnSorting.Image = ((System.Drawing.Image)(resources.GetObject("btnSorting.Image")));
            this.btnSorting.Name = "btnSorting";
            this.btnSorting.ReadOnly = true;
            this.btnSorting.Text = null;
            this.btnSorting.Visible = false;
            // 
            // CAbnSortingTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.superTabControl1);
            this.DoubleBuffered = true;
            this.Name = "CAbnSortingTask";
            this.Size = new System.Drawing.Size(1014, 477);
            this.Load += new System.EventHandler(this.CSortingTask_Load);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgviewfindetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewfin)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgviewnone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewnonedetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.abnSortingLineTaskListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abnSortingLineTaskDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abnSortingLineTaskListBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortingTaskArrivesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortingTaskIssuedListBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DoubleBufferDataGridViewX dgviewnone;
        private System.Windows.Forms.DataGridViewTextBoxColumn finisheTimeDataGridViewTextBoxColumn;
        private DoubleBufferDataGridViewX dgviewnonedetail;
        private DoubleBufferDataGridViewX dgviewfindetail;
        private DoubleBufferDataGridViewX dgviewfin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pLCFLAGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pLCTASKNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLOCATIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oRDERNUMBERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn lINEBOXCODEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDDRESSCODEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTYDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource sortingTaskArrivesBindingSource;
        private System.Windows.Forms.BindingSource sortingTaskIssuedListBindingSource1;
        private BindingSource abnSortingLineTaskListBindingSource1;
        private BindingSource abnSortingLineTaskListBindingSource;
        private BindingSource abnSortingLineTaskDetailsBindingSource;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn sORTINGTASKNODataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn oRDERDATEDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn sUBLINECODEDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn sUBLINENAMEDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn lINEBOXCODEDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn lINEBOXNAMEDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn aDDRESSCODEDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn cIGCODEDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cIGNAMEDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn qTYDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn sORTINGTASKNODataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn oRDERDATEDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn sUBLINECODEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sUBLINENAMEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lINEBOXCODEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lINEBOXNAMEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aDDRESSCODEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cIGCODEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cIGNAMEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn qTYDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn sORTINGTASKNODataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn oRDERDATEDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn pICKLINECODEDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn pICKLINENAMEDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cUSTCODEDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cUSTNAMEDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn iNDEXNODataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn oUTPORTDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn sortingTimeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn finishTimeDataGridViewTextBoxColumn1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.LabelX labindexno;
        private DevComponents.DotNetBar.LabelX labcustname;
        private DevComponents.DotNetBar.LabelX labcustcode;
        private DevComponents.DotNetBar.LabelX labpicklinename;
        private DevComponents.DotNetBar.LabelX laborderdate;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labSortingtaskno;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 设置分拣未完成ToolStripMenuItem;
        private ToolStripMenuItem 设置分拣已完成ToolStripMenuItem;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sORTINGTASKNODataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn oRDERDATEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pICKLINECODEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pICKLINENAMEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cUSTCODEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shortname;
        private DataGridViewTextBoxColumn cUSTNAMEDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iNDEXNODataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn oUTPORTDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sortingTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn finishTimeDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn btnSorting;
    }
}

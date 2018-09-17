using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.materials;

namespace MonitorMain.CustomContorl
{
    public partial class CMaterialsDetal : UserControl
    {
        public CMaterialsDetal(MaterialsDetial materialsDetial)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); //双缓冲
            this.UpdateStyles();
            InitializeComponent();
	        CMaterialsDetial = materialsDetial;
	        labCigName.Text = materialsDetial.rownum + "、" + materialsDetial.cigname;
	        labpiece.Text = materialsDetial.pickNum.ToString();
	        labqty.Text =  materialsDetial.qty.ToString();
            labtotqty.DataBindings.Add("Text", CMaterialsDetial, "tQty", false, DataSourceUpdateMode.OnPropertyChanged);
            labsorting.DataBindings.Add("Text", CMaterialsDetial, "sortingNum", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public MaterialsDetial CMaterialsDetial { get; set; }

	    public void UpdateCMaterialsDetal()
	    {
            labCigName.Text = CMaterialsDetial.rownum + "、" + CMaterialsDetial.cigname;
            labpiece.Text = CMaterialsDetial.pickNum.ToString();
            labqty.Text = CMaterialsDetial.qty.ToString();
            labtotqty.Text = CMaterialsDetial.tQty.ToString();
	    }

	    public Color BackColor {
            set { this.panelEx1.Style.BackColor2.Color = value; } 
	    }


    }
}

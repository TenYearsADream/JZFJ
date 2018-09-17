using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MonitorMain.CustomContorl.Search;

namespace MonitorMain
{
    public partial class frmLineBoxSearch : Form
    {
        public frmLineBoxSearch()
        {
            InitializeComponent();
        }

        private void frmLineBoxSearch_Load(object sender, EventArgs e)
        {
            CLineBoxSearch clineboxsearch = new CLineBoxSearch();
            clineboxsearch.Dock = DockStyle.Fill;
            this.Controls.Add(clineboxsearch);
        }

    }
}

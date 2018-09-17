using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace MonitorMain.ToolView
{
    public class CreateForms
    {
        public static Control CreateNewDocumentControl(string classname)
        {
            Control control = (Control)Activator.CreateInstance(Type.GetType(classname));
            return control;
        }
    }
}

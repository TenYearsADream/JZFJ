using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MonitorMain
{
    public partial class DummyOutputWindow : UserControl
    {
        private string _systemlog;
        private int min, max;
        private int pos = 0;
        private int endPos = 0;
        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int SB_THUMBPOSITION = 4;
        [DllImport("user32.dll")]
        private static extern int SetScrollPos(IntPtr hwnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll")]
        private static extern int GetScrollPos(IntPtr hwnd, int nBar);
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, int nBar, int wParam, int lParam);
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos); 




        public DummyOutputWindow()
        {
            InitializeComponent();
        }

        private void DummyOutputWindow_Load(object sender, EventArgs e)
        {

        }

        public string SystemLog { get { return _systemlog; } set { richTextBox1.Text += _systemlog = value; } }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //得到滚动条的最大最小值 
            GetScrollRange(richTextBox1.Handle, SB_VERT, out min, out max);
            //得到滚动条到最底下的实际位置 
            endPos = max - richTextBox1.ClientRectangle.Height;
            this.timer1.Enabled = true; 

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pos = GetScrollPos(richTextBox1.Handle, SB_VERT);//加上这句是为了如果用户手动拖拽滚动条，可以保证滚动条继续从拖拽的位置走 
            pos = pos+7;
            //如果已经到底，那么停止Timer 
            if (pos > endPos)
            {
                this.timer1.Enabled = false;
                return;
            }
            SetScrollPos(richTextBox1.Handle, pos, endPos, true);
            PostMessage(richTextBox1.Handle, WM_VSCROLL, SB_THUMBPOSITION + 0x10000 * pos, 0); 

        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
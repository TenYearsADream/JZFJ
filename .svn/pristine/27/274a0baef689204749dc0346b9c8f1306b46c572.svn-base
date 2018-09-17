using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace KeerSolutions.MobileCommerce.AutoUpdate
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool hasMutex;//是否存在互斥体
            using (var mutex = new System.Threading.Mutex(false, "SINGLE_INSTANCE_MUTEX", out hasMutex))
            {
                if (hasMutex)
                {
                    //如果应用程序没有运行
                    Application.Run(new UpdateForm());
                }
                else
                {
                    MessageBox.Show("应用程序已经在运行中！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BusinessLogic.Print;

namespace PosPrint
{
    /// <summary>
    /// 打印
    /// 
    /// </summary>
    public class LPTPrintSetup
    {
        private LPTPrinter print;
        private int fontsize = 13;
        private int titlefontsize = 14;
        private Num2String num2string = new Num2String();

        public bool SetupThePrinting(PrintDocument MyPrintDocument, SYSPrintsettings theSysPrintsetting, PrintInfo thePrintInfo)
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;
	        MyPrintDialog.PrinterSettings.DefaultPageSettings.Landscape = false;

            MyPrintDocument.DocumentName = thePrintInfo.CustomerName + "标签";            
            
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;

            foreach (PrinterResolution item in MyPrintDocument.PrinterSettings.PrinterResolutions)
            {
                if(item.X>100 && item.Y>100)
                {
                    MyPrintDocument.DefaultPageSettings.PrinterResolution = item;
                }
            }

            MyPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            Invoice.Titel.Clear();
            Invoice.Details.Clear();
            Invoice.Floot.Clear();

            PrintSettings printSettings  = PrintSettings.GetSettings();
            PrintTypes printTypes = new PrintTypes();

            //循环printSetting表内的设置项
            foreach (PrintSetting printSetting in printSettings)
	        {
		        foreach (PrintType printType in printTypes)
		        {
                    //获取属性描述对应的属性名称
			        if (printType.TypeText == printSetting.PrintText)
			        {
                        Type type = thePrintInfo.GetType(); //获取类型
                        System.Reflection.PropertyInfo propertyInfo = type.GetProperty(printType.TypeName); //获取指定名称的属性
                        string value_Old = propertyInfo.GetValue(thePrintInfo, null).ToString(); //获取属性值 
                        Invoice.Details.Add(new InvoiceDetail(printSetting.PrintLable + value_Old,printSetting.X,printSetting.Y,printSetting.Font,printSetting.FontSize));
			        }
		        }
                
	        }
            print = new LPTPrinter(MyPrintDocument, Color.Black);
            
            Invoice.IsPageturn = theSysPrintsetting.IsPageturn;
            Invoice.ItemHeight_M = 40;
            Invoice.BlankHeight_M = 0;
            return true;
        }

        public LPTPrinter getLPTPrinter()
        {
            if (print != null)
            {
                return print;
            }
            else
            {
                throw new Exception("请先调用打印机设置！");
            }
        }

        public int Text_Length(string Text)
        {
            int len = 0;

            for (int i = 0; i < Text.Length; i++)
            {
                byte[] byte_len = Encoding.Default.GetBytes(Text.Substring(i, 1));
                if (byte_len.Length > 1)
                    len += 2;  //如果长度大于1，是中文，占两个字节，+2
                else
                    len += 1;  //如果长度等于1，是英文，占一个字节，+1
            }

            return len;
        }
    }



}

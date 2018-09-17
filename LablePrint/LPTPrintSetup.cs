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
    /// ��ӡ
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

            MyPrintDocument.DocumentName = thePrintInfo.CustomerName + "��ǩ";            
            
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

            //ѭ��printSetting���ڵ�������
            foreach (PrintSetting printSetting in printSettings)
	        {
		        foreach (PrintType printType in printTypes)
		        {
                    //��ȡ����������Ӧ����������
			        if (printType.TypeText == printSetting.PrintText)
			        {
                        Type type = thePrintInfo.GetType(); //��ȡ����
                        System.Reflection.PropertyInfo propertyInfo = type.GetProperty(printType.TypeName); //��ȡָ�����Ƶ�����
                        string value_Old = propertyInfo.GetValue(thePrintInfo, null).ToString(); //��ȡ����ֵ 
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
                throw new Exception("���ȵ��ô�ӡ�����ã�");
            }
        }

        public int Text_Length(string Text)
        {
            int len = 0;

            for (int i = 0; i < Text.Length; i++)
            {
                byte[] byte_len = Encoding.Default.GetBytes(Text.Substring(i, 1));
                if (byte_len.Length > 1)
                    len += 2;  //������ȴ���1�������ģ�ռ�����ֽڣ�+2
                else
                    len += 1;  //������ȵ���1����Ӣ�ģ�ռһ���ֽڣ�+1
            }

            return len;
        }
    }



}

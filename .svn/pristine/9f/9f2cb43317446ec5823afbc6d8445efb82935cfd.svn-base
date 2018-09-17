using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PosPrint
{
    static public class Invoice
    {
        static private ArrayList titel = new ArrayList();

        static public ArrayList Titel
        {
            get { return titel; }
            set { titel = value; }
        }

        static private InvoiceDetails details = new InvoiceDetails();
        static public InvoiceDetails Details
        {
            get { return details; }
            set { details = value; }
        }

        static private ArrayList floot = new ArrayList();
        static public ArrayList Floot
        {
            get { return floot; }
            set { floot = value; }
        }

        static private bool ispageturn;

        static public bool IsPageturn 
        {
            get { return ispageturn; }
            set { ispageturn = value; }
        }

        static private float itemheight_M;

        static public float ItemHeight_M
        {
            get { return itemheight_M; }
            set { itemheight_M = value; }
        }

        static private float blankheight_M;

        static public float BlankHeight_M
        {
            get { return blankheight_M; }
            set { blankheight_M = value; }
        }
    }

    public class InvoiceDetails : List<InvoiceDetail>
    {
        
    }

    public class InvoiceDetail
    {
        public string DetailName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Font { get; set; }
        public float FontSize { get; set; }

        public InvoiceDetail(string name, int x, int y, string font, float fontsize)
        {
            DetailName = name;
            X = x;
            Y = y;
            Font = font;
            FontSize = fontsize;
            if (string.IsNullOrEmpty(font))
            {
	            Font = "ºÚÌå";
            }
        }
    }
}

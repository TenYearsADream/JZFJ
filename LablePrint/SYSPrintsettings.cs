using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PosPrint
{
    /// <summary>
    /// 打印设置
    /// </summary>
    public class SYSPrintsettings
    {

        /// <summary>
        /// Ctor
        /// </summary>
        public SYSPrintsettings()
        {
            this.ReadConfig();
        }

        public string PageHeader { get; set; }

        //端口
        private string post;
        public string Post
        {
            get { return post; }
            set { post = value; }
        }

        //页脚1
        private string pageFloot1;
        public string PageFloot1
        {
            get { return pageFloot1; }
            set { pageFloot1 = value; }
        }
        //页脚2
        private string pageFloot2;
        public string PageFloot2
        {
            get { return pageFloot2; }
            set { pageFloot2 = value; }
        }

        //是否标题字体大号
        private bool isBigFont;
        public bool IsBigFont
        {
            get { return isBigFont; }
            set { isBigFont = value; }
        }

        //是否打印交易时间
        private bool isSellTime;
        public bool IsSellTime
        {
            get { return isSellTime; }
            set { isSellTime = value; }
        }


        private bool isdiscount;
        public bool IsDiscount
        {
            get { return isdiscount; }
            set { isdiscount = value; }
        }

        //是否打印找零
        private bool ischange;
        public  bool IsChange
        {
            get { return ischange; }
            set { ischange = value; }
        }

        //是否打印销售员编号
        private bool issalesperson;
        public  bool IsSalesPerson
        {
            get { return issalesperson; }
            set { issalesperson = value; }
        }

        //是否翻页打印
        private bool ispageturn;
        public bool IsPageturn
        {
            get { return ispageturn; }
            set { ispageturn = value; }
        }

        //翻页长度
        private string printHeight;
        public string PrintHeight
        {
            get { return printHeight; }
            set { printHeight = value; }
        }

        //排头空行
        private string blankHeight;
        public string BlankHeight
        {
            get { return blankHeight; }
            set { blankHeight = value; }
        }

        //读
        private void ReadConfig()
        {
            XmlDocument doc = new XmlDocument();
            //获得配置文件的全路径
            string strFileName = AppDomain.CurrentDomain.BaseDirectory.ToString() + "PrintSet.xml";
            doc.Load(strFileName);
            //找出名称为“add”的所有元素
            XmlNodeList nodes = doc.GetElementsByTagName("PrintSetting");
            nodes = nodes[0].ChildNodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                switch (nodes[i].Name)
                {
                    case "PageHeader":
                        PageHeader = nodes[i].InnerText ;
                        break;
                    case "PageFloot1":
                        pageFloot1 = nodes[i].InnerText;
                        break;
                    case "PageFloot2":
                        pageFloot2 = nodes[i].InnerText;
                        break;
                    case "Post":
                        post = nodes[i].InnerText;
                        break;
                    case "IsBigFont":
                        isBigFont = bool.Parse(nodes[i].InnerText);
                        break;
                    case "IsSellTime":
                        isSellTime = bool.Parse(nodes[i].InnerText);
                        break;
                    case "IsDiscount":
                        isdiscount = bool.Parse(nodes[i].InnerText);
                        break;
                    case "IsChange":
                        ischange = bool.Parse(nodes[i].InnerText);
                        break;
                    case "IsSalesPerson":
                        issalesperson = bool.Parse(nodes[i].InnerText);
                        break;
                    case "PrintHeight":
                        printHeight = nodes[i].InnerText;
                        break;
                    case "BlankHeight":
                        blankHeight = nodes[i].InnerText;
                        break;
                    case "IsPageturn":
                        ispageturn =  bool.Parse(nodes[i].InnerText);
                        break;
                    default:
                        break;
                }

            }

        }

        //写
        public void SetValue()
        {
            XmlDocument doc = new XmlDocument();
            //获得配置文件的全路径
            string strFileName = AppDomain.CurrentDomain.BaseDirectory.ToString() + "PrintSet.xml";
            doc.Load(strFileName);
            //找出名称为“add”的所有元素
            XmlNodeList nodes = doc.GetElementsByTagName("PrintSetting");
            nodes = nodes[0].ChildNodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                switch (nodes[i].Name)
                {
                    case "PageHeader":
                        nodes[i].InnerText = PageHeader;
                        break;
                    case "PageFloot1":
                        nodes[i].InnerText = pageFloot1;
                        break;
                    case "PageFloot2":
                        nodes[i].InnerText = pageFloot2;
                        break;
                    case "Post":
                        nodes[i].InnerText = post;
                        break;
                    case "IsBigFont":
                        nodes[i].InnerText = isBigFont.ToString();
                        break;
                    case "IsSellTime":
                        nodes[i].InnerText = isSellTime.ToString();
                        break;
                    case "IsDiscount":
                        nodes[i].InnerText = isdiscount.ToString();
                        break;
                    case "IsChange":
                        nodes[i].InnerText = ischange.ToString();
                        break;
                    case "IsSalesPerson":
                        nodes[i].InnerText = issalesperson.ToString();
                        break;
                    case "PrintHeight":
                        nodes[i].InnerText = printHeight;
                        break;
                    case "BlankHeight":
                        nodes[i].InnerText = blankHeight;
                        break;
                    case "IsPageturn":
                        nodes[i].InnerText = ispageturn.ToString();
                        break;
                    default:
                        break;
                }

            }
            doc.Save(AppDomain.CurrentDomain.BaseDirectory.ToString() + "PrintSet.xml");
        }
	
	
	
	
	
	
    }
}

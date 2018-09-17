using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace BusinessLogic.Print
{
    public class PrintType
    {
	    public string TypeName { get; set; }
        public string TypeText { get; set; }

	    public PrintType(string typename,string typetext)
	    {
		    TypeName = typename;
		    TypeText = typetext;
	    }
    }

	public class PrintTypes:List<PrintType>
	{
		
		public PrintTypes()
		{
            Type t = typeof(PrintInfo);
             System.Reflection.PropertyInfo[] properties = t.GetProperties();
            foreach (System.Reflection.PropertyInfo property in properties)
            {

                switch (property.Name)
	            {
                    case "CustomerName":
                        Add(new PrintType("CustomerName","客户姓名"));
                        break;
                    case "IndexNo":
                        Add(new PrintType("IndexNo","客户顺序"));
                        break;
                    case "CustomerCode":
                        Add(new PrintType("CustomerCode","客户代码"));
                        break;
                    case "CurrentNum":
                        Add(new PrintType("CurrentNum", "条数"));
                        break;
                    case "BoxNo":
                        Add(new PrintType("BoxNo","包序"));
                        break;
                    case "BoxCount":
                        Add(new PrintType("BoxCount","总包数"));
                        break;
                    case "CustomerSqe":
                        Add(new PrintType("CustomerSqe","客户线路顺序"));
                        break;
                    case "CustomerBoxSqe":
                        Add(new PrintType("CustomerBoxSqe", "客户线路包顺序"));
                        break;
                    case "DelivyLine":
                        Add(new PrintType("DelivyLine","线路名称"));
                        break;
                    case "SortingDate":
                        Add(new PrintType("SortingDate", "分拣日期"));
                        break;
                    case "AbnoBoxCount":
                        Add(new PrintType("AbnoBoxCount","异型烟数量"));
                        break;
                    case "Address":
                        Add(new PrintType("Address", "地址"));
                        break;
                    case "BoxIndex":
                        Add(new PrintType("BoxIndex", "总包序"));
                        break;
	            }
	            
            }

			
		}
	}
}

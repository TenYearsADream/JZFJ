using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PosPrint
{
    public class Order
    {
        private string orderID;

        private string salesPersonID;

        private DateTime saleTime;
        public string OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public string SalesPersonID
        {
            get { return salesPersonID; }
            set { salesPersonID = value; }
        }

        public DateTime SaleTime
        {
            get { return saleTime; }
            set { saleTime = value; }
        }

        

        private int tatolQuantity;

        public int TatolQuantity
        {
            get { return tatolQuantity; }
            set { tatolQuantity = value; }
        }

        private double tatolAmount;

        public double TatolAmout
        {
            get { return tatolAmount; }
            set { tatolAmount = value; }
        }

        private double payment;

        public double Payment
        {
            get { return payment; }
            set { payment = value; }
        }


        private double change;

        public double Change
        {
            get { return change; }
            set { change = value; }
        }       
	
    }
}

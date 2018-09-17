using System;
using Csla;
using Csla.Data;

namespace BusinessLogic.Search
{
   [Serializable]
    public class SortingCigInfo : ReadOnlyBase<SortingCigInfo>
    {
       public string OrderDate { get; set; }
       public string SortingTaskNo { get; set; }
        public string CigCode { get; private set; }
        public string CigName { get; private set; }
        public int Qty { get;  set; }
        
        

        private SortingCigInfo()
        {
            /* require use of factory methods */
        }

        internal SortingCigInfo(SafeDataReader dr)
        {
            OrderDate = dr.GetString("OrderDate");
            SortingTaskNo = dr.GetString("SortingTaskNo");
            CigCode = dr.GetString("CigCode");
            CigName = dr.GetString("CigName");
            Qty = dr.GetInt32("Qty");
            
        }
    }
}

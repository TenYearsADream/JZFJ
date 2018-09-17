using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using Csla.Data;

namespace BusinessLogic.Search
{
    [Serializable]
    public class LineBoxProcessInfo : ReadOnlyBase<LineBoxProcessInfo>
    {
        public string LINEBOXCODE { get; set; }
        public string LINEBOXNAME { get; set; }
        public string CigCode { get; private set; }
        public string CigName { get; private set; }
        public int TOTQTY { get; private set; }        
        public int NONQTY { get; set; }
        public int FINQTY { get; set; }
        public int OUTQTY { get; set; }
        public int REMAINQTY { get; set; }
    
    
        public double proportion { get; private set; }

        private LineBoxProcessInfo()
        {
            /* require use of factory methods */
        }

        internal LineBoxProcessInfo(SafeDataReader dr)
        {
            LINEBOXCODE = dr.GetString("BOXCODE");
            LINEBOXNAME = dr.GetString("BOXNAME");
            CigCode = dr.GetString("CigCode");
            CigName = dr.GetString("CigName");
            TOTQTY = dr.GetInt32("TOTQTY");
            try
            {
                NONQTY = dr.GetInt32("NONQTY");
                FINQTY = dr.GetInt32("FINQTY");

            }
            catch (Exception)
            {

              
            }
            
            if (TOTQTY > 0)
            {
                proportion = Convert.ToDouble((NONQTY / Convert.ToDouble(TOTQTY) * 100).ToString("#0.00"));
            }
            else
            {
                proportion = 0;
            }
            
        }
    }
}

using System;
using Csla;
using Csla.Data;

namespace BusinessLogic.Common
{

    [Serializable]
    public class CigInfo : ReadOnlyBase<CigInfo>
    {

        public string CIGARETTENO { get; set; }

        public string CIGARETTENAME { get; set; }

        public string BARCODE { get; set; }

        public string LineBoxCode { get; set; }

        public string LineBoxName { get; set; }



        private CigInfo()
        {
            /* require use of factory methods */
        }

        internal CigInfo(SafeDataReader dr)
        {
            CIGARETTENO = dr.GetString("CIGARETTENO");
            CIGARETTENAME = dr.GetString("CIGARETTENAME");
            BARCODE = dr.GetString("BARCODE");
            LineBoxCode = dr.GetString("BoxCode");
            LineBoxName = dr.GetString("BoxName");
        }
    }
}

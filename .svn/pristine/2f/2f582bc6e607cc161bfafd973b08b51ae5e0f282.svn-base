using System;
using Csla;
using Csla.Data;

namespace BusinessLogic.PlcDataSettings
{
   [Serializable]
    public class PLCDataInfo : ReadOnlyBase<PLCDataInfo>
    {
        public string TYPECODE { get; private set; }
        public string TYPENAME { get; private set; }
        public string DBBLOCK { get; private set; }
        public string BASEADDRESS { get; private set; }
        public int ROWSIZE { get; private set; }
        public int ROWCOUNT { get; private set; }

        

        private PLCDataInfo()
        {
            /* require use of factory methods */
        }

        internal PLCDataInfo(SafeDataReader dr)
        {
            TYPECODE = dr.GetString("TYPECODE");
            TYPENAME = dr.GetString("TYPENAME");
            DBBLOCK = dr.GetString("DBBLOCK");
            BASEADDRESS = dr.GetString("BASEADDRESS");
            ROWSIZE = dr.GetInt32("ROWSIZE");
            ROWCOUNT = dr.GetInt32("ROWCOUNT"); 
        }
    }
}

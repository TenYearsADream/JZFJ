using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeerSolutions.MobileCommerce.AutoUpdate
{
    using System.Net;

    public class CWebClient:WebClient
    {
        public int Sequence { get; set; }
    }
}

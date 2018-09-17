using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlcContract
{
   public abstract class FlowBasic
    {
       public virtual int Flow()
       {
           return 1;
       }
    }
}

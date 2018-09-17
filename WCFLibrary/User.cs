using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//添加引用
using System.ServiceModel;

namespace WCFLibrary
{
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        string ShowName(string name);
    }
}

namespace WCFLibrary
{
    public class User : IUser
    {
        public string ShowName(string name)
        {
            string wcfName = string.Format("WCF服务，显示姓名：{0}", name);
            return wcfName;
        }
    }
}
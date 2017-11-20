using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依赖项注入
{
    //打断和声明依赖项
    public class Client
    {
        private IEmail duix;
        public Client(IEmail duix2)
        {
            duix = duix2;
        }

        public string SendXiaoXi()
        {
            return duix.SendMessage();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依赖项注入
{
    public class Email:IEmail
    {
        public string SendMessage()
        {
            return "ssss";
        }
    }
}

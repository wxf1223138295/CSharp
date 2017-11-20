using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Serviceb;

namespace SererHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebServiceHost host=new WebServiceHost(typeof(EmployServer)))
            {
                host.Open();
                Console.WriteLine("服务已启动");
                Console.Read();
            }
        }
    }
}

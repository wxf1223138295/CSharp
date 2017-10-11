using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.xfWebServiceFuncSoapClient x = new ServiceReference1.xfWebServiceFuncSoapClient();
            Console.WriteLine(x.HelloWorld());
            Console.ReadKey();
        }
    }
}

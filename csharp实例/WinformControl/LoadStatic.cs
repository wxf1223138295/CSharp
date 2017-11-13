using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinformControl
{
    public class LoadStatic
    {
        public static string  fun1()
        {
            Thread.Sleep(2000);
            return "fun1加载完毕";
        }
        public static string fun2()
        {
            Thread.Sleep(2000);
            return "fun2加载完毕";
        }
        public static string fun3()
        {
            Thread.Sleep(2000);
            return "fun3加载完毕";
        }
        public static string fun4()
        {
            Thread.Sleep(2000);
            return "fun4加载完毕";
        }
        public static string fun5()
        {
            Thread.Sleep(2000);
            return "fun5加载完毕";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            生产具体产品的抽象类工厂 子工厂1 = new 子工厂1();
            Console.WriteLine(子工厂1.CreateA产品().生产A());
            Console.WriteLine(子工厂1.CreateB产品().生产B());
            Console.WriteLine("-------------------------------------------------");
            生产具体产品的抽象类工厂 子工厂2 = new 子工厂2();
            Console.WriteLine(子工厂2.CreateA产品().生产A());
            Console.WriteLine(子工厂2.CreateB产品().生产B());
            Console.ReadKey();
        }
    }
}

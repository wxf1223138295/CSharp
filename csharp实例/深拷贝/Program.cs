using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 深拷贝
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p1 = new Person();
            //p1.Age = 1;
            //p1.Height = 1;
            //p1.Name = "1";

            //List<Person> list1 = new List<Person>();
            //list1.Add(p1);

            //List<Person> list2=FuncClone.Clone(list1);

            //list1.First().Name = "2";
            //list1.First().Height = 2;
            //list1.First().Age = 2;

            //Console.WriteLine(list2.First().Name);
            //Console.WriteLine(list2.First().Age);
            //Console.WriteLine(list2.First().Height);
            //-----------------------------------------------------------
            ClassAB ab = new ClassAB();
            ab.o = "1";
            ab.p = "1";
            ab.q = "1";
            ab.r = "1";

            Person p = new Person();
            p.Age = 1;
            p.Height = 1;
            p.Name = "1";
            ab.personer = p;

            ClassB b = new ClassB();
            FuncClone.CopyByType<IInterface>(b,ab);

            Console.ReadKey();
        }
    }
}

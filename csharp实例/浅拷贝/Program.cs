using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 浅拷贝
{
    class Program
    {
        static void Main(string[] args)
        {
            //引用类型的对象直接赋值实现浅copy
            //List<Person> 浅拷贝方式1 = Person.personList;
            //Console.WriteLine(Person.personList.First().Entity.jobName);

            //Console.WriteLine(浅拷贝方式1.First().Entity.jobName);

            //Person.personList.First().Entity.jobName = "教师";

            //Console.WriteLine(Person.personList.First().Entity.jobName);

            //Console.WriteLine(浅拷贝方式1.First().Entity.jobName);
            //Console.WriteLine("浅copy方式2");
            //Person[] 浅copy2 = new Person[2];

            //Person.personList.CopyTo(浅copy2);
            //Console.WriteLine(浅copy2.First().Entity.jobName);
            //Console.WriteLine("浅copy方式3");
            //ShallowCopy();
            toCopy();
            Console.ReadKey();
        }
        public static void toCopy()
        {
            ShallowCopyDemoClass n1 = new ShallowCopyDemoClass();
            n1.name = "1";
            n1.stu1.Age = 1;
            n1.stu1.Name = "1";
            ShallowCopyDemoClass n2 = new ShallowCopyDemoClass();
            n2 = n1;

            Console.WriteLine(n1.name);
            Console.WriteLine(n1.stu1.Name);
            Console.WriteLine(n2.name);
            Console.WriteLine(n1.stu1.Name);

            n1.name = "2";
            n1.stu1.Age = 2;
            n1.stu1.Name = "2";
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(n1.name);
            Console.WriteLine(n1.stu1.Name);
            Console.WriteLine(n2.name);
            Console.WriteLine(n1.stu1.Name);
        }
        public static void ShallowCopy()
        {
            //NET引用类型默认浅copy 值类型默认深copy
            ShallowCopyDemoClass n1 = new ShallowCopyDemoClass();
            n1.name = "First值类型不变的";
            n1.stu1.Name = "王五";
            ShallowCopyDemoClass n2 = n1.Clone() as ShallowCopyDemoClass;
            Console.WriteLine(n1.name);
         
            Console.WriteLine(n1.stu1.Name);
            Console.WriteLine(n2.name);
            Console.WriteLine(n1.stu1.Name);
            Console.WriteLine("-----------------------------------------------");
            n1.name = "Second值类型不变的";
            n1.stu1.Name = "赵六";
            Console.WriteLine(n1.name);
            Console.WriteLine(n1.stu1.Name);

            Console.WriteLine(n2.name);           
            Console.WriteLine(n2.stu1.Name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 浅拷贝
{
    public class Person
    {
        public Person()
        {

        }
        public Person(string name,int age,JobType _entity)
        {
            Name = name;
            Age = age;
            Entity = _entity;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public JobType Entity { get; set; }

       

        public static List<Person> personList = new List<Person>()
        {
            new Person("张三",34, new JobType("程序员",6000))
        };

    }
}

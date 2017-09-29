using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    //public delegate int Call(int a, int b);  
    class Program
    {
        static void Main(string[] args)
        {
            //Call dele = new Call(MathFunc.Divide);         
            //Console.WriteLine(dele.Invoke(8, 4));
            //委托对象（参数n）和委托对象.Invoke（参数n）

            Func<int, int,int> action = (a,b)=> { return MathFunc.Divide(a,b); };
           
            Console.WriteLine(action.Invoke(8,4));

            Console.ReadKey();
        }
    }
    class MathFunc
    {
        // 乘法方法
        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        // 除法方法
        public static int Divide(int num1, int num2)
        {
            return num1 / num2;
        }
    }
}

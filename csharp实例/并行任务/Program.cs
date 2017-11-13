using System;
using System.Threading;
using System.Threading.Tasks;

namespace 并行任务
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var _current = Thread.CurrentThread.CurrentUICulture;


            //Func<string> func = (() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"当前时间是{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff")}");
            //    return "ss"; });

            //List<Func<string>> list = new List<Func<string>>();
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(func);
            //}
            Action[] arry =
            {
                ()=> {Thread.Sleep(1000);
                    Console.WriteLine("1");
                },
                ()=> {Thread.Sleep(1000);
                    Console.WriteLine("2");
                },
                ()=> {Thread.Sleep(1000);
                    Console.WriteLine("3");
                },
                ()=> {Thread.Sleep(1000);
                    Console.WriteLine("4");
                },
                ()=> {Thread.Sleep(1000);
                    Console.WriteLine("5");
                },
            };


            //Action<Func<string>> act=((x)=> { func(); });

            var trx = new ParallelOptions {MaxDegreeOfParallelism = 1};


            //ParallelLoopResult y = Parallel.ForEach(list, trx, p => Task.Factory.StartNew((_curent) =>
            //     {
            //         Thread.CurrentThread.CurrentUICulture = _curent as CultureInfo;
            //         try { return p.Invoke(); }
            //         catch { return p.Method.Name + " Function Error!"; }
            //     }, _current)
            //     .ContinueWith(result =>
            //     {
            //         Console.WriteLine($"当前时间是{result.Result}");
            //     }));


            //ParallelLoopResult r = Parallel.ForEach(list, trx, p => act.Invoke(p));



            Parallel.Invoke(trx,arry);


            //Console.WriteLine("是否完成:{0}", r.IsCompleted);
            //Console.WriteLine("最低迭代:{0}", r.LowestBreakIteration);
            Console.ReadKey();
        }
    }

    internal class classA
    {
        public static string GetDateime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff");
        }
    }
}
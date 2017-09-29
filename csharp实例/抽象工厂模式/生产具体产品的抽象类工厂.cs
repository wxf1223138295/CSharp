using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂模式
{
    public abstract class 生产具体产品的抽象类工厂
    {
        //public static 生产具体产品的抽象类工厂 GetInstance()
        //{
        //    生产具体产品的抽象类工厂 instance;
        //    if (true)
        //        instance = (生产具体产品的抽象类工厂)Assembly.Load(@"I:\vsProjectDocument\XML\抽象工厂\bin\Debug").CreateInstance("子工厂1");
        //    else
        //        instance = null;

        //    return instance;
        //}
        //A B产品都是属于抽象类的工厂
        //生产产品的工厂 
        public abstract 生产产品A抽象类 CreateA产品();

        public abstract 生产产品B抽象类 CreateB产品();
    }
}

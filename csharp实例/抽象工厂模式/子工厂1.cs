using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂模式
{
    public class 子工厂1 : 生产具体产品的抽象类工厂
    {
        public override 生产产品A抽象类 CreateA产品()
        {
            return new 工厂1的产品A();
        }
        public override 生产产品B抽象类 CreateB产品()
        {
            return new 工厂1的产品B();
        }
    }
}

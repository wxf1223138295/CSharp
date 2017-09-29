using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂模式
{
    public class 工厂2的产品A : 生产产品A抽象类
    {
        public override string 生产A()
        {
            return "子工厂2自定义生产产品A";
        }
    }
}

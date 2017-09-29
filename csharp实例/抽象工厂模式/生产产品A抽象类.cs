using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂模式
{
    public abstract class 生产产品A抽象类
    {
        public virtual string 生产A()
        {
            return "生产A产品";
        }
    }
}

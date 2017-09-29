using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 深拷贝
{
    /// <summary>
    /// 进行序列化实现深度复制的实体类需要添加[Serializable]特性
    /// </summary>
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
    }
}

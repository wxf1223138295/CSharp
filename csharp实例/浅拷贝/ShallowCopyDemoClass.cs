using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 浅拷贝
{
    public class ShallowCopyDemoClass:ICloneable
    {
        private Student _stu1;

        public Student stu1
        {
            get
            {
                if (this._stu1 == null)
                    this._stu1 = new Student();
                return _stu1;
            }
            set { this._stu1 = value; }
        }
        public string name { get; set; }
        public object Clone()
        {
           return this.MemberwiseClone();
        }

    }
}

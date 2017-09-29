using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 深拷贝
{
    public class ClassB: IInterface
    {
        public string q { get; set; }
        public string r { get; set; }

        private Person _personer;

        public Person personer
        {
            get
            {
                if (this._personer == null)
                    this._personer = new Person();
                return _personer;
            }
            set { this._personer = value; }
        }
  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 松耦合
{
    public class Client
    {
        IEmil sss = new Emil();
        public void resd()
        {
            
            sss.GetString();
        }

    }
}

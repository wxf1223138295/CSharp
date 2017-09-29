using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 浅拷贝
{
    public class JobType
    {

        public JobType(string _jobname, decimal _slave)
        {
            jobName = _jobname;
            slave = _slave;
        }
        public string jobName { get; set; }
        public decimal slave { get; set; }
    }
}

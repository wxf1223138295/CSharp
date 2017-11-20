using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Serviceb
{
    [ServiceContract]
    public interface IEmployees
    {
        [WebGet(UriTemplate = "all")]
        List<Employee> GetAll();
    }
}

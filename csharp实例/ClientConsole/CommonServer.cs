using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Serviceb;

namespace ClientConsole
{
    public interface ICommonService
    {
        string getResult(int a);
    }
    public class CommonServer:BaseServer, ICommonService
    {
        private readonly string m_DicApi = "EmployServer/all";
        public string getResult(int AddParameter)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = m_DicApi;
            //request.AddParameter("AddParameter", AddParameter);
            var responseData = m_Client.Execute<List<Employee>>(request);
          

            return responseData.Data.First().Id;
        }
    }
}

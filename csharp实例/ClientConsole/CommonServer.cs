using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ClientConsole
{
    public interface ICommonService
    {
        DataTable getResult(int a);
    }
    public class CommonServer:BaseServer, ICommonService
    {
        private readonly string m_DicApi = "api/test";
        public DataTable getResult(int AddParameter)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = m_DicApi;
            request.AddParameter("AddParameter", AddParameter);
            var responseData = m_Client.Execute<DataTable>(request);
            var result = JsonConvert.DeserializeObject<DataTable>(responseData.Content);

            return result;
        }
    }
}

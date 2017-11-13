using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace restApi.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public DataTable GetResult(int AddParameter)
        {
            string sql = "Select * from MergeColumn";
            var table= DbHelperSQL.Query(sql).Tables[0];
            return table;
        }
    }
}

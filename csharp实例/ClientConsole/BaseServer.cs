using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Net.Http;

namespace ClientConsole
{
    public interface IBaseService
    {
        /// <summary>
        /// RestClient 初始化
        /// </summary>
        /// <param name="http"></param> 
        RestClient ServerInit(string http);
    }
    public class BaseServer: IBaseService
    {
        public BaseServer()
        {
            _Http = "http://localhost:8040";
            Uri uri=new Uri(_Http);
            m_Client.BaseUrl = uri;
        }
        public static RestClient m_Client = new RestClient();

        public static HttpClient client = new HttpClient();

        public static string _Http;
        /// <summary>
        /// RestClient 初始化
        /// </summary>
        /// <param name="http"></param>
        public RestClient ServerInit()
        {
            Uri uri=new Uri(_Http);
            m_Client.BaseUrl = uri;

            return m_Client;
        }
        /// <summary>
        /// RestClient请求 初始化
        /// </summary>
        /// <param name="http">请求http地址</param>
        public RestClient ServerInit(string http)
        {
            if (string.IsNullOrEmpty(http))
                throw new NotImplementedException("Http is empty!");

            http = http.StartsWith("http://") ? http : "http://" + http;
            var client = new RestClient(http);
            return client;
        }
    }
}

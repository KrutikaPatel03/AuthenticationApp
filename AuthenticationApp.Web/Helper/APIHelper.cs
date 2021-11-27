using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AuthenticationApp.Web.Helper
{
    public class APIHelper
    {
        public static string apiPath = ConfigurationManager.AppSettings["apiUrl"];
        public HttpClient Client => new HttpClient();
        /// <summary>
        /// Get Http Client
        /// </summary>
        /// <param name="headertype">headertype</param>
        /// <returns></returns>
        public static HttpClient GetHttpClient(string headertype)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(apiPath)
            };
            headertype = string.IsNullOrEmpty(headertype) ? "application/json" : headertype;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
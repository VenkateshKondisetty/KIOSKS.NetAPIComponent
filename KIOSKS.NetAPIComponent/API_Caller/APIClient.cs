using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace KIOSKS.NetAPIComponent.API_Caller
{
    public class APIClient
    {
        private HttpClient client;
        private HttpClientHandler handler;
        public APIClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            //handler = new HttpClientHandler();
            //handler.Credentials = new NetworkCredential("gfsuser", "gfsuser123!");
            //client = new HttpClient(handler);            
            //client.BaseAddress = new Uri("https://uat1.woolworthsmoney.com.au/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ////client.DefaultRequestHeaders.Add("content-length", "762");
            //client.DefaultRequestHeaders.Add("date", "Thu, 05 Oct 2017 01:37:58 GMT");
            //client.DefaultRequestHeaders.Add("x-akamai-staging", "ESSL");
            //client.DefaultRequestHeaders.Add("status", "200");
            //client.DefaultRequestHeaders.Add("x-xss-protection", "1;mode=block");

        }

        public async Task<T> GetAPIResponse<T>(string query)
        {
            dynamic responseObj = null;
            HttpResponseMessage response = await client.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                responseObj = await response.Content.ReadAsAsync<T>();
            }
            return responseObj;
        }
    }
}
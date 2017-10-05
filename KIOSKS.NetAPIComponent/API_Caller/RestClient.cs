using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace KIOSKS.NetAPIComponent.API_Caller
{
    public class ServiceClient
    {
        protected static string ServiceUrl = "https://uat1.woolworthsmoney.com.au/";
        private RestClient client;

        public ServiceClient()
        {
            this.client = new RestClient(ServiceUrl);
            client.Authenticator = new SimpleAuthenticator("username", "gfsuser", "password", "gfsuser123!");
        }


        public T GetServiceResponse<T>() where T : new()
        {
            RestRequest request = new RestRequest("api/gift-card/detail", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("content-length", "762");
            request.AddHeader("date", "Thu, 05 Oct 2017 01:37:58 GMT");
            request.AddHeader("x-akamai-staging", "ESSL");
            request.AddHeader("status", "200");
            request.AddHeader("x-xss-protection", "1;mode=block");
            request.AddHeader("x-frame-options", "SAMEORIGIN");
            request.JsonSerializer.ContentType = "application/json; charset=utf-8";
            IRestResponse<T> response = this.client.Execute<T>(request);
            if (response.ErrorException != null || response.StatusCode != HttpStatusCode.OK)
            {

            }

            return response.Data;
        }
    }
}
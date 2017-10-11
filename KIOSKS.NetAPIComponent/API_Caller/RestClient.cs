using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace KIOSKS.NetAPIComponent.API_Caller
{
    public class ServiceClient : RestSharp.RestClient
    {
        protected static string ServiceUrl = "https://uat1.woolworthsmoney.com.au/";
        private RestSharp.RestClient client;

        public ServiceClient()
        {
            client = new RestClient { BaseUrl = new Uri(ServiceUrl), Authenticator = new NtlmAuthenticator("gfsuser", "gfsuser123!") };
            client.AddDefaultHeader("Content-Type", "application/json");
            client.AddDefaultHeader("Authorization", "Basic Z2ZzdXNlcjpnZnN1c2VyMTIzIQ==");
        }


        public T GetServiceResponse<T>() where T : new()
        {
            RestRequest request = new RestRequest("api/gift-card/detail", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            BodyObject body = new BodyObject { token = "ek1:a4303041aad645d0e26cb4a526d01558", usa = "old:1baa0dbdadcd14719511ec51b9379a00d2fbcc24661155ee1b08fd51d80ecdca" };
            request.AddJsonBody(body);
            IRestResponse<T> response = this.client.Execute<T>(request);
            if (response.ErrorException != null || response.StatusCode != HttpStatusCode.OK)
            {
                //response.
            }

            return response.Data;
        }
    }

    public class BodyObject
    {
        public string token { get; set; }
        public string usa { get; set; }
    }
}
using System;
using System.Net;
using EpaycoSdk.Models;
using EpaycoSdk.Models.Auth;
using Newtonsoft.Json;
using RestSharp;

namespace EpaycoSdk.Utils
{
    public class Request 
    {
        RestClient client = new RestClient(BASE_URL);
        BodyRequest body = new BodyRequest();
        #region Constructor

        public Request()
        {
            
        }

        #endregion

        #region Atributes
        const string BASE_URL = Constants.url_base;
        private string END_POINT = string.Empty;
        private string TYPE = string.Empty;
        private string PUBLIC_KEY_BASE64 = string.Empty;
        private string PARAMETER = string.Empty;
        private string RESPONSE = string.Empty;
        private string PRIVATE_KEY = string.Empty;
        private string PUBLIC_KEY = string.Empty;
        private string BEARER_TOKEN = string.Empty;
        #endregion

        #region Methods

        public void AuthService(string publicKey, string privateKey)
        {
            PRIVATE_KEY = privateKey;
            PUBLIC_KEY = publicKey;
            var auth = GetBearerToken();
            if (auth.status)
            {
                BEARER_TOKEN = auth.bearer_token;
            }
        }
        
        public string Execute(string endPoint, string type, string publicKeyBase64, string parameter = "")
        {
            PARAMETER = parameter;
            END_POINT = endPoint;
            TYPE = type;
            PUBLIC_KEY_BASE64 = publicKeyBase64;
            if (TYPE == "POST")
            {
                RESPONSE = Post();
            }
            else
            {
                RESPONSE = Get();
            }
            return RESPONSE;
        }
        
        private string Get()
        {
            var request = new RestRequest(END_POINT);
            // string auth = "Basic " + PUBLIC_KEY_BASE64;
            string auth = "Bearer " + BEARER_TOKEN;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("lang", ".NET");
            request.AddHeader("authorization", auth);
            // request.RequestFormat = DataFormat.Json;
            var response = client.Get<dynamic>(request);
            return response.Content;
        }
        
        private string Post()
        {
            var request = new RestRequest(END_POINT);
            // string auth = "Basic " + PUBLIC_KEY_BASE64;
            string auth = "Bearer " + BEARER_TOKEN;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("lang", ".NET");
            request.AddHeader("authorization", auth);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", PARAMETER, ParameterType.RequestBody);
            
            var response = client.Post<dynamic>(request);
            return response.Content;
           
        }
        
        private AuthModel GetBearerToken()
        {
            PARAMETER = body.getBodyAuthBearer(PUBLIC_KEY, PRIVATE_KEY);
            var request = new RestRequest("/v1/auth/login");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", PARAMETER, ParameterType.RequestBody);
            var response = client.Post<dynamic>(request);
            AuthModel auth = JsonConvert.DeserializeObject<AuthModel>(response.Content);
            return auth;
        }

        #endregion
    }
}
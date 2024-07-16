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
        readonly RestClient _client = new RestClient(BaseUrl);
        readonly BodyRequest _body = new BodyRequest();
        #region Constructor
        public Request()
        {
            
        }
        #endregion

        #region Atributes
        const string BaseUrl = Constants.UrlBase;
        private string _endPoint = string.Empty;
        private string _type = string.Empty;
        private string _publicKeyBase64 = string.Empty;
        private string _parameter = string.Empty;
        private string _response = string.Empty;
        private string _privateKey = string.Empty;
        private string _publicKey = string.Empty;
        private string _bearerToken = string.Empty;
        #endregion

        #region Methods

        public void AuthService(string publicKey, string privateKey)
        {
            _privateKey = privateKey;
            _publicKey = publicKey;
            var auth = GetBearerToken();
            if (auth.status)
            {
                _bearerToken = auth.bearer_token;
            }
        }

        public string Execute(string endPoint, string type, string publicKeyBase64, string parameter = "")
        {
            _parameter = parameter;
            _endPoint = endPoint;
            _type = type;
            _publicKeyBase64 = publicKeyBase64;
            if (_type == "POST")
            {
                _response = Post();
            }
            else
            {
                _response = Get();
            }
            return _response;
        }

        private string Get()
        {
            var request = new RestRequest(_endPoint);
            // string auth = "Basic " + PUBLIC_KEY_BASE64;
            string auth = "Bearer " + _bearerToken;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("lang", ".NET");
            request.AddHeader("authorization", auth);
            // request.RequestFormat = DataFormat.Json;
            var response = _client.Get<dynamic>(request);
            return response.ToString();
        }
        
        private string Post()
        {
            var request = new RestRequest(_endPoint);
            // string auth = "Basic " + PUBLIC_KEY_BASE64;
            string auth = "Bearer " + _bearerToken;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("lang", ".NET");
            request.AddHeader("authorization", auth);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", _parameter, ParameterType.RequestBody);
            
            var response = _client.Post<dynamic>(request);
            return response.ToString();
           
        }
        
        private AuthModel GetBearerToken()
        {
            _parameter = _body.GetBodyAuthBearer(_publicKey, _privateKey);
            var request = new RestRequest("/v1/auth/login");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", _parameter, ParameterType.RequestBody);
            var response = _client.Post<dynamic>(request);
            AuthModel auth = JsonConvert.DeserializeObject<AuthModel>(response.ToString());
            return auth;
        }
        #endregion

    }
}
using System.Net;
using RestSharp;

namespace EpaycoSdk.Utils
{
    public class RequestRest
    {
        readonly RestClient _client = new RestClient(BaseUrl);
        // ResponseModel response = new ResponseModel();
        #region Constructor

        public RequestRest()
        {
            System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType) 3072;
        }

        #endregion

         #region Atributes

        const string BaseUrl = Constants.BaseUrlSecure;
        private string _endPoint = string.Empty;
        private string _type = string.Empty;
        private string _publicKeyBase64 = string.Empty;
        private string _parameter = string.Empty;
        private string? _response = string.Empty;
        #endregion

        #region Methods

        public string? Execute(string endPoint, string type, string publicKeyBase64, string parameter = "")
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
        
        private string? Get()
        {
            var request = new RestRequest(_endPoint);
            string auth = "Basic " + _publicKeyBase64;
            request.AddHeader("authorization", auth);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk");
            // request.RequestFormat = DataFormat.Json;
            var response = _client.Get<dynamic>(request);
            return response?.ToString();
        }
        
        private string? Post()
        {
            var request = new RestRequest(_endPoint);
            string auth = "Basic " + _publicKeyBase64;
            request.AddHeader("authorization", auth);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("lang", ".NET");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", _parameter, ParameterType.RequestBody);
            
            var response = _client.Post<dynamic>(request);
            return response?.ToString();
        }

        #endregion
    }
}
using RestSharp;
using EpaycoSdk.Models.Auth;
using Newtonsoft.Json;

namespace EpaycoSdk.Utils
{
    public class RequestApify
    {
        readonly RestClient _client = new RestClient(BaseUrl);
        Auxiliars _auxiliars = new Auxiliars();
        #region Constructor

        public RequestApify()
        {

        }

        #endregion

         #region Atributes

        const string BaseUrl = Constants.BaseUrlApify;
        private string _endPoint = string.Empty;
        private string _type = string.Empty;
        private string _parameter = string.Empty;
        private string? _response = string.Empty;
        private string _bearerToken = string.Empty;
        private string _privateKey = string.Empty;
        private string _publicKey = string.Empty;

        #endregion

        #region Methods

        public void AuthService(string publicKey, string privateKey)
        {
            _privateKey = privateKey;
            _publicKey = publicKey;
            var auth = GetBearerToken();
            _bearerToken = auth.token;
        }
        public string? Execute(string endPoint, string type, string publicKeyBase64, string parameter = "" )
        {

            _parameter = parameter;
            _endPoint = endPoint;
            _type = type;
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
            string auth = "Bearer " + _bearerToken;
            request.AddHeader("Authorization", auth);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("lang", ".NET");
            // request.RequestFormat = DataFormat.Json;
            var response = _client.Get<dynamic>(request);
            return response?.ToString();
        }
        
        private string? Post()
        {
            var request = new RestRequest(_endPoint);
            
            string auth = "Bearer " + _bearerToken;
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

        private TokenApify GetBearerToken()
        {
            _parameter = _auxiliars.ConvertToBase64(_publicKey + ":" + _privateKey);
            var request = new RestRequest("/login");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("Authorization", "Basic "+_parameter);
            request.RequestFormat = DataFormat.Json;
            var response = _client.Post<dynamic>(request);
            TokenApify auth = JsonConvert.DeserializeObject<TokenApify>(response.ToString());
            return auth;
        }
        #endregion
    }
}
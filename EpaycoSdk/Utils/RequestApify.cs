using RestSharp;
using EpaycoSdk.Models.Auth;
using Newtonsoft.Json;

namespace EpaycoSdk.Utils
{
    public class RequestApify
    {
        RestClient client = new RestClient(BASE_URL);
        Auxiliars _auxiliars = new Auxiliars();
        #region Constructor

        public RequestApify()
        {

        }

        #endregion

         #region Atributes

        static string BASE_URL = Constants.base_url_apify;
        private string END_POINT = string.Empty;
        private string TYPE = string.Empty;
        private string PARAMETER = string.Empty;
        private string RESPONSE = string.Empty;
        private string BEARER_TOKEN = string.Empty;
        private string PRIVATE_KEY = string.Empty;
        private string PUBLIC_KEY = string.Empty;

        #endregion

        #region Methods

        public void AuthService(string publicKey, string privateKey)
        {
            PRIVATE_KEY = privateKey;
            PUBLIC_KEY = publicKey;
            var auth = GetBearerToken();
            if (auth.token != null)
            {
                BEARER_TOKEN = auth.token;
            }
        }
        public string Execute(string endPoint, string type, string publicKeyBase64, string parameter = "" )
        {

            PARAMETER = parameter;
            END_POINT = endPoint;
            TYPE = type;
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
            string auth = "Bearer " + BEARER_TOKEN;
            request.AddHeader("Authorization", auth);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("lang", ".NET");
            // request.RequestFormat = DataFormat.Json;
            var response = client.Get<dynamic>(request);
            return response.Content;
        }
        
        private string Post()
        {
            var request = new RestRequest(END_POINT);
            
            string auth = "Bearer " + BEARER_TOKEN;
            request.AddHeader("authorization", auth);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("lang", ".NET");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", PARAMETER, ParameterType.RequestBody);
            
            var response = client.Post<dynamic>(request);
            return response.Content;
        }

        private TokenApify GetBearerToken()
        {
            PARAMETER = _auxiliars.ConvertToBase64(PUBLIC_KEY + ":" + PRIVATE_KEY);
            var request = new RestRequest("/login");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("Authorization", "Basic "+PARAMETER);
            request.RequestFormat = DataFormat.Json;
            var response = client.Post<dynamic>(request);
            TokenApify auth = JsonConvert.DeserializeObject<TokenApify>(response.Content);
            return auth;
        }
        #endregion
    }
}
using System.Net;
using RestSharp;
using EpaycoSdk.Utils;

namespace EpaycoSdk.Utils
{
    public class RequestApify
    {
        RestClient client = new RestClient(BASE_URL);
        // ResponseModel response = new ResponseModel();
        #region Constructor

        public RequestApify()
        {

        }

        #endregion

         #region Atributes

        static string BASE_URL = Constants.base_url_apify;
        private string END_POINT = string.Empty;
        private string TYPE = string.Empty;
        private string PUBLIC_KEY_BASE64 = string.Empty;
        private string PARAMETER = string.Empty;
        private string RESPONSE = string.Empty;
        private string BEARER_TOKEN = string.Empty;

        #endregion

        #region Methods

        public string Execute(string endPoint, string type, string publicKeyBase64, string parameter = "" )
        {
            var authRequest = new Request();
            var auth = authRequest.GetBearerToken();
            if (auth.status)
            {
                BEARER_TOKEN = auth.bearer_token;
            }

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
            string auth = "Bearer " + BEARER_TOKEN;
            request.AddHeader("authorization", auth);
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

        #endregion
    }
}
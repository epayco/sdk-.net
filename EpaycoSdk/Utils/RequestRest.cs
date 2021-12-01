using System.Net;
using RestSharp;

namespace EpaycoSdk.Utils
{
    public class RequestRest
    {
        RestClient client = new RestClient(BASE_URL);
        // ResponseModel response = new ResponseModel();
        #region Constructor

        public RequestRest()
        {
            System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType) 3072;
        }

        #endregion

         #region Atributes

        static string BASE_URL = Constants.base_url_secure;
        private string END_POINT = string.Empty;
        private string TYPE = string.Empty;
        private string PUBLIC_KEY_BASE64 = string.Empty;
        private string PARAMETER = string.Empty;
        private string RESPONSE = string.Empty;
        #endregion

        #region Methods

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
            string auth = "Basic " + PUBLIC_KEY_BASE64;
            request.AddHeader("authorization", auth);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk");
            // request.RequestFormat = DataFormat.Json;
            var response = client.Get<dynamic>(request);
            return response.Content;
        }
        
        private string Post()
        {
            var request = new RestRequest(END_POINT);
            string auth = "Basic " + PUBLIC_KEY_BASE64;
            request.AddHeader("authorization", auth);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", PARAMETER, ParameterType.RequestBody);
            
            var response = client.Post<dynamic>(request);
            return response.Content;
        }

        #endregion
    }
}
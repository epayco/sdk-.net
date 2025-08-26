using EpaycoSdk.Models;
using EpaycoSdk.Models.Auth;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace EpaycoSdk.Utils
{
    public class Request
    {
        // Configuración del cliente para NO lanzar HttpRequestException automáticamente
        private static readonly RestClient _client = new RestClient(new RestClientOptions(Constants.UrlBase)
        {
            ThrowOnAnyError = false,               // evita excepciones en 400, 401, etc.
            ThrowOnDeserializationError = false,   // evita excepciones si el JSON no es válido
            MaxTimeout = 30000
        });

        private readonly BodyRequest _body = new BodyRequest();

        #region Atributos
        private string _endPoint = string.Empty;
        private string _type = string.Empty;
        private string _publicKeyBase64 = string.Empty;
        private string _parameter = string.Empty;
        private string _response = string.Empty;
        private string _privateKey = string.Empty;
        private string _publicKey = string.Empty;
        private string _bearerToken = string.Empty;
        #endregion

        #region Métodos

        public void AuthService(string publicKey, string privateKey)
        {
            _privateKey = privateKey;
            _publicKey = publicKey;
            var auth = GetBearerToken();
            if (auth != null && auth.status)
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

            return _type == "POST" ? Post() : Get();
        }

        private string Get()
        {
            var request = new RestRequest(_endPoint);
            string auth = "Bearer " + _bearerToken;

            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("lang", ".NET");
            request.AddHeader("authorization", auth);

            var response = _client.Execute(request, Method.Get);

            if (!response.IsSuccessful)
            {
                ManejarError(response);
                return string.Empty;
            }

            return response.Content ?? string.Empty;
        }

        private string Post()
        {
            var request = new RestRequest(_endPoint, Method.Post);
            string auth = "Bearer " + _bearerToken;

            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddHeader("lang", ".NET");
            request.AddHeader("authorization", auth);
            request.AddParameter("application/json", _parameter, ParameterType.RequestBody);

            var response = _client.Execute(request);
            

            if (!response.IsSuccessful)
            {
                ManejarError(response);
                return string.Empty;
            }

            return response.Content ?? string.Empty;
        }

        private AuthModel? GetBearerToken()
        {
            _parameter = _body.GetBodyAuthBearer(_publicKey, _privateKey);
            var request = new RestRequest("/v1/auth/login", Method.Post);

            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("type", "sdk-jwt");
            request.AddParameter("application/json", _parameter, ParameterType.RequestBody);

            var response = _client.Execute(request);
        

            if (!response.IsSuccessful)
            {
                ManejarError(response);
                return null;
            }

            try
            {
                return JsonConvert.DeserializeObject<AuthModel>(response.Content ?? string.Empty);
            }
            catch
            {
                Console.WriteLine(JsonConvert.SerializeObject(new
                {
                    codigoError = "104",
                    status = false,
                    message = "El servicio no se puede autenticar, verifique su llave pública o llave privada"
                }, Formatting.Indented));
                return null;
            }
        }

        // 🔹 Método centralizado para mostrar errores HTTP
        private void ManejarError(RestResponse response)
        {
            string error = response.StatusCode switch
            {
                HttpStatusCode.BadRequest => "Error 400: Solicitud incorrecta, por favor verifica los datos enviados.",
                HttpStatusCode.Unauthorized => "Error 401: No autorizado, revisa tus credenciales.",
                HttpStatusCode.Forbidden => "Error 403: Acceso prohibido, no tienes permisos para esta acción.",
                HttpStatusCode.NotFound => "Error 404: La ruta en la que estás realizando la petición no existe.",
                HttpStatusCode.MethodNotAllowed => "Error 405: Método no permitido en esta ruta.",
                _ => $"Error inesperado del servidor (HTTP {(int)response.StatusCode})"
            };

            var errorResponse = new
            {
                status = false,
                message = error,
                detail = JsonConvert.DeserializeObject(response.Content ?? "{}") 
            };

            Console.WriteLine(JsonConvert.SerializeObject(errorResponse, Formatting.Indented));
        }

        #endregion
    }
}

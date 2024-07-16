namespace EpaycoSdk.Models.Auth
{
    public class AuthModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string bearer_token { get; set; }
        public string data { get; set; }
    }

    public class TokenApify
    {
        public string token { get; set; }
        public string error { get; set; }
    }
}
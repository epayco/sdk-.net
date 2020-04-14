namespace EpaycoSdk.Models
{
    public class CustomerTokenDeleteModel
    {
        public bool status { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public TokenDeleteData data { get; set; }
    }

    public class TokenDeleteData
    {
        public string status { get; set; }
        public string description { get; set; }
        public string errors { get; set; }
    }
}
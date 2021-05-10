namespace EpaycoSdk.Models
{
    public class DebitTokenModel
    {
        public bool status { get; set; }
        public string id { get; set; }
        public bool success { get; set; }
        public string type { get; set; }
        public DebitTokenData data { get; set; }
        public DebitAccount debitAccount { get; set; }
    }

    public partial class DebitTokenData
    {
        public string status { get; set; }
        public string id { get; set; }
        public string created { get; set; }
        public bool livemode { get; set; }
        public string description { get; set; }
        public string errors { get; set; }
        
    }

    public class DebitAccount
    {
        public string mask { get; set; }
    }
}
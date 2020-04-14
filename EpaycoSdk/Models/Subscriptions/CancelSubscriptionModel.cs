namespace EpaycoSdk.Models.Subscriptions
{
    public class CancelSubscriptionModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public string type { get; set; }
        public CancelSubscriptionData data { get; set; }
    }

    public class CancelSubscriptionData
    {
        public string description { get; set; }
    }
}
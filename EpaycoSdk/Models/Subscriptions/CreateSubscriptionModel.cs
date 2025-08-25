using EpaycoSdk.Models.Plans;

namespace EpaycoSdk.Models.Subscriptions
{
    public class CreateSubscriptionModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string created { get; set; }
        public string id { get; set; }
        public bool success { get; set; }
        public string current_period_start { get; set; }
        public string current_period_end { get; set; }
        public Customer customer { get; set; }
        public string status_subscription { get; set; }
        public string type { get; set; }
        public CreateSubscriptionData data { get; set; }
    }

    public class Customer
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string merchandId { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string cell_phone { get; set; }
        public bool break_card { get; set; }
    }

    public class CreateSubscriptionData
    {
        public string status { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public object errors { get; set; }
        public decimal? amount { get; set; }
        public string currency { get; set; }
        public string interval { get; set; }
        public int interval_count { get; set; }
        public int trial_days { get; set; }
        public bool test { get; set; }
        public int afterPayment { get; set; }
        public string createdAt { get; set; }
    }

    
}
using EpaycoSdk.Models.Plans;

namespace EpaycoSdk.Models.Subscriptions
{
    public class FindSusbscriptionModel
    {
        public bool status { get; set; }
        public string created { get; set; }
        public string message { get; set; }
        public string id { get; set; }
        public bool success { get; set; }
        public string current_period_start { get; set; }
        public string current_period_end { get; set; }
        public string customer { get; set; }
        public PlanData plan{ get; set; }
        public string status_plan { get; set; }
        public string type { get; set; }
        public FindSubscriptionData data { get; set; }
    }

    public class FindSubscriptionData
    {
        public string status { get; set; }
        public string description { get; set; }
        public string errors { get; set; }
    }

    public class PlanData
    {
        public string _id { get; set; }
        public string idClient { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal? amount { get; set; }
        public string currency { get; set; }
        public string interval { get; set; }
        public int? interval_count { get; set; }
        public string status { get; set; }
        public int? trialDays { get; set; }
    }
}
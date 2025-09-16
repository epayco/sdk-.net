using System.Collections;
using System.Collections.Generic;

namespace EpaycoSdk.Models.Subscriptions
{
    public class AllSubscriptionModel
    {
        public bool status { get; set; }
        public bool success { get; set; }
        public string type { get; set; }
        public List<Data> data { get; set; }
        public string? message { get; set; }
    }

    public class Data
    {
        public string _id { get; set; }
        public string idPlan { get; set; }
        public string periodStart { get; set; }
        public string periodEnd { get; set; }
        public string nextVerificationDate { get; set; }
        public string status { get; set; }
        public bool first { get; set; }
        public string idCustomer { get; set; }
        public string paymentAttemps { get; set; }
        public string tokenCard { get; set; }
        public PlanData plan { get; set; }
        public string description { get; set; }
        public string errors { get; set; }
    }
    public class SubscriptionStatus
    {
        public bool status { get; set; }
        public string? message { get; set; }
    }

}
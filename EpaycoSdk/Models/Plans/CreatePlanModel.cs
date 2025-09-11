namespace EpaycoSdk.Models.Plans
{
    public class CreatePlanModel
    {
        public bool status { get; set; }
        public bool success { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public CreatePlanData data { get; set; }
    }

    public class CreatePlanData
    {
        public string status { get; set; }
        public string errors { get; set; }
        public string id_plan { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string interval { get; set; }
        public int interval_count { get; set; }
        public int trial_days { get; set; }
        public bool test { get; set; }
        public int afterPayment { get; set; }
    }
}
namespace EpaycoSdk.Models.Plans
{
    public class RemovePlanModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public string type { get; set; }
        public RemovePlanData data { get; set; }
    }

    public class RemovePlanData
    {
        public string idPlan { get; set; }
        public string errors { get; set; }
    }
}
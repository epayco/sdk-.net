using System.Collections.Generic;

namespace EpaycoSdk.Models.Plans
{
    public class FindAllPlansSatusModel
    {
        public bool status { get; set; }
        public string? message { get; set; }
    }
    
    public class FindAllPlansModel
    {
        public bool status { get; set; } = true;
        public string? message { get; set; }
        public bool success { get; set; }
        public string type { get; set; }
        public List<FindPlanData> data { get; set; }
    }
}
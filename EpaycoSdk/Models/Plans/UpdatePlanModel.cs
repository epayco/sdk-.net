namespace EpaycoSdk.Models.Plans;

public class UpdatePlanModel
{
    public bool status { get; set; }
    public bool success { get; set; }
    public string type { get; set; }
    public string message { get; set; }
    public UpdatePlanData data { get; set; }
}

public class UpdatePlanData
{
    public string status { get; set; }
    public object errors { get; set; }
    public string id_plan { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public decimal amount { get; set; }
    public string currency { get; set; }
    public string interval { get; set; }
    public int interval_count { get; set; }
    public int trial_days { get; set; }
    public bool? test { get; set; }
    public string? ip { get; set; }
    public decimal? iva { get; set; }
    public decimal? ico { get; set; }
    public string? afterPayment { get; set; }
    public int? transactionalLimit { get; set; }
    public decimal? additionalChargePercentage { get; set; }
}
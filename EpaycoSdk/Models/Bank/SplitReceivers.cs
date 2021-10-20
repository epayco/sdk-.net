namespace EpaycoSdk.Models.Bank
{
    public class SplitReceivers
    {
        public string id { get; set; }
        public decimal total { get; set; }
        public decimal iva { get; set; }
        public decimal ico { get; set; }
        public decimal base_iva { get; set; }
        public decimal fee { get; set; }
    }
}
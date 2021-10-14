namespace EpaycoSdk.Models.Bank
{
    public class SplitReceivers
    {
        public string id { get; set; }
        public int total { get; set; }
        public int iva { get; set; }
        public int ico { get; set; }
        public int base_iva { get; set; }
        public int fee { get; set; }
    }
}
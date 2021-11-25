using System.Collections.Generic;

namespace EpaycoSdk.Models.Bank
{
    public class SplitModel
    {
        public string splitpayment { get; set; }
        public string split_app_id { get; set; }
        public string split_merchant_id { get; set; }
        public string split_type { get; set; }
        public string split_rule { get; set; }
        public string split_primary_receiver { get; set; }
        public string split_primary_receiver_fee { get; set; }
        public List<SplitReceivers> split_receivers { get; set; }
    }

    public class SplitModelRest
    {
        public string splitpayment { get; set; }
        public string split_app_id { get; set; }
        public string split_merchant_id { get; set; }
        public string split_type { get; set; }
        public string split_rule { get; set; }
        public string split_primary_receiver { get; set; }
        public string split_primary_receiver_fee { get; set; }
        public string split_receivers { get; set; }
    }
}
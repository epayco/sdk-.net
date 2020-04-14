using System.Collections.Generic;

namespace EpaycoSdk.Models.Bank
{
    public class BanksModel
    {
        public bool success { get; set; }
        public string title_response { get; set; }
        public string text_response { get; set; }
        public string last_action { get; set; }
        public List<BankModel> data { get; set; }
    }

    public class BankModel
    {
        public string bankCode { get; set; }
        public string bankName { get; set; }
    }

    public class BankResponse
    {
        public bool success { get; set; }
        public string title_response { get; set; }
        public string text_response { get; set; }
        public string last_action { get; set; }
    }
}
using EpaycoSdk.Models.Cash;

namespace EpaycoSdk.Models.Charge
{
    public class ChargeTransactionModel
    {
        public bool success { get; set; }
        public string title_response { get; set; }
        public string text_response { get; set; }
        public string last_action { get; set; }
        public CashTransactionData data { get; set; }
    }
}
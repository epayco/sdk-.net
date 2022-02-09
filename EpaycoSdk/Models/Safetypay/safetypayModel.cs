using EpaycoSdk.Models.Cash;
using System.Collections.Generic;

namespace EpaycoSdk.Models.Safetypay
{
    public class safetypayModel
    {
        public bool success { get; set; }
        public string titleResponse { get; set; }
        public string textResponse { get; set; }
        public string lastAction { get; set; }
        public SafetypayTransactionData data { get; set; }
    }

    public class SafetypayTransactionData
    {
        public string refPayco { get; set; }
        public string invoice { get; set; }
        public string description { get; set; }
        public decimal value { get; set; }
        public decimal tax { get; set; }
        public decimal ico { get; set; }
        public decimal taxBase { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
        public string response { get; set; }
        public string autorization { get; set; }
        public string receipt { get; set; }
        public string date { get; set; }
        public string urlBank { get; set; }
        public string transactionId { get; set; }
        public string ticketId { get; set; }
        public int totalErrors { get; set; }
        public List<errors> errores { get; set; }
    }

    public class bodySafetypay
    {
        public string cash { get; set; }
        public string expirationDate { get; set; }
        public string docType { get; set; }
        public string document { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string indCountry { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string ip { get; set; }
        public string currency { get; set; }
        public string invoice { get; set; }
        public string description { get; set; }
        public decimal value { get; set; }
        public decimal tax { get; set; }
        public decimal ico { get; set; }
        public decimal taxBase { get; set; }
        public bool testMode { get; set; }
        public string urlResponse { get; set; }
        public string urlResponsePointer { get; set; }
        public string urlConfirmation { get; set; }
        public string methodConfirmation { get; set; }
        public string typeIntegration { get; set; }
    }   


}

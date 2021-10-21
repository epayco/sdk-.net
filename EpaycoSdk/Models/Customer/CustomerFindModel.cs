using System.Collections.Generic;

namespace EpaycoSdk.Models
{
    public class CustomerFindModel
    {
        public bool status { get; set; }
        public bool success { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public DataFind data { get; set; }
        
    }

    public class DataFind
    {
        public string status { get; set; }
        public string description { get; set; }
        public string errors { get; set; }
        public string id_customer { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string created { get; set; }
        public List<Cards> cards { get; set; }
    }

    public class Cards
    {
        public string token { get; set; }
        public string insert { get; set; }
        public int priority { get; set; }
        public bool _default { get; set; }
        public string franchise { get; set; }
        public string mask { get; set; }
    }
}
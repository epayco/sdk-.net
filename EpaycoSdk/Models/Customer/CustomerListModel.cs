using System.Collections.Generic;

namespace EpaycoSdk.Models
{
    class StatusConsult
    {
        public bool status { get; set; }
        public string message { get; set; }
    }
    
    public class CustomerListModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public string type { get; set; }
        public List<Customer> data { get; set; }
        
    }

    public class Error
    {
        public string status { get; set; }
        public string description { get; set; }
        public string errors { get; set; }
    }

    public class Customer
    {
        public string id_customer { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string created { get; set; }
    }

   
}
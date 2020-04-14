namespace EpaycoSdk.Models
{
    public class CustomerCreateModel
    {
        public bool status { get; set; }
        public bool succsess { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public DataCustomer data { get; set; }
    }

    public class DataCustomer
    {
        public string status { get; set; }
        public string errors { get; set; }
        public string description { get; set; }
        public string customerId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}
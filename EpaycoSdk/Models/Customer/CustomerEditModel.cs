namespace EpaycoSdk.Models
{
    public class CustomerEditModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public string type { get; set; }
        public DataCustomerEdit data { get; set; }
    }

    public class DataCustomerEdit
    {
        public string status { get; set; }
        public string description { get; set; }
        public string customerId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string errors { get; set; }
    }
}
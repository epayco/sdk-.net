using System.Collections.Generic;

namespace EpaycoSdk.Models
{
    public class TokenModel
    {
        public bool status { get; set; }
        public string id { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public Data data { get; set; }
        public Card card { get; set; }
    }

    public partial class Data
    {
        public string status { get; set; }
        public string id { get; set; }
        public string created { get; set; }
        public bool livemode { get; set; }
        public string description { get; set; }
        public string errors { get; set; }
        
    }

    public class Card
    {
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public string name { get; set; }
        public string mask { get; set; }
    }

    public class TokenMessage
    {
        public bool status { get; set; }
        public string type { get; set; }
        public string message { get; set; }
    }

    public class SetDefaultToken
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Cards> cars { get; set; }

    }
}
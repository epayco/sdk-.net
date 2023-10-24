namespace EpaycoSdk.Models.Subscriptions
{
    public class ChargeSubscriptionModel
    {
        public bool success { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string title_response { get; set; }
        public string text_response { get; set; }
        public string last_action { get; set; }
        public DataPayment data { get; set; }
        public SubscriptionData subscription { get; set; }
        public string idPlan { get; set; }
        public string periodEnd { get; set; }
        public string nextVerificationDate { get; set; }
        public bool first { get; set; }
        public string idCustomer { get; set; }
        public string tokenCard { get; set; }

    }
    public class DataPayment
    {
        public string ref_payco { get; set; }
        public string factura { get; set; }
        public string descripcion { get; set; }
        public string valor { get; set; }
        public string iva { get; set; }
        public string baseiva { get; set; }
        public string moneda { get; set; }
        public string banco { get; set; }
        public string estado { get; set; }
        public string respuesta { get; set; }
        public string autorizacion { get; set; }
        public int recibo { get; set; }
        public string fecha { get; set; }
        public string franquicia { get; set; }
        public int cod_respuesta { get; set; }
        public string ip { get; set; }
        public string tipo_doc { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public int enpruebas { get; set; }
        public string ciudad { get; set; }
        public string direccion { get; set; }
        public string ind_pais { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string errors { get; set; }

        public string idClient { get; set; }
        public string name { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string interval { get; set; }
        public int interval_count { get; set; }
        public int trialDays { get; set; }

        public string url_confirmation { get; set; }

    }
   

    public class SubscriptionData
    {
        public string _id { get; set; }
        public string idPlan { get; set; }
        public DataPlan data { get; set; }
        //public string periodStart { get; set; }
        public string periodEnd { get; set; }
        public string nextVerificationDate { get; set; }
        public string status { get; set; }
        public bool first { get; set; }
        public string idCustomer { get; set; }
        public string tokenCard { get; set; }
        public string url_confirmation { get; set; }
        //PENDIENTES PAYMENTATTEMPS
        // public string paymentAttempts { get; set; }
    }

    public class DataPlan
    {
        public string idClient { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string interval { get; set; }
        public int interval_count { get; set; }
        public int trialDays { get; set; }
    }

    public class DataErrors
    {
        public string codError { get; set; }
        public string errorMessage { get; set; }
    }
}
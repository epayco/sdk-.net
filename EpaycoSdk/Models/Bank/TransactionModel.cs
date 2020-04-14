namespace EpaycoSdk.Models.Bank
{
    public class TransactionModel
    {
        public bool success { get; set; }
        public string title_response { get; set; }
        public string text_response { get; set; }
        public string last_action { get; set; }
        public DataBank data { get; set; }
    }

    public class DataBank
    {
        public int ref_payco { get; set; }
        public string factura { get; set; }
        public string descripcion { get; set; }
        public int valor { get; set; }
        public int iva { get; set; }
        public int baseiva { get; set; }
        public string moneda { get; set; }
        public string banco { get; set; }
        public string estado { get; set; }
        public string respuesta { get; set; }
        public int autorizacion { get; set; }
        public string recibo { get; set; }
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
        public int transactionId { get; set; }
        public string ticketId { get; set; }
    }
    
    public class TransactionResponse
    {
        public bool success { get; set; }
        public string title_response { get; set; }
        public string text_response { get; set; }
        public string last_action { get; set; }
    }
}
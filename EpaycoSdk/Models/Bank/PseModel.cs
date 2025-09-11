using System.Collections.Generic;
using EpaycoSdk.Models.Cash;

namespace EpaycoSdk.Models.Bank
{
    public class PseModel
    {
        public bool success { get; set; }
        public string title_response { get; set; }
        public string text_response { get; set; }
        public string last_action { get; set; }
        public DataPse data { get; set; }
    }

    public class Extras
    {
        public string extra1 { get; set; }
        public string extra2 { get; set; }
        public string extra3 { get; set; }
        public string extra4 { get; set; }
        public string extra5 { get; set; }
        public string extra6 { get; set; }
        public string extra7 { get; set; }
        public string extra8 { get; set; }
        public string extra9 { get; set; }
        public string extra10 { get; set; }

    }

    public class errors
    {

        public string codError { get; set; }
        public string errorMessage { get; set; }
    }

    public class DataPse
    {
        public int ref_payco { get; set; }
        public string factura { get; set; }
        public string descripcion { get; set; }
        public string valor { get; set; }
        public string iva { get; set; }
        public string ico { get; set; }
        public string baseiva { get; set; }
        public string moneda { get; set; }
        public string respuesta { get; set; }
        public string autorizacion { get; set; }
        public string ciudad { get; set; }
        public string recibo { get; set; }
        public string fecha { get; set; }
        public string urlbanco { get; set; }
        public string transactionId { get; set; }
        public string ticketId { get; set; }
        public Extras extras { get; set;  }
        public List<errors> errores { get; set; }

    }
}
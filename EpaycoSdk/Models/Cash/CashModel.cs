namespace EpaycoSdk.Models.Cash
{
    public class CashModel
    {
        public bool success { get; set; }
        public string title_response { get; set; }
        public string text_response { get; set; }
        public string last_action { get; set; }
        public string message { get; set; }
        public DataCash data { get; set; }
    }
    
    public class DataCash
    {
        public int ref_payco { get; set; }
        public string factura { get; set; }
        public string descripcion { get; set; }
        public string valor { get; set; }
        public string iva { get; set; }
        public dynamic baseiva { get; set; }
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
        public string pin { get; set; }
        public string codigoproyecto { get; set; }
        public string fechaexpiracion { get; set; }
        public string fechapago { get; set; }
        public decimal factor_conversion { get; set; }
        public string valor_pesos { get; set; }
        public int totalerrores { get; set; }
        public dynamic errores { get; set; }
    }
}
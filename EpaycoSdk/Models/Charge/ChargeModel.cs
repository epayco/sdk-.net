namespace EpaycoSdk.Models.Charge
{
    public class ChargeModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public ChargeData data { get; set; }
    }

    public class ChargeData
    {
        public int ref_payco { get; set; }
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
        public string recibo { get; set; }
        public string fecha { get; set; }
        public string franquicia { get; set; }
        public string cod_respuesta { get; set; }
        public string ip { get; set; }
        public string tipo_doc { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string enpruebas { get; set; }
        public string ciudad { get; set; }
        public string direccion { get; set; }
        public string ind_pais { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public dynamic errors { get; set; }
    }
}
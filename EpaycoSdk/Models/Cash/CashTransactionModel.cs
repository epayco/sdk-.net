using System.Collections.Generic;

namespace EpaycoSdk.Models.Cash
{
    public class CashTransactionModel
    {
        public bool success { get; set; }
        public string title_response { get; set; }
        public string text_response { get; set; }
        public string last_action { get; set; }
        public CashTransactionData data { get; set; }
    }

    public class CashTransactionData
    {
        public int x_cust_id_cliente { get; set; }
        public int x_ref_payco { get; set; }
        public string x_id_factura { get; set; }
        public string x_id_invoice { get; set; }
        public string x_description { get; set; }
        public decimal x_amount { get; set; }
        public decimal x_amount_country { get; set; }
        public decimal x_amount_ok { get; set; }
        public double x_tax { get; set; }
        public double x_ico { get; set; }
        public decimal x_amount_base { get; set; }
        public string x_currency_code { get; set; }
        public string x_bank_name { get; set; }
        public string x_cardnumber { get; set; }
        public string x_quotas { get; set; }
        public string x_resspuesta { get; set; }
        public string x_response { get; set; }
        public string x_approval_code { get; set; }
        public string x_transaction_id { get; set; }
        public string x_fecha_transaccion { get; set; }
        public string x_transaction_date { get; set; }
        public int x_cod_respuesta { get; set; }
        public int x_cod_response { get; set; }
        public string x_response_reason_text { get; set; }
        public int x_cod_transaction_state { get; set; }
        public string x_transaction_state { get; set; }
        public string x_errorcode { get; set; }
        public string x_franchise { get; set; }
        public string x_business { get; set; }
        public string x_customer_doctype { get; set; }
        public string x_customer_document { get; set; }
        public string x_customer_name { get; set; }
        public string x_customer_lastname { get; set; }
        public string x_customer_email { get; set; }
        public string x_customer_phone { get; set; }
        public string x_customer_movil { get; set; }
        public string x_customer_ind_pais { get; set; }
        public string x_customer_country { get; set; }
        public string x_customer_city { get; set; }
        public string x_customer_address { get; set; }
        public string x_customer_ip { get; set; }
        public string x_signature { get; set; }
        public string x_test_request { get; set; }
        public string x_extra1 { get; set; }
        public string x_extra2 { get; set; }
        public string x_extra3 { get; set; }
        public string x_extra4 { get; set; }
        public string x_extra5 { get; set; }
        public string x_extra6 { get; set; }
        public string x_extra7 { get; set; }
        public string x_extra8 { get; set; }
        public string x_extra9 { get; set; }
        public string x_extra10 { get; set; }
        public int totalerrores { get; set; }
        public dynamic errores { get; set; }
    }
    
    public class EntitiesCashModel
    {
        public bool success { get; set; }
        public string titleResponse { get; set; }
        public string textResponse { get; set; }
        public string lastAction { get; set; }
        public List<DataEntities> data { get; set; }
    }

    public class DataEntities
    {
        public string id { get; set; }
        public string name { get; set; }

    }
}
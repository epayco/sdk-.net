using System;
using System.IO;
namespace EpaycoSdk.Utils
{
    public class Constants
    {
        public static string url_base =  "https://api.secure.epayco.io";
        public static string base_url_secure = "https://secure2.epayco.io";
        public static string entorno =  "/restpagos";

        public static string base_url_apify = "https://apify.epayco.io";
        /*
        * CUSTOMER
        */
        public const string url_create_token = "/v1/tokens";
        public const string url_create_customer = "/payment/v1/customer/create";
        public const string url_find_customer = "/payment/v1/customer/";
        public const string url_find_all_customer = "/payment/v1/customers/";
        public const string url_update_customer = "/payment/v1/customer/edit/";
        public const string url_token_delete = "/v1/remove/token";
        public const string url_add_new_token = "/v1/customer/add/token";
        public const string url_set_default_token = "/payment/v1/customer/reasign/card/default";

        /*
         * PLANS
         */
        public const string url_create_plan = "/recurring/v1/plan/create";
        public const string url_get_plan = "/recurring/v1/plan/";
        public const string url_get_all_plans = "/recurring/v1/plans/";
        public const string url_remove_plan = "/recurring/v1/plan/remove/";
        
        /*
         * SUBSCRIPTIONS
         */
        public const string url_create_subscription = "/recurring/v1/subscription/create";
        public const string url_get_subscription = "/recurring/v1/subscription/";
        public const string url_get_all_subscriptions = "/recurring/v1/subscriptions/";
        public const string url_cancel_subscription = "/recurring/v1/subscription/cancel";
        public const string url_chage_subscription = "/payment/v1/charge/subscription/create";
        public const string url_charge = "/payment/v1/charge/create";
        
        /*
         * BANK CREATE
         */
        public static string url_pagos_debitos = entorno + "/pagos/debitos.json";
        public static string url_get_transaction = entorno + "/restpagos/pse/transactioninfomation.json";
        public static string url_get_banks = entorno + "/restpagos/pse/bancos.json";
        
        /*CASH*/
        public static string url_cash_efecty = entorno + "/v2/efectivo/efecty";
        public static string url_cash_baloto = entorno + "/v2/efectivo/baloto";
        public static string url_cash_gana = entorno + "/v2/efectivo/gana";
        public static string url_cash_redservi = entorno + "/v2/efectivo/redservi";
        public static string url_cash_puntored = entorno + "/v2/efectivo/puntored";
        public static string url_cash_sured = entorno + "/v2/efectivo/sured";
        public static string url_cash_transaction = entorno + "/transaction/response.json?";

        /*DAVIPLATA*/
        public const string url_daviplata = "/payment/process/daviplata";
        public const string url_daviplata_confirm = "/payment/confirm/daviplata";

        /*SAFETYPAY*/
        public const string url_safetypay = "/payment/process/safetypay";
    }
}
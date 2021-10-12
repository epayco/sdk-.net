namespace EpaycoSdk.Utils
{
    public class Constants
    {
        public const string url_base = "https://api.secure.epayco.xyz";

        public const string base_url_secure = "https://secure2.epayco.io";
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
        public const string url_pagos_debitos = "/restpagostest/pagos/debitos.json";
        public const string url_get_transaction = "/restpagostest/pse/transactioninfomation.json";
        public const string url_get_banks = "/restpagostest/pse/bancos.json";
        
        /*CASH*/
        public const string url_cash_efecty = "/restpagostest/v2/efectivo/efecty";
        public const string url_cash_baloto = "/restpagostest/v2/efectivo/baloto";
        public const string url_cash_gana = "/restpagostest/v2/efectivo/gana";
        public const string url_cash_redservi = "/restpagostest/v2/efectivo/redservi";
        public const string url_cash_puntored = "/restpagostest/v2/efectivo/puntored";
        public const string url_cash_sured = "/restpagostest/v2/efectivo/sured";
        public const string url_cash_transaction = "/restpagostest/transaction/response.json?";
    }
}
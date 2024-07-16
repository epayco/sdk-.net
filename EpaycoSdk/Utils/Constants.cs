namespace EpaycoSdk.Utils
{
    public class Constants
    {
        public const string UrlBase = "https://api.secure.payco.co";

        public const string BaseUrlSecure = "https://secure.payco.co";

        public const string BaseUrlApify = "https://apify.epayco.co";
        /*
        * CUSTOMER
        */
        public const string UrlCreateToken = "/v1/tokens";
        public const string UrlCreateCustomer = "/payment/v1/customer/create";
        public const string UrlFindCustomer = "/payment/v1/customer/";
        public const string UrlFindAllCustomer = "/payment/v1/customers/";
        public const string UrlUpdateCustomer = "/payment/v1/customer/edit/";
        public const string UrlTokenDelete = "/v1/remove/token";
        public const string UrlAddNewToken = "/v1/customer/add/token";
        public const string UrlSetDefaultToken = "/payment/v1/customer/reasign/card/default";

        /*
         * PLANS
         */
        public const string UrlCreatePlan = "/recurring/v1/plan/create";
        public const string UrlGetPlan = "/recurring/v1/plan/";
        public const string UrlGetAllPlans = "/recurring/v1/plans/";
        public const string UrlRemovePlan = "/recurring/v1/plan/remove/";
        
        /*
         * SUBSCRIPTIONS
         */
        public const string UrlCreateSubscription = "/recurring/v1/subscription/create";
        public const string UrlGetSubscription = "/recurring/v1/subscription/";
        public const string UrlGetAllSubscriptions = "/recurring/v1/subscriptions/";
        public const string UrlCancelSubscription = "/recurring/v1/subscription/cancel";
        public const string UrlChageSubscription = "/payment/v1/charge/subscription/create";
        public const string UrlCharge = "/payment/v1/charge/create";
        
        /*
         * BANK CREATE
         */
        public const string UrlPagosDebitos = "/restpagos/pagos/debitos.json";
        public const string UrlGetTransaction = "/restpagos/pse/transactioninfomation.json";
        public const string UrlGetBanks = "/restpagos/pse/bancos.json";
        
        /*CASH*/
        public static string UrlCash = "/restpagos/v2/efectivo/";
        public static string UrlEntitiesCash = "/payment/cash/entities";
        public static string UrlCashTransaction = "/restpagos/transaction/response.json?";

        /*DAVIPLATA*/
        public const string UrlDaviplata = "/payment/process/daviplata";
        public const string UrlDaviplataConfirm = "/payment/confirm/daviplata";

        /*SAFETYPAY*/
        public const string UrlSafetypay = "/payment/process/safetypay";
    }
}
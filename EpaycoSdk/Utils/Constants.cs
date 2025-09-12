namespace EpaycoSdk.Utils
{
    public class Constants
    {
        public const string UrlBase = "https://eks-subscription-api-lumen-service.epayco.io";
        public const string BaseUrlSecure = "https://eks-rest-pagos-service.epayco.io";
        public const string Entorno = "/restpagos";
        public const string BaseUrlApify = "https://eks-apify-service.epayco.io";

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
        public const string UrlUpdatePlan = "/recurring/v1/plan/edit/";

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
        public const string UrlPagosDebitos = Entorno + "/pagos/debitos.json";
        public const string UrlGetTransaction = Entorno + "/pse/transactioninfomation.json";
        public const string UrlGetBanks = Entorno + "/pse/bancos.json";

        /*CASH*/
        public static string UrlCash = Entorno + "/v2/efectivo/";
        public static string UrlEntitiesCash = "/payment/cash/entities";
        public static string UrlCashTransaction = Entorno + "/transaction/response.json?";

        /*DAVIPLATA*/
        public const string UrlDaviplata = "/payment/process/daviplata";
        public const string UrlDaviplataConfirm = "/payment/confirm/daviplata";

        /*SAFETYPAY*/
        public const string UrlSafetypay = "/payment/process/safetypay";
    }
}
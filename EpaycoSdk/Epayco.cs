using EpaycoSdk.Models;
using EpaycoSdk.Models.Bank;
using EpaycoSdk.Models.Cash;
using EpaycoSdk.Models.Charge;
using EpaycoSdk.Models.Daviplata;
using EpaycoSdk.Models.Plans;
using EpaycoSdk.Models.Safetypay;
using EpaycoSdk.Models.Subscriptions;
using EpaycoSdk.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using Newtonsoft.Json.Linq;

namespace EpaycoSdk
{
    public class Epayco
    {

        BodyRequest body = new BodyRequest();
        Request _request = new Request();
        RequestRest _restRequest = new RequestRest();
        RequestApify _requestApify = new RequestApify();
        Auxiliars _auxiliars = new Auxiliars();

        #region Constructor
        public Epayco(string publicKey, string privateKey, string lang, bool test)
        {
            _PUBLIC_KEY = publicKey;
            _PRIVATE_KEY = privateKey;
            _LANG = lang;
            _TEST = test;
            _request.AuthService(publicKey, privateKey);
            _requestApify.AuthService(publicKey, privateKey);
        }
        #endregion

        #region Atributes
        private string _PUBLIC_KEY = string.Empty;
        private string _PRIVATE_KEY = string.Empty;
        private string PARAMETER = string.Empty;
        private string ENDPOINT = string.Empty;
        private string _LANG = string.Empty;
        private bool _TEST = false;
        private string IV = "0000000000000000";
        #endregion

        #region Methods

        /*
         * METODOS RELACIONADOS CON EL CUSTOMER
         */
        public TokenModel? CreateToken(string cardNumber, string expYear, string expMonth, string cvc, bool hasCvv = false)
        {
            PARAMETER = body.GetBodyCreateToken(cardNumber, expYear, expMonth, cvc, hasCvv);
            ENDPOINT = Constants.UrlCreateToken;
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);

            TokenModel? token = JsonConvert.DeserializeObject<TokenModel>(content);
            return token;
        }
        
        public CustomerCreateModel? CustomerCreate(string tokenCard, 
            string name, 
            string lastName, 
            string email, 
            bool isDefault,
            string city = "",
            string address = "",
            string phone = "",
            string cellPhone = "")
        {
            PARAMETER = body.GetBodyCreateCustomer(tokenCard, name, lastName, email, isDefault, city, address, phone, cellPhone);
            ENDPOINT = Constants.UrlCreateCustomer;
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CustomerCreateModel? customer = JsonConvert.DeserializeObject<CustomerCreateModel>(content);
            return customer;
        }
        
        public CustomerFindModel? FindCustomer(string idCustomer)
        {
            ENDPOINT = body.GetQueryFindCustomer(_PUBLIC_KEY, idCustomer);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            CustomerFindModel? customer = JsonConvert.DeserializeObject<CustomerFindModel>(content);
            return customer;
        }
        
        public CustomerListModel? CustomerGetList()
        {
            ENDPOINT = body.GetQueryFindAllCustomers(_PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            StatusConsult? customer = JsonConvert.DeserializeObject<StatusConsult>(content);
            CustomerListModel? custom = new CustomerListModel();
            if (customer != null && customer.status)
            {
                custom = JsonConvert.DeserializeObject<CustomerListModel>(content);
            }
            else
            {
                custom.status = false;
                custom.message = customer?.message;
            }

            return custom;
        }
        
        public CustomerEditModel? CustomerUpdate(string idCustomer, string name)
        {
            ENDPOINT = body.GetQueryUpdateCustomer(_PUBLIC_KEY, idCustomer);
            PARAMETER = body.GetBodyUpdateCustomer(name);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CustomerEditModel? customer = JsonConvert.DeserializeObject<CustomerEditModel>(content);
            return customer;
        }
        
        public TokenMessage? AddNewToken(string tokenCard, string customerId)
        {
            ENDPOINT = Constants.UrlAddNewToken;
            PARAMETER = body.GetBodyAddNewToken(tokenCard, customerId);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            TokenMessage? customer = JsonConvert.DeserializeObject<TokenMessage>(content);
            return customer;
        }

        public SetDefaultToken? AddDefaultCard(string tokenCard, string customerId, string franchise, string mask)
        {
            ENDPOINT = Constants.UrlSetDefaultToken;
            PARAMETER = body.GetBodySetDefaultToken(tokenCard, customerId, franchise, mask);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            SetDefaultToken? customer = JsonConvert.DeserializeObject<SetDefaultToken>(content);
            return customer;
        }



        public CustomerTokenDeleteModel? CustomerDeleteToken(string franchise, string mask, string customerId)
        {
            ENDPOINT = Constants.UrlTokenDelete;
            PARAMETER = body.GetBodyDeleteTokenCustomer(franchise, mask, customerId);
       
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CustomerTokenDeleteModel? customer = JsonConvert.DeserializeObject<CustomerTokenDeleteModel>(content);
            return customer;
        }
        
        /*
         * METODOS RELACIONADOS CON PLANS
         */
        public CreatePlanModel? PlanCreate(string idPlan, string name, string description, decimal amount, string currency, string interval, int intervalCount, int trialDays)
        {
            ENDPOINT = Constants.UrlCreatePlan;
            PARAMETER = body.GetBodyCreatePlan(idPlan, name, description, amount, currency, interval, intervalCount, trialDays);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            
            CreatePlanModel? plan = JsonConvert.DeserializeObject<CreatePlanModel>(content);
            return plan;
        }
        
        public FindPlanModel? GetPlan(string idPlan)
        {
            ENDPOINT = body.GetQueryGetPlan(idPlan, _PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            FindPlanModel? plan = JsonConvert.DeserializeObject<FindPlanModel>(content);
            return plan;
        }
        
        public FindAllPlansModel? GetAllPlans()
        {
            FindAllPlansModel? plan = new FindAllPlansModel();
            ENDPOINT = body.GetQueryGetAllPlans(_PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            FindAllPlansSatusModel? status = JsonConvert.DeserializeObject<FindAllPlansSatusModel>(content);
            if (status != null && status.status)
            {
                plan = JsonConvert.DeserializeObject<FindAllPlansModel>(content);
            }
            else
            {
                plan.status = false;
                plan.message = status?.message;
            }
            return plan;
        }
        
        public RemovePlanModel? RemovePlan(string idPlan)
        {
            ENDPOINT = body.GetQueryRemovePlan(_PUBLIC_KEY, idPlan);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            RemovePlanModel? plan = JsonConvert.DeserializeObject<RemovePlanModel>(content);
            return plan;
        }

        /*
         * SUBSCRIPTIONS
         */
        public CreateSubscriptionModel? SubscriptionCreate(string idPlan, string customerId, string tokenCard, string docType, string docNumber, string? urlConfirmation = null, string? methodConfirmation = null)
        {
            ENDPOINT = Constants.UrlCreateSubscription;
            PARAMETER = BodyRequest.GetBodyCreateSubscription(idPlan, customerId, tokenCard, docType, docNumber, urlConfirmation, methodConfirmation);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
          
            CreateSubscriptionModel? subscription = JsonConvert.DeserializeObject<CreateSubscriptionModel>(content);
            return subscription;
        }

        public FindSusbscriptionModel? getSubscription(string subscriptionId)
        {
            ENDPOINT = body.GetQueryFindSubscription(_PUBLIC_KEY, subscriptionId);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            FindSusbscriptionModel? subscription = JsonConvert.DeserializeObject<FindSusbscriptionModel>(content);
            return subscription;
        }

        public AllSubscriptionModel? getAllSubscription()
        {
            ENDPOINT = body.GetQueryFindAllSubscription(_PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
          
                AllSubscriptionModel? subscription = JsonConvert.DeserializeObject<AllSubscriptionModel>(content);
                return subscription;
        }

        public CancelSubscriptionModel? CancelSubscription(string subscriptionId)
        {
            ENDPOINT = Constants.UrlCancelSubscription;
            PARAMETER = body.GetBodyCancelSubscription(subscriptionId);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CancelSubscriptionModel? subscription = JsonConvert.DeserializeObject<CancelSubscriptionModel>(content);
            return subscription;
        }

        public ChargeSubscriptionModel? ChargeSubscription(string idPlan,
             string customerId,
             string tokenCard,
             string docType,
             string docNumber,
             string? ip = null,
             string? address = null,
             string? phone = null,
             string? cellPhone = null,
             string? extras_epayco = "P46"
             )
        {
            ENDPOINT = Constants.UrlChageSubscription;
            PARAMETER = body.GetBodyChargeSubscription(idPlan, customerId, tokenCard, docType, docNumber, ip, address, phone, cellPhone, _TEST, extras_epayco: "P46");
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            ChargeSubscriptionModel? subscription = JsonConvert.DeserializeObject<ChargeSubscriptionModel>(content);
            return subscription;
        }




        /*
         * BANK CREATE
         */
        public PseModel? BankCreate(
            string bank, 
            string invoice, 
            string description,
            string value,
            string tax,
            string taxBase,
            string ico,
            string currency,
            string typePerson,
            string docType,
            string docNumber,
            string name,
            string lastName,
            string email,
            string country,
            string city,
            string cellPhone,
            string urlResponse,
            string urlConfirmation,
            string methodConfirmation,
            string extra1 = "N/A",
            string extra2 = "N/A",
            string extra3 = "N/A",
            string extra4 = "N/A",
            string extra5 = "N/A",
            string extra6 = "N/A",
            string extra7 = "N/A",
            string extra8 = "N/A",
            string extra9 = "N/A",
            string extra10 = "N/A",
            string? extras_epayco = "P46"

             )
        {
            ENDPOINT = Constants.UrlPagosDebitos;
            PARAMETER = body.GetBodyBankCreate(_auxiliars.ConvertToBase64(IV),_TEST,_PUBLIC_KEY,_PRIVATE_KEY, bank, invoice, description, value, tax,
                taxBase, ico, currency, typePerson, docType, docNumber, name, lastName, email, country, city,
                cellPhone, urlResponse, urlConfirmation, methodConfirmation, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10, extras_epayco: "P46");
            string? content = _restRequest.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            PseModel? pse = JsonConvert.DeserializeObject<PseModel>(content);
            return pse;
        }
        
        public PseModel? BankCreateSplit(
            string bank, 
            string invoice, 
            string description,
            string value,
            string tax,
            string taxBase,
            string ico,
            string currency,
            string typePerson,
            string docType,
            string docNumber,
            string name,
            string lastName,
            string email,
            string country,
            string city,
            string cellPhone,
            string urlResponse,
            string urlConfirmation,
            string methodConfirmation,
            string splitpayment,
            string splitAppId,
            string splitMerchantId,
            string splitType,
            string splitRule,
            string splitPrimaryReceiver,
            string splitPrimaryReceiverFee,
            List<SplitReceivers> splitReceivers,
            string extra1 = "N/A",
            string extra2 = "N/A",
            string extra3 = "N/A",
            string extra4 = "N/A",
            string extra5 = "N/A",
            string extra6 = "N/A",
            string extra7 = "N/A",
            string extra8 = "N/A",
            string extra9 = "N/A",
            string extra10 = "N/A",
            string? extras_epayco = "P46")
        {
            ENDPOINT = Constants.UrlPagosDebitos;
            PARAMETER = body.GetBodyBankCreateSplit(_auxiliars.ConvertToBase64(IV),_TEST,_PUBLIC_KEY,_PRIVATE_KEY, bank, invoice, description, value, tax,
                taxBase, ico, currency, typePerson, docType, docNumber, name, lastName, email, country, city,
                cellPhone, urlResponse, urlConfirmation, methodConfirmation, splitpayment, splitAppId, splitMerchantId,
                splitType, splitRule, splitPrimaryReceiver, splitPrimaryReceiverFee, splitReceivers, extra1, extra2, extra3,
                extra4, extra5, extra6, extra7, extra8, extra9, extra10, extras_epayco: "P46");
            string? content = _restRequest.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            PseModel? pse = JsonConvert.DeserializeObject<PseModel>(content);
            return pse;
        }
        
        public TransactionModel? GetTransaction(string transactionId)
        {
            ENDPOINT = body.GetQueryGetTransaction(_PUBLIC_KEY, transactionId);
            string? content = _restRequest.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            TransactionModel? transaction = new TransactionModel();
            TransactionResponse? response = JsonConvert.DeserializeObject<TransactionResponse>(content);
            if (response != null && response.success)
            {
                transaction = JsonConvert.DeserializeObject<TransactionModel>(content);
            }
            else
            {
                if (response != null)
                {
                    transaction.success = response.success;
                    transaction.title_response = response.title_response;
                    transaction.text_response = response.text_response;
                    transaction.last_action = response.last_action;
                }
            }
            return transaction;
        }
        
        public BanksModel? GetBanks()
        {
            BanksModel? bank = new BanksModel();
            ENDPOINT = body.GetQueryGetBanks(_PUBLIC_KEY,_TEST);
            string? content = _restRequest.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            BankResponse? response = JsonConvert.DeserializeObject<BankResponse>(content);
            if (response != null && response.success)
            {
                bank = JsonConvert.DeserializeObject<BanksModel>(content);
            }
            else
            {
                if (response != null)
                {
                    bank.success = response.success;
                    bank.text_response = response.text_response;
                    bank.title_response = response.title_response;
                    bank.last_action = response.last_action;
                }
            }
            return bank;
        }
        
        /*
         * CASH
         */
        public CashModel? CashCreate(string type, string invoice, 
            string description,
            string value,
            string tax,
            string taxBase,
            string ico,
            string currency,
            string typePerson,
            string docType,
            string docNumber,
            string name,
            string lastName,
            string email,
            string cellPhone,
            string endDate,
            string country,
            string city,
            string urlResponse,
            string urlConfirmation,
            string methodConfirmation,
            string extra1 = "N/A",
            string extra2 = "N/A",
            string extra3 = "N/A",
            string extra4 = "N/A",
            string extra5 = "N/A",
            string extra6 = "N/A",
            string extra7 = "N/A",
            string extra8 = "N/A",
            string extra9 = "N/A",
            string extra10 = "N/A",
            string extras_epayco = "P46",
            SplitModel? splitDetails = null)
        {
            CashModel? cash;
            CashModel? invalid = new CashModel
            {
                success = false,
                title_response = "Error",
                text_response = "Método de pago en efectivo no válido, unicamnete soportados: efecty, gana, redservi, puntored, sured",
                last_action = "validation transaction"
            };
            string medio = type.ToLower();
            if(medio == "baloto")
            {
                return invalid;
            }
            bool isCorrect = this.GetEntitiesCash(type);
            if (!isCorrect)
            {
                return invalid;
            }
            ENDPOINT = Constants.UrlCash + type;
            
            PARAMETER = body.GetBodyCashCreate(_auxiliars.ConvertToBase64(IV), _TEST, _PUBLIC_KEY, _PRIVATE_KEY,
                invoice, description, value, tax, taxBase, ico, currency, typePerson, docType, docNumber, name,
                lastName, email, cellPhone, endDate, country, city, urlResponse, urlConfirmation, methodConfirmation,  extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10, extras_epayco: "P46");
            
            if(splitDetails != null){
                string splitReqBody = body.GetBodySplitPayments(splitDetails, true);
               PARAMETER = Auxiliars.ConcatBodyStrings(PARAMETER, splitReqBody);
            }
            var content = _restRequest.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            
            cash = JsonConvert.DeserializeObject<CashModel>(content);
            return cash;
        }
        
        public CashTransactionModel? GetCashTransaction(string refPayco)
        {
            ENDPOINT = body.GetQueryCashTransaction(refPayco, _PUBLIC_KEY);
            string? content = _restRequest.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            CashTransactionModel? transaction = JsonConvert.DeserializeObject<CashTransactionModel>(content);
            return transaction;
        }
        
        /*
         * PAYMENT
         */
        public ChargeModel? ChargeCreate(
            string tokenCard,
            string customerId, 
            string docType,
            string docNumber,
            string name,
            string lastName,
            string email,
            string bill,
            string description,
            string value,
            string tax,
            string taxBase,
            string ico,
            string currency,
            string dues,
            string address,
            string country,
            string city,
            string phone,
            string cellPhone,
            string urlResponse,
            string urlConfirmation,
            string methodConfirmation,
            string ip,
            string extra1 = "N/A",
            string extra2 = "N/A",
            string extra3 = "N/A",
            string extra4 = "N/A",
            string extra5 = "N/A",
            string extra6 = "N/A",
            string extra7 = "N/A",
            string extra8 = "N/A",
            string extra9 = "N/A",
            string extra10 = "N/A",
            string extras_epayco = "P46",
            SplitModel? splitDetails = null)
        {
            ENDPOINT = Constants.UrlCharge;
            PARAMETER = body.GetBodyChargeCreate(tokenCard, customerId, docType, docNumber, name, lastName,
                email, bill, description, value, tax, taxBase, ico, currency, dues, address, country, city, phone, cellPhone,
                urlResponse,
                urlConfirmation, methodConfirmation, ip, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10, extras_epayco: "P46");
            
            if(splitDetails != null){
                string splitReqBody = body.GetBodySplitPayments(splitDetails);
                PARAMETER = Auxiliars.ConcatBodyStrings(PARAMETER, splitReqBody);
            }
            
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
         
           
            ChargeModel? payment = new ChargeModel();
            
            if (content.Contains("errorMessage"))
            {
                ChargeDataListError? response = JsonConvert.DeserializeObject<ChargeDataListError>(content);
                ChargeData data = new ChargeData
                {
                    status = response?.data.status,
                    description = response?.data.description,
                    errors = response?.data.errors 
                };
                if (response != null)
                {
                    payment.status = response.status;
                    payment.message = response.message;
                }

                payment.data = data;
               
            }else
            {
                payment = JsonConvert.DeserializeObject<ChargeModel>(content);
            }
            
            return payment;
        }
        
        public ChargeTransactionModel? GetChargeTransaction(string refPayco)
        {
            ENDPOINT = body.GetQueryCashTransaction(refPayco, _PUBLIC_KEY);
            string? content = _restRequest.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            ChargeTransactionModel? transaction = JsonConvert.DeserializeObject<ChargeTransactionModel>(content);
            return transaction;
        }

        /* 
         * DAVIPLATA
         */

        public DaviplataModel? DaviplataCreate(
            string docType,
            string document,
            string name,
            string lastName,
            string email,
            string indCountry,
            string phone,
            string country,
            string city,
            string address,
            string ip,
            string currency,
            string invoice,
            string description,
            decimal value,
            decimal tax = 0, 
            decimal taxBase = 0,
            decimal ico = 0,
            string test = "false",
            string urlResponse = "N/A",
            string urlConfirmation = "N/A",
            string methodConfirmation = "N/A",
            string extra1 = "N/A",
            string extra2 = "N/A",
            string extra3 = "N/A",
            string extra4 = "N/A",
            string extra5 = "N/A",
            string extra6 = "N/A",
            string extra7 = "N/A",
            string extra8 = "N/A",
            string extra9 = "N/A",
            string extra10 = "N/A",
            string extras_epayco = "P46"
            )
        {
            ENDPOINT = Constants.UrlDaviplata;
            PARAMETER = body.GetBodyDaviplata(docType, document, name, lastName,
                email, indCountry, phone, country, city, address, ip, currency, invoice, description, value, tax, taxBase, ico, test,
                urlResponse, urlConfirmation, methodConfirmation, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10, extras_epayco: "P46");
          
            string? content = _requestApify.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
           
            DaviplataModel? payment = JsonConvert.DeserializeObject<DaviplataModel>(content);
            return payment;
        }


        public DaviplataConfirmModel? DaviplataConfirm(
            string refPayco,
            string idSessionToken,
            string otp
            )
        {
            ENDPOINT = Constants.UrlDaviplataConfirm;
            PARAMETER = body.GetBodyConfirmDaviplata(refPayco, idSessionToken, otp);

            string? content = _requestApify.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);

            DaviplataConfirmModel? payment = JsonConvert.DeserializeObject<DaviplataConfirmModel>(content);
            return payment;
        }

        public safetypayModel? SafetypayCreate(string cash,
            string endDate,
            string docType,
            string document,
            string name,
            string lastName,
            string email,
            string indCountry,
            string phone,
            string country,
            string city,
            string address,
            string ip,
            string currency,
            string invoice,
            string description,
            decimal value,
            decimal tax = 0,
            decimal taxBase = 0,
            decimal ico = 0,
            string test = "false",
            string urlResponse = "N/A",
            string urlConfirmation = "N/A",
            string urlResponsePointer = "N/A",
            string methodConfirmation = "N/A",
            string extra1 = "N/A",
            string extra2 = "N/A",
            string extra3 = "N/A",
            string extra4 = "N/A",
            string extra5 = "N/A",
            string extra6 = "N/A",
            string extra7 = "N/A",
            string extra8 = "N/A",
            string extra9 = "N/A",
            string extra10 = "N/A",
            string? extras_epayco = "P46")
        {
            ENDPOINT = Constants.UrlSafetypay;
            PARAMETER = body.GetBodySafetypayCreate(cash,endDate,docType,document,name,lastName,email,
                indCountry,phone,country,city,address,ip,currency,invoice,description,value,tax,taxBase,ico,
                test,urlResponse, urlResponsePointer, urlConfirmation, methodConfirmation, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10, extras_epayco: "P46");
    
             string? content = _requestApify.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);

            safetypayModel? payment = JsonConvert.DeserializeObject<safetypayModel>(content);
            return payment;
        }

        private bool GetEntitiesCash(string type)
        {
            ENDPOINT = Constants.UrlEntitiesCash;
          
            string? content = _requestApify.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            EntitiesCashModel? response = JsonConvert.DeserializeObject<EntitiesCashModel>(content);

            if (response != null && !response.success)
            {
                return false;
            }

            if (response != null)
            {
                var data = response.data.Select(item => item.name.ToLower().Replace(" ", String.Empty)).ToArray();
                if (data.Contains(type))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion



    }
}
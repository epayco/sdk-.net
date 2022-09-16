using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Linq;
using EpaycoSdk.Models;
using EpaycoSdk.Models.Bank;
using EpaycoSdk.Models.Cash;
using EpaycoSdk.Models.Charge;
using EpaycoSdk.Models.Plans;
using EpaycoSdk.Models.Subscriptions;
using EpaycoSdk.Models.Daviplata;
using EpaycoSdk.Models.Safetypay;
using EpaycoSdk.Utils;
using Newtonsoft.Json;

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
        public TokenModel CreateToken(string cardNumber, string expYear, string expMonth, string cvc)
        {
            PARAMETER = body.getBodyCreateToken(cardNumber, expYear, expMonth, cvc);
            ENDPOINT = Constants.url_create_token;
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            TokenModel token = JsonConvert.DeserializeObject<TokenModel>(content);
            return token;
        }

        public CustomerCreateModel CustomerCreate(string token_card, 
            string name, 
            string last_name, 
            string email, 
            bool isDefault,
            string city = "",
            string address = "",
            string phone = "",
            string cell_phone = "")
        {
            PARAMETER = body.getBodyCreateCustomer(token_card, name, last_name, email, isDefault, city, address, phone, cell_phone);
            ENDPOINT = Constants.url_create_customer;
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CustomerCreateModel customer = JsonConvert.DeserializeObject<CustomerCreateModel>(content);
            return customer;
        }

        public CustomerFindModel FindCustomer(string id_customer)
        {
            ENDPOINT = body.getQueryFindCustomer(_PUBLIC_KEY, id_customer);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            CustomerFindModel customer = JsonConvert.DeserializeObject<CustomerFindModel>(content);
            return customer;
        }
        
        public CustomerListModel CustomerGetList()
        {
            ENDPOINT = body.getQueryFindAllCustomers(_PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            StatusConsult customer = JsonConvert.DeserializeObject<StatusConsult>(content);
            CustomerListModel custom = new CustomerListModel();
            if (customer.status)
            {
                custom = JsonConvert.DeserializeObject<CustomerListModel>(content);
            }
            else
            {
                custom.status = false;
                custom.message = customer.message;
            }

            return custom;;
        }
        
        public CustomerEditModel CustomerUpdate(string id_customer, string name)
        {
            ENDPOINT = body.getQueryUpdateCustomer(_PUBLIC_KEY, id_customer);
            PARAMETER = body.getBodyUpdateCustomer(name);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CustomerEditModel customer = JsonConvert.DeserializeObject<CustomerEditModel>(content);
            return customer;
        }

        public TokenMessage addNewToken(string token_card, string customer_id)
        {
            ENDPOINT = Constants.url_add_new_token;
            PARAMETER = body.getBodyAddNewToken(token_card, customer_id);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            TokenMessage customer = JsonConvert.DeserializeObject<TokenMessage>(content);
            return customer;
        }

        public SetDefaultToken addDefaultCard(string token_card, string customer_id, string franchise, string mask)
        {
            ENDPOINT = Constants.url_set_default_token;
            PARAMETER = body.getBodySetDefaultToken(token_card, customer_id, franchise, mask);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            SetDefaultToken customer = JsonConvert.DeserializeObject<SetDefaultToken>(content);
            return customer;
        }



        public CustomerTokenDeleteModel CustomerDeleteToken(string franchise, string mask, string customer_id)
        {
            ENDPOINT = Constants.url_token_delete;
            PARAMETER = body.getBodyDeleteTokenCustomer(franchise, mask, customer_id);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CustomerTokenDeleteModel customer = JsonConvert.DeserializeObject<CustomerTokenDeleteModel>(content);
            return customer;
        }
        
        /*
         * METODOS RELACIONADOS CON PLANS
         */
        public CreatePlanModel PlanCreate(string id_plan, string name, string description, decimal amount, string currency, string interval, int interval_count, int trial_days)
        {
            ENDPOINT = Constants.url_create_plan;
            PARAMETER = body.getBodyCreatePlan(id_plan, name, description, amount, currency, interval, interval_count, trial_days);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CreatePlanModel plan = JsonConvert.DeserializeObject<CreatePlanModel>(content);
            return plan;
        }
        
        public FindPlanModel GetPlan(string id_plan)
        {
            ENDPOINT = body.getQueryGetPlan(id_plan, _PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            FindPlanModel plan = JsonConvert.DeserializeObject<FindPlanModel>(content);
            return plan;
        }
        
        public FindAllPlansModel GetAllPlans()
        {
            FindAllPlansModel plan = new FindAllPlansModel();
            ENDPOINT = body.getQueryGetAllPlans(_PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            FindAllPlansSatusModel status = JsonConvert.DeserializeObject<FindAllPlansSatusModel>(content);
            if (status.status)
            {
                plan = JsonConvert.DeserializeObject<FindAllPlansModel>(content);
            }
            else
            {
                plan.status = false;
                plan.message = status.message;
            }
            return plan;
        }
        
        public RemovePlanModel RemovePlan(string id_plan)
        {
            ENDPOINT = body.getQueryRemovePlan(_PUBLIC_KEY, id_plan);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            RemovePlanModel plan = JsonConvert.DeserializeObject<RemovePlanModel>(content);
            return plan;
        }

        /*
         * SUBSCRIPTIONS
         */
        public CreateSubscriptionModel SubscriptionCreate(string id_plan, string customer_id, string token_card, string doc_type, string doc_number, string url_confirmation = null, string method_confirmation = null)
        {
            ENDPOINT = Constants.url_create_subscription;
            PARAMETER = body.getBodyCreateSubscription(id_plan, customer_id, token_card, doc_type, doc_number, url_confirmation, method_confirmation);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CreateSubscriptionModel subscription = JsonConvert.DeserializeObject<CreateSubscriptionModel>(content);
            return subscription;
        }
        
        public FindSusbscriptionModel getSubscription(string subscriptionId)
        {
            ENDPOINT = body.getQueryFindSubscription(_PUBLIC_KEY, subscriptionId);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            FindSusbscriptionModel subscription = JsonConvert.DeserializeObject<FindSusbscriptionModel>(content);
            return subscription;
        }
        
        public AllSubscriptionModel getAllSubscription()
        {
            ENDPOINT = body.getQueryFindAllSubscription(_PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            SubscriptionStatus status = JsonConvert.DeserializeObject<SubscriptionStatus>(content);
            AllSubscriptionModel subscription = new AllSubscriptionModel();
            if (status.status)
            {
                subscription = JsonConvert.DeserializeObject<AllSubscriptionModel>(content);
            }
            else
            {
                subscription.status = false;
                subscription.message = status.message;
            }
            return subscription;
        }
        
        public CancelSubscriptionModel cancelSubscription(string subscriptionId)
        {
            ENDPOINT = Constants.url_cancel_subscription;
            PARAMETER = body.getBodyCancelSubscription(subscriptionId);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CancelSubscriptionModel subscription = JsonConvert.DeserializeObject<CancelSubscriptionModel>(content);
            return subscription;
        }
        
        public ChargeSubscriptionModel ChargeSubscription(string id_plan, 
            string customer_id, 
            string token_card,
            string doc_type,
            string doc_number,
            string ip,
            string address = null,
            string phone = null,
            string cell_phone = null
            )
        {
            ENDPOINT = Constants.url_chage_subscription;
            PARAMETER = body.getBodyChargeSubscription(id_plan, customer_id, token_card, doc_type, doc_number, ip, address, phone, cell_phone);
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            ChargeSubscriptionModel subscription = JsonConvert.DeserializeObject<ChargeSubscriptionModel>(content);
            return subscription;
        }
        
        /*
         * BANK CREATE
         */
        public PseModel BankCreate(
            string bank, 
            string invoice, 
            string description,
            string value,
            string tax,
            string tax_base,
            string ico,
            string currency,
            string type_person,
            string doc_type,
            string doc_number,
            string name,
            string last_name,
            string email,
            string country,
            string city,
            string cell_phone,
            string url_response,
            string url_confirmation,
            string method_confirmation,
            string extra1 = "N/A",
            string extra2 = "N/A",
            string extra3 = "N/A",
            string extra4 = "N/A",
            string extra5 = "N/A",
            string extra6 = "N/A",
            string extra7 = "N/A",
            string extra8 = "N/A",
            string extra9 = "N/A",
            string extra10 = "N/A")
        {
            ENDPOINT = Constants.url_pagos_debitos;
            PARAMETER = body.getBodyBankCreate(_auxiliars.ConvertToBase64(IV),_TEST,_PUBLIC_KEY,_PRIVATE_KEY, bank, invoice, description, value, tax,
                tax_base, ico, currency, type_person, doc_type, doc_number, name, last_name, email, country, city,
                cell_phone, url_response, url_confirmation, method_confirmation, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
            string content = _restRequest.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            PseModel pse = JsonConvert.DeserializeObject<PseModel>(content);
            return pse;
        }
        
        public PseModel BankCreateSplit(
            string bank, 
            string invoice, 
            string description,
            string value,
            string tax,
            string tax_base,
            string ico,
            string currency,
            string type_person,
            string doc_type,
            string doc_number,
            string name,
            string last_name,
            string email,
            string country,
            string city,
            string cell_phone,
            string url_response,
            string url_confirmation,
            string method_confirmation,
            string splitpayment,
            string split_app_id,
            string split_merchant_id,
            string split_type,
            string split_rule,
            string split_primary_receiver,
            string split_primary_receiver_fee,
            List<SplitReceivers> split_receivers,
            string extra1 = "N/A",
            string extra2 = "N/A",
            string extra3 = "N/A",
            string extra4 = "N/A",
            string extra5 = "N/A",
            string extra6 = "N/A",
            string extra7 = "N/A",
            string extra8 = "N/A",
            string extra9 = "N/A",
            string extra10 = "N/A")
        {
            ENDPOINT = Constants.url_pagos_debitos;
            PARAMETER = body.getBodyBankCreateSplit(_auxiliars.ConvertToBase64(IV),_TEST,_PUBLIC_KEY,_PRIVATE_KEY, bank, invoice, description, value, tax,
                tax_base, ico, currency, type_person, doc_type, doc_number, name, last_name, email, country, city,
                cell_phone, url_response, url_confirmation, method_confirmation, splitpayment, split_app_id, split_merchant_id,
                split_type, split_rule, split_primary_receiver, split_primary_receiver_fee, split_receivers, extra1, extra2, extra3,
                extra4, extra5, extra6, extra7, extra8, extra9, extra10);
            string content = _restRequest.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            PseModel pse = JsonConvert.DeserializeObject<PseModel>(content);
            return pse;
        }
        
        public TransactionModel GetTransaction(string transactionId)
        {
            ENDPOINT = body.getQueryGetTransaction(_PUBLIC_KEY, transactionId);
            string content = _restRequest.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            TransactionModel transaction = new TransactionModel();
            TransactionResponse response = JsonConvert.DeserializeObject<TransactionResponse>(content);
            if (response.success)
            {
                transaction = JsonConvert.DeserializeObject<TransactionModel>(content);
            }
            else
            {
                transaction.success = response.success;
                transaction.title_response = response.title_response;
                transaction.text_response = response.text_response;
                transaction.last_action = response.last_action;
            }
            return transaction;
        }
        
        public BanksModel GetBanks()
        {
            BanksModel bank = new BanksModel();
            ENDPOINT = body.getQueryGetBanks(_PUBLIC_KEY,_TEST);
            string content = _restRequest.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            BankResponse response = JsonConvert.DeserializeObject<BankResponse>(content);
            if (response.success)
            {
                bank = JsonConvert.DeserializeObject<BanksModel>(content);
            }
            else
            {
                bank.success = response.success;
                bank.text_response = response.text_response;
                bank.title_response = response.title_response;
                bank.last_action = response.last_action;
            }
            return bank;
        }
        
        /*
         * CASH
         */
        public CashModel CashCreate(string type, string invoice, 
            string description,
            string value,
            string tax,
            string tax_base,
            string ico,
            string currency,
            string type_person,
            string doc_type,
            string doc_number,
            string name,
            string last_name,
            string email,
            string cell_phone,
            string end_date,
            string country,
            string city,
            string url_response,
            string url_confirmation,
            string method_confirmation,
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
            SplitModel split_details = null)
        {
            CashModel cash;
            string content;
            CashModel invalid = new CashModel
            {
                success = false,
                title_response = "Error",
                text_response = "Método de pago en efectivo no válido, unicamnete soportados: efecty, gana, redservi, puntored, sured",
                last_action = "validation transaction",
                data = new DataCash
                {
                    totalerrores = 1,
                    errores = new List<errors>
                        {
                            new errors
                            {
                                codError = "109",
                                errorMessage = "Método de pago en efectivo no válido, unicamnete soportados: efecty, gana, redservi, puntored, sured"
                            }
                        }
                }
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
            ENDPOINT = Constants.url_cash + type;
            
            PARAMETER = body.getBodyCashCreate(_auxiliars.ConvertToBase64(IV), _TEST, _PUBLIC_KEY, _PRIVATE_KEY,
                invoice, description, value, tax, tax_base, ico, currency, type_person, doc_type, doc_number, name,
                last_name, email, cell_phone, end_date, country, city, url_response, url_confirmation, method_confirmation,  extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
            
            if(split_details != null){
                string split_req_body = body.getBodySplitPayments(split_details, true);
               PARAMETER = Auxiliars.ConcatBodyStrings(PARAMETER, split_req_body);
            }
            content = _restRequest.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            cash = JsonConvert.DeserializeObject<CashModel>(content);
            return cash;
        }
        
        public CashTransactionModel GetCashTransaction(string ref_payco)
        {
            ENDPOINT = body.getQueryCashTransaction(ref_payco, _PUBLIC_KEY);
            string content = _restRequest.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            CashTransactionModel transaction = JsonConvert.DeserializeObject<CashTransactionModel>(content);
            return transaction;
        }
        
        /*
         * PAYMENT
         */
        public ChargeModel ChargeCreate(
            string token_card,
            string customer_id, 
            string doc_type,
            string doc_number,
            string name,
            string last_name,
            string email,
            string bill,
            string description,
            string value,
            string tax,
            string tax_base,
            string ico,
            string currency,
            string dues,
            string address,
            string country,
            string city,
            string phone,
            string cell_phone,
            string url_response,
            string url_confirmation,
            string method_confirmation,
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
            SplitModel split_details = null)
        {
            ENDPOINT = Constants.url_charge;
            PARAMETER = body.getBodyChargeCreate(token_card, customer_id, doc_type, doc_number, name, last_name,
                email, bill, description, value, tax, tax_base, ico, currency, dues, address, country, city, phone, cell_phone,
                url_response,
                url_confirmation, method_confirmation, ip, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
            
            if(split_details != null){
                string split_req_body = body.getBodySplitPayments(split_details, false);
                PARAMETER = Auxiliars.ConcatBodyStrings(PARAMETER, split_req_body);
            }
            
            string content = _request.Execute(
                ENDPOINT, 
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
         
            ChargeModel payment = new ChargeModel();
            
            if (content.Contains("errorMessage"))
            {
                ChargeDataListError response = JsonConvert.DeserializeObject<ChargeDataListError>(content);
                ChargeData data = new ChargeData
                {
                    status = response.data.status,
                    description = response.data.description,
                    errors = response.data.errors
                };
                payment.status = response.status;
                payment.message = response.message;
                payment.data = data;
               
            }else
            {
                payment = JsonConvert.DeserializeObject<ChargeModel>(content);
            }
            
            return payment;
        }
        
        public ChargeTransactionModel GetChargeTransaction(string ref_payco)
        {
            ENDPOINT = body.getQueryCashTransaction(ref_payco, _PUBLIC_KEY);
            string content = _restRequest.Execute(
                ENDPOINT, 
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            ChargeTransactionModel transaction = JsonConvert.DeserializeObject<ChargeTransactionModel>(content);
            return transaction;
        }

        /* 
         * DAVIPLATA
         */

        public DaviplataModel DaviplataCreate(
            string doc_type,
            string document,
            string name,
            string last_name,
            string email,
            string ind_country,
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
            decimal tax_base = 0,
            decimal ico = 0,
            bool test = false,
            string url_response = "N/A",
            string url_confirmation = "N/A",
            string method_confirmation = "N/A",
            string extra1 = "N/A",
            string extra2 = "N/A",
            string extra3 = "N/A",
            string extra4 = "N/A",
            string extra5 = "N/A",
            string extra6 = "N/A",
            string extra7 = "N/A",
            string extra8 = "N/A",
            string extra9 = "N/A",
            string extra10 = "N/A"
            )
        {
            ENDPOINT = Constants.url_daviplata;
            PARAMETER = body.getBodyDaviplata(doc_type, document, name, last_name,
                email, ind_country, phone, country, city, address, ip, currency, invoice, description, value, tax, tax_base, ico, test,
                url_response, url_confirmation, method_confirmation, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
            string content = _requestApify.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            DaviplataModel payment = JsonConvert.DeserializeObject<DaviplataModel>(content);
            return payment;
        }


        public DaviplataConfirmModel DaviplataConfirm(
            string ref_payco,
            string id_session_token,
            string otp
            )
        {
            ENDPOINT = Constants.url_daviplata_confirm;
            PARAMETER = body.getBodyConfirmDaviplata(ref_payco, id_session_token, otp);

            string content = _requestApify.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);

            DaviplataConfirmModel payment = JsonConvert.DeserializeObject<DaviplataConfirmModel>(content);
            return payment;
        }

        public safetypayModel SafetypayCreate(string cash,
            string end_date,
            string doc_type,
            string document,
            string name,
            string last_name,
            string email,
            string ind_country,
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
            decimal tax_base = 0,
            decimal ico = 0,
            bool test = false,
            string url_response = "N/A",
            string url_confirmation = "N/A",
            string url_response_pointer = "N/A",
            string method_confirmation = "N/A",
            string extra1 = "N/A",
            string extra2 = "N/A",
            string extra3 = "N/A",
            string extra4 = "N/A",
            string extra5 = "N/A",
            string extra6 = "N/A",
            string extra7 = "N/A",
            string extra8 = "N/A",
            string extra9 = "N/A",
            string extra10 = "N/A")
        {
            ENDPOINT = Constants.url_safetypay;
            PARAMETER = body.getBodySafetypayCreate(cash,end_date,doc_type,document,name,last_name,email,
                ind_country,phone,country,city,address,ip,currency,invoice,description,value,tax,tax_base,ico,
                test,url_response, url_response_pointer, url_confirmation, method_confirmation, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);

            string content = _requestApify.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);

            safetypayModel payment = JsonConvert.DeserializeObject<safetypayModel>(content);
            return payment;
        }

        private bool GetEntitiesCash(string type)
        {
            ENDPOINT = Constants.url_entities_cash;
          
            string content = _requestApify.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            EntitiesCashModel response = JsonConvert.DeserializeObject<EntitiesCashModel>(content);

            if (!response.success)
            {
                return false;
            }
            var data = response.data.Select(item => item.name.ToLower().Replace(" ", String.Empty)).ToArray();
            if (data.Contains(type))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
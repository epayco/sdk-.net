using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using EpaycoSdk.Models.Bank;
using EpaycoSdk.Models.Cash;
using EpaycoSdk.Models.Daviplata;
using EpaycoSdk.Models.Safetypay;
using Newtonsoft;

namespace EpaycoSdk.Utils
{
    public class BodyRequest
    {
        #region Constructor

        public BodyRequest()
        {
            
        }
        #endregion

        #region Methods

        public string GetBodyAuthBearer(string publicKey, string privateKey)
        {
            return "{\n\"public_key\":\"" + publicKey + "\"," +
                   "\n\"private_key\":\"" + privateKey + "\"\n}";
        }
        public string GetBodyCreateToken(string cardNumber, string expYear, string expMonth, string cvc, bool hasCvv)
        {
            return "{\n\"card[number]\":\"" + cardNumber + "\"," +
                   "\n\"card[exp_year]\":\"" + expYear + "\"," +
                   "\n\"card[exp_month]\":\"" + expMonth + "\"," +
                   "\n\"card[cvc]\":\"" + cvc + "\","+
                   "\n\"hasCvv\":\"" + hasCvv + "\"\n}";
        }

        public string GetBodyCreateCustomer(
            string tokenCard, 
            string name, 
            string lastName, 
            string email, 
            bool isDefault,
            string city,
            string address,
            string phone,
            string cellPhone)
        {
            return
                "{\n\"token_card\":\"" + tokenCard + "\"," +
                "\n\"name\":\"" + name + "\"," +
                "\n\"last_name\":\"" + lastName + "\"," +
                "\n\"email\":\"" + email + "\"," +
                "\n\"default\":\"" + isDefault + "\"," +
                "\n\"city\":\"" + city + "\"," +
                "\n\"address\":\"" + address + "\"," +
                "\n\"phone\":\"" + phone + "\"," +
                "\n\"cell_phone\":\"" + cellPhone + "\"\n}";
               
        }

        public string GetQueryFindCustomer(string publicKey, string idCustomer)
        {
            return Constants.UrlFindCustomer + publicKey + "/" + idCustomer;
        }
        
        public string GetQueryFindAllCustomers(string publicKey)
        {
            return Constants.UrlFindAllCustomer + publicKey;
        }
        
        public string GetQueryUpdateCustomer(string publicKey, string customerId)
        {
            return Constants.UrlUpdateCustomer + publicKey + "/" + customerId;
        }
        
        public string GetBodyUpdateCustomer(string name)
        {
            return "{\r\n\"name\":\""+name+"\"\r\n}";
        }
        
        public string GetBodyDeleteTokenCustomer(string franchise, string mask, string customerId)
        {
            return "{\n\"franchise\":\"" + franchise + "\"," +
                   "\n\"mask\":\"" + mask + "\"," +
                   "\n\"customer_id\":\"" + customerId + "\"\n}";
        }

        public string GetBodyAddNewToken(string tokenCard, string customerId)
        {
            return "{\n\"token_card\":\"" + tokenCard + "\"," +
                   "\n\"customer_id\":\"" + customerId + "\"\n}";
        }
        public string GetBodySetDefaultToken(string token, string customerId, string franchise, string mask)
        {
            return "{\n\"franchise\":\"" + franchise + "\"," +
                   "\n\"token\":\"" + token + "\"," +
                   "\n\"mask\":\"" + mask + "\"," +
                   "\n\"customer_id\":\"" + customerId + "\"\n}";
        }


        /*
         * PLANS QUERYS AND BODY
         */
        public string GetBodyCreatePlan(string idPlan, string name, string description, decimal amount, string currency, string interval, int intervalCount, int trialDays)
        {
            return "{\r\n\"id_plan\":\""+idPlan+"\",\r" +
                   "\n\"name\":\""+name+"\",\r" +
                   "\n\"description\":\""+description+"\",\r" +
                   "\n\"amount\": "+amount+",\r" +
                   "\n\"currency\": \""+currency+"\",\r" +
                   "\n\"interval\": \""+interval+"\",\r" +
                   "\n\"interval_count\": "+intervalCount+",\r" +
                   "\n\"trial_days\":"+trialDays+"\r\n}";
        }
        
        public string GetQueryGetPlan(string idPlan, string publicKey)
        {
            return Constants.UrlGetPlan + publicKey + "/" + idPlan;
        }
        
        public string GetQueryGetAllPlans(string publicKey)
        {
            return Constants.UrlGetAllPlans + publicKey;
        }
        
        public string GetQueryRemovePlan(string publicKey, string idPlan)
        {
            return Constants.UrlRemovePlan + publicKey + "/" + idPlan;
        }
        
        /*
         * SUBSCRIPTIONS
         */
        public static string GetBodyCreateSubscription(string idPlan, string customerId, string tokenCard, string docType,
            string docNumber, string? urlConfirmation = null, string? methodConfirmation = null)
        {
            string body = "";
            if (urlConfirmation != null && methodConfirmation != null)
            {
                body = "{\r\n\"id_plan\": \""+idPlan+"\",\r" +
                       "\n\"customer\": \""+customerId+"\",\r" +
                       "\n\"token_card\": \""+tokenCard+"\",\r" +
                       "\n\"doc_type\": \""+docType+"\",\r" +
                       "\n\"url_confirmation\": \""+urlConfirmation+"\",\r" +
                       "\n\"method_confirmation\": \""+methodConfirmation+"\",\r" +
                       "\n\"doc_number\": \""+docNumber+"\"\r\n}";
            }
            else
            {
                body = "{\r\n\"id_plan\": \""+idPlan+"\",\r" +
                       "\n\"customer\": \""+customerId+"\",\r" +
                       "\n\"token_card\": \""+tokenCard+"\",\r" +
                       "\n\"doc_type\": \""+docType+"\",\r" +
                       "\n\"doc_number\": \""+docNumber+"\"\r\n}";
            }

            return body;
        }
        public string GetQueryFindSubscription(string publicKey, string id)
        {
            return Constants.UrlGetSubscription + id + "/" + publicKey;
        }
        
        public string GetQueryFindAllSubscription(string publicKey)
        {
            return Constants.UrlGetAllSubscriptions + publicKey;
        }
        
        public string GetBodyCancelSubscription(string subscriptionId)
        {
            return "{\r\n\"id\":\""+subscriptionId+"\"\r\n}";
        }
        
        public string GetBodyChargeSubscription(string idPlan, 
            string customerId, 
            string tokenCard,
            string docType,
            string docNumber,
            string? ip = null,
            string? address = null,
            string? phone = null,
            string? cellPhone = null,
            bool test =  false,
            string? extras_epayco = "P46" 
            )
        {
            var TEST = test ? "TRUE" : "FALSE";
            return "{\r\n\"id_plan\": \""+idPlan+"\",\r" +
                  "\n\"customer\": \""+customerId+"\",\r" +
                  "\n\"token_card\": \""+tokenCard+"\",\r" +
                  "\n\"doc_type\": \""+docType+"\",\r" +
                  "\n\"doc_number\": \"" + docNumber + "\",\r" +
                  "\n\"ip\": \"" +ip+"\",\r" +
                  "\n\"address\": \"" +address+"\",\r" +
                  "\n\"phone\": \"" +phone+"\",\r" +
                  "\n\"cell_phone\": \"" +cellPhone+"\",\r" +
                  "\n\"test\": \"" + TEST + "\",\r" +
                  "\n\"extras_epayco\": {\"extra5\": \"" + "P46" + "\"}\r\n}";

        }
        
        /*
         * PSE
         */
        public string GetBodyBankCreate(
            string I,
            bool test,
            string publicKey,
            string privateKey,
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
            string extra1,
            string extra2,
            string extra3,
            string extra4,
            string extra5,
            string extra6,
            string extra7,
            string extra8,
            string extra9,
            string extra10,
            string extras_epayco)
        {
            var localIp = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            localIp = host.AddressList.First(i => i.AddressFamily.ToString() == "InterNetwork").ToString();
            return "{\r\n\"banco\": \""+Auxiliars.AESEncrypt(bank, privateKey)+"\",\r" +
                   "\n\"factura\": \""+Auxiliars.AESEncrypt(invoice, privateKey)+"\",\r" +
                   "\n\"descripcion\": \""+Auxiliars.AESEncrypt(description, privateKey)+"\",\r" +
                   "\n\"valor\": \""+Auxiliars.AESEncrypt(value, privateKey)+"\",\r" +
                   "\n\"iva\": \""+Auxiliars.AESEncrypt(tax, privateKey)+"\",\r" +
                   "\n\"baseiva\": \""+Auxiliars.AESEncrypt(taxBase, privateKey)+"\",\r" +
                   "\n\"ico\": \""+Auxiliars.AESEncrypt(ico, privateKey)+"\",\r" +
                   "\n\"moneda\": \""+Auxiliars.AESEncrypt(currency, privateKey)+"\",\r" +
                   "\n\"tipo_persona\": \""+Auxiliars.AESEncrypt(typePerson, privateKey)+"\",\r" +
                   "\n\"tipo_doc\": \""+Auxiliars.AESEncrypt(docType, privateKey)+"\",\r" +
                   "\n\"documento\": \""+Auxiliars.AESEncrypt(docNumber, privateKey)+"\",\r" +
                   "\n\"nombres\": \""+Auxiliars.AESEncrypt(name, privateKey)+"\",\r" +
                   "\n\"apellidos\": \""+Auxiliars.AESEncrypt(lastName, privateKey)+"\",\r" +
                   "\n\"email\": \""+Auxiliars.AESEncrypt(email, privateKey)+"\",\r" +
                   "\n\"pais\": \""+Auxiliars.AESEncrypt(country, privateKey)+"\",\r" +
                   "\n\"ciudad\": \"" + Auxiliars.AESEncrypt(city, privateKey)+"\",\r" +
                   "\n\"celular\": \""+Auxiliars.AESEncrypt(cellPhone, privateKey)+"\",\r" +
                   "\n\"url_respuesta\": \""+Auxiliars.AESEncrypt(urlResponse, privateKey)+"\",\r" +
                   "\n\"url_confirmacion\": \""+Auxiliars.AESEncrypt(urlConfirmation, privateKey)+"\",\r" +
                   "\n\"metodoconfirmacion\": \""+Auxiliars.AESEncrypt(methodConfirmation, privateKey)+"\",\r" +
                   "\n\"extra1\": \""+Auxiliars.AESEncrypt(extra1, privateKey)+"\",\r" +
                   "\n\"extra2\": \""+Auxiliars.AESEncrypt(extra2, privateKey)+"\",\r" +
                   "\n\"extra3\": \""+Auxiliars.AESEncrypt(extra3, privateKey)+"\",\r" +
                   "\n\"extra4\": \""+Auxiliars.AESEncrypt(extra4, privateKey)+"\",\r" +
                   "\n\"extra5\": \""+Auxiliars.AESEncrypt(extra5, privateKey)+"\",\r" +
                   "\n\"extra6\": \""+Auxiliars.AESEncrypt(extra6, privateKey)+"\",\r" +
                   "\n\"extra7\": \""+Auxiliars.AESEncrypt(extra7, privateKey)+"\",\r" +
                   "\n\"extra8\": \""+Auxiliars.AESEncrypt(extra8, privateKey)+"\",\r" +
                   "\n\"extra9\": \""+Auxiliars.AESEncrypt(extra9, privateKey)+"\",\r" +
                   "\n\"extra10\": \""+Auxiliars.AESEncrypt(extra10, privateKey)+"\",\r" +
                   "\n\"extras_epayco\": {\"extra5\": \"" + Auxiliars.AESEncrypt("P46", privateKey) + "\"},\r" +
                   "\n\"public_key\": \"" +publicKey+"\",\r" +
                   "\n\"enpruebas\": \""+Auxiliars.AESEncrypt(test.ToString(), privateKey)+"\",\r" +
                   "\n\"ip\": \""+Auxiliars.AESEncrypt(localIp, privateKey)+"\",\r" +
                   "\n\"i\": \""+I+"\",\r" +
                   "\n\"lenguaje\": \""+".net"+"\"\r\n}";
        }
        
        public string GetBodyBankCreateSplit(
           string I,
           bool test,
           string publicKey,
           string privateKey,
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
            string extra1,
            string extra2,
            string extra3,
            string extra4,
            string extra5,
            string extra6,
            string extra7,
            string extra8,
            string extra9,
            string extra10,
            string? extras_epayco)
        {
           var localIp = "";
           var splitReceiversJson = Newtonsoft.Json.JsonConvert.SerializeObject(splitReceivers);
           IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
           localIp = host.AddressList.First(i => i.AddressFamily.ToString() == "InterNetwork").ToString();

            return "{\r\n\"banco\": \""+Auxiliars.AESEncrypt(bank, privateKey)+"\",\r" +
                  "\n\"factura\": \""+Auxiliars.AESEncrypt(invoice, privateKey)+"\",\r" +
                  "\n\"descripcion\": \""+Auxiliars.AESEncrypt(description, privateKey)+"\",\r" +
                  "\n\"valor\": \""+Auxiliars.AESEncrypt(value, privateKey)+"\",\r" +
                  "\n\"iva\": \""+Auxiliars.AESEncrypt(tax, privateKey)+"\",\r" +
                  "\n\"baseiva\": \""+Auxiliars.AESEncrypt(taxBase, privateKey)+"\",\r" +
                  "\n\"ico\": \""+Auxiliars.AESEncrypt(ico, privateKey)+"\",\r" +
                  "\n\"moneda\": \""+Auxiliars.AESEncrypt(currency, privateKey)+"\",\r" +
                  "\n\"tipo_persona\": \""+Auxiliars.AESEncrypt(typePerson, privateKey)+"\",\r" +
                  "\n\"tipo_doc\": \""+Auxiliars.AESEncrypt(docType, privateKey)+"\",\r" +
                  "\n\"documento\": \""+Auxiliars.AESEncrypt(docNumber, privateKey)+"\",\r" +
                  "\n\"nombres\": \""+Auxiliars.AESEncrypt(name, privateKey)+"\",\r" +
                  "\n\"apellidos\": \""+Auxiliars.AESEncrypt(lastName, privateKey)+"\",\r" +
                  "\n\"email\": \""+Auxiliars.AESEncrypt(email, privateKey)+"\",\r" +
                  "\n\"pais\": \""+Auxiliars.AESEncrypt(country, privateKey)+"\",\r" +
                  "\n\"ciudad\": \""+ Auxiliars.AESEncrypt(city, privateKey)+"\",\r" +
                  "\n\"celular\": \""+Auxiliars.AESEncrypt(cellPhone, privateKey)+"\",\r" +
                  "\n\"url_respuesta\": \""+Auxiliars.AESEncrypt(urlResponse, privateKey)+"\",\r" +
                  "\n\"url_confirmacion\": \""+Auxiliars.AESEncrypt(urlConfirmation, privateKey)+"\",\r" +
                  "\n\"metodoconfirmacion\": \""+Auxiliars.AESEncrypt(methodConfirmation, privateKey)+"\",\r" +
                  "\n\"splitpayment\": \"" + Auxiliars.AESEncrypt(splitpayment, privateKey) + "\",\r" +
                  "\n\"split_app_id\": \"" + Auxiliars.AESEncrypt(splitAppId, privateKey) + "\",\r" +
                  "\n\"split_merchant_id\": \"" + Auxiliars.AESEncrypt(splitMerchantId, privateKey) + "\",\r" +
                  "\n\"split_type\": \"" + Auxiliars.AESEncrypt(splitType, privateKey) + "\",\r" +
                  "\n\"split_rule\": \"" + Auxiliars.AESEncrypt(splitRule, privateKey) + "\",\r" +
                  "\n\"split_primary_receiver\": \"" + Auxiliars.AESEncrypt(splitPrimaryReceiver, privateKey) + "\",\r" +
                  "\n\"split_primary_receiver_fee\": \"" + Auxiliars.AESEncrypt(splitPrimaryReceiverFee, privateKey) + "\",\r" +
                  "\n\"split_receivers\": \""+Auxiliars.AESEncrypt(splitReceiversJson, privateKey)+"\",\r" +
                  "\n\"extra1\": \""+Auxiliars.AESEncrypt(extra1, privateKey)+"\",\r" +
                  "\n\"extra2\": \""+Auxiliars.AESEncrypt(extra2, privateKey)+"\",\r" +
                  "\n\"extra3\": \""+Auxiliars.AESEncrypt(extra3, privateKey)+"\",\r" +
                  "\n\"extra4\": \""+Auxiliars.AESEncrypt(extra4, privateKey)+"\",\r" +
                  "\n\"extra5\": \""+Auxiliars.AESEncrypt(extra5, privateKey)+"\",\r" +
                  "\n\"extra6\": \""+Auxiliars.AESEncrypt(extra6, privateKey)+"\",\r" +
                  "\n\"extra7\": \""+Auxiliars.AESEncrypt(extra7, privateKey)+"\",\r" +
                  "\n\"extra8\": \""+Auxiliars.AESEncrypt(extra8, privateKey)+"\",\r" +
                  "\n\"extra9\": \""+Auxiliars.AESEncrypt(extra9, privateKey)+"\",\r" +
                  "\n\"extra10\": \""+Auxiliars.AESEncrypt(extra10, privateKey)+"\",\r" +
                  "\n\"extras_epayco\": {\"extra5\": \"" + Auxiliars.AESEncrypt("P46", privateKey) + "\"},\r" +
                  "\n\"public_key\": \"" +publicKey+"\",\r" +
                  "\n\"enpruebas\": \""+ Auxiliars.AESEncrypt(test.ToString(), privateKey) +"\",\r" +
                  "\n\"ip\": \""+ Auxiliars.AESEncrypt(localIp, privateKey) +"\",\r" +
                  "\n\"i\": \""+I+"\",\r" +
                  "\n\"lenguaje\": \""+".net"+"\"\r\n}";
        }
 
        public string GetBodySplitPayments(SplitModel? splitDetails,bool cash = false)
        {
            SplitModelRest split = new SplitModelRest
            {
                splitpayment = splitDetails?.splitpayment,
                split_app_id = splitDetails?.split_app_id,
                split_merchant_id = splitDetails?.split_merchant_id,
                split_primary_receiver = splitDetails?.split_primary_receiver,
                split_primary_receiver_fee = splitDetails?.split_primary_receiver_fee,
                split_rule = splitDetails?.split_rule,
                split_type = splitDetails?.split_type
            };

            if (cash)
            {
                split.split_receivers = Newtonsoft.Json.JsonConvert.SerializeObject(splitDetails?.split_receivers);
            }
            else
            {
                split.split_receivers = splitDetails?.split_receivers;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(split);
         }

         public string GetQueryGetTransaction(string publicKey, string transactionId)
         {
             return Constants.UrlGetTransaction + "?transactionID=" + transactionId + "&public_key=" + publicKey ;
         }

         public string GetQueryGetBanks(string publicKey, bool test)
         {
             string pruebas = "2";
             if (test)
             {
                 pruebas = "1";
             }
             return Constants.UrlGetBanks + "?public_key=" + publicKey + "&test=" + pruebas;
         }

         /*
          * CASH
          */
        
         public string GetBodyCashCreate(
            string I,
            bool test,
            string publicKey,
            string privateKey,
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
            string cellPhone,
            string endDate,
            string country,
            string city,
            string urlResponse,
            string urlConfirmation,
            string methodConfirmation,
            string extra1,
            string extra2,
            string extra3,
            string extra4,
            string extra5,
            string extra6,
            string extra7,
            string extra8,
            string extra9,
            string extra10,
            string? extras_epayco)
        {
            var localIp = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            localIp = host.AddressList.First(i => i.AddressFamily.ToString() == "InterNetwork").ToString();
            return "{\r\n\"factura\": \""+invoice+"\",\r" +
                   "\n\"descripcion\": \""+description+"\",\r" +
                   "\n\"valor\": \""+value+"\",\r" +
                   "\n\"iva\": \""+tax+"\",\r" +
                   "\n\"baseiva\": \""+taxBase+"\",\r" +
                   "\n\"ico\": \""+ico+"\",\r" +
                   "\n\"moneda\": \""+currency+"\",\r" +
                   "\n\"tipo_persona\": \""+typePerson+"\",\r" +
                   "\n\"tipo_doc\": \""+docType+"\",\r" +
                   "\n\"documento\": \""+docNumber+"\",\r" +
                   "\n\"nombres\": \""+name+"\",\r" +
                   "\n\"apellidos\": \""+lastName+"\",\r" +
                   "\n\"email\": \""+email+"\",\r" +
                   "\n\"celular\": \""+cellPhone+"\",\r" +
                   "\n\"fechaexpiracion\": \""+endDate+"\",\r" +
                   "\n\"pais\": \""+country+"\",\r" +
                   "\n\"ciudad\": \""+city+"\",\r" +
                   "\n\"url_respuesta\": \"" +urlResponse+"\",\r" +
                   "\n\"url_confirmacion\": \""+urlConfirmation+"\",\r" +
                   "\n\"metodoconfirmacion\": \""+methodConfirmation+"\",\r" +
                   "\n\"extra1\": \""+extra1+"\",\r" +
                   "\n\"extra2\": \""+extra2+"\",\r" +
                   "\n\"extra3\": \""+extra3+"\",\r" +
                   "\n\"extra4\": \""+extra4+"\",\r" +
                   "\n\"extra5\": \""+extra5+"\",\r" +
                   "\n\"extra6\": \""+extra6+"\",\r" +
                   "\n\"extra7\": \""+extra7+"\",\r" +
                   "\n\"extra8\": \""+extra8+"\",\r" +
                   "\n\"extra9\": \""+extra9+"\",\r" +
                   "\n\"extra10\": \""+extra10+"\",\r" +
                   "\n\"extras_epayco\": {\"extra5\": \"" + "P46" + "\"},\r" +
                   "\n\"public_key\": \"" +publicKey+"\",\r" +
                   "\n\"enpruebas\": \""+test+"\",\r" +
                   "\n\"ip\": \""+localIp+"\",\r" +
                   "\n\"i\": \""+I+"\",\r" +
                   "\n\"lenguaje\": \""+".net"+"\"\r\n}";
        }
         
         public string GetQueryCashTransaction(string refPayco, string publicKey)
         {
             return Constants.UrlCashTransaction + "ref_payco=" + refPayco + "&public_key=" + publicKey;
         }
         
         /*
          * PAYMENT
          */
         public string GetBodyChargeCreate(
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
             string extra1,
             string extra2,
             string extra3,
             string extra4,
             string extra5,
             string extra6,
             string extra7,
             string extra8,
             string extra9,
             string extra10,
             string? extras_epayco
             )
         {
             return "{\r\n\"token_card\": \"" + tokenCard+"\",\r" +
                    "\n\"customer_id\": \""+customerId+"\",\r" +
                    "\n\"doc_type\": \""+docType+"\",\r" +
                    "\n\"doc_number\": \""+docNumber+"\",\r" +
                    "\n\"name\": \""+name+"\",\r" +
                    "\n\"last_name\": \""+lastName+"\",\r" +
                    "\n\"email\": \""+email+"\",\r" +
                    "\n\"bill\": \""+bill+"\",\r" +
                    "\n\"description\": \""+description+"\",\r" +
                    "\n\"value\": \""+value+"\",\r" +
                    "\n\"tax\": \""+tax+"\",\r" +
                    "\n\"tax_base\": \""+taxBase+"\",\r" +
                    "\n\"ico\": \""+ico+"\",\r" +
                    "\n\"currency\": \""+currency+"\",\r" +
                    "\n\"dues\": \""+dues+"\",\r" +
                    "\n\"address\": \""+address+"\",\r" +
                    "\n\"country\": \""+country+"\",\r" +
                    "\n\"city\": \""+city+"\",\r" +
                    "\n\"phone\": \"" +phone+"\",\r" +
                    "\n\"cell_phone\": \""+cellPhone+"\",\r" +
                    "\n\"url_response\": \""+urlResponse+"\",\r" +
                    "\n\"url_confirmation\": \""+urlConfirmation+"\",\r" +
                    "\n\"method_confirmation\": \"" + methodConfirmation + "\",\r" +
                    "\n\"extras\": {\r" +
                    "\n\"extra1\": \""+extra1+"\",\r" +
                    "\n\"extra2\": \""+extra2+"\",\r" +
                    "\n\"extra3\": \""+extra3+"\",\r" +
                    "\n\"extra4\": \""+extra4+"\",\r" +
                    "\n\"extra5\": \""+extra5+"\",\r" +
                    "\n\"extra6\": \""+extra6+"\",\r" +
                    "\n\"extra7\": \""+extra7+"\",\r" +
                    "\n\"extra8\": \""+extra8+"\",\r" +
                    "\n\"extra9\": \""+extra9+"\",\r" +
                    "\n\"extra10\": \""+extra10+"\"\r },\r" +
                   "\n\"extras_epayco\": {\"extra5\": \"P46\"},\r" +
                    "\n\"ip\": \"" + ip+"\"\r\n}";
         }

        public string GetBodyDaviplata(
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
            decimal tax,
            decimal taxBase,
            decimal ico,
            string test,
            string urlResponse,
            string urlConfirmation,
            string methodConfirmation,
            string extra1,
            string extra2,
            string extra3,
            string extra4,
            string extra5,
            string extra6,
            string extra7,
            string extra8,
            string extra9,
            string extra10,
            string extras_epayco
            )
        {
          var body  = "{\r\n\"docType\": \"" + docType + "\",\r" +
                    "\n\"document\": \"" + document + "\",\r" +
                    "\n\"lastName\": \"" + lastName + "\",\r" +
                    "\n\"name\": \"" + name + "\",\r" +
                    "\n\"last_name\": \"" + lastName + "\",\r" +
                    "\n\"email\": \"" + email + "\",\r" +
                    "\n\"indCountry\": \"" + indCountry + "\",\r" +
                    "\n\"phone\": \"" + phone + "\",\r" +
                    "\n\"country\": \"" + country + "\",\r" +
                    "\n\"city\": \"" + city + "\",\r" +
                    "\n\"address\": \"" + address + "\",\r" +
                    "\n\"ip\": \"" + ip + "\",\r" +
                    "\n\"currency\": \"" + currency + "\",\r" +
                    "\n\"invoice\": \"" + invoice + "\",\r" +
                    "\n\"description\": \"" + description + "\",\r" +
                    "\n\"value\": \"" + value + "\",\r" +
                    "\n\"tax\": \"" + tax + "\",\r" +
                    "\n\"taxBase\": \"" + taxBase + "\",\r" +
                    "\n\"ico\": \"" + ico + "\",\r" +
                    "\n\"testMode\": " + test + ",\r" +
                    "\n\"urlResponse\": \"" + urlResponse + "\",\r" +
                    "\n\"urlConfirmation\": \"" + urlConfirmation + "\",\r" +
                    "\n\"methodConfirmation\": \"" + methodConfirmation + "\",\r" +
                    "\n\"extras\": {\r" +
                    "\n\"extra1\": \"" + extra1 + "\",\r" +
                    "\n\"extra2\": \"" + extra2 + "\",\r" +
                    "\n\"extra3\": \"" + extra3 + "\",\r" +
                    "\n\"extra4\": \"" + extra4 + "\",\r" +
                    "\n\"extra5\": \"" + extra5 + "\",\r" +
                    "\n\"extra6\": \"" + extra6 + "\",\r" +
                    "\n\"extra7\": \"" + extra7 + "\",\r" +
                    "\n\"extra8\": \"" + extra8 + "\",\r" +
                    "\n\"extra9\": \"" + extra9 + "\",\r" +
                    "\n\"extra10\": \"" + extra10 + "\"\r },\r" +
                    "\n\"extras_epayco\": {\"extra5\": \"" + "P46" + "\"},\r" +
                    "\n\"typeIntegration\": \"" + ".NET" + "\"\r\n}";
            return body;
        }

           



        public string GetBodyConfirmDaviplata(
            string refPayco,
            string idSessionToken,
            string otp)
        {
            bodyConfirmDaviplata body = new bodyConfirmDaviplata
            {
                refPayco = refPayco,
                idSessionToken = idSessionToken,
                otp = otp,
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(body);

        }

        public string GetBodySafetypayCreate(
            string cash,
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
            decimal tax,
            decimal taxBase,
            decimal ico,
            string test,
            string urlResponse,
            string urlResponsePointer,
            string urlConfirmation,
            string methodConfirmation,
            string extra1,
            string extra2,
            string extra3,
            string extra4,
            string extra5,
            string extra6,
            string extra7,
            string extra8,
            string extra9,
            string extra10,
            string extras_epayco
            )

        {
            var body = "{\r\n\"cash\": \"" + cash + "\",\r" +
                    "\n\"expirationDate\": \"" + endDate + "\",\r" +
                    "\n\"docType\": \"" + docType + "\",\r" +
                    "\n\"document\": \"" + document + "\",\r" +
                    "\n\"name\": \"" + name + "\",\r" +
                    "\n\"lastName\": \"" + lastName + "\",\r" +
                    "\n\"email\": \"" + email + "\",\r" +
                    "\n\"indCountry\": \"" + indCountry + "\",\r" +
                    "\n\"phone\": \"" + phone + "\",\r" +
                    "\n\"country\": \"" + country + "\",\r" +
                    "\n\"city\": \"" + city + "\",\r" +
                    "\n\"address\": \"" + address + "\",\r" +
                    "\n\"ip\": \"" + ip + "\",\r" +
                    "\n\"currency\": \"" + currency + "\",\r" +
                    "\n\"invoice\": \"" + invoice + "\",\r" +
                    "\n\"description\": \"" + description + "\",\r" +
                    "\n\"value\": \"" + value + "\",\r" +
                    "\n\"tax\": \"" + tax + "\",\r" +
                    "\n\"taxBase\": \"" + taxBase + "\",\r" +
                    "\n\"ico\": \"" + ico + "\",\r" +
                    "\n\"testMode\": " + test + ",\r" +
                    "\n\"urlResponse\": \"" + urlResponse + "\",\r" +
                    "\n\"urlResponsePointer\": \"" + urlResponsePointer + "\",\r" +
                    "\n\"urlConfirmation\": \"" + urlConfirmation + "\",\r" +
                    "\n\"methodConfirmation\": \"" + methodConfirmation + "\",\r" +
                    "\n\"extras\": {\r" +
                    "\n\"extra1\": \"" + extra1 + "\",\r" +
                    "\n\"extra2\": \"" + extra2 + "\",\r" +
                    "\n\"extra3\": \"" + extra3 + "\",\r" +
                    "\n\"extra4\": \"" + extra4 + "\",\r" +
                    "\n\"extra5\": \"" + extra5 + "\",\r" +
                    "\n\"extra6\": \"" + extra6 + "\",\r" +
                    "\n\"extra7\": \"" + extra7 + "\",\r" +
                    "\n\"extra8\": \"" + extra8 + "\",\r" +
                    "\n\"extra9\": \"" + extra9 + "\",\r" +
                    "\n\"extra10\": \"" + extra10 + "\"\r },\r" +
                    "\n\"extras_epayco\": {\"extra5\": \"" + "P46" + "\"},\r" +
                    "\n\"typeIntegration\": \"" + ".NET" + "\"\r\n}";
            return body;
        }
        #endregion
    }
}
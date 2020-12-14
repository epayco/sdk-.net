using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using EpaycoSdk.Models.Bank;

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

        public string getBodyAuthBearer(string publicKey, string privateKey)
        {
            return "{\n\"public_key\":\"" + publicKey + "\"," +
                   "\n\"private_key\":\"" + privateKey + "\"\n}";
        }
        public string getBodyCreateToken(string cardNumber, string expYear, string expMonth, string cvc)
        {
            return "{\n\"card[number]\":\"" + cardNumber + "\"," +
                   "\n\"card[exp_year]\":\"" + expYear + "\"," +
                   "\n\"card[exp_month]\":\"" + expMonth + "\"," +
                   "\n\"card[cvc]\":\"" + cvc + "\"\n}";
        }

        public string getBodyCreateCustomer(
            string token_card, 
            string name, 
            string last_name, 
            string email, 
            bool isDefault,
            string city,
            string address,
            string phone,
            string cell_phone)
        {
            return
                "{\n\"token_card\":\"" + token_card + "\"," +
                "\n\"name\":\"" + name + "\"," +
                "\n\"last_name\":\"" + last_name + "\"," +
                "\n\"email\":\"" + email + "\"," +
                "\n\"default\":\"" + isDefault + "\"," +
                "\n\"city\":\"" + city + "\"," +
                "\n\"address\":\"" + address + "\"," +
                "\n\"phone\":\"" + phone + "\"," +
                "\n\"cell_phone\":\"" + cell_phone + "\"\n}";
               
        }

        public string getQueryFindCustomer(string publicKey, string id_customer)
        {
            return Constants.url_base + Constants.url_find_customer  + publicKey + "/" + id_customer;
        }
        
        public string getQueryFindAllCustomers(string publicKey)
        {
            return Constants.url_base + Constants.url_find_all_customer  + publicKey;
        }
        
        public string getQueryUpdateCustomer(string publicKey, string customer_id)
        {
            return Constants.url_base + Constants.url_update_customer  + publicKey + "/" + customer_id;
        }
        
        public string getBodyUpdateCustomer(string name)
        {
            return "{\r\n\"name\":\""+name+"\"\r\n}";
        }
        
        public string getBodyDeleteTokenCustomer(string franchise, string mask, string customer_id)
        {
            return "{\n\"franchise\":\"" + franchise + "\"," +
                   "\n\"mask\":\"" + mask + "\"," +
                   "\n\"customer_id\":\"" + customer_id + "\"\n}";
        }
        
        /*
         * PLANS QUERYS AND BODY
         */
        public string getBodyCreatePlan(string id_plan, string name, string description, decimal amount, string currency, string interval, int interval_count, int trial_days)
        {
            return "{\r\n\"id_plan\":\""+id_plan+"\",\r" +
                   "\n\"name\":\""+name+"\",\r" +
                   "\n\"description\":\""+description+"\",\r" +
                   "\n\"amount\": "+amount+",\r" +
                   "\n\"currency\": \""+currency+"\",\r" +
                   "\n\"interval\": \""+interval+"\",\r" +
                   "\n\"interval_count\": "+interval_count+",\r" +
                   "\n\"trial_days\":"+trial_days+"\r\n}";
        }
        
        public string getQueryGetPlan(string id_plan, string publicKey)
        {
            return Constants.url_base + Constants.url_get_plan  + publicKey + "/" + id_plan;
        }
        
        public string getQueryGetAllPlans(string publicKey)
        {
            return Constants.url_base + Constants.url_get_all_plans  + publicKey;
        }
        
        public string getQueryRemovePlan(string publicKey, string id_plan)
        {
            return Constants.url_base + Constants.url_remove_plan  + publicKey + "/" + id_plan;
        }
        
        /*
         * SUBSCRIPTIONS
         */
        public string getBodyCreateSubscription(string id_plan, string customer_id, string token_card, string doc_type,
            string doc_number, string url_confirmation = null, string method_confirmation = null)
        {
            string body = "";
            if (url_confirmation != null && method_confirmation != null)
            {
                body = "{\r\n\"id_plan\": \""+id_plan+"\",\r" +
                       "\n\"customer\": \""+customer_id+"\",\r" +
                       "\n\"token_card\": \""+token_card+"\",\r" +
                       "\n\"doc_type\": \""+doc_type+"\",\r" +
                       "\n\"url_confirmation\": \""+url_confirmation+"\",\r" +
                       "\n\"method_confirmation\": \""+method_confirmation+"\",\r" +
                       "\n\"doc_number\": \""+doc_number+"\"\r\n}";
            }
            else
            {
                body = "{\r\n\"id_plan\": \""+id_plan+"\",\r" +
                       "\n\"customer\": \""+customer_id+"\",\r" +
                       "\n\"token_card\": \""+token_card+"\",\r" +
                       "\n\"doc_type\": \""+doc_type+"\",\r" +
                       "\n\"doc_number\": \""+doc_number+"\"\r\n}";
            }

            return body;
        }
        public string getQueryFindSubscription(string publicKey, string id)
        {
            return Constants.url_base + Constants.url_get_subscription  +  id + "/" + publicKey;
        }
        
        public string getQueryFindAllSubscription(string publicKey)
        {
            return Constants.url_base + Constants.url_get_all_subscriptions + publicKey;
        }
        
        public string getBodyCancelSubscription(string subscriptionId)
        {
            return "{\r\n\"id\":\""+subscriptionId+"\"\r\n}";
        }
        
        public string getBodyChargeSubscription(string id_plan, 
            string customer_id, 
            string token_card,
            string doc_type,
            string doc_number,
            string ip,
            string address = null,
            string phone = null,
            string cell_phone = null)
        {
            return "{\r\n\"id_plan\": \""+id_plan+"\",\r" +
                  "\n\"customer\": \""+customer_id+"\",\r" +
                  "\n\"token_card\": \""+token_card+"\",\r" +
                  "\n\"doc_type\": \""+doc_type+"\",\r" +
                  "\n\"ip\": \""+ip+"\",\r" +
                  "\n\"address\": \""+address+"\",\r" +
                  "\n\"phone\": \""+phone+"\",\r" +
                  "\n\"cell_phone\": \""+cell_phone+"\",\r" +
                  "\n\"doc_number\": \""+doc_number+"\"\r\n}";
        }
        
        /*
         * PSE
         */
        public string getBodyBankCreate(
            string I,
            bool test,
            string public_key,
            string private_key,
            string bank, 
            string invoice, 
            string description,
            string value,
            string tax,
            string tax_base,
            string currency,
            string type_person,
            string doc_type,
            string doc_number,
            string name,
            string last_name,
            string email,
            string country,
            string cell_phone,
            string url_response,
            string url_confirmation,
            string method_confirmation,
            string extra1 = "",
            string extra2 = "",
            string extra3 = "",
            string extra4 = "",
            string extra5 = "",
            string extra6 = "",
            string extra7 = "")
        {
            var localIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            localIP = host.AddressList.First(i => i.AddressFamily.ToString() == "InterNetwork").ToString();
            return "{\r\n\"banco\": \""+Auxiliars.AESEncrypt(bank, private_key)+"\",\r" +
                   "\n\"factura\": \""+Auxiliars.AESEncrypt(invoice, private_key)+"\",\r" +
                   "\n\"descripcion\": \""+Auxiliars.AESEncrypt(description, private_key)+"\",\r" +
                   "\n\"valor\": \""+Auxiliars.AESEncrypt(value, private_key)+"\",\r" +
                   "\n\"iva\": \""+Auxiliars.AESEncrypt(tax, private_key)+"\",\r" +
                   "\n\"baseiva\": \""+Auxiliars.AESEncrypt(tax_base, private_key)+"\",\r" +
                   "\n\"moneda\": \""+Auxiliars.AESEncrypt(currency, private_key)+"\",\r" +
                   "\n\"tipo_persona\": \""+Auxiliars.AESEncrypt(type_person, private_key)+"\",\r" +
                   "\n\"tipo_doc\": \""+Auxiliars.AESEncrypt(doc_type, private_key)+"\",\r" +
                   "\n\"documento\": \""+Auxiliars.AESEncrypt(doc_number, private_key)+"\",\r" +
                   "\n\"nombres\": \""+Auxiliars.AESEncrypt(name, private_key)+"\",\r" +
                   "\n\"apellidos\": \""+Auxiliars.AESEncrypt(last_name, private_key)+"\",\r" +
                   "\n\"email\": \""+Auxiliars.AESEncrypt(email, private_key)+"\",\r" +
                   "\n\"pais\": \""+Auxiliars.AESEncrypt(country, private_key)+"\",\r" +
                   "\n\"celular\": \""+Auxiliars.AESEncrypt(cell_phone, private_key)+"\",\r" +
                   "\n\"url_respuesta\": \""+Auxiliars.AESEncrypt(url_response, private_key)+"\",\r" +
                   "\n\"url_confirmacion\": \""+Auxiliars.AESEncrypt(url_confirmation, private_key)+"\",\r" +
                   "\n\"metodoconfirmacion\": \""+Auxiliars.AESEncrypt(method_confirmation, private_key)+"\",\r" +
                   "\n\"extra1\": \""+Auxiliars.AESEncrypt(extra1, private_key)+"\",\r" +
                   "\n\"extra2\": \""+Auxiliars.AESEncrypt(extra2, private_key)+"\",\r" +
                   "\n\"extra3\": \""+Auxiliars.AESEncrypt(extra3, private_key)+"\",\r" +
                   "\n\"extra4\": \""+Auxiliars.AESEncrypt(extra4, private_key)+"\",\r" +
                   "\n\"extra5\": \""+Auxiliars.AESEncrypt(extra5, private_key)+"\",\r" +
                   "\n\"extra6\": \""+Auxiliars.AESEncrypt(extra6, private_key)+"\",\r" +
                   "\n\"extra7\": \""+Auxiliars.AESEncrypt(extra7, private_key)+"\",\r" +
                   "\n\"public_key\": \""+public_key+"\",\r" +
                   "\n\"enpruebas\": \""+Auxiliars.AESEncrypt(test.ToString(), private_key)+"\",\r" +
                   "\n\"ip\": \""+Auxiliars.AESEncrypt(localIP, private_key)+"\",\r" +
                   "\n\"i\": \""+I+"\",\r" +
                   "\n\"lenguaje\": \""+".net"+"\"\r\n}";
        }
        
        public string getBodyBankCreateSplit(
           string I,
           bool test,
           string public_key,
           string private_key,
           string bank,
           string invoice,
           string description,
           string value,
           string tax,
           string tax_base,
           string currency,
           string type_person,
           string doc_type,
           string doc_number,
           string name,
           string last_name,
           string email,
           string country,
           string cell_phone,
           string url_response,
           string url_confirmation,
           string method_confirmation,
           string splitpayment,
           string split_app_id,
           string split_merchant_id,
           string split_type,
           string split_primary_receiver,
           string split_primary_receiver_fee,
           List<SplitReceivers> split_receivers,
           string extra1 = "",
           string extra2 = "",
           string extra3 = "",
           string extra4 = "",
           string extra5 = "",
           string extra6 = "",
           string extra7 = "")
        {
           var localIP = "";
           IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
           localIP = host.AddressList.First(i => i.AddressFamily.ToString() == "InterNetwork").ToString();
           string split_data = "";
           int count = 0;
           foreach (var split in split_receivers)
           {
               if (count == 0)
               {
                   split_data += "[{" + split.id + "," + split.fee + "," + split.fee_type + "";
               }
               else
               {
                   split_data += ",{" + split.id + "," + split.fee + "," + split.fee_type + "";
               }

               if (count == split_receivers.Count - 1)
               {
                   split_data += "}]";
               }
               else
               {
                   split_data += "}";
               }
               count++;
              
           }
           return "{\r\n\"banco\": \""+Auxiliars.AESEncrypt(bank, private_key)+"\",\r" +
                  "\n\"factura\": \""+Auxiliars.AESEncrypt(invoice, private_key)+"\",\r" +
                  "\n\"descripcion\": \""+Auxiliars.AESEncrypt(description, private_key)+"\",\r" +
                  "\n\"valor\": \""+Auxiliars.AESEncrypt(value, private_key)+"\",\r" +
                  "\n\"iva\": \""+Auxiliars.AESEncrypt(tax, private_key)+"\",\r" +
                  "\n\"baseiva\": \""+Auxiliars.AESEncrypt(tax_base, private_key)+"\",\r" +
                  "\n\"moneda\": \""+Auxiliars.AESEncrypt(currency, private_key)+"\",\r" +
                  "\n\"tipo_persona\": \""+Auxiliars.AESEncrypt(type_person, private_key)+"\",\r" +
                  "\n\"tipo_doc\": \""+Auxiliars.AESEncrypt(doc_type, private_key)+"\",\r" +
                  "\n\"documento\": \""+Auxiliars.AESEncrypt(doc_number, private_key)+"\",\r" +
                  "\n\"nombres\": \""+Auxiliars.AESEncrypt(name, private_key)+"\",\r" +
                  "\n\"apellidos\": \""+Auxiliars.AESEncrypt(last_name, private_key)+"\",\r" +
                  "\n\"email\": \""+Auxiliars.AESEncrypt(email, private_key)+"\",\r" +
                  "\n\"pais\": \""+Auxiliars.AESEncrypt(country, private_key)+"\",\r" +
                  "\n\"celular\": \""+Auxiliars.AESEncrypt(cell_phone, private_key)+"\",\r" +
                  "\n\"url_respuesta\": \""+Auxiliars.AESEncrypt(url_response, private_key)+"\",\r" +
                  "\n\"url_confirmacion\": \""+Auxiliars.AESEncrypt(url_confirmation, private_key)+"\",\r" +
                  "\n\"metodoconfirmacion\": \""+Auxiliars.AESEncrypt(method_confirmation, private_key)+"\",\r" +
                  "\n\"splitpayment\": \"" + Auxiliars.AESEncrypt(splitpayment, private_key) + "\",\r" +
                  "\n\"split_app_id\": \"" + Auxiliars.AESEncrypt(split_app_id, private_key) + "\",\r" +
                  "\n\"split_merchant_id\": \"" + Auxiliars.AESEncrypt(split_merchant_id, private_key) + "\",\r" +
                  "\n\"split_type\": \"" + Auxiliars.AESEncrypt(split_type, private_key) + "\",\r" +
                  "\n\"split_primary_receiver\": \"" + Auxiliars.AESEncrypt(split_primary_receiver, private_key) + "\",\r" +
                  "\n\"split_primary_receiver_fee\": \"" + Auxiliars.AESEncrypt(split_primary_receiver_fee, private_key) + "\",\r" +
                  "\n\"split_receivers\": \""+Auxiliars.AESEncrypt(split_data, private_key)+"\",\r" +
                  "\n\"extra1\": \""+Auxiliars.AESEncrypt(extra1, private_key)+"\",\r" +
                  "\n\"extra2\": \""+Auxiliars.AESEncrypt(extra2, private_key)+"\",\r" +
                  "\n\"extra3\": \""+Auxiliars.AESEncrypt(extra3, private_key)+"\",\r" +
                  "\n\"extra4\": \""+Auxiliars.AESEncrypt(extra4, private_key)+"\",\r" +
                  "\n\"extra5\": \""+Auxiliars.AESEncrypt(extra5, private_key)+"\",\r" +
                  "\n\"extra6\": \""+Auxiliars.AESEncrypt(extra6, private_key)+"\",\r" +
                  "\n\"extra7\": \""+Auxiliars.AESEncrypt(extra7, private_key)+"\",\r" +
                  "\n\"public_key\": \""+public_key+"\",\r" +
                  "\n\"enpruebas\": \""+test+"\",\r" +
                  "\n\"ip\": \""+localIP+"\",\r" +
                  "\n\"i\": \""+I+"\",\r" +
                  "\n\"lenguaje\": \""+".net"+"\"\r\n}";
        }
 
        
        
        public string getQueryGetTransaction(string publicKey, string transactionId)
        {
            return Constants.url_get_transaction + "?transactionID=" + transactionId + "&public_key=" + publicKey ;
        }
        
        public string getQueryGetBanks(string publicKey)
        {
            return Constants.url_get_banks + "?public_key=" + publicKey ;
        }
        
        /*
         * CASH
         */
        public string getQueryCash(string type)
        {
            var endpoint = "";
            switch (type)
            {
                case "efecty":
                    endpoint = Constants.url_cash_efecty;
                    break;
                case "baloto":
                    endpoint = Constants.url_cash_baloto;
                    break;
                case "gana":
                    endpoint = Constants.url_cash_gana;
                    break;
                case "redservi":
                    endpoint = Constants.url_cash_redservi;
                    break;
                case "puntored":
                    endpoint = Constants.url_cash_puntored;
                    break;
                default:
                    return "";
            }
            return endpoint;
        }
        
         public string getBodyCashCreate(
            string I,
            bool test,
            string public_key,
            string private_key,
            string invoice, 
            string description,
            string value,
            string tax,
            string tax_base,
            string currency,
            string type_person,
            string doc_type,
            string doc_number,
            string name,
            string last_name,
            string email,
            string cell_phone,
            string end_date,
            string url_response,
            string url_confirmation,
            string method_confirmation)
        {
            var localIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            localIP = host.AddressList.First(i => i.AddressFamily.ToString() == "InterNetwork").ToString();
            return "{\r\n\"factura\": \""+invoice+"\",\r" +
                   "\n\"descripcion\": \""+description+"\",\r" +
                   "\n\"valor\": \""+value+"\",\r" +
                   "\n\"iva\": \""+tax+"\",\r" +
                   "\n\"baseiva\": \""+tax_base+"\",\r" +
                   "\n\"moneda\": \""+currency+"\",\r" +
                   "\n\"tipo_persona\": \""+type_person+"\",\r" +
                   "\n\"tipo_doc\": \""+doc_type+"\",\r" +
                   "\n\"documento\": \""+doc_number+"\",\r" +
                   "\n\"nombres\": \""+name+"\",\r" +
                   "\n\"apellidos\": \""+last_name+"\",\r" +
                   "\n\"email\": \""+email+"\",\r" +
                   "\n\"celular\": \""+cell_phone+"\",\r" +
                   "\n\"fechaexpiracion\": \""+end_date+"\",\r" +
                   "\n\"url_respuesta\": \""+url_response+"\",\r" +
                   "\n\"url_confirmacion\": \""+url_confirmation+"\",\r" +
                   "\n\"metodoconfirmacion\": \""+method_confirmation+"\",\r" +
                   "\n\"public_key\": \""+public_key+"\",\r" +
                   "\n\"enpruebas\": \""+test+"\",\r" +
                   "\n\"ip\": \""+localIP+"\",\r" +
                   "\n\"i\": \""+I+"\",\r" +
                   "\n\"lenguaje\": \""+".net"+"\"\r\n}";
        }
         
         public string getQueryCashTransaction(string ref_payco, string publicKey)
         {
             return Constants.base_url_secure + Constants.url_cash_transaction + "ref_payco=" + ref_payco + "&public_key=" + publicKey;
         }
         
         /*
          * PAYMENT
          */
         public string getBodyChargeCreate(
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
             string currency,
             string dues,
             string address,
             string phone,
             string cell_phone,
             string url_response,
             string url_confirmation,
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
             string extra10)
         {
             return "{\r\n\"token_card\": \""+token_card+"\",\r" +
                    "\n\"customer_id\": \""+customer_id+"\",\r" +
                    "\n\"doc_type\": \""+doc_type+"\",\r" +
                    "\n\"doc_number\": \""+doc_number+"\",\r" +
                    "\n\"name\": \""+name+"\",\r" +
                    "\n\"last_name\": \""+last_name+"\",\r" +
                    "\n\"email\": \""+email+"\",\r" +
                    "\n\"bill\": \""+bill+"\",\r" +
                    "\n\"description\": \""+description+"\",\r" +
                    "\n\"value\": \""+value+"\",\r" +
                    "\n\"tax\": \""+tax+"\",\r" +
                    "\n\"tax_base\": \""+tax_base+"\",\r" +
                    "\n\"currency\": \""+currency+"\",\r" +
                    "\n\"dues\": \""+dues+"\",\r" +
                    "\n\"address\": \""+address+"\",\r" +
                    "\n\"phone\": \""+phone+"\",\r" +
                    "\n\"cell_phone\": \""+cell_phone+"\",\r" +
                    "\n\"url_response\": \""+url_response+"\",\r" +
                    "\n\"url_confirmation\": \""+url_confirmation+"\",\r" +
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
                    "\n\"ip\": \""+ip+"\"\r\n}";
         }
        #endregion
    }
}
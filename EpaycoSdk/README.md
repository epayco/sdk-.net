# EPAYCO SDK .NET
## Requisitos
Para el uso del sdk es necesario instalar las siguientes librerias:
* Microsoft.CSharp
* Newtonsoft.Json

## Inicialización del SDK
Es recomendable inicilizar el SDK en el controlador o clase principal donde se desean implementar los métodos.
```
Epayco epayco = new EpaycoSdk.Epayco(
  "public_key", //String
  "private_key", //String
  "languaje", //String
  test //Boolean 
); 
```
## METODOS DISPONIBLES
### Create Token (Tokenizar un medio de pago)
Ejemplo de la petición:
```
TokenModel token = epayco.CreateToken(
  "4575623182290326", //cardNumber
  "2019", //expYear
  "12", //expMonth
  "123" //cvc
);
```

### CUSTOMER
### Create Customer 
Ejemplo de la petición:
```
CustomerCreateModel customer = epayco.CustomerCreate(
      "token_card", //string
      "name", //string
      "last_name", //string
      "email", //string 
      is_default, //boolean
      "city", //string 
      "address", //string
      "phone", //string
      "cell_phone" //string
);
```
### Get Customer 
Ejemplo de la petición:
```
 CustomerFindModel customer = epayco.FindCustomer("customer_id");
```
### Update Customer 
Ejemplo de la petición:
```
 CustomerEditModel customer = epayco.CustomerUpdate("customer_id", "name");
```
### Customer Token Remove
Ejemplo de la petición:
```
 CustomerTokenDeleteModel customer = epayco.CustomerDeleteToken(
    "franchise", 
    "mask", 
    "customer_id"
);
```
### Customer List
Ejemplo de la petición:
```
 CustomerListModel customer = epayco.CustomerGetList();
```
### PLANS
### Plan Create 
Ejemplo de la petición:
```
CreatePlanModel plan = epayco.PlanCreate(
    "id_plan", //string
    "name", //string
    "description", //string
    amount, //decimal
    "currency", /string ej: COP
    "interval", /string
    interval_count, //int
    trial_days // int
);
```
### Get Plan
Ejemplo de la petición:
```
FindPlanModel plan = epayco.GetPlan("id_plan");
```

### Get All Plans
Ejemplo de la petición:
```
FindAllPlansModel plan = epayco.GetAllPlans();
```

### Plan Remove
Ejemplo de la petición:
```
RemovePlanModel plan = epayco.RemovePlan("id_plan");
```

### SUBSCRIPTIONS
### Create Subscription
Ejemplo de la petición:
```
CreateSubscriptionModel subscription = epayco.SubscriptionCreate(
    "id_plan",
    "customer_id",
    "token_card",
    "doc_type",
    "doc_number",
    "url_confirmation",
    "method_confirmation"
);
```

### Find Subscription
Ejemplo de la petición:
```
FindSusbscriptionModel subscription = epayco.getSubscription("subscription_id");
```

### Find All Subscriptions
Ejemplo de la petición:
```
AllSubscriptionModel subscription = epayco.getAllSubscription();
```

### Cancel Subscription
Ejemplo de la petición:
```
CancelSubscriptionModel subscription = epayco.cancelSubscription("subscription_id");
```

### Pay Subscription
Ejemplo de la petición:
```
ChargeSubscriptionModel subscription = epayco.ChargeSubscription(
    "id_plan",
    "customer_id",
    "token_card",
    "doc_type",
    "doc_number",
    "ip",
    "address",
    "phone",
    "cell_phone"
);
```

### PSE
### Pse Create
Ejemplo de la petición:
```
PseModel response = epayco.BankCreate(
  "bank_code",
  "invoice",
  "description",
  "value",
  "tax",
  "tax_base",
  "ico",
  "currency",
  "type_person",
  "doc_type",
  "doc_number",
  "name",
  "last_name",
  "email",
  "country",
  "city",
  "cell_phone",
  "url_response",
  "url_confirmation",
  "metodoconfirmacion"
);
```

### PSE
### Pse Create SplitPayment
Ejemplo de la petición:
```
List<SplitReceivers> splitReceiverses = new List<SplitReceivers>();
splitReceiverses.Add(new SplitReceivers(){id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100"});
PseModel response = epayco.BankCreateSplit(
  "bank_code",
  "invoice",
  "description",
  "value",
  "tax",
  "tax_base",
  "ico",
  "currency",
  "type_person",
  "doc_type",
  "doc_number",
  "name",
  "last_name",
  "email",
  "country",
  "city"
  "cell_phone",
  "url_response",
  "url_confirmation",
  "metodoconfirmacion"
  "splitpayment", // true or false
  "split_app_id",
  "split_merchant_id",
  "split_type",
  "split_rule",
  "split_primary_receiver",
  "split_primary_receiver_fee",
  splitReceiverses // Este sería un array de tipo SplitReceivers el cual se inicializa al principio del método es un campo opcional y es obligatorio sí se envía split_rule
);
```

### Get Transaction
Ejemplo de la petición:
```
TransactionModel transaction = epayco.GetTransaction("ticketId");
```

### Get Banks
Ejemplo de la petición:
```
BanksModel banks = epayco.GetBanks();
```

### CASH
### Cash Create
Ejemplo de la petición:
```
CashModel response = epayco.CashCreate(
    "type", //efecty, gana, baloto, redservi, puntored, sured
    "invoice",
    "description",
    "value",
    "tax",
    "tax_base",
    "ico",
    "currency",
    "type_person",
    "doc_type",
    "doc_number",
    "name",
    "last_name",
    "email",
    "cell_phone",
    "end_date",
    "country",
    "city",
    "url_response",
    "url_confirmation",
    "metodoconfirmacion");
```
### Get Cash Transaction
Ejemplo de la petición:
```
CashTransactionModel cash = epayco.GetCashTransaction("ref_payco");
```

### Split Payments

Previous requirements: https://docs.epayco.co/tools/split-payment

#### Split 1-1

Ejemplo de la petición:

```
SplitModel splitData = new SplitModel();
splitData.splitpayment = "true";
splitData.split_app_id = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_merchant_id = "P_CUST_ID_CLIENTE COMMERCE";
splitData.split_type = "02";
splitData.split_primary_receiver = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_primary_receiver_fee = "10";
splitData.split_rule = "";
List<EpaycoSdk.Models.Bank.SplitReceivers> splitReceivers = new List<SplitReceivers>();
splitReceivers.Add(new SplitReceivers() { id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100" });
splitData.split_receivers = splitReceivers;
SplitType  splitDataPayment = new SplitType();
splitDataPayment.split_details = splitData;

CashModel response = epayco.CashCreate(
    //Other customary parameters...
    splitDataPayment
);
```

#### Split multiple

use the following attributes in case you need to do a dispersion with multiple providers

Ejemplo de la petición:

```
SplitModel splitData = new SplitModel();
splitData.splitpayment = "true";
splitData.split_app_id = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_merchant_id = "P_CUST_ID_CLIENTE COMMERCE";
splitData.split_type = "02";
splitData.split_primary_receiver = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_primary_receiver_fee = "0";
splitData.split_rule = "multiple"; //si se envía este parámetro el campo splitReceivers se vuelve obligatorio
List<EpaycoSdk.Models.Bank.SplitReceivers> splitReceivers = new List<SplitReceivers>();
splitReceivers.Add(new SplitReceivers() { id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100" });
splitReceivers.Add(new SplitReceivers() { id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100" });
splitData.split_receivers = splitReceivers;
SplitType  splitDataPayment = new SplitType();
splitDataPayment.split_details = splitData;

CashModel response = epayco.CashCreate(
    //Other customary parameters...
    splitDataPayment
);
```

## PAYMENT
### Payment Create
Ejemplo de la petición:
```
ChargeModel response = epayco.ChargeCreate(
    "token_card",
    "customer_id",
    "doc_type",
    "doc_number",
    "name",
    "last_name",
    "email",
    "bill",
    "description",
    "value",
    "tax",
    "tax_base",
    "ico",
    "currency",
    "dues",
    "address",
    "country",
    "city",
    "phone",
    "cell_phone",
    "url_response",
    "url_confirmation",
    "method_confirmation",
    "ip",
    "extra1",
    "extra2",
    "extra3",
    "extra4",
    "extra5",
    "extra6",
    "extra7",
    "extra8",
    "extra9",
    "extra10");
```


### Get Charge Transaction
Ejemplo de la petición:
```
 ChargeTransactionModel cash = epayco.GetChargeTransaction("ref_payco");
```

### Split Payments

Previous requirements: https://docs.epayco.co/tools/split-payment

#### Split 1-1

Ejemplo de la petición:

```
SplitModel splitData = new SplitModel();
splitData.splitpayment = "true";
splitData.split_app_id = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_merchant_id = "P_CUST_ID_CLIENTE COMMERCE";
splitData.split_type = "02";
splitData.split_primary_receiver = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_primary_receiver_fee = "10";
splitData.split_rule = "";
List<EpaycoSdk.Models.Bank.SplitReceivers> splitReceivers = new List<SplitReceivers>();
splitReceivers.Add(new SplitReceivers() { id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100" });
splitData.split_receivers = splitReceivers;
SplitType  splitDataPayment = new SplitType();
splitDataPayment.split_details = splitData;

ChargeModel response = epayco.ChargeCreate(
    //Other customary parameters...
    splitDataPayment
);
```

#### Split multiple

use the following attributes in case you need to do a dispersion with multiple providers

Ejemplo de la petición:

```
SplitModel splitData = new SplitModel();
splitData.splitpayment = "true";
splitData.split_app_id = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_merchant_id = "P_CUST_ID_CLIENTE COMMERCE";
splitData.split_type = "02";
splitData.split_primary_receiver = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_primary_receiver_fee = "0";
splitData.split_rule = "multiple"; // si se envía este parámetro el campo splitReceivers se vuelve obligatorio
List<EpaycoSdk.Models.Bank.SplitReceivers> splitReceivers = new List<SplitReceivers>();
splitReceivers.Add(new SplitReceivers() { id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100" });
splitReceivers.Add(new SplitReceivers() { id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100" });
splitData.split_receivers = splitReceivers;
SplitType  splitDataPayment = new SplitType();
splitDataPayment.split_details = splitData;

ChargeModel response = epayco.ChargeCreate(
    //Other customary parameters...
    splitDataPayment
);
```


### Daviplata

## Create

Crea una transaccion en Daviplata
Ejemplo de la peticion
```
DaviplataModel response = epayco.DaviplataCreate(
    "doc_type",
    "document",
    "name",
    "last_name",
    "email",
    "ind_country",
    "phone",
    "country",
    "city",
    "address",
    "ip",
    "currency",
    "invoice",
    "description",
    "value",
    "tax", 
    "tax_base",
    "ico",
    "test",
    "url_response",
    "url_confirmation",
    "method_confirmation"
)
```

## Confirm
Confirma una transaccion en Daviplata

Ejemplo:
```
DaviplataConfirmModel response = epayco.DaviplataConfirm(
    "ref_payco",
    "id_session_token",
    "otp"
)
```

### Safetypay

## Create
Crea una transaccion en Safetypay

Ejemplo de peticion
```
safetypayModel response = epayco.SafetypayCreate(
    "cash",
    "end_date",
    "doc_type",
    "document",
    "name",
    "last_name",
    "email",
    "ind_country",
    "phone",
    "country",
    "city",
    "address",
    "ip",
    "currency",
    "invoice",
    "description",
    "value",
    "tax",
    "tax_base",
    "ico",
    "test",
    "url_response",
    "url_confirmation",
    "url_response_pointer",
    "method_confirmation"
)
```


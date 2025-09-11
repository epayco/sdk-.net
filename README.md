# EPAYCO SDK .NET
## Requirements
To use the SDK, you need to install the following libraries:
* Microsoft.CSharp
* Newtonsoft.Json
* RestSharp

## Manual Setup
- Download the SDK from the repository
- Add the project reference to your solution. Configure the `<OutputType>Exe</OutputType>` tag in the EpaycoSdk.csproj file.

## Importing the SDK in your code

After installing and referencing the SDK in your project, you must import the necessary namespaces  This is done using the `using` directive at the top of your file. For example:

```csharp
using EpaycoSdk; // Main SDK namespace
using Newtonsoft.Json;
using EpaycoSdk.Models; // For models like TokenModel, 
using EpaycoSdk.Models.Bank; // For bank-related models
using EpaycoSdk.Models.Cash; // For cash-related models
// Add other namespaces as needed for your use case
```

This step is required so you can access all the SDK classes and methods for consuming Epayco services in your application.


## SDK Initialization
It is recommended to initialize the SDK in the controller or main class where you want to implement the methods.
```csharp
Epayco epayco = new EpaycoSdk.Epayco(
    "public_key",  
    "private_key", 
    "language", // Language
    test // (true/false)
); 
```
## AVAILABLE METHODS

### Create Token (Tokenize a payment method)
Example request:
```csharp
TokenModel token = epayco.CreateToken(
        "4575623182290326", // Card number
        "2025", // Expiry year 
        "12",   // Expiry month
        "123"   // CVC
);
string tokenResponse = JsonConvert.SerializeObject(token, Formatting.Indented);
Console.WriteLine(tokenResponse);
```

### CUSTOMER

#### Create Customer 
Example request:
```csharp
CustomerCreateModel customer = epayco.CustomerCreate(
        "token.id", // Token ID
        "Juan", // First name 
        "Garcia", // Last name
        "juanes99@gmail.com", // Email 
        true, // Boolean (Indicates if the customer is active or inactive)
        "medellin", // City
        "calle 45", // Address
        "4345689", // Phone
        "3003602025" // Mobile
);

string customerResponse = JsonConvert.SerializeObject(customer, Formatting.Indented);
Console.WriteLine(customerResponse);
```
#### Get Customer 
Example request:
```csharp
CustomerFindModel customer = epayco.FindCustomer("customer_id");
string customerResponse = JsonConvert.SerializeObject(customer, Formatting.Indented);
Console.WriteLine(customerResponse);
```
#### Update Customer 
Example request:
```csharp
CustomerEditModel customer = epayco.CustomerUpdate("customer_id", "name");
string customerResponse = JsonConvert.SerializeObject(customer, Formatting.Indented);
Console.WriteLine(customerResponse);
```
#### Customer Token Remove
Example request:
```csharp
CustomerTokenDeleteModel customer = epayco.CustomerDeleteToken(
        "franchise", 
        "mask", 
        "customer_id"
);
string customerResponse = JsonConvert.SerializeObject(customer, Formatting.Indented);
Console.WriteLine(customerResponse);
```
#### Customer List
Example request:
```csharp
CustomerListModel customer = epayco.CustomerGetList();
string customerResponse = JsonConvert.SerializeObject(customer, Formatting.Indented);
Console.WriteLine(customerResponse);
```
### PLANS

#### Plan Create 
Example request:
```csharp
CreatePlanModel plan = epayco.PlanCreate(
        "plan_id_", // Plan ID
        "name", // Plan name
        "description", // Plan description
        10000, // Plan value
        "COP", // Currency
        "month", // Plan period
        30, // Plan days
        1 // Number of cycles
);
string planResponse = JsonConvert.SerializeObject(plan, Formatting.Indented);
Console.WriteLine(planResponse);
```
#### Get Plan
Example request:
```csharp
FindPlanModel plan = epayco.GetPlan("id_plan");
string planResponse = JsonConvert.SerializeObject(plan, Formatting.Indented);
Console.WriteLine(planResponse);
```

#### Get All Plans
Example request:
```csharp
FindAllPlansModel plan = epayco.GetAllPlans();
string planResponse = JsonConvert.SerializeObject(plan, Formatting.Indented);
Console.WriteLine(planResponse);
```

#### Plan Remove
Example request:
```csharp
RemovePlanModel plan = epayco.RemovePlan("id_plan");
string planResponse = JsonConvert.SerializeObject(plan, Formatting.Indented);
Console.WriteLine(planResponse);
```

### SUBSCRIPTIONS

#### Create Subscription
Example request:
```csharp

CreateSubscriptionModel subscription = epayco.SubscriptionCreate(
        "id_plan", // Plan ID
        "customer_id", // Customer ID
        "token_card", // Token ID
        "CC", // Document type
        "0000000000", // Document number  
        urlConfirmation: "https://confirmacion.com/index.php", // Confirmation URL
        "POST" // Confirmation method
);

string subscriptionResponse = JsonConvert.SerializeObject(subscription, Formatting.Indented);
Console.WriteLine(subscriptionResponse);
```

#### Find Subscription
Example request:
```csharp
FindSusbscriptionModel subscription = epayco.getSubscription("subscription_id");
string subscriptionResponse = JsonConvert.SerializeObject(subscription, Formatting.Indented);
Console.WriteLine(subscriptionResponse);
```

#### Find All Subscriptions
Example request:
```csharp
AllSubscriptionModel subscription = epayco.getAllSubscription();
string subscriptionResponse = JsonConvert.SerializeObject(subscription, Formatting.Indented);
Console.WriteLine(subscriptionResponse);
```

#### Cancel Subscription
Example request:
```csharp
CancelSubscriptionModel subscription = epayco.cancelSubscription("subscription_id");
string subscriptionResponse = JsonConvert.SerializeObject(subscription, Formatting.Indented);
Console.WriteLine(subscriptionResponse);
```

#### Pay Subscription
Example request:
```csharp
ChargeSubscriptionModel subscription = epayco.ChargeSubscription(
        "id_plan", // Plan ID
        "customer_id", // Customer ID
        "token_card", // Token ID
        "doc_type", // Document type
        "doc_number", // Document number
        "ip", // Customer IP
        "address", // Customer address
        "phone", // Customer phone
        "cell_phone" // Customer mobile
);
string subscriptionResponse = JsonConvert.SerializeObject(subscription, Formatting.Indented);
Console.WriteLine(subscriptionResponse);

```

### PSE

#### Pse Create
Example request:
```csharp
PseModel pse = epayco.BankCreate(
    "1077",                    // bank_code - código del banco
    "factura_1101", // invoice - número de factura único
    "pago de prueba pse",       // description - descripción del pago
    "50000",                      // value - valor a pagar (50,000 cop)
    "0",                          // tax - impuestos
    "50000",                      // tax_base - base imponible
    "0",                          // ico - ico
    "COP",                      // currency - moneda
    "0",                        // type_person - 0=persona natural, 1=empresa
    "CC",                       // doc_type - tipo de documento (cc, ce, nit)
    "123456789",                // doc_number - número de documento
    "juan",                     // name - nombre
    "garcía",                   // last_name - apellido
    "juan.garcia12@gmail.com",    // email - correo electrónico
    "co",                       // country - país (co=colombia)
    "bogotá",                   // city - ciudad
    "3001234567",               // cell_phone - teléfono celular
    "https://webhook.site/4924ffa7-4941-4df2-810c-8529480467a6", // url_response - url de respuesta
    "https://webhook.site/4924ffa7-4941-4df2-810c-8529480467a6", // url_confirmation - url de confirmación
    "POST"                      // metodoconfirmacion - método de confirmación
);

string banksResponse = JsonConvert.SerializeObject(pse, Formatting.Indented);
Console.WriteLine(banksResponse);
```

#### Pse Create SplitPayment
Example request:
```csharp
List<SplitReceivers> splitReceiverses = new List<SplitReceivers>();
splitReceiverses.Add(new SplitReceivers() { id = "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000", fee = "100" });
PseModel response = epayco.BankCreateSplit(
 "Banka", // Bank code
 "1-J", // Reference
 "Split", // Description
 "10000", // Amount
 "2000", // Tax 
 "8000", // Tax base
 "0", // ICO
 "COP", // Currency
 "0", // 0=Natural Person, 1=Company
 "CC", // Document type
 "256454556", // Document number
 "Juan", // First name
 "Garcia", // Last name
 "juan.pruebas@gmail.com", // Email
 "CO", // Country
 "medellin", // City
 "2254554555", // Mobile
 "url_response", // Response URL
 "url_confirmation", // Confirmation URL
 "POST", // Confirmation method
 "true", // Enable split payment functionality
 "split_app_id", // Application ID
 "split_merchant_id", // Merchant ID
 "1",  // Split type
 "1",  // Rule type
 "split_primary_receiver", // Primary receiver ID
 "split_primary_receiver_fee", // Primary receiver fee
 splitReceiverses // Array of SplitReceivers, required if split_rule is sent
);
string banksResponse = JsonConvert.SerializeObject(pse, Formatting.Indented);
Console.WriteLine(banksResponse);
```

#### Get Transaction
Example request:
```csharp
TransactionModel transaction = epayco.GetTransaction("ticketId");
string banksResponse = JsonConvert.SerializeObject(transaction, Formatting.Indented);
Console.WriteLine(banksResponse);
```

#### Get Banks
Example request:
```csharp
BanksModel banks = epayco.GetBanks();
string banksResponse = JsonConvert.SerializeObject(banks, Formatting.Indented);
Console.WriteLine(banksResponse);
```

### CASH

#### Cash Create
Example request:
```csharp
CashModel response = epayco.CashCreate(
"efecty", //efecty, gana, baloto, redservi, puntored, sured
"EF-1", //Invoice
"Pay test", //Description
"20000 ", //Amount
"0", //Tax
"0", //Tax base
"0", //ICO
"COP", //Currency
"0", //Type person 0=Natural Person, 1=Company
"CC", //Document type 
"5488787488", //Document number
"Juan", // First name
"Garcia", //Last name
"test@mailinator.com", //Email
"3003605859", //Mobile
"2025-08-25", //End date YYYY-MM-DD
"N/A", //IP
"N/A", //Address
"https://tudominio.com/respuesta.php", //Response URL
"https://tudominio.com/respuesta.php", //Confirmation URL
"POST"); //Confirmation method

string cash = JsonConvert.SerializeObject(response, Formatting.Indented);
Console.WriteLine(cash);
```
#### Get Cash Transaction
Example request:
```csharp
CashTransactionModel cash = epayco.GetCashTransaction("ref_payco");
string cashResponse = JsonConvert.SerializeObject(cash, Formatting.Indented);
Console.WriteLine(cashResponse);
```

### Split Payments

Previous requirements: https://docs.epayco.co/tools/split-payment

#### Split 1-1

Example request:
```csharp
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

CashModel response = epayco.CashCreate(
        //Other customary parameters...
        splitData
);
```

#### Split multiple

Use the following attributes if you need to disperse to multiple providers

Example request:
```csharp
SplitModel splitData = new SplitModel();
splitData.splitpayment = "true";
splitData.split_app_id = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_merchant_id = "P_CUST_ID_CLIENTE COMMERCE";
splitData.split_type = "02";
splitData.split_primary_receiver = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_primary_receiver_fee = "0";
splitData.split_rule = "multiple"; // If this parameter is sent, splitReceivers becomes mandatory
List<EpaycoSdk.Models.Bank.SplitReceivers> splitReceivers = new List<SplitReceivers>();
splitReceivers.Add(new SplitReceivers() { id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100" });
splitReceivers.Add(new SplitReceivers() { id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100" });
splitData.split_receivers = splitReceivers;

CashModel response = epayco.CashCreate(
        //Other customary parameters...
        splitData
);
```

## PAYMENT

### Payment Create
Example request:
```csharp
ChargeModel response = epayco.ChargeCreate(
"token_card", //Token 
"customer_id", //Customer
"CC", //Document type
"1554545", //Document number
"juan", //First name
"Garcia", //Last name
"juan.garcia4@epayco.com", //Email
"16-J", //Invoice
"Test", //Description
"50000", //Amount
"8000", //Tax
"42000", //Tax base
"0", //ICO
"COP", //Currency
"1", //Dues
"calle prueba", //Address
"CO", //Country
"Medellin", //City
"125565566", //Phone
"300305254", //Mobile
"https://tudominio.com/respuesta.php", //Response URL
"https://tudominio.com/respuesta.php",//Confirmation URL
"POST", //Confirmation method
"179.12.113.12", //IP
"extra1", //Extras 
"extra2",
"extra3",
"extra4",
"extra5",
"extra6",
"extra7",
"extra8",
"extra9",
"extra10");

string chargeResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
Console.WriteLine(chargeResponse);
```

### Get Charge Transaction
Example request:
```csharp
ChargeTransactionModel charge = epayco.GetChargeTransaction("ref_payco");
string chargeResponse = JsonConvert.SerializeObject(charge, Formatting.Indented);
Console.WriteLine(chargeResponse);
```

### Split Payments

Previous requirements: https://docs.epayco.co/tools/split-payment

#### Split 1-1

Example request:
```csharp
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

ChargeModel response = epayco.ChargeCreate(
        //Other customary parameters...
        splitData
);
```

#### Split multiple

Use the following attributes if you need to disperse to multiple providers

Example request:
```csharp
SplitModel splitData = new SplitModel();
splitData.splitpayment = "true";
splitData.split_app_id = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_merchant_id = "P_CUST_ID_CLIENTE COMMERCE";
splitData.split_type = "02";
splitData.split_primary_receiver = "P_CUST_ID_CLIENTE APPLICATION";
splitData.split_primary_receiver_fee = "0";
splitData.split_rule = "multiple"; // If this parameter is sent, splitReceivers becomes mandatory
List<EpaycoSdk.Models.Bank.SplitReceivers> splitReceivers = new List<SplitReceivers>();
splitReceivers.Add(new SplitReceivers() { id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100" });
splitReceivers.Add(new SplitReceivers() { id= "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000",  fee = "100" });
splitData.split_receivers = splitReceivers;

ChargeModel response = epayco.ChargeCreate(
        //Other customary parameters...
        splitData
);
```
### Daviplata

#### Create

Creates a transaction in Daviplata
Example request:
```csharp
DaviplataModel daviplata = epayco.DaviplataCreate(
"CC", //Document type
"1134568019", //Document number
"Juan", //First name
"Garcia", //Last name
"juan.gaRci05@epayco.com", //Email
"57", //Country code
"3003602525", //Mobile
"CO", //Country
"N/A", //City
"N/A", //Address
"179.12.113.12", //IP
"COP", //Currency
"50-lo", //Invoice
"Pago de pruebas", //Description
5000, //Amount
0, //Tax
0, //Tax base 
0, //ICO
"true", //Test
"https://tudominio.com/respuesta.php", //Response URL
"https://tudominio.com/respuesta.php", //Confirmation URL
"POST" //Confirmation method
);

string daviplataResponse = JsonConvert.SerializeObject(daviplata, Formatting.Indented);
Console.WriteLine(daviplataResponse);
```

#### Confirm
Confirms a transaction in Daviplata

Example:
```csharp
DaviplataConfirmModel daviplata = epayco.DaviplataConfirm(
        "ref_payco",
        "id_session_token",
        "otp"
);

string daviplataResponse = JsonConvert.SerializeObject(daviplata, Formatting.Indented);
Console.WriteLine(daviplataResponse);
```

### Safetypay

#### Create
Creates a transaction in Safetypay

Example request:
```csharp
safetypayModel safetypay = epayco.SafetypayCreate(
"1", //bank_code
"2025-08-30", //due_date YYYY-MM-DD
"CC", //document type
"1000204854", //document number
"Juan", // First name
"Garcia", //Last name
"gerson.vasquez5@epayco.com", //Email
"57", //Country code
"3003003434", //Mobile
"CO", //Country
"N/A", //City
"N/A", //Address
"192.168.100.100", //IP
"COP", //Currency
"fac-05741", //Invoice
"Thu Jun 17 2021 11:37:01 GMT-0400 (Venezuela time)", //Description
10000, //Amount
0, //Tax
0, //Tax base
0, //ICO
"true", //Test
"https://tudominio.com/respuesta.php", //Response URL
"https://tudominio.com/respuesta.php", //Confirmation URL
"https://tudominio.com/respuesta.php", //Success URL
"POST" //Confirmation method
);

string safetypayResponse = JsonConvert.SerializeObject(safetypay, Formatting.Indented);
Console.WriteLine(safetypayResponse);
```


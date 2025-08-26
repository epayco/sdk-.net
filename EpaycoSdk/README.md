# EPAYCO SDK .NET
## Requisitos
Para el uso del sdk es necesario instalar las siguientes librerias:
* Microsoft.CSharp
* Newtonsoft.Json

## Configuración Manual
- Descargar el SDK desde el repositorio
- Agregar la referencia del proyecto en la solución "Configurar en el archivo EpaycoSdk.csproj la etiqueta <OutputType>Exe</OutputType>"
```"
- Importar la librería en la clase donde se va a utilizar
```

## Inicialización del SDK
Es recomendable inicilizar el SDK en el controlador o clase principal donde se desean implementar los métodos.
```
Epayco epayco = new EpaycoSdk.Epayco(
  "public_key",  
  "private_key", 
  "languaje", // Idioma
  test // (true/false)
); 
```
## METODOS DISPONIBLES
### Create Token (Tokenizar un medio de pago)
Ejemplo de la petición:
```
TokenModel token = epayco.CreateToken(
    "4575623182290326", // Numero de la tarjeta
    "2025", // Año de vencimiento 
    "12",   // Mes de vencimiento
    "123"   // CVC
);
string tokenResponse = JsonConvert.SerializeObject(token, Formatting.Indented);
Console.WriteLine(tokennResponse);
```

### CUSTOMER
### Create Customer 
Ejemplo de la petición:
```
CustomerCreateModel customer = epayco.CustomerCreate(
    token.id, // Id del token
    "Juan", // Nombre 
    "Garcia", // Apellido
    "juanes99@gmail.com", // Email 
    true, // Boolean (Indica si el cliente está activo o inactivo)
    "medellin", // Ciudad
    "calle 45", // Dirección
    "4345689", // Teléfono
    "3003602025" // Celular
);

string customerResponse = JsonConvert.SerializeObject(customer, Formatting.Indented);
Console.WriteLine(customerResponse);

);
```
### Get Customer 
Ejemplo de la petición:
```
 CustomerFindModel customer = epayco.FindCustomer("customer_id");
 string customerResponse = JsonConvert.SerializeObject(customer, Formatting.Indented);
Console.WriteLine(customerResponse);
```
### Update Customer 
Ejemplo de la petición:
```
 CustomerEditModel customer = epayco.CustomerUpdate("customer_id", "name");
 string customerResponse = JsonConvert.SerializeObject(customer, Formatting.Indented);
Console.WriteLine(customerResponse);
```
### Customer Token Remove
Ejemplo de la petición:
```
 CustomerTokenDeleteModel customer = epayco.CustomerDeleteToken(
    "franchise", 
    "mask", 
    "customer_id"
);
string customerResponse = JsonConvert.SerializeObject(customer, Formatting.Indented);
Console.WriteLine(customerResponse);
```
### Customer List
Ejemplo de la petición:
```
 CustomerListModel customer = epayco.CustomerGetList();
string customerResponse = JsonConvert.SerializeObject(customer, Formatting.Indented);
Console.WriteLine(customerResponse);
```
### PLANS
### Plan Create 
Ejemplo de la petición:
```
CreatePlanModel plan = epayco.PlanCreate(
    "plan_id_", // Id del plan
    "name", // Nombre del plan
    "description", // Descripción del plan
    10000, // Valor del plan
    "COP", // Moneda
    "month", // Periodo del plan
    30, // Días del plan
    1 // Cantidad de ciclos
);
string planResponse = JsonConvert.SerializeObject(plan, Formatting.Indented);
Console.WriteLine(planResponse);
```
### Get Plan
Ejemplo de la petición:
```
FindPlanModel plan = epayco.GetPlan("id_plan");
string planResponse = JsonConvert.SerializeObject(plan, Formatting.Indented);
Console.WriteLine(planResponse);
```

### Get All Plans
Ejemplo de la petición:
```
FindAllPlansModel plan = epayco.GetAllPlans();
string planResponse = JsonConvert.SerializeObject(plan, Formatting.Indented);
Console.WriteLine(planResponse);
```

### Plan Remove
Ejemplo de la petición:
```
RemovePlanModel plan = epayco.RemovePlan("id_plan");
string planResponse = JsonConvert.SerializeObject(plan, Formatting.Indented);
Console.WriteLine(planResponse);
```

### SUBSCRIPTIONS
### Create Subscription
Ejemplo de la petición:
```
Console.WriteLine("=== CREANDO SUSCRIPCIÓN ===");
CreateSubscriptionModel subscription = epayco.SubscriptionCreate(
    "id_plan", // ID del plan
    "customer_id", // ID del cliente
    "token_card", // ID del token
    "CC", // Tipo de documento
    "0000000000", // Numero de documento  
    urlConfirmation: "https://confirmacion.com/index.php", // Url de confirmación
    "POST" // Método de confirmación
);

string suscripcionResponse = JsonConvert.SerializeObject(subscription, Formatting.Indented);
Console.WriteLine(suscripcionResponse);
```

### Find Subscription
Ejemplo de la petición:
```
FindSusbscriptionModel subscription = epayco.getSubscription("subscription_id");
string suscripcionResponse = JsonConvert.SerializeObject(subscription, Formatting.Indented);
Console.WriteLine(suscripcionResponse);
```

### Find All Subscriptions
Ejemplo de la petición:
```
AllSubscriptionModel subscription = epayco.getAllSubscription();
string suscripcionResponse = JsonConvert.SerializeObject(subscription, Formatting.Indented);
Console.WriteLine(suscripcionResponse);
```

### Cancel Subscription
Ejemplo de la petición:
```
CancelSubscriptionModel subscription = epayco.cancelSubscription("subscription_id");
string suscripcionResponse = JsonConvert.SerializeObject(subscription, Formatting.Indented);
Console.WriteLine(suscripcionResponse);
```

### Pay Subscription
Ejemplo de la petición:
```
ChargeSubscriptionModel subscription = epayco.ChargeSubscription(
    "id_plan", // ID del plan
    "customer_id", // ID del cliente
    "token_card", // ID del token
    "doc_type", //Tipo de documento
    "doc_number", //Numero de documento
    "ip", // IP del cliente
    "address", // Dirección del cliente
    "phone", // Teléfono del cliente
    "cell_phone" // Celular del cliente
);
```

### PSE
### Pse Create
Ejemplo de la petición:
```
PseModel pse = epayco.BankCreate(
    "banka",                    // bank_code - Código del banco
    "FACTURA_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"), // invoice - Número de factura único
    "Pago de prueba PSE",       // description - Descripción del pago
    "50000",                      // value - Valor a pagar (50,000 COP)
    "0",                          // tax - Impuestos
    "50000",                      // tax_base - Base imponible
    "0",                          // ico - ICO
    "COP",                      // currency - Moneda
    "0",                        // type_person - 0=Persona Natural, 1=Empresa
    "CC",                       // doc_type - Tipo de documento (CC, CE, NIT)
    "123456789",                // doc_number - Número de documento
    "Juan",                     // name - Nombre
    "García",                   // last_name - Apellido
    "juan.garcia@gmail.com",    // email - Correo electrónico
    "CO",                       // country - País (CO=Colombia)
    "Bogotá",                   // city - Ciudad
    "3001234567",               // cell_phone - Teléfono celular
    "https:/response.com/index.php", // url_response - URL de respuesta
    "https://confirmation.com/index.php", // url_confirmation - URL de confirmación
    "POST"                      // metodoconfirmacion - Método de confirmación
);
string banksResponse = JsonConvert.SerializeObject(pse, Formatting.Indented);
Console.WriteLine(banksResponse);

```

### PSE
### Pse Create SplitPayment
Ejemplo de la petición:
```

//List<SplitReceivers> splitReceiverses = new List<SplitReceivers>();
//splitReceiverses.Add(new SplitReceivers() { id = "ID_COMMERCE_RECEIVER", total = "10000", iva = "2500", ico = "2500", base_iva = "5000", fee = "100" });
//PseModel response = epayco.BankCreateSplit(
//  "Banka", // Codigo del banco
//  "1-J", //  Referencia,
//  "Split", //  Description",
//  "10000", //Valor
//  "2000", // Tax 
//  "8000", //Tax base
//  "0", //  Ico
//  "COP", // Moneda
//  "0", // 0=Persona Natural, 1=Empresa
//  "CC", // Tipo de documento
//  "256454556", // Numero de documento
//  "Juan", // Nombre
//  "Garcia", //Apellido
//  "juan.pruebas@gmail.com", //  Correo
//  "CO", // Pais
//  "medellin" // Ciudad
//  "2254554555", // Celular
//  "url_response", // Url de respuesta
//  "url_confirmation", // Url de confirmacion
//  "POST" // Metodo de confirmacion
//  "true", // Verdadero o falso para activar la funcionalidad de split payment
//  "split_app_id", // Aplication id
//  "split_merchant_id", // Comercio id
//  "1",  //  Tipo de split
//  "1",  // Tipo de regla
//  "split_primary_receiver", //  Id del comercio que recibe el pago
//  "split_primary_receiver_fee", //  Tarifa del comercio que recibe el pago
//  splitReceiverses // Este sería un array de tipo SplitReceivers el cual se inicializa al principio del método es un campo opcional y es obligatorio sí se envía split_rule
//);
string banksResponse = JsonConvert.SerializeObject(pse, Formatting.Indented);
Console.WriteLine(banksResponse);
```

### Get Transaction
Ejemplo de la petición:
```
TransactionModel transaction = epayco.GetTransaction("ticketId");
string banksResponse = JsonConvert.SerializeObject(transaction, Formatting.Indented);
Console.WriteLine(banksResponse);
```

### Get Banks
Ejemplo de la petición:
```
BanksModel banks = epayco.GetBanks();
string banksResponse = JsonConvert.SerializeObject(banks, Formatting.Indented);
Console.WriteLine(banksResponse);
```

### CASH
### Cash Create
Ejemplo de la petición:
```
CashModel response = epayco.CashCreate(
"efecty", //efecty, gana, baloto, redservi, puntored, sured
"EF-1", //Invoice
"Pay test", //Description
"20000 ", //Value
"0", //Tax
"0", //Tax base
"0", //Ico
"COP", //Currency
"0", //Type person 0=Persona Natural, 1=Empresa
"CC", //Doc type 
"5488787488", //Doc number
"Juan", // Name
"Garcia", //Last name
"test@mailinator.com", //Email
"3003605859", //Cell phone
"2025-08-25", //End date YYYY-MM-DD
"N/A", //IP
"N/A", //Address
"https://tudominio.com/respuesta.php", //Url response
 "https://tudominio.com/respuesta.php", //Url confirmation
"POST"); //Method confirmation

string cash = JsonConvert.SerializeObject(efectivo, Formatting.Indented);
Console.WriteLine(cash);
```
### Get Cash Transaction
Ejemplo de la petición:
```
CashTransactionModel cash = epayco.GetCashTransaction("ref_payco");
string cash = JsonConvert.SerializeObject(efectivo, Formatting.Indented);
Console.WriteLine(cash);
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

CashModel response = epayco.CashCreate(
    //Other customary parameters...
    splitData
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

CashModel response = epayco.CashCreate(
    //Other customary parameters...
    splitData
);
```

## PAYMENT
### Payment Create
Ejemplo de la petición:
```
ChargeModel response = epayco.ChargeCreate(
"token_card", //Token 
"customer_id", //Customer
"CC", //Doc type
"1554545", //Doc number
"juan", //Name
"Garcia", //Last name
"juan.garcia4@epayco.com", //Email
"16-J", //Invoice
"Test", //Description
"50000", //Value
"8000", //Tax
"42000", //Tax base
"0", //Ico
"COP", //Currency
"1", //Dues
"calle prueba", //Address
"CO", //Country
"Medellin", //City
"125565566", //Phone
"300305254", //Cell phone
"https://tudominio.com/respuesta.php", //Url response
 "https://tudominio.com/respuesta.php",//Url confirmation
"POST", //Method confirmation
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


string chargeResponse = JsonConvert.SerializeObject(charge, Formatting.Indented);
Console.WriteLine(chargeResponse);

```


### Get Charge Transaction
Ejemplo de la petición:
```
 ChargeTransactionModel charge = epayco.GetChargeTransaction("ref_payco");
 string chargeResponse = JsonConvert.SerializeObject(charge, Formatting.Indented);
Console.WriteLine(chargeResponse);

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

ChargeModel response = epayco.ChargeCreate(
    //Other customary parameters...
    splitData
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

ChargeModel response = epayco.ChargeCreate(
    //Other customary parameters...
    splitData
);
```


### Daviplata

## Create

Crea una transaccion en Daviplata
Ejemplo de la peticion
```
DaviplataModel daviplata = epayco.DaviplataCreate(
"CC", //Tipo de documento
"1134568019", //Numero de documento
"Juan", //Nombre
"Garcia", //Apellido
"juan.gaRci05@epayco.com", //Email
"57", //Codigo del pais
"3003602525", //Celular
"CO", //Pais
"N/A", //Ciudad
"N/A", //Direccion
"179.12.113.12", //IP
"COP", //Moneda
"50-lo", //Factura
"Pago de pruebas", //Descripcion
5000, //Valor
0, //Impuesto
0, //Base tax 
0, //Ico
"true", //Test
"https://tudominio.com/respuesta.php", //Url response
"https://tudominio.com/respuesta.php", //Url confirmation
"POST" //Method confirmation

);

string daviplataResponse = JsonConvert.SerializeObject(daviplata, Formatting.Indented);
Console.WriteLine(daviplataResponse);

)
```

## Confirm
Confirma una transaccion en Daviplata

Ejemplo:
```
DaviplataConfirmModel daviplata = epayco.DaviplataConfirm(
    "ref_payco",
    "id_session_token",
    "otp"
)

string daviplataResponse = JsonConvert.SerializeObject(daviplata, Formatting.Indented);
Console.WriteLine(daviplataResponse);


```

### Safetypay

## Create
Crea una transaccion en Safetypay

Ejemplo de peticion
```
safetypayModel safetypay = epayco.SafetypayCreate(
"1", //bank_code
"2025-08-30", //due_date YYYY-MM-DD
"CC", //doc_type
"1000204854", //doc_number
"Juan", // name
"Garcia", //last_name
"gerson.vasquez5@epayco.com", //email
"57", //country
"3003003434", //cell_phone
"CO", //country
"N/A", //city
"N/A", //address
"192.168.100.100", //ip
"COP", //currency
"fac-05741", //invoice
"Thu Jun 17 2021 11:37:01 GMT-0400 (hora de Venezuela)", //description
10000, //value
0, //tax
0, //tax_base
0, //ico
"true", //test
"https://tudominio.com/respuesta.php", //url_response
"https://tudominio.com/respuesta.php", //url_confirmation
"https://tudominio.com/respuesta.php", //url_success
"POST" //method_confirmation
);


string safetypayResponse = JsonConvert.SerializeObject(safetypay, Formatting.Indented);
Console.WriteLine(safetypayResponse);
```


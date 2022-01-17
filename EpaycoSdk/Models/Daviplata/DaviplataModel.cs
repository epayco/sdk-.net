﻿using EpaycoSdk.Models.Cash;
using System.Collections.Generic;

namespace EpaycoSdk.Models.Daviplata
{
    public class DaviplataModel
    {
        public bool success { get; set; }
        public string titleResponse { get; set; }
        public string textResponse { get; set; }
        public string lastAction { get; set; }
        public DaviplataTransactionData data { get; set; }
    }

    public class DaviplataTransactionData
    {
        public string refPayco { get; set; }
        public string invoice { get; set; }
        public string description { get; set; }
        public decimal value { get; set; }
        public decimal tax { get; set; }
        public decimal ico { get; set; }
        public decimal taxBase { get; set; }
        public decimal netoValue { get; set; }
        public string currency{ get; set; }
        public string bank  { get; set; }
        public string estatus{ get; set; }
        public string response { get; set; }
        public string autorization { get; set; }
        public int receipt { get; set; }
        public string date { get; set; }
        public string franchise { get; set; }
        public int codResponse { get; set; }
        public string ip{ get; set; }
        public string testMode { get; set; }
        public string docType { get; set; }
        public string document{ get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string indCountry { get; set; }
        public string idSessionToken { get; set; }
        public string tokenExpirationDate { get; set; }
        public int totalErrors { get; set; }
        public List<errors> errors { get; set; }
    }

    public class bodyDaviplata
    {
        public string docType { get; set; }
        public string document { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string indCountry { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string ip { get; set; }
        public string currency { get; set; }
        public string invoice { get; set; }
        public string description { get; set; }
        public decimal value { get; set; }
        public decimal tax { get; set; }
        public decimal taxBase { get; set; }
        public decimal ico { get; set; }
        public bool test { get; set; }
        public string urlResponse { get; set; }
        public string urlConfirmation { get; set; }
        public string methodConfirmation { get; set; }
        public string typeIntegration { get; set; }
    }

    public class bodyConfirmDaviplata
    {
        public string refPayco { get; set; }
        public string idSessionToken { get; set; }
        public string otp { get; set; }
    }

    public class DaviplataConfirmModel
    {
        public bool success { get; set; }
        public string titleResponse { get; set; }
        public string textResponse { get; set; }
        public string lastAction { get; set; }
        public DaviplataConfirmData data { get; set; }

    }

    public class DaviplataConfirmData
    {
        public string refPayco { get; set; }
        public string status { get; set; }
        public string date { get; set; }
        public string numApproval { get; set; }
        public string idTransactionDaviplata { get; set; }
        public int idTransactionAutorization { get; set; }
        public string response { get; set; }
        public int totalErrors { get; set; }
        public List<errors> errors { get; set; }
    }
}

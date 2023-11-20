using RestSharp;
using CoreLibrary.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using CoreLibrary.Extras;
using System.Xml.Schema;
using CoreLibrary.Models.DTO;

namespace CoreLibrary.Models.Base
{
    public class Expense
    {
        public int expenseId { get; set; }
        public int personId { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public int totalPaymentsRequested { get; set; }
        public int totalPaymentsReceived { get; set; }
        public int nettAmount { get; set; }

        public Expense(int expenseId, int personId, string date, string description, int amount, int totalPaymentsReceived, int totalPaymentsRequested, int nettAmount)
        {
            this.expenseId = expenseId;
            this.personId = personId;
            this.date = date;
            this.description = description;
            this.amount = amount;
            this.totalPaymentsRequested = totalPaymentsRequested;
            this.totalPaymentsReceived = totalPaymentsReceived;
            this.nettAmount = nettAmount;
        }
    }
}
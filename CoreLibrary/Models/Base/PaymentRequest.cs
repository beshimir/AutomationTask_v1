namespace CoreLibrary.Models.Base
{
    public class PaymentRequest
    {
        public int id { get; set; }
        public int expenseId { get; set; }
        public int fromPersonId { get; set; }
        public int toPersonId { get; set; }
        public int amount { get; set; }
        public string date { get; set; }
        public bool paid { get; set; }

        public PaymentRequest(int id, int expenseId, int fromPersonId, int toPersonId, int amount, string date, bool paid)
        {
            this.id = id;
            this.expenseId = expenseId;
            this.fromPersonId = fromPersonId;
            this.toPersonId = toPersonId;
            this.amount = amount;
            this.date = date;
            this.paid = paid;
        }
    }
}
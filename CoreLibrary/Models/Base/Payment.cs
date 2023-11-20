namespace CoreLibrary.Models.Base
{
    public class Payment
    {
        public int id { get; set; }
        public int expenseId { get; set; }
        public int paymentRequestId { get; set; }
        public int payingPersonId { get; set; }
        public int amount { get; set; }
        public string date { get; set; }

        public Payment(int id, int expenseId, int paymentRequestId, int payingPersonId, int amount, string date)
        {
            this.id = id;
            this.expenseId = expenseId;
            this.paymentRequestId = paymentRequestId;
            this.payingPersonId = payingPersonId;
            this.amount = amount;
            this.date = date;
        }
    }
}
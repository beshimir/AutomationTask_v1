namespace CoreLibrary.Models.DTO
{
    public class PaymentRequestDTO
    {
        public int expenseId { get; set; }
        public int fromPersonId { get; set; }
        public int toPersonId { get; set; }
        public string date { get; set; }
        public int amount { get; set; }

        public PaymentRequestDTO(int expenseId, int fromPersonId, int toPersonId, string date, int amount)
        {
            this.expenseId = expenseId;
            this.fromPersonId = fromPersonId;
            this.date = date;
            this.toPersonId = toPersonId;
            this.amount = amount;
        }
    }
}
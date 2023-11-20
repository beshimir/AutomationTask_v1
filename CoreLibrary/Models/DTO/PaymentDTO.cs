namespace CoreLibrary.Models.DTO
{
    public class PaymentDTO
    {
        public int expenseId { get; set; }
        public int paymentRequestId { get; set; }
        public int payingPersonId { get; set; }

        public PaymentDTO(int expenseId, int paymentRequestId, int payingPersonId)
        {
            this.expenseId = expenseId;
            this.paymentRequestId = paymentRequestId;
            this.payingPersonId = payingPersonId;
        }
    }
}
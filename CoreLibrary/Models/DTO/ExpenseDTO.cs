namespace CoreLibrary.Models.DTO
{
    public class ExpenseDTO
    {
        public int personId { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public int amount { get; set; }

        public ExpenseDTO(int personId, string date, string description, int amount)
        {
            this.personId = personId;
            this.date = date;
            this.description = description;
            this.amount = amount;
        }
    }
}
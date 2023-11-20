namespace CoreLibrary.Models.DTO
{
    public class PersonDTO
    {
        public string email { get; set; }
        
        public PersonDTO(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }
    }
}
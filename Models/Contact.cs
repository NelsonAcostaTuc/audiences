namespace Audiences.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
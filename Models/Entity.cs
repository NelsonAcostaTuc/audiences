namespace Audiences.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public int EntityTypeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}
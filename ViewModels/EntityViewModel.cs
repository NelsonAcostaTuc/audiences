using System.ComponentModel.DataAnnotations;

namespace Audiences.ViewModels
{
    public class EntityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

    }
}
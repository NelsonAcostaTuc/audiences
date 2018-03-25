using System.ComponentModel.DataAnnotations;

namespace Audiences.ViewModels
{
    public class EntityTypeViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Audiences.Models.Identity.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

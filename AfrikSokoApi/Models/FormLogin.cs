using System.ComponentModel.DataAnnotations;

namespace AfrikSokoApi.Models
{
    public class FormLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

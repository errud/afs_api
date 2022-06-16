using System.ComponentModel.DataAnnotations;

namespace AfrikSokoApi.Models
{
    public class ModifyBuyer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

    }
}

using System.ComponentModel.DataAnnotations;

namespace AfrikSokoApi.Models
{
    public class NewServiceCreate
    { 
        [Required]
        public string ServiceName { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Period { get; set; } = string.Empty;
        [Required]
        public string Note { get; set; } = string.Empty;
    }
}

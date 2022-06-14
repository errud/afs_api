using System.ComponentModel.DataAnnotations;
namespace AfrikSokoApi.Models
{
    public class ModifyProduct
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        //public Category Category { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string Origin { get; set; } = string.Empty;
    }
}

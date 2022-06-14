using System.ComponentModel.DataAnnotations;
namespace AfrikSokoApi.Models
{
    public class NewProductCreate
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        //public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Origin { get; set; } = string.Empty;
    }
}

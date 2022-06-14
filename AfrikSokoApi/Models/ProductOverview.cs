using System.ComponentModel.DataAnnotations.Schema;

namespace AfrikSokoApi.Models
{
    public class ProductOverview
    {
        public int Uid { get; set; }
        public string Company { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

    }
}

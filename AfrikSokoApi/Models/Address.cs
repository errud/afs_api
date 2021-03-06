using System.ComponentModel.DataAnnotations.Schema;
namespace AfrikSokoApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}

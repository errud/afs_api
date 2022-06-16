using System.ComponentModel.DataAnnotations;

namespace AfrikSokoApi.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public int SectorId { get; set; }
        public int ServiceId { get; set; }
        public bool Membership { get; set; } = false;
        public string Contact { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string AdditInfo { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.Now;

    }
}

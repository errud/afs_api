using System.ComponentModel.DataAnnotations;

namespace AfrikSokoApi.Models
{
    public class NewCommentCreate
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime PostDate { get; set; } = DateTime.Now;

    }
}

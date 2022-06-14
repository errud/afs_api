using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime PostDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}

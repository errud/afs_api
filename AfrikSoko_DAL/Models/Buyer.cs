using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}

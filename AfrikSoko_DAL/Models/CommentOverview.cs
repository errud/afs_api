using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Models
{
    public class CommentOverview
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProductName { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_BLL.LocalModels
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}

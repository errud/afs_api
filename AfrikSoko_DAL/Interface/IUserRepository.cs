using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{
    public interface IUserRepository<User>
    {
        int Register(string email, string password, string firstname, string lastname, string nickname);
        User Login (string email, string password);
        bool? CheckUser(User u);
        IEnumerable<User> GetAll();
        User GetById(int Id); 
        User GetByEmail(string email);
        void SetAdmin(int Id);
        void Update(User u);
        bool Delete(int Id);
    }
}

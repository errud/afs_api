using AfrikSoko_BLL.LocalModels;
using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_BLL.LocalServices.Interface
{
    public interface IUserService
    {
        bool? CheckUser(CompleteAppUser u);
        IEnumerable<CompleteAppUser> GetAll();
        CompleteAppUser GetCompleteUser(int Id);
        CompleteAppUser GetById(int Id);
        CompleteAppUser GetByMail(string Email);
        void RegisterUser(CreateUserModel user);
        void Switchactivate(int Id);
        void Update(CompleteAppUser u);
        void SwitchAdmin(int Id);
    }
}

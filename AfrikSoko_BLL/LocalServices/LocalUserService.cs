using AfrikSoko_BLL.LocalModels;
using AfrikSoko_BLL.LocalServices.Interface;
using AfrikSoko_BLL.Tools;
using AfrikSoko_DAL.Interface;
using dal = AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AfrikSoko_DAL.Models;

namespace AfrikSoko_BLL.LocalServices
{
    public class LocalUserService : IUserService
    {
        private readonly IUserRepository<dal.User> _userRepo;
        private readonly IProductTypeRepository _prodtRepo;


        public LocalUserService(IUserRepository<dal.User> userRepo, IProductTypeRepository prodtRepo)
        {
            _userRepo = userRepo;
            _prodtRepo = prodtRepo;

        }


        public bool? CheckUser(CompleteAppUser u)
        {
            bool? reponse = _userRepo.CheckUser(u.toDal());
            return reponse;
        }

        public IEnumerable<CompleteAppUser> GetAll()
        {
            return _userRepo.GetAll().Select(x => x.ToLocal());
        }

        public CompleteAppUser GetById(int Id)
        {
            return _userRepo.GetById(Id).ToLocal();
        }

        public CompleteAppUser GetByMail(string Email)
        {
            return _userRepo.GetByEmail(Email).ToLocal();
        }

        public CompleteAppUser GetCompleteUser(int Id)
        {
            CompleteAppUser result = _userRepo.GetById(Id).ToLocal();
            result.FavoriteProdTypes = _prodtRepo.GetFavoriteByUserId(Id);
            return result;
        }


        public void RegisterUser(CreateUserModel m)
        {
            int newUserId = _userRepo.Register(m.Email, m.Password, m.FirstName, m.LastName, m.NickName);

          /*  foreach (int prodtypeId in m.FavoriteId)
            {
                _prodtRepo.AddFavorite(newUserId, prodtypeId);
            }*/
        }
        /*
        public void RegisterUser(CompleteAppUser user)
        {
            _userRepo.Register(CompleteAppUser.toDal());
        }*/

        public void Switchactivate(int Id)
        {
            _userRepo.Delete(Id);
        }

        public void SwitchAdmin(int Id)
        {
            _userRepo.SetAdmin(Id);
        }

        public void Update(CompleteAppUser u)
        {
            _userRepo.Update(u.toDal());
        }
    }







}

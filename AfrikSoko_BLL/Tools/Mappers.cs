using local = AfrikSoko_BLL.LocalModels;
using dal = AfrikSoko_DAL.Models;
using AfrikSoko_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_BLL.Tools
{
    public static class Mappers
    {
        public static local.CompleteAppUser ToLocal(this dal.User u)
        {
            return new local.CompleteAppUser
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role,
                NickName = u.NickName,
                IsActive = u.IsActive              
              
            };
        }

        public static dal.User toDal(this local.CompleteAppUser u)
        {
            return new dal.User
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                NickName = u.NickName,
                IsActive = u.IsActive
            };
        }
























    }
}

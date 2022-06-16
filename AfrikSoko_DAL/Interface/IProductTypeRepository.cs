using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{
    public interface IProductTypeRepository
    {
        IEnumerable<ProductType> GetAll();
        string GetNameById(int Id);
        bool Create(ProductType pt);
        IEnumerable<ProductType> GetFavoriteByUserId(int id);
        void AddFavorite(int userId, int prodtypeId);
    }
}


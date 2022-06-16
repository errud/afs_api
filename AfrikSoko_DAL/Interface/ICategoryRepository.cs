using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        string GetNameById(int Id);
        string GetUrlById(int Id);
        bool Create(Category c);
        bool Update(Category c);
        bool Delete(int Id);
    }
}

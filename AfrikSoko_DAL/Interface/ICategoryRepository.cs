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
        bool Create(string name, string url);
        bool Update(int id, string name, string url);
        bool Delete(int Id);
    }
}

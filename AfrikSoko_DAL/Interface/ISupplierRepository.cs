using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int Id);
        IEnumerable<Supplier> GetBySector(int Id);
        IEnumerable<Supplier> GetByService(int Id);
        User GetUserBySupplier(int Id);  
        bool Create(Supplier supplier);
        bool Update(Supplier supplier);
        bool Delete(int Id);
    }
}

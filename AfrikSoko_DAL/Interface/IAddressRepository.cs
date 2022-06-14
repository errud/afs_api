using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        IEnumerable<Address> GetByUserId(int Id);
        bool Create(Address address);
        bool Update(Address address);
        bool Delete(int Id);
    }
}

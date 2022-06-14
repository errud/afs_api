using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{
    public interface IBuyerRepository <Buyer, User>
    {
        IEnumerable<Buyer> GetAll();
        Buyer GetById(int Id);
        User GetUserByBuyer(int Id);
        bool Create(Buyer buyer);
        bool Update(Buyer buyer);
        bool Delete(int Id);
    }
}

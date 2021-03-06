using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{ 
    public interface ISupplyItemRepository
    {
        IEnumerable<SupplyItemOverview> GetAll();
        IEnumerable<SupplyItemOverview> GetByUser(int Id);
        bool Create(SupplyItem s);
        bool Update(SupplyItem s);
        bool Delete(int UserId, int ProductId, int ProductTypeId);
        
    }
}

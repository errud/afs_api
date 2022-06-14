using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAll();
        string GetNameById(int Id);
        bool Create(Service service);
    }
}

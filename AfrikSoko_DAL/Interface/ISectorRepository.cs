using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{
    public interface ISectorRepository
    {
        IEnumerable<Sector> GetAll();
        string GetNameById(int Id);
        bool Create(string name);       
    }
}

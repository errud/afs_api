using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{
    public interface IProductRepository<Product, SupplyItem>
    {
        IEnumerable<Product> GetAll();
        //IEnumerable<ProductOverview> GetAll();
        IEnumerable<Product> GetByCategoryId(int Id);
        //ProductOverview GetByUser(int Id);
        Product GetById(int Id);
        bool Create(Product p);
        bool Update(Product p);
        bool Delete(int Id);        
        
    
    }
}

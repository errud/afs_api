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
        IEnumerable<ProductOverview> ViewAll();
        IEnumerable<Product> GetByCategoryId(int Id);
        Product GetById(int Id);
        //void SetSuppliedItem(int UserId, int ProductId, int ProductTypeId, string Quantity, decimal TotalPrice);
        bool Create(Product p);
        bool Update(Product p);
        bool Delete(int Id);        
        
    
    }
}

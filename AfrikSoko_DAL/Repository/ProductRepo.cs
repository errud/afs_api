using AdoToolbox;
using AfrikSoko_DAL.Interface;
using AfrikSoko_DAL.Models;
using AfrikSoko_DAL.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Repository
{
    public class ProductRepo : BaseRepository, IProductRepository <Product, SupplyItem>
    {

        public ProductRepo(IConfiguration config) : base(config)
        {
        }

        internal Product Converter(SqlDataReader reader)
        {
            return new Product
            {
                Id = (int)reader["Id"],
                Title = reader["Title"].ToString(),
                ImageUrl = reader["ImageUrl"].ToString(),
                Description = reader["Description"].ToString(),
                Origin = reader["Origin"].ToString(),
                CategoryId = (int)reader["CategoryId"]
            };

        }

       public IEnumerable<Product> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Product");

            return cnx.ExecuteReader(cmd, Converter);
        }

        /*public IEnumerable<ProductOverview> GetAll()
        {
            Command cmd = new Command("SELECT * FROM V_ProductMain");

            return cnx.ExecuteReader(cmd, Converters.ProdOverviewConverter);
        }*/

        public IEnumerable<Product> GetByCategoryId(int Id)
        {
            Command cmd = new Command("SELECT * FROM Product WHERE CategoryId = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteReader(cmd, Converter);
        }

        /*public ProductOverview GetByUser(int Id)
        {
            Command cmd = new Command("SELECT * FROM V_ProductMain WHERE Uid = @id");
            cmd.AddParameter("id", Id);

            return cnx.ExecuteReader(cmd, Converters.ProdOverviewConverter).FirstOrDefault();
        }*/

        public Product GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM Product WHERE Id = @id");
            cmd.AddParameter("id", Id);

            return cnx.ExecuteReader(cmd, Converter).FirstOrDefault();
        }

        /*
        public void SetSuppliedItem(int UserId, int ProductId, int ProductTypeId,  string Quantity, decimal TotalPrice)
        {
            Command cmd = new Command("INSERT INTO SupplyItems (UserId, ProductId, ProductTypeId, Quantity, TotalPrice) VALUES (@uid, @prodid, @prodtypeid, @qty, @totprice)");

            cmd.AddParameter("uid", UserId);
            cmd.AddParameter("prodid", ProductId);
            cmd.AddParameter("prodtypeid", ProductId);
            cmd.AddParameter("qty", Quantity);
            cmd.AddParameter("totprice", TotalPrice);
           
            cnx.ExecuteNonQuery(cmd);
        }
        */
        public bool Create(Product p)
        {
            Command cmd = new Command("AddProduct", true);

            cmd.AddParameter("title", p.Title);
            cmd.AddParameter("imgurl", p.ImageUrl);
            cmd.AddParameter("descr", p.Description);
            cmd.AddParameter("origin", p.Origin);
            cmd.AddParameter("catId", p.CategoryId);
            try
            {
                return cnx.ExecuteNonQuery(cmd) == 1;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public bool Update(Product p)
        {
            Command cmd = new Command("UpdateProduct", true);

            cmd.AddParameter("title", p.Title);
            cmd.AddParameter("imgurl", p.ImageUrl);
            cmd.AddParameter("descr", p.Description);
            cmd.AddParameter("origin", p.Origin);
            cmd.AddParameter("catId", p.CategoryId);
            cmd.AddParameter("id", p.Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }


        public bool Delete(int Id)
        {
            Command cmd = new Command("DeleteProduct", true);

            cmd.AddParameter("id", Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    }
}

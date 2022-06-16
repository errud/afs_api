using AdoToolbox;
using AfrikSoko_DAL.Interface;
using AfrikSoko_DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Repository
{
    public class ProductTypeRepo : BaseRepository, IProductTypeRepository
    {
        public ProductTypeRepo(IConfiguration config) : base(config)
        {
        }
        internal ProductType Converter(SqlDataReader reader)
        {
            return new ProductType
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString()
            };
        }

        public IEnumerable<ProductType> GetAll()
        {
            Command cmd = new Command("SELECT * FROM ProductType");

            return cnx.ExecuteReader(cmd, Converter);
        }
        public string GetNameById(int Id)
        {
            Command cmd = new Command("SELECT Name FROM ProductType WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteScalar(cmd).ToString() ?? "";
        }
        public bool Create(ProductType pt)
        {
            Command cmd = new Command("AddProductType", true);

            cmd.AddParameter("name", pt.Name);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<ProductType> GetFavoriteByUserId(int id)
        {
           
            string sql = "SELECT * FROM V_FavoriteProdType WHERE uid = @id";

            Command cmd = new Command(sql);
            cmd.AddParameter("id", id);

            return cnx.ExecuteReader(cmd, Converter);
        }

        public void AddFavorite(int newUserId, int prodtypeId)
        {
            Command cmd = new Command("INSERT INTO FavoriteProductType (AppUserId, ProdtypeId) VALUES (@uid, @pid)");

            cmd.AddParameter("uid", newUserId);
            cmd.AddParameter("pid", prodtypeId);

            cnx.ExecuteNonQuery(cmd);
        }
    }
}

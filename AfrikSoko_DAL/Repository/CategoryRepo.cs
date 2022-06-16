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
    public class CategoryRepo : BaseRepository, ICategoryRepository
    {
        public CategoryRepo(IConfiguration config) : base(config)
        {
        }

        internal Category Converter(SqlDataReader reader)
        {
            return new Category
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Url = reader["Url"].ToString()
            };
        }

        public IEnumerable<Category> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Category");
            return cnx.ExecuteReader(cmd, Converter);
        }


        public string GetNameById(int Id)
        {
            Command cmd = new Command("SELECT Name FROM Category WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteScalar(cmd).ToString() ?? "";
        }

        public string GetUrlById(int Id)
        {
            Command cmd = new Command("SELECT Url FROM Category WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteScalar(cmd).ToString() ?? "";
        }

        public bool Create(Category c)
        {
            Command cmd = new Command("AddCategory", true);

            cmd.AddParameter("name", c.Name);
            cmd.AddParameter("url", c.Url);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public bool Update(Category c)
        {
            Command cmd = new Command("UpdateCategory", true);

            cmd.AddParameter("name", c.Name);
            cmd.AddParameter("url", c.Url);
            cmd.AddParameter("id", c.Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DeleteCategory", true);

            cmd.AddParameter("id", Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    }
}

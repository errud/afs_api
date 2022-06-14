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
    public class BuyerRepo : BaseRepository, IBuyerRepository<Buyer, User>
    {
        public BuyerRepo(IConfiguration config) : base(config)
        {
        }

        public IEnumerable<Buyer> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Buyer");

            return cnx.ExecuteReader(cmd, Converters.BuyerConverter);
        }

        public Buyer GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM Buyer WHERE Id = @id");
            cmd.AddParameter("id", Id);

            return cnx.ExecuteReader(cmd, Converters.BuyerConverter).FirstOrDefault();
        }

        public User GetUserByBuyer(int Id)
        {
            Command cmd = new Command("SELECT u.FirstName as FirstName, u.LastName as LastName, u.Email as Email FROM AppUser u JOIN Buyer b ON b.UserId = u.Id WHERE b.UserId = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteReader(cmd, Converters.Convert).FirstOrDefault();
            
        }

        public bool Create(Buyer buyer)
        {
            Command cmd = new Command("AddBuyer", true);

            cmd.AddParameter("userid", buyer.UserId);
            cmd.AddParameter("tel", buyer.Phone);
            cmd.AddParameter("city", buyer.City);
            cmd.AddParameter("ctry", buyer.Country);
            cmd.AddParameter("company", buyer.Company);
            cmd.AddParameter("url", buyer.Url);
            try
            {
                return cnx.ExecuteNonQuery(cmd) == 1;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(Buyer buyer)
        {
            Command cmd = new Command("UpdateBuyer", true);

            cmd.AddParameter("userid", buyer.UserId);
            cmd.AddParameter("tel", buyer.Phone);
            cmd.AddParameter("city", buyer.City);
            cmd.AddParameter("ctry", buyer.Country);
            cmd.AddParameter("company", buyer.Company);
            cmd.AddParameter("url", buyer.Url);
            cmd.AddParameter("id", buyer.Id);

            return cnx.ExecuteNonQuery(cmd) == 1;

        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DeleteBuyer", true);

            cmd.AddParameter("id", Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    }
}

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
    public class AddressRepo : BaseRepository, IAddressRepository
    {
        public AddressRepo(IConfiguration config) : base(config)
        {
        }

        internal Address Converter(SqlDataReader reader)
        {
            return new Address
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                Street = reader["Street"].ToString(),
                City = reader["City"].ToString(),
                State = reader["State"].ToString(),
                Zip = reader["Zip"].ToString(),
                Country = reader["Country"].ToString()
            };

        }
      
        public IEnumerable<Address> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Addresses");

            return cnx.ExecuteReader(cmd, Converter);
        }

        public IEnumerable<Address> GetByUserId(int Id)
        {
            Command cmd = new Command("SELECT * FROM Addresses WHERE UserId = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteReader(cmd, Converter);
        }

        public bool Create(Address address)
        {
            Command cmd = new Command("AddAddress", true);

            cmd.AddParameter("userid", address.UserId);
            cmd.AddParameter("street", address.Street);
            cmd.AddParameter("city", address.City);
            cmd.AddParameter("state", address.State);
            cmd.AddParameter("zipc", address.Zip);
            cmd.AddParameter("ctry", address.Country);
            try
            {
                return cnx.ExecuteNonQuery(cmd) == 1;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Update(Address address)
        {
            Command cmd = new Command("UpdateAddress", true);

            cmd.AddParameter("userid", address.UserId);
            cmd.AddParameter("street", address.Street);
            cmd.AddParameter("city", address.City);
            cmd.AddParameter("state", address.State);
            cmd.AddParameter("zipc", address.Zip);
            cmd.AddParameter("ctry", address.Country);
            cmd.AddParameter("id", address.Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DeleteAddress", true);

            cmd.AddParameter("id", Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    }
       
}

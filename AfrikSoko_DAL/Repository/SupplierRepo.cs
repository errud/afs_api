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
    public class SupplierRepo : BaseRepository, ISupplierRepository<Supplier, User>
    {
        public SupplierRepo(IConfiguration config) : base(config)
        {
        }
        


        public IEnumerable<Supplier> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Supplier");

            return cnx.ExecuteReader(cmd, Converters.SupplierConverter);
        }

        public Supplier GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM Supplier WHERE Id = @id");
            cmd.AddParameter("id", Id);

            return cnx.ExecuteReader(cmd, Converters.SupplierConverter).FirstOrDefault();
        }

        public IEnumerable<Supplier> GetBySector(int Id)
        {
            Command cmd = new Command("SELECT * FROM Supplier WHERE SectorId = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteReader(cmd, Converters.SupplierConverter);
        }

        public IEnumerable<Supplier> GetByService(int Id)
        {
            Command cmd = new Command("SELECT * FROM Supplier WHERE ServiceId = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteReader(cmd, Converters.SupplierConverter);

        }

        public User GetUserBySupplier(int Id)
        {
            Command cmd = new Command("SELECT u.FirstName as FirstName, u.LastName as LastName, u.Email as Email FROM AppUser u JOIN Supplier s ON s.UserId = u.Id WHERE s.UserId = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteReader(cmd, Converters.Convert).FirstOrDefault();
        }
        public bool Create(Supplier supplier)
        {
            Command cmd = new Command("AddSupplier", true);

            cmd.AddParameter("userid", supplier.UserId);
            cmd.AddParameter("company", supplier.Company);
            cmd.AddParameter("logo", supplier.Logo);
            cmd.AddParameter("secId", supplier.SectorId);
            cmd.AddParameter("serId", supplier.ServiceId);
            cmd.AddParameter("member", supplier.Membership);
            cmd.AddParameter("contact", supplier.Contact);
            cmd.AddParameter("phone", supplier.Phone);
            cmd.AddParameter("email", supplier.Email);
            cmd.AddParameter("url", supplier.Url);
            cmd.AddParameter("address", supplier.Address);
            cmd.AddParameter("city", supplier.City);
            cmd.AddParameter("ctry", supplier.Country);
            cmd.AddParameter("ainfo", supplier.AdditInfo);
            try
            {
                return cnx.ExecuteNonQuery(cmd) == 1;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public bool Update(Supplier supplier)
        {
            Command cmd = new Command("UpdateSupplier", true);

            cmd.AddParameter("userid", supplier.UserId);
            cmd.AddParameter("company", supplier.Company);
            cmd.AddParameter("logo", supplier.Logo);
            cmd.AddParameter("secId", supplier.SectorId);
            cmd.AddParameter("serId", supplier.ServiceId);
            cmd.AddParameter("member", supplier.Membership);
            cmd.AddParameter("contact", supplier.Contact);
            cmd.AddParameter("phone", supplier.Phone);
            cmd.AddParameter("email", supplier.Email);
            cmd.AddParameter("url", supplier.Url);
            cmd.AddParameter("address", supplier.Address);
            cmd.AddParameter("city", supplier.City);
            cmd.AddParameter("ctry", supplier.Country);
            cmd.AddParameter("ainfo", supplier.AdditInfo);
            cmd.AddParameter("id", supplier.Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }


        public bool Delete(int Id)
        {
            Command cmd = new Command("DeleteSupplier", true);

            cmd.AddParameter("id", Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    }
}

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
    public class ServiceRepo : BaseRepository, IServiceRepository
    {
        public ServiceRepo(IConfiguration config) : base(config)
        {
        }

        internal Service Converter(SqlDataReader reader)
        {
            return new Service
            {
                Id = (int)reader["Id"],
                ServiceName = reader["ServiceName"].ToString(),
                Price = (decimal)reader["Price"],
                Period = reader["Period"].ToString(),
                Note = reader["Note"].ToString()
            };
        }
        public IEnumerable<Service> GetAll()
        {
            Command cmd = new Command("SELECT * FROM ServiceAsked");

            return cnx.ExecuteReader(cmd, Converter);
        }
        public string GetNameById(int Id)
        {
            Command cmd = new Command("SELECT ServiceName FROM ServiceAsked WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteScalar(cmd).ToString() ?? "";
        }
        public bool Create(Service service)
        {
            Command cmd = new Command("AddService", true);

            cmd.AddParameter("servname", service.ServiceName);
            cmd.AddParameter("price", service.Price);
            cmd.AddParameter("period", service.Period);
            cmd.AddParameter("note", service.Note);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    }
}

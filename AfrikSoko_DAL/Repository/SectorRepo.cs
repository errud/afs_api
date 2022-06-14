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
    public class SectorRepo : BaseRepository, ISectorRepository
    {
        public SectorRepo(IConfiguration config) : base(config)
        {
        }

        internal Sector Converter(SqlDataReader reader)
        {
            return new Sector
            {
                Id = (int)reader["Id"],
                SectorName = reader["SectorName"].ToString()
            };
        }


        public IEnumerable<Sector> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Sector");

            return cnx.ExecuteReader(cmd, Converter);
        }

        public string GetNameById(int Id)
        {
            Command cmd = new Command("SELECT SectorName FROM Sector WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteScalar(cmd).ToString() ?? "";
        }
        public bool Create(string name)
        {
            Command cmd = new Command("AddSector", true);

            cmd.AddParameter("secname", name);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }

 
    }
}

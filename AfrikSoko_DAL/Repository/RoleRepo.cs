using AfrikSoko_DAL.Models;
using AfrikSoko_DAL.Interface;
using System.Data.SqlClient;
using AfrikSoko_DAL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AdoToolbox;

namespace AfrikSoko_DAL.Repository
{
    public class RoleRepo : BaseRepository, IRoleRepository
    {
        public RoleRepo(IConfiguration config) : base(config)
        {
        }

        internal AppRole Converter(SqlDataReader reader)
        {
            return new AppRole
            {
                Id = (int)reader["Id"],
                RoleName = (string)reader["RoleName"]
            };
        }

        public IEnumerable<AppRole> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [AppRole]");

            return cnx.ExecuteReader<AppRole>(cmd, Converter);
        }


        public AppRole GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM AppRole WHERE Id = @id");
            cmd.AddParameter("id", Id);

            return cnx.ExecuteReader(cmd, Converter).FirstOrDefault();
        }
    }
}

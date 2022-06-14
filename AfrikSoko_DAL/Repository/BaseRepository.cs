using AdoToolbox;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Repository
{
    public class BaseRepository
    {
        internal Connection cnx;

        IConfiguration _config;

        public BaseRepository(IConfiguration config)
        {
            _config = config;
            cnx = new Connection(config.GetConnectionString("default"));
        }
    }
}

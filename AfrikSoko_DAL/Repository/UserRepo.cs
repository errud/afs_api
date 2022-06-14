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
    public class UserRepo : BaseRepository, IUserRepository<User>
    {
        public UserRepo(IConfiguration config) : base(config)
        {
        }


        internal User Converter(SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                NickName = reader["NickName"].ToString(),
                Role = reader["Role"].ToString()
            };
        }

        public int Register(string email, string password, string firstname, string lastname, string nickname)
        {
        
            Command cmd = new Command("AppUserRegister", true);
            cmd.AddParameter("email", email);
            cmd.AddParameter("passwd", password);
            cmd.AddParameter("fname", firstname);
            cmd.AddParameter("lname", lastname);
            cmd.AddParameter("nickname", nickname);

            return (int)cnx.ExecuteScalar(cmd);
        }

        public User Login(string email, string password)
        {
            Command cmd = new Command("AppUserLogin", true);
            cmd.AddParameter("email", email);
            cmd.AddParameter("passwd", password);

            try
            {
                return cnx.ExecuteReader(cmd, Converter).First();
            }
            catch (SqlException ex)
            {
                throw new ArgumentNullException("User does not exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool? CheckUser(User u)
        {
            string Query = "SELECT Id FROM [AppUser] WHERE Email = @email AND Passwd = @pass";            
            Command cmd = new Command(Query);
            cmd.AddParameter("email", u.Email);
            cmd.AddParameter("pass", u.Passwd);

            int Id;
            try
            {
                Id = (int)cnx.ExecuteScalar(cmd);
            }
            catch (Exception e)
            {
                Id = 0;
                throw new Exception(e.Message);
            }



            if (Id > 0)
            {
                Command checkActive = new Command("SELECT Id FROM [AppUser] WHERE Id = " + Id + " AND IsActive = 1");


                if ((int)cnx.ExecuteScalar(checkActive) > 0) return true;
                else return false;
            }
            else
            {
                return null;
            }
        }              
        
        public IEnumerable<User> GetAll()
        {
            Command cmd = new Command("SELECT * FROM V_AppUser");

            return cnx.ExecuteReader<User>(cmd, Converters.Convert);
        }

        public User GetById(int Id)
        {
            Command cmd = new Command("SELECT * FROM [AppUser] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteReader(cmd, Converters.Convert).FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            Command cmd = new Command("SELECT * FROM [AppUser] WHERE Email = @email");
            cmd.AddParameter("email", email);

            return cnx.ExecuteReader(cmd, Converters.Convert).FirstOrDefault();
        }           

        public void SetAdmin(int Id)
        {
            string Query = "UPDATE [AppUser] SET RoleId = @role WHERE Id = @id";
            Command cmd = new Command(Query);
            cmd.AddParameter("role", 3);
            cmd.AddParameter("id", Id);

            cnx.ExecuteNonQuery(cmd);
        }

        public void Update(User u)
        {
            string query = "UPDATE [AppUser] SET Email = @email, FirstName = @firstName, LastName = @lastName, NickName = @nickname" +
               " WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("email", u.Email);
            cmd.AddParameter("firstName", u.FirstName);
            cmd.AddParameter("lastName", u.LastName);
            cmd.AddParameter("nickname", u.NickName);
            cmd.AddParameter("Id", u.Id);

            cnx.ExecuteNonQuery(cmd);
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM [AppUser] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    }
}

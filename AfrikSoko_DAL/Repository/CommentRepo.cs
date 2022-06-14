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
    public class CommentRepo : BaseRepository, ICommentRepository
    {
        public CommentRepo(IConfiguration config) : base(config)
        {
        }

        internal Comment Converter(SqlDataReader reader)
        {
            return new Comment
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                ProductId = (int)reader["ProductId"],
                Content = reader["Content"].ToString(),
                PostDate = (DateTime)reader["Created"]
            };
        }

        public IEnumerable<Comment> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Comments");

            return cnx.ExecuteReader(cmd, Converter);
        }

        public IEnumerable<CommentOverview> GetCommentByUser(int userId)
        {
            Command cmd = new Command("SELECT a.FirstName as FirstName, a.LastName as LastName, c.Content as Content, p.Title as [ProductName], c.Created as Created, a.Email as Email, c.UserId as UserId FROM AppUser a JOIN Comments c ON c.UserId = a.Id JOIN Product p ON p.Id = c.ProductId WHERE c.UserId = @Id");
            cmd.AddParameter("Id", userId);

            return cnx.ExecuteReader(cmd, Converters.CommmentDetailedConverter);
        }

        public string GetCommentById(int Id)
        {
            Command cmd = new Command("SELECT Content FROM Comments WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return cnx.ExecuteScalar(cmd).ToString() ?? "";
        }

        public bool Create(Comment comment)
        {
            Command cmd = new Command("AddComment", true);

            cmd.AddParameter("userid", comment.UserId);
            cmd.AddParameter("prodid", comment.ProductId);
            cmd.AddParameter("note", comment.Content);
            try
            {
                return cnx.ExecuteNonQuery(cmd) == 1;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(Comment comment)
        {
            Command cmd = new Command("UpdateComment", true);

            cmd.AddParameter("userid", comment.UserId);
            cmd.AddParameter("prodid", comment.ProductId);
            cmd.AddParameter("note", comment.Content);
            cmd.AddParameter("id", comment.Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DeleteComment", true);

            cmd.AddParameter("id", Id);

            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    }
}

using AfrikSoko_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfrikSoko_DAL.Interface
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAll();
        IEnumerable<CommentOverview> GetCommentByUser(int userid);
        string GetCommentById(int Id);
        bool Create(Comment comment);
        bool Update(Comment comment);
        bool Delete(int Id);
    }
}

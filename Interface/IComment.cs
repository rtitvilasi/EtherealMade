using EtherealMadeFin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtherealMadeFin.Interface
{
    public interface IComment
    {
        IEnumerable<Comment> GetAll();
        Comment GetById(int id);
        IEnumerable<Comment> GetCommentsByCategory(int id);
        Task AddComment(Comment comment);
        Task Delete(int Commentid);
        
    }
}

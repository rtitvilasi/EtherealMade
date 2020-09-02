using EtherealMadeFin.Data;
using EtherealMadeFin.Interface;
using EtherealMadeFin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtherealMadeFin.InterfaceImplementation
{
    public class CommentImplementation : IComment
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentImplementation(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int Commentid)
        {
            var comment = GetById(Commentid);
            _dbContext.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetAll()
        {
            var comment = _dbContext.Comments;
            return comment;
        }

        public Comment GetById(int id)
        {
            return _dbContext.Comments.Where(comment => comment.CommentId == id)
                .Include(comment => comment.Product)
                .FirstOrDefault();
        }
        public IEnumerable<Comment> GetCommentsByCategory(int id)
        {
            var product = _dbContext.Products.Where(products => products.ProductId == id).FirstOrDefault();
            return product.Comments;
        }
    }
}

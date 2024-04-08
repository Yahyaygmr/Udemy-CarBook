using CarBook.Application.Features.Repository;
using CarBook.Application.Interfaces.CommentRepositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Comment> GetCommentByBlogId(int blogId)
        {
            var blog = _context.Blogs.Find(blogId);
            int bogId = blog.BlogId;

            return _context.Comments
                .Where(c => c.BlogId == bogId)
                .ToList();
        }
    }
}

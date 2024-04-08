using CarBook.Application.Interfaces.AuthorInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.AuthorRepositories
{
   
    public class AuthorRepository: IAuthorRepository
    {
        private readonly CarBookContext _context;

        public AuthorRepository(CarBookContext context)
        {
            _context = context;
        }

        public Author GetAuthorByBlogId(int blogId)
        {
            Blog? blog = _context.Blogs.Where(x => x.BlogId == blogId).FirstOrDefault();
            int authorId = blog.AuthorId;

            return _context.Authors.Find(authorId);

        }
    }
}

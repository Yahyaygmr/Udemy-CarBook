using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CommentRepositories
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentByBlogId(int blogId);
    }
}

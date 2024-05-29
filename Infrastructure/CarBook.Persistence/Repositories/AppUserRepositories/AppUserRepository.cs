using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CarBookContext _context;

        public AppUserRepository(CarBookContext context)
        {
            _context = context;
        }

        public AppUser GetByFilter(Expression<Func<AppUser, bool>> filter)
        {
            return _context.AppUsers
                .Include(x=>x.AppRole)
                .Where(filter).FirstOrDefault();
        }

        public Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> GetListByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}

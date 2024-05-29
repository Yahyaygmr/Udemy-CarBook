using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        AppUser GetByFilter(Expression<Func<AppUser, bool>> filter);
        Task<List<AppUser>> GetListByFilterAsync(Expression<Func<AppUser, bool>> filter);
        Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);
    }
}

using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckApUserQueryHandler : IRequestHandler<GetCheckApUserQuery, GetCheckApUserQueryResult>
    {
        private readonly IAppUserRepository _appUserRepository;

        public GetCheckApUserQueryHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<GetCheckApUserQueryResult> Handle(GetCheckApUserQuery request, CancellationToken cancellationToken)
        {
            var user = _appUserRepository.GetByFilter(x => x.UserName == request.UserName && x.Password == request.Password);
            var value = new GetCheckApUserQueryResult();
            if (user == null)
            {
                value.IsExist = false;
            }
            else
            {
                value.IsExist = true;
                value.UserName = user.UserName;
                value.Role = user.AppRole.RoleName;
                value.Id = user.AppUserId;
            }
            return value;
        }
    }
}

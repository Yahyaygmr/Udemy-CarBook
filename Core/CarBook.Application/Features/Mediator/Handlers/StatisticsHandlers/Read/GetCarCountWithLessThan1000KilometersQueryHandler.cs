using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers.Read
{
    public class GetCarCountWithLessThan1000KilometersQueryHandler : IRequestHandler<GetCarCountWithLessThan1000KilometersQuery, GetCarCountWithLessThan1000KilometersQueryResult>
    {
        public Task<GetCarCountWithLessThan1000KilometersQueryResult> Handle(GetCarCountWithLessThan1000KilometersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

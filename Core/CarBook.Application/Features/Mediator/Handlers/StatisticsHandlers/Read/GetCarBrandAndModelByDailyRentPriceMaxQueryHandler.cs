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
    public class GetCarBrandAndModelByDailyRentPriceMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByDailyRentPriceMaxQuery, GetCarBrandAndModelByDailyRentPriceMaxQueryResult>
    {
        public Task<GetCarBrandAndModelByDailyRentPriceMaxQueryResult> Handle(GetCarBrandAndModelByDailyRentPriceMaxQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class GetCarBrandAndModelByDailyRentPriceMinQueryHandler : IRequestHandler<GetCarBrandAndModelByDailyRentPriceMinQuery, GetCarBrandAndModelByDailyRentPriceMinQueryResult>
    {
        public Task<GetCarBrandAndModelByDailyRentPriceMinQueryResult> Handle(GetCarBrandAndModelByDailyRentPriceMinQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

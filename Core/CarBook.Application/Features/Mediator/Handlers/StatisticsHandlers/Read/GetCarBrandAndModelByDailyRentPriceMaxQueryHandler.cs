using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
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
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByDailyRentPriceMaxQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModelByDailyRentPriceMaxQueryResult> Handle(GetCarBrandAndModelByDailyRentPriceMaxQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelByDailyRentPriceMax();

            return new GetCarBrandAndModelByDailyRentPriceMaxQueryResult
            {
                CarBrandAndModelByDailyRentPriceMax = value,
            };
        }
    }
}

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
    public class GetCarBrandAndModelByDailyRentPriceMinQueryHandler : IRequestHandler<GetCarBrandAndModelByDailyRentPriceMinQuery, GetCarBrandAndModelByDailyRentPriceMinQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByDailyRentPriceMinQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModelByDailyRentPriceMinQueryResult> Handle(GetCarBrandAndModelByDailyRentPriceMinQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelByDailyRentPriceMin();

            return new GetCarBrandAndModelByDailyRentPriceMinQueryResult
            {
                CarBrandAndModelByDailyRentPriceMin = value,
            };
        }
    }
}

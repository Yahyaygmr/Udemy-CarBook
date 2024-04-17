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
    public class GetCarCountWithLessThan1000KilometersQueryHandler : IRequestHandler<GetCarCountWithLessThan1000KilometersQuery, GetCarCountWithLessThan1000KilometersQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountWithLessThan1000KilometersQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountWithLessThan1000KilometersQueryResult> Handle(GetCarCountWithLessThan1000KilometersQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountWithLessThan1000Kilometers();

            return new GetCarCountWithLessThan1000KilometersQueryResult
            {
                CarCountWithLessThan1000Kilometers = value,
            };
        }
    }
}

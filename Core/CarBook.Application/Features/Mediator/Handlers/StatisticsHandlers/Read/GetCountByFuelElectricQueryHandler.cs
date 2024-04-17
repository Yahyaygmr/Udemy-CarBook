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
    public class GetCountByFuelElectricQueryHandler : IRequestHandler<GetCountByFuelElectricQuery, GetCountByFuelElectricQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCountByFuelElectricQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCountByFuelElectricQueryResult> Handle(GetCountByFuelElectricQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCountByFuelElectric();

            return new GetCountByFuelElectricQueryResult
            {
                CountByFuelElectric = value,
            };
        }
    }
}

using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces.AuthorInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Read
{
    public class GetAuthorByBlogIdQueryHandler : IRequestHandler<GetAuthorByBlogIdQuery, GetAuthorByBlogIdQueryResult>
    {
        private readonly IAuthorRepository _repository;

        public GetAuthorByBlogIdQueryHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByBlogIdQueryResult> Handle(GetAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAuthorByBlogId(request.Id);
            return new GetAuthorByBlogIdQueryResult
            {
                AuthorId = value.AuthorId,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Name = value.Name,
            };
        }
    }
}

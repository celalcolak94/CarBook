using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery ,GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetServiceByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                AuthorID = value.AuthorID,
                Name = value.Name,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };
        }
    }
}

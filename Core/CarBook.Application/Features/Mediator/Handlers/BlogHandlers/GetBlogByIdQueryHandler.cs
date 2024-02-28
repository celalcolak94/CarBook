using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetBlogByIdQuery ,GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetServiceByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                BlogID = value.BlogID,
                AuthorID = value.AuthorID,
                CategoryID = value.CategoryID,
                CoverImageUrl = value.CoverImageUrl,
                CreatedDate = value.CreatedDate,
                Description = value.Description,
                Title = value.Title
            };
        }
    }
}

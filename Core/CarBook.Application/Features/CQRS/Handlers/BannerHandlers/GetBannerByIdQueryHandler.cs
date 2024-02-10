using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var value = await _repository.GetByIDAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerID = value.BannerID,
                Description = value.Description,
                Title = value.Title,
                VideoDescription = value.VideoDescription,
                VideoUrl = value.VideoUrl
            };
        }
    }
}

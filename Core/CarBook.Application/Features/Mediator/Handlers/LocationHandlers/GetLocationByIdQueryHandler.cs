using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetLocationByIdQuery ,GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetServiceByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.Id);
            return new GetLocationByIdQueryResult
            {
                LocationID = value.LocationID,
                Name = value.Name
            };
        }
    }
}

using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery ,GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetServiceByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialID = value.TestimonialID,
                Name = value.Name,
                Comment = value.Comment,
                ImageUrl = value.ImageUrl,
                Title = value.Title
            };
        }
    }
}

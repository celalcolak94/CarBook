using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateServiceCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.BlogID);
            value.AuthorID = request.AuthorID;
            value.Title = request.Title;
            value.Description = request.Description;
            value.CreatedDate = request.CreatedDate;
            value.CategoryID = request.CategoryID;
            value.CoverImageUrl = request.CoverImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}

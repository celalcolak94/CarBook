using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIDAsync(command.BannerID);
            value.VideoDescription = command.VideoDescription;
            value.Title = command.Title;
            value.VideoUrl = command.VideoUrl;
            value.Description = command.Description;
            await _repository.UpdateAsync(value);
        }
    }
}

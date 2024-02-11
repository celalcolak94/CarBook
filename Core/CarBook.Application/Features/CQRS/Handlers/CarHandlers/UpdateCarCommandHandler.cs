using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIDAsync(command.CarID);
            value.Fuel = command.Fuel;
            value.Transmission = command.Transmission;
            value.BigImageUrl = command.BigImageUrl;
            value.Km = command.Km;
            value.CoverImageUrl = command.CoverImageUrl;
            value.BrandID = command.BrandID;
            value.Luggage = command.Luggage;
            value.Model = command.Model;
            value.Seat = command.Seat;
            await _repository.UpdateAsync(value);
        }
    }
}

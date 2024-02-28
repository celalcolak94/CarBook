using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarListWithBrand();
        Task<List<Car>> GetLast5CarsWithBrand();
    }
}

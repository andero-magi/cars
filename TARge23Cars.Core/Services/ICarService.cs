namespace TARge23Cars.Core.Services;

using TARge23Cars.Core.Domain;
using TARge23Cars.Core.Dto;

public interface ICarService
{
  public Task<Car?> GetCarById(Guid id);

  public Task<List<Car>> GetAllCars();

  public Task<Car> CreateCar(CarDto dto);

  public Task<Car> UpdateCar(CarDto dto);

  public Task<Car?> RemoveCar(Guid id);
}

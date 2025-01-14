namespace TARge23Cars.ApplicationServices;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TARge23Cars.Core.Domain;
using TARge23Cars.Core.Dto;
using TARge23Cars.Core.Services;
using TARge23Cars.Data;

public class CarsService : ICarService
{
  private readonly CarsDbContext _ctx;

  public CarsService(CarsDbContext ctx)
  {
    _ctx = ctx;
  }

  public async Task<Car> CreateCar(CarDto dto)
  {
    Car c = new();
    dto.TransferTo(c);
    
    c.Id = Guid.NewGuid();
    c.CreationDate = DateTime.Now;
    c.LastModified = DateTime.Now;

    await _ctx.Cars.AddAsync(c);
    await _ctx.SaveChangesAsync();

    return c;
  }

  public async Task<List<Car>> GetAllCars()
  {
    return await _ctx.Cars.ToListAsync();
  }

  public async Task<Car?> GetCarById(Guid id)
  {
    return await _ctx.Cars.FindAsync(id);
  }

  public async Task<Car?> RemoveCar(Guid id)
  {
    var car = await GetCarById(id);
    if (car == null) 
    {
      return null;
    }

    _ctx.Cars.Remove(car);
    await _ctx.SaveChangesAsync();

    return car;
  }

  public async Task<Car> UpdateCar(CarDto dto)
  {
    Car c = new();
    dto.TransferTo(c);

    c.LastModified = DateTime.Now;
    
    _ctx.Cars.Update(c);
    await _ctx.SaveChangesAsync();

    return c;
  }
}

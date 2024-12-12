namespace TARge23Cars.Data;

using System;
using TARge23Cars.Core.Domain;

public class DbInitializer
{
  public static void InitializeDb(CarsDbContext ctx) 
  {
    if (ctx.Cars.Any()) {
      return;
    }

    Car[] cars = [
      new()
      {
        Id = Guid.NewGuid(),
        ModelName = "Model C",
        SerialNumber = 23534534,
        Manufacturer = "Made Up Car Company",
        ManufacturerCountry = "Federation of Avignon Guilds",
        CreationDate = DateTime.Now,
        LastModified = DateTime.Now,
      },
      new()
      {
        Id = Guid.NewGuid(),
        ModelName = "V2",
        SerialNumber = 98787,
        Manufacturer = "Electrics and Cars",
        ManufacturerCountry = "US",
        CreationDate = DateTime.Now,
        LastModified = DateTime.Now,
      }
    ];

    ctx.Cars.AddRange(cars);
    ctx.SaveChanges();
  }
}

namespace TARge23Cars.Data;

using Microsoft.EntityFrameworkCore;
using TARge23Cars.Core.Domain;

public class CarsDbContext: DbContext
{
  public DbSet<Car> Cars{ get; set; }

  public CarsDbContext(DbContextOptions opts): base(opts)
  {

  }
}

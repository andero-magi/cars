namespace TARge23Cars;

using Microsoft.EntityFrameworkCore;
using TARge23Cars.ApplicationServices;
using TARge23Cars.Core.Services;
using TARge23Cars.Data;

public class Program {
  public static void Main(string[] args) 
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    builder.Services.AddScoped<ICarService, CarsService>();

    builder.Services.AddDbContext<CarsDbContext>(options => 
    {
      options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        opt => opt.EnableRetryOnFailure()
      );
    });

    var app = builder.Build();

    InitDatabase(app);

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
      app.UseExceptionHandler("/Home/Error");
      // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
  }

  static void InitDatabase(WebApplication app) 
  {
    using IServiceScope scope = app.Services.CreateScope();
    IServiceProvider services = scope.ServiceProvider;

    try 
    {
      CarsDbContext ctx = services.GetRequiredService<CarsDbContext>();
      ctx.Database.Migrate();
      DbInitializer.InitializeDb(ctx);
    }
    catch (Exception ex)
    {
      var logger = services.GetRequiredService<ILogger>();
      logger.LogError(ex, "Error while initializing the database.");
    }
  }
}
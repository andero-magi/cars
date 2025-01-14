namespace TARge23Cars.Tests;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TARge23Cars.ApplicationServices;
using TARge23Cars.Core.Services;
using TARge23Cars.Data;

public abstract class TestBase
{
    protected IServiceProvider ServiceProvider { get; set; }

    protected TestBase()
    {
        var services = new ServiceCollection();
        SetupServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    protected T Svc<T>()
    {
        return ServiceProvider.GetService<T>();
    }

    public virtual void SetupServices(IServiceCollection services)
    {
        services.AddScoped<IHostEnvironment, MockHostEnvironment>();
        services.AddScoped<ICarService, CarsService>();

        services.AddDbContext<CarsDbContext>(x =>
        {
            x.UseInMemoryDatabase("TEST");
            x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        });
    }
}

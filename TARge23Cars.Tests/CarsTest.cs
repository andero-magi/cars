using TARge23Cars.Core.Domain;
using TARge23Cars.Core.Dto;
using TARge23Cars.Core.Services;

namespace TARge23Cars.Tests;

public class CarsTest : TestBase
{
    [Fact]
    public async void Should_AddCar_WhenReturnResult()
    {
        CarDto dto = CreateMock();

        Car result = await Svc<ICarService>().CreateCar(dto);

        Assert.NotNull(result);

        Assert.Equal(dto.ModelName, result.ModelName);
        Assert.Equal(dto.Manufacturer, result.Manufacturer);
        Assert.Equal(dto.ManufacturerCountry, result.ManufacturerCountry);
        Assert.Equal(dto.SerialNumber, result.SerialNumber);
    }

    [Fact]
    public async void Should_GetCarById_WhenAdded()
    {
        CarDto dto = CreateMock();
        ICarService svc = Svc<ICarService>();

        Car car = await svc.CreateCar(dto);
        Car? found = await svc.GetCarById(car.Id);

        Assert.NotNull(found);
        Assert.Equal(car, found);
    }

    [Fact]
    public async void ShouldNot_GetCarById_WhenRemoved()
    {
        CarDto dto = CreateMock();
        ICarService svc = Svc<ICarService>();

        Car car = await svc.CreateCar(dto);
        await svc.RemoveCar(car.Id);

        Car? found = await svc.GetCarById(car.Id);

        Assert.Null(found);
    }

    [Fact]
    public async void ShouldNot_DeleteCar_WhenNotAdded()
    {
        CarDto dto = CreateMock();
        ICarService svc = Svc<ICarService>();

        Car car = await svc.CreateCar(dto);
        Guid uid = Guid.NewGuid();

        Car? removed = await svc.RemoveCar(uid);

        Assert.Null(removed);
    }

    private CarDto CreateMock()
    {
        return new()
        {
            Manufacturer = "TestMan",
            ManufacturerCountry = "USA",
            ModelName = "TestModel",
            SerialNumber = 34325
        };
    }
}
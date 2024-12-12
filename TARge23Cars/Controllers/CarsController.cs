namespace TARge23Cars.Controllers;

using Microsoft.AspNetCore.Mvc;
using TARge23Cars.Core.Domain;
using TARge23Cars.Core.Dto;
using TARge23Cars.Core.Services;
using TARge23Cars.Models.Cars;

public class CarsController : Controller
{
  private readonly ICarService _cars;

  public CarsController(ICarService service)
  {
    _cars = service;
  }

  public async Task<ActionResult> Index()
  {
    List<Car> list = await _cars.GetAllCars();
    IndexViewModel vm = new() 
    {
      Cars = list
    };

    return View(vm);
  }

  public async Task<IActionResult> Create()
  {
    ViewData["IsCreate"] = "true";

    CarCreateUpdateViewModel vm = new() 
    {
      Dto = new()
    };

    return View("CreateUpdate", vm);
  }

  [HttpPost]
  public async Task<IActionResult> Create(CarCreateUpdateViewModel vm) {
    if (vm == null || vm.Dto == null) 
    {
      return NotFound();
    }

    Car c = await _cars.CreateCar(vm.Dto);

    return RedirectToAction(nameof(Index));
  }

  public async Task<IActionResult> Edit(Guid? carId)
  {
    if (carId == null) 
    {
      return NotFound();
    }

    Car? car = await _cars.GetCarById((Guid) carId);
    if (car == null) 
    {
      return NotFound();
    }

    CarCreateUpdateViewModel vm = new()
    {
      Dto = new(car)
    };

    ViewData["IsCreate"] = "false";
    return View("CreateUpdate", vm);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(CarCreateUpdateViewModel vm)
  {
    if (vm == null || vm.Dto == null) 
    {
      return NotFound();
    }

    Car c = await _cars.UpdateCar(vm.Dto);

    return RedirectToAction(nameof(Index));
  }

  public async Task<IActionResult> Delete(Guid? carId)
  {
    if (carId == null) 
    {
      return NotFound();
    }

    var car = await _cars.GetCarById((Guid) carId);
    if (car == null) 
    {
      return NotFound();
    }

    CarDeleteViewModel vm = new()
    {
      Car = car
    };

    return View(vm);
  }

  public async Task<IActionResult> DeleteConfirm(Guid? carId)
  {
    if (carId == null) 
    {
      return NotFound();
    }

    await _cars.RemoveCar((Guid) carId);

    return RedirectToAction(nameof(Index));
  }

  public async Task<IActionResult> Details(Guid? carId)
  {
    if (carId == null) 
    {
      return NotFound();
    }

    var car = await _cars.GetCarById((Guid) carId);
    if (car == null) 
    {
      return NotFound();
    }

    CarDetailsViewModel vm = new()
    {
      Car = car
    };

    return View(vm);
  }
}

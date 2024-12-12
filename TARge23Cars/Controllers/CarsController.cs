namespace TARge23Cars.Controllers;

using Microsoft.AspNetCore.Mvc;
using TARge23Cars.Core.Domain;
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
    return View();
  }

  public async Task<IActionResult> Edit(Guid? carId)
  {
    return View();
  }

  public async Task<IActionResult> Delete(Guid? carId)
  {
    return View();
  }

  public async Task<IActionResult> Details(Guid? carId)
  {
    return View();
  }
}

namespace TARge23Cars.Core.Dto;

using TARge23Cars.Core.Domain;

public class CarDto
{
  public Guid Id { get; set; }
  public string ModelName { get; set; }
  public int SerialNumber { get; set; }
  public string Manufacturer { get; set; }
  public string ManufacturerCountry { get; set; }
  public DateTime CreationDate { get; set; }
  public DateTime LastModified { get; set; }

  public CarDto()
  {

  }

  public CarDto(Car car)
  {
    Id = car.Id;
    ModelName = car.ModelName;
    SerialNumber = car.SerialNumber;
    Manufacturer = car.Manufacturer;
    ManufacturerCountry = car.ManufacturerCountry;
    CreationDate = car.CreationDate;
    LastModified = car.LastModified;
  }

  public void TransferTo(Car car) 
  {
    car.Id = Id;
    car.ModelName = ModelName;
    car.SerialNumber = SerialNumber;
    car.Manufacturer = Manufacturer;
    car.ManufacturerCountry = ManufacturerCountry;
    car.CreationDate = CreationDate;
    car.LastModified = LastModified;
  }
}

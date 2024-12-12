namespace TARge23Cars.Core.Domain;

public class Car
{
  public Guid Id { get; set; }
  public string ModelName { get; set; }
  public int SerialNumber { get; set; }
  public string Manufacturer { get; set; }
  public string ManufacturerCountry { get; set; }
  public DateTime CreationDate { get; set; }
  public DateTime LastModified { get; set; }
}

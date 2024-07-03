using si730ebucodigo.API.Inventory.Domain.Model.Commands;
using si730ebucodigo.API.Inventory.Domain.Model.ValueObjects;
using si730ebucodigo.API.Maintenance.Domain.Model.Aggregates;

namespace si730ebucodigo.API.Inventory.Domain.Model.Aggregates;

public class Product
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public EStatus Status { get; set; } // This is a value object with type int
    
    //This field is statusDescription, and it is not in the database
    public string StatusDescription { get; set; }
    
    public MaintenanceActivity MaintenanceActivity { get; set; }
    
    public Product()
    {
    }

    public Product(CreateProductCommand command)
    {
        Brand = command.Brand;
        Model = command.Model;
        SerialNumber = command.SerialNumber;
        StatusDescription = command.StatusDescription;
        if(Enum.TryParse<EStatus>(command.StatusDescription, out var statusResult))
        {
            Status = statusResult;
        }
        else
        {
            throw new ArgumentException("Invalid status description");
        }
    }
}
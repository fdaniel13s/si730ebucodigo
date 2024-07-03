using si730ebucodigo.API.Inventory.Domain.Model.Aggregates;
using si730ebucodigo.API.Maintenance.Domain.Model.Commands;
using si730ebucodigo.API.Maintenance.Domain.Model.ValueObjects;

namespace si730ebucodigo.API.Maintenance.Domain.Model.Aggregates;

public class MaintenanceActivity
{
    public int Id { get; set; }
    public string ProductSerialNumber { get; set; }
    //Relation one to one with product
    public Product Product { get; set; }
    public ProductId ProductId { get; set; }
    
    public string Summary { get; set; }
    public string Description { get; set; }
    public EActivityResult ActivityResult { get; set; }
    
    public MaintenanceActivity() { }
    
    public MaintenanceActivity(CreateMaintenanceActivityCommand command, int productId)
    {
        ProductId = new ProductId(productId);
        ProductSerialNumber = command.ProductSerialNumber;
        Summary = command.Summary;
        Description = command.Description;
        ActivityResult = (EActivityResult)command.ActivityResult;
    }
    
}
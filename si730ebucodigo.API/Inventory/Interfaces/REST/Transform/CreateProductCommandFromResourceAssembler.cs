using si730ebucodigo.API.Inventory.Domain.Model.Commands;
using si730ebucodigo.API.Inventory.Interfaces.REST.Resources;

namespace si730ebucodigo.API.Inventory.Interfaces.REST.Transform;

public class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(
            resource.Brand, resource.Model,
            resource.SerialNumber, resource.StatusDescription);
    }
}
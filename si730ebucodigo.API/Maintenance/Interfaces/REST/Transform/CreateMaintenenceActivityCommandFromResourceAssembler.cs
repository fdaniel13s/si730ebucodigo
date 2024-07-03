using si730ebucodigo.API.Maintenance.Domain.Model.Commands;
using si730ebucodigo.API.Maintenance.Interfaces.REST.Resources;

namespace si730ebucodigo.API.Maintenance.Interfaces.REST.Transform;

public class CreateMaintenenceActivityCommandFromResourceAssembler
{
    public static CreateMaintenanceActivityCommand ToCommandFromResource(CreateMaintenanceActivityResource resource)
    {
        return new CreateMaintenanceActivityCommand(
            resource.ProductSerialNumber,
            resource.Summary,
            resource.Description,
            resource.ActivityResult
        );
    }
}
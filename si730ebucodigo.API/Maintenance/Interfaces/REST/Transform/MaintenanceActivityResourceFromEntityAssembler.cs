using si730ebucodigo.API.Maintenance.Domain.Model.Aggregates;
using si730ebucodigo.API.Maintenance.Interfaces.REST.Resources;

namespace si730ebucodigo.API.Maintenance.Interfaces.REST.Transform;

public class MaintenanceActivityResourceFromEntityAssembler
{
    public static MaintenanceActivityResource ToResourceFromEntity(MaintenanceActivity entity)
    {
        return new MaintenanceActivityResource(
            entity.Id,
            entity.Product.SerialNumber,
            entity.Summary,
            entity.Description,
            entity.ActivityResult.ToString()
        );
    }
}
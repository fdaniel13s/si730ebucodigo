namespace si730ebucodigo.API.Maintenance.Interfaces.REST.Resources;

public record CreateMaintenanceActivityResource(
    string ProductSerialNumber, string Summary, string Description, int ActivityResult
    );
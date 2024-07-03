namespace si730ebucodigo.API.Maintenance.Domain.Model.Commands;

public record CreateMaintenanceActivityCommand(
    string ProductSerialNumber, string Summary, string Description, int ActivityResult
    );
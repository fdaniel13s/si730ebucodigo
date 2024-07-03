using si730ebucodigo.API.Maintenance.Domain.Model.Aggregates;
using si730ebucodigo.API.Maintenance.Domain.Model.Commands;

namespace si730ebucodigo.API.Maintenance.Domain.Services;

public interface IMaintenanceActivityCommandService
{
    Task<MaintenanceActivity?> Handle(CreateMaintenanceActivityCommand command);
}
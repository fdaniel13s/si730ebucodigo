using si730ebucodigo.API.Maintenance.Domain.Model.Aggregates;
using si730ebucodigo.API.Maintenance.Domain.Model.Queries;

namespace si730ebucodigo.API.Maintenance.Domain.Services;

public interface IMaintenanceActivityQueryService
{
    Task<MaintenanceActivity?> Handle(GetMaintenanceActivityByIdQuery query);
}
using si730ebucodigo.API.Maintenance.Domain.Model.Aggregates;
using si730ebucodigo.API.Maintenance.Domain.Model.Queries;
using si730ebucodigo.API.Maintenance.Domain.Repositories;
using si730ebucodigo.API.Maintenance.Domain.Services;

namespace si730ebucodigo.API.Maintenance.Application.Internal.QueryServices;

public class MaintenanceActivityQueryService(IMaintenanceActivityRepository maintenanceActivityRepository):
    IMaintenanceActivityQueryService
{
    public async Task<MaintenanceActivity?> Handle(GetMaintenanceActivityByIdQuery query)
    {
        return await maintenanceActivityRepository.GetByIdAsync(query.Id);
    }
}
using si730ebucodigo.API.Inventory.Domain.Model.Aggregates;
using si730ebucodigo.API.Maintenance.Domain.Model.Aggregates;
using si730ebucodigo.API.Shared.Domain.Repositories;

namespace si730ebucodigo.API.Maintenance.Domain.Repositories;

public interface IMaintenanceActivityRepository: IBaseRepository<MaintenanceActivity>
{
    Task<MaintenanceActivity?> GetByIdAsync(int id);
}
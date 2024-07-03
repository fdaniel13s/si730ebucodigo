using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Digests;
using si730ebucodigo.API.Maintenance.Domain.Model.Aggregates;
using si730ebucodigo.API.Maintenance.Domain.Repositories;
using si730ebucodigo.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebucodigo.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebucodigo.API.Maintenance.Infrastructure.Persistence.EFC.Repositories;

public class MaintenanceActivityRepository(AppDbContext context): BaseRepository<MaintenanceActivity>(context),
    IMaintenanceActivityRepository
{
    public async Task<MaintenanceActivity?> GetByIdAsync(int id)
    {
        return await Context.Set<MaintenanceActivity>().FirstOrDefaultAsync(
            maintenanceActivity => maintenanceActivity.Id == id
        );
    }
}
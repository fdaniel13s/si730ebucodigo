using Microsoft.EntityFrameworkCore;
using si730ebucodigo.API.Inventory.Domain.Model.Aggregates;
using si730ebucodigo.API.Inventory.Domain.Model.ValueObjects;
using si730ebucodigo.API.Inventory.Domain.Repositories;
using si730ebucodigo.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebucodigo.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebucodigo.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context): BaseRepository<Product>(context), IProductRepository
{
    public async Task<Product?> FindBySerialNumberAsync(string serialNumber)
    {
        return await Context.Set<Product>().FirstOrDefaultAsync(p => p.SerialNumber == serialNumber);
    }

    public async Task<Product?> FindByStatusAsync(EStatus status)
    {
        return await Context.Set<Product>().FirstOrDefaultAsync(p => p.Status == status);
    }
}
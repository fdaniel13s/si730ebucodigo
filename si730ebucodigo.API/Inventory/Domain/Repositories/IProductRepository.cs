using si730ebucodigo.API.Inventory.Domain.Model.Aggregates;
using si730ebucodigo.API.Inventory.Domain.Model.ValueObjects;
using si730ebucodigo.API.Shared.Domain.Repositories;

namespace si730ebucodigo.API.Inventory.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product>
{
    Task<Product?> FindByIdAsync(int id);
    Task<Product?> FindBySerialNumberAsync(string serialNumber);
    Task<Product?> FindByStatusAsync(EStatus status);
}
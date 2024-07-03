using si730ebucodigo.API.Inventory.Domain.Model.Aggregates;
using si730ebucodigo.API.Inventory.Domain.Model.Queries;

namespace si730ebucodigo.API.Inventory.Domain.Services;

public interface IProductQueryService
{
    Task<Product?> Handle(GetProductByIdQuery query);
    Task<Product?> Handle(GetProductBySerialNumberQuery query);
    Task<Product?> Handle(GetProductByStatusQuery query);
}
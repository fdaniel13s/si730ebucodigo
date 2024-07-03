using si730ebucodigo.API.Inventory.Domain.Model.Aggregates;
using si730ebucodigo.API.Inventory.Domain.Model.Commands;

namespace si730ebucodigo.API.Inventory.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(CreateProductCommand command);
}
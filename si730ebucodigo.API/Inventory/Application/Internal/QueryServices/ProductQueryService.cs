using si730ebucodigo.API.Inventory.Domain.Model.Aggregates;
using si730ebucodigo.API.Inventory.Domain.Model.Queries;
using si730ebucodigo.API.Inventory.Domain.Model.ValueObjects;
using si730ebucodigo.API.Inventory.Domain.Repositories;
using si730ebucodigo.API.Inventory.Domain.Services;

namespace si730ebucodigo.API.Inventory.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.Id);
    }

    public async Task<Product?> Handle(GetProductBySerialNumberQuery query)
    {
        return await productRepository.FindBySerialNumberAsync(query.SerialNumber);
    }

    public async Task<Product?> Handle(GetProductByStatusQuery query)
    {
        return await productRepository.FindByStatusAsync((EStatus)query.Status);
    }
}
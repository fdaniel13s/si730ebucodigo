using si730ebucodigo.API.Inventory.Interfaces.ACL;
using si730ebucodigo.API.Maintenance.Domain.Model.ValueObjects;

namespace si730ebucodigo.API.Maintenance.Application.Internal.OutboundServices.ACL;

public class ExternalProductService(IProductsContextFacade productsContextFacade)
{
    public async Task<ProductId?> FetchProductIdBySerialNumber(string serialNumber)
    {
        var productId = await productsContextFacade.FetchProductIdBySerialNumber(serialNumber);
        if (productId == 0) return await Task.FromResult<ProductId?>(null);
        return new ProductId(productId);
    }
}
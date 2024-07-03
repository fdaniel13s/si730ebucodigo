using si730ebucodigo.API.Inventory.Domain.Model.Queries;
using si730ebucodigo.API.Inventory.Domain.Services;

namespace si730ebucodigo.API.Inventory.Interfaces.ACL.Services;

public class ProductsContextFacade(IProductCommandService productCommandService,
    IProductQueryService productQueryService): IProductsContextFacade
{
    public async Task<int> FetchProductIdBySerialNumber(string serialNumber)
    {
        var product = await productQueryService.Handle(new GetProductBySerialNumberQuery(serialNumber));
        return product?.Id ?? 0;
    }
}